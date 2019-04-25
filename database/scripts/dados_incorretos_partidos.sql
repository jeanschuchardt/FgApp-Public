
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