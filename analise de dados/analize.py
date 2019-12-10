#!/usr/bin/env python
# coding: utf-8

# In[5]:


import pandas as pd
import datetime 
from sqlalchemy import create_engine
import numpy as np
from sqlalchemy.sql import select
from sqlalchemy.sql import text
from string import ascii_uppercase


# In[7]:


def analise_ano_mes(ano,mes):
    engine = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
    conn = engine.connect()

    s = text('select sum(total_remuneracao),:ano, :mes from stg_servidores '
                'where ano = :ano '
                 'and mes = :mes '
            )
     
    return  conn.execute(s, ano=ano,mes=mes ).fetchall()

def delete_null_from_total():
    engine = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
    conn = engine.connect()
    delete = text('delete from total_gastos where total is null')        

    conn.execute(delete)

def call ():
    for x in range(2014,2020,1):
        for y in range(1,13,1):
            temp = pd.DataFrame(columns=["total", "ano", "mes"],data = analise_ano_mes(x,y))
            eng = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
            temp.to_sql('total_gastos', eng, if_exists='append', index=False)
        

def analise_af(ano,mes):
    engine = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
    conn = engine.connect()

    s = text('SELECT distinct Id_SERVIDOR_PORTAL,NOME,MATRICULA,SIGLA_FUNCAO,NIVEL_FUNCAO,FUNCAO '
                'FROM datastage.stg_servidores '
                'where ano = :ano '
                'and mes = :mes '
            )

    result = conn.execute(s, ano=ano,mes=mes ).fetchall()   
   
    return   pd.DataFrame(columns=["id_portal", "nome", "matricula","sigla","nivel","func"],data = result)



def  analise_fp2(mes,letter):
    engine = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
    conn = engine.connect()

    s = text('SELECT NOME_DO_FILIADO, NUMERO_DA_INSCRICAO, SIGLA_DO_PARTIDO, uf '
             'FROM tb_af568 where '
             'SITUACAO_DO_REGISTRO  not like \'ERROR\' and '
             ':m1 between DATE_FORMAT(DATA_DA_FILIACAO,"%Y-%m")   and  IFNULL(DATE_FORMAT(DATA_DA_DESFILIACAO,"%Y-%m"),now())'
             'and nome like  :m2  '
             'order by nome '
             )
    result = conn.execute(s, m1=mes, m2=letter).fetchall()
    
    return  pd.DataFrame(columns=["nome", "id", "partido","uf"],data = result)
    
def get_servidores_by_letter(letra,x):
    x["Indexes"]= x["nome"].str.find(letra) 
    x = x.query('Indexes == 0')
    return x

#def analise(ano,mes):
#    ano = str(ano)
#    mes = str(mes)
#    x = analise_af(ano,mes)
#    data = ano+'-'+mes
#    for letra in ascii_uppercase:
#        fp = analise_fp2(data, letra+'%')
#        serv = get_servidores_by_letter(letra,x)
#        merge = pd.merge(serv, fp, on='nome',how='right')
#        merge = merge.dropna()
#        merge = merge.drop_duplicates(['id_portal','nome'], keep='first')
#        merge['ano']=ano
#        merge['mes']=mes
#        eng = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
#        merge.to_sql('resultados', eng, if_exists='append', index=False)
#        print(letra)
#        


def analise(ano,mes):
    eng = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
      
    ano = str(ano)
    mes = str(mes)
    x = analise_af(ano,mes)
    data = ano+'-'+mes
    for letra in ascii_uppercase:
        
        results = []
        results.append(ano)
        results.append(mes)
        results.append(letra)
        
        fp = analise_fp2(data, letra+'%')
        serv = get_servidores_by_letter(letra,x)
        
        results.append(len(serv))
        results.append(len(fp))
        
        serv['C'] = serv.groupby(['nome'])['nome'].cumcount()
        fp['C'] = fp.groupby(['nome'])['nome'].cumcount()
        
        merge = pd.merge(serv, fp, on=['nome','C'],how='right',validate="1:1")
        
        merge = merge.dropna()
        merge  = merge.drop(['Indexes'],1)

           
        merge['ano']=ano
        merge['mes']=mes
        
        results.append(len(merge))
        
        df_results = pd.DataFrame()
        df_results = df_results.append(pd.Series(results, index=['ano', 'mes', 'letra','t_servidores','t_filados','t_resultados']),ignore_index=True)
        
        df_results.to_sql('resultados_numericos', eng, if_exists='append', index=False)
        merge.to_sql('resultados_02', eng, if_exists='append', index=False)
        print(letra)
        

# In[8]:


for ano in  range(2015, 2019,1):
    for mes in  range(1, 13,1):
        print (ano,"-",mes)
        analise(ano,mes)
        print('\n--------------------\n')


# In[ ]:




