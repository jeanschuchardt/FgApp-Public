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

        public List<GastosTotaisDTO> GetAllGastos()
        {
            List<GastosTotaisDTO> list = new List<GastosTotaisDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
	                                        ANO,
	                                        MES,
	                                        SIGLA_FUNCAO,
	                                        TOTAL_REMUNERACAO
                                        FROM gastostotais
                                        ORDER BY ANO, MES ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GastosTotaisDTO()
                        {
                            Ano = reader.GetInt32("ANO"),
                            Mes = reader.GetInt32("MES"),
                            SiglaFuncao = reader.GetString("SIGLA_FUNCAO"),
                            TotalRemuneracao = reader.GetDouble("TOTAL_REMUNERACAO")
                        });
                    }
                }
            }

            return list;
        }

        public List<GastosTotaisDTO> GetGastosPorAno()
        {
            List<GastosTotaisDTO> list = new List<GastosTotaisDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
                                            ANO,
                                            SUM(TOTAL_REMUNERACAO) AS TOTAL_REMUNERACAO
                                        FROM gastostotais
                                        WHERE ano > 2013 AND ano < 2019
                                        GROUP BY ano ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new GastosTotaisDTO()
                        {
                            Ano = reader.GetInt32("ANO"),
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
