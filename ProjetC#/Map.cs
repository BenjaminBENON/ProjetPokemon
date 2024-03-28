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

    public static bool _Item1 = true;
    public static bool _Item2 = true;
    public static bool _Item3 = true;

    public static int SizeX { get => _iSizeX; }
    public static int SizeY { get => _iSizeY; }
    public static string[] GetWorldMap { get => WorldMap; }



    static string[] WorldMap =
    {
        "|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|",
        "|                     MMM                                                           FF                               OOOOOOOOOOOOOOOO                                                                                                 OOOOOOOOOOO|",
        "|                   MMMMMMM       FF           MMMMMMMMMM        MMMMMMMM           TT         9                     OOOOOOOOOOOOOO          FF                                                                FF                    OOOOOOOOOOOO|",
        "|                   MMPPMMM       TT           MMMMMMMMMM        MMPPMMMM                                              OOOOOOOOOOOO          TT                        FF               HHHHHHHHHHHHHHHH       TT                   OOOOOOOOOOOOO|",
        "|              CCCCCCCCCCCCCCCC                MMMMMMPPMMCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC  OOOOOOOOOOOO                                  TT               HHHHHHHHHHHHHHH                           OOOOOOOOOOOOOOO|",
        "|              CCCCCCCCCCCCCCCC                CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC  OOOOOOOOOOOOOO               HHHHHHHHHHHHHHH                  HHHHHHHHHHHHHHHH                        OOOOOOOOOOOOOOOOOO|",
        "|              CCCC        CCCC                CCCCCCCCCCCCCC                CCCC                        FF        CCCC    OOOOOOOOOOOO               HHHHHHHHHHHHHHH                                                        OOOOOOOOOOOOOOOOOOOO|",
        "|              CCCC        CCCC                CCCCCCCCCCCCCC   FF           CCCC            FF          TT        CCCC    OOOOOOOOOOOOOO             HHHHHHHHHHHHHHH                                        FF             OOOOOOOOOOOOOOOOOOOOO|",
        "|      FF      CCCC        MMMMMMMMMM                    CCCC   TT       FF  CCCC            TT                    CCCC      OOOOOOOOOOOOOO                                  FF                              TT            OOOOOOOOOOOOOOOOOOOOOO|",
        "|      TT      CCCC        MMMMMMMMMM                    CCCC            TT  CCCC       HHHHHHHHHHHHHHH            CCCC        OOOOOOOOOOOOOO                                TT          MMMMMMMM                          OOOOOOOOOOOOOOOOOOOOOO|",
        "|              CCCC        MMPPMMMMMM       FF           CCCC            MMMMMMMM       HHHHHHHHHHHHHHH            CCCC            OOOOOOOOOOOO                                          MMMMMMMM                          OOOOOOOOOOOOOOOOOOOOOO|",
        "|              CCCC        CCCCCCCCCC       TT           CCCC            MMMMMMMM       HHHHHHHHHHHHHHH            CCCC              OOOOOOOOOOOO                                        MMPPMMMM                         OOOOOOOOOOOOOOOOOOOOOOO|",
        "|              CCCCCCCCCCCCCCCCCCCCCCCC                  CCCC     FF     MMMMMMMM                                  CCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC         FF              OOOOOOOOOOOOOOOOOOOOOOO|",
        "|              CCCCCCCCCCCCCCCCCCCCCCCC                  CCCC     TT     MMMMMMMM   FF                             CCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC         TT              OOOOOOOOOOOOOOOOOOOOOOO|",
        "|                          CCCC    CCCC           FF     CCCC            MMM11MMM   TT        HHHHHHHHHHHHHHHHH                          OOOOOOOOOOOO                                                                    OOOOOOOOOOOOOOOOOOOOOOOO|",
        "|                          CCCC    CCCC           TT     CCCC  FF        CCCCCCCC               HHHHHHHHHHHHHHHHHH             FF            OOOOOOOOOOOOOO      FF                                                     OOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|   FF                     CCCC    CCCC                  CCCC  TT        CCCCCCCCCCCC           HHHHHHHHHHHHHHH       FF       TT            OOOOOOOOOOOOOOOO    TT                       HHHHHHHH                      OOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|   TT              FF     CCCC    CCCC                  CCCC            CCCCCCCCCCCC                                 TT                       OOOOOOOOOOOOOOOO                  FF        HHHHHHHH                    OOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|                   TT     CCCC    CCCC    FF            CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC            OOOOOOOOOOOOOOOOOO              TT                                   OOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|                          CCCC    CCCC    TT            CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                OOOOOOOOOOOOOOOO                          MMMM                 OOOOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "| FF   MMMMMMMMMM          CCCC    CCCC                  CCCC                CCCCCCCC                    FF                      CCCC                OOOOOOOOOOOOOOOOOO                      MMMMMMMM             OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "| TT   MMMMMMMMMM          CCCC    CCCC                  CCCC                CCCCCCCC  CCCCCCCCCC        TT                      CCCC                  OOOOOOOOOOOOOOOOOOOO                  MMPPMMMM            OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|      MMMMPPMMMM          CCCC    CCCC           FF     CCCC   FF           CCCCCCCC  CCOOOOOOCC                                CCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCC              OOOOOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|      CCCCCCCCCCCCCC      CCCC    CCCC           TT     CCCC   TT           CCCCCCCCCCCCOOOOOOCC        HHHHHHHHHHHHHHH         CCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCC                OOOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|      CCCCCCCCCCCCCC      CCCC    CCCC                  CCCC                CCCCCCCCCCCCOOOOOOCC        HHHHHHHHHHHHHHH                                     OOOOOOOOOOOOOOOOOOOO        CCCC                        OOOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|                CCCC      CCCC    CCCC                  CCCC          FF        CCCC  CCCCCCCCCC        HHHHHHHHHHHHHHH           FF                          OOOOOOOOOOOOOOOOOOOOOO    CCCC                         OOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOO             CCCC      CCCC    CCCC                  CCCC          TT        CCCC                                              TT                FF        OOOOOOOOOOOOOOOOOOOOOOOO  CCCC    FF                   OOOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOO     CCCC      CCCC    CCCC       nn         CCCC   HHHHHHHHHH       CCCC                                                                TT          OOOOOOOOOOOOOOOOOOOOOO  CCCC    TT                    OOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOO   BBBB      CCCC    CCCC      nNNn        CCCC    HHHHHHHHHHHH    CCCC                   FF                                                       OOOOOOOOOOOOOOOOOOOOOOOOBBBB                          OOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOOOOOBBBB      CCCC    CCCC       nn         CCCC    HHHHHHHHHHHH    CCCC                   TT                          HHHHHHHHHHHHHH                 OOOOOOOOOOOOOOOOOOOOOOBBBB             HHHHH        OOOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOOOOOBBBBOO    CCCC    CCCC                  CCCC      HHHHHHHHHH    CCCC   FF                                          HHHHHHHHHHHHHH                 OOOOOOOOOOOOOOOOOOOOOOBBBB           HHHHH           OOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOOOOOBBBBOOOO  CCCC    CCCC                  CCCC                    CCCC   TT        HHHHHHHHHHHHHHHHHH                  HHHHHHHHHHHHHH     FF        OOOOOOOOOOOOOOOOOOOOOOBBBB              HHHH         OOOOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC            FF      CCCC      HHHHHHHHHHHHHHHHHHHHHHHHH                  HHHHHHHHHHHHHH     TT          OOOOOOOOOOOOOOOOOOOOBBBB                            OOOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC         FF       CCCC            TT      CCCC     HHHHHHHHHHHHHHHHHH                                                         OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM           OOOOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC         TT       CCCC                    CCCC     HHHHHHHHHHHHHHHHHH                FF                                       OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM             OOOOOOOOOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC     HHHHHHHHHHHHHHHHHH                TT                    FF                 OOOOOOOOOOOOOOOOOO  CCCC        MMMMMMMMMM              OOOOOOOOOOOOOOOOOOOO|",
        "|   OOOOOOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC                    CCCC                                                             TT               OOOOOOOOOOOOOOOOOOOO  CCCC        MMMMPPMMMM              OOOOOOOOOOOOOOOOOOOO|",
        "|       OOOOOOOOOBBBBOOOOOOBBBB    CCCC                  CCCC   FF               CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBnnBBBCCCCCCCCCCCCCCCCCCCCCC               OOOOOOOOOOOOOOOOOOO|",
        "|HHHH     OOOOOOOBBBBOOOOOOBBBB    CCCC    FF            CCCC   TT               CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBNNBBBCCCCCCCCCCCCCCCCCCCCCC                OOOOOOOOOOOOOOOOOO|",
        "|    HHHH   OOOOOBBBBOOOOOOBBBBOO  CCCC    TT            CCCC             FF     CCCC                                                                              OOOOOOOOOOOOOOOOOO    CCCC                                    OOOOOOOOOOOOOOOO|",
        "|FFFF       OOOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC             TT     CCCC    HHHHHHHHHHHHHH         FF                              FF               OOOOOOOOOOOOOOOOOO      CCCC                                     OOOOOOOOOOOOOOO|",
        "|TTTTFF      OOOOBBBBOOOOOOBBBBOO  CCCC                  CCCC            MMMMMMMMCCCC    HHHHHHHHHHHHHH         TT          HHHHHHHHHHHHHHHHHH  TT               OOOOOOOOOOOOOOOO        CCCC    FF                               OOOOOOOOOOOOOOO|",
        "|    TT        OOBBBBOOOOOOBBBBOO  CCCC           FF     CCCC            MMMMMMMMCCCC    HHHHHHHHHHHHHHHH                     HHHHHHHHHHHHHHHH                 OOOOOOOOOOOOOOOOOO        CCCC    TT      HHHHH                     OOOOOOOOOOOOOO|",
        "|FFFF          OOBBBBOOOOOOBBBBOOOOBBBB           TT     CCCC   HHHH     MMMPPMMMCCCC       HHHHHHHHHHHHHHH  FF                                              OOOOOOOOOOOOOOOOOO          CCCC          HHHHHHH      MMMM           OOOOOOOOOOOOOO|",
        "|TTTT   FF     OOBBBBOOOOOOBBBBOOOOBBBB                  CCCCHHHHHH      CCCCCCCCCCCC                        TT                 FF                    FF     OOOOOOOOOOOOOOOO            CCCC                     MMMMMMMM          OOOOOOOOOOOOO|",
        "|       TT     OOBBBBOOOOOOBBBBOOOOBBBB                  CCCCHHHHH       CCCCCCCCCCCC                                           TT                    TT   OOOOOOOOOOOOOOOO              CCCC                     MMMMPPMM          OOOOOOOOOOOOO|",
        "|              OOBBBBOOOOOOBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC          OOOOOOOOOOOOO|",
        "|              OOBBBBOOOOOOBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC           OOOOOOOOOOOO|",
        "|     HH       OOBBBBOOOOOOOOOOOO  CCCCHHHHHH    MMMMMMMMCCCC                                                                                          OOOOOOOOOOOOOOOO                  CCCC                                        OOOOOOOOOOOO|",
        "|   HHHH       OOBBBBOOOOOOOOOOOO  CCCCHHHH      MMMMMMMMCCCC     FFHH        FF         FF     FF     FF       HHHHHHHHHHHH          HHHHH      OOOOOOOOOOOOOOOOOOOO           FF       CCCC               FF                       OOOOOOOOOOOO|",
        "|   HHHHHH   OOOOBBBBOOOOOOOOOOOO  CCCCHHHHHHH   MMMMPPMMCCCC     TT HH    HHHTT         TT     TT     TT    HHHHHHHHHHHHHHHHHH     HHHHHHHH   OOOOOOOOOOOOOOOOOOOO             TT       CCCC               TT                       OOOOOOOOOOOO|",
        "|       HH  OOOOOBBBBOOOOOOOOOOOO  CCCC          CCCCCCCCCCCC HHH     FF       HH  FF  HHHFF  FF      FF      HHHHHHHHHHHHHHHHHH       HHHH  OOOOOOOOOOOOOOOOOOOO                        CCCC                                        OOOOOOOOOOOO|",
        "| FF        OOOOOBBBBOOOOOOOOOOOO  CCCC                  CCCC  HH     TT HH   FF HHTT     TT  TT    FFTT         HHHHHHHHHHHHH             OOOOOOOOOOOOOOOOOOOO                          CCCC                                        OOOOOOOOOOOO|",
        "| TT      OOOOOOOBBBBOOOOOOOOOOOO  CCCC     HHHHH        CCCC             HHH TTFF             FF   TT FFFF      HHHHHHH               OOOOOOOOOOOOOOOOOOOOOO          FF                CCCC                      HHHHHHHHH         OOOOOOOOOOOO|",
        "|        OOOOOOOOBBBBOOOOOOOOOO    CCCC     HHHH         CCCC     HHH FF      HHTT HHH  FF     TT      TTTT                      OOOOOOOOOOOOOOOOOOOOOOOOOO            TT                CCCC       FF               HHHHHHHHHH      OOOOOOOOOOOO|",
        "| HHHH   OOOOOOOOBBBBOOOOOOOO      CCCC                HHCCCC   HHH   TT    HHFF        TT   FF      FF FF                 OOOOOOOOOOOOOOOOOOOOOOOOOOOO                                  CCCC       TT                  HHHHHHH      OOOOOOOOOOOO|",
        "| HH   OOOOOOOOOOBBBBOOOOOOOO      CCCC              HHHHCCCC  HHH          HHTT    HHHFF    TT      TT TT         OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                HHHHHHHH            CCCC                                       OOOOOOOOOOOOO|",
        "|    OOOOOOOOOOOOBBBBOOOOOO      HHCCCC               HHHCCCC       HHHFF         HHH  TT                  OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                  HHHHHHHH        MMMMMMMMMM                                       OOOOOOOOOOOOO|",
        "|   OOOOOOOOOOOOOBBBBOOOO       HHHCCCC   HHHHHHH        CCCC     HHH  TT       FF                 OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO           FF                         MMMMMMMMMM        MMMMMMMMMM                     OOOOOOOOOOOOO|",
        "|   OOOOOOOOOOOOOBBBBOO            CCCCHHHHHHHHHHH       CCCC                   TT           OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                     TT                         MMPPMMMMMM        MMMMMMPPMM                     OOOOOOOOOOOOO|",
        "| OOOOOOOOOOOOOOOBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC                     OOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOOOOOBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC          FF         OOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOO   CCCC                             HHHH   CCCC                          OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                                                              FF                                  TT        OOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOOO   CCCC   FF       HHHHHH                  CCCC      HHHHHHHH        OOOOOOOOOOOOOOOOOOOOOOOOOOOOOO                         FF                                         TT                                            OOOOOOOOOOOOOO|",
        "|OOOOOOOOOOOO    CCCC   TT         HHHHHH                CCCC    HHHHHHHH        OOOOOOOOOOOOOOOOOOOOOOOOOOOO          FF                 TT      HHHHHHHH                     FF                MMMMMMMMMM                        OOOOOOOOOOOOOO|",
        "|OOOOOOOOOO      CCCC            HHHHHH            HH    CCCC     HHHHHH         OOOOOOOOOOOOOOOOOOOOOOOO              TT                       HHHHHHHH           FF          TT                MMMMMMMMMM                       OOOOOOOOOOOOOOO|",
        "|OOOOOOOO        CCCCHHHHHH                              CCCC                    OOOOOOOOOOOOOOOOOO                                                                TT                            MMPPMMMMMM       FF              OOOOOOOOOOOOOOO|",
        "|OOOOOO          CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC       TT              OOOOOOOOOOOOOOO|",
        "|OOOO            CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCBBBBBBBBBBBBBBBBBBBBBBBBCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC              8       OOOOOOOOOOOOOOOO|",
        "|OO          HHHHHHHHHHHHHHHH                           HH                     OOOOOOOOOOOOOOOOOO                                           FF                                                                                   OOOOOOOOOOOOOOOO|",
        "|    FF        HHHHHHHHHHHH     7       FF            HHHH                     OOOOOOOOOOOOOOOO                                             TT                                    FF                                            OOOOOOOOOOOOOOOOO|",
        "|    TT            HHHHHHHH             TT                                     OOOOOOOOOOOOOOOO                                                                                   TT                                           OOOOOOOOOOOOOOOOOO|",
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
                else if (carac == '9')
                    if (_Item1) Console.ForegroundColor = ConsoleColor.Gray;
                    else Console.ForegroundColor = ConsoleColor.Green;
                else if (carac == '8') 
                    if (_Item2) Console.ForegroundColor = ConsoleColor.Gray;
                    else Console.ForegroundColor = ConsoleColor.Green;
                else if (carac == '7')
                    if (_Item3) Console.ForegroundColor = ConsoleColor.Gray;
                    else Console.ForegroundColor = ConsoleColor.Green;

                if ((carac == '7' && _Item1 == true) || (carac == '8' && _Item2 == true) || (carac == '9' && _Item3 == true))
                {
                    Console.Write('O');
                }
                else
                {
                    Console.Write('▒');
                }
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
    