import mysql.connector
import api
from flask_bcrypt  import Bcrypt
import pandas as pd
from sklearn.neighbors import KNeighborsClassifier
from datetime import datetime
from api.Utils import util


bcrypt = Bcrypt(api.app)


def pegarConexaoPW():
    cnx = mysql.connector.connect(user='apiquestionarios', password='Root@2020',
                              host='apiquestionarios.mysql.pythonanywhere-services.com',
                              database='apiquestionarios$db')
    return cnx


def pegarConexao():
    cnx = mysql.connector.connect( user='root', 
                                   password='root',
                                   host='127.0.0.1',
                                   database='Questionarios')
    return cnx


def autenticar(json):

    try:
        cnx = pegarConexao()
    except Exception as e:
        erroBD = 'Erro ao conectar no banco, ' + str(e)
        print(erroBD)
        raise Exception(erroBD)

    cursor = cnx.cursor()
    aluno = {}

    try:
        query = """select id_Aluno,
                          nome,
                          usuario,
                          email,
                          data_cadastro,
                          data_ultima_atualizacao
                     from alunos as a
                    where binary a.usuario = %s
                      and binary a.senha = %s """

        params = (json['Usuario'], json['Senha'])

        cursor.execute(query, params)

        for result in cursor:
            aluno = { 'id_Aluno': result[0],
                      'nome': result[1],
                      'usuario': result[2],
                      'email': result[3],
                      'data_cadastro': result[4],
                      'data_ultima_atualizacao': result[5]}

    except Exception as e:
        cnx.rollback()
        print('Erro ao autenticar usuário: ' + str(e))

    cursor.close()
    cnx.close()
    return aluno


def pegarQuestionarios(idQuestionario):
    try:
        cnx = pegarConexao()
    except Exception as e:
        erroBD = 'Erro ao conectar no banco, ' + str(e)
        print(erroBD)
        resp = f'{{"status":0, "msg": "{erroBD}"}}'
        api.Response(resp, mimetype='text/json'), 500

    cursor = cnx.cursor()
    resp = {}

    try:
        query = """select q.id_Questionario,
                          p.id_Pergunta,
                          a.id_Alternativa,
                          q.Nome as NomeQuestionario,
                          p.Pergunta,
                          a.Descricao as DescricaoAlternativa,
                          a.Alternativa_Correta
                     from questionarios q
                     join perguntas p on p.id_Questionario = q.id_Questionario
                     join alternativas a on a.id_Pergunta = p.id_Pergunta 
                     where q.id_Questionario = %s """
        
        params = (int(idQuestionario),) #A virgula é para indicar que é uma tupla

        cursor.execute(query, params)

        payload = []
        content = {}
        for result in cursor:
            content = { 'id_Questionario': result[0], 
                        'id_Pergunta': result[1],
                        'id_Alternativa': result[2],
                        'NomeQuestionario': result[3],
                        'Pergunta': result[4],
                        'DescricaoAlternativa': result[5],
                        'Alternativa_Correta': result[6]}

            payload.append(content)

        resp = api.jsonify(payload)

    except Exception as e:
        cnx.rollback()
        print('Erro na conexão com o BD: ' + str(e))

    cursor.close()
    cnx.close()
    return resp


