
SELECT 
    *
FROM
    (SELECT 
        cp.id,
            cp.NOME_DO_FILIADO,
            cp.SIGLA_DO_PARTIDO,
            cp.UF,
            pa.DATA_FILIACAO,
            pa.DATA_DESFILIACAO,
            pa.status
    FROM
        cadastro_politico cp, politico_ativo pa
    WHERE
        CAST(EXTRACT(YEAR FROM pa.data_filiacao) AS UNSIGNED) >= 2015
            AND cp.id = pa.fk_cad_id) a
WHERE
    (a.status != 'REGULAR'
        AND a.data_desfiliacao IS NOT NULL)
        OR (a.status = 'REGULAR'
        AND a.data_desfiliacao IS NULL)

;