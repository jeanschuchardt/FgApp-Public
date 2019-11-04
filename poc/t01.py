import pandas as pd
import datetime 
from sqlalchemy import create_engine
import numpy as np
from sqlalchemy.sql import select
from sqlalchemy.sql import text
from string import ascii_uppercase
import calendar

engine = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
conn = engine.connect()

s = text('SELECT id_portal,  nome, matricula, sigla, nivel, func, Indexes, id, partido, uf, ano, mes  '
         'FROM resultados  '
        
         )
result = conn.execute(s).fetchall()


resultados = pd.DataFrame(columns=["id_portal","nome","matricula","sigla","nivel","func","Indexes","id","partido","uf","ano","mes"], data = result)


df3 = resultados

#df3 = df3.set_index('ano')
#df3 = df3.set_index('mes')
#df3 = df3.set_index('sigla')

eng = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage')
df3.to_sql('test_resultados_index', eng, if_exists='append')