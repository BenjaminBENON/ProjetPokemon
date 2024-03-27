
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;



public class Map
{
    static int _iSizeX = 239;
    static int _iSizeY = 71;

    public static int SizeX { get => _iSizeX; }
    public static int SizeY { get => _iSizeY; }
    public static string[] GetWorldMap { get => WorldMap; }



    static string[] WorldMap =
    {
        "|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|",
        "|                     MMM                                                                                            OOOOOOOOOOOOOOOO                                                                                                            |",
        "|                   MMMMMMM                    MMMMMMMMMM        MMMMMMMM                                            OOOOOOOOOOOOOO                                                                                                              |",
        "|                   MMPPMMM                    MMMMMMMMMM        MMMMMMMM                                              OOOOOOOOOOOO                                                                                                              |",
        "|              CCCCCCCCCCCCCCCC                MMMMMMPPMMCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC  OOOOOOOOOOOO                                                                                                            |",
        "|              CCCCCCCCCCCCCCCC                CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC  OOOOOOOOOOOOOO                                                                                                          |",
        "|              CCCC        CCCC                CCCCCCCCCCCCCC                CCCC                                  CCCC    OOOOOOOOOOOO                                                                                                          |",
        "|              CCCC        CCCC                CCCCCCCCCCCCCC                CCCC                                  CCCC    OOOOOOOOOOOOOO                                                                                                        |",
        "|              CCCC        MMMMMMMMMM                    CCCC                CCCC                                  CCCC      OOOOOOOOOOOOOO                                                                                                      |",
        "|              CCCC        MMMMMMMMMM                    CCCC                CCCC                                  CCCC        OOOOOOOOOOOOOO                                            MMMMMMMM                                                |",
        "|              CCCC        MMPPMMMMMM                    CCCC            MMMMMMMM                                  CCCC            OOOOOOOOOOOO                                          MMMMMMMM                                                |",
        "|              CCCC        CCCCCCCCCC                    CCCC            MMMMMMMM                                  CCCC              OOOOOOOOOOOO                                        MMPPMMMM                                                |",
        "|              CCCCCCCCCCCCCCCCCCCCCCCC                  CCCC            MMMMMMMM                                  CCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                |",
        "|              CCCCCCCCCCCCCCCCCCCCCCCC                  CCCC            MMMMMMMM                                  CCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                                |",
        "|                          CCCC    CCCC                  CCCC            MMMMMMMM                                                        OOOOOOOOOOOO                                                                                            |",
        "|                          CCCC    CCCC                  CCCC            CCCCCCCC                                                            OOOOOOOOOOOOOO                                                                                      |",
        "|                          CCCC    CCCC                  CCCC            CCCCCCCCCCCC                                                        OOOOOOOOOOOOOOOO                                                                                    |",
        "|                          CCCC    CCCC                  CCCC            CCCCCCCCCCCC                                                          OOOOOOOOOOOOOOOO                                                                                  |",
        "|                          CCCC    CCCC                  CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC            OOOOOOOOOOOOOOOOOO                                                                              |",
        "|                          CCCC    CCCC                  CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                OOOOOOOOOOOOOOOO                          MMMM                                              |",
        "|      MMMMMMMMMM          CCCC    CCCC                  CCCC                CCCCCCCC                                            CCCC                OOOOOOOOOOOOOOOOOO                      MMMMMMMM                                            |",
        "|      MMMMMMMMMM          CCCC    CCCC                  CCCC                CCCCCCCC  CCCCCCCCCC                                CCCC                  OOOOOOOOOOOOOOOOOOOO                  MMPPMMMM                                            |",
        "|      MMMMPPMMMM          CCCC    CCCC                  CCCC                CCCCCCCC  CCOOOOOOCC                                CCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCC                                            |",
        "|      CCCCCCCCCCCCCC      CCCC    CCCC                  CCCC                CCCCCCCCCCCCOOOOOOCC                                CCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCC                                            |",
        "|      CCCCCCCCCCCCCC      CCCC    CCCC                  CCCC                CCCCCCCCCCCCOOOOOOCC                                                            OOOOOOOOOOOOOOOOOOOO        CCCC                                                    |",
        "|                CCCC      CCCC    CCCC                  CCCC                    CCCC  CCCCCCCCCC                                                              OOOOOOOOOOOOOOOOOOOOOO    CCCC                                                    |",
        "|OOO             CCCC      CCCC    CCCC                  CCCC                    CCCC                                                                          OOOOOOOOOOOOOOOOOOOOOOOO  CCCC                                                    |",
        "|OOOOOOOOOOO     CCCC      CCCC    CCCC                  CCCC                    CCCC                  HH                                                        OOOOOOOOOOOOOOOOOOOOOO  CCCC                                                    |",
        "|OOOOOOOOOOOOO   BBBB      CCCC    CCCC                  CCCC                    CCCC                  BB                                                        OOOOOOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBB      CCCC    CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBBOO    CCCC    CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBBOOOO  CCCC    CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                                OOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                                OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM                                  |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                                OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM                                  |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                                OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM                                  |",
        "|   OOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOOOO  CCCC        MMMMPPMMMM                                  |",
        "|       OOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                            BBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCC                                  |",
        "|         OOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                            BBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCC                                  |",
        "|           OOOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOO    CCCC                                                    |",
        "|           OOOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC                    CCCC                                                                            OOOOOOOOOOOOOOOOOO      CCCC                                                    |",
        "|            OOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC            MMMMMMMMCCCC                                                                            OOOOOOOOOOOOOOOO        CCCC                                                    |",
        "|              OOBBBBOOOOOOBBBBOO  CCCC                  CCCC            MMMMMMMMCCCC                                                                          OOOOOOOOOOOOOOOOOO        CCCC                                                    |",
        "|              OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC            MMMMMMMMCCCC                                                                        OOOOOOOOOOOOOOOOOO          CCCC                       MMMM                         |",
        "|              OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC            CCCCCCCCCCCC                                                                        OOOOOOOOOOOOOOOO            CCCC                     MMMMMMMM                       |",
        "|              OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC            CCCCCCCCCCCC                                                                      OOOOOOOOOOOOOOOO              CCCC                     MMMMPPMM                       |",
        "|              OOBBBBOOOOOOBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                       |",
        "|              OOBBBBOOOOOOBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                       |",
        "|              OOBBBBOOOOOOOOOOOO  CCCC          MMMMMMMMCCCC                                                                                          OOOOOOOOOOOOOOOO                  CCCC                                                    |",
        "|              OOBBBBOOOOOOOOOOOO  CCCC          MMMMMMMMCCCC                                                                                    OOOOOOOOOOOOOOOOOOOO                    CCCC                                                    |",
        "|            OOOOBBBBOOOOOOOOOOOO  CCCC          MMMMMMMMCCCC                                                                                  OOOOOOOOOOOOOOOOOOOO                      CCCC                                                    |",
        "|           OOOOOBBBBOOOOOOOOOOOO  CCCC          CCCCCCCCCCCC                                                                                OOOOOOOOOOOOOOOOOOOO                        CCCC                                                    |",
        "|           OOOOOBBBBOOOOOOOOOOOO  CCCC                  CCCC                                                                              OOOOOOOOOOOOOOOOOOOO                          CCCC                                                    |",
        "|         OOOOOOOBBBBOOOOOOOOOOOO  CCCC                  CCCC                                                                          OOOOOOOOOOOOOOOOOOOOOO                            CCCC                                                    |",
        "|        OOOOOOOOBBBBOOOOOOOOOO    CCCC                  CCCC                                                                    OOOOOOOOOOOOOOOOOOOOOOOOOO                              CCCC                                                    |",
        "|        OOOOOOOOBBBBOOOOOOOO      CCCC                  CCCC                                                              OOOOOOOOOOOOOOOOOOOOOOOOOOOO                                  CCCC                                                    |",
        "|      OOOOOOOOOOBBBBOOOOOOOO      CCCC                  CCCC                                                      OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                    CCCC                                                    |",
        "|    OOOOOOOOOOOOBBBBOOOOOO        CCCC                  CCCC                                              OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                  MMMMMMMMMM                                                    |",
        "|   OOOOOOOOOOOOOBBBBOOOO          CCCC                  CCCC                                      OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                      MMMMMMMMMM        MMMMMMMMMM                                  |",
        "|   OOOOOOOOOOOOOBBBBOO            CCCC                  CCCC                                OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                MMPPMMMMMM        MMMMMMPPMM                                  |",
        "| OOOOOOOOOOOOOOOBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                  |",
        "|OOOOOOOOOOOOOOOOBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                  |",
        "|OOOOOOOOOOOOO   CCCC                                    CCCC                          OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                                                                                          |",
        "|OOOOOOOOOOOOO   CCCC                                    CCCC                      OOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                                                                                                |",
        "|OOOOOOOOOOOO    CCCC                                    CCCC                    OOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                                                    MMMMMMMMMM                                      |",
        "|OOOOOOOOOO      CCCC                                    CCCC                    OOOOOOOOOOOOOOOOOOOOOOOO                                                                                        MMMMMMMMMM                                      |",
        "|OOOOOOOO        CCCC                                    CCCC                    OOOOOOOOOOOOOOOOOO                                                                                              MMPPMMMMMM                                      |",
        "|OOOOOO          CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                      |",
        "|OOOO            CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                      |",
        "|OO                                                                            OOOOOOOOOOOOOOOOOO                                                                                                                                                |",
        "|                                                                              OOOOOOOOOOOOOOOO                                                                                                                                                  |",
        "|                                                                              OOOOOOOOOOOOOOOO                                                                                                                                                  |",
        "|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|",
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
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public static void DrawPlayer(Character p)
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 , Console.WindowHeight / 2 -10);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(p._sCharac);
    }
    public static char GetCaracOnPos(int x, int y)
    {
        return GetWorldMap[y][x];
    }

}
    