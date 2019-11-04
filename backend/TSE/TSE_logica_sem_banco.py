import pandas as pd
import datetime
from sqlalchemy import create_engine
import numpy as np
from sqlalchemy.sql import select
from sqlalchemy.sql import text
import os


def list_files(path):
    files_r = []
    print(path)
    for (dirpath, dirs, files) in os.walk(path):
        for file in files:
            files_r.append(dirpath+'/'+file)
    return files_r


def read_file(path):
    try:
        f = pd.read_csv(path, encoding="ansi", delimiter=';',
                        low_memory=False, skipinitialspace=True)
    except:
        print("erro de leitura")

    keep_col = ['NOME DO FILIADO', 'NUMERO DA INSCRICAO', 'SIGLA DO PARTIDO', 'UF', 'NOME DO MUNICIPIO',
                'ZONA ELEITORAL', 'SECAO ELEITORAL', 'DATA DA FILIACAO', 'SITUACAO DO REGISTRO', 'DATA DA DESFILIACAO']
    y = f[keep_col]

    y.columns = y.columns.str.replace('\D(R\$\D)', '')
    y.columns = y.columns.str.replace('\D(\*\D)', '')
    y.columns = y.columns.str.replace('\/^\s+|\s+$', '')
    y.columns = y.columns.str.replace(' ', '_')
    y['nome'] = y['NOME_DO_FILIADO']
    x = y['nome'].str.split(" ", n = 1, expand = True) 
    y['nome'] = x[0]
    return y


def situacao_registro(data_frame):
    return data_frame.groupby('SITUACAO_DO_REGISTRO')


def sr_cancelado(sr_gb):
    CANCELADO = 'CANCELADO'
    df_cancelado = sr_gb.get_group(CANCELADO)
    return df_cancelado


def sr_regular(sr_gb):
    REGULAR = 'REGULAR'
    df_regular = sr_gb.get_group(REGULAR)
    return df_regular


def cancelado_grouby(df):
    not_null = df[df['DATA_DA_DESFILIACAO'].notnull()]
    is_null = df[df['DATA_DA_DESFILIACAO'].isnull()]
    return not_null, is_null


def insert(data, table):
    try:
        # ler isso do config e remover do codigo
        eng = create_engine(
            'mysql+pymysql://admin:example@localhost:3308/datastage')
        data.to_sql(table, eng, if_exists='append', index=False)
        print('arquivo inserido')
    except Exception as e:

        print("insert")
        print(e)


def percorre(r):

    for paths in r:
        if 'filiados' in paths:

            y = read_file(paths)

            try:
                sr_gb = situacao_registro(y)
            except Exception as identifier:
                print(identifier)

            try:
                df_cancelado = sr_cancelado(sr_gb)
            except Exception as identifier:
                print(identifier)

            try:
                df_regular = sr_regular(sr_gb)
            except Exception as identifier:
                print(identifier)

            # quando o cancelado for null salvar esse registro em um outra tabela para  tentar processar os dados mais tardes #
            cancelado_not_null, cancelado_is_null = cancelado_grouby(df_cancelado)

            ##################
            print(paths)
            # cancelado_not_null
            df_regular['DATA_DA_FILIACAO'] = pd.to_datetime(
                df_regular['DATA_DA_FILIACAO'], format='%d/%m/%Y', errors='coerce')
            df_regular['DATA_DA_DESFILIACAO'] = pd.to_datetime(
                df_regular['DATA_DA_DESFILIACAO'], format='%d/%m/%Y', errors='coerce')

            # cancelado_not_null

            cancelado_not_null['DATA_DA_FILIACAO'] = pd.to_datetime(
                cancelado_not_null['DATA_DA_FILIACAO'], format='%d/%m/%Y', errors='coerce')
            cancelado_not_null['DATA_DA_DESFILIACAO'] = pd.to_datetime(
                cancelado_not_null['DATA_DA_DESFILIACAO'], format='%d/%m/%Y', errors='coerce')

            # cancelado_not_null

            insert(df_regular, 'tb_af568')
            insert(cancelado_not_null, 'tb_af568')
            insert(cancelado_is_null, 'stg_af_data_missing3')



dir_path = 'D:\\Github\\FGApp\\backend\\TSE\\readtoinsert'

percorre(list_files(dir_path))

