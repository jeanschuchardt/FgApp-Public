import pandas as pd
from sqlalchemy import create_engine
from unidecode import unidecode
from datetime import datetime


def insert_cadastro(cadastro,remuneracao):
    chunk = 10000
    #le o arquivo csv remuneração
    remuneracao_result_set = read_csv(remuneracao)
    
    #remove caracteres especiais da lingua portuguesa 
    remuneracao_result_set.columns = remove_pt_caracteres(remuneracao_result_set)
    
    #remove dolar 
    remuneracao_result_set = remove_coll_dolar(remuneracao_result_set)
    
    #remove espaços em branco
    remove_spaces(remuneracao_result_set)

    #remove colunas não necessarias 
    remuneracao_result_set = remove_columns_remuneracao(remuneracao_result_set)
    
    #cria nova coluna para armazenar o gato total do servidor
    create_total_column(remuneracao_result_set)

    # remover no futuro -> existe para test
    # 
    # keep_col = ['ANO','MES','Id_SERVIDOR_PORTAL','CPF','NOME','total_remuneracao'] #remover valores intermediarios a soma 
    # y = y[keep_col]
    #
    # 
    # ##

    for i, result_set in enumerate((pd.read_csv(cadastro, encoding ="ISO-8859-1", delimiter=';', skipinitialspace=True,error_bad_lines = False, engine='c',chunksize=chunk))):
        
        result_set = remove_columns_cadastro(result_set)

        
        result_set = remove_last_line(result_set)

        result_set = define_columns_types(result_set)
        
        merge= pd.merge(result_set,remuneracao_result_set,how='inner',on=['Id_SERVIDOR_PORTAL','NOME','CPF'])

        #  TODO
        # remover path estatico do codigo  
        #  #        
        merge.to_csv("D:\\Github\\FGApp\\backend\\Servidores\\test\\"+  str(i) + datetime.now().strftime("%d-%m-%Y-%H-%M-%S") +'.csv', index=False)

        #
        # TODO
        # inserir no banco nesse momento
        # e nao  gerar um arquivo csv
        # #

#
# define tipos de dados e remove espaços em branco
# #
def define_columns_types(resul_set):
    resul_set.CPF = resul_set.CPF.str.replace('\D','')
    resul_set.MATRICULA = resul_set.MATRICULA.str.replace('\D','')
    resul_set["Id_SERVIDOR_PORTAL"] = resul_set['Id_SERVIDOR_PORTAL'].astype('int')
    resul_set["CPF"] = resul_set['CPF'].astype('int')
    resul_set["MATRICULA"] = resul_set['MATRICULA'].astype('int')
    return resul_set

def remove_last_line(x):
    x = x[x.SIGLA_FUNCAO != '-1']
    return x

def remove_columns_cadastro(x):
    keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO',
                'NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO',
                'DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','UF_EXERCICIO']


    x = x[keep_col]
    return x

def create_total_column(remuneracao_result_set):
    col_list = list(remuneracao_result_set)
    col_list.remove('ANO')
    col_list.remove('MES')
    col_list.remove('Id_SERVIDOR_PORTAL')
    col_list.remove('CPF')
    col_list.remove('NOME')

    define_types(remuneracao_result_set)

    remuneracao_result_set['total_remuneracao'] = remuneracao_result_set[col_list].sum(axis=1)

def define_types(y):
    y["ANO"] = y['ANO'].astype('int')
    y["MES"] = y['MES'].astype('int')
    y["CPF"] = y['CPF'].astype('int')
    y["Id_SERVIDOR_PORTAL"] = y['Id_SERVIDOR_PORTAL'].astype('int')

    y["REMUNERACAO_BASICA_BRUTA"] = y['REMUNERACAO_BASICA_BRUTA'].astype('float')
    y["GRATIFICACAO_NATALINA"] = y['GRATIFICACAO_NATALINA'].astype('float')
    y["FERIAS"] = y['FERIAS'].astype('float')
    y["OUTRAS_REMUNERACOES_EVENTUAIS"] = y['OUTRAS_REMUNERACOES_EVENTUAIS'].astype('float')
    y["TOTAL_DE_VERBAS_INDENIZATORIAS"] = y['TOTAL_DE_VERBAS_INDENIZATORIAS'].astype('float')

def remove_columns_remuneracao(y):
    keep_col =      ['ANO', 'MES', 'Id_SERVIDOR_PORTAL', 'CPF', 'NOME',
                        'REMUNERACAO_BASICA_BRUTA', 'GRATIFICACAO_NATALINA',
                        'FERIAS',
                        'OUTRAS_REMUNERACOES_EVENTUAIS', 
                        'TOTAL_DE_VERBAS_INDENIZATORIAS']

    y = y[keep_col]
    y = y[:-1] #remove last row
    return y

def remove_spaces(y):
    y.columns = y.columns.str.replace('\D(R\$\D)','')
    y.columns = y.columns.str.replace('\D(\*\D)','')
    y.columns = y.columns.str.replace('\/^\s+|\s+$','')
    y.columns = y.columns.str.replace(' ','_')
    y.CPF = y.CPF.str.replace('\D','')

def remove_coll_dolar(y):
    drop_columns = []
    for x in y[:0]:
        if('U$' in x):
            y = y.drop(columns=[x])
    return y

def remove_pt_caracteres(y):
    new_header = []
    for x in y[:0]:
        new_header.append(unidecode(x))

    return new_header

def read_csv(remuneracao):
    y = pd.read_csv(remuneracao, encoding ="ISO-8859-1", delimiter=';', skipinitialspace=True,error_bad_lines = False, engine='c',decimal=",")
    return y


