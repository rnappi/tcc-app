import api

if __name__ == "__main__":
    #Deixar API aberta na rede local
    #api.app.run(host = '0.0.0.0', port=8080, debug=False)

    #Para Debug, apenas localhost
    api.app.run(host="localhost", port=8080, debug=True)