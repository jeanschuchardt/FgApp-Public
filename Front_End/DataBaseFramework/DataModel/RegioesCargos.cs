using System;

namespace DataBaseFramework.DataModel
{
    public class RegioesCargos
    {
        public int ID { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public DateTime DataCargos { get; set; }

        public string Partido { get; set; }

        public string TipoCargos { get; set; }

        public int? TotalCargos { get; set; }
    }
}
