using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using FGApp.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FGApp.API
{
    [Route("api/[controller]/[action]")]
    public class FiliadosController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public FiliadosController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        [HttpGet("{ano}/{mes}")]
        public JsonResult GetNumFuncionariosPorFuncao(int ano, int mes)
        {
            List<FiliadosFuncionariosDTO> listaFuncionarios = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetNumFuncionariosPorFuncao(new FiliadosFuncionariosDTO() { Ano = ano, Mes = mes }); ;

            if (listaFuncionarios.Count > 0)
            {
                return Json(listaFuncionarios.Select(x => new { x.Sigla, x.Funcao, x.Quantidade }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet("{ano}")]
        public JsonResult GetDistribuicaoFuncoes(int ano)
        {
            List<FiliadosFuncionariosDTO> listaRegioesFuncoes = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(new FiliadosFuncionariosDTO() { Ano = ano });
            if (listaRegioesFuncoes.Count > 0)
            {
                return Json(DataNormalization.NormalizeDistribuicaoFuncoes(listaRegioesFuncoes));
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet("{ano}/{mes}")]
        public JsonResult GetServidoresPorPartido(int ano, int mes)
        {
            List<FiliadosFuncionariosDTO> listaPartidoServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new FiliadosFuncionariosDTO() { Ano = ano, Mes = mes });

            if (listaPartidoServidores.Count > 0)
            {
                return Json(listaPartidoServidores.Select(x => new { x.Partido, x.Quantidade }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet("{estado}/{siglaFuncao}")]
        public JsonResult GetEvolucaoCargos(string estado, string siglaFuncao)
        {
            List<FiliadosFuncionariosDTO> listaPartidoServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetServidoresPorAno(new FiliadosFuncionariosDTO() { UF = estado, Sigla = siglaFuncao });

            if (listaPartidoServidores.Count > 0)
            {
                return Json(listaPartidoServidores.Select(x => new { x.Ano, x.Sigla, x.Quantidade }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetTodosServidores()
        {
            List<FiliadosFuncionariosDTO> filiadosFuncionarios = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllFiliadosFuncionarios();

            if (filiadosFuncionarios.Count > 0)
            {
                return Json(filiadosFuncionarios.Select(x => new { x.Sigla, x.Funcao, x.Partido, x.UF, x.Ano, x.Mes, x.Quantidade }).ToArray());
            }
            else
            {
                return Json(null);
            }
        }
    }
}
