import pandas as pd
from sqlalchemy import create_engine
import yaml
import shutil
import glob
import os
import csv

#class ReadFiles():
configs = ''
    
def ReadConfig():
    #ler do arquivo de configuração
    with open("config.yml", 'r') as ymlfile:
        cfg = yaml.load(ymlfile, Loader=yaml.FullLoader)

    #print(x)
    return cfg

def SelectFiles():
    print("Start")
    configs = ReadConfig()
    folderPath = configs['files_root']['serv_path']
    while True:
        files= glob.glob(folderPath +'//2019*Cadastro.csv')
        for file in files:
            #print(file)
            ReadFile(file,configs)
        break
        
def ReadFile(path, configs):
    try:
        print(path)
        chunksize = 10000
        fileName = os.path.basename(path)
        year = fileName[:4]
        mounth = fileName[4:6]
        for df in pd.read_csv(path,encoding ="ansi", sep=',\s+', delimiter=';',skipinitialspace=True,memory_map=True , chunksize=chunksize,error_bad_lines=False  ):
            #dataRaw = pd.read_csv(path, encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)
            try:
                RemoveColuns(df,year,mounth)
            except Exception  as e:
                print (e)
        move(path,configs)
    except Exception  as e:
        print (e)

def creatFolders(folderName):
    path = os.getcwd() + '/' + folderName
    if not os.path.exists(path):
         os.mkdir(path)
    return path

def move(scr,config):
    dst = creatFolders('../ServidoresFilesInserted')

    try:
        base=os.path.basename(scr)
        shutil.move(scr, dst+'/'+base)
    except Exception as e:
        print('>>>>>>\n MoveError: \n', e)

def RemoveColuns(df,year,mounth):
    # try:
    #     keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
    #     df = dataRaw[keep_col]
    #     #df = df.drop_duplicates(['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO'])
    #     df = df.drop_duplicates()
    #     df.columns = df.columns.str.replace(' ','_')
    #     insert(df)
    # except Exception  as e:
    #     print("RemoveColuns")
    #     print (e)
    try:    
        #chunksize = 10000
        #for df in pd.read_csv(path,encoding ="ansi", sep=',\s+', delimiter=';',low_memory=False, skipinitialspace=True,memory_map=True , chunksize=chunksize):
        #process(chunk)
        #f=pd.read_csv(path,encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True,memory_map=True )
        keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO','NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO','DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','DATA_NOMEACAO_CARGOFUNCAO','DATA_INGRESSO_ORGAO']
        df = df[keep_col]
        df.columns = df.columns.str.replace(' ','_')
        #df.columns = df.columns = df.columns.str.replace(' ', '_')
        df = df[df.SIGLA_FUNCAO != '-1']
        
        df.insert(len(df.columns),"ANO",year)
        df.insert(len(df.columns),"MES",mounth)

        # print(df)
        insert(df)
        #insert(f)
    except Exception as e:
        print('>>>>')
        print('error:', e)
        print('error:', path)
        print('>>>>')
        

def insert(result):
    try:
       
        eng = create_engine('mysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
     
        result.to_sql('stg_servidores', eng, if_exists='append', index=False)
        print('arquivo inserido')
    except Exception  as e:
      
        print("insert")
        print (e)



SelectFiles()