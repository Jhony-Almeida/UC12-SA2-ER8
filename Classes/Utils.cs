using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgBackEnd.Classes
{
    public static class Utils
    {
        public static void BarraCarregamento(string texto, int repeticao, string simbulo)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write($">>{texto}");

            for (var i = 0; i < repeticao; i++)
            {
                Thread.Sleep(300);
                Console.Write($"{simbulo}");
            }

            Console.Write($"!");
            Thread.Sleep(1000);
            Console.ResetColor();
        }
    }
}