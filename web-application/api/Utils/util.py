from validate_email import validate_email
import re


def validarEmail(email):
    is_valid = validate_email(email=email)
    return is_valid


def validarNomeUsuario(nomeUsuario):
    regex = re.compile(r'^[a-z]{1}[a-z0-9]{2,14}$')
    valida = regex.match(nomeUsuario)
    return valida != None
