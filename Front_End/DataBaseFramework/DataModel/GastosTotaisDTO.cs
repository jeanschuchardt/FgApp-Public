using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseFramework.DataModel
{
    public class GastosTotaisDTO
    {
        #region colunasTabela

        public int Mes { get; set; }

        public int Ano { get; set; }

        public string SiglaFuncao { get; set; }

        public double TotalRemuneracao { get; set; }

        #endregion
    }
}
