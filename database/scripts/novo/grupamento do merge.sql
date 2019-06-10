/*
Filtro grupado para resultado final
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

