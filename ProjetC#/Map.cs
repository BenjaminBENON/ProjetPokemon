
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
        "|                   MMPPMMM                    MMMMMMMMMM        MMPPMMMM                                              OOOOOOOOOOOO                                                                                                              |",
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
        "|                          CCCC    CCCC                  CCCC            MMM11MMM                                                        OOOOOOOOOOOO                                                                                            |",
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
        "|OOOOOOOOOOO     CCCC      CCCC    CCCC       nn         CCCC                    CCCC                                                                            OOOOOOOOOOOOOOOOOOOOOO  CCCC                                                    |",
        "|OOOOOOOOOOOOO   BBBB      CCCC    CCCC      nNNn        CCCC                    CCCC                                                                            OOOOOOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBB      CCCC    CCCC       nn         CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBBOO    CCCC    CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBBOOOO  CCCC    CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                                OOOOOOOOOOOOOOOOOOOOBBBB                                                    |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                                OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM                                  |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                                OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM                                  |",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                                OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM                                  |",
        "|   OOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOOOO  CCCC        MMMMPPMMMM                                  |",
        "|       OOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBnnBBBCCCCCCCCCCCCCCCCCCCCCC                                  |",
        "|HHHH     OOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBNNBBBCCCCCCCCCCCCCCCCCCCCCC                                  |",
        "|    HHHH   OOOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC                    CCCC                                                                              OOOOOOOOOOOOOOOOOO    CCCC                                                    |",
        "|FFFF       OOOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC                    CCCC                                                                            OOOOOOOOOOOOOOOOOO      CCCC                                                    |",
        "|TTTTFF      OOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC            MMMMMMMMCCCC                                                                            OOOOOOOOOOOOOOOO        CCCC                                                    |",
        "|    TT        OOBBBBOOOOOOBBBBOO  CCCC                  CCCC            MMMMMMMMCCCC                                                                          OOOOOOOOOOOOOOOOOO        CCCC                                                    |",
        "|FFFF          OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC            MMMPPMMMCCCC                                                                        OOOOOOOOOOOOOOOOOO          CCCC                       MMMM                         |",
        "|TTTT   FF     OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC            CCCCCCCCCCCC                                                                        OOOOOOOOOOOOOOOO            CCCC                     MMMMMMMM                       |",
        "|       TT     OOBBBBOOOOOOBBBBOOOOBBBB                  CCCC            CCCCCCCCCCCC                                                                      OOOOOOOOOOOOOOOO              CCCC                     MMMMPPMM                       |",
        "|              OOBBBBOOOOOOBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                       |",
        "|              OOBBBBOOOOOOBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                       |",
        "|     HH       OOBBBBOOOOOOOOOOOO  CCCCHHHHHH    MMMMMMMMCCCC                                                                                          OOOOOOOOOOOOOOOO                  CCCC                                                    |",
        "|   HHHH       OOBBBBOOOOOOOOOOOO  CCCCHHHH      MMMMMMMMCCCC     FFHH        FF         FF     FF     FF       HHHHHHHHHHHH          HHHHH      OOOOOOOOOOOOOOOOOOOO                    CCCC                                                    |",
        "|   HHHHHH   OOOOBBBBOOOOOOOOOOOO  CCCCHHHHHHH   MMMMPPMMCCCC     TT HH    HHHTT         TT     TT     TT    HHHHHHHHHHHHHHHHHH     HHHHHHHH   OOOOOOOOOOOOOOOOOOOO                      CCCC                                                    |",
        "|       HH  OOOOOBBBBOOOOOOOOOOOO  CCCC          CCCCCCCCCCCC HHH     FF       HH  FF  HHHFF  FF      FF      HHHHHHHHHHHHHHHHHH       HHHH  OOOOOOOOOOOOOOOOOOOO                        CCCC                                                    |",
        "| FF        OOOOOBBBBOOOOOOOOOOOO  CCCC                  CCCC  HH     TT HH   FF HHTT     TT  TT    FFTT         HHHHHHHHHHHHH             OOOOOOOOOOOOOOOOOOOO                          CCCC                                                    |",
        "| TT      OOOOOOOBBBBOOOOOOOOOOOO  CCCC     HHHHH        CCCC             HHH TTFF             FF   TT FFFF      HHHHHHH               OOOOOOOOOOOOOOOOOOOOOO                            CCCC                                                    |",
        "|        OOOOOOOOBBBBOOOOOOOOOO    CCCC     HHHH         CCCC     HHH FF      HHTT HHH  FF     TT      TTTT                      OOOOOOOOOOOOOOOOOOOOOOOOOO                              CCCC                                                    |",
        "| HHHH   OOOOOOOOBBBBOOOOOOOO      CCCC                HHCCCC   HHH   TT    HHFF        TT   FF      FF FF                 OOOOOOOOOOOOOOOOOOOOOOOOOOOO                                  CCCC                                                    |",
        "| HH   OOOOOOOOOOBBBBOOOOOOOO      CCCC              HHHHCCCC  HHH          HHTT    HHHFF    TT      TT TT         OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                    CCCC                                                    |",
        "|    OOOOOOOOOOOOBBBBOOOOOO      HHCCCC               HHHCCCC       HHHFF         HHH  TT                  OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                  MMMMMMMMMM                                                    |",
        "|   OOOOOOOOOOOOOBBBBOOOO       HHHCCCC   HHHHHHH        CCCC     HHH  TT       FF                 OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                      MMMMMMMMMM        MMMMMMMMMM                                  |",
        "|   OOOOOOOOOOOOOBBBBOO            CCCCHHHHHHHHHHH       CCCC                   TT           OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                MMPPMMMMMM        MMMMMMPPMM                                  |",
        "| OOOOOOOOOOOOOOOBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                  |",
        "|OOOOOOOOOOOOOOOOBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                  |",
        "|OOOOOOOOOOOOO   CCCC                             HHHH   CCCC                          OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                                                                                          |",
        "|OOOOOOOOOOOOO   CCCC            HHHHHH                  CCCC      HHHHHHHH        OOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                                                                                                |",
        "|OOOOOOOOOOOO    CCCC              HHHHHH                CCCC    HHHHHHHH        OOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                                                    MMMMMMMMMM                                      |",
        "|OOOOOOOOOO      CCCC            HHHHHH            HH    CCCC     HHHHHH         OOOOOOOOOOOOOOOOOOOOOOOO                                                                                        MMMMMMMMMM                                      |",
        "|OOOOOOOO        CCCCHHHHHH                              CCCC                    OOOOOOOOOOOOOOOOOO                                                                                              MMPPMMMMMM                                      |",
        "|OOOOOO          CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                      |",
        "|OOOO            CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                                      |",
        "|OO          HHHHHHHHHHHHHHHH                           HH                     OOOOOOOOOOOOOOOOOO                                                                                                                                                |",
        "|              HHHHHHHHHHHH                           HHHH                     OOOOOOOOOOOOOOOO                                                                                                                                                  |",
        "|                  HHHHHHHH                                                    OOOOOOOOOOOOOOOO                                                                                                                                                  |",
        "|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|",
    };
    public static void Play_Map(Game oGame, Character p)
    {
        //Ici tout ce qui se passe sur la map
        
        for (int y = -15; y <= 15; y++)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.WindowHeight / 2 - 5 + y);
            for (int x = -50; x <= 50; x++)
            {
                if (p.PosX + x < 0 || p.PosX + x > SizeX || p.PosY + y < 0 || p.PosY + y > SizeY)
                {
                    Console.Write(' ');
                    continue;
                }
                char carac = GetWorldMap[p.PosY + y][p.PosX + x];
                if (carac == ' ')
                    Console.Write("\x1b[38;2;0;255;0m");
                else if (carac == 'H')
                    Console.Write("\x1b[38;2;75;153;0m");
                else if (carac == 'M')
                    Console.Write("\x1b[38;2;51;25;0m");
                else if (carac == 'P')
                    Console.Write("\x1b[38;2;204;102;0m");
                else if (carac == 'O')
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (carac == 'B')
                    Console.Write("\x1b[38;2;255;153;51m");
                else if (carac == 'C')
                    Console.Write("\x1b[38;2;160;160;160m");
                else if (carac == '1')
                    Console.ForegroundColor = ConsoleColor.Gray;
                else if (carac == 'N')
                    Console.ForegroundColor = ConsoleColor.Gray;
                else if (carac == 'T')
                    Console.Write("\x1b[38;2;152;71;0m");
                else if (carac == 'F')
                    Console.Write("\x1b[38;2;0;102;0m");

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
    