using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DAO
{
    public class GastosTotaisDAO
    {
        public string ConnectionString { get; set; }

        public GastosTotaisDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
    }
}
