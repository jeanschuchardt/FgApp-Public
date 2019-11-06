using System;

namespace DataBaseFramework.DataModel
{
    public class NumerosAnalisesDTO
    {
        #region colunasTabela
        public int Ano { get; set; }

        public string Letra { get; set; }

        public int Mes { get; set; }

        public decimal TotalFiliados { get; set; }

        public decimal TotalResultados { get; set; }

        public decimal TotalServidores { get; set; }
        #endregion
    }
}
