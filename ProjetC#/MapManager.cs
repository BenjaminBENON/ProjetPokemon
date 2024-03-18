using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class MapManager
{
    public static void OnEnterMap()
    {
        DisplayMap();
    }
    private static void DisplayMap()
    {
        Console.WriteLine("Vous êtes sur la carte.");
        Console.WriteLine("1. Combattre");
        Console.WriteLine("2. Retourner au menu");

        Console.Write("Choix : ");
    }

    public static void SwitchFromMap(Game oGame)
    {
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                oGame.SetState(State.OnFight);
                Console.Clear();
                break;
            case "2":
                oGame.SetState(State.GameMenu);
                Console.Clear();
                GameMenu.OnEnterGameMenu();
                break;
            default:
                Console.WriteLine("Choix invalide.");
                break;
        }
    }
}

