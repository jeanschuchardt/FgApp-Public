/*select distinct SIGLA_DO_PARTIDO, UF from stg_afiliados;
select * from stg_afiliados
;
*/
create table cadastro_politico like stg_afiliados;
ALTER TABLE cadastro_politico 
DROP COLUMN data_da_filiacao,
drop column situacao_do_registro,
drop column data_da_desfiliacao
;
ALTER TABLE cadastro_politico 
DROP COLUMN data_da_filiacao,
drop column situacao_do_registro,
drop column data_da_desfiliacao
;
ALTER TABLE cadastro_politico ADD COLUMN id INT AUTO_INCREMENT UNIQUE FIRST;

ALTER TABLE cadastro_politico 
ADD UNIQUE INDEX af_unico (NOME_DO_FILIADO(200), NUMERO_DA_INSCRICAO, SIGLA_DO_PARTIDO(10), UF(10) , NOME_DO_MUNICIPIO(20) , SECAO_ELEITORAL, ZONA_ELEITORAL) ;
;

CREATE TABLE IF NOT EXISTS politico_ativo (
    id INT AUTO_INCREMENT,
    data_cadastro DATE,
    data_cancelamento DATE,
    fk_cad_id int,
    PRIMARY KEY (id),
	FOREIGN KEY (fk_cad_id) REFERENCES cadastro_politico(id)
)  ENGINE=INNODB;

ALTER TABLE politico_ativo add column `status` varchar(200);


INSERT INTO `datastage`.`cadastro_politico`
(
`NOME_DO_FILIADO`,
`NUMERO_DA_INSCRICAO`,
`SIGLA_DO_PARTIDO`,
`UF`,
`NOME_DO_MUNICIPIO`,
`ZONA_ELEITORAL`,
`SECAO_ELEITORAL`)

SELECT distinct `stg_afiliados`.`NOME_DO_FILIADO`,
    `stg_afiliados`.`NUMERO_DA_INSCRICAO`,
    `stg_afiliados`.`SIGLA_DO_PARTIDO`,
    `stg_afiliados`.`UF`,
    `stg_afiliados`.`NOME_DO_MUNICIPIO`,
    `stg_afiliados`.`ZONA_ELEITORAL`,
    `stg_afiliados`.`SECAO_ELEITORAL`
   
FROM `datastage`.`stg_afiliados`;

insert into politico_ativo (data_cadatro, data_cancelamento, status, fk_cad_id)
;
select stg.nome_do_filiado, cdp.id, stg.SITUACAO_DO_REGISTRO, stg.DATA_DA_FILIACAO, stg.DATA_DA_DESFILIACAO from stg_afiliados stg, cadastro_politico cdp
where stg.NOME_DO_FILIADO = cdp.NOME_DO_FILIADO 



