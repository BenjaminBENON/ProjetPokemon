using System;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Linq;

public class SaveShape
{
    //public int Score { get; set; }
    //public int Level { get; set; }

    //DONNEES A SAUVEGARDER 
    private string SaveId { get; set; }
    private int PosXPlayer { get; set; }
    private int PosYPlayer { get; set; }
    private List<Item> ListItem { get; set; }
    private List<Pokemon> ListPokemon { get; set; }
    private List<int> ListEvent { get; set; }

    public SaveShape(string name, int posXPlayer, int posYPlayer, List<Item> listItem, List<Pokemon> listPokemon, List<int> listEvent)
    {
        SaveId = name;
        PosXPlayer = posXPlayer;
        PosYPlayer = posYPlayer;
        ListItem = listItem;
        ListPokemon = listPokemon;
        ListEvent = listEvent;
    }
}
