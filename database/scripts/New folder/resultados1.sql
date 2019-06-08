SELECT * FROM vw_r_merge
limit 1
;
/*
 vr.F_NOME,
    vr.S_NOME,
    vr.S_ID,
    vr.F_ID,
    vr.SIGLA_FUNCAO,
    vr.NIVEL_FUNCAO,
    vr.FUNCAO,
    vr.PARTIDO,
    vr.UF,
    vr.status,
    vr.ANO_AF,
    vr.MES_AF,
    vr.SNAP_S_MES,
    vr.SNAP_S_ANO,
    vr.ANO_DF,
    vr.MES_DF,
    vr.DATA_ING_FUNCAO
    
    
*/
SELECT
	vr.SIGLA_FUNCAO,
  --  vr.NIVEL_FUNCAO,
  --  vr.FUNCAO,
    vr.PARTIDO,
    vr.UF,
    vr.SNAP_S_MES,
    vr.SNAP_S_ANO,
    count(vr.s_id)
FROM datastage.vw_r_merge vr
group by 
    vr.SIGLA_FUNCAO,
   -- vr.NIVEL_FUNCAO,
  --  vr.FUNCAO,
    vr.PARTIDO,
    vr.UF,
   vr.SNAP_S_MES,
    vr.SNAP_S_ANO

