using DataBaseFramework.DataModel;
using MySql.Data.MySqlClient;
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

        public List<NumerosAnalisesDTO> GetRelacaoPorAno(NumerosAnalisesDTO filiadosFuncionarios)
        {
            List<NumerosAnalisesDTO> list = new List<NumerosAnalisesDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
                                            ano,
                                            mes,
                                            SUM(t_resultados) AS t_resultados,
                                            SUM(t_servidores) AS t_servidores
                                        FROM RESULTADOS_NUM
                                        WHERE ano = @pAno
                                        GROUP BY mes
                                        ORDER BY mes ASC; ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                cmd.Parameters.AddWithValue("@pAno", filiadosFuncionarios.Ano);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NumerosAnalisesDTO()
                        {
                            Ano = reader.GetInt32("ano"),
                            Mes = reader.GetInt32("mes"),
                            TotalResultados = reader.GetDecimal("t_resultados"),
                            TotalServidores = reader.GetDecimal("t_servidores")
                        });
                    }
                }
            }

            return list;
        }

        public List<NumerosAnalisesDTO> GetAllRelacoes()
        {
            List<NumerosAnalisesDTO> list = new List<NumerosAnalisesDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
                                            ano,
                                            mes,
                                            SUM(t_filados) AS t_filiados,
                                            SUM(t_resultados) AS t_resultados,
                                            SUM(t_servidores) AS t_servidores
                                        FROM RESULTADOS_NUM
                                        GROUP BY ano, mes
                                        ORDER BY ano, mes ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NumerosAnalisesDTO()
                        {
                            Ano = reader.GetInt32("ano"),
                            Mes = reader.GetInt32("mes"),
                            TotalFiliados = reader.GetDecimal("t_filiados"),
                            TotalResultados = reader.GetDecimal("t_resultados"),
                            TotalServidores = reader.GetDecimal("t_servidores")
                        });
                    }
                }
            }

            return list;
        }
    }
}
