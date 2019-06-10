

CREATE TABLE `cadastro_politico` (
   `id` int(11) NOT NULL AUTO_INCREMENT,
   `NOME_DO_FILIADO` text,
   `NUMERO_DA_INSCRICAO` bigint(20) DEFAULT NULL,
   `SIGLA_DO_PARTIDO` text,
   `UF` text,
   `NOME_DO_MUNICIPIO` text,
   `ZONA_ELEITORAL` bigint(20) DEFAULT NULL,
   `SECAO_ELEITORAL` bigint(20) DEFAULT NULL,
   UNIQUE KEY `id` (`id`),
   UNIQUE KEY `unic` (`NUMERO_DA_INSCRICAO`,`SIGLA_DO_PARTIDO`(10),`UF`(3),`NOME_DO_MUNICIPIO`(10),`ZONA_ELEITORAL`,`SECAO_ELEITORAL`,`NOME_DO_FILIADO`(200)),
   KEY `num_cad` (`NUMERO_DA_INSCRICAO`),
   KEY `uf` (`UF`(5))
 ) ENGINE=InnoDB AUTO_INCREMENT=22931251 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
 ;
CREATE TABLE `cadastro_servidores` (
   `id` int(11) NOT NULL AUTO_INCREMENT,
   `Id_SERVIDOR_PORTAL` bigint(20) DEFAULT NULL,
   `NOME` text,
   `CPF` text,
   `MATRICULA` text,
   UNIQUE KEY `id` (`id`),
   UNIQUE KEY `serv` (`Id_SERVIDOR_PORTAL`,`NOME`(100),`CPF`(15),`MATRICULA`(10)) /*!80000 INVISIBLE */,
   KEY `id_servidor` (`Id_SERVIDOR_PORTAL`),
   KEY `nome_servidor` (`NOME`(100)),
   KEY `cpf` (`CPF`(13))
 ) ENGINE=InnoDB AUTO_INCREMENT=341892 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
 ;
CREATE TABLE `tbl_cargo_servidores` (
   `id` int(11) NOT NULL AUTO_INCREMENT,
   `SIGLA_FUNCAO` text,
   `NIVEL_FUNCAO` text,
   `FUNCAO` text,
   `UORG_EXERCICIO` text,
   `DATA_INICIO_AFASTAMENTO` date DEFAULT NULL,
   `DATA_TERMINO_AFASTAMENTO` date DEFAULT NULL,
   `DATA_INGRESSO_CARGOFUNCAO` date DEFAULT NULL,
   `FK_SERVIDOR` int(11) DEFAULT NULL,
   `UF_EXERCICIO` varchar(100) DEFAULT NULL,
   `MES` int(2) DEFAULT NULL,
   `ANO` int(4) DEFAULT NULL,
   PRIMARY KEY (`id`),
   UNIQUE KEY `cargo_unik` (`SIGLA_FUNCAO`(10),`NIVEL_FUNCAO`(10),`FUNCAO`(10),`UORG_EXERCICIO`(100),`DATA_INICIO_AFASTAMENTO`,`DATA_TERMINO_AFASTAMENTO`,`DATA_INGRESSO_CARGOFUNCAO`,`ANO`,`MES`,`FK_SERVIDOR`,`UF_EXERCICIO`(5)),
   KEY `sigla` (`SIGLA_FUNCAO`(10)),
   KEY `funcao` (`NIVEL_FUNCAO`(5)),
   KEY `fk_cas_ser` (`FK_SERVIDOR`),
   KEY `ano_mes` (`ANO`),
   KEY `mes` (`MES`),
   CONSTRAINT `fk_cadastro_ser` FOREIGN KEY (`FK_SERVIDOR`) REFERENCES `cadastro_servidores` (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=32976849 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
 ;
 
 CREATE TABLE `politico_ativo` (
   `id` int(11) NOT NULL AUTO_INCREMENT,
   `DATA_FILIACAO` date DEFAULT NULL,
   `DATA_DESFILIACAO` date DEFAULT NULL,
   `fk_cad_id` int(11) DEFAULT NULL,
   `status` varchar(200) DEFAULT NULL,
   PRIMARY KEY (`id`),
   KEY `fk_cad_id` (`fk_cad_id`),
   KEY `status` (`status`(10)) USING BTREE,
   CONSTRAINT `politico_ativo_ibfk_1` FOREIGN KEY (`fk_cad_id`) REFERENCES `cadastro_politico` (`id`)
 ) ENGINE=InnoDB AUTO_INCREMENT=5240837 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
 ;
 
 
SHOW CREATE TABLE cadastro_politico ;

SHOW CREATE TABLE cadastro_servidores;

SHOW CREATE TABLE tbl_cargo_servidores;

SHOW CREATE TABLE politico_ativo;