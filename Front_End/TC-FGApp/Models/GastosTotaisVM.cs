using Microsoft.AspNetCore.Mvc.Rendering;

namespace FGApp.Models
{
    public class GastosTotaisVM
    {
        public SelectList selecaoAno { get; set; }

        public int anoSelecionado { get; set; }

        public string arrayMeses { get; set; }

        public string arrayTotalGastos { get; set; }
    }
}
