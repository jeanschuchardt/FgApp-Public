INSERT INTO public.servidores(
	"Id_SERVIDOR_PORTAL", "NOME", "CPF", "MATRICULA")
	SELECT "Id_SERVIDOR_PORTAL", "NOME","CPF","MATRICULA" from servidores_stg
	
;
INSERT INTO sevidores_func(
	"SIGLA_FUNCAO", "NIVEL_FUNCAO", "FUNCAO", "UORG_EXERCICIO", "DATA_INICIO_AFASTAMENTO", "DATA_TERMINO_AFASTAMENTO", "DATA_INGRESSO_CARGOFUNCAO", "DATA_NOMEACAO_CARGOFUNCAO", "DATA_INGRESSO_ORGAO", fk_servidores)

SELECT 	a."SIGLA_FUNCAO",
		a."NIVEL_FUNCAO", 
		a."FUNCAO", 
		a."UORG_EXERCICIO",
		a."DATA_INICIO_AFASTAMENTO", 
		a."DATA_TERMINO_AFASTAMENTO", 
		a."DATA_INGRESSO_CARGOFUNCAO",
		a."DATA_NOMEACAO_CARGOFUNCAO", 
		a."DATA_INGRESSO_ORGAO", 
		b."Cod_sys_ser"
		
	FROM servidores_stg a , servidores b
	where b."NOME" = a."NOME" and 
							b."CPF" = a."CPF" and
							b."MATRICULA" = a."MATRICULA" and
							b."Id_SERVIDOR_PORTAL" = a."Id_SERVIDOR_PORTAL"
							
							
							---
							
							
							
							INSERT INTO public.servidores(
	"Id_SERVIDOR_PORTAL", "NOME", "CPF", "MATRICULA")
	SELECT "Id_SERVIDOR_PORTAL", "NOME","CPF","MATRICULA" from servidores_stg
	
;
INSERT INTO sevidores_func(
	"SIGLA_FUNCAO", "NIVEL_FUNCAO", "FUNCAO", "UORG_EXERCICIO", "DATA_INICIO_AFASTAMENTO", "DATA_TERMINO_AFASTAMENTO", "DATA_INGRESSO_CARGOFUNCAO", "DATA_NOMEACAO_CARGOFUNCAO", "DATA_INGRESSO_ORGAO", fk_servidores)

SELECT 	a."SIGLA_FUNCAO",
		a."NIVEL_FUNCAO", 
		a."FUNCAO", 
		a."UORG_EXERCICIO",
		a."DATA_INICIO_AFASTAMENTO", 
		a."DATA_TERMINO_AFASTAMENTO", 
		a."DATA_INGRESSO_CARGOFUNCAO",
		a."DATA_NOMEACAO_CARGOFUNCAO", 
		a."DATA_INGRESSO_ORGAO", 
		b."Cod_sys_ser"
		
	FROM servidores_stg a , servidores b
	where b."NOME" = a."NOME" and 
							b."CPF" = a."CPF" and
							b."MATRICULA" = a."MATRICULA" and
							b."Id_SERVIDOR_PORTAL" = a."Id_SERVIDOR_PORTAL"-- Table: public.servidores

-- DROP TABLE public.servidores;

CREATE TABLE public.servidores
(
    "Id_SERVIDOR_PORTAL" bigint,
    "NOME" text COLLATE pg_catalog."default",
    "CPF" text COLLATE pg_catalog."default",
    "MATRICULA" text COLLATE pg_catalog."default",
    "Cod_sys_ser" integer NOT NULL DEFAULT nextval('"servidores_Cod_sys_ser_seq"'::regclass),
    CONSTRAINT servidores_pkey PRIMARY KEY ("Cod_sys_ser")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public.servidores
    OWNER to postgres;