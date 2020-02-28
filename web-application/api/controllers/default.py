import api
import DAO.questionarioDAO


@api.app.route('/api/auth', methods=['POST'])
def adicionarQuestionario():
    return """{
                token:'fdg6d6f2g6adg565df4g56d4g6dfg54d45fgfg4d'
              }"""

@api.app.route('/api/questionarios/<id_questionario>', methods=['GET'])
def questionario(id_questionario):
    return DAO.questionarioDAO.pegarQuestionarios(id_questionario)

@api.app.route('/api/alunos/<id_aluno>', methods=['GET'])
def questionarios(id_aluno):
    return """{
                nome:'Aluno 1'
              }"""

@api.app.route('/api/alunos/<id_aluno>/questionarios', methods=['GET'])
def questionarios(id_aluno):
    return DAO.questionarioDAO.pegarQuestionarios(id_aluno)


@api.app.route('/api/alunos/<id_aluno>/tentativas/', methods=['GET'])
def adicionarQuestionario():
    return """{
                idTentativa:'102'
              }"""

@api.app.route('/api/tentativas/', methods=['POST'])
def adicionarQuestionario():
    return """{
                idTentativa:'102'
              }"""

@api.app.route('/api/tentativas/<id_tentativa>/respostas', methods=['POST'])
def adicionarQuestionario():
    return """{
                idResposta:'102'
              }"""              