using System;

namespace DataBaseFramework.DataModel
{
    public class FiliadosFuncionariosDTO
    {
        #region colunasTabela

        public long IdPortal { get; set; }

        public string Nome { get; set; }

        public double Matricula { get; set; }

        public string Sigla { get; set; }

        public string Nivel { get; set; }

        public string Funcao { get; set; }

        public long C { get; set; }

        public long Id { get; set; }

        public string Partido { get; set; }

        public string UF { get; set; }

        public int Ano { get; set; }

        public int Mes { get; set; }

        #endregion

        public int Quantidade { get; set; }

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
