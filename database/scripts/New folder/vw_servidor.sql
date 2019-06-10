CREATE VIEW `servidores_data` AS
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
order by ano and mes


CREATE VIEW `resultado_servidores` AS
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
;

CREATE VIEW `resultados_politicos` AS

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


CREATE VIEW `vw_af_ativo` AS
SELECT distinct
    -- stg.nome_do_filiado,
	STR_TO_DATE(stg.DATA_DA_FILIACAO, '%d/%m/%Y') as DATA_FILIACAO,
    STR_TO_DATE(stg.DATA_DA_DESFILIACAO, '%d/%m/%Y')as DATA_DA_DESFILIACAO,
    cdp.id,
    stg.SITUACAO_DO_REGISTRO
FROM
    cadastro_politico cdp
    inner join stg_afiliados stg
    on    cdp.NUMERO_DA_INSCRICAO = stg.NUMERO_DA_INSCRICAO
        AND cdp.SIGLA_DO_PARTIDO = stg.SIGLA_DO_PARTIDO
        
order by  cdp.id