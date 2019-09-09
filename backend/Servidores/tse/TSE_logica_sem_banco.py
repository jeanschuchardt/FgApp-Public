#!/usr/bin/env python
# coding: utf-8

# In[83]:


import pandas as pd
from sqlalchemy import create_engine
import numpy as np


# In[84]:


#path = "D:\\Github\\raw_data\\Unziper\\test.csv"
path = "D:\\Github\\raw_data\\Unziper\\filiados_pt_sc.csv"


# In[85]:


try:
    f=pd.read_csv(path, encoding ="ansi", delimiter=';',low_memory=False, skipinitialspace=True)
except:
    print("erro de leitura")  


# In[86]:


keep_col = ['NOME DO FILIADO','NUMERO DA INSCRICAO','SIGLA DO PARTIDO','UF','NOME DO MUNICIPIO','ZONA ELEITORAL','SECAO ELEITORAL','DATA DA FILIACAO','SITUACAO DO REGISTRO','DATA DA DESFILIACAO']
y = f[keep_col]
       


# In[87]:


y.columns = y.columns.str.replace('\D(R\$\D)','')
y.columns = y.columns.str.replace('\D(\*\D)','')
y.columns = y.columns.str.replace('\/^\s+|\s+$','')
y.columns = y.columns.str.replace(' ','_')


# In[88]:


#taes = y.groupby('SITUACAO_DO_REGISTRO')
#taes.get_group('CANCELADO')


# In[ ]:





# In[89]:


def situacao_registro(data_frame):
    return  data_frame.groupby('SITUACAO_DO_REGISTRO')


# In[90]:


def sr_cancelado(sr_gb):
    CANCELADO = 'CANCELADO'
    df_cancelado = sr_gb.get_group(CANCELADO)
    return df_cancelado


# In[91]:


def sr_regular(sr_gb):
    REGULAR = 'REGULAR'
    df_regular = sr_gb.get_group(REGULAR)
    return df_regular


# In[92]:


def cancelado_grouby(df):
    not_null = df[df['DATA_DA_DESFILIACAO'].notnull()]
    is_null = df[df['DATA_DA_DESFILIACAO'].isnull()]
    return not_null,is_null


# In[93]:


def insert(data,table):
    try:
       
        eng = create_engine('mysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
     
        data.to_sql(table, eng, if_exists='append', index=False)
        print('arquivo inserido')
    except Exception  as e:
      
        print("error insert "+ e)
        
    
        
        


# In[94]:





# In[96]:


#main

sr_gb =  situacao_registro(y)

df_cancelado = sr_cancelado(sr_gb)

df_regular = sr_regular(sr_gb)

# quando o cancelado for null salvar esse registro em um outra tabela para  tentar processar os dados mais tardes #
cancelado_not_null,cancelado_is_null = cancelado_grouby(df_cancelado)


#cancelado_not_null
#gb_cancelado


# In[101]:


cancelado_not_null


insert (df_regular,'stg_af2')
insert (cancelado_not_null,'stg_af2')
insert (cancelado_is_null,'stg_af_data_missing2')


# fazer um filtro de tempo passando mes e ano 
# esse filto deve ser generico

# verificar se nos cancalados null e nos cancalados not null nao tem conflitos de id

# varificar o que fazer com os registro com mais de 100 anos


# In[ ]:





# In[100]:


cancelado_is_null.count()
#df = cancelado_is_null


# In[53]:


#df_cancelado['dat'] = np.nan
df_cancelado

#DATA_DA_DESFILIACAO


# In[64]:



#cancelado_is_null.count()/(df_cancelado.count()+cancelado_is_null.count())

df_cancelado.columns


# In[76]:


#f_cancelado.equals(cancelado_is_null)
mergedStuff = pd.merge(cancelado_not_null, cancelado_is_null, on=['NOME_DO_FILIADO', 'NUMERO_DA_INSCRICAO', 'SIGLA_DO_PARTIDO', 'UF',
       'NOME_DO_MUNICIPIO', 'ZONA_ELEITORAL', 'SECAO_ELEITORAL',
        'SITUACAO_DO_REGISTRO'],how='inner')
#mergedStuff.head()
mergedStuff


# In[ ]:




