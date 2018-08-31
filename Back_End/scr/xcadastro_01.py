#!/usr/bin/env python
import sys
import pandas as pd
import numpy as np
import os
import glob


#pasth file
#filez ='..\\data_input\\20180131_Cadastro.csv'
filez = "..\\data_input\\20130131_Cadastro.csv"
#filez ="D:\\Project\\Final%20Paper%20-%20Mapping%20Public%20Data\\partidos_UZIP\\filiados_pmdb_sp.csv"
#filez ='unzip\\teste\\aplic\\sead\\lista_filiados\\uf\\filiados_pmdb_sp.csv'
 #

#encoding and read
f=pd.read_csv(filez, sep=',\s+', encoding ="ansi", delimiter='\t',low_memory=False, skipinitialspace=True)

#the name of colluns 
keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO','NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO','DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','DATA_NOMEACAO_CARGOFUNCAO','DATA_INGRESSO_ORGAO']
#keep_col = ['Id_SERVIDOR_PORTAL','NOME','CPF','MATRICULA','SIGLA_FUNCAO','NIVEL_FUNCAO','FUNCAO','UORG_EXERCICIO','DATA_INICIO_AFASTAMENTO','DATA_TERMINO_AFASTAMENTO','DATA_INGRESSO_CARGOFUNCAO','DATA_NOMEACAO_CARGOFUNCAO','DATA_INGRESSO_ORGAO','UF_EXERCICIO']
df = f[keep_col]

df = df.dropna(subset=['SIGLA_FUNCAO'])


#crate new file
df.to_csv("..\\data_result\\0.csv", index=False)
