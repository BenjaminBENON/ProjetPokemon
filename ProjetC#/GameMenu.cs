using ProjetC_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    //        // si déja une partie, texte -> "Continuer la partie actuelle / Jouer"
    //        PlayText = "Commencer le jeu";
    //        // si déja une partie, texte -> "Gérer les sauvegardes"
    //        GameManagementText = "Créer une partie";
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
            { 2, GameMenuStates.OnMap },
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
        Console.Write("Votre personnage " + cName + " est désormais disponible");

        oGame.SetCharacterName(cName);

        oGame.UpdateCurrentGameState(GameMenuStates.OnMap);
    }
    public static void Display_InventoryMenu()
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        string textMenu = "=== INVENTORY ===";
        int xPosition = (windowWidth) / 2 - 45;
        int yPosition = (windowHeight / 6) * 4;

        Console.SetCursorPosition(xPosition, yPosition + 1);
        Console.WriteLine("|" + textMenu + "|");
        Console.SetCursorPosition(xPosition, yPosition);
        Console.WriteLine("-------------------");
        Console.SetCursorPosition(xPosition, yPosition + 2);
        Console.WriteLine("-------------------");

        for (int y = 0; y < 20; y++)
        {
            Console.SetCursorPosition(windowWidth/2 - 50, yPosition + y);
            Console.Write("|");
            Console.SetCursorPosition(windowWidth/2 + 50, yPosition + y);
            Console.WriteLine("|");
        }
        

    }
        public static void Display_SaveMenu()
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        //texte MENU SAVE
        string textMenu = "=== SAVE YOUR GAME ===";
        int xPosition = (windowWidth - textMenu.Length) / 2;
        Console.SetCursorPosition(xPosition, windowHeight / 6);
        Console.WriteLine("|" + textMenu + "|");
        Console.SetCursorPosition(xPosition, windowHeight / 6 - 1);
        Console.WriteLine("------------------------");
        Console.SetCursorPosition(xPosition, windowHeight / 6 + 1);
        Console.WriteLine("------------------------");

        //texte nouvelle save
        string textJeu = "=== NEW SAVE ===";
        Console.SetCursorPosition(windowWidth / 4 - 20, windowHeight / 3);
        Console.WriteLine("|  " + textJeu + "  |");
        Console.SetCursorPosition(windowWidth / 4 - 20, windowHeight / 3 - 1);
        Console.WriteLine("|                    |");
        Console.SetCursorPosition(windowWidth / 4 - 20, windowHeight / 3 - 2);
        Console.WriteLine("----------------------");
        Console.SetCursorPosition(windowWidth / 4 - 20, windowHeight / 3 + 1);
        if (m_userChoice == 1) Console.WriteLine("|          1         |");
        else Console.WriteLine("|                    |");
        Console.SetCursorPosition(windowWidth / 4 - 20, windowHeight / 3 + 2);
        Console.WriteLine("----------------------");

        //texte supprimer une save
        string textSave = "=== DELETE SAVE  ===";
        Console.SetCursorPosition(windowWidth / 2 - 10, windowHeight / 3);
        Console.WriteLine("|  " + textSave + "  |");
        Console.SetCursorPosition(windowWidth / 2 - 10, windowHeight / 3 - 1);
        Console.WriteLine("|                        |");
        Console.SetCursorPosition(windowWidth / 2 - 10, windowHeight / 3 - 2);
        Console.WriteLine("--------------------------");
        Console.SetCursorPosition(windowWidth / 2 - 10, windowHeight / 3 + 1);
        if (m_userChoice == 2) Console.WriteLine("|            2           |");
        else Console.WriteLine("|                        |");
        Console.SetCursorPosition(windowWidth / 2 - 10, windowHeight / 3 + 2);
        Console.WriteLine("--------------------------");

        //texte retour menu
        string textOut = "=== BACK TO MENU ===";
        Console.SetCursorPosition(3 * windowWidth / 4, windowHeight / 3);
        Console.WriteLine("|  " + textOut + "  |");
        Console.SetCursorPosition(3 * windowWidth / 4, windowHeight / 3 - 1);
        Console.WriteLine("|                        |");
        Console.SetCursorPosition(3 * windowWidth / 4, windowHeight / 3 - 2);
        Console.WriteLine("--------------------------");
        Console.SetCursorPosition(3 * windowWidth / 4, windowHeight / 3 + 1);
        if (m_userChoice == 3) Console.WriteLine("|            3           |");
        else Console.WriteLine("|                        |");
        Console.SetCursorPosition(3 * windowWidth / 4, windowHeight / 3 + 2);
        Console.WriteLine("--------------------------");
        
        //Lire un JSON et pouvoir sélectionner une save
    
    }

    public static void SaveChoice(Game oGame)
    {
        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.Save_AddMenu },
            { 2, GameMenuStates.Save_AddMenu },
            { 3, GameMenuStates.InGameMenu }
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
}
