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