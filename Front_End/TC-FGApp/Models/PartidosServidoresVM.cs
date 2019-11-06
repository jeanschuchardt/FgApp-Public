using Microsoft.AspNetCore.Mvc.Rendering;

namespace FGApp.Models
{
    public class PartidosServidoresVM
    {
        public SelectList selecaoAno { get; set; }

        public int anoSelecionado { get; set; }

        public int mesSelecionado { get; set; }

        public string arrayPartidos { get; set; }

        public string arrayTotalServidores { get; set; }

        public string arrayCores { get; set; }
    }
}
