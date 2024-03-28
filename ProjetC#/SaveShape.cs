using System;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Linq;

public class SaveShape
{
    //public int Score { get; set; }
    //public int Level { get; set; }

    //DONNEES A SAUVEGARDER 
    public string SaveId { get; set; }
    public int PosXPlayer { get; set; }
    public int PosYPlayer { get; set; }
    public List<Item> ListItem { get; set; }
    public List<Pokemon> ListPokemon { get; set; }
    public List<int> ListEvent { get; set; }

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
