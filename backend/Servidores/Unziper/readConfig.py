import configparser

def readConfig(): 
    config = configparser.ConfigParser()
    config.read("Config.ini")
    url = config['URL']['tse']

    pathEstados = config['anos']['path']
    days_file = open(pathEstados,'r')
    estados = days_file.readlines()
    estados =  [w.replace('\n','') for w in estados]

    pathPartidos = config['meses']['path']
    days_file = open(pathPartidos,'r')
    partidos = days_file.readlines()
    partidos =  [w.replace('\n','') for w in partidos]

    return(url, estados, partidos)


       
