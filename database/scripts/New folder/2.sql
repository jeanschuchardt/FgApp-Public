SELECT SV.NOME AS SERVIDOR, SV.ID, X.*
FROM cadastro_servidores SV
LEFT OUTER JOIN
(SELECT  
   AF.ID,AF.NOME_DO_FILIADO AS NOME
FROM
    cadastro_politico AF
WHERE
    AF.NOME_DO_FILIADO IN (SELECT DISTINCT
            NOME
        FROM
            cadastro_servidores)) X
		ON X.NOME = SV.NOME
	 WHERE SV.NOME IS  NULL

        

;

SELECT AF.NOME_DO_FILIADO, COUNT(AF.NOME_DO_FILIADO) FROM  cadastro_politico AF
GROUP BY AF.NOME_DO_FILIADO
;

SELECT AF.* FROM  cadastro_politico AF
WHERE AF.NOME_DO_FILIADO = 'PAULO CESAR DE ALMEIDA'
; -- 17


select b.* , a.* from 

(SELECT  @n := @n + 1 temp_id_af, SV.* FROM  cadastro_politico SV,(SELECT @n := 0) m

WHERE SV.NOME_DO_FILIADO = 'JOSE CARLOS DA SILVA') b
,

(SELECT  @t := @t + 1 temp_id_s, SV.NOME FROM  cadastro_servidores SV,(SELECT @t := 0) f
	WHERE SV.NOME = 'JOSE CARLOS DA SILVA')  a
 
 where a.temp_id_s =  b.temp_id_af
;



