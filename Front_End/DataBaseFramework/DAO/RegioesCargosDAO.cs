using DataBaseFramework.DataModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DAO
{
    internal class RegioesCargosDAO
    {
        public string ConnectionString { get; set; }

        public RegioesCargosDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<RegioesCargos> GetAllRegioesCargos()
        {
            List<RegioesCargos> list = new List<RegioesCargos>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM RegioesCargos", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RegioesCargos()
                        {
                            ID = reader.GetInt32("ID"),
                            Estado = reader.GetString("Estado"),
                            Cidade = reader.GetString("Cidade"),
                            DataCargos = reader.GetDateTime("DataCargos"),
                            Partido = reader.GetString("Partido"),
                            TipoCargos = reader.GetString("TipoCargos"),
                            TotalCargos = reader.GetInt32("TotalCargos")
                        });
                    }
                }
            }

            return list;
        }
    }
}
