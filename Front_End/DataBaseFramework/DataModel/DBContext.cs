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

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<RegioesCargos> GetAllRegioesCargos()
        {
            List<RegioesCargos> list = new List<RegioesCargos>();

            using (MySqlConnection conn = GetConnection())
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


        public List<FuncionarioPublicos> GetAllFuncionarios()
        {
            List<FuncionarioPublicos> list = new List<FuncionarioPublicos>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM FuncionarioPublicos", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new FuncionarioPublicos()
                        {
                            ID = reader.GetInt32("ID"),
                            Nome = reader.GetString("Nome"),
                            FuncaoAtual = reader.GetString("FuncaoAtual"),
                            FuncaoAnterior = reader.IsDBNull(3)? null : reader.GetString("FuncaoAnterior"),
                            DataTroca = reader.GetDateTime("DataTroca")
                        });
                    }
                }
            }

            return list;
        }



    }

}
