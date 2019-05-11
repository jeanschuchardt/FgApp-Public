using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseFramework.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace TC_FGApp.Controllers
{
    public class GraficosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FuncoesOcupantes()
        {
            return View();
        }

        public IActionResult Mapa()
        {
            DBContext context = HttpContext.RequestServices.GetService(typeof(DBContext)) as DBContext;

            List<RegioesCargos> listaRegioesCargos = context.GetAllRegioesCargos();
            List<FuncionarioPublicos> funcionarioPublicos = context.GetAllFuncionarios();

            return View();
        }

        public IActionResult Filiados()
        {
            return View();
        }
    }
}