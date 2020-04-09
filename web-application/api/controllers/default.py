import api.DAO.questionarioDAO
import api


#Verificar status da API
@api.app.route('/', methods=['GET'])
def statusAPI():
    return '<html><h1>API Questionarios: Status OK</h1></html>'


#Autentica o usuário
@api.app.route('/api/auth', methods=['POST'])
def autenticar():
    return """{
                token:'fdg6d6f2g6adg565df4g56d4g6dfg54d45fgfg4d'
              }"""


#Traz o questionário do ID informado.
@api.app.route('/api/questionarios/<idQuestionario>', methods=['GET'])
def questionario(idQuestionario):
    args = api.request.args
    print(args)
    return api.DAO.questionarioDAO.pegarQuestionarios(idQuestionario)


#Traz o aluno do ID informado.
@api.app.route('/api/alunos/<id_aluno>', methods=['GET'])
def questionariosAluno(id_aluno):
    return """{
                nome:'Aluno 1'
              }"""


#Traz os questionários do aluno informado
@api.app.route('/api/alunos/<id_aluno>/questionarios', methods=['GET'])
def questionarioAluno(id_aluno):
    return api.DAO.questionarioDAO.pegarQuestionarios(id_aluno)


#Lista as tentativas do aluno podendo filtrar por questionarios
@api.app.route('/api/alunos/<id_aluno>/tentativas/questionario/<id_questionario>', methods=['GET'])
def tentativasAluno(id_questionario):
    return """{
                idTentativa:'102'
              }"""


#Traz uma tentativa específica
@api.app.route('/api/tentativas/<id_tentativa>', methods=['GET'])
def tentativaAluno(id_tentativa):
    return """{
                idTentativa:'102'
              }"""


#Cria uma nova tentativa
@api.app.route('/api/tentativas/', methods=['POST'])
def criarTentativa():
    return """{
                idTentativa:'102'
              }"""


#Grava uma resposta para uma tentativa
@api.app.route('/api/tentativas/<id_tentativa>/respostas', methods=['POST'])
def gravarTentativa():
    return """{
                idResposta:'102'
              }"""


#Recebe um json com as alternativas para indicar um material
@api.app.route('/api/questionarios', methods=['POST'])
def verificarMaterial():
    json = api.request.json
    resp = api.DAO.questionarioDAO.indicarMaterial(json)
    return api.Response(resp, mimetype='text/json')