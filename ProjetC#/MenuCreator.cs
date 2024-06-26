﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


public class MenuCreator
{
    private static int m_userChoiceInMenu = 1;

    public static void CreateMenu(int posX, int posY, string name, int nbCase, List<string> caseName)
    {

        if (caseName.Count != nbCase || nbCase < 0)
        {
            Console.WriteLine("Erreur dans la création de menu.");
            throw new Exception("Erreur dans la création de menu.");
        }

        Console.SetCursorPosition(posX, posY);
        Console.WriteLine("|======" + name + "======|");
        int sizeName = name.Length;
        Console.SetCursorPosition(posX, posY - 1);
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

        if (nbCase < 6 && nbCase > 0)
        {
            int nb2 = nbCase / 2 + (nbCase % 2);
            int Size = Console.WindowWidth - posX * 2;

            for (int i = 0; i < nb2; i++)
            {
                int sizeCaseName = caseName[i].Length;
                Console.SetCursorPosition(posX + (i + 1) * (Size / (nb2 + 1)), posY + 5);
                Console.Write("|" + caseName[i] + "|");
                if (m_userChoiceInMenu == i + 1) Console.Write("<");
                if (m_userChoiceInMenu != i + 1) Console.Write(" ");
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
                if (m_userChoiceInMenu == i + 1) Console.Write("<");
                if (m_userChoiceInMenu != i + 1) Console.Write(" ");
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

            for (int i = 0; i < nb3; i++)
            {
                int sizeCaseName = caseName[i].Length;
                Console.SetCursorPosition(posX + (i + 1) * (Size / (nb3 + 1)), posY + 5);
                Console.Write("|" + caseName[i] + "|");
                if (m_userChoiceInMenu == i + 1) Console.Write("<");
                if (m_userChoiceInMenu != i + 1) Console.Write(" ");
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
                if (m_userChoiceInMenu == i + 1) Console.Write("<");
                if (m_userChoiceInMenu != i + 1) Console.Write(" ");
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
                if (m_userChoiceInMenu == i + 1) Console.Write("<");
                if (m_userChoiceInMenu != i + 1) Console.Write(" ");
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

    public static int SelectItemInMenu(List<string> list)
    {
        int sizeMenu = list.Count;

        ConsoleKey a = Input.KeyPress.Key;

        switch (a)
        {
            case ConsoleKey.Enter:
                return m_userChoiceInMenu - 1;
            case ConsoleKey.RightArrow:
                m_userChoiceInMenu++;
                break;
            case ConsoleKey.LeftArrow:
                m_userChoiceInMenu--;
                break;
        }
        if (m_userChoiceInMenu > sizeMenu) m_userChoiceInMenu = sizeMenu;
        if (m_userChoiceInMenu < 1) m_userChoiceInMenu = 1;

        return -1;
    }
}
