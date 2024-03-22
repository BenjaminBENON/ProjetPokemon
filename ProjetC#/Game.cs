﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Xml.Linq;

// #TODO -> NPC pour combat | Market pour acheter consommable | IA Pokemon enemy | Quete / Entity Management pour les npc / coffre / pokemons sauvage / Regarder la carte de son pokemon

// Random pokemon generator qui start des fight 

// Gerer si combat sauvage ou combat dresseur / Gerer pokeball ? 

// faire un beau design pour le fight -> pokemon 1 a gauche -> pokemon 2 a droite - Log au milieu


// Réorganiser Le fight *************
// Update les effects durant avant l'attaque *************

// Implement Poison / Stun / Object add stat 

public enum GameMenuStates
{
    InGameMenu, // Start Menu
    InInventoryMenu, // Manage Object & Pokemon
    InPokedexMenu, // Discover Pokemons of current Character
    InSaveMenu, // Save Menu -> ShowBackupList | Button Add | Button Delete
    OnMap, // In Open world | Can move | Can Interact and Trigger Fight
    InPokemonCenter,
    OnFight, // In fight world | To think

    // Subtypes (Type can be only call by a Type only) | Next can be move in more generic approch

    Inventory_ShowPokemons,
    Inventory_ShowObjects,

    Pokedex_ShowDiscoverPokemon,

    Save_AddMenu, // Menu to add a party

    // Play Button Redirect on Character Creation if no character in save 
    CharacterCreationMenu,

    ShutDown //Fin du jeu pour quitter la fenêtre

}


public class Game
{ 
    //---------------------------LES CHAMPS------------------------

    // Game Data One part will be in the save
    private GameMenuStates currentGameState;
    private Character currentCharacter;
    private Character botCharacter;

    private Dictionary<GameMenuStates, Action> bindFunctionsToGameMenuStates;


    //---------------------------LES METHODES-----------------------

    public Game()
    {
        currentGameState = GameMenuStates.InGameMenu;
        
        // Generate multiple opponent / enemy
        botCharacter = new Character("Bot");


    }

