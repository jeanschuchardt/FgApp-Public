import shutil
import urllib3
import configparser
import zipfile  
import glob
import os
import pandas as pd
import psycopg2
import sys
from sqlalchemy import create_engine

def manin():
    config = configparser.ConfigParser()
    config.read("Config.ini")
    url = config['URL']['tse']

    pathEstados = config['ESTADOS']['path']
    days_file = open(pathEstados,'r')
    estados = days_file.readlines()

    pathPartidos = config['PARTIDOS']['path']
    days_file = open(pathPartidos,'r')
    partidos = days_file.readlines()

    for partido in partidos:
        for estado in estados:
            p = partido.rstrip('\n')
            e = estado.rstrip('\n')
            urlFinal = url+p+'_'+e+'.zip'
            print(urlFinal)
            downloader(urlFinal,p,e)
            unziper()
            extrect_partidos()
def downloader(url,p,e):
    #http = urllib3.PoolManager()
    # url = rl2
    c = urllib3.PoolManager()
  
    creatFolders()

    filename ='donwloads/'+p+'_'+e+'.zip'

    with c.request('GET',url, preload_content=False) as resp, open(filename, 'wb') as out_file:
        shutil.copyfileobj(resp, out_file)

    resp.release_conn() 
def creatFolders():
      
    path = os.getcwd() + '/donwloads'
    if not os.path.exists(path):
         os.mkdir(path)

    '''file_path = "/donwloads"
    directory = os.path.dirname(file_path)
    homedir =  os.environ['username']

    desktop = os.path.join(os.path.join(os.environ['USERPROFILE']), 'Desktop') 
    print(homedir)

    try:
        os.stat(path+'/donwloads')
    except:
        os.mkdir(path+'/donwloads')       

    #f = file(filename) 
    '''
def unziper():
    path = os.getcwd() + '/donwloads'
    #print(origemPath)
    files = path+'/*.zip'
    fileToUnzip = glob.glob(files)
    #print(fileToUnzip)

    path = os.getcwd() + '/unzip'
    if not os.path.exists(path):
         os.mkdir(path)

    for fileX in fileToUnzip:
        try: 
            zip_ref = zipfile.ZipFile(fileX,'r')
            zip_ref.extractall(path)
            zip_ref.close()
       
            os.remove(fileX)
        except:
            print('not deleted '+ fileX)
def extrect_partidos():
    path = os.getcwd() + "//unzip//aplic//sead//lista_filiados//uf"
    listFiles = glob.glob(path+'/*csv')
    for file in listFiles:
        readProcess(file)
        print(file)
        move(file)
def readProcess(path):
    #encoding and read
    try:
        f=pd.read_csv(path, sep=',\s+', encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)

        #the name of colluns 
        keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','CODIGO DO MUNICIPIO','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
        #keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO','NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO','DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','DATA_NOMEACAO_CARGOFUNCAO','DATA_INGRESSO_ORGAO','UF_EXERCICIO']
        df = f[keep_col]
        #df = df.dropna(subset=['SIGLA_FUNCAO'])

        insert(df)
    except:
        print('error:')
def insert(result):
    #result.to_csv("0.csv", index=False)

    #eng = create_engine('postgresql://aladdin:Cp1149rm3t7@genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com:5432/abu')
    eng = create_engine('postgresql://postgres:162606@localhost:5432/abu')
      
    result.to_sql('afiliados_STG', eng, if_exists='append', index=False)
def move(path):
    newpath = os.getcwd() + '/inserted'
    if not os.path.exists(newpath):
        os.mkdir(newpath)

    base=os.path.basename(path)
    print(path)
    print(newpath+'/'+base)
    shutil.move(path, newpath+'/'+base)

manin()

