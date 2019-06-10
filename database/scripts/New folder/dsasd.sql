SHOW ENGINE INNODB STATUS
;
show open tables where in_use>0;
show processlist;
 show variables like 'innodb_lock_wait_timeout';
 SET GLOBAL innodb_lock_wait_timeout = 12000; 
SET  innodb_lock_wait_timeout = 12000; 
 
 
 sET binlog_format = 'STATEMENT'
 
 set innodb_buffer_pool_size 
 
 
 commit
 
 select distinct uf  from  cadastro_politico 
 