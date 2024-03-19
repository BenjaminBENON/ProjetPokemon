using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum GameStates
{
    GameMenu,
    Inventory,
    PokemonMenu,
    OnMap,
    OnFight
}

public class Game
{
    private GameStates currentState;

    public Game()
    {
        currentState = GameStates.GameMenu;
    }

    public void Start()
    {
        Run();
    }

    public void Run()
    {
        switch (currentState)
        {
            case GameStates.GameMenu:
                DisplayMenu();
                break;
            case GameStates.OnMap:
                StartMap();
                break;
            case GameStates.OnFight:
                StartFight();
                break;
            default:
                Console.WriteLine("État du jeu non géré.");
                break;
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("=== MENU ===");
        Console.WriteLine("1. Jouer");
        Console.WriteLine("2. Quitter");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameStates> stateTransitions = new Dictionary<int, GameStates>
        {
            { 1, GameStates.OnMap },
            { 2, GameStates.GameMenu }
        };

        UpdateState(choice, stateTransitions);
    }

    private void StartMap()
    {
        Console.WriteLine("Vous êtes sur la carte.");
        Console.WriteLine("1. Combattre");
        Console.WriteLine("2. Retourner au menu");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameStates> stateTransitions = new Dictionary<int, GameStates>
        {
            { 1, GameStates.OnFight },
            { 2, GameStates.GameMenu }
        };

        UpdateState(choice, stateTransitions);
    }

    private void StartFight()
    {
        Console.WriteLine("Combat en cours...");

        // LE fiiiiiiight;

        Console.WriteLine("Combat terminé.");

        currentState = GameStates.OnMap;
    }

    private void UpdateState(string choice, Dictionary<int, GameStates> transitionArray)
    {
        int option;
        int.TryParse(choice, out option);
        foreach (var item in transitionArray)
        {
            if (item.Key == option)
            {
                currentState = item.Value;
                return; 
            }
        }
    }
}

