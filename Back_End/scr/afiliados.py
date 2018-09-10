#!/usr/bin/env python
import sys
import pandas as pd
import psycopg2
import sys
from sqlalchemy import create_engine


def extrect_partidos(path):

    #encoding and read
    f=pd.read_csv(path, sep=',\s+', encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)

    #the name of colluns 
    keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','CODIGO DO MUNICIPIO','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
    #keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO','NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO','DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','DATA_NOMEACAO_CARGOFUNCAO','DATA_INGRESSO_ORGAO','UF_EXERCICIO']
    df = f[keep_col]
    #df = df.dropna(subset=['SIGLA_FUNCAO'])

    data_result(df)

    #df.to_csv("0.csv", index=False)

def data_result(result):
    #result.to_csv("0.csv", index=False)

    #eng = create_engine('postgresql://aladdin:Cp1149rm3t7@genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com:5432/abu')
    eng = create_engine('postgresql://postgres:162606@localhost:5432/abu')
    #print(eng)
    
    #conn_string = "host='genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com' dbname='abu' user='aladdin' password='Cp1149rm3t7'"

    # # print the connection string we will use to connect
    #print ("Connecting to database\n	->%s" % (conn_string))

    # # get a connection, if a connect cannot be made an exception will be raised here
    #conn = psycopg2.connect(conn_string)

    # # conn.cursor will return a cursor object, you can use this cursor to perform queries
   # cursor = conn.cursor()
    #result = pd.drop_duplicates(result, keep=False)
    
    result.to_sql('afiliados_stg', eng, if_exists='append', index=False)

# def db_connect():

    

# #   engine = create_engine('postgresql://'+ user + ':' + password + '@' + host + '/' +dbname)
#     #engine = create_engine('postgresql://aladdin:Cp1149rm3t7@18.228.120.133:5432/abu')

#    # engine = create_engine('postgresql://genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com[aladdin]:[Cp1149rm3t7]:]+'/'+os.environ[abu],echo=False)


#     conn_string = "host='genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com' dbname='abu' user='aladdin' password='Cp1149rm3t7'"

#     # # print the connection string we will use to connect
#     #print ("Connecting to database\n	->%s" % (conn_string))

#     # # get a connection, if a connect cannot be made an exception will be raised here
#     conn = psycopg2.connect(conn_string)

#     # # conn.cursor will return a cursor object, you can use this cursor to perform queries
#     cursor = conn.cursor()
    
    
#     print ("Connected!\n")

    

def main():
    path = "D:\\Project\FGApp\\temp\\filiados_avante_ac.csv"
    #db_connect()
    extrect_partidos(path)
    
   



if __name__ == "__main__":
	main()