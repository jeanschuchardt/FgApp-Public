import multiprocessing as mp
import random
import string
import pandas as pd
import datetime 
from sqlalchemy import create_engine
import numpy as np
from sqlalchemy.sql import select
from sqlalchemy.sql import text
from string import ascii_uppercase
import calendar

#random.seed(123)

# Define an output queue
output = mp.Queue()
'''
def analise_af(ano,mes):
    engine = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
    conn = engine.connect()

    s = text('SELECT distinct Id_SERVIDOR_PORTAL,NOME,MATRICULA,SIGLA_FUNCAO,NIVEL_FUNCAO,FUNCAO '
                'FROM datastage.stg_servidores '
                'where ano = :ano '
                'and mes = :mes '
            )

    result = conn.execute(s, ano=ano,mes=mes ).fetchall()   
    conn.close()
    return   pd.DataFrame(columns=["id_portal", "nome", "matricula","sigla","nivel","func"],data = result)
'''
def run_query(inicial,final,limit):
    engine = create_engine('mysql+pymysql://admin:example@localhost:3308/datastage') #ler isso do config e remover do codigo
    conn = engine.connect()

    s = text('select NOME_DO_FILIADO, NUMERO_DA_INSCRICAO, SIGLA_DO_PARTIDO, uf, DATA_DA_FILIACAO, DATA_DA_DESFILIACAO,SITUACAO_DO_REGISTRO from stg_af256 '
           

                'where  DATA_DA_DESFILIACAO is null '
                'and SITUACAO_DO_REGISTRO = \'REGULAR\' '
                'LIMIT 100000 OFFSET :limit'

             )
    result = conn.execute(s, inicial=inicial, final=final, limit=limit).fetchall()
    conn.close()
    print("xxxx")
    x = pd.DataFrame(columns=["nome", "id", "partido","uf","DATA_DA_FILIACAO","DATA_DA_DESFILIACAO","SITUACAO"],data = result)
    return x



# define a example function
def rand_string(length, output):
    """ Generates a random string of numbers, lower- and uppercase chars. """
    rand_str = ''.join(random.choice(
                        string.ascii_lowercase
                        + string.ascii_uppercase
                        + string.digits)
                   for i in range(length))
    output.put(rand_str)

if __name__ == '__main__':
    ano = 2017
    mes = 12
    tuple_days = calendar.monthrange(ano,mes)
    partial_date = str(ano) + '-' + str(mes) +'-'
    initial_date = partial_date + str(1)
    final_date = partial_date + str( tuple_days[1])
    # Setup a list of processes that we want to run
    processes = []
    #processes.append(mp.Process(target=analise_af, args=(2017, 12)))
    for x in range(0,200000,100000):
        ano = 2017
        mes = 12
        tuple_days = calendar.monthrange(ano,mes)
        partial_date = str(ano) + '-' + str(mes) +'-'
        initial_date = partial_date + str(1)
        final_date = partial_date + str( tuple_days[1])
        result_ff = run_query(initial_date,final_date,x)
        #processes.append(mp.Process(target=run_query, args=(initial_date, final_date,x,output,)))
        processes.append(result_ff)
        #resultados_sel = resultados_sel.append(result_ff, ignore_index = True)
        
    
        print(x)
   # processes.append(mp.Process(target=run_query, args=(initial_date, final_date)))

    

    # Get process results from the output queue
    print("aqui")
    for p in processes:
        print(p)
    