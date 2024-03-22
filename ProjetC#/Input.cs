
using System.Numerics;

public class Input
{
    public static void Update(Character p)
    {
        ConsoleKeyInfo KeyPress;
        while (Console.KeyAvailable)
            Console.ReadKey(true);

        KeyPress = Console.ReadKey(true);

        if (KeyPress.KeyChar == 'z')
        {
            if (Map.GetCaracOnPos(p.PosX, p.PosY - 1) != 'M' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != '|' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != '-')
            {
                p.PosY -= 1;
            }
        }
        else if (KeyPress.KeyChar == 's')
        {
            if (Map.GetCaracOnPos(p.PosX, p.PosY + 1) != 'M' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != '|' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != '-')
            {
                p.PosY += 1;
            }
        }
        else if (KeyPress.KeyChar == 'q')
        {
            if (Map.GetCaracOnPos(p.PosX - 1, p.PosY) != 'M' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != '|' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != '-')
            {
                p.PosX -= 1;
            }
        }
        else if (KeyPress.KeyChar == 'd')
        {
            if (Map.GetCaracOnPos(p.PosX + 1, p.PosY) != 'M' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != '|' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != '-')
            {
                p.PosX += 1;
            }
        }
    }
}