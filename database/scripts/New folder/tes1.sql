/*
SELECT DISTINCT
        cd.nome_S AS NOME
    FROM
        vw_r_servidores cd
    WHERE
        cd.nome_S IN (SELECT DISTINCT
                NOME_DO_FILIADO
            FROM
                vw_r_afiliados)

*/
;
SELECT 
    aa.nome,
    bb.nome,
    bb.id,
    aa.id,
    bb.SIGLA,
    bb.NIVEL_FUNCAO,
    bb.FUNCAO,
    aa.SIGLA_DO_PARTIDO,
    aa.UF,
    aa.status,
    aa.ANO_AF,
    aa.MES_AF,
    bb.MES_SERV_EX,
    bb.ANO_SER_EX,
    aa.ANO_DF,
    aa.MES_DF,
    bb.DATA_ING_FUNCAO
FROM
    (SELECT 
        af.id,
            af.NOME_DO_FILIADO AS nome,
            af.SIGLA_DO_PARTIDO,
            af.UF,
            af.status,
            af.ANO_AF,
            af.MES_AF,
            af.ANO_DF,
            af.MES_DF
    FROM
        vw_r_afiliados af) aa,
    (SELECT 
        cv.id,
            cv.NOME_S AS nome,
            cv.SIGLA,
            cv.NIVEL_FUNCAO,
            cv.FUNCAO,
            cv.DATA_ING_FUNCAO,
            cv.MES_SERV_EX,
            cv.ANO_SER_EX
    FROM
        vw_r_servidores cv) bb
WHERE
    bb.nome = aa.nome 
    and (
			(
			bb.ANO_SER_EX >= aa.ano_af AND
			bb.MES_SERV_EX >= aa.mes_af and
			bb.ANO_SER_EX < aa.ano_df
			) 
            OR
            (
			bb.ANO_SER_EX = aa.ano_df AND
			bb.MES_SERV_EX <= aa.mes_df
            )
		)
order by aa.id, bb.ano_ser_ex, bb.MES_SERV_EX
limit 10