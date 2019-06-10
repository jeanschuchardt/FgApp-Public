  SELECT 
        `cad_p`.`NOME_DO_FILIADO` AS `NOME_DO_FILIADO`,
        `cad_p`.`UF` AS `uf`,
        `cad_p`.`NOME_DO_MUNICIPIO` AS `NOME_DO_MUNICIPIO`,
        `cad_p`.`SIGLA_DO_PARTIDO` AS `SIGLA_DO_PARTIDO`,
        `pol_at`.`status` AS `status`,
        CAST(EXTRACT(YEAR FROM `pol_at`.`DATA_FILIACAO`)
            AS UNSIGNED) AS `ANO_AF`,
        CAST(EXTRACT(MONTH FROM `pol_at`.`DATA_FILIACAO`)
            AS UNSIGNED) AS `MES_AF`,
		 CAST(EXTRACT(YEAR FROM `pol_at`.`data_desfiliacao`)
            AS UNSIGNED) AS `ANO_DF`,
        CAST(EXTRACT(MONTH FROM `pol_at`.`data_desfiliacao`)
            AS UNSIGNED) AS `MES_DF`
		
		
    FROM
        (`cadastro_politico` `cad_p`
        JOIN `politico_ativo` `pol_at` ON ((`pol_at`.`fk_cad_id` = `cad_p`.`id`)))
    WHERE
		EXTRACT(YEAR FROM `pol_at`.`DATA_FILIACAO`) >= 2014
        and
       
	(	
        pol_at.status  = 'REGULAR' 
         or
        pol_at.data_desfiliacao is not null
     )    
            ;
            
            
	