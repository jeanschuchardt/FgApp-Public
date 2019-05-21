using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace TC_FGApp.Controllers
{
    public class GraficosController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public GraficosController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public IActionResult Index()
        {
            List<FuncionarioPublicos> funcionarioPublicos = new FuncionarioPublicosBO(_connectionStrings.DefaultConnection).GetAllFuncionarios();

            return View();
        }

        public IActionResult FuncoesOcupantes()
        {


            return View();
        }

        public IActionResult Mapa()
        {
            List<RegioesCargos> listaRegioesCargos = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetAllRegioesCargos();

            return View();
        }

        public IActionResult Filiados()
        {
            return View();
        }
    }
}