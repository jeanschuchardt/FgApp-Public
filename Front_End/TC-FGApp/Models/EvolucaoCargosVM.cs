using Microsoft.AspNetCore.Mvc.Rendering;

namespace FGApp.Models
{
    public class EvolucaoCargosVM
    {
        public SelectList listaEstados { get; set; }

        public string estadoSelecionado { get; set; }

        public SelectList listaCargos { get; set; }

        public string cargoSelecionado { get; set; }

        public string arrayDataCargos { get; set; }

        public string arrayTotalServidores { get; set; }
    }
}
