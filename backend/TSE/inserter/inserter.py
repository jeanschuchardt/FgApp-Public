import pandas as pd
from sqlalchemy import create_engine
import yaml
import shutil
import glob
import os

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
        files= glob.glob(folderPath +'//*rs.csv')
        for file in files:
            ReadFile(file,configs)

def ReadFile(path, configs):
    try:
        print(path)
        dataRaw = pd.read_csv(path, encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)
        move(path,configs)
        RemoveColuns(dataRaw)
    except Exception  as e:
        print (e)

def creatFolders(folderName):
    path = os.getcwd() + '/' + folderName
    if not os.path.exists(path):
         os.mkdir(path)
    return path

def move(scr,config):
    dst = creatFolders('../TSEFilesInserted')

    try:
        base=os.path.basename(scr)
        shutil.move(scr, dst+'/'+base)
    except Exception as e:
        print('>>>>>>\n MoveError: \n', e)

def RemoveColuns(dataRaw):
    try:
        keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
        df = dataRaw[keep_col]
        #df = df.drop_duplicates(['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO'])
        df = df.drop_duplicates()
        df.columns = df.columns.str.replace(' ','_')
        insert(df)
    except Exception  as e:
        print("RemoveColuns")
        print (e)

def insert(data):
    try:
       
        eng = create_engine('mysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
     
        data.to_sql('stg_afiliados', eng, if_exists='append', index=False)
        print('arquivo inserido')
    except Exception  as e:
      
        print("insert")
        print (e)
    

SelectFiles()