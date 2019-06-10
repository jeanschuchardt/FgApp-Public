select  servc.FK_SERVIDOR
	,servc.SIGLA_FUNCAO
    ,servc.NIVEL_FUNCAO
    ,servc.FUNCAO
    ,servc.mes
    ,servc.ano
    ,serv.nome

from cargo_servidores servc
inner join cadastro_servidores serv
on serv.id = servc.fk_servidor
where ano='2017'
order by mes
limit 10
;
select * from servidores_data
where ano = '2017'

;
select  
	 servc.FK_SERVIDOR
	,servc.SIGLA_FUNCAO
    ,servc.NIVEL_FUNCAO
    ,servc.FUNCAO
    ,servc.mes
    ,servc.ano
    ,serv.nome
from cargo_servidores servc
inner join cadastro_servidores serv
on serv.id = servc.fk_servidor
;
select  
	 servc.FK_SERVIDOR
	,servc.SIGLA_FUNCAO
    ,servc.NIVEL_FUNCAO
    ,servc.FUNCAO
    ,servc.mes
    ,servc.ano
    ,serv.nome
from cargo_servidores servc
inner join cadastro_servidores serv
on serv.id = servc.fk_servidor
;

select 
	count(*),
	cad_p.UF,
    cad_p.NOME_DO_MUNICIPIO,
    cad_p.SIGLA_DO_PARTIDO,
    cargo_ser.sigla_funcao,
    cargo_ser.nivel_funcao,
    cargo_ser.funcao

from cadastro_politico cad_p

inner join politico_ativo  pol_at
on pol_at.fk_cad_id =  cad_p.id
inner join cadastro_servidores cas_ser
on cas_ser.nome = cad_p.NOME_DO_FILIADO

inner join cargo_servidores cargo_ser
on cas_ser.id	= cargo_ser.fk_servidor
where  cas_ser.nome is not null
and pol_at.status='REGULAR'
and EXTRACT(YEAR FROM pol_at.DATA_FILIACAO) > '2014'
group by 
	cad_p.UF,
    cad_p.NOME_DO_MUNICIPIO,
    cad_p.SIGLA_DO_PARTIDO,
    cargo_ser.sigla_funcao,
    cargo_ser.nivel_funcao,
    cargo_ser.funcao

limit 5;