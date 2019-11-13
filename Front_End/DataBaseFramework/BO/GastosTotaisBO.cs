using DataBaseFramework.DAO;
using DataBaseFramework.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.BO
{
    class GastosTotaisBO
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
    }
}
