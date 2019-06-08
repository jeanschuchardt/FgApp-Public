using DataBaseFramework.DAO;
using DataBaseFramework.DataModel;
using System.Collections.Generic;

namespace DataBaseFramework.BO
{
    public class RegioesCargosBO
    {
        public string ConnectionString { get; set; }

        public RegioesCargosBO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<RegioesCargos> GetAllRegioesCargos()
        {
            return new RegioesCargosDAO(ConnectionString).GetAllRegioesCargos();
        }

        public List<string> GetAllEstadosDisponiveis()
        {
            return new RegioesCargosDAO(ConnectionString).GetAllEstadosDisponiveis();
        }

        public List<string> GetAllTipoCargosDisponiveis()
        {
            return new RegioesCargosDAO(ConnectionString).GetAllTipoCargosDisponiveis();
        }

        public List<int> GetAllDataCargosDisponiveis()
        {
            return new RegioesCargosDAO(ConnectionString).GetAllDataCargosDisponiveis();
        }

        public List<RegioesCargos> GetDistribuicaoFuncoes(RegioesCargos regioesCargos)
        {
            return new RegioesCargosDAO(ConnectionString).GetDistribuicaoFuncoes(regioesCargos);
        }

        public List<RegioesCargos> GetServidoresPorPartido(RegioesCargos regioesCargos)
        {
            return new RegioesCargosDAO(ConnectionString).GetServidoresPorPartido(regioesCargos);
        }

        public List<RegioesCargos> GetServidoresPorAno(RegioesCargos regioesCargos)
        {
            return new RegioesCargosDAO(ConnectionString).GetServidoresPorAno(regioesCargos);
        }
    }
}
