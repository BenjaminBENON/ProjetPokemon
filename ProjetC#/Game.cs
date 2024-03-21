using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetC_;
using System.ComponentModel;
using System.Xml.Linq;

// #TODO -> NPC pour combat | Market pour acheter consommable | IA Pokemon enemy | Quete / Entity Management pour les npc / coffre / pokemons sauvage / Regarder la carte de son pokemon

// #TODO clément -> HUD System avec buffer pour organiser l'écran de jeu inventaire 
// Random pokemon generator qui start des fight 

// #TODO william -> Gestion des résistance - 

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
        PokeBall pokeBall = new PokeBall("Poke Ball");

        currentCharacter.AddObject(potion30);
        currentCharacter.AddObject(berryHelp);
        currentCharacter.AddObject(pokeBall);

        Pokemon bulbizarre = new Pokemon("Bulbizarre", "Plante", 45, 49, 49, 65, 65, 45);
        Pokemon salameche = new Pokemon("Salamèche", "Feu", 39, 52, 43, 60, 50, 65);
        Pokemon carapuce = new Pokemon("Carapuce", "Eau", 44, 48, 65, 50, 64, 43);
        Pokemon pikachu = new Pokemon("Pikachu", "Électrique", 35, 55, 40, 40, 50, 90);

        // Création des Attacks
        Attack fouetLianes = new VineWhip();
        Attack tranchHerbe = new RazorLeaf();
        Attack bombeGraine = new BubbleBeam();
        Attack lanceSoleil = new FireSpin();

        Attack griffe = new Tackle();
        Attack flammeche = new Ember();
        Attack lanceFlamme = new ThunderShock();
        Attack detonation = new QuickAttack();

        bulbizarre.AddAttack(fouetLianes);
        bulbizarre.AddAttack(tranchHerbe);
        bulbizarre.AddAttack(bombeGraine);
        bulbizarre.AddAttack(lanceSoleil);

        salameche.AddAttack(griffe);
        salameche.AddAttack(flammeche);
        salameche.AddAttack(lanceFlamme);
        salameche.AddAttack(detonation);

        carapuce.AddAttack(fouetLianes);
        carapuce.AddAttack(tranchHerbe);
        carapuce.AddAttack(bombeGraine);
        carapuce.AddAttack(lanceSoleil);

        pikachu.AddAttack(griffe);
        pikachu.AddAttack(flammeche);
        pikachu.AddAttack(lanceFlamme);
        pikachu.AddAttack(detonation);

        List<Pokemon> enemyPokemonList = new List<Pokemon>();

        currentCharacter.AddPokemon(bulbizarre);
        currentCharacter.AddPokemon(salameche);

        enemyPokemonList.Add(carapuce);
        enemyPokemonList.Add(pikachu);

        Fight fight = new Fight(currentCharacter, enemyPokemonList, "Trainer");

        Thread.Sleep(30000000);

        bindFunctionsToGameMenuStates = new Dictionary<GameMenuStates, Action> {
            // Game Menus
            { GameMenuStates.InGameMenu, StartMenu },
            { GameMenuStates.CharacterCreationMenu, CharacterCreationMenu },
            // Save Menus
            { GameMenuStates.InSaveMenu, SaveMenu },
            { GameMenuStates.Save_AddMenu, Display_Save_AddMenu },
            // Inventory Menus
            { GameMenuStates.InInventoryMenu, Display_Inventory_Menu },
            { GameMenuStates.Inventory_ShowPokemons, Display_Inventory_PokemonsMenu },
            { GameMenuStates.Inventory_ShowObjects, Display_Inventory_ObjectsMenu },
            
            // Pokedex Menus
            { GameMenuStates.InPokedexMenu, Display_Pokedex_Menu },
            // Play Menu
            { GameMenuStates.OnMap, StartMap },
            { GameMenuStates.InPokemonCenter, StartPokemonCenter },
            { GameMenuStates.OnFight, Play_Fight },

            { GameMenuStates.ShutDown, Quit }
        };

        // };
        Run();
    }
    private void Run()
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
        //Console.Clear();
        GameMenu.CharacterMenu(this);
    }
    private void StartMap()
    {
        //Console.Clear();
        Map.Play_Map(this);
    }
    private void SaveMenu()
    {
        Console.Clear();
        GameMenu.Display_SaveMenu();
        GameMenu.SaveChoice(this);
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

    //---------------------------


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

        //Fight fight = new Fight(currentCharacter, botCharacter);

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

