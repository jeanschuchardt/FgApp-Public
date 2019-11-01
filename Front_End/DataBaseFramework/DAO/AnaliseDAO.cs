using DataBaseFramework.DataModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DAO
{
    internal class AnaliseDAO
    {
        public string ConnectionString { get; set; }

        public AnaliseDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<Analise> GetAllAnalises()
        {
            List<Analise> list = new List<Analise>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT *, COUNT(id_portal) AS quantidade FROM resultados GROUP BY func", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Analise()
                        {
                            Ano = reader.GetInt32("ano"),
                            Mes = reader.GetInt32("mes"),
                            UF = reader.GetString("uf"),
                            Partido = reader.GetString("partido"),
                            Sigla = reader.GetString("sigla"),
                            Func = reader.GetString("func"),
                            Quantidade = reader.GetInt32("quantidade")
                        });
                    }
                }
            }

            return list;
        }
    }
}
