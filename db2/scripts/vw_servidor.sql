CREATE VIEW `servidores_data` AS
select  servc.FK_SERVIDOR
	,servc.SIGLA_FUNCAO
    ,servc.NIVEL_FUNCAO
    ,servc.FUNCAO
    ,servc.mes
    ,servc.ano
    ,serv.nome

from cargo_servidores servc
inner join cadastro_servidores serv
on serv.id = servc.fk_servidor
order by ano and mes