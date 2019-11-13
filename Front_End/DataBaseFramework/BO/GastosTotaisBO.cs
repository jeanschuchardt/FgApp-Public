using DataBaseFramework.DAO;
using DataBaseFramework.DataModel;
using System.Collections.Generic;

namespace DataBaseFramework.BO
{
    public class GastosTotaisBO
    {
        public string ConnectionString { get; set; }

        public GastosTotaisBO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<GastosTotaisDTO> GetRelacaoPorAno(GastosTotaisDTO gastosTotais)
        {
            return new GastosTotaisDAO(ConnectionString).GetRelacaoPorAno(gastosTotais);
        }

        public List<int> GetAllDataGastosDisponiveis()
        {
            return new GastosTotaisDAO(ConnectionString).GetAllDataGastosDisponiveis();
        }
    }
}
