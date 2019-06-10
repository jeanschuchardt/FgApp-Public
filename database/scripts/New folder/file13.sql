select 
	cad_p.NOME_DO_FILIADO,
    cad_p.uf,
    cad_p.NOME_DO_MUNICIPIO,
    cad_p.SIGLA_DO_PARTIDO,
    pol_at.status,
    EXTRACT(YEAR FROM pol_at.DATA_FILIACAO) as year,
	EXTRACT(Month FROM pol_at.DATA_FILIACAO) as month
   
from cadastro_politico cad_p

inner join politico_ativo  pol_at
on pol_at.fk_cad_id =  cad_p.id
where  pol_at.status = 'REGULAR'
AND 
EXTRACT(YEAR FROM pol_at.DATA_FILIACAO) > 2014

limit 10;



select 
	cad_ser.id,
    cad_ser.nome,
    cargo_ser.sigla_funcao,
    cargo_ser.nivel_funcao,
    cargo_ser.funcao,
    cargo_ser.ano,
    cargo_ser.mes

from cadastro_servidores cad_ser

inner join cargo_servidores cargo_ser
on cad_ser.id	= cargo_ser.fk_servidor
where cad_ser.id is not null
and cargo_ser.ano = '2017'
limit 100;