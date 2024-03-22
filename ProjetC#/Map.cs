using ProjetC_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;



public class Map
{
    static int _iSizeX = 155;
    static int _iSizeY = 59;

    public static int SizeX { get => _iSizeX; }
    public static int SizeY { get => _iSizeY; }
    public static string[] GetWorldMap { get => WorldMap; }

    static string[] WorldMap =
    {
        "|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|",
        "|                     MMM                                                                                                                                                                                                                        |",
        "|                   MMMMMMM                    MMMMMMMMMM                                                                                                                                                                                                  |",
        "|                   MMMPMMM                    MMMMMMMMMM                                                                                                                                                                                                  |",
        "|              CCCCCCCCCCCCCCCC                MMMMMMMMMMCCCCCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                                        |",
        "|              CCCCCCCCCCCCCCCC                CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                                        |",
        "|              CCCC        CCCC                CCCCCCCCCCCCCC                CCCC                                                                                                                                                                        |",
        "|              CCCC        CCCC                CCCCCCCCCCCCCC                CCCC                                                                                                                                                                        |",
        "|              CCCC        MMMMMMMMMM                    CCCC                CCCC                                                                                                                                                                        |",
        "|              CCCC        MMMMMMMMMM                    CCCC                CCCC                                                                                                                                                                        |",
        "|              CCCC        MMMMPPMMMM                    CCCC            MMMMMMMM                                                                                                                                                                    |",
        "|              CCCC        CCCCCCCCCC                    CCCC            MMMMMMMM                                                                                                                                                                     |",
        "|              CCCCCCCCCCCCCCCCCCCCCCCC                  CCCC            MMMMMMMM                                                                                                                                                                     |",
        "|              CCCCCCCCCCCCCCCCCCCCCCCC                  CCCC            MMMMMMMM                                                                                                                                                                     |",
        "|                          CCCC    CCCC                  CCCC            MMMMMMMM                                                                                                                                                                     |",
        "|                          CCCC    CCCC                  CCCC            CCCCCCCC                                                                                                                                                                          |",
        "|                          CCCC    CCCC                  CCCC            CCCCCCCCCCCC                                                                                                                                                                          |",
        "|                          CCCC    CCCC                  CCCC            CCCCCCCCCCCC                                                                                                                                                                          |",
        "|                          CCCC    CCCC                  CCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                      |",
        "|                          CCCC    CCCC                  CCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                      |",
        "|      MMMMMMMMMM          CCCC    CCCC                  CCCC                CCCCCCCC                                                                                                                                                                      |",
        "|      MMMMMMMMMM          CCCC    CCCC                  CCCC                CCCCCCCC                                                                                                                                                                        |",
        "|      MMMMPPMMMM          CCCC    CCCC                  CCCC                CCCCCCCC                                                                                                                                                                        |",
        "|      CCCCCCCCCCCCCC      CCCC    CCCC                  CCCC                CCCCCCCCCC                                                                                                                                                                        |",
        "|      CCCCCCCCCCCCCC      CCCC    CCCC                  CCCC                CCCCCCCCCC                                                                                                                                                                        |",
        "|                CCCC      CCCC    CCCC                  CCCC                    CCCC                                                                                                                                                                    |",
        "|OOO             CCCC      CCCC    CCCC                  CCCC                    CCCC                                                                                                                                                                    |",
        "|OOOOOOOOOOO     CCCC      CCCC    CCCC                  CCCC                    CCCC                                                                                                                                                                    |",
        "|OOOOOOOOOOOOO   BBBB      CCCC    CCCC                  CCCC                    CCCC                                                                                                                                                                    |",
        "|OOOOOOOOOOOOOOOOBBBB      CCCC    CCCC                  CCCC                                                                                                                                                                                        |",
        "|OOOOOOOOOOOOOOOOBBBBOO    CCCC    CCCC                  CCCC                                                                                                                                                                                        |",
        "|OOOOOOOOOOOOOOOOBBBBOOOO  CCCC    CCCC                  CCCC                                                                                                                                                                                        |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                                                                                                                                                                                        |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                                                                                                                                                                                        |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                                                                                                                                                                                        |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                                                                                                                                                                                        |",
        "|   OOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                                                                                                                                                                                        |",
        "|       OOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                                                                                                                                                                                        |",
        "|         OOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                                                                                                                                                                                        |",
        "|           OOOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC                                                                                                                                                                                        |",
        "|           OOOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC                                                                                                                                                                                        |",
        "|            OOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC                                                                                                                                                                                        |",
        "|              OOBBBBOOOOOOBBBBOO  CCCC                  CCCC                                                                                                                                                                                        |",
        "|              OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC                                                                                                                                                                                        |",
        "|              OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC                                                                                                                                                                                        |",
        "|              OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC                                                                                                                                                                                        |",
        "|              OOBBBBOOOOOOBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                                                      |",
        "|              OOBBBBOOOOOOBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                                                        |",
        "|              OOBBBBOOOOOOOOOOOO  CCCC          MMMMMMMMCCCC                                                                                                                                                                                            |",
        "|              OOBBBBOOOOOOOOOOOO  CCCC          MMMMMMMMCCCC                                                                                                                                                                                           |",
        "|            OOOOBBBBOOOOOOOOOOOO  CCCC          MMMMMMMMCCCC                                                                                                                                                                                            |",
        "|           OOOOOBBBBOOOOOOOOOOOO  CCCC          CCCCCCCCCCCC                                                                                                                                                                                            |",
        "|           OOOOOBBBBOOOOOOOOOOOO  CCCC                  CCCC                                                                                                                                                                                            |",
        "|         OOOOOOOBBBBOOOOOOOOOOOO  CCCC                  CCCC                                                                                                                                                                                            |",
        "|        OOOOOOOOBBBBOOOOOOOOOO    CCCC                  CCCC                                                                                                                                                                                            |",
        "|        OOOOOOOOBBBBOOOOOOOO      CCCC                  CCCC                                                                                                                                                                                            |",
        "|      OOOOOOOOOOBBBBOOOOOOOO      CCCC                  CCCC                                                                                                                                                                                            |",
        "|    OOOOOOOOOOOOBBBBOOOOOO        CCCC                  CCCC                                                                                                                                                                                            |",
        "|   OOOOOOOOOOOOOBBBBOOOO          CCCC                  CCCC                                                                                                                                                                                            |",
        "|   OOOOOOOOOOOOOBBBBOO            CCCC                  CCCC                                                                                                                                                                                            |",
        "| OOOOOOOOOOOOOOOBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                                                                          |",
        "|OOOOOOOOOOOOOOOOBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                                                                          |",
        "|OOOOOOOOOOOOO   CCCC                                    CCCC                                                                                                                                                                                            |",
        "|OOOOOOOOOOOOO   CCCC                                    CCCC                                                                                                                                                                                            |",
        "|OOOOOOOOOOOO    CCCC                                    CCCC                                                                                                                                                                                            |",
        "|OOOOOOOOOO      CCCC                                    CCCC                                                                                                                                                                                            |",
        "|OOOOOOOO        CCCC                                    CCCC                                                                                                                                                                                            |",
        "|OOOOOO          CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                                                                                |",
        "|OOOO            CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                                                                                                                                                                                                |",
        "|OO                                                                                                                                                                                                                                              |",
        "|                                                                                                                                                                                                                                                |",
        "|                                                                                                                                                                                                                                                |",
        "|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|",
    };
    public static void Play_Map(Game oGame, Character p)
    {
        for (int y = -9; y <= 9; y++)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + y);
            for (int x = -15; x <= 15; x++)
            {
                if (p.PosX + x < 0 || p.PosX + x > SizeX || p.PosY + y < 0 || p.PosY + y > SizeY)
                {
                    Console.Write(' ');
                    continue;
                }
                char carac = GetWorldMap[p.PosY + y][p.PosX + x];
                if (carac == ' ')
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (carac == 'H')
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                else if (carac == 'M')
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                else if (carac == 'P')
                    Console.ForegroundColor = ConsoleColor.Gray;
                else if (carac == 'O')
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (carac == 'B')
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (carac == 'C')
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write('▒');
            }
            Console.WriteLine();
        }
        DrawPlayer(p);
    }

    public static void DrawPlayer(Character p)
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 , Console.WindowHeight / 2);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(p._sCharac);
    }
    public static char GetCaracOnPos(int x, int y)
    {
        return GetWorldMap[y][x];
    }

}
    