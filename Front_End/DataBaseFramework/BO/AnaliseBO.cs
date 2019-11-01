using DataBaseFramework.DAO;
using DataBaseFramework.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.BO
{
    public class AnaliseBO
    {
        public string ConnectionString { get; set; }

        public AnaliseBO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<Analise> GetAllAnalises()
        {
            return new AnaliseDAO(ConnectionString).GetAllAnalises();
        }
    }
}
