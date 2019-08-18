import pandas as pd
from sqlalchemy import create_engine
from unidecode import unidecode



path = "D:\\Github\\FGApp\\backend\\Servidores\\test\\201903_Cadastro.csv"
    
path2 = "D:\\Github\\FGApp\\backend\\Servidores\\test\\201903_Remuneracao.csv"

c = 10000

y = pd.read_csv(path2, encoding ="ISO-8859-1", delimiter=';', skipinitialspace=True,error_bad_lines = False, engine='c',decimal=",")



new_header = []
for x in y[:0]:
    new_header.append(unidecode(x))

y.columns =new_header

drop_columns = []
for x in y[:0]:
    if('U$' in x):
       y = y.drop(columns=[x])



y.columns = y.columns.str.replace('\D(R\$\D)','')
y.columns = y.columns.str.replace('\D(\*\D)','')
y.columns = y.columns.str.replace('\/^\s+|\s+$','')
y.columns = y.columns.str.replace(' ','_')
y.CPF = y.CPF.str.replace('\D','')


keep_col =      ['ANO', 'MES', 'Id_SERVIDOR_PORTAL', 'CPF', 'NOME',
                    'REMUNERACAO_BASICA_BRUTA', 'GRATIFICACAO_NATALINA',
                    'FERIAS',
                    'OUTRAS_REMUNERACOES_EVENTUAIS', 
                    'TOTAL_DE_VERBAS_INDENIZATORIAS']

y = y[keep_col]

print ()



y = y[:-1] #remove last row


col_list = list(y)
col_list.remove('ANO')
col_list.remove('MES')
col_list.remove('Id_SERVIDOR_PORTAL')
col_list.remove('CPF')
col_list.remove('NOME')

y["ANO"] = y['ANO'].astype('int')
y["MES"] = y['MES'].astype('int')
y["CPF"] = y['CPF'].astype('int')
y["Id_SERVIDOR_PORTAL"] = y['Id_SERVIDOR_PORTAL'].astype('int')

y["REMUNERACAO_BASICA_BRUTA"] = y['REMUNERACAO_BASICA_BRUTA'].astype('float')
y["GRATIFICACAO_NATALINA"] = y['GRATIFICACAO_NATALINA'].astype('float')
y["FERIAS"] = y['FERIAS'].astype('float')
y["OUTRAS_REMUNERACOES_EVENTUAIS"] = y['OUTRAS_REMUNERACOES_EVENTUAIS'].astype('float')
y["TOTAL_DE_VERBAS_INDENIZATORIAS"] = y['TOTAL_DE_VERBAS_INDENIZATORIAS'].astype('float')

y['total_remuneracao'] = y[col_list].sum(axis=1)


y.to_csv("D:\\Github\\FGApp\\backend\\Servidores\\test\\"+  'test_soma' +'.csv', index=False)

#keep_col = ['ANO','MES','Id_SERVIDOR_PORTAL','CPF','NOME','total_remuneracao'] #remover valores intermediarios a soma 
#y = y[keep_col]
###


for i, x in enumerate((pd.read_csv(path, encoding ="ISO-8859-1", delimiter=';', skipinitialspace=True,error_bad_lines = False, engine='c',chunksize=c))):
    keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO',
                'NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO',
                'DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','UF_EXERCICIO']


    x = x[keep_col]
    x = x[x.SIGLA_FUNCAO != '-1']

    x.CPF = x.CPF.str.replace('\D','')
    x.MATRICULA = x.MATRICULA.str.replace('\D','')
    x["Id_SERVIDOR_PORTAL"] = x['Id_SERVIDOR_PORTAL'].astype('int')
    x["CPF"] = x['CPF'].astype('int')
    x["MATRICULA"] = x['MATRICULA'].astype('int')
    
    merge= pd.merge(x,y,how='inner',on=['Id_SERVIDOR_PORTAL','NOME','CPF'])

    
    merge.to_csv("D:\\Github\\FGApp\\backend\\Servidores\\test\\"+  str(i) +'.csv', index=False)


