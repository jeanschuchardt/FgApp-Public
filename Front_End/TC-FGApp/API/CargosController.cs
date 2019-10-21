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
    public class CargosController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public CargosController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{ano}")]
        public JsonResult GetServidoresPartidos(int ano)
        {
            List<RegioesCargos> listaPartidoServidores = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new RegioesCargos() { DataCargos = new DateTime(ano, 1, 1) });

            if (listaPartidoServidores.Count > 0)
            {
                return Json(listaPartidoServidores.Select(x => new { x.Partido, x.TotalCargos }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet("{ano}")]
        public JsonResult GetDistribuicaoFuncoes(int ano)
        {
            List<RegioesCargos> listaPartidoServidores = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(new RegioesCargos() { DataCargos = new DateTime(ano, 1, 1) });

            if (listaPartidoServidores.Count > 0)
            {
                return Json(listaPartidoServidores.Select(x => new { x.Estado, x.TotalCargos }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        
        [HttpGet("{estado}/{tipoCargo}")]
        public JsonResult GetServidoresPorAno(string estado, string tipoCargo)
        {
            List<RegioesCargos> listaServidoresPorAno = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetServidoresPorAno(new RegioesCargos() { Estado = estado, TipoCargos = tipoCargo});

            if (listaServidoresPorAno.Count > 0)
            {
                return Json(listaServidoresPorAno.Select(x => new { x.DataCargos.Year, x.TipoCargos, x.TotalCargos}).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetAllRegioesCargos()
        {
            List<RegioesCargos> listaRegioesCargos = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetAllRegioesCargos();

            if (listaRegioesCargos.Count > 0)
            {
                return Json(listaRegioesCargos.Select(x => new { x.Estado, x.Cidade, x.DataCargos.Date, x.Partido, x.TipoCargos, x.TotalCargos }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }
    }
}
