using DataBaseFramework.DataModel;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DAO
{
    internal class GastosTotaisDAO
    {
        public string ConnectionString { get; set; }

        public GastosTotaisDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<GastosTotaisDTO> GetRelacaoPorAno(GastosTotaisDTO gastosTotais)
        {
            List<GastosTotaisDTO> list = new List<GastosTotaisDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
                                            MES,
                                            SUM(TOTAL_REMUNERACAO) AS TOTAL_REMUNERACAO
                                        FROM gastostotais
                                        WHERE ANO = @pAno
                                        GROUP BY MES
                                        ORDER BY MES ASC; ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                cmd.Parameters.AddWithValue("@pAno", gastosTotais.Ano);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GastosTotaisDTO()
                        {
                            Mes = reader.GetInt32("MES"),
                            TotalRemuneracao = reader.GetDouble("TOTAL_REMUNERACAO")
                        });
                    }
                }
            }

            return list;
        }

        public List<int> GetAllDataGastosDisponiveis()
        {
            List<int> list = new List<int>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT DISTINCT(ano) 
                                        FROM gastostotais 
                                        ORDER BY ano ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetInt32("ano"));
                    }
                }
            }

            return list;
        }
    }
}
