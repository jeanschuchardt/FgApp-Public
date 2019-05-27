using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using FGApp.Models;
using FGApp.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<FuncoesOcupantesDM> listaFuncoesOcupantes = new FuncionarioPublicosBO(_connectionStrings.DefaultConnection).GetFuncoesxOcupantes();

            return View(listaFuncoesOcupantes);
        }

        public IActionResult DistribuicaoFuncoes()
        {
            DistribuicaoFuncoesVM distribuicaoFuncoesVM = new DistribuicaoFuncoesVM();
            distribuicaoFuncoesVM.regioesCargos = new RegioesCargos() { DataCargos = new DateTime(2010, 1, 1) };

            List<RegioesCargos> listaRegioesCargos = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(distribuicaoFuncoesVM.regioesCargos);

            distribuicaoFuncoesVM.arrayDados = DataNormalization.NormalizeDistribuicaoFuncoes(listaRegioesCargos);

            return View(distribuicaoFuncoesVM);
        }

        [HttpPost]
        public IActionResult DistribuicaoFuncoes(DistribuicaoFuncoesVM distribuicaoFuncoesVM)
        {
            List<RegioesCargos> listaRegioesCargos = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(distribuicaoFuncoesVM.regioesCargos);

            distribuicaoFuncoesVM.arrayDados = DataNormalization.NormalizeDistribuicaoFuncoes(listaRegioesCargos);

            return View(distribuicaoFuncoesVM);
        }

        public IActionResult Filiados()
        {
            return View();
        }
    }
}