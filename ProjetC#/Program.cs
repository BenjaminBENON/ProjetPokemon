using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

class Program
{

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();
    const int SW_MAXIMIZE = 3;
    private static void Resize()
    {
        IntPtr handle = GetConsoleWindow();
        ShowWindow(handle, SW_MAXIMIZE);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.Clear();
    }

    private static void DefaultSave()
    {
        var itemList = new List<Item>();
        var pokemonList = new List<Pokemon>();
        var eventList = new List<int>();

        float[]  resPlant = { 1, 2, 0.5f, 1, 0.8f };
        Pokemon bulbizarre = new Pokemon("Bulbizarre", PokemonType.Plant, 45, 49, 49, 65, 99, 1,resPlant);

        itemList.Add(new Pokeball("Pokeball"));
        itemList.Add(new Pokeball("Pokeball"));
        itemList.Add(new Pokeball("Pokeball"));
        pokemonList.Add(bulbizarre);
        eventList.Add(1);

        SaveShape newSave = new SaveShape("Default", 20, 20, itemList, pokemonList, eventList);
        string filePath = "saveDefault.json";
        Save.CreateJsonSave(newSave, filePath);
        
    }

    static void Main(string[] args)
    {
        Resize();

        DefaultSave();

        Game game = new Game();

        while (true)
        {
            game.Run();
        }

    }
}
//EXCEL _ CSV _ JSON