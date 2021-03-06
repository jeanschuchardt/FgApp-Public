﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace FGApp.Models
{
    public class ServidoresFiliadosVM
    {
        public SelectList selecaoAno { get; set; }

        public int anoSelecionado { get; set; }

        public string arrayMeses { get; set; }

        public string arrayTotalServidores { get; set; }

        public string arrayTotalResultados { get; set; }
    }
}
