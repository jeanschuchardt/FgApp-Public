
select distinct a.*, b.*
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
 -- and b.nome is null
 order by b.mes
  limit 10	;
 
 
 
 