    public void Start()
    {
        botCharacter = new Character("Bot");
        currentCharacter = new Character("William");

        Potion potion30 = new Potion("potion30", 30);
        Berry berryHelp = new Berry("baieSoin");
        Pokeball pokeBall = new Pokeball("Poke Ball");

        currentCharacter.AddObject(potion30);
        currentCharacter.AddObject(berryHelp);
        currentCharacter.AddObject(pokeBall);

        float[] resPlant = { 1, 2, 0.5f, 1, 0.8f };   // Plante
        float[] resWater = { 1, 1, 0.8f, 1, 0.5f };   // Eau
        float[] resFire = { 1, 0.5f, 1, 1, 1 };       // Feu
        float[] resNormal = { 1, 1, 1, 1, 1 };       // Normal
        float[] resElectric = { 1, 2, 1, 1, 1 };     // Électrique

        Pokemon bulbizarre = new Pokemon("Bulbizarre", PokemonType.Plant, 45, 49, 49, 65, 99, 1, resPlant);
        Pokemon salameche = new Pokemon("Salamèche", PokemonType.Fire, 39, 52, 43, 60, 99, 2, resFire);
        Pokemon carapuce = new Pokemon("Carapuce", PokemonType.Water, 44, 48, 65, 50, 99, 2, resWater);
        Pokemon pikachu = new Pokemon("Pikachu", PokemonType.Electric, 35, 55, 40, 40, 99, 2, resElectric);

        // Ajout des attaques
        Attack fouetLianes = new VineWhip();
        Attack tranchHerbe = new RazorLeaf();
        Attack bombeGraine = new BubbleBeam();
        Attack lanceSoleil = new FireSpin();

        Attack griffe = new Tackle();
        Attack flammeche = new Ember();
        Attack lanceFlamme = new ThunderShock();
        Attack detonation = new QuickAttack();

        Attack defenseBoost = new DefenseBoost();
        Attack speedBoost = new SpeedBoost();
        Attack accuracyBoost = new AccuracyBoost();
        Attack evasionBoost = new EsquiveBoost();


        bulbizarre.AddAttack(fouetLianes);    // Physique
        bulbizarre.AddAttack(tranchHerbe);    // Physique
        bulbizarre.AddAttack(defenseBoost);   // Stat
        bulbizarre.AddAttack(speedBoost);     // Stat

        salameche.AddAttack(griffe);          // Physique
        salameche.AddAttack(flammeche);       // Physique
        salameche.AddAttack(accuracyBoost);   // Stat
        salameche.AddAttack(evasionBoost);    // Stat

        carapuce.AddAttack(bombeGraine);      // Physique
        carapuce.AddAttack(lanceSoleil);      // Physique
        carapuce.AddAttack(defenseBoost);     // Stat
        carapuce.AddAttack(speedBoost);       // Stat

        pikachu.AddAttack(lanceFlamme);       // Physique
        pikachu.AddAttack(detonation);        // Physique
        pikachu.AddAttack(accuracyBoost);     // Stat
        pikachu.AddAttack(evasionBoost);      // Stat

        List<Pokemon> enemyPokemonList = new List<Pokemon>();

        currentCharacter.AddPokemon(bulbizarre);
        currentCharacter.AddPokemon(salameche);

        enemyPokemonList.Add(carapuce);
        //enemyPokemonList.Add(pikachu);



        Fight fight = new Fight(currentCharacter, enemyPokemonList, FightType.SavagePokemon);

        //ConsoleUI consoleUI = new ConsoleUI();

        //// Ajouter des éléments à l'interface utilisateur
        //consoleUI.AddElement("Pokémon gauche", 5, 5); // Pokémon à gauche
        //consoleUI.AddElement("Pokémon droit", Console.WindowWidth - 15, 5); // Pokémon à droite
        //consoleUI.AddElement("Logs de combat", (Console.WindowWidth / 2) - 10, 10); // Logs de combat au milieu

        //// Dessiner l'interface utilisateur
        //consoleUI.DrawUI();

        //// Exemple de modification dynamique de l'interface utilisateur
        //System.Threading.Thread.Sleep(2000); // Attendre 2 secondes
        //consoleUI.AddElement("Combat en cours...", (Console.WindowWidth / 2) - 8, 10); // Modifier les logs de combat
        //consoleUI.DrawUI(); // Dessiner à nouveau pour voir les modifications

        //Console.ReadKey();

        Thread.Sleep(300000000);

        bindFunctionsToGameMenuStates = new Dictionary<GameMenuStates, Action> {
            // Game Menus
            { GameMenuStates.InGameMenu, StartMenu },
            { GameMenuStates.CharacterCreationMenu, CharacterCreationMenu },
            // Inventory Menus
            { GameMenuStates.InInventoryMenu, Display_Inventory_Menu },
            { GameMenuStates.Inventory_ShowPokemons, Display_Inventory_PokemonsMenu },
            { GameMenuStates.Inventory_ShowObjects, Display_Inventory_ObjectsMenu },
            
            // Pokedex Menus
            { GameMenuStates.InPokedexMenu, Display_Pokedex_Menu },
            // Save Menus
            { GameMenuStates.InSaveMenu, Display_Save_Menu },
            { GameMenuStates.Save_AddMenu, Display_Save_AddMenu },
            // Play Menu | No sub type
            { GameMenuStates.OnMap, StartMap },
            { GameMenuStates.InPokemonCenter, StartPokemonCenter },
            { GameMenuStates.OnFight, Play_Fight },
            { GameMenuStates.ShutDown, Quit }
        };

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

    private void Quit()
    {
        Environment.Exit(0);
    }

    public void SetCharacterName(string cName)
    {
        currentCharacter = new Character(cName);
    }

    private void StartMenu()
    {   
        Console.Clear();
        GameMenu.OnEnterGameMenu();
        GameMenu.StartChoice(this);
    }
    private void CharacterCreationMenu()
    {
        Console.Clear();
        GameMenu.CharacterMenu(this);
    }
    private void StartMap()
    {
        Map.Play_Map(this,botCharacter); 
        Input.Update(botCharacter);
        Console.CursorVisible = false;
    }
    private void StartPokemonCenter()
    {
        
    }


    //------------------------LES INVENTAIRES---------------------

    private void Display_Inventory_Menu()
    {
        Console.WriteLine("=== MENU D'INVENTAIRE ===");

        Console.WriteLine("1. Afficher les Pokémons"); // Show all caught pokemon
        Console.WriteLine("2. Afficher les Objets"); // Show all caught objects
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

    private void Display_Inventory_PokemonsMenu()
    {
        Console.WriteLine("Voici tout vos pokemons"); // Show all caught pokemon
    }

    private void Display_Inventory_ObjectsMenu()
    {
        Console.WriteLine("Voici tout vos objets"); // Show all caught objects
    }

    private void Display_Pokedex_Menu()
    {
        Console.WriteLine("=== MENU DU POKEDEX ===");

        Console.WriteLine("1. Découvrir les Pokémons découvert"); // Show all current character Discovered Pokemons
        Console.WriteLine("2. Retourner au menu principal");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        // #TO REMEMBER -> THE CHOICE STATE is RELATIF, we need UpdateCurrentGameState to adapt our choice to global Menus States
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

        Console.WriteLine("1. Ajouter une nouvelle sauvegarde");
        Console.WriteLine("Supprimer une partie"); // Show all save and allow choice to delete
        Console.WriteLine("Voir les parties sauvegardées"); // Show all save 
        Console.WriteLine("2.Retourner au menu principal");

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
        Console.Write("Nom de de votre partie : ");
        // save name
        string name = Console.ReadLine();

        Console.Write("Votre partie : " + name + " est désormais disponible");

        currentGameState = GameMenuStates.InGameMenu;
    }


    private void Play_Fight()
    {
        currentGameState = GameMenuStates.OnMap;
    }

    public void UpdateCurrentGameState(string choice, Dictionary<int, GameMenuStates> transitionArray)
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
    public void UpdateCurrentGameState(int choice, Dictionary<int, GameMenuStates> transitionArray)
    {
        foreach (var item in transitionArray)
        {
            if (item.Key == choice)
            {
                currentGameState = item.Value;
                return;
            }
        }
    }
    public void UpdateCurrentGameState(GameMenuStates state)
    {
        currentGameState = state;
    }
}

