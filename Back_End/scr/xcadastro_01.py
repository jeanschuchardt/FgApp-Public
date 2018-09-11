#!/usr/bin/env python
import sys
import pandas as pd
import psycopg2
import sys
from sqlalchemy import create_engine


def extrect_partidos(path):
    f=pd.read_csv(path, sep=',\s+', encoding ="ansi", delimiter='\t',low_memory=False, skipinitialspace=True)

    #the name of colluns 
    keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO','NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO','DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','DATA_NOMEACAO_CARGOFUNCAO','DATA_INGRESSO_ORGAO']
    df = f[keep_col]

    df = df.dropna(subset=['SIGLA_FUNCAO'])

    data_result(df)



def data_result(result):

#   eng =  create_engine('postgresql://aladdin:Cp1149rm3t7@genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com:5432/abu')
    eng = create_engine('postgresql://postgres:162606@localhost:5432/abu')

    result.to_sql('servidores_func', eng, if_exists='replace', index=False,)


def main():
    path = "D:\\Project\\FGApp\\temp\\20130131_Cadastro.csv"
    #db_connect()
    extrect_partidos(path)
    


if __name__ == "__main__":
	main()