def pegarQuestionariosAluno(idAluno):
    try:
        cnx = pegarConexao()
    except Exception as e:
        erroBD = 'Erro ao conectar no banco, ' + str(e)
        print(erroBD)
        resp = f'{{"status":0, "msg": "{erroBD}"}}'
        api.Response(resp, mimetype='text/json'), 500

    cursor = cnx.cursor()
    resp = {}

    try:
        query = """SELECT q.id_Questionario,
                          p.id_Pergunta,
                          a.id_Alternativa,
                          q.Nome as nomeQuestionario,
                          p.Pergunta,
                          a.Descricao as descricaoAlternativa,
                          a.Alternativa_Correta,
                          (select count(1) from perguntas p 
                                          where p.id_Questionario = q.id_Questionario) qtdPerguntas,
                          (select count(1) from perguntas p2
						                   join Alternativas a on a.id_Pergunta = p2.id_Pergunta                        
					                      where p2.id_Questionario =  q.id_Questionario
					                   group by a.id_Pergunta
                                          limit 1) qtdAlternativas,
						  ifnull( (select t.id_Tentativa from tentativas t
                                    where t.id_Aluno = %s
                                      and t.id_questionario = q.id_Questionario
                                 order by t.id_Tentativa desc -- tem que pegar a ultima tentativa
                                    limit 1), 0) tentativa,
                          (SELECT COUNT(a.Alternativa_Correta)
							 FROM tentativas t
							 JOIN respostas r
							   ON (t.id_Tentativa = r.id_Tentativa)
							 JOIN alternativas a
							   ON (a.id_Alternativa = r.id_Alternativa)
							WHERE t.id_Aluno = %s
							  AND t.id_Questionario = q.id_Questionario
							  AND a.Alternativa_Correta = 1
							  AND t.id_Tentativa = (select max(id_Tentativa) -- pegar a ultima tentativa
													  from tentativas te
													 where te.id_Aluno = t.id_Aluno 
													   and te.id_Questionario = t.id_Questionario)) qtdAcertos
                     FROM questionarios q
                     JOIN perguntas p on p.id_Questionario = q.id_Questionario
                     JOIN alternativas a on a.id_Pergunta = p.id_Pergunta"""

        params = (idAluno, idAluno)

        cursor.execute(query, params)

        payload = []
        content = {}
        for result in cursor:
            content = { 'idQuestionario': result[0], 
                        'idPergunta': result[1],
                        'idAlternativa': result[2],
                        'nomeQuestionario': result[3],
                        'pergunta': result[4],
                        'descricaoAlternativa': result[5],
                        'alternativaCorreta': result[6],
                        'qtdPerguntas': result[7],
                        'qtdAlternativas': result[8],
                        'tentativa': result[9],
                        'qtdAcertos': result[10]}

            payload.append(content)

        resp = api.jsonify(payload)

    except Exception as e:
        cnx.rollback()
        msgErro = 'Erro na conexão com o BD: ' + str(e)
        print(msgErro)
        resp = {"status":0, "msg":msgErro}

    cursor.close()
    cnx.close()
    return resp


def inserirAluno(json):
    #pw_hash = bcrypt.generate_password_hash('hunter2')
    #check = bcrypt.check_password_hash(pw_hash, 'hunter2')

    try:
        cnx = pegarConexao()
    except Exception as e:
        erroBD = 'Erro ao conectar no banco, ' + str(e)
        print(erroBD)
        raise Exception(erroBD)

    cursor = cnx.cursor()
    resp = ""

    try:        
        query = """insert into alunos (Nome, Email, Usuario, Senha, Data_Cadastro, Data_Ultima_Atualizacao) values (%s, %s, %s, %s, NOW(), NOW());"""

        params = (json['Nome'], json['Email'], json['Usuario'], json['Senha'])

        cursor.execute(query, params)

        now = datetime.now()
        dt_string = now.strftime("%d/%m/%Y %H:%M:%S")
        resp = f'{{"status":1, "msg":"Usuário {json["Usuario"]} cadastrado com sucesso, {dt_string}"}}'

    except Exception as e:
        cnx.rollback()
        cursor.close()
        cnx.close()
        print('Erro na conexão com o BD: ' + str(e))
        raise Exception(str(e))

    cursor.close()
    cnx.commit()
    cnx.close()

    return resp


def indicarMaterial(json):
    try:
        cnx = pegarConexao()
    except Exception as e:
        erroBD = 'Erro ao conectar no banco, ' + str(e)
        print(erroBD)
        raise Exception(erroBD)

    cursor = cnx.cursor()
    resp = ""

    try:
        query = """select Combinacao from view_material_indicado where id_Questionario = %s"""

        params = (int(json['questionario']), )

        cursor.execute(query, params)

        payload = []
        qtdPerguntas = 0 #Guarda a quantidade de perguntas do questionario

        for result in cursor:

            content = result[0].split(",")

            if qtdPerguntas == 0:
                qtdPerguntas = len(content) - 1

            payload.append(content)

        if len(payload) <= 0:
            raise Exception("Questionario não encontrado")

        base = pd.DataFrame(payload)

        #axis=1 indica coluna, o padrão é axis=0 que é linha
        x = base.drop(qtdPerguntas, axis=1) #Remove a coluna Material para pegar apenas as caracteristicas
        y = base[qtdPerguntas] #Pega apenas as classes material

        #Cria o classificador e passa o k
        knn = KNeighborsClassifier(n_neighbors=5)

        #Pega a base de treinamento
        knn.fit(x,y)

        #Tem que ser um dataframe (array 2D)
        classificar = [json['cp']]

        mat = knn.predict(classificar)

        resp = f'{{"material":{mat[0]}}}'

    except Exception as e:
        cnx.rollback()
        print('Erro na conexão com o BD: ' + str(e))
        resp = f'{{"Erro":"{str(e)}"}}'

    cursor.close()
    cnx.close()

    return resp


