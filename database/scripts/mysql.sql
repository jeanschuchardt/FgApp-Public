select NOME_DO_FILIADO,NUMERO_DA_INSCRICAO,SIGLA_DO_PARTIDO,UF,NOME_DO_MUNICIPIO,ZONA_ELEITORAL,SECAO_ELEITORAL,DATA_DA_FILIACAO,SITUACAO_DO_REGISTRO, DATA_DA_DESFILIACAO,count(NUMERO_DA_INSCRICAO) as count 
from stg_afiliados
where NUMERO_DA_INSCRICAO =  34863870477tb_estados
group by NOME_DO_FILIADO,NUMERO_DA_INSCRICAO,SIGLA_DO_PARTIDO,UF,NOME_DO_MUNICIPIO,ZONA_ELEITORAL,SECAO_ELEITORAL,DATA_DA_FILIACAO,SITUACAO_DO_REGISTRO,DATA_DA_DESFILIACAO
order by count desc
;

select NOME_DO_FILIADO,NUMERO_DA_INSCRICAO,SIGLA_DO_PARTIDO,UF,NOME_DO_MUNICIPIO,ZONA_ELEITORAL,SECAO_ELEITORAL,DATA_DA_FILIACAO,SITUACAO_DO_REGISTRO, count(NUMERO_DA_INSCRICAO) as count 
from stg_afiliados

group by NOME_DO_FILIADO,NUMERO_DA_INSCRICAO,SIGLA_DO_PARTIDO,UF,NOME_DO_MUNICIPIO,ZONA_ELEITORAL,SECAO_ELEITORAL,DATA_DA_FILIACAO,SITUACAO_DO_REGISTRO
order by count desc

;

select  distinct count(*) from stg_afiliados 
;

select count(*) from stg_afiliados 
;

select  'total cancelado', uf, SIGLA_DO_PARTIDO, count(*) 
from stg_afiliados
where situacao_do_registro = 'CANCELADO'
group by uf, SIGLA_DO_PARTIDO

union

select  
	'dados completos',uf, SIGLA_DO_PARTIDO, count(*) 
from 	
	stg_afiliados
where 	
	situacao_do_registro = 'CANCELADO' and 
	DATA_DA_DESFILIACAO is not null 
group by uf, SIGLA_DO_PARTIDO

union

 select  
	'dados incompletos',uf, SIGLA_DO_PARTIDO, count(*) 
from 	
	stg_afiliados
where 	
	situacao_do_registro = 'CANCELADO' and 
	DATA_DA_DESFILIACAO is null 
group by uf, SIGLA_DO_PARTIDO

;
delete from stg_afiliados
