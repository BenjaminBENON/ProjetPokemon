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
        string textMenu = "=== MENU ===";

        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;
        int xPosition = (windowWidth - textMenu.Length) / 2;
        Console.SetCursorPosition(xPosition, 3);
        Console.WriteLine("|" + textMenu + "|");
        Console.SetCursorPosition(xPosition + 1, 2);
        Console.WriteLine("------------");
        Console.SetCursorPosition(xPosition + 1, 4);
        Console.WriteLine("------------");

        //Console.Write("Choix : ");
        //string choice = Console.ReadLine();

        //switch (choice)
        //{
        //    case "1":
        //        currentState = State.OnMap;
        //        break;
        //    case "2":
        //        Environment.Exit(0);
        //        break;
        //    default:
        //        Console.WriteLine("Choix invalide.");
        //        break;
        //}
    }

    public static void SelectChoice(Game oGame)
    {
        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                oGame.SetState(State.OnMap);
                Console.Clear();
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