def salvarLog(json):
    try:
        cnx = pegarConexao()
    except Exception as e:
        erroBD = 'Erro ao conectar no banco, ' + str(e)
        print(erroBD)
        raise Exception(erroBD)

    cursor = cnx.cursor()
    resp = ""

    try:        
        query = """insert into log_sistema (id_Aluno, id_TipoLogSistema, descricao, Localizacao, data_cadastro) values (%s, %s, %s, %s, NOW());"""

        params = (int(json['id_Aluno']), int(json['id_TipoLogSistema']), json['descricao'], json['localizacao'])

        cursor.execute(query, params)

        now = datetime.now()
        dt_string = now.strftime("%d/%m/%Y %H:%M:%S")
        resp = f'{{"status":1, "msg":"Log gerado com sucesso, {dt_string}"}}'

    except Exception as e:
        cnx.rollback()
        cursor.close()
        cnx.close()
        print('Erro na conexão com o BD: ' + str(e))
        raise Exception(str(e))

    cursor.close()
    cnx.commit()
    cnx.close()

    return resp


def salvarQuestionarioRespondido(json):
    
    try:
        cnx = pegarConexao()
    except Exception as e:
        erroBD = 'Erro ao conectar no banco, ' + str(e)
        print(erroBD)
        raise Exception(erroBD)

    cursor = cnx.cursor()
    resp = ""

    try:        
        query = """insert into tentativas (id_Aluno, id_Questionario) values (%s, %s);"""

        params = (json['id_Aluno'], json['id_Questionario'])
        cursor.execute(query, params)

        #Pega o ultimo id inserido pela conexão
        query = """SELECT LAST_INSERT_ID();"""
        cursor.execute(query)

        id_Tentativa = 0

        for result in cursor:
            id_Tentativa = int(result[0])

        for resposta in json['respostas']:
            query = """insert into respostas (id_Tentativa, id_Alternativa) values (%s, %s);"""
            params = (id_Tentativa, int(resposta))
            cursor.execute(query, params)

        query = """SELECT COUNT(a.Alternativa_Correta)
                     FROM tentativas t
	                 JOIN respostas r
		               ON (t.id_Tentativa = r.id_Tentativa)
	                 JOIN alternativas a
            		   ON (a.id_Alternativa = r.id_Alternativa)
                    WHERE t.id_Aluno = %s
                      AND t.id_Questionario = %s
                      AND a.Alternativa_Correta = 1 -- contar apenas as corretas
                      AND t.id_Tentativa = (select max(id_Tentativa) -- ultima tentativa
			            					  from tentativas te
			            					 where te.id_Aluno = t.id_Aluno 
                                               and te.id_Questionario = t.id_Questionario);"""

        params = (json['id_Aluno'], json['id_Questionario'])
        cursor.execute(query, params)

        qtdAcertos = 0
        for result in cursor:
            qtdAcertos = int(result[0])

        now = datetime.now()
        dt_string = now.strftime("%d/%m/%Y %H:%M:%S")
        resp = f'{{"status":1, "msg":"Respostas cadastradas com sucesso, {dt_string}", "idTentativa":{id_Tentativa}, "qtdAcertos":{qtdAcertos}}}'

    except Exception as e:
        cnx.rollback()
        cursor.close()
        cnx.close()
        print('Erro na conexão com o BD: ' + str(e))
        raise Exception(str(e))

    cursor.close()
    cnx.commit()
    cnx.close()

    return resp

    