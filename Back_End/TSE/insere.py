import pandas as pd
import psycopg2
from sqlalchemy import create_engine
import manipula
def readProcess(path):
    #encoding and read
    try:
        f=pd.read_csv(path, encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)

        #the name of colluns 
        keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','CODIGO DO MUNICIPIO','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
        df = f[keep_col]
       
        df.columns = df.columns = df.columns.str.replace(' ', '_')
        df = df[df.SITUACAO_DO_REGISTRO == 'REGULAR']
        manipula.moveFile(path, 'inseridos')
        insert(df)
       
    except Exception as e:
        print('>>>>')
        print('error:', e)
        print('error:', path)
        
    
def insert(result):
    #eng = create_engine('postgresql://aladdin:Cp1149rm3t7@genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com:5432/abu')
    eng = create_engine('postgresql://postgres:162606@localhost:5432/abu')
      
    result.to_sql('afiliados_2STG', eng, if_exists='append', index=False)
    print('arquivo inserido')