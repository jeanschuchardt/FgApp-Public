using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FGApp.API
{
    [Route("api/[controller]/[action]")]
    public class GastosController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public GastosController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        [HttpGet("{ano}")]
        public JsonResult GetGastosTotais(int ano)
        {
            List<GastosTotaisDTO> listaGastos = new GastosTotaisBO(_connectionStrings.DefaultConnection).GetRelacaoPorAno(new GastosTotaisDTO() { Ano = ano });

            if (listaGastos.Count > 0)
            {
                return Json(listaGastos.Select(x => new { x.Mes, x.TotalRemuneracao }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetTodosGastos()
        {
            List<GastosTotaisDTO> gastosTotais = new GastosTotaisBO(_connectionStrings.DefaultConnection).GetAllGastos();

            if (gastosTotais.Count > 0)
            {
                return Json(gastosTotais.Select(x => new { x.Ano, x.Mes, x.SiglaFuncao, x.TotalRemuneracao }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }
    }
}
