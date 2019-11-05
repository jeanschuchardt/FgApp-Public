using DataBaseFramework.DataModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DAO
{
    internal class NumerosAnalisesDAO
    {
        public string ConnectionString { get; set; }

        public NumerosAnalisesDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        

        
    }
}
