using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FGApp.Util
{
    public static class Helper
    {
        public static string ColorGenerator()
        {
            Random random = new Random();
            string color = String.Format("rgba(" + random.Next(255).ToString() + ", " + random.Next(255).ToString() + ", " + random.Next(255).ToString() + ", ");
            color = color + "0.7)";

            return color;
        }

        public static string ListaCores(int tamanho)
        {
            List<string> listaCores = new List<string>();

            for (int i = 0; i < tamanho; i++)
                listaCores.Add(ColorGenerator());

            return JsonConvert.SerializeObject(listaCores.ToArray());
        }
    }
}
