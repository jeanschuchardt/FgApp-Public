using DataBaseFramework.DataModel;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DAO
{
    internal class FiliadosFuncionariosDAO
    {
        public string ConnectionString { get; set; }

        public FiliadosFuncionariosDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<FiliadosFuncionariosDTO> GetNumFuncionariosPorFuncao()
        {
            List<FiliadosFuncionariosDTO> list = new List<FiliadosFuncionariosDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"SELECT 
                                                        ano, 
                                                        mes,
                                                        uf,
                                                        partido,
                                                        sigla,
                                                        func,
                                                        COUNT(id_portal) AS quantidade
                                                    FROM resultados 
                                                    WHERE ano = 2018 
                                                    AND mes = 12
                                                    GROUP BY sigla", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new FiliadosFuncionariosDTO()
                        {
                            Ano = reader.GetInt32("ano"),
                            Mes = reader.GetInt32("mes"),
                            UF = reader.GetString("uf"),
                            Partido = reader.GetString("partido"),
                            Sigla = reader.GetString("sigla"),
                            Funcao = reader.GetString("func"),
                            Quantidade = reader.GetInt32("quantidade")
                        });
                    }
                }

                conn.Close();
            }

            return list;
        }

        public List<FiliadosFuncionariosDTO> GetDistribuicaoFuncoes(FiliadosFuncionariosDTO filiadosFuncionarios)
        {
            List<FiliadosFuncionariosDTO> list = new List<FiliadosFuncionariosDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
	                                        uf, 
	                                        COUNT(id_portal) AS quantidade
                                        FROM resultados
                                        WHERE ano = @pAno
                                        GROUP BY uf ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                cmd.Parameters.AddWithValue("@pAno", filiadosFuncionarios.Ano);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new FiliadosFuncionariosDTO()
                        {
                            UF = reader.GetString("uf"),
                            Quantidade = reader.GetInt32("quantidade"),
                        });
                    }
                }
            }

            return list;
        }

        public List<FiliadosFuncionariosDTO> GetServidoresPorPartido(FiliadosFuncionariosDTO filiadosFuncionarios)
        {
            List<FiliadosFuncionariosDTO> list = new List<FiliadosFuncionariosDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
	                                        partido, 
	                                        COUNT(id_portal) AS quantidade
                                        FROM resultados
                                        WHERE mes = @pMes
                                        AND ano = @pAno
                                        GROUP BY partido, ano
                                        ORDER BY quantidade DESC ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                cmd.Parameters.AddWithValue("@pMes", filiadosFuncionarios.Mes);
                cmd.Parameters.AddWithValue("@pAno", filiadosFuncionarios.Ano);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new FiliadosFuncionariosDTO()
                        {
                            Partido = reader.GetString("partido"),
                            Quantidade = reader.GetInt32("quantidade"),
                        });
                    }
                }
            }

            return list;
        }

        public List<FiliadosFuncionariosDTO> GetServidoresPorAno(FiliadosFuncionariosDTO filiadosFuncionarios)
        {
            List<FiliadosFuncionariosDTO> list = new List<FiliadosFuncionariosDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
                                            ano, 
                                            sigla, 
                                            COUNT(id_portal) AS quantidade
	                                    FROM resultados 
	                                    WHERE uf = @pUf
	                                    AND sigla = @pSigla
	                                    GROUP BY ano 
	                                    ORDER BY ano ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                cmd.Parameters.AddWithValue("@pUf", filiadosFuncionarios.UF);
                cmd.Parameters.AddWithValue("@pSigla", filiadosFuncionarios.Sigla);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new FiliadosFuncionariosDTO()
                        {
                            Ano = reader.GetInt32("ano"),
                            Sigla = reader.GetString("sigla"),
                            Quantidade = reader.GetInt32("quantidade")
                        });
                    }
                }
            }

            return list;
        }

        public List<FiliadosFuncionariosDTO> GetAllFiliadosFuncionarios()
        {
            List<FiliadosFuncionariosDTO> list = new List<FiliadosFuncionariosDTO>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT 
	                                        sigla,
                                            func,
                                            partido,
                                            uf,
                                            ano,
                                            mes,
	                                        COUNT(id_portal) AS quantidade
                                        FROM resultados 
                                        GROUP BY ano, mes, partido 
                                        ORDER BY ano, mes ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new FiliadosFuncionariosDTO()
                        {
                            Sigla = reader.GetString("sigla"),
                            Funcao = reader.GetString("func"),
                            Partido = reader.GetString("partido"),
                            UF = reader.GetString("uf"),
                            Ano = reader.GetInt32("ano"),
                            Mes = reader.GetInt32("mes"),
                            Quantidade = reader.GetInt32("quantidade")
                        });
                    }
                }
            }

            return list;
        }

        #region MetodosParaCamposDePesquisa
        public List<int> GetAllDataCargosDisponiveis()
        {
            List<int> list = new List<int>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT DISTINCT(ano) 
                                        FROM resultados 
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

        public List<string> GetAllEstadosDisponiveis()
        {
            List<string> list = new List<string>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT DISTINCT(uf) FROM resultados ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString("uf"));
                    }
                }
            }

            return list;
        }

        public List<string> GetAllTipoFuncoesDisponiveis()
        {
            List<string> list = new List<string>();

            using (MySqlConnection conn = new DBContext(ConnectionString).GetConnection())
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" SELECT DISTINCT(sigla), func FROM resultados ");

                conn.Open();
                MySqlCommand cmd = new MySqlCommand(stringBuilder.ToString(), conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString("sigla"));
                    }
                }
            }

            return list;
        }
        #endregion
    }
}
