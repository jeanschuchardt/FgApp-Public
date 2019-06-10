SELECT 
    `cads`.`id` AS `id`,
    `cads`.`NOME` AS `NOME_S`,
    `cs`.`SIGLA_FUNCAO` AS `SIGLA`,
    `cs`.`NIVEL_FUNCAO` AS `NIVEL_FUNCAO`,
    `cs`.`FUNCAO` AS `FUNCAO`,
    `cs`.`DATA_INGRESSO_CARGOFUNCAO` AS `DATA_ING_FUNCAO`,
    `cs`.`MES` AS `MES_SERV_EX`,
    `cs`.`ANO` AS `ANO_SER_EX`
FROM
    (`cadastro_servidores` `cads`
    JOIN `tbl_cargo_servidores` `cs` ON ((`cads`.`id` = `cs`.`FK_SERVIDOR`)))
WHERE
    (`cs`.`ANO` >= 2015)
ORDER BY `cads`.`id` , `cs`.`ANO` desc , `cs`.`MES` desc