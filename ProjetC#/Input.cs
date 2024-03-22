using ProjetC_;
using System.Numerics;

public class Input
{
    public static void Update(Game oGame,Character p)
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
        ChangeState(oGame, p, KeyPress);
    }

    private static void ChangeState(Game oGame, Character p, ConsoleKeyInfo k)
    {
        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.InPokemonCenter },
            { 2, GameMenuStates.InGameMenu }
        };

        if (k.Key == ConsoleKey.P)
        {
            oGame.UpdateCurrentGameState(2, stateTransitions);
            Console.Clear();
        }
        else if (Map.GetCaracOnPos(p.PosX + 1, p.PosY) == 'P')
        {
            oGame.UpdateCurrentGameState(1, stateTransitions);
            Console.Clear();
        }
        
    }
}