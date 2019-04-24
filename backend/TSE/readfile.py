import pandas as pd
from sqlalchemy import create_engine
import yaml
import glob

#class ReadFiles():
configs = ''
    
def ReadConfig():
    #ler do arquivo de configuração
    with open("config.yml", 'r') as ymlfile:
        cfg = yaml.load(ymlfile, Loader=yaml.FullLoader)

    #print(x)
    return cfg

def SelectFiles():
    configs = ReadConfig()
    folderPath = configs['files_root']['tse_path']
    while True:
        files= glob.glob(folderPath +'//*.csv')
        for file in files:
            ReadFile(file)

def ReadFile(path):
    try:
        print(path)
        dataRaw = pd.read_csv(path, encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)
        RemoveColuns(dataRaw)
    except Exception  as e:
        print (e)

def RemoveColuns(dataRaw):
    try:
        keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
        f = dataRaw[keep_col]
        insert(f)
    except Exception  as e:
        print("RemoveColuns")
        print (e)

def insert(data):
    try:
       # conn = configs['database']['str_conn']
        #print(conn)
        eng = create_engine('mysql://admin:example@localhost:3308/datastage')
        
        data.to_sql('stg_afiliados', eng, if_exists='append', index=False)

        print('arquivo inserido')
    except Exception  as e:
      
        print("insert")
        print (e)
    

SelectFiles()