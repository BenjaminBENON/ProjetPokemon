
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
            if (Map.GetCaracOnPos(p.PosX, p.PosY - 1) != 'T' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != 'F' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != 'M' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != '|' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != '-' && Map.GetCaracOnPos(p.PosX, p.PosY - 1) != 'O')
            {
                p.PosY -= 1;
                MapUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 's')
        {
            if (Map.GetCaracOnPos(p.PosX, p.PosY + 1) != 'T' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != 'F' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != 'M' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != '|' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != '-' && Map.GetCaracOnPos(p.PosX, p.PosY + 1) != 'O')
            {
                p.PosY += 1;
                MapUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 'q')
        {
            if (Map.GetCaracOnPos(p.PosX - 1, p.PosY) != 'T' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != 'F' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != 'M' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != '|' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != '-' && Map.GetCaracOnPos(p.PosX - 1, p.PosY) != 'O')
            {
                p.PosX -= 1;
                MapUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 'd')
        {
            if (Map.GetCaracOnPos(p.PosX + 1, p.PosY) != 'T' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != 'F' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != 'M' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != '|' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != '-' && Map.GetCaracOnPos(p.PosX + 1, p.PosY) != 'O')
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
        if (Map.GetCaracOnPos(p.PosX, p.PosY) == '1')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.InPokemonCenter);
            p.PosX = 9;
            p.PosY = 5;
        }    
        else if(Map.GetCaracOnPos(p.PosX, p.PosY) == 'H')
        {
            int seed = DateTime.Now.Millisecond;
            Random rand = new Random(seed);
            int randNb = rand.Next(100);

            if (randNb < 5) 
            {
                Console.Clear();
                List<Pokemon> pokemonList = GameDatabase.Instance.GetAllPokemons();
                seed = DateTime.Now.Millisecond;
                rand = new Random(seed);
                randNb = rand.Next(pokemonList.Count);
                game.enemyPokemonList = new List<Pokemon>{pokemonList[randNb]};
                game.fightType = FightType.SavagePokemon;
                game.UpdateCurrentGameState(GameMenuStates.OnFight);
            }
        }
        else if (Map.GetCaracOnPos(p.PosX, p.PosY) == 'n')
        {
            NPC rival = new NPC(game);
            rival.launchDialog(game);
        }
    }

    public static void PlayerCenterControl(Game game, Character p)
    {
        if (KeyPress.KeyChar == 'z')
        {
            if (PokemonCenter.GetCaracOnPos(p.PosX, p.PosY - 1) != 'I' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY - 1) != 'M' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY - 1) != '|' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY - 1) != '-' )
            {
                p.PosY -= 1;
                CenterUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 's')
        {
            if (PokemonCenter.GetCaracOnPos(p.PosX, p.PosY + 1) != 'I' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY + 1) != 'M' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY + 1) != '|' && PokemonCenter.GetCaracOnPos(p.PosX, p.PosY + 1) != '-')
            {
                p.PosY += 1;
                CenterUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 'q')
        {
            if (PokemonCenter.GetCaracOnPos(p.PosX - 1, p.PosY) != 'I' && PokemonCenter.GetCaracOnPos(p.PosX - 1, p.PosY) != 'M' && PokemonCenter.GetCaracOnPos(p.PosX - 1, p.PosY) != '|' && PokemonCenter.GetCaracOnPos(p.PosX - 1, p.PosY) != '-')
            {
                p.PosX -= 1;
                CenterUpdate(game, p);
            }
        }
        else if (KeyPress.KeyChar == 'd')
        {
            if (PokemonCenter.GetCaracOnPos(p.PosX + 1, p.PosY) != 'I' && PokemonCenter.GetCaracOnPos(p.PosX + 1, p.PosY) != 'M' && PokemonCenter.GetCaracOnPos(p.PosX + 1, p.PosY) != '|' && PokemonCenter.GetCaracOnPos(p.PosX + 1, p.PosY) != '-')
            {
                p.PosX += 1;
                CenterUpdate(game, p);
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

    static void CenterUpdate(Game game, Character p)
    {
        char charOnPos = PokemonCenter.GetCaracOnPos(p.PosX, p.PosY);
        if (charOnPos == 'O')
        {
            Console.Clear();
            game.UpdateCurrentGameState(GameMenuStates.OnMap);
            p.PosX = 76;
            p.PosY = 14;
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