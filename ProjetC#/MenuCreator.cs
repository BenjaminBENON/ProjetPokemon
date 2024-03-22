using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetC_
{
    internal class MenuCreator
    {
        public static void CreateMenu(string name, int nbCase, List<string> caseName) 
        {
            if (caseName.Count != nbCase || nbCase < 2)
            {
                Console.WriteLine("Erreur dans la création de menu.");
                return;
            }

            int nb2 = nbCase / 2;

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("============" + name + "============");

            int posX = Console.WindowWidth / (nb2 + 2) ;
            int posY = Console.WindowHeight / 3;
            for (int i  = 0; i < nb2; i++)
            {
                Console.SetCursorPosition((i+1)*(posX - caseName[i].Length/2),posY - 1);
                Console.Write(caseName[i]);
            }
            for (int i = nb2; i < nbCase; i++)
            {
                Console.SetCursorPosition((i - nb2 + 1) * (posX - caseName[i].Length / 2), 2*posY - 1);
                Console.Write(caseName[i]);
            }
        }
    }
}
