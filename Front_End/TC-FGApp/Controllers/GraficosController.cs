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

        [HttpGet]
        public IActionResult DistribuicaoFuncoes()
        {
            DistribuicaoFuncoesVM distribuicaoFuncoesVM = new DistribuicaoFuncoesVM();

            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            distribuicaoFuncoesVM.selecaoAno = new SelectList(listaAnos);
            distribuicaoFuncoesVM.anoSelecionado = 2015;

            List<FiliadosFuncionariosDTO> listaRegioesFuncoes = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetDistribuicaoFuncoes(new FiliadosFuncionariosDTO() { Ano = 2015 });

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
            partidosServidoresVM.anoSelecionado = 2015;
            partidosServidoresVM.mesSelecionado = 1;

            List<FiliadosFuncionariosDTO> listaPartidoServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new FiliadosFuncionariosDTO() { Ano = partidosServidoresVM.anoSelecionado, Mes = partidosServidoresVM.mesSelecionado });

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

            List<FiliadosFuncionariosDTO> listaPartidoServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetServidoresPorPartido(new FiliadosFuncionariosDTO() { Ano = partidosServidoresVM.anoSelecionado, Mes = partidosServidoresVM.mesSelecionado });

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

        [HttpGet]
        public IActionResult ServidoresFiliados()
        {
            ServidoresFiliadosVM servidoresFiliadosVM = new ServidoresFiliadosVM();

            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            servidoresFiliadosVM.selecaoAno = new SelectList(listaAnos);
            servidoresFiliadosVM.anoSelecionado = 2015;

            List<NumerosAnalisesDTO> listaRelacoes = new NumerosAnalisesBO(_connectionStrings.DefaultConnection).GetRelacaoPorAno(new NumerosAnalisesDTO() { Ano = 2015 });

            servidoresFiliadosVM.arrayTotalResultados = JsonConvert.SerializeObject(listaRelacoes.Select(x => x.TotalResultados));
            servidoresFiliadosVM.arrayTotalServidores = JsonConvert.SerializeObject(listaRelacoes.Select(x => x.TotalServidores));

            return View(servidoresFiliadosVM);
        }

        [HttpPost]
        public IActionResult ServidoresFiliados(ServidoresFiliadosVM servidoresFiliadosVM)
        {
            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            servidoresFiliadosVM.selecaoAno = new SelectList(listaAnos);

            List<NumerosAnalisesDTO> listaRelacoes = new NumerosAnalisesBO(_connectionStrings.DefaultConnection).GetRelacaoPorAno(new NumerosAnalisesDTO() { Ano = servidoresFiliadosVM.anoSelecionado });

            servidoresFiliadosVM.arrayTotalResultados = JsonConvert.SerializeObject(listaRelacoes.Select(x => x.TotalResultados));
            servidoresFiliadosVM.arrayTotalServidores = JsonConvert.SerializeObject(listaRelacoes.Select(x => x.TotalServidores));

            return View(servidoresFiliadosVM);
        }

    }
}