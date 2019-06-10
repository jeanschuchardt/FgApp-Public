-- scripty de criação

-- afiliados a partidos politicos

create table cadastro_politico like stg_afiliados;

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
    DATA_FILIACAO DATE,
    DATA_DESFILIACAO DATE,
    fk_cad_id int,
    PRIMARY KEY (id),
	FOREIGN KEY (fk_cad_id) REFERENCES cadastro_politico(id)
)  ENGINE=INNODB;

ALTER TABLE politico_ativo add column `status` varchar(200);


