select * from resultados_politicos
LIMIT 10

;
select * from resultado_servidores
where ano = '2017'
limit 100;

select a.*, b.* from resultado_servidores a
inner join resultados_politicos b
on a.nome = b.nome_do_filiado
where a.ano = '2017' and 
b.year >= 2017 and
a.nome is not null
limit 10

-- CREATE TABLE new_tbl [AS] SELECT * FROM orig_tbl;

;
drop table test_result_politicos;
drop table test_result_servidores;

CREATE TABLE test_result_politicos AS select * from resultados_politicos;
CREATE TABLE test_result_servidores ASCREATE TABLE test_result_servidores AS select * from resultado_servidores;


select * from test_result_politicos
limit 10;


select * from test_result_servidores
where ano = 2017
limit 10;

select a.*, b.*
from test_result_politicos a
inner join test_result_servidores b
on b.nome = a.nome_do_filiado
and b.ano => a.ano and b.mes => a.mes
where a.ano = 2017
and b.ano = 2017
a.nome is not null
limit 10
;


select a.*, b.*
 from test_result_politicos a
 inner join test_result_servidores b
 on b.nome = a.nome_do_filiado
 and b.ano >= a.ano_af  
 and b.mes >= a.mes_af
 and (
 (b.ano < a.ano_df) or
 (b.ano = a.ano_df and b.mes <= a.mes_df)
 )
 where 
 b.ano = 2017
-- and  a.nome_do_filiado is not null
-- and b.nome is not null
 order by b.mes
 -- limit 10	;
 
 commit