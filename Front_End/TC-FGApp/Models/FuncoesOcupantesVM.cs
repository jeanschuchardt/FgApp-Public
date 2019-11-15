using Microsoft.AspNetCore.Mvc.Rendering;

namespace FGApp.Models
{
    public class FuncoesOcupantesVM
    {
        public SelectList selecaoAno { get; set; }

        public int anoSelecionado { get; set; }

        public int mesSelecionado { get; set; }

        public string arrayFuncoes { get; set; }

        public string arrayQuantidade { get; set; }
    }
}
