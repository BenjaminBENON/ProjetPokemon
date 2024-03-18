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

    public void Play()
    {
        switch (currentState)
        {
            case State.GameMenu:
                GameMenu.SelectChoice(this);
                break;
            case State.OnMap:
                MapManager.SwitchFromMap(this);
                break;
            case State.OnFight:
                StartFight();
                break;
            default:
                Console.WriteLine("État du jeu non géré.");
                break;
        }
    }

    private void StartFight()
    {
        Console.WriteLine("Combat en cours...");
        // LE fiiiiiiight;
        Console.WriteLine("Combat terminé.");

        currentState = State.OnMap;
        //Console.Clear();
        MapManager.OnEnterMap();
    }
}

