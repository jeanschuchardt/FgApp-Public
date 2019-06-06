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

        public List<RegioesCargos> GetDistribuicaoFuncoes(RegioesCargos regioesCargos)
        {
            List<RegioesCargos> list = new List<RegioesCargos>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
                                            Estado, 
                                            SUM(TotalCargos) AS TotalCargos
                                        FROM regioescargos
                                        WHERE YEAR(DataCargos) = @pDataCargo
                                        GROUP BY Estado ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                cmd.Parameters.AddWithValue("@pDataCargo", regioesCargos.DataCargos.Year);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RegioesCargos()
                        {
                            Estado = reader.GetString("Estado"),
                            TotalCargos = reader.GetInt32("TotalCargos"),
                        });
                    }
                }
            }

            return list;
        }

        public List<RegioesCargos> GetServidoresPorPartido(RegioesCargos regioesCargos)
        {
            List<RegioesCargos> list = new List<RegioesCargos>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
                                            Partido, 
                                            SUM(TotalCargos) AS TotalCargos
                                        FROM regioescargos
                                        WHERE YEAR(DataCargos) = @pDataCargo
                                        GROUP BY Partido, DataCargos
                                        ORDER BY TotalCargos DESC ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                cmd.Parameters.AddWithValue("@pDataCargo", regioesCargos.DataCargos.Year);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RegioesCargos()
                        {
                            Partido = reader.GetString("Partido"),
                            TotalCargos = reader.GetInt32("TotalCargos"),
                        });
                    }
                }
            }

            return list;
        }

        public List<RegioesCargos> GetServidoresPorAno(RegioesCargos regioesCargos)
        {
            List<RegioesCargos> list = new List<RegioesCargos>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT DataCargos, TipoCargos, SUM(TotalCargos) AS TotalCargos
                                        FROM regioescargos 
                                        WHERE Estado = @pEstado 
                                        GROUP BY DataCargos
                                        ORDER BY DataCargos ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                cmd.Parameters.AddWithValue("@pEstado", regioesCargos.Estado);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RegioesCargos()
                        {
                            DataCargos = reader.GetDateTime("DataCargos"),
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
