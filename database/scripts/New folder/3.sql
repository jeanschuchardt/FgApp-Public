select cs.*, cp.* from (
SELECT 
    *
FROM
    (SELECT DISTINCT
        AF.NOME_DO_FILIADO AS NOME_1, MIN(AF.id) id_af
    FROM
        cadastro_politico AF
    WHERE
        AF.NOME_DO_FILIADO IN (SELECT DISTINCT
                NOME
            FROM
                cadastro_servidores)
    GROUP BY AF.NOME_DO_FILIADO
    ORDER BY AF.NOME_DO_FILIADO) a,
    (SELECT DISTINCT
        AF.nome AS NOME, MIN(id) id_sv
    FROM
        cadastro_servidores AF
    WHERE
        AF.nome IN (SELECT DISTINCT
                NOME_DO_FILIADO
            FROM
                cadastro_politico)
    GROUP BY AF.nome
    ORDER BY AF.nome) b
WHERE
    a.nome_1 = b.nome
    ) x
    
    left join cadastro_politico cp
    on x.id_af = cp.id
    left join cadastro_servidores cs
    on x.id_sv = cs.id