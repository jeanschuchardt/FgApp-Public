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

        public string AnoMesFormatado
        {
            get
            {
                string mesReduzido = this.MesFormatado.Substring(0, 3);
                string anoReduzido = this.Ano.ToString().Substring(2, 2);

                return mesReduzido + "/" + anoReduzido;
            }
        }

        public string MesReduzido
        {
            get
            {
                string mesReduzido = this.MesFormatado.Substring(0, 3);

                return mesReduzido;
            }
        }

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
    }
}
