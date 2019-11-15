using DataBaseFramework.DAO;
using DataBaseFramework.DataModel;
using System.Collections.Generic;

namespace DataBaseFramework.BO
{
    public class FiliadosFuncionariosBO
    {
        public string ConnectionString { get; set; }

        public FiliadosFuncionariosBO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<FiliadosFuncionariosDTO> GetNumFuncionariosPorFuncao(FiliadosFuncionariosDTO filiadosFuncionarios)
        {
            return new FiliadosFuncionariosDAO(ConnectionString).GetNumFuncionariosPorFuncao(filiadosFuncionarios);
        }

        public List<FiliadosFuncionariosDTO> GetDistribuicaoFuncoes(FiliadosFuncionariosDTO filiadosFuncionarios)
        {
            return new FiliadosFuncionariosDAO(ConnectionString).GetDistribuicaoFuncoes(filiadosFuncionarios);
        }

        public List<FiliadosFuncionariosDTO> GetServidoresPorPartido(FiliadosFuncionariosDTO filiadosFuncionarios)
        {
            return new FiliadosFuncionariosDAO(ConnectionString).GetServidoresPorPartido(filiadosFuncionarios);
        }

        public List<FiliadosFuncionariosDTO> GetServidoresPorAno(FiliadosFuncionariosDTO filiadosFuncionarios)
        {
            return new FiliadosFuncionariosDAO(ConnectionString).GetServidoresPorAno(filiadosFuncionarios);
        }

        public List<FiliadosFuncionariosDTO> GetAllFiliadosFuncionarios()
        {
            return new FiliadosFuncionariosDAO(ConnectionString).GetAllFiliadosFuncionarios();
        }

        public List<int> GetAllDataCargosDisponiveis()
        {
            return new FiliadosFuncionariosDAO(ConnectionString).GetAllDataCargosDisponiveis();
        }

        public List<string> GetAllEstadosDisponiveis()
        {
            return new FiliadosFuncionariosDAO(ConnectionString).GetAllEstadosDisponiveis();
        }

        public List<string> GetAllTipoFuncoesDisponiveis()
        {
            return new FiliadosFuncionariosDAO(ConnectionString).GetAllTipoFuncoesDisponiveis();
        }
    }
}
