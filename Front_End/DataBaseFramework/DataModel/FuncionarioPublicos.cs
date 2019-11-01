using System;

namespace DataBaseFramework.DataModel
{
    public class FuncionarioPublicos
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public string FuncaoAtual { get; set; }

        public string FuncaoAnterior { get; set; }

        public DateTime? DataTroca { get; set; }
    }
}
