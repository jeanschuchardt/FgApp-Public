using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using FGApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FGApp.Controllers
{
    public class HomeController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public HomeController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        [HttpGet]
        public IActionResult Index()
        {
            DashboardVM dashboardVM = new DashboardVM();

            List<NumerosAnalisesDTO> numerosAnalises = new NumerosAnalisesBO(_connectionStrings.DefaultConnection).GetAllRelacoes();

            dashboardVM.arrayDatasAnalise = JsonConvert.SerializeObject(numerosAnalises.Select(x => x.AnoMesFormatado));
            dashboardVM.arrayTotalResultadosAnalises = JsonConvert.SerializeObject(numerosAnalises.Select(x => x.TotalResultados));

            dashboardVM.arrayTotalResAnalises2015 = JsonConvert.SerializeObject(numerosAnalises.Where(x => x.Ano == 2015).Select(x => x.TotalResultados));
            dashboardVM.arrayTotalResAnalises2016 = JsonConvert.SerializeObject(numerosAnalises.Where(x => x.Ano == 2016).Select(x => x.TotalResultados));
            dashboardVM.arrayTotalResAnalises2017 = JsonConvert.SerializeObject(numerosAnalises.Where(x => x.Ano == 2017).Select(x => x.TotalResultados));
            dashboardVM.arrayTotalResAnalises2018 = JsonConvert.SerializeObject(numerosAnalises.Where(x => x.Ano == 2018).Select(x => x.TotalResultados));


            List<FiliadosFuncionariosDTO> filiadosFuncionariosPartidos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetTopPartidos();

            dashboardVM.arrayPartidos = JsonConvert.SerializeObject(filiadosFuncionariosPartidos.Select(x => x.Partido));
            dashboardVM.arrayNumTopPartidos = JsonConvert.SerializeObject(filiadosFuncionariosPartidos.Select(x => x.Quantidade));


            List<GastosTotaisDTO> gastosPorAno = new GastosTotaisBO(_connectionStrings.DefaultConnection).GetGastosPorAno();

            dashboardVM.arrayGastosPorAno = JsonConvert.SerializeObject(gastosPorAno.Select(x => x.TotalRemuneracao));

            return View(dashboardVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
