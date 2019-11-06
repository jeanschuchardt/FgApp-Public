using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
