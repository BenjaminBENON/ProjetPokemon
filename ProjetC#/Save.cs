using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public class Save
{
    //DONNEES A SAUVEGARDER TEST
    //private DateTimeOffset Date { get; set; }
    //private int TemperatureCelsius { get; set; }
    //private string? Summary { get; set; }

    //DONNEES A SAUVEGARDER 
    private string SaveId { get; set; }
    private int PosXPlayer { get; set; }
    private int PosYPlayer { get; set; }
    private List<Item> ListItem { get; set; }
    private List<Pokemon> ListPokemon { get; set; }
    private List<int> ListEvent { get; set; }


    private static List<string> listSaves;
    public static List<string> ListSaves { get => listSaves; set => listSaves = value; }


    public static void CreateJsonSave(string name, int posXPlayer, int posYPlayer, List<Item> listItem, List<Pokemon> listPokemon, List<int> listEvent)
    {
        //var newSaveTest = new Save
        //{
        //    Date = DateTime.Parse("2024-03-27"),
        //    TemperatureCelsius = 20,
        //    Summary = "Not So Hot"
        //};

        //string jsonString = JsonSerializer.Serialize(newSaveTest);
        
        var newSave = new Save
        {
            SaveId = name,
            PosXPlayer = posXPlayer,
            PosYPlayer = posYPlayer,
            ListItem = listItem,
            ListPokemon = listPokemon,
            ListEvent = listEvent
        };

        string jsonString = JsonSerializer.Serialize(newSave);

        listSaves.Add(jsonString);
    }
}

