#!/usr/bin/env python
import sys
import pandas as pd
import psycopg2
import sys
from sqlalchemy import create_engine


def extrect_partidos(path):

    f=pd.read_csv(path, sep=',\s+', encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)
    keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','CODIGO DO MUNICIPIO','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
    df = f[keep_col]
    data_result(df)

def data_result(result):
    #eng = create_engine('postgresql://aladdin:Cp1149rm3t7@genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com:5432/abu')
    eng = create_engine('postgresql://postgres:162606@localhost:5432/abu')
    result.to_sql('afiliados', eng, if_exists='append', index=False)

def main():
    path = "D:\\Project\FGApp\\temp\\filiados_avante_ac.csv"
    #db_connect()
    extrect_partidos(path)

if __name__ == "__main__":
	main()