-- select em tabelas

SELECT DISTINCT
    SIGLA_DO_PARTIDO, UF
FROM
    stg_afiliados;

SELECT 
    *
FROM
    stg_afiliados;

SELECT DISTINCT
    `stg_afiliados`.`NOME_DO_FILIADO`,
    `stg_afiliados`.`NUMERO_DA_INSCRICAO`,
    `stg_afiliados`.`SIGLA_DO_PARTIDO`,
    `stg_afiliados`.`UF`,
    `stg_afiliados`.`NOME_DO_MUNICIPIO`,
    `stg_afiliados`.`ZONA_ELEITORAL`,
    `stg_afiliados`.`SECAO_ELEITORAL`
FROM
    `datastage`.`stg_afiliados`
ORDER BY 
	`stg_afiliados`.`NOME_DO_FILIADO`,
	`stg_afiliados`.`NUMERO_DA_INSCRICAO`,
	`stg_afiliados`.`SIGLA_DO_PARTIDO`,
	`stg_afiliados`.`UF`,
	`stg_afiliados`.`NOME_DO_MUNICIPIO`,
	`stg_afiliados`.`ZONA_ELEITORAL`,
	`stg_afiliados`.`SECAO_ELEITORAL`

;
commit;

select * from cas_poli
;
select count(*) from cadastro_politico
;

SELECT distinct
    -- stg.nome_do_filiado,
      
    stg.DATA_DA_FILIACAO,
    stg.DATA_DA_DESFILIACAO,
 -- stg.nome_do_filiado,
	STR_TO_DATE(stg.DATA_DA_FILIACAO, '%d/%m/%Y'),
    STR_TO_DATE(stg.DATA_DA_DESFILIACAO, '%d/%m/%Y')
    
    
FROM
    
     stg_afiliados stg
    limit 10
; 
select distinct status from politico_ativo ;

select 'REGULAR',count(status) from politico_ativo where status='REGULAR'
union
select 'CANCELADO',count(status) from politico_ativo where status='CANCELADO'
union
select 'DESFILIADO', count(status) from politico_ativo where status='DESFILIADO'
union
select 'SUB JUDICE',count(status) from politico_ativo where status='SUB JUDICE'
;
select * from politico_ativo  order by fk_cad_id;

select max(fk_cad_id) from politico_ativo
;
select count(*) from cadastro_politico;
select count(*) from politico_ativo;

select  fk_cad_id,status, data_filiacao,count(*) as duplicates
from politico_ativo
group by fk_cad_id,status, data_filiacao 
having count(*) >1
;

select max(DATA_FILIACAO) from politico_ativo 
where fk_cad_id  = 22
group by fk_cad_id
;
select a.*, b.* from 
politico_ativo a
inner join politico_ativo b
on a.fk_cad_id =  b.fk_cad_id
where a.DATA_FILIACAO > b.DATA_FILIACAO
;
select a.*, b.* from 
politico_ativo a
inner join cadastro_politico b
on a.fk_cad_id =  b.id
;





/*
se count(fk_cad_id) > 1
	pega maior data de filiacao e status 


*/


;
select min(data_filiacao) from politico_ativo ;

select id, count(fk_cad_id) from politico_ativo  group by id , fk_cad_id
order by count(fk_cad_id) desc

;
select * from politico_ativo 
where data_filiacao = '0001-07-14'
;

select * from politico_ativo 
where data_filiacao < DATE_SUB(CURDATE(), INTERVAL 100 YEAR);
;

;
select count(*) from politico_ativo 
where data_filiacao < DATE_SUB(CURDATE(), INTERVAL 80 YEAR);
;

;
select * from politico_ativo 
where data_filiacao < '1900-12-31'
;

--  dado inconsistente 
select * from politico_ativo 
where data_filiacao < '1900-01-01'
and status = 'cancelado' 
and data_desfiliacao is null
;
select * from politico_ativo 
where data_filiacao < '1900-01-01'

;
-- grupo que deve ser considerado cancelado 
select *, date_add(data_filiacao, interval 70 year) as new_data from politico_ativo 
where data_filiacao < DATE_SUB(CURDATE(), INTERVAL 80 YEAR)
and  data_filiacao > '1900-01-01'
and data_desfiliacao is null
and status <> 'REGULAR'
/*
a ideia para corrigir isso é pegar a data de de filiação e adicionar 70 anos que é a idade normal quem que as pessoas podem parar de votar 
logo tbm diminuir seu convivio no meio politico

*/
;
select * from politico_ativo 
where 
data_desfiliacao is null
and status <> 'REGULAR'


;
SELECT DATE_SUB(CURDATE(), INTERVAL 70 YEAR);