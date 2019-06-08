select cv.* from cadastro_servidores cv
limit 10;

select distinct cs.uf_exercicio from tbl_cargo_servidores cs
limit 10
;

;

select distinct id_servidor_portal from cadastro_servidores;
;

select 
	cads.id,
    cads.nome AS NOME_S, 
    cs.SIGLA_FUNCAO AS SIGLA,
    cs.NIVEL_FUNCAO,
    cs.FUNCAO,
    cs.DATA_INGRESSO_CARGOFUNCAO AS DATA_ING_FUNCAO, -- acho que nao precisa
    cs.mes as MES_SERV_EX,
    cs.ano AS ANO_SER_EX

    
from cadastro_servidores cads
join tbl_cargo_servidores cs
on cads.id = cs.fk_servidor

where cs.ano >= 2015
order by cads.id, cs.ano, cs.mes




