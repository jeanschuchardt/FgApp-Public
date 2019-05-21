USE fgappdb;

SELECT * FROM regioescargos;

SELECT * FROM funcionariopublicos;

INSERT INTO regioescargos 
	(Estado, Cidade, DataCargos, Partido, TipoCargos, TotalCargos)
VALUES
	('RS', 'Porto Alegre', '2010-01-01', 'PMDB', 'CC', 35231),
    ('RS', 'Porto Alegre', '2010-01-01', 'PT', 'CC', 24532),
	('RS', 'Porto Alegre', '2010-01-01', 'PP', 'CC', 10324),
	('RS', 'Porto Alegre', '2010-01-01', 'PSDB', 'CC', 26345),
    ('RS', 'Porto Alegre', '2010-01-01', 'PDT', 'CC', 3435),
    ('RS', 'Porto Alegre', '2010-01-01', 'PTB', 'CC', 2084),
    ('RS', 'Porto Alegre', '2010-01-01', 'DEM', 'CC', 1834),
    ('RS', 'Porto Alegre', '2010-01-01', 'PR', 'CC', 562),
    ('RS', 'Porto Alegre', '2010-01-01', 'PSB', 'CC', 974),
    ('RS', 'Porto Alegre', '2010-01-01', 'PPS', 'CC', 123),
    ('RS', 'Porto Alegre', '2010-01-01', 'PSC', 'CC', 120),
    ('RS', 'Porto Alegre', '2010-01-01', 'PRB', 'CC', 145),
    ('RS', 'Porto Alegre', '2010-01-01', 'PCdoB', 'CC', 345),
    ('RS', 'Porto Alegre', '2010-01-01', 'PV', 'CC', 532),
    ('RS', 'Porto Alegre', '2010-01-01', 'PSD', 'CC', 90),
    ('RS', 'Porto Alegre', '2010-01-01', 'PRP', 'CC', 20),
    ('RS', 'Porto Alegre', '2010-01-01', 'PSL', 'CC', 80),
    ('RS', 'Porto Alegre', '2010-01-01', 'PMN', 'CC', 0),
    ('RS', 'Porto Alegre', '2010-01-01', 'PHS', 'CC', 0),
    ('RS', 'Porto Alegre', '2010-01-01', 'SD', 'CC', 0),
    ('RS', 'Porto Alegre', '2010-01-01', 'PTC', 'CC', 20),
    ('RS', 'Porto Alegre', '2010-01-01', 'AVANTE', 'CC', 10),
    ('RS', 'Porto Alegre', '2010-01-01', 'DC', 'CC', 5),
    ('RS', 'Porto Alegre', '2010-01-01', 'PODE', 'CC', 2),
    ('RS', 'Porto Alegre', '2010-01-01', 'PSOL', 'CC', 634),
    ('RS', 'Porto Alegre', '2010-01-01', 'PRTB', 'CC', 32),
    ('RS', 'Porto Alegre', '2010-01-01', 'PROS', 'CC', 64),
    ('RS', 'Porto Alegre', '2010-01-01', 'PATRI', 'CC', 52),
    ('RS', 'Porto Alegre', '2010-01-01', 'PMB', 'CC', 12),
    ('RS', 'Porto Alegre', '2010-01-01', 'PPL', 'CC', 19),
    ('RS', 'Porto Alegre', '2010-01-01', 'NOVO', 'CC', 10),
    ('RS', 'Porto Alegre', '2010-01-01', 'REDE', 'CC', 29),
    ('RS', 'Porto Alegre', '2010-01-01', 'PSTU', 'CC', 74),
    ('RS', 'Porto Alegre', '2010-01-01', 'PCB', 'CC', 53),
    ('RS', 'Porto Alegre', '2010-01-01', 'PCO', 'CC', 46);
    
INSERT INTO regioescargos 
	(Estado, Cidade, DataCargos, Partido, TipoCargos, TotalCargos)
