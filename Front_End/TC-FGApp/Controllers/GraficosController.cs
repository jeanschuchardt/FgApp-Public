using DataBaseFramework.BO;
using DataBaseFramework.Context;
using DataBaseFramework.DataModel;
using FGApp.Models;
using FGApp.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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

        [HttpGet]
        public IActionResult DistribuicaoFuncoes()
        {
            DistribuicaoFuncoesVM distribuicaoFuncoesVM = new DistribuicaoFuncoesVM();

            List<int> listaAnos = new List<int>();
            listaAnos.Add(2001);
            listaAnos.Add(2010);
            listaAnos.Add(2018);

            distribuicaoFuncoesVM.selecaoAno = new SelectList(listaAnos);
            distribuicaoFuncoesVM.anoSelecionado = 2010;

            List<RegioesCargos> listaRegioesCargos = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(new RegioesCargos() { DataCargos = new DateTime(2010, 1, 1) });

            distribuicaoFuncoesVM.arrayDados = DataNormalization.NormalizeDistribuicaoFuncoes(listaRegioesCargos);

            return View(distribuicaoFuncoesVM);
        }

        [HttpPost]
        public IActionResult DistribuicaoFuncoes(DistribuicaoFuncoesVM distribuicaoFuncoesVM)
        {
            List<int> listaAnos = new List<int>();
            listaAnos.Add(2001);
            listaAnos.Add(2010);
            listaAnos.Add(2018);
            distribuicaoFuncoesVM.selecaoAno = new SelectList(listaAnos);

            List<RegioesCargos> listaRegioesCargos = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(new RegioesCargos() { DataCargos = new DateTime(distribuicaoFuncoesVM.anoSelecionado, 1, 1) });

            distribuicaoFuncoesVM.arrayDados = DataNormalization.NormalizeDistribuicaoFuncoes(listaRegioesCargos);

            return View(distribuicaoFuncoesVM);
        }

        [HttpGet]
        public IActionResult PartidosServidores()
        {
            PartidosServidoresVM partidosServidoresVM = new PartidosServidoresVM();

            List<int> listaAnos = new List<int>();
            listaAnos.Add(2001);
            listaAnos.Add(2010);
            listaAnos.Add(2018);

            partidosServidoresVM.selecaoAno = new SelectList(listaAnos);
            partidosServidoresVM.anoSelecionado = 2010;

            List<RegioesCargos> listaPartidoServidores = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new RegioesCargos() { DataCargos = new DateTime(partidosServidoresVM.anoSelecionado, 1, 1) });

            partidosServidoresVM.arrayPartidos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Partido).ToArray());
            partidosServidoresVM.arrayTotalServidores = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.TotalCargos).ToArray());
            partidosServidoresVM.arrayCores = Helper.ListaCores(listaPartidoServidores.Count());

            return View(partidosServidoresVM);
        }

        [HttpPost]
        public IActionResult PartidosServidores(PartidosServidoresVM partidosServidoresVM)
        {
            List<int> listaAnos = new List<int>();
            listaAnos.Add(2001);
            listaAnos.Add(2010);
            listaAnos.Add(2018);
            partidosServidoresVM.selecaoAno = new SelectList(listaAnos);

            List<RegioesCargos> listaPartidoServidores = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new RegioesCargos() { DataCargos = new DateTime(partidosServidoresVM.anoSelecionado, 1, 1) });

            partidosServidoresVM.arrayPartidos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Partido));
            partidosServidoresVM.arrayTotalServidores = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.TotalCargos).ToArray());
            partidosServidoresVM.arrayCores = Helper.ListaCores(listaPartidoServidores.Count());

            return View(partidosServidoresVM);
        }

        [HttpGet]
        public IActionResult EvolucaoCargos()
        {
            EvolucaoCargosVM evolucaoCargosVM = new EvolucaoCargosVM();

            List<string> listaEstados = new List<string>();
            listaEstados.Add("RS");
            listaEstados.Add("SP");
            listaEstados.Add("SC");

            evolucaoCargosVM.listaEstados = new SelectList(listaEstados);
            evolucaoCargosVM.estadoSelecionado = "RS";

            List<string> listaCargos = new List<string>();
            listaCargos.Add("CC");
            listaCargos.Add("CP");

            evolucaoCargosVM.listaCargos = new SelectList(listaCargos);
            evolucaoCargosVM.cargoSelecionado = "CC";

            List<RegioesCargos> listaPartidoServidores = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetServidoresPorAno(new RegioesCargos() { Estado = evolucaoCargosVM.estadoSelecionado, TipoCargos = evolucaoCargosVM.cargoSelecionado });

            evolucaoCargosVM.arrayDataCargos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.DataCargos.Year));
            evolucaoCargosVM.arrayTotalServidores = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.TotalCargos));

            return View(evolucaoCargosVM);
        }

        [HttpPost]
        public IActionResult EvolucaoCargos(EvolucaoCargosVM evolucaoCargosVM)
        {
            List<string> listaEstados = new List<string>();
            listaEstados.Add("RS");
            listaEstados.Add("SP");
            listaEstados.Add("SC");
            evolucaoCargosVM.listaEstados = new SelectList(listaEstados);

            List<string> listaCargos = new List<string>();
            listaCargos.Add("CC");
            listaCargos.Add("CP");
            evolucaoCargosVM.listaCargos = new SelectList(listaCargos);

            List<RegioesCargos> listaPartidoServidores = new RegioesCargosBO(_connectionStrings.DefaultConnection).GetServidoresPorAno(new RegioesCargos() { Estado = evolucaoCargosVM.estadoSelecionado, TipoCargos = evolucaoCargosVM.cargoSelecionado });

            evolucaoCargosVM.arrayDataCargos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.DataCargos.Year));
            evolucaoCargosVM.arrayTotalServidores = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.TotalCargos));

            return View(evolucaoCargosVM);
        }


        public IActionResult Filiados()
        {
            return View();
        }
    }
}