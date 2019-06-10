 -- ultmas trocas de  funcao

SELECT 
    MIN(m.mes), xx.*
FROM
    test_result_servidores m,
    (SELECT 
        MIN(d.ANO) AS ano, x.*
    FROM
        test_result_servidores d, (SELECT 
        serv.id, serv.nome, serv.sigla_funcao, serv.funcao
    FROM
        test_result_servidores serv, (SELECT 
        a.id, COUNT(a.id)
    FROM
        (SELECT 
        id, nome, sigla_funcao, funcao
    FROM
        test_result_servidores
    GROUP BY id , nome , sigla_funcao , funcao) a
    GROUP BY id
    HAVING COUNT(id) > 1) result
    WHERE
        serv.id = result.id
    GROUP BY serv.id , serv.nome , serv.sigla_funcao , serv.funcao) x
    WHERE
        x.id = d.id
            AND x.sigla_funcao = d.sigla_funcao
            AND x.funcao = d.funcao
    GROUP BY x.id , x.nome , x.sigla_funcao , x.funcao) xx
WHERE
    xx.id = m.id AND xx.ano = m.ano
        AND xx.sigla_funcao = m.sigla_funcao
GROUP BY xx.id , xx.nome , xx.sigla_funcao , xx.funcao , xx.ano


;



