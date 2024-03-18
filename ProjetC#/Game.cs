using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


public enum State
{
    GameMenu,
    Inventory,
    PokemonMenu,
    OnMap,
    OnFight
}

public class Game
{
    private State currentState;

    public Game()
    {
        currentState = State.GameMenu;
        GameMenu.OnEnterGameMenu();
    }

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Start()
    {
        switch (currentState)
        {
            case State.GameMenu:
                GameMenu.SelectChoice(this);
                break;
            case State.OnMap:
                StartMap();
                break;
            case State.OnFight:
                StartFight();
                break;
            default:
                Console.WriteLine("État du jeu non géré.");
                break;
        }
    }


    private void StartMap()
    {
        Console.WriteLine("Vous êtes sur la carte.");
        Console.WriteLine("1. Combattre");
        Console.WriteLine("2. Retourner au menu");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                currentState = State.OnFight;
                break;
            case "2":
                currentState = State.GameMenu;
                Console.Clear();
                GameMenu.OnEnterGameMenu();
                break;
            default:
                Console.WriteLine("Choix invalide.");
                break;
        }
    }

    private void StartFight()
    {
        Console.WriteLine("Combat en cours...");
        // LE fiiiiiiight;
        Console.WriteLine("Combat terminé.");

        currentState = State.OnMap;
    }
}

