/* 

inseri em tabela cadastro politico 

*/

INSERT ignore INTO `datastage`.`cadastro_politico`
(
`NOME_DO_FILIADO`,
`NUMERO_DA_INSCRICAO`,
`SIGLA_DO_PARTIDO`,
`UF`,
`NOME_DO_MUNICIPIO`,
`ZONA_ELEITORAL`,
`SECAO_ELEITORAL`)

-- CREATE TABLE cadastro_politico2 AS 
 SELECT distinct `stg_afiliados`.`NOME_DO_FILIADO`,
    `stg_afiliados`.`NUMERO_DA_INSCRICAO`,
    `stg_afiliados`.`SIGLA_DO_PARTIDO`,
    `stg_afiliados`.`UF`,
    `stg_afiliados`.`NOME_DO_MUNICIPIO`,
    `stg_afiliados`.`ZONA_ELEITORAL`,
    `stg_afiliados`.`SECAO_ELEITORAL`
	-- talvez esse select possa ser orgenado ou gerado por uma view
FROM `datastage`.`stg_afiliados`
where    EXTRACT(year FROM STR_TO_DATE(`stg_afiliados`.`DATA_DA_FILIACAO`, '%d/%m/%Y')) = '2019';
commit;
INSERT ignore INTO `datastage`.`cadastro_politico`
(
`NOME_DO_FILIADO`,
`NUMERO_DA_INSCRICAO`,
`SIGLA_DO_PARTIDO`,
`UF`,
`NOME_DO_MUNICIPIO`,
`ZONA_ELEITORAL`,
`SECAO_ELEITORAL`)

-- CREATE TABLE cadastro_politico2 AS 
 SELECT distinct `stg_afiliados`.`NOME_DO_FILIADO`,
    `stg_afiliados`.`NUMERO_DA_INSCRICAO`,
    `stg_afiliados`.`SIGLA_DO_PARTIDO`,
    `stg_afiliados`.`UF`,
    `stg_afiliados`.`NOME_DO_MUNICIPIO`,
    `stg_afiliados`.`ZONA_ELEITORAL`,
    `stg_afiliados`.`SECAO_ELEITORAL`
	-- talvez esse select possa ser orgenado ou gerado por uma view
FROM `datastage`.`stg_afiliados`
where  EXTRACT(year FROM STR_TO_DATE(`stg_afiliados`.`DATA_DA_FILIACAO`, '%d/%m/%Y')) = '2018';
commit;
INSERT ignore INTO `datastage`.`cadastro_politico`
(
`NOME_DO_FILIADO`,
`NUMERO_DA_INSCRICAO`,
`SIGLA_DO_PARTIDO`,
`UF`,
`NOME_DO_MUNICIPIO`,
`ZONA_ELEITORAL`,
`SECAO_ELEITORAL`)

-- CREATE TABLE cadastro_politico2 AS 
 SELECT distinct `stg_afiliados`.`NOME_DO_FILIADO`,
    `stg_afiliados`.`NUMERO_DA_INSCRICAO`,
    `stg_afiliados`.`SIGLA_DO_PARTIDO`,
    `stg_afiliados`.`UF`,
    `stg_afiliados`.`NOME_DO_MUNICIPIO`,
    `stg_afiliados`.`ZONA_ELEITORAL`,
    `stg_afiliados`.`SECAO_ELEITORAL`
	-- talvez esse select possa ser orgenado ou gerado por uma view
FROM `datastage`.`stg_afiliados`
where  EXTRACT(year FROM STR_TO_DATE(`stg_afiliados`.`DATA_DA_FILIACAO`, '%d/%m/%Y')) = '2017';
commit;

INSERT ignore INTO `datastage`.`cadastro_politico`
(
`NOME_DO_FILIADO`,
`NUMERO_DA_INSCRICAO`,
`SIGLA_DO_PARTIDO`,
`UF`,
`NOME_DO_MUNICIPIO`,
`ZONA_ELEITORAL`,
`SECAO_ELEITORAL`)

-- CREATE TABLE cadastro_politico2 AS 
 SELECT distinct `stg_afiliados`.`NOME_DO_FILIADO`,
    `stg_afiliados`.`NUMERO_DA_INSCRICAO`,
    `stg_afiliados`.`SIGLA_DO_PARTIDO`,
    `stg_afiliados`.`UF`,
    `stg_afiliados`.`NOME_DO_MUNICIPIO`,
    `stg_afiliados`.`ZONA_ELEITORAL`,
    `stg_afiliados`.`SECAO_ELEITORAL`
	-- talvez esse select possa ser orgenado ou gerado por uma view
FROM `datastage`.`stg_afiliados`
where EXTRACT(year FROM STR_TO_DATE(`stg_afiliados`.`DATA_DA_FILIACAO`, '%d/%m/%Y')) = '2016';
commit;
INSERT ignore INTO `datastage`.`cadastro_politico`
(
`NOME_DO_FILIADO`,
`NUMERO_DA_INSCRICAO`,
`SIGLA_DO_PARTIDO`,
`UF`,
`NOME_DO_MUNICIPIO`,
`ZONA_ELEITORAL`,
`SECAO_ELEITORAL`)

-- CREATE TABLE cadastro_politico2 AS 
 SELECT distinct `stg_afiliados`.`NOME_DO_FILIADO`,
    `stg_afiliados`.`NUMERO_DA_INSCRICAO`,
    `stg_afiliados`.`SIGLA_DO_PARTIDO`,
    `stg_afiliados`.`UF`,
    `stg_afiliados`.`NOME_DO_MUNICIPIO`,
    `stg_afiliados`.`ZONA_ELEITORAL`,
    `stg_afiliados`.`SECAO_ELEITORAL`
	-- talvez esse select possa ser orgenado ou gerado por uma view
FROM `datastage`.`stg_afiliados`
where  EXTRACT(year FROM STR_TO_DATE(`stg_afiliados`.`DATA_DA_FILIACAO`, '%d/%m/%Y')) = '2015';
commit;
;

;
alter table cadastro_politico2 
add column id int not null AUTO_INCREMENT first , add primary key(id);

commit;


insert ignore into politico_ativo (DATA_FILIACAO, DATA_DESFILIACAO, fk_cad_id, status)

select * from vw_af_ativo
    /*
    -- ou
SELECT distinct
    -- stg.nome_do_filiado,
    -- stg.nome_do_filiado,
	STR_TO_DATE(stg.DATA_DA_FILIACAO, '%d/%m/%Y') as DATA_FILIACAO,
    STR_TO_DATE(stg.DATA_DA_DESFILIACAO, '%d/%m/%Y')as DATA_DA_DESFILIACAO,
    cdp.id,
    stg.SITUACAO_DO_REGISTRO
FROM
    cadastro_politico cdp
    inner join stg_afiliados stg
    on    cdp.NUMERO_DA_INSCRICAO = stg.NUMERO_DA_INSCRICAO
        AND cdp.SIGLA_DO_PARTIDO = stg.SIGLA_DO_PARTIDO
        
order by  cdp.id;

*/
    ;
      
;
