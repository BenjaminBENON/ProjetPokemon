using Microsoft.VisualBasic.FileIO;
using ProjetC_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum GameStates
{
    InGameMenu, // Start Menu
    InInventory, // Manage Object & Pokemon
    InPokedexMenu, // Discover Pokemons of current Character
    InSaveMenu, // Save Menu
    OnMap, // In Open world
    OnFight // In fight world                                                                                                            
}

public class Game
{
    private struct StartMenuLabels
    {
        public string PlayText;
        public string GameManagementText;
        public string LeaveText;

        public StartMenuLabels()
        {
            // si déja une partie, texte -> "Continuer la partie actuelle / Jouer"
            PlayText = "Commencer le jeu";
            // si déja une partie, texte -> "Gérer les sauvegardes"
            GameManagementText = "Créer une partie";
            LeaveText = "Quitter le jeu";
        }
    }

    private struct OnMapLabels
    {
        public string FightText;
        public string LeaveText;

        // Constructeur explicite pour initialiser les champs avec des valeurs par défaut
        public OnMapLabels()
        {
            FightText = "Combattre";
            LeaveText = "Quitter le monde ouvert";
        }
    }



    private GameStates currentState;

    public Game()
    {
        currentState = GameStates.InGameMenu;
    }

    public void Start()
    {
        Run();
    }

    public void Run()
    {
        switch (currentState)
        {
            case GameStates.InGameMenu:
                DisplayStartMenu();
                break;
            case GameStates.OnMap:
                PlayMap();
                break;
            case GameStates.OnFight:
                PlayFight();
                break;
            default:
                Console.WriteLine("État du jeu non géré.");
                break;
        }
    }

    private void DisplayStartMenu()
    {
        Console.WriteLine("=== MENU DE DEPART ===");
        Console.WriteLine("1. Jouer");
        Console.WriteLine("1. Créer une nouvelle partie");
        Console.WriteLine("2. Quitter");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameStates> stateTransitions = new Dictionary<int, GameStates>
        {
            { 1, GameStates.OnMap },
            { 2, GameStates.InGameMenu }
        };

        UpdateState(choice, stateTransitions);
    }

    private void DisplaySaveMenu()
    {
        Console.WriteLine("=== MENU DE SAUVEGARDE ===");
        Console.WriteLine("1. Afficher les sauvegardes de parties");
        Console.WriteLine("2. Quitter le menu de sauvegarde");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameStates> stateTransitions = new Dictionary<int, GameStates>
        {
            { 1, GameStates.OnMap },
            { 2, GameStates.InGameMenu }
        };

        UpdateState(choice, stateTransitions);
    }

    private void PlayMap()
    {
        Console.WriteLine("Vous êtes sur la carte.");
        Console.WriteLine("1. Combattre");
        Console.WriteLine("2. Retourner au menu");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameStates> stateTransitions = new Dictionary<int, GameStates>
        {
            { 1, GameStates.OnFight },
            { 2, GameStates.InGameMenu }
        };

        UpdateState(choice, stateTransitions);
    }

    private void PlayFight()
    {
        Character character = new Character();
        Character character2 = new Character();

        Fight fight = new Fight(character, character2);

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

