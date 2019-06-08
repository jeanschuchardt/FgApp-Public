(
SELECT distinct
    cp.id AS id,
    cp.NOME_DO_FILIADO AS NOME_DO_FILIADO,
    cp.SIGLA_DO_PARTIDO AS SIGLA_DO_PARTIDO,
    cp.UF AS UF,
    pa.DATA_FILIACAO AS DATA_FILIACAO,
    pa.DATA_DESFILIACAO AS DATA_DESFILIACAO,
    pa.status AS status
FROM
    cadastro_politico cp
        JOIN
    politico_ativo pa
WHERE
    cp.id = pa.fk_cad_id
        AND (CAST(EXTRACT(YEAR FROM pa.DATA_FILIACAO) AS UNSIGNED) >= 2015)
-- 		ORDER BY cp.id 
)
LIMIT 10