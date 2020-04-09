__all__ = ['controllers', 'DAO', 'models']
from flask import Flask, jsonify, request, Response

app = Flask(__name__)

# Importa depois de instanciar o app
from api.controllers import default