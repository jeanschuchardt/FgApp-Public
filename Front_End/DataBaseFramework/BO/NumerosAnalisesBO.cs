using DataBaseFramework.DAO;
using DataBaseFramework.DataModel;
using System.Collections.Generic;

namespace DataBaseFramework.BO
{
    public class NumerosAnalisesBO
    {
        public string ConnectionString { get; set; }

        public NumerosAnalisesBO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<NumerosAnalisesDTO> GetRelacaoPorAno(NumerosAnalisesDTO filiadosFuncionarios)
        {
            return new NumerosAnalisesDAO(ConnectionString).GetRelacaoPorAno(filiadosFuncionarios);
        }
    }
}
