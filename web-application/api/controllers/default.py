import api.DAO.questionarioDAO
from jsonschema import validate
from datetime import timedelta
from flask_jwt_extended import (
    JWTManager, jwt_required,
    create_access_token, get_raw_jwt
)
import api


api.app.config['JWT_SECRET_KEY'] = 'ApiQuestionarios-SecretKey'
api.app.config['JWT_BLACKLIST_ENABLED'] = True
api.app.config['JWT_ACCESS_TOKEN_EXPIRES'] = timedelta(hours = 12)
jwt = JWTManager(api.app)

schema = {  "type" : "object",
            "properties" : {
            "usuario" : {"type" : "string", "minLength": 3, "maxLength": 100},
            "senha" : {"type" : "string", "minLength": 6, "maxLength": 100},
            },
        }

#Guardar tokens revogados
blacklist = set()


@jwt.token_in_blacklist_loader
def verificar_blacklist(token):
    #Verifica se o id do token stá na lista
    return token['jti'] in blacklist


@jwt.revoked_token_loader
def token_invalidado():
    return api.jsonify({"msg": "Token inválido"}), 401


@jwt.expired_token_loader
def token_expirou(token):
    return api.jsonify({'msg': f'O token expirou'}), 401


@jwt.invalid_token_loader
def token_invalido(token):
    return api.jsonify({'msg': f'O token é inválido'}), 401


@jwt.unauthorized_loader
def sem_token_autorizacao(token):
    return api.jsonify({'msg': f'Não há token no header (bearer)'}), 401


#Verificar status da API
@api.app.route('/', methods=['GET'])
def statusAPI():
    return '<html><h1>API Questionarios: Status OK</h1></html>', 200


@api.app.route('/api/logout', methods=['POST'])
@jwt_required
def logout():
    jti = get_raw_jwt()['jti']
    blacklist.add(jti)
    return api.jsonify({"msg": "Logout realizado com sucesso"}), 200


#Autentica o usuário
@api.app.route('/api/auth', methods=['POST'])
def autenticar():
    json = api.request.json

    #if len(json) != 2:
    #    return api.jsonify({"msg": "Número de parametros diferente de 2", "erro":"Objeto json inválido"}), 409

    try:
        validate(instance = json, schema=schema)
    except Exception as e:
        return api.jsonify({"msg": str(e), "erro": "Objeto json inválido"}), 409

    try:
        aluno = api.DAO.questionarioDAO.autenticar(json)
    except Exception as e:
        return api.jsonify({"status": 0, "msg": str(e)}), 501

    if aluno:
        access_token = create_access_token(identity=aluno['id_Aluno'])
        aluno["AccessToken"] = access_token
        return api.jsonify(aluno), 200

    return api.jsonify({"msg": "Usuário ou/e senha incorreto(s)", "erro": "Usuário inválido"}), 401


#Traz o questionário do ID informado.
@api.app.route('/api/questionarios/<int:idQuestionario>', methods=['GET'])
@jwt_required
def questionario(idQuestionario):
    args = api.request.args
    print(args)
    return api.DAO.questionarioDAO.pegarQuestionarios(idQuestionario)


#Traz o aluno do ID informado.
@api.app.route('/api/alunos/<int:id_aluno>', methods=['GET'])
@jwt_required
def questionariosAluno(id_aluno):
    return """{
                nome:'Aluno 1'
              }"""


#Traz os questionários do aluno informado
@api.app.route('/api/alunos/<int:id_aluno>/questionarios', methods=['GET'])
@jwt_required
def questionarioAluno(id_aluno):
    resp = api.DAO.questionarioDAO.pegarQuestionariosAluno(id_aluno)
    return resp


#Lista as tentativas do aluno podendo filtrar por questionarios
@api.app.route('/api/alunos/<int:id_aluno>/tentativas/questionario/<int:id_questionario>', methods=['GET'])
@jwt_required
def tentativasAluno(id_questionario):
    return """{
                idTentativa:'102'
              }"""


#Traz uma tentativa específica
@api.app.route('/api/tentativas/<int:id_tentativa>', methods=['GET'])
@jwt_required
def tentativaAluno(id_tentativa):
    return """{
                idTentativa:'102'
              }"""


#Cria uma nova tentativa
@api.app.route('/api/tentativas', methods=['POST'])
@jwt_required
def criarTentativa():
    try:
        json = api.request.json

        #validarJsonQuestionarioRespondido(json)

        resp = api.DAO.questionarioDAO.salvarQuestionarioRespondido(json)
        return api.Response(resp, mimetype='text/json'), 200

    except Exception as e:
        resp = f'{{"status": 0, "msg": "Erro ao salvar questionário: {str(e)}"}}'
        return api.Response(resp, mimetype='text/json'), 500


#Grava uma resposta para uma tentativa
@api.app.route('/api/tentativas/<int:id_tentativa>/respostas', methods=['POST'])
@jwt_required
def gravarTentativa():
    return """{
                idResposta:'102'
              }"""


#Recebe um json com as alternativas para indicar um material
@api.app.route('/api/questionarios', methods=['POST'])
def verificarMaterial():
    json = api.request.json
    resp = api.DAO.questionarioDAO.indicarMaterial(json)
    return api.Response(resp, mimetype='text/json'), 200


#Salva o log no sistema.
@api.app.route('/api/log', methods=['POST'])
@jwt_required
def salvarLog():
    try:
        json = api.request.json
        resp = api.DAO.questionarioDAO.salvarLog(json)
        return api.Response(resp, mimetype='text/json'), 200
    except Exception as e:
        resp = f'{{"status":0, "msg": "Erro ao salvar log: {str(e)}"}}'
        return api.Response(resp, mimetype='text/json'), 500

schemaUsuario = {  "type" : "object",
                   "properties" : {
                      "Nome" : {"type" : "string", "minLength": 5, "maxLength": 100},
                      "Email" : {"type" : "string", "minLength": 10, "maxLength": 150},
                      "Usuario" : {"type" : "string", "minLength": 3, "maxLength": 150},
                      "Senha" : {"type" : "string", "minLength": 6, "maxLength": 50}
                   },
                }

def validarJsonUsuario(json):
    if len(json) != 4:
        raise Exception("Número de parametros diferente de 4, objeto json inválido")

    try:
        validate(instance = json, schema=schemaUsuario)
    except Exception as e:
        raise Exception("JSON Inválido, verifique as propriedades")


#Inserir novo aluno no sistema
@api.app.route('/api/usuario/aluno', methods=['POST'])
def cadastrarNovoAluno():
    try:
        json = api.request.json

        validarJsonUsuario(json)

        resp = api.DAO.questionarioDAO.inserirAluno(json)
        return api.Response(resp, mimetype='text/json'), 200
    except Exception as e:
        resp = f'{{"status": 0, "msg": "Erro ao cadastrar: {str(e)}"}}'
        return api.Response(resp, mimetype='text/json'), 500

