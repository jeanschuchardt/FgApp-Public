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
    }
}
