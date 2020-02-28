from flask import jsonify
import mysql.connector

def pegarQuestionarios(id=0):
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
                            a.Descricao,
                            a.Alternativa_Correta
                    from questionarios q
                    join perguntas p on p.id_Questionario = q.id_Questionario
                    join alternativas a on a.id_Pergunta = p.id_Pergunta; """

        if id > 0:
            query += "where q.id_Questionario = " + id

        cursor.execute(query)

        #for (nome) in cursor:
            #print(nome)

        #rv = cnx.fetchall()
        payload = []
        content = {}
        for result in cursor:
            content = { 'id_Questionario': result[0], 
                        'id_Pergunta': result[1],
                        'id_Alternativa': result[2],
                        'Pergunta': result[3],
                        'Descricao': result[4],
                        'Alternativa_Correta': result[5]}

            payload.append(content)

        r = jsonify(payload)

    except Exception as e:
        cnx.rollback()
        print('Erro na conexão com o BD: ' + str(e))

    cursor.close()
    cnx.close()
    return r