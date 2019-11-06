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
            string color = String.Format("#{0:X6}", random.Next(0x1000000));
            color = color + "AA";

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
