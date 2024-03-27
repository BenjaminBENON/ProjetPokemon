using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public class Save
{
    private static string myPath = @"C:\Users\33652\source\repos\ProjetPokemon\ProjetC#\saveDirectory\";

    private static int nbSave = 0;
    public static int NbSave { get => nbSave; set => nbSave = value; }

    public static void CreateJsonSave(SaveShape newSave, string fileName)
    {
        string jsonData = JsonConvert.SerializeObject(newSave);

        string filePath = myPath + fileName;

        File.WriteAllText(filePath, jsonData);
        nbSave++;
    }
}

