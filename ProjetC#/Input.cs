
using System.Numerics;

public class Input
{
    static ConsoleKeyInfo _keyPress;

    static public ConsoleKeyInfo KeyPress { get => _keyPress; set => _keyPress = value; }

    public static void Update()
    {
        
        while (Console.KeyAvailable)
            Console.ReadKey(true);

        KeyPress = Console.ReadKey(true);

    }

    public static void PlayerMapControl(Game game, Character p)
    {
        if (KeyPress.KeyChar == 'z')
        {
            if (Map.GetCaracOnPos(p.PosX, p.PosY - 1) != 'M' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != '|' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != '-' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != 'O')
            {
                p.PosY -= 1;
                MapUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 's')
        {
            if (Map.GetCaracOnPos(p.PosX, p.PosY + 1) != 'M' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != '|' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != '-' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != 'O')
            {
                p.PosY += 1;
                MapUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 'q')
        {
            if (Map.GetCaracOnPos(p.PosX - 1, p.PosY) != 'M' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != '|' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != '-' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != 'O')
            {
                p.PosX -= 1;
                MapUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 'd')
        {
            if (Map.GetCaracOnPos(p.PosX + 1, p.PosY) != 'M' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != '|' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != '-' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != 'O')
            {
                p.PosX += 1;
                MapUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 'i')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.Inventory_ShowObjects);
        }
        else if (KeyPress.KeyChar == 'p')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.Inventory_ShowPokemons);
        }
        else if (KeyPress.KeyChar == 'm')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.Save_AddMenu);
        }
        else if (KeyPress.KeyChar == 'l')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.InSaveMenu);
        }
    }

    static void MapUpdate(Game game, Character p)
    {
        if (Map.GetCaracOnPos(p.PosX + 1, p.PosY) == '1')
        {
            game.UpdateCurrentGameState(GameMenuStates.InPokemonCenter);
        }
        if(Map.GetCaracOnPos(p.PosX, p.PosY) == 'H')
        { 
            Random rand = new Random();
            int randNb = rand.Next(100);

            if (randNb < 5) 
            {
                Console.Clear();
                game.UpdateCurrentGameState(GameMenuStates.OnFight);
            }
        }
        if (Map.GetCaracOnPos(p.PosX + 1, p.PosY) == 'n')
        {
            NPC rival = new NPC(game);

            rival.launchDialog();
        }
    }

    public static void PlayerCenterControl(Game game, Character p)
    {
        if (KeyPress.KeyChar == 'z')
        {
            if (PokemonCenter.GetCaracOnPos(p.PosX, p.PosY - 1) != 'M' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY - 1) != '|' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY - 1) != '-' )
            {
                p.PosY -= 1;
            }
        }
        else if (KeyPress.KeyChar == 's')
        {
            if (PokemonCenter.GetCaracOnPos(p.PosX, p.PosY + 1) != 'M' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY + 1) != '|' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY + 1) != '-')
            {
                p.PosY += 1;
            }
        }
        else if (KeyPress.KeyChar == 'q')
        {
            if (PokemonCenter.GetCaracOnPos(p.PosX - 1, p.PosY) != 'M' && PokemonCenter.GetCaracOnPos(p.PosX - 1, p.PosY) != '|' && PokemonCenter.GetCaracOnPos(p.PosX - 1, p.PosY) != '-')
            {
                p.PosX -= 1;
            }
        }
        else if (KeyPress.KeyChar == 'd')
        {
            if (PokemonCenter.GetCaracOnPos(p.PosX + 1, p.PosY) != 'M' && PokemonCenter.GetCaracOnPos(p.PosX + 1, p.PosY) != '|' && PokemonCenter.GetCaracOnPos(p.PosX + 1, p.PosY) != '-')
            {
                p.PosX += 1;
            }
        }
        else if (KeyPress.KeyChar == 'i')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.Inventory_ShowObjects);
        }
        else if (KeyPress.KeyChar == 'p')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.Inventory_ShowPokemons);
        }
        else if (KeyPress.KeyChar == 'm')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.Save_AddMenu);
        }
        else if (KeyPress.KeyChar == 'l')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.InSaveMenu);
        }
    }

    public static void ItemInventoryControl(Game game)
    {
        if (KeyPress.KeyChar == 'i')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.OnMap);       
        }
    }

    public static void PokemonInventoryControl(Game game)
    {
        if (KeyPress.KeyChar == 'p')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.OnMap);
        }
    }
}