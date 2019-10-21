using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FGApp.API
{
    [Route("api/[controller]/[action]")]
    public class FuncionariosController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public FuncionariosController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        [HttpGet]
        public JsonResult GetAllFuncionarios(int ano)
        {
            List<FuncionarioPublicos> listaFuncionarios = new FuncionarioPublicosBO(_connectionStrings.DefaultConnection).GetAllFuncionarios();

            if (listaFuncionarios.Count > 0)
            {
                return Json(listaFuncionarios.Select(x => new { x.Nome, x.FuncaoAtual, x.FuncaoAnterior, x.DataTroca }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetFuncoesxOcupantes(int ano)
        {
            List<FuncoesOcupantesDM> listaFuncoesOcupantes = new FuncionarioPublicosBO(_connectionStrings.DefaultConnection).GetFuncoesxOcupantes();

            if (listaFuncoesOcupantes.Count > 0)
            {
                return Json(listaFuncoesOcupantes.Select(x => new { x.FuncaoAtual, x.NumOcupantes}).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

    }
}
