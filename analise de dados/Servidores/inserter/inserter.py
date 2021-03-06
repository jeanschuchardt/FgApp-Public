import pandas as pd
from sqlalchemy import create_engine
import yaml
import shutil
import glob
import os
import csv

#class read_files():
configs = ''
    
def read_config():
    #ler do arquivo de configuração
    with open("config.yml", 'r') as ymlfile:
        cfg = yaml.load(ymlfile, Loader=yaml.FullLoader)

    #print(x)
    return cfg

def select_files():
    print("Start")
    configs = read_config()
    folderPath = configs['files_root']['serv_path']
    anos = ['2019','2018','2017','2016','2015','2014']
   # anos = ['2016','2015','2014']
    #anos = ['2013']

    for ano in anos:
            
        while True:
            files= glob.glob(folderPath +'//'+ano+'*Cadastro.csv')
            for file in files:
                #print(file)
                read_file(file,configs)
            break
        
def read_file(path, configs):
    try:
        print(path)
        chunksize = 10000
        fileName = os.path.basename(path)
        year = fileName[:4]
        print(year)
        mounth = fileName[4:6]
        for df in pd.read_csv(path,encoding ="ansi", sep=',\s+', delimiter=';',skipinitialspace=True,memory_map=True , chunksize=chunksize,error_bad_lines=False  ):
            #dataRaw = pd.read_csv(path, encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)
            try:
                remove_coluns(df,year,mounth)
            except Exception  as e:
                print (e)
        move(path,configs)
    except Exception  as e:
        print (e)

def create_folders(folderName):
    path = os.getcwd() + '/' + folderName
    if not os.path.exists(path):
         os.mkdir(path)
    return path

def move(scr,config):
    dst = create_folders('../ServidoresFilesInserted')

    try:
        base=os.path.basename(scr)
        shutil.move(scr, dst+'/'+base)
    except Exception as e:
        print('>>>>>>\n MoveError: \n', e)

def remove_coluns(df,year,mounth):
    # try:
    #     keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
    #     df = dataRaw[keep_col]
    #     #df = df.drop_duplicates(['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO'])
    #     df = df.drop_duplicates()
    #     df.columns = df.columns.str.replace(' ','_')
    #     insert(df)
    # except Exception  as e:
    #     print("remove_coluns")
    #     print (e)
    try:    
        #chunksize = 10000
        #for df in pd.read_csv(path,encoding ="ansi", sep=',\s+', delimiter=';',low_memory=False, skipinitialspace=True,memory_map=True , chunksize=chunksize):
        #process(chunk)
        #f=pd.read_csv(path,encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True,memory_map=True )
        keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO','NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO','DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','UF_EXERCICIO']
        df = df[keep_col]
        df.columns = df.columns.str.replace(' ','_')
        #df.columns = df.columns = df.columns.str.replace(' ', '_')
        df = df[df.SIGLA_FUNCAO != '-1']
                
        df.insert(len(df.columns),"MES",mounth)
        df.insert(len(df.columns),"ANO",year)
        print(df)
        # print(df)
        insert(df)
        #insert(f)
    except Exception as e:
        print('>>>>')
        print('error:', e)
     #   print('error:', path)
        print('>>>>')
        

def insert(result):
    try:
       #TODO
       # ler isso do config e remover do codigo
       # 
       # ##
        eng = create_engine('mysql://admin:example@localhost:3308/datastage') 
     
        result.to_sql('stg_servidores', eng, if_exists='append', index=False)
        print('arquivo inserido')
    except Exception  as e:
      
        print("insert")
        print (e)



select_files()