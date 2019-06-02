using DataBaseFramework.DataModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FGApp.Models
{
    public class DistribuicaoFuncoesVM
    {
        public SelectList selecaoAno { get; set; }

        public int anoSelecionado { get; set; }

        public string arrayDados { get; set; }
    }
}
