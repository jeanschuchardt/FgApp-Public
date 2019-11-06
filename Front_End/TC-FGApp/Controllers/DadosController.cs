using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
            List<FiliadosFuncionariosDTO> NumFuncionariosPorFuncao = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetNumFuncionariosPorFuncao();

            return View(NumFuncionariosPorFuncao);
        }
    }
}