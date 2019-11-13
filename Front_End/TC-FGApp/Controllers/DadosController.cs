using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace FGApp.Controllers
{
    public class DadosController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;

        public DadosController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        public IActionResult TabelaResultados()
        {
            List<NumerosAnalisesDTO> numerosAnalises = new NumerosAnalisesBO(_connectionStrings.DefaultConnection).GetAllRelacoes();

            return View(numerosAnalises);
        }

        public IActionResult TabelaServidores()
        {
            List<FiliadosFuncionariosDTO> filiadosFuncionarios = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllFiliadosFuncionarios();

            return View(filiadosFuncionarios);
        }

        public IActionResult TabelaGastos()
        {
            List<GastosTotaisDTO> gastosTotais = new GastosTotaisBO(_connectionStrings.DefaultConnection).GetAllGastos();

            return View(gastosTotais);
        }
    }
}