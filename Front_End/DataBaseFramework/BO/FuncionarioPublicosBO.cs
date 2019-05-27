using DataBaseFramework.DAO;
using DataBaseFramework.DataModel;
using System.Collections.Generic;

namespace DataBaseFramework.BO
{
    public class FuncionarioPublicosBO
    {
        public string ConnectionString { get; set; }

        public FuncionarioPublicosBO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<FuncionarioPublicos> GetAllFuncionarios()
        {
            return new FuncionarioPublicosDAO(ConnectionString).GetAllFuncionarios();
        }

        public List<FuncoesOcupantesDM> GetFuncoesxOcupantes()
        {
            return new FuncionarioPublicosDAO(ConnectionString).GetFuncoesxOcupantes();
        }
    }
}
