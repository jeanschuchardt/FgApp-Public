# import pandas as pd
# import psycopg2
# from sqlalchemy import create_engine
# import manipula
# import os
# def read_process(path):
#   #encoding and read
#     fileName = os.path.basename(path)
#     year = fileName[:4]
#     mounth = fileName[4:6]
#     #print(year)
#     #print(mounth)
#     try:    
#         chunksize = 10000
#         for df in pd.read_csv(path,encoding ="ansi", sep=',\s+', delimiter=';',low_memory=False, skipinitialspace=True,memory_map=True , chunksize=chunksize):
#             #process(chunk)
#             #f=pd.read_csv(path,encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True,memory_map=True )
#             keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO','NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO','DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','DATA_NOMEACAO_CARGOFUNCAO','DATA_INGRESSO_ORGAO']
#             df = df[keep_col]
#             df.columns = df.columns = df.columns.str.replace(' ', '_')
#             df = df[df.SIGLA_FUNCAO != '-1']
            
#             df.insert_sevidores(len(df.columns),"ANO",year)
#             df.insert_sevidores(len(df.columns),"MES",mounth)

#            # print(df)
#            insert_sevidores(df)
       
#     except Exception as e:
#         print('>>>>')
#         print('error:', e)
#         print('error:', path)
        
    
# def insert_sevidores(result):
#     #result.to_csv("0.csv", index=False)
#     print('insert')
#     #eng = create_engine('postgresql://aladdin:Cp1149rm3t7@genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com:5432/abu')
#     eng = create_engine('postgresql://postgres:162606@localhost:5432/abu')
#     try:
#        result.to_sql('servidores_2STG', eng, if_exists='append', index=False)
#     except Exception as e:
#        print('error2:', e)
#     print('arquivo inserido')

# def read_process2(path):
#   #encoding and read
#     fileName = os.path.basename(path)

#     #print(year)
#     #print(mounth)
#     try:    
#         chunksize = 10000
#         for df in pd.read_csv(path,encoding ="ansi", sep=',\s+', delimiter=';',low_memory=False, skipinitialspace=True,memory_map=True , chunksize=chunksize):
#             #process(chunk)
#             #f=pd.read_csv(path,encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True,memory_map=True )
#             keep_col = ['ANO',	'MES',	'Id_SERVIDOR_PORTAL',	'CPF',	'NOME',	'REMUNERAÇÃO BÁSICA BRUTA (R$)',	'FÉRIAS (R$)'	,'OUTRAS REMUNERAÇÕES EVENTUAIS (R$)',	'IRRF (R$)'
#             ,	'PSS/RPGS (R$)',	'DEMAIS DEDUÇÕES (R$)',	'REMUNERAÇÃO APÓS DEDUÇÕES OBRIGATÓRIAS (R$)',	'TOTAL DE VERBAS INDENIZATÓRIAS (R$)(*)']
#             df = df[keep_col]
#             df.columns =  df.columns.str.replace("\(R\$\)", '')
#             df.columns =  df.columns.str.replace("\(\*\)", '')
#             df.columns  = df.columns.str.replace(' ', '_')
                     
#            # print(df.columns)

#            # print(df)
#             insert_remuneracao(df)
       
#     except Exception as e:
#         print('>>>>')
#         print('error:', e)
#         print('error:', path)
        
    
# def insert_remuneracao(result):
#     #result.to_csv("0.csv", index=False)
#     print('insert')
#     #eng = create_engine('postgresql://aladdin:Cp1149rm3t7@genie.clbigxrmgqzl.sa-east-1.rds.amazonaws.com:5432/abu')
#     eng = create_engine('postgresql://postgres:162606@localhost:5432/abu')
#     try:
#        result.to_sql('remuneraca_STG', eng, if_exists='append', index=False)
#     except Exception as e:
#        print('error2:', e)
#     print('arquivo inserido')



