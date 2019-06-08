select count(*) from vw_r_servidores
union
select count(*) from vw_af_ativo
;






;

SELECT DISTINCT
        cd.nome_S AS NOME
    FROM
        vw_r_servidores cd
    WHERE
        cd.nome_S IN (SELECT DISTINCT
                NOME_DO_FILIADO
            FROM
                vw_r_afiliados)
