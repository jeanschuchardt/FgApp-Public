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
    public class AnalisesController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public AnalisesController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        [HttpGet("{ano}")]
        public JsonResult GetServidoresFiliados(int ano)
        {
            List<NumerosAnalisesDTO> listaRelacoes = new NumerosAnalisesBO(_connectionStrings.DefaultConnection).GetRelacaoPorAno(new NumerosAnalisesDTO() { Ano = ano });

            if (listaRelacoes.Count > 0)
            {
                return Json(listaRelacoes.Select(x => new { x.Ano, x.Mes, x.TotalResultados, x.TotalServidores }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetTodosResultadosAnalise()
        {
            List<NumerosAnalisesDTO> listaRelacoes = new NumerosAnalisesBO(_connectionStrings.DefaultConnection).GetAllRelacoes();

            if (listaRelacoes.Count > 0)
            {
                return Json(listaRelacoes.Select(x => new { x.Ano, x.Mes, x.TotalFiliados, x.TotalServidores, x.TotalResultados }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }
    }
}