VALUES
	('RS', 'Porto Alegre', '2018-01-01', 'PMDB', 'CC', 3231),
    ('RS', 'Porto Alegre', '2018-01-01', 'PT', 'CC', 2432),
	('RS', 'Porto Alegre', '2018-01-01', 'PP', 'CC', 1324),
	('RS', 'Porto Alegre', '2018-01-01', 'PSDB', 'CC', 6345),
    ('RS', 'Porto Alegre', '2018-01-01', 'PDT', 'CC', 435),
    ('RS', 'Porto Alegre', '2018-01-01', 'PTB', 'CC', 084),
    ('RS', 'Porto Alegre', '2018-01-01', 'DEM', 'CC', 834),
    ('RS', 'Porto Alegre', '2018-01-01', 'PR', 'CC', 62),
    ('RS', 'Porto Alegre', '2018-01-01', 'PSB', 'CC', 94),
    ('RS', 'Porto Alegre', '2018-01-01', 'PPS', 'CC', 923),
    ('RS', 'Porto Alegre', '2018-01-01', 'PSC', 'CC', 1920),
    ('RS', 'Porto Alegre', '2018-01-01', 'PRB', 'CC', 1425),
    ('RS', 'Porto Alegre', '2018-01-01', 'PCdoB', 'CC', 35),
    ('RS', 'Porto Alegre', '2018-01-01', 'PV', 'CC', 53),
    ('RS', 'Porto Alegre', '2018-01-01', 'PSD', 'CC', 0),
    ('RS', 'Porto Alegre', '2018-01-01', 'PRP', 'CC', 240),
    ('RS', 'Porto Alegre', '2018-01-01', 'PSL', 'CC', 808),
    ('RS', 'Porto Alegre', '2018-01-01', 'PMN', 'CC', 2),
    ('RS', 'Porto Alegre', '2018-01-01', 'PHS', 'CC', 3),
    ('RS', 'Porto Alegre', '2018-01-01', 'SD', 'CC', 2),
    ('RS', 'Porto Alegre', '2018-01-01', 'PTC', 'CC', 20),
    ('RS', 'Porto Alegre', '2018-01-01', 'AVANTE', 'CC', 10),
    ('RS', 'Porto Alegre', '2018-01-01', 'DC', 'CC', 5),
    ('RS', 'Porto Alegre', '2018-01-01', 'PODE', 'CC', 2),
    ('RS', 'Porto Alegre', '2018-01-01', 'PSOL', 'CC', 64),
    ('RS', 'Porto Alegre', '2018-01-01', 'PRTB', 'CC', 332),
    ('RS', 'Porto Alegre', '2018-01-01', 'PROS', 'CC', 61),
    ('RS', 'Porto Alegre', '2018-01-01', 'PATRI', 'CC', 62),
    ('RS', 'Porto Alegre', '2018-01-01', 'PMB', 'CC', 12),
    ('RS', 'Porto Alegre', '2018-01-01', 'PPL', 'CC', 19),
    ('RS', 'Porto Alegre', '2018-01-01', 'NOVO', 'CC', 10),
    ('RS', 'Porto Alegre', '2018-01-01', 'REDE', 'CC', 293),
    ('RS', 'Porto Alegre', '2018-01-01', 'PSTU', 'CC', 54),
    ('RS', 'Porto Alegre', '2018-01-01', 'PCB', 'CC', 52),
    ('RS', 'Porto Alegre', '2018-01-01', 'PCO', 'CC', 41);
    
INSERT INTO regioescargos 
	(Estado, Cidade, DataCargos, Partido, TipoCargos, TotalCargos)
