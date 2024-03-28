using System;
using System.ComponentModel.DataAnnotations;

public class PokemonCenter
{
    PokemonCenter() { }

    static int _iSizeX = 18;
    static int _iSizeY = 5;
    public static int SizeX { get => _iSizeX; set => _iSizeX = value; }
    public static int SizeY { get => _iSizeY; set => _iSizeY = value; }

    public static string[] GetCenterMap { get => CenterMap; }

    static string[] CenterMap =
    {
        "--------------------",
        "|    MM  @@  MM    |",
        "|    MMMMMMMMMM    |",
        "|        ZZ        |",
        "|                  |" +
        "|                  |",
        "|        OO        |",
        "--------------------"
    };

    public static bool Display_Counter_Menu(Character p) {
        Console.Clear();
        Console.WriteLine("Bienvenue au comptoir Pokémon !");
        Console.WriteLine("Que souhaitez-vous faire ?");
        Console.WriteLine("1. Soigner tous vos Pokémon");
        Console.WriteLine("2. Acheter des objets");
        Console.WriteLine("3. Quitter");

        string choice;
        do
        {
            Console.Write("Entrez votre choix : ");
            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Tous vos Pokémon ont été soignés !");
                    p.HealAllPokemons();
                    break;
                case "2":
                    Console.WriteLine("Désolé, la fonctionnalité d'achat n'est pas encore disponible.");
                    break;
                case "3":
                    Console.WriteLine("Merci d'avoir visité le comptoir Pokémon !");
                    return false;
                default:
                    Console.WriteLine("Choix invalide. Veuillez réessayer.");
                    break;
            }
        } while (choice != "3");
        return true;
    }


    public static void Play_Map(Game oGame, Character p)
    {

        // Display Counter Menu
        if (GetCaracOnPos(p.PosX, p.PosY) == 'Z')
        {
            Display_Counter_Menu(p);
        }

        for (int y = -15; y <= 15; y++)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 50, Console.WindowHeight / 2 - 10 + y);
            for (int x = -50; x <= 50; x++)
            {
                if (p.PosX + x < 0 || p.PosX + x > SizeX || p.PosY + y < 0 || p.PosY + y > SizeY)
                {
                    Console.Write(' ');
                    continue;
                }
                char carac = GetCenterMap[p.PosY + y][p.PosX + x];
                if (carac == ' ')
                    Console.ForegroundColor = ConsoleColor.Gray;
                else if (carac == 'O')
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (carac == 'M')
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (carac == '@')
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (carac == 'I')
                    Console.ForegroundColor = ConsoleColor.White;
                else if (carac == 'Z')
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.Write('▒');
            }
            Console.WriteLine();
        }
        DrawPlayer(p);
        Console.BackgroundColor = ConsoleColor.Black;

        
    }

    public static void DrawPlayer(Character p)
    {
        Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 - 10);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(p._sCharac);
    }
    public static char GetCaracOnPos(int x, int y)
    {
        return GetCenterMap[y][x];
    }
}