using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetC_
{
    internal class MenuCreator
    {
        public static void CreateMenu(int posX,int posY, string name, int nbCase, List<string> caseName) 
        {
            if (caseName.Count != nbCase || nbCase < 3)
            {
                Console.WriteLine("Erreur dans la création de menu.");
                return;
            }

            Console.SetCursorPosition(posX, posY);
            Console.WriteLine("|======" + name + "======|");
            int sizeName = name.Length;
            Console.SetCursorPosition(posX , posY -1);
            Console.Write("-------");
            for (int i = 0; i < sizeName; i++)
            {
                Console.Write("-");
            }
            Console.Write("-------");
            Console.SetCursorPosition(posX, posY + 1);
            Console.Write("-------");
            for (int i = 0; i < sizeName; i++)
            {
                Console.Write("-");
            }
            Console.Write("-------");

            if (nbCase < 6)
            {
                int nb2 = nbCase / 2 + (nbCase % 2);
                int Size = Console.WindowWidth - posX * 2;

                int posCaseX = Console.WindowWidth / (nb2 + 2);
                int posCaseY = Console.WindowHeight / 3;

                for (int i = 0; i < nb2; i++)
                {
                    int sizeCaseName = caseName[i].Length;
                    Console.SetCursorPosition(posX + (i + 1) * (Size / (nb2 + 1)), posY + 5);
                    Console.Write("|" + caseName[i] + "|");
                    Console.SetCursorPosition(posX + (i + 1) * (Size / (nb2 + 1)), posY + 4);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(posX + (i + 1) * (Size / (nb2 + 1)), posY + 6);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                }
                for (int i = nb2; i < nbCase; i++)
                {
                    int sizeCaseName = caseName[i].Length;
                    Console.SetCursorPosition(posX + (i - nb2 + 1) * (Size / (nb2 + 1)), posY + 10);
                    Console.Write("|" + caseName[i] + "|");
                    Console.SetCursorPosition(posX + (i - nb2 + 1) * (Size / (nb2 + 1)), posY + 9);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(posX + (i - nb2 + 1) * (Size / (nb2 + 1)), posY + 11);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                }
            }
            else
            {

                int nb3 = nbCase / 3 + (nbCase % 3);
                int Size = Console.WindowWidth - posX * 2;

                int posCaseX = Console.WindowWidth / (nb3 + 2);
                int posCaseY = Console.WindowHeight / 3;
                for (int i = 0; i < nb3; i++)
                {
                    int sizeCaseName = caseName[i].Length;
                    Console.SetCursorPosition(posX + (i + 1) * (Size / (nb3 + 1)), posY + 5);
                    Console.Write("|" + caseName[i] + "|");
                    Console.SetCursorPosition(posX + (i + 1) * (Size / (nb3 + 1)), posY + 4);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(posX + (i + 1) * (Size / (nb3 + 1)), posY + 6);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                }
                for (int i = nb3; i < 2 * nb3; i++)
                {
                    int sizeCaseName = caseName[i].Length;
                    Console.SetCursorPosition(posX + (i - nb3 + 1) * (Size / (nb3 + 1)), posY + 10);
                    Console.Write("|" + caseName[i] + "|");
                    Console.SetCursorPosition(posX + (i - nb3 + 1) * (Size / (nb3 + 1)), posY + 9);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(posX + (i - nb3 + 1) * (Size / (nb3 + 1)), posY + 11);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                }
                for (int i = 2 * nb3; i < nbCase; i++)
                {
                    int sizeCaseName = caseName[i].Length;
                    Console.SetCursorPosition(posX + (i - 2 * nb3 + 1) * (Size / (nb3 + 1)), posY + 15);
                    Console.Write("|" + caseName[i] + "|");
                    Console.SetCursorPosition(posX + (i - 2 * nb3 + 1) * (Size / (nb3 + 1)), posY + 14);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(posX + (i - 2 * nb3 + 1) * (Size / (nb3 + 1)), posY + 16);
                    for (int j = 0; j < sizeCaseName + 2; j++)
                    {
                        Console.Write("-");
                    }
                }
            }
        }
    }
}