VALUES
	('RS', 'Porto Alegre', '2001-01-01', 'PMDB', 'CC', 5231),
    ('RS', 'Porto Alegre', '2001-01-01', 'PT', 'CC', 2432),
	('RS', 'Porto Alegre', '2001-01-01', 'PP', 'CC', 1024),
	('RS', 'Porto Alegre', '2001-01-01', 'PSDB', 'CC', 6345),
    ('RS', 'Porto Alegre', '2001-01-01', 'PDT', 'CC', 335),
    ('RS', 'Porto Alegre', '2001-01-01', 'PTB', 'CC', 284),
    ('RS', 'Porto Alegre', '2001-01-01', 'DEM', 'CC', 134),
    ('RS', 'Porto Alegre', '2001-01-01', 'PR', 'CC', 56),
    ('RS', 'Porto Alegre', '2001-01-01', 'PSB', 'CC', 94),
    ('RS', 'Porto Alegre', '2001-01-01', 'PPS', 'CC', 123),
    ('RS', 'Porto Alegre', '2001-01-01', 'PSC', 'CC', 10),
    ('RS', 'Porto Alegre', '2001-01-01', 'PRB', 'CC', 145),
    ('RS', 'Porto Alegre', '2001-01-01', 'PCdoB', 'CC', 345),
    ('RS', 'Porto Alegre', '2001-01-01', 'PV', 'CC', 53),
    ('RS', 'Porto Alegre', '2001-01-01', 'PSD', 'CC', 90),
    ('RS', 'Porto Alegre', '2001-01-01', 'PRP', 'CC', 20),
    ('RS', 'Porto Alegre', '2001-01-01', 'PSL', 'CC', 8),
    ('RS', 'Porto Alegre', '2001-01-01', 'PMN', 'CC', 0),
    ('RS', 'Porto Alegre', '2001-01-01', 'PHS', 'CC', 54),
    ('RS', 'Porto Alegre', '2001-01-01', 'SD', 'CC', 0),
    ('RS', 'Porto Alegre', '2001-01-01', 'PTC', 'CC', 203),
    ('RS', 'Porto Alegre', '2001-01-01', 'AVANTE', 'CC', 10),
    ('RS', 'Porto Alegre', '2001-01-01', 'DC', 'CC', 53),
    ('RS', 'Porto Alegre', '2001-01-01', 'PODE', 'CC', 52),
    ('RS', 'Porto Alegre', '2001-01-01', 'PSOL', 'CC', 34),
    ('RS', 'Porto Alegre', '2001-01-01', 'PRTB', 'CC', 632),
    ('RS', 'Porto Alegre', '2001-01-01', 'PROS', 'CC', 644),
    ('RS', 'Porto Alegre', '2001-01-01', 'PATRI', 'CC', 52),
    ('RS', 'Porto Alegre', '2001-01-01', 'PMB', 'CC', 12),
    ('RS', 'Porto Alegre', '2001-01-01', 'PPL', 'CC', 19),
    ('RS', 'Porto Alegre', '2001-01-01', 'NOVO', 'CC', 10),
    ('RS', 'Porto Alegre', '2001-01-01', 'REDE', 'CC', 9),
    ('RS', 'Porto Alegre', '2001-01-01', 'PSTU', 'CC', 774),
    ('RS', 'Porto Alegre', '2001-01-01', 'PCB', 'CC', 563),
    ('RS', 'Porto Alegre', '2001-01-01', 'PCO', 'CC', 41);
    
INSERT INTO regioescargos 
	(Estado, Cidade, DataCargos, Partido, TipoCargos, TotalCargos)
VALUES
	('SP', 'São Paulo', '2010-01-01', 'PMDB', 'CC', 55231),
    ('SP', 'São Paulo', '2010-01-01', 'PT', 'CC', 34532),
	('SP', 'São Paulo', '2010-01-01', 'PP', 'CC', 40324),
	('SP', 'São Paulo', '2010-01-01', 'PSDB', 'CC', 6345),
    ('SP', 'São Paulo', '2010-01-01', 'PDT', 'CC', 5435),
    ('SP', 'São Paulo', '2010-01-01', 'PTB', 'CC', 2084),
    ('SP', 'São Paulo', '2010-01-01', 'DEM', 'CC', 834),
    ('SP', 'São Paulo', '2010-01-01', 'PR', 'CC', 1562),
    ('SP', 'São Paulo', '2010-01-01', 'PSB', 'CC', 924),
    ('SP', 'São Paulo', '2010-01-01', 'PPS', 'CC', 223),
    ('SP', 'São Paulo', '2010-01-01', 'PSC', 'CC', 120),
    ('SP', 'São Paulo', '2010-01-01', 'PRB', 'CC', 345),
    ('SP', 'São Paulo', '2010-01-01', 'PCdoB', 'CC', 45),
    ('SP', 'São Paulo', '2010-01-01', 'PV', 'CC', 32),
    ('SP', 'São Paulo', '2010-01-01', 'PSD', 'CC', 90),
    ('SP', 'São Paulo', '2010-01-01', 'PRP', 'CC', 0),
    ('SP', 'São Paulo', '2010-01-01', 'PSL', 'CC', 8),
    ('SP', 'São Paulo', '2010-01-01', 'PMN', 'CC', 0),
    ('SP', 'São Paulo', '2010-01-01', 'PHS', 'CC', 2),
    ('SP', 'São Paulo', '2010-01-01', 'SD', 'CC', 5),
    ('SP', 'São Paulo', '2010-01-01', 'PTC', 'CC', 0),
    ('SP', 'São Paulo', '2010-01-01', 'AVANTE', 'CC', 10),
    ('SP', 'São Paulo', '2010-01-01', 'DC', 'CC', 5),
    ('SP', 'São Paulo', '2010-01-01', 'PODE', 'CC', 2),
    ('SP', 'São Paulo', '2010-01-01', 'PSOL', 'CC', 64),
    ('SP', 'São Paulo', '2010-01-01', 'PRTB', 'CC', 342),
    ('SP', 'São Paulo', '2010-01-01', 'PROS', 'CC', 643),
    ('SP', 'São Paulo', '2010-01-01', 'PATRI', 'CC', 52),
    ('SP', 'São Paulo', '2010-01-01', 'PMB', 'CC', 12),
    ('SP', 'São Paulo', '2010-01-01', 'PPL', 'CC', 19),
    ('SP', 'São Paulo', '2010-01-01', 'NOVO', 'CC', 10),
    ('SP', 'São Paulo', '2010-01-01', 'REDE', 'CC', 29),
    ('SP', 'São Paulo', '2010-01-01', 'PSTU', 'CC', 74),
    ('SP', 'São Paulo', '2010-01-01', 'PCB', 'CC', 53),
    ('SP', 'São Paulo', '2010-01-01', 'PCO', 'CC', 46);
    
    
