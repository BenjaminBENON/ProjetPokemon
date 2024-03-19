using ProjetC_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;



public class GameMenu
{
    private static int m_userChoice = 1;
    
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
        Console.SetCursorPosition(xPosition, 3);
        Console.WriteLine("|" + textMenu + "|");
        Console.SetCursorPosition(xPosition + 1, 2);
        Console.WriteLine("------------");
        Console.SetCursorPosition(xPosition + 1, 4);
        Console.WriteLine("------------");

        //texte JOUER
        string textJeu = "=== NEW GAME ===";
        Console.SetCursorPosition(windowWidth / 4 - 20, 18);
        Console.WriteLine("|  " + textJeu + "  |");
        Console.SetCursorPosition(windowWidth / 4 - 20, 17);
        Console.WriteLine("|                    |");
        Console.SetCursorPosition(windowWidth / 4 - 20, 16);
        Console.WriteLine("----------------------");
        Console.SetCursorPosition(windowWidth / 4 - 20, 19);
        Console.WriteLine("|          1         |");
        Console.SetCursorPosition(windowWidth / 4 - 20, 20);
        Console.WriteLine("----------------------");

        //texte JOUER
        string textSave = "=== CONTINUE ===";
        Console.SetCursorPosition(windowWidth / 2 - 10, 18);
        Console.WriteLine("|  " + textSave + "  |");
        Console.SetCursorPosition(windowWidth / 2 - 10, 17);
        Console.WriteLine("|                    |");
        Console.SetCursorPosition(windowWidth / 2 - 10, 16);
        Console.WriteLine("----------------------");
        Console.SetCursorPosition(windowWidth / 2 - 10, 19);
        Console.WriteLine("|         2          |");
        Console.SetCursorPosition(windowWidth / 2 - 10, 20);
        Console.WriteLine("----------------------");

        //texte Quitter
        string textOut = "=== QUIT ===";
        Console.SetCursorPosition(3 * windowWidth / 4, 18);
        Console.WriteLine("|  " + textOut + "  |");
        Console.SetCursorPosition(3 * windowWidth / 4, 17);
        Console.WriteLine("|                |");
        Console.SetCursorPosition(3 * windowWidth / 4, 16);
        Console.WriteLine("------------------");
        Console.SetCursorPosition(3 * windowWidth / 4, 19);
        Console.WriteLine("|        3       |");
        Console.SetCursorPosition(3 * windowWidth / 4, 20);
        Console.WriteLine("------------------");
    }

    public static void StartChoice(Game oGame)
    {

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.CharacterCreationMenu },
            { 2, GameMenuStates.OnMap },
            { 3, GameMenuStates.ShutDown }// Leave 
        };

        //Console.Write("Choice : ");
        //string choice = Console.ReadLine();
        //oGame.UpdateCurrentGameState(choice, stateTransitions);


        if (Console.ReadKey().KeyChar == 13)
        {
            oGame.UpdateCurrentGameState(m_userChoice, stateTransitions);
            return;
        }
        if (Console.ReadKey().KeyChar == 39 && m_userChoice < 3)
        {
            m_userChoice++;
            Console.WriteLine("WOW");
        }
        if (Console.ReadKey().KeyChar == 37 && m_userChoice > 1)
        {
            m_userChoice--;
            Console.WriteLine("YEAH");
        }
    }

    public static void CharacterMenu(Game oGame)
    {
        Console.WriteLine("=== CREATION DE PERSONNAGE ===");
        Console.Write("Nom de votre personnage : ");
        // character name
        string cName = Console.ReadLine();
        Console.Write("Votre personnage " + cName + " est désormais disponible");

        oGame.SetCharacterName(cName);

        oGame.UpdateCurrentGameState(GameMenuStates.OnMap);
    }

}
