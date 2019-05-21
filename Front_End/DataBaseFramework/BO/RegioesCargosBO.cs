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
    }
}
