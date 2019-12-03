using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FGApp.Models
{
    public class EvolucaoPartidosVM
    {
        public SelectList selecaoAno { get; set; }

        public int anoSelecionado { get; set; }

        public string arrayOcupantesPartidos { get; set; }
    }

    public class OcupantesPartido
    {
        public string partido { get; set; }

        public string cor { get; set; }

        public string arrayTotalOcupantes { get; set; }
    }
}
