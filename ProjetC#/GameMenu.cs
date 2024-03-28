
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;



public class GameMenu
{
    private static int m_userChoice = 1;
    private static int m_ItemSelect = 1;


    //private struct StartMenuLabels
    //{
    //    public string PlayText;
    //    public string GameManagementText;
    //    public string LeaveText;

    //    public StartMenuLabels()
    //    {
    //        // si d�ja une partie, texte -> "Continuer la partie actuelle / Jouer"
    //        PlayText = "Commencer le jeu";
    //        // si d�ja une partie, texte -> "G�rer les sauvegardes"
    //        GameManagementText = "Cr�er une partie";
    //        LeaveText = "Quitter le jeu";
    //    }
    //}

    public static void OnEnterGameMenu()
    {
        Display_StartMenu();
    }

    private static void Display_StartMenu()
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        //texte MENU
        string textMenu = "=== MENU ===";
        int xPosition = (windowWidth - textMenu.Length) / 2;
        Console.SetCursorPosition(xPosition, windowHeight / 3);
        Console.WriteLine("|" + textMenu + "|");
        Console.SetCursorPosition(xPosition + 1, windowHeight / 3 - 1);
        Console.WriteLine("------------");
        Console.SetCursorPosition(xPosition + 1, windowHeight / 3 + 1);
        Console.WriteLine("------------");

        //texte JOUER
        string textJeu = "=== NEW GAME ===";
        Console.SetCursorPosition(windowWidth / 4 - 20, 2 * windowHeight / 3);
        Console.WriteLine("|  " + textJeu + "  |");
        Console.SetCursorPosition(windowWidth / 4 - 20, 2 * windowHeight / 3 - 1);
        Console.WriteLine("|                    |");
        Console.SetCursorPosition(windowWidth / 4 - 20, 2 * windowHeight / 3 - 2);
        Console.WriteLine("----------------------");
        Console.SetCursorPosition(windowWidth / 4 - 20, 2 * windowHeight / 3 + 1);
        if (m_userChoice==1) Console.WriteLine("|          1         |");
        else Console.WriteLine("|                    |");
        Console.SetCursorPosition(windowWidth / 4 - 20, 2 * windowHeight / 3 + 2);
        Console.WriteLine("----------------------");

        //texte JOUER
        string textSave = "=== CONTINUE ===";
        Console.SetCursorPosition(windowWidth / 2 - 10, 2 * windowHeight / 3);
        Console.WriteLine("|  " + textSave + "  |");
        Console.SetCursorPosition(windowWidth / 2 - 10, 2 * windowHeight / 3 - 1);
        Console.WriteLine("|                    |");
        Console.SetCursorPosition(windowWidth / 2 - 10, 2 * windowHeight / 3 - 2);
        Console.WriteLine("----------------------");
        Console.SetCursorPosition(windowWidth / 2 - 10, 2 * windowHeight / 3 + 1);
        if (m_userChoice == 2) Console.WriteLine("|          2         |");
        else Console.WriteLine("|                    |");
        Console.SetCursorPosition(windowWidth / 2 - 10, 2 * windowHeight / 3 + 2);
        Console.WriteLine("----------------------");

