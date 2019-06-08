
SELECT DISTINCT
    a.*, b.*
FROM
    test_result_politicos a
        INNER JOIN
    test_result_servidores b ON b.nome = a.nome_do_filiado
        AND b.ano >= a.ano_af
        AND b.mes >= a.mes_af
        AND ((b.ano < a.ano_df)
        OR (b.ano = a.ano_df AND b.mes <= a.mes_df))
WHERE
    b.ano = 2017
ORDER BY b.mes
LIMIT 10	;
 