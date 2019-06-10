select 
	a.id,a.NOME_DO_FILIADO, 	
	EXTRACT(YEAR FROM b.DATA_FILIACAO) as year,
	EXTRACT(Month FROM b.DATA_FILIACAO) as month,
     b.DATA_FILIACAO
from cadastro_politico a
inner join politico_ativo b 
	on a.id =  b.fk_cad_id
where
	upper(b.status) =  'REGULAR'
	and b.data_desfiliacao is null
	and b.DATA_FILIACAO > '1901-01-01'
order by a.id
limit 30
;

select 
	a.id,
    a.nome,
	b.mes,
    b.ano
from cadastro_servidores a
inner join cargo_servidores b
	on a.id = b.fk_servidor
    
where b.ano>'2000'

order by a.id
limit 30
;

select * from cadastro_servidores

limit 10
;

select * from cargo_servidores

limit 10
;



select * from stg_servidores;

SELECT 
    *
FROM
    politico_ativo
LIMIT 1;