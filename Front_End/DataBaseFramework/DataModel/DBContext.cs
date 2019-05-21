using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DataModel
{
    public class DBContext
    {
        public string ConnectionString { get; set; }

        public DBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }

}
