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

        public string MesFormatado
        {
            get
            {
                switch (Mes)
                {
                    case 1:
                        return "Janeiro";
                    case 2:
                        return "Fevereiro";
                    case 3:
                        return "Março";
                    case 4:
                        return "Abril";
                    case 5:
                        return "Maio";
                    case 6:
                        return "Junho";
                    case 7:
                        return "Julho";
                    case 8:
                        return "Agosto";
                    case 9:
                        return "Setembro";
                    case 10:
                        return "Outubro";
                    case 11:
                        return "Novembro";
                    case 12:
                        return "Dezembro";
                    default:
                        return "";
                }
            }
        }

        public string TotalRemuneracaoFormata
        {
            get
            {
                return "R$ " + string.Format("{0:N}", TotalRemuneracao);
            }
        }

    }
}
