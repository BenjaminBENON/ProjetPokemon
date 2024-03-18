using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class GameMenu
{
    public static void OnEnterGameMenu()
    {
        DisplayMenu();
    }
    private static void DisplayMenu()
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        //texte MENU
        string textMenu = "=== MENU ===";
        int xPosition = (windowWidth - textMenu.Length) / 2;
        Console.SetCursorPosition(xPosition, 3);
        Console.WriteLine("|" + textMenu + "|");
        Console.SetCursorPosition(xPosition + 1, 2);
        Console.WriteLine("------------");
        Console.SetCursorPosition(xPosition + 1, 4);
        Console.WriteLine("------------");

        //texte JOUER
        string textJeu = "=== PLAY ===";
        Console.SetCursorPosition(windowWidth/3 - 10 , 18);
        Console.WriteLine("|  " + textJeu + "  |");
        Console.SetCursorPosition(windowWidth / 3 - 10 , 17);
        Console.WriteLine("|                |");
        Console.SetCursorPosition(windowWidth / 3 - 10 , 16);
        Console.WriteLine("------------------");
        Console.SetCursorPosition(windowWidth / 3 - 10 , 19);
        Console.WriteLine("|                |");
        Console.SetCursorPosition(windowWidth / 3 - 10 , 20);
        Console.WriteLine("------------------");

        //texte Quitter
        string textOut = "=== QUIT ===";
        Console.SetCursorPosition(2 * windowWidth / 3, 18);
        Console.WriteLine("|  " + textOut + "  |");
        Console.SetCursorPosition(2 * windowWidth / 3, 17);
        Console.WriteLine("|                |");
        Console.SetCursorPosition(2 * windowWidth / 3, 16);
        Console.WriteLine("------------------");
        Console.SetCursorPosition(2 * windowWidth / 3, 19);
        Console.WriteLine("|                |");
        Console.SetCursorPosition(2 * windowWidth / 3, 20);
        Console.WriteLine("------------------");
    }

    public static void SelectChoice(Game oGame)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("1. Jouer");
        Console.WriteLine("2. Quitter");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                oGame.SetState(State.OnMap);
                Console.Clear();
                MapManager.OnEnterMap();
                break;
            case "2":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Choix invalide.");
                break;
        }

    }
}

