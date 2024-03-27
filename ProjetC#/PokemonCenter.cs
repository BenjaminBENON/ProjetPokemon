using ProjetC_;
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
        "|    MMMMIIMMMM    |",
        "|                  |",
        "|                  |",
        "|        OO        |",
        "--------------------"
    };


    public static void Play_Map(Game oGame, Character p)
    {
        //Ici tout ce qui se passe sur la map

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