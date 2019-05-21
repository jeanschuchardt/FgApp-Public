using DataBaseFramework.DataModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DAO
{
    internal class FuncionarioPublicosDAO
    {
        public string ConnectionString { get; set; }

        public FuncionarioPublicosDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<FuncionarioPublicos> GetAllFuncionarios()
        {
            List<FuncionarioPublicos> list = new List<FuncionarioPublicos>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
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
                            FuncaoAnterior = reader.IsDBNull(3) ? null : reader.GetString("FuncaoAnterior"),
                            DataTroca = reader.GetDateTime("DataTroca")
                        });
                    }
                }
            }

            return list;
        }
    }
}