INSERT INTO regioescargos 
	(Estado, Cidade, DataCargos, Partido, TipoCargos, TotalCargos)
VALUES
	('SP', 'São Paulo', '2018-01-01', 'PMDB', 'CC', 55231),
    ('SP', 'São Paulo', '2018-01-01', 'PT', 'CC', 34532),
	('SP', 'São Paulo', '2018-01-01', 'PP', 'CC', 40324),
	('SP', 'São Paulo', '2018-01-01', 'PSDB', 'CC', 6345),
    ('SP', 'São Paulo', '2018-01-01', 'PDT', 'CC', 5435),
    ('SP', 'São Paulo', '2018-01-01', 'PTB', 'CC', 2084),
    ('SP', 'São Paulo', '2018-01-01', 'DEM', 'CC', 834),
    ('SP', 'São Paulo', '2018-01-01', 'PR', 'CC', 1562),
    ('SP', 'São Paulo', '2018-01-01', 'PSB', 'CC', 924),
    ('SP', 'São Paulo', '2018-01-01', 'PPS', 'CC', 223),
    ('SP', 'São Paulo', '2018-01-01', 'PSC', 'CC', 120),
    ('SP', 'São Paulo', '2018-01-01', 'PRB', 'CC', 345),
    ('SP', 'São Paulo', '2018-01-01', 'PCdoB', 'CC', 45),
    ('SP', 'São Paulo', '2018-01-01', 'PV', 'CC', 32),
    ('SP', 'São Paulo', '2018-01-01', 'PSD', 'CC', 90),
    ('SP', 'São Paulo', '2018-01-01', 'PRP', 'CC', 0),
    ('SP', 'São Paulo', '2018-01-01', 'PSL', 'CC', 8),
    ('SP', 'São Paulo', '2018-01-01', 'PMN', 'CC', 0),
    ('SP', 'São Paulo', '2018-01-01', 'PHS', 'CC', 2),
    ('SP', 'São Paulo', '2018-01-01', 'SD', 'CC', 5),
    ('SP', 'São Paulo', '2018-01-01', 'PTC', 'CC', 0),
    ('SP', 'São Paulo', '2018-01-01', 'AVANTE', 'CC', 10),
    ('SP', 'São Paulo', '2018-01-01', 'DC', 'CC', 5),
    ('SP', 'São Paulo', '2018-01-01', 'PODE', 'CC', 2),
    ('SP', 'São Paulo', '2018-01-01', 'PSOL', 'CC', 64),
    ('SP', 'São Paulo', '2018-01-01', 'PRTB', 'CC', 342),
    ('SP', 'São Paulo', '2018-01-01', 'PROS', 'CC', 643),
    ('SP', 'São Paulo', '2018-01-01', 'PATRI', 'CC', 52),
    ('SP', 'São Paulo', '2018-01-01', 'PMB', 'CC', 12),
    ('SP', 'São Paulo', '2018-01-01', 'PPL', 'CC', 19),
    ('SP', 'São Paulo', '2018-01-01', 'NOVO', 'CC', 10),
    ('SP', 'São Paulo', '2018-01-01', 'REDE', 'CC', 29),
    ('SP', 'São Paulo', '2018-01-01', 'PSTU', 'CC', 74),
    ('SP', 'São Paulo', '2018-01-01', 'PCB', 'CC', 53),
    ('SP', 'São Paulo', '2018-01-01', 'PCO', 'CC', 46);
    







INSERT INTO funcionariopublicos 
	(Nome, FuncaoAtual, FuncaoAnterior, DataTroca)
VALUES
	('RS', 'Porto Alegre', '2010-01-01'),
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
	