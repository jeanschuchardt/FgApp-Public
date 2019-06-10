 SELECT 
        `a`.`id` AS `id`,
        `a`.`NOME_DO_FILIADO` AS `NOME_DO_FILIADO`,
        `a`.`SIGLA_DO_PARTIDO` AS `SIGLA_DO_PARTIDO`,
        `a`.`UF` AS `UF`,
        `a`.`status` AS `status`,
        CAST(EXTRACT(YEAR FROM `a`.`DATA_FILIACAO`) AS UNSIGNED) AS `ANO_AF`,
        CAST(EXTRACT(MONTH FROM `a`.`DATA_FILIACAO`) AS UNSIGNED) AS `MES_AF`,
        CAST(EXTRACT(YEAR FROM `a`.`DATA_DESFILIACAO`)
            AS UNSIGNED) AS `ANO_DF`,
        CAST(EXTRACT(MONTH FROM `a`.`DATA_DESFILIACAO`)
            AS UNSIGNED) AS `MES_DF`
    FROM
        (SELECT DISTINCT
            `cp`.`id` AS `id`,
                `cp`.`NOME_DO_FILIADO` AS `NOME_DO_FILIADO`,
                `cp`.`SIGLA_DO_PARTIDO` AS `SIGLA_DO_PARTIDO`,
                `cp`.`UF` AS `UF`,
                `pa`.`DATA_FILIACAO` AS `DATA_FILIACAO`,
                `pa`.`DATA_DESFILIACAO` AS `DATA_DESFILIACAO`,
                `pa`.`status` AS `status`
        FROM
            (`cadastro_politico` `cp`
        JOIN `politico_ativo` `pa`)
        WHERE
            ((`cp`.`id` = `pa`.`fk_cad_id`)
                AND (CAST(EXTRACT(YEAR FROM `pa`.`DATA_FILIACAO`) AS UNSIGNED) >= 2015))) `a`
    WHERE
        (((`a`.`status` <> 'REGULAR')
            AND (`a`.`DATA_DESFILIACAO` IS NOT NULL))
            OR ((`a`.`status` = 'REGULAR')
            AND ISNULL(`a`.`DATA_DESFILIACAO`)))
    ORDER BY `a`.`id` , CAST(EXTRACT(YEAR FROM `a`.`DATA_FILIACAO`) AS UNSIGNED) desc , CAST(EXTRACT(MONTH FROM `a`.`DATA_FILIACAO`) AS UNSIGNED) desc