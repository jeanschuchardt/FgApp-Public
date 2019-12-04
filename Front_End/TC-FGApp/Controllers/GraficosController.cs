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

        [HttpGet]
        public IActionResult FuncoesOcupantes()
        {
            FuncoesOcupantesVM funcoesOcupantesVM = new FuncoesOcupantesVM();

            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            funcoesOcupantesVM.selecaoAno = new SelectList(listaAnos);
            funcoesOcupantesVM.anoSelecionado = 2015;
            funcoesOcupantesVM.mesSelecionado = 1;

            List<FiliadosFuncionariosDTO> listaFuncoesServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetNumFuncionariosPorFuncao(new FiliadosFuncionariosDTO() { Ano = funcoesOcupantesVM.anoSelecionado, Mes = funcoesOcupantesVM.mesSelecionado });

            funcoesOcupantesVM.arrayFuncoes = JsonConvert.SerializeObject(listaFuncoesServidores.Select(x => x.Funcao).ToArray());
            funcoesOcupantesVM.arrayQuantidade = JsonConvert.SerializeObject(listaFuncoesServidores.Select(x => x.Quantidade).ToArray());

            return View(funcoesOcupantesVM);
        }

        [HttpPost]
        public IActionResult FuncoesOcupantes(FuncoesOcupantesVM funcoesOcupantesVM)
        {
            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();
            funcoesOcupantesVM.selecaoAno = new SelectList(listaAnos);

            List<FiliadosFuncionariosDTO> listaFuncoesServidores = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetNumFuncionariosPorFuncao(new FiliadosFuncionariosDTO() { Ano = funcoesOcupantesVM.anoSelecionado, Mes = funcoesOcupantesVM.mesSelecionado });

            funcoesOcupantesVM.arrayFuncoes = JsonConvert.SerializeObject(listaFuncoesServidores.Select(x => x.Funcao).ToArray());
            funcoesOcupantesVM.arrayQuantidade = JsonConvert.SerializeObject(listaFuncoesServidores.Select(x => x.Quantidade).ToArray());

            return View(funcoesOcupantesVM);
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

            evolucaoCargosVM.arrayDataCargos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.AnoMesFormatado));
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

            evolucaoCargosVM.arrayDataCargos = JsonConvert.SerializeObject(listaPartidoServidores.Select(x => x.AnoMesFormatado));
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

        [HttpGet]
        public IActionResult GastosTotais()
        {
            GastosTotaisVM gastosTotaisVM = new GastosTotaisVM();

            List<int> listaAnos = new GastosTotaisBO(_connectionStrings.DefaultConnection).GetAllDataGastosDisponiveis();

            gastosTotaisVM.selecaoAno = new SelectList(listaAnos);
            gastosTotaisVM.anoSelecionado = 2015;

            List<GastosTotaisDTO> listaGastos = new GastosTotaisBO(_connectionStrings.DefaultConnection).GetRelacaoPorAno(new GastosTotaisDTO() { Ano = 2015 });

            gastosTotaisVM.arrayTotalGastos = JsonConvert.SerializeObject(listaGastos.Select(x => x.TotalRemuneracao));

            return View(gastosTotaisVM);
        }

        [HttpPost]
        public IActionResult GastosTotais(GastosTotaisVM gastosTotaisVM)
        {
            List<int> listaAnos = new GastosTotaisBO(_connectionStrings.DefaultConnection).GetAllDataGastosDisponiveis();

            gastosTotaisVM.selecaoAno = new SelectList(listaAnos);

            List<GastosTotaisDTO> listaGastos = new GastosTotaisBO(_connectionStrings.DefaultConnection).GetRelacaoPorAno(new GastosTotaisDTO() { Ano = gastosTotaisVM.anoSelecionado });

            gastosTotaisVM.arrayTotalGastos = JsonConvert.SerializeObject(listaGastos.Select(x => x.TotalRemuneracao));

            return View(gastosTotaisVM);
        }

        [HttpGet]
        public IActionResult EvolucaoPartidos()
        {
            EvolucaoPartidosVM evolucaoPartidosVM = new EvolucaoPartidosVM();

            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            evolucaoPartidosVM.selecaoAno = new SelectList(listaAnos);
            evolucaoPartidosVM.anoSelecionado = 2015;

            List<FiliadosFuncionariosDTO> listaEvolucaoPartidos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetEvolucaoPartidosPorAno(new FiliadosFuncionariosDTO() { Ano = 2015 });

            List<OcupantesPartido> listOcupantesPartidos = new List<OcupantesPartido>();

            foreach (FiliadosFuncionariosDTO ff in listaEvolucaoPartidos)
            {
                if (!listOcupantesPartidos.Any(x => x.partido.Equals(ff.Partido)))
                {
                    OcupantesPartido ocupantesPartidoAux = new OcupantesPartido();

                    ocupantesPartidoAux.partido = ff.Partido;
                    ocupantesPartidoAux.cor = Helper.ColorGenerator();
                    ocupantesPartidoAux.arrayTotalOcupantes = JsonConvert.SerializeObject(listaEvolucaoPartidos.Where(x => x.Partido.Equals(ocupantesPartidoAux.partido)).Select(x => x.Quantidade));

                    listOcupantesPartidos.Add(ocupantesPartidoAux);
                }
            }

            evolucaoPartidosVM.arrayOcupantesPartidos = JsonConvert.SerializeObject(listOcupantesPartidos);

            return View(evolucaoPartidosVM);
        }

        [HttpPost]
        public IActionResult EvolucaoPartidos(EvolucaoPartidosVM evolucaoPartidosVM)
        {
            List<int> listaAnos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetAllDataCargosDisponiveis();

            evolucaoPartidosVM.selecaoAno = new SelectList(listaAnos);

            List<FiliadosFuncionariosDTO> listaEvolucaoPartidos = new FiliadosFuncionariosBO(_connectionStrings.DefaultConnection).GetEvolucaoPartidosPorAno(new FiliadosFuncionariosDTO() { Ano = evolucaoPartidosVM.anoSelecionado });

            List<OcupantesPartido> listOcupantesPartidos = new List<OcupantesPartido>();

            foreach (FiliadosFuncionariosDTO ff in listaEvolucaoPartidos)
            {
                if (!listOcupantesPartidos.Any(x => x.partido.Equals(ff.Partido)))
                {
                    OcupantesPartido ocupantesPartidoAux = new OcupantesPartido();

                    ocupantesPartidoAux.partido = ff.Partido;
                    ocupantesPartidoAux.cor = Helper.ColorGenerator();
                    ocupantesPartidoAux.arrayTotalOcupantes = JsonConvert.SerializeObject(listaEvolucaoPartidos.Where(x => x.Partido.Equals(ocupantesPartidoAux.partido)).Select(x => x.Quantidade));

                    listOcupantesPartidos.Add(ocupantesPartidoAux);
                }
            }

            evolucaoPartidosVM.arrayOcupantesPartidos = JsonConvert.SerializeObject(listOcupantesPartidos);

            return View(evolucaoPartidosVM);
        }
    }
}