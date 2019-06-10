
SELECT 
    *
FROM
    `datastage`.`stg_servidores`;

CREATE TABLE cadastro_servidores LIKE stg_servidores;

ALTER TABLE cadastro_servidores 
DROP COLUMN SIGLA_FUNCAO,
DROP COLUMN NIVEL_FUNCAO,
DROP COLUMN FUNCAO,
DROP COLUMN UORG_EXERCICIO,
DROP COLUMN DATA_INICIO_AFASTAMENTO,
DROP COLUMN DATA_TERMINO_AFASTAMENTO,
DROP COLUMN DATA_INGRESSO_CARGOFUNCAO,
DROP COLUMN DATA_NOMEACAO_CARGOFUNCAO,
DROP COLUMN DATA_INGRESSO_ORGAO,
DROP COLUMN MES,
DROP COLUMN ANO
;

ALTER TABLE cadastro_servidores ADD COLUMN id INT AUTO_INCREMENT UNIQUE FIRST;

ALTER TABLE `datastage`.`cadastro_servidores` 
ADD INDEX `nome_servidor` (`NOME`(100) ASC) VISIBLE,
ADD INDEX `cpf` (`CPF`(15) ASC) VISIBLE,
ADD UNIQUE INDEX `serv` (`Id_SERVIDOR_PORTAL` ASC, `NOME`(100) ASC, `CPF`(15) ASC, `MATRICULA`(10) ASC) INVISIBLE
;

-- INSERT IGNORE INTO cadastro_servidores
-- (
-- 	Id_SERVIDOR_PORTAL,
-- 	NOME,
-- 	CPF,
-- 	MATRICULA
-- )
-- SELECT DISTINCT 
-- 	Id_SERVIDOR_PORTAL,
-- 	NOME,
-- 	CPF,
-- 	MATRICULA
-- FROM  stg_servidores
;

CREATE TABLE cargo_servidores LIKE stg_servidores;

ALTER TABLE cargo_servidores 
DROP COLUMN NOME,
DROP COLUMN CPF,
DROP COLUMN Id_SERVIDOR_PORTAL,
DROP COLUMN MATRICULA

;

ALTER TABLE cargo_servidores ADD COLUMN id INT AUTO_INCREMENT UNIQUE FIRST;
ALTER TABLE cargo_servidores ADD COLUMN FK_SERVIDOR INT ;

ALTER TABLE `datastage`.`cargo_servidores` 
ADD PRIMARY KEY (`id`);
ALTER TABLE `datastage`.`cargo_servidores` 
ADD INDEX `sigla` (`SIGLA_FUNCAO`(10) ASC) VISIBLE,
ADD INDEX `funcao` (`NIVEL_FUNCAO`(5) ASC) VISIBLE;

ALTER TABLE `datastage`.`cargo_servidores` 

ADD INDEX `uni` (`SIGLA_FUNCAO` ASC, `NIVEL_FUNCAO` ASC, `FUNCAO` ASC, `UORG_EXERCICIO` ASC, `DATA_INICIO_AFASTAMENTO` ASC, `DATA_TERMINO_AFASTAMENTO` ASC, `DATA_INGRESSO_CARGOFUNCAO` ASC, `DATA_NOMEACAO_CARGOFUNCAO` ASC, `DATA_INGRESSO_ORGAO` ASC, `ANO` ASC, `MES` ASC, `FK_SERVIDOR` ASC) VISIBLE;
ALTER TABLE `datastage`.`cargo_servidores` ALTER INDEX `id` INVISIBLE;

ALTER TABLE cargo_servidores
ADD CONSTRAINT fk_cas_ser
FOREIGN KEY (FK_SERVIDOR) REFERENCES cadastro_servidores(id);


ALTER TABLE cargo_servidores 
add COLUMN UF_EXERCICIO varchar (100);

ALTER TABLE cargo_servidores 
drop column mes,
drop column ano,
add column MES varchar(3),
add column ANO varchar(5);


ALTER TABLE cargo_servidores 
drop COLUMN DATA_NOMEACAO_CARGOFUNCAO,
drop COLUMN DATA_INGRESSO_ORGAO ;


/*                        */


select count(*) from cadastro_servidores  a 
union
select count(*) from stg_servidores b  ;


select distinct count(*) from stg_servidores b  ;

INSERT IGNORE INTO `datastage`.`cargo_servidores`
(
`SIGLA_FUNCAO`,
`NIVEL_FUNCAO`,
`FUNCAO`,
`UORG_EXERCICIO`,
`DATA_INICIO_AFASTAMENTO`,
`DATA_TERMINO_AFASTAMENTO`,
`DATA_INGRESSO_CARGOFUNCAO`,
`ANO`,
`MES`,
`FK_SERVIDOR`,
`UF_EXERCICIO`)

SELECT 
-- css.*,
-- stg.nome,
-- stg.id_servidor_portal,
stg.SIGLA_FUNCAO,
stg.NIVEL_FUNCAO,
stg.FUNCAO,
stg.UORG_EXERCICIO,
STR_TO_DATE(stg.DATA_INICIO_AFASTAMENTO,'%d/%m/%Y')as DATA_INICIO_AFASTAMENTO,vw_af_ativo

STR_TO_DATE(stg.DATA_INICIO_AFASTAMENTO,'%d/%m/%Y')as DATA_INICIO_AFASTAMENTO,vw_af_ativo
STR_TO_DATE(stg.DATA_TERMINO_AFASTAMENTO,'%d/%m/%Y')as DATA_TERMINO_AFASTAMENTO,
STR_TO_DATE(stg.DATA_INGRESSO_CARGOFUNCAO,'%d/%m/%Y')as DATA_INGRESSO_CARGOFUNCAO,
stg.ano,
stg.MES,
css.id,
stg.UF_EXERCICIO

  
FROM
    cadastro_servidores css
    
	inner join stg_servidores stg
	on    
	css.Id_SERVIDOR_PORTAL = stg.Id_SERVIDOR_PORTAL 
		and css.NOME = stg.NOME
		and css.MATRICULA = stg.MATRICULA
		and css.CPF = stg.CPF
     
    
order by  css.id_servidor_portal
;
commit

;
select  * from cargo_servidores;