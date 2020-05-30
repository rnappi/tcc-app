import mysql.connector
import api
from flask_bcrypt  import Bcrypt
import pandas as pd
from sklearn.neighbors import KNeighborsClassifier
from datetime import datetime


bcrypt = Bcrypt(api.app)


def autenticar(json):
    cnx = mysql.connector.connect(user='root', password='root',
                                  host='127.0.0.1',
                                  database='Questionarios')

    cursor = cnx.cursor()
    aluno = {}

    try:
        query = """select * 
                     from alunos as a
                    where a.usuario = %s
                      and a.senha = %s """

        params = (json['Usuario'], json['Senha'])

        cursor.execute(query, params)
        
        for result in cursor:
            aluno = { 'id_Aluno': result[0], 
                      'nome': result[1],
                      'usuario': result[2],
                      'email': result[4],
                      'data_cadastro': result[5],
                      'data_ultima_atualizacao': result[6]}

    except Exception as e:
        cnx.rollback()
        print('Erro ao autenticar usuário: ' + str(e))

    cursor.close()
    cnx.close()
    return aluno


def pegarQuestionarios(idQuestionario):
    cnx = mysql.connector.connect(user='root', password='root',
                                host='127.0.0.1',
                                database='Questionarios')

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
    cnx = mysql.connector.connect(user='root', password='root',
                                host='127.0.0.1',
                                database='Questionarios')

    cursor = cnx.cursor()
    resp = {}

    try:
        query = """select q.id_Questionario,
	                      (select count(1) from perguntas p 
                                          where p.id_Questionario = q.id_Questionario) qtdPerguntas,
                          (select count(1) from perguntas p2
						                   join Alternativas a on a.id_Pergunta = p2.id_Pergunta                        
					                      where p2.id_Questionario =  q.id_Questionario
					                   group by a.id_Pergunta
                                          limit 1) qtdAlternativas,
                          q.Nome as NomeQuestionario
                     from questionarios q"""

        cursor.execute(query)

        payload = []
        content = {}
        for result in cursor:
            content = { 'id_Questionario': result[0], 
                        'qtdPerguntas': result[1],
                        'qtdAlternativas': result[2],
                        'NomeQuestionario': result[3]}

            payload.append(content)

        resp = api.jsonify(payload)

    except Exception as e:
        cnx.rollback()
        print('Erro na conexão com o BD: ' + str(e))

    cursor.close()
    cnx.close()
    return resp


def inserirAluno(json):
    pw_hash = bcrypt.generate_password_hash('hunter2')
    check = bcrypt.check_password_hash(pw_hash, 'hunter2')

    print(pw_hash, check)


def indicarMaterial(json):
    cnx = mysql.connector.connect(user='root', password='root',
                                host='127.0.0.1',
                                database='Questionarios')

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
    cnx = mysql.connector.connect(user='root', password='root',
                            host='127.0.0.1',
                            database='Questionarios')

    cursor = cnx.cursor()
    resp = ""

    try:        
        query = """insert into log_sistema (id_Aluno, id_TipoLogSistema, descricao, data_cadastro) values (%s, %s, %s, NOW());"""

        params = (int(json['Id_Aluno']), int(json['Id_TipoLogSistema']), json['Descricao'])

        cursor.execute(query, params)

        now = datetime.now()
        dt_string = now.strftime("%d/%m/%Y %H:%M:%S")
        resp = f'{{"msg":"Log gerado com sucesso, {dt_string}"}}'

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