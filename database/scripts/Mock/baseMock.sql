USE fgappdb;

CREATE TABLE IF NOT EXISTS RegioesCargos (
	ID INT NOT NULL AUTO_INCREMENT
    ,Estado VARCHAR(2) NOT NULL
	,Cidade VARCHAR(100) NULL
	,DataCargos DATETIME
	,Partido VARCHAR(20) NOT NULL
	,TipoCargos VARCHAR(50) NULL
	,TotalCargos int NULL
    ,PRIMARY KEY (ID)
);


CREATE TABLE IF NOT EXISTS FuncionarioPublicos (
	ID INT NOT NULL AUTO_INCREMENT
    ,Nome VARCHAR(100) NOT NULL
	,FuncaoAtual VARCHAR(100) NULL
	,FuncaoAnterior VARCHAR(100) NULL
	,DataTroca DATETIME NULL
    ,PRIMARY KEY (ID)
);