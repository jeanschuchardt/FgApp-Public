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
            List<FiliadosFuncionariosDTO> funcionarioPublicos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetNumFuncionariosPorFuncao();

            return View();
        }

        public IActionResult FuncoesOcupantes()
        {
            List<FiliadosFuncionariosDTO> NumFuncionariosPorFuncao = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetNumFuncionariosPorFuncao();

            return View(NumFuncionariosPorFuncao);
        }

        public IActionResult ServidoresFiliados()
        {


            return View();
        }

        [HttpGet]
        public IActionResult DistribuicaoFuncoes()
        {
            DistribuicaoFuncoesVM distribuicaoFuncoesVM = new DistribuicaoFuncoesVM();

            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            distribuicaoFuncoesVM.selecaoAno = new SelectList(listaAnos);
            distribuicaoFuncoesVM.anoSelecionado = 2015;

            List<FiliadosFuncionariosDTO> listaRegioesFuncoes = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(new FiliadosFuncionariosDTO() { Ano = 2010 });

            distribuicaoFuncoesVM.arrayDados = DataNormalization.NormalizeDistribuicaoFuncoes(listaRegioesFuncoes);

            return View(distribuicaoFuncoesVM);
        }

        [HttpPost]
        public IActionResult DistribuicaoFuncoes(DistribuicaoFuncoesVM distribuicaoFuncoesVM)
        {
            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();
            distribuicaoFuncoesVM.selecaoAno = new SelectList(listaAnos);

            List<FiliadosFuncionariosDTO> listaRegioesFuncoes = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(new FiliadosFuncionariosDTO() { Ano = distribuicaoFuncoesVM.anoSelecionado });

            distribuicaoFuncoesVM.arrayDados = DataNormalization.NormalizeDistribuicaoFuncoes(listaRegioesFuncoes);

            return View(distribuicaoFuncoesVM);
        }

        [HttpGet]
        public IActionResult PartidosServidores()
        {
            PartidosServidoresVM partidosServidoresVM = new PartidosServidoresVM();

            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            partidosServidoresVM.selecaoAno = new SelectList(listaAnos);
            partidosServidoresVM.anoSelecionado = 2010;

            List<FiliadosFuncionariosDTO> listaPartidoServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new FiliadosFuncionariosDTO() { Ano = partidosServidoresVM.anoSelecionado });

            partidosServidoresVM.arrayPartidos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Partido).ToArray());
            partidosServidoresVM.arrayTotalServidores = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Quantidade).ToArray());
            partidosServidoresVM.arrayCores = Helper.ListaCores(listaPartidoServidores.Count());

            return View(partidosServidoresVM);
        }

        [HttpPost]
        public IActionResult PartidosServidores(PartidosServidoresVM partidosServidoresVM)
        {
            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();
            partidosServidoresVM.selecaoAno = new SelectList(listaAnos);

            List<FiliadosFuncionariosDTO> listaPartidoServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new FiliadosFuncionariosDTO() { Ano = partidosServidoresVM.anoSelecionado });

            partidosServidoresVM.arrayPartidos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Partido));
            partidosServidoresVM.arrayTotalServidores = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Quantidade).ToArray());
            partidosServidoresVM.arrayCores = Helper.ListaCores(listaPartidoServidores.Count());

            return View(partidosServidoresVM);
        }

        [HttpGet]
        public IActionResult EvolucaoCargos()
        {
            EvolucaoCargosVM evolucaoCargosVM = new EvolucaoCargosVM();

            List<string> listaEstados = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllEstadosDisponiveis();

            evolucaoCargosVM.listaEstados = new SelectList(listaEstados);
            evolucaoCargosVM.estadoSelecionado = "RS";

            List<string> listaCargos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllTipoFuncoesDisponiveis();

            evolucaoCargosVM.listaCargos = new SelectList(listaCargos);
            evolucaoCargosVM.cargoSelecionado = "CCT";

            List<FiliadosFuncionariosDTO> listaPartidoServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetServidoresPorAno(new FiliadosFuncionariosDTO() { UF = evolucaoCargosVM.estadoSelecionado, Sigla = evolucaoCargosVM.cargoSelecionado });

            evolucaoCargosVM.arrayDataCargos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Ano));
            evolucaoCargosVM.arrayTotalServidores = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Quantidade));

            return View(evolucaoCargosVM);
        }

        [HttpPost]
        public IActionResult EvolucaoCargos(EvolucaoCargosVM evolucaoCargosVM)
        {
            List<string> listaEstados = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllEstadosDisponiveis();
            evolucaoCargosVM.listaEstados = new SelectList(listaEstados);

            List<string> listaCargos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllTipoFuncoesDisponiveis();
            evolucaoCargosVM.listaCargos = new SelectList(listaCargos);

            List<FiliadosFuncionariosDTO> listaPartidoServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetServidoresPorAno(new FiliadosFuncionariosDTO() { UF = evolucaoCargosVM.estadoSelecionado, Sigla = evolucaoCargosVM.cargoSelecionado });

            evolucaoCargosVM.arrayDataCargos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Ano));
            evolucaoCargosVM.arrayTotalServidores = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.Quantidade));

            return View(evolucaoCargosVM);
        }



        public IActionResult Filiados()
        {
            return View();
        }
    }
}