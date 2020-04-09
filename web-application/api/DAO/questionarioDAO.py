import mysql.connector
import api
import pandas as pd
from sklearn.neighbors import KNeighborsClassifier

def pegarQuestionarios(idQuestionario):
    cnx = mysql.connector.connect(user='root', password='root',
                                host='127.0.0.1',
                                database='Questionarios')

    cursor = cnx.cursor()

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
                     join alternativas a on a.id_Pergunta = p.id_Pergunta """

        query += f"where q.id_Questionario = {idQuestionario}"
        cursor.execute(query)

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

        r = api.jsonify(payload)

    except Exception as e:
        cnx.rollback()
        print('Erro na conexão com o BD: ' + str(e))

    cursor.close()
    cnx.close()
    return r

def indicarMaterial(json):
    cnx = mysql.connector.connect(user='root', password='root',
                                host='127.0.0.1',
                                database='Questionarios')

    cursor = cnx.cursor()
    r = ""

    try:
        query = F"""select Combinacao from view_material_indicado where id_Questionario = {json['questionario']}"""

        cursor.execute(query)

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
        knn = KNeighborsClassifier(n_neighbors=1)

        #Pega a base de treinamento
        knn.fit(x,y)

        #Tem que ser um dataframe (array 2D)
        classificar = [json['cp']]

        mat = knn.predict(classificar)

        r = f'{{"material":{mat[0]}}}'

    except Exception as e:
        cnx.rollback()
        print('Erro na conexão com o BD: ' + str(e))
        r = f'{{"Erro":"{str(e)}"}}'

    cursor.close()
    cnx.close()
    return r