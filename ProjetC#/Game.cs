﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetC_;
using System.ComponentModel;


public enum GameMenuStates
{
    InGameMenu, // Start Menu
    InInventoryMenu, // Manage Object & Pokemon
    InPokedexMenu, // Discover Pokemons of current Character
    InSaveMenu, // Save Menu -> ShowBackupList | Button Add | Button Delete
    OnMap, // In Open world | Can move | Can Interact and Trigger Fight
    OnFight, // In fight world | To think

    // Subtypes (Type can be only call by a Type only) | Next can be move in more generic approch

    Inventory_ShowPokemons,
    Inventory_ShowObjects,

    Pokedex_ShowDiscoverPokemon,

    Save_AddMenu, // Menu to add a party

    // Play Button Redirect on Character Creation if no character in save 
    Game_CharacterCreationMenu,



}

// HUD Part, Can be draw in same time

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


    // Game Data One part will be in the save
    private GameMenuStates currentGameState;
    private Character currentCharacter;
    private Character botCharacter;

    private Dictionary<GameMenuStates, Action> bindFunctionsToGameMenuStates;

    public Game()
    {
        currentGameState = GameMenuStates.InGameMenu;

        // Generate multiple opponent / enemy
        botCharacter = new Character("Bot");
    }

    public void Start()
    {
        bindFunctionsToGameMenuStates = new Dictionary<GameMenuStates, Action>
        {
            // Function NameStyle -> Display / Play * _ * SubType * _ * MenuName
            { GameMenuStates.InGameMenu, Display_StartMenu },
            { GameMenuStates.InInventoryMenu, Display_Inventory_Menu },
            { GameMenuStates.InPokedexMenu, Display_Pokedex_Menu },
            { GameMenuStates.InSaveMenu, Display_Save_Menu },
            { GameMenuStates.OnMap, Play_Map },
            { GameMenuStates.OnFight, Play_Fight },
            { GameMenuStates.Game_CharacterCreationMenu, Display_Game_CharacterCreationMenu }
        };
        Run();
    }
    public void Run()
    {
        foreach (var item in bindFunctionsToGameMenuStates)
        {
            if (item.Key == currentGameState)
            {
                item.Value.Invoke();
                return;
            }
        }
    }

    private void Display_StartMenu()
    {
        Console.WriteLine("=== MENU DE DEPART ===");
        Console.WriteLine("1. Jouer");
        Console.WriteLine("2. Créer une nouvelle partie");
        Console.WriteLine("3. Quitter");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        // Next State when you click Play
        GameMenuStates nextPlayState = GameMenuStates.Game_CharacterCreationMenu; // Can be On map || Character Creation

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, nextPlayState },
            { 2, GameMenuStates.InGameMenu } // Leave
        };

        UpdateCurrentGameState(choice, stateTransitions);
    }

    private void Display_Game_CharacterCreationMenu()
    {
        Console.WriteLine("=== CREATION DE PERSONNAGE ===");
        Console.Write("Nom de votre personnage : ");
        // character name
        string cName = Console.ReadLine();
        Console.Write("Votre personnage " + cName + " est désormais disponible");
        currentCharacter = new Character(cName);

        currentGameState = GameMenuStates.OnMap;
    }

    private void Display_Inventory_Menu()
    {
        Console.WriteLine("=== MENU D'INVENTAIRE ===");
        Console.WriteLine("1. Afficher les Pokémons");
        Console.WriteLine("2. Afficher les Objets");
        Console.WriteLine("3. Retourner au menu principal");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.Inventory_ShowPokemons },
            { 2, GameMenuStates.Inventory_ShowObjects },
            { 3, GameMenuStates.InGameMenu }
        };

        UpdateCurrentGameState(choice, stateTransitions);
    }

    private void Display_Pokedex_Menu()
    {
        Console.WriteLine("=== MENU DU POKEDEX ===");
        Console.WriteLine("1. Découvrir les Pokémons");
        Console.WriteLine("2. Retourner au menu principal");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.Pokedex_ShowDiscoverPokemon },
            { 2, GameMenuStates.InGameMenu }
        };

        UpdateCurrentGameState(choice, stateTransitions);
    }

    private void Display_Save_Menu()
    {
        Console.WriteLine("=== MENU DE SAUVEGARDE ===");
        Console.WriteLine("Ajouter une nouvelle partie");
        Console.WriteLine("Supprimer une partie");
        Console.WriteLine("Voir les parties sauvegardées");
        Console.WriteLine("Retourner au menu principal");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.Save_AddMenu },
            { 2, GameMenuStates.InGameMenu }
        };

        UpdateCurrentGameState(choice, stateTransitions);
    }


    private void Display_Save_AddMenu()
    {
        Console.WriteLine("=== AJOUTER UNE SAUVEGARDE ===");
        Console.WriteLine("Ajouter une nouvelle partie");
        Console.WriteLine("Retourner au menu principal");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
    {
        { 1, GameMenuStates.Game_CharacterCreationMenu },
        { 2, GameMenuStates.InGameMenu }
    };

        UpdateCurrentGameState(choice, stateTransitions);
    }


    private void Play_Map()
    {
        Console.WriteLine("Vous êtes sur la carte.");
        Console.WriteLine("1. Combattre");
        Console.WriteLine("2. Retourner au menu");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.OnFight },
            { 2, GameMenuStates.InGameMenu }
        };

        UpdateCurrentGameState(choice, stateTransitions);
    }

    private void Play_Fight()
    {

        Fight fight = new Fight(currentCharacter, botCharacter);

        currentGameState = GameMenuStates.OnMap;
    }

    private void UpdateCurrentGameState(string choice, Dictionary<int, GameMenuStates> transitionArray)
    {
        int option;
        int.TryParse(choice, out option);
        foreach (var item in transitionArray)
        {
            if (item.Key == option)
            {
                currentGameState = item.Value;
                return; 
            }
        }
    }
}