        //texte Quitter
        string textOut = "=== QUIT ===";
        Console.SetCursorPosition(3 * windowWidth / 4, 2 * windowHeight / 3);
        Console.WriteLine("|  " + textOut + "  |");
        Console.SetCursorPosition(3 * windowWidth / 4, 2 * windowHeight / 3 - 1);
        Console.WriteLine("|                |");
        Console.SetCursorPosition(3 * windowWidth / 4, 2 * windowHeight / 3 - 2);
        Console.WriteLine("------------------");
        Console.SetCursorPosition(3 * windowWidth / 4, 2 * windowHeight / 3 + 1);
        if (m_userChoice == 3) Console.WriteLine("|        3       |");
        else Console.WriteLine("|                |");
        Console.SetCursorPosition(3 * windowWidth / 4, 2 * windowHeight / 3 + 2);
        Console.WriteLine("------------------");
    }

    public static void StartChoice(Game oGame)
    {

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.CharacterCreationMenu },
            { 2, GameMenuStates.InSaveMenu },
            { 3, GameMenuStates.ShutDown }
        };

        ConsoleKey a = Console.ReadKey(true).Key;
        switch (a)
        {
            case ConsoleKey.Enter:
                Console.Clear();
                oGame.UpdateCurrentGameState(m_userChoice, stateTransitions);
                break;
            case ConsoleKey.RightArrow:
                m_userChoice++;
                break;
            case ConsoleKey.LeftArrow:
                m_userChoice--;
                break;
        }
        if (m_userChoice > 3) m_userChoice = 3;
        if (m_userChoice < 1) m_userChoice = 1;
    }

    public static void CharacterMenu(Game oGame)
    {
        Console.CursorTop = 1;
        Console.WriteLine("=== CREATION DE PERSONNAGE ===");
        Console.Write("Nom de votre personnage : ");
        // character name
        string cName = Console.ReadLine();
        Console.Write("Votre personnage " + cName + " est d�sormais disponible . Appuyer sur Entrer pour continuer.");

        oGame.SetCharacterName(cName);
        //EntrySave(cName);

        ConsoleKey a = Console.ReadKey(true).Key;
        if (a == ConsoleKey.Enter)
        {
            Console.Clear();
            oGame.UpdateCurrentGameState(GameMenuStates.OnMap);
        }
    }


    public static void Display_InventoryMenu(Character p)
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        int xPosition = (windowWidth) / 2 - 45;
        int yPosition = (windowHeight / 6) * 4;

        var objList = p.GetObjectList();

        var listInventory = new List<string>();
        foreach (var item in objList)
        {
            listInventory.Add(item.Name);
        }

        int selectedItem = MenuCreator.SelectItemInMenu(listInventory);
        MenuCreator.CreateMenu(xPosition,yPosition,"INVENTORY", listInventory.Count, listInventory);

        for (int y = 0; y < 20; y++)
        {
            Console.SetCursorPosition(windowWidth / 2 - 50, yPosition + y);
            Console.Write("|");
            Console.SetCursorPosition(windowWidth / 2 + 50, yPosition + y);
            Console.WriteLine("|");
        }
    }

    public static void Display_PokemonMenu(Character p)
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        int xPosition = (windowWidth) / 2 - 45;
        int yPosition = (windowHeight / 6) * 4;

        var pokList = p.GetPokemonList();

        var listInventory = new List<string>();
        foreach (var pok in pokList)
        {
            listInventory.Add(pok.Name + " : " + pok.PokemonState.ToString());
        }

        int selectedItem = MenuCreator.SelectItemInMenu(listInventory);
        MenuCreator.CreateMenu(xPosition, yPosition, "MY POKEMONS", listInventory.Count, listInventory);

        for (int y = 0; y < 20; y++)
        {
            Console.SetCursorPosition(windowWidth / 2 - 50, yPosition + y);
            Console.Write("|");
            Console.SetCursorPosition(windowWidth / 2 + 50, yPosition + y);
            Console.WriteLine("|");
        }

    }

    public static void Display_SaveMenu(Game oGame)
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        int xPosition = (windowWidth) / 2 - 45;
        int yPosition = (windowHeight / 6) * 4;

        var list = new List<string>();
        
        int nbSave = Save.getNbSave();
        list.Add("DEFAULT SAVE");
        if (nbSave > 1)
        {
            for (int i = 0; i < nbSave -1; i++)
            {
                list.Add("SAVE " + (i+1).ToString());
            }
        }

        for (int y = 0; y < 25; y++)
        {
            Console.SetCursorPosition(45, y + 3);
            Console.Write("|");
            Console.SetCursorPosition(165, y + 3);
            Console.WriteLine("|");
        }

        int selectedSave = MenuCreator.SelectItemInMenu(list);
        MenuCreator.CreateMenu(50, 3, "SAVE MENU", list.Count, list);

        if (selectedSave >= 0)
        {
            SaveShape loadedSave = Save.ReadSave(selectedSave);
            if (loadedSave != null)
            {
                string name = loadedSave.SaveId;
                oGame.SetCharacterName(name);
                oGame.SetCharacterPos(loadedSave.PosXPlayer, loadedSave.PosYPlayer);
                oGame.SetCharacterPokemons(loadedSave.ListPokemon);
                oGame.SetCharacterItems(loadedSave.ListItem);
            }

            oGame.UpdateCurrentGameState(GameMenuStates.OnMap);
        }
    }

}
