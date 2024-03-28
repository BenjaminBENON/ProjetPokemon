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
    private static string myPath = @"..\..\..\saveDirectory\";

    private static List<string> nameList = new List<string>();

    public static void CreateJsonSave(SaveShape newSave, string fileName)
    {
        string jsonData = JsonConvert.SerializeObject(newSave);

        string filePath = myPath + fileName;

        File.WriteAllText(filePath, jsonData);
        nameList.Add(fileName);
    }

    public static SaveShape ReadSave(int i)
    {
        if (i>=nameList.Count) 
        { 
            Console.WriteLine("Impossible de load la save");
            return null;
        }
        string filePath = myPath + nameList[i] ;

        string loadedJsonData = File.ReadAllText(filePath);
        SaveShape loadedSaveData = JsonConvert.DeserializeObject<SaveShape>(loadedJsonData);

        return loadedSaveData;
    }

    public static int getNbSave()
    {
        if (Directory.Exists(myPath))
        {
            string[] files = Directory.GetFiles(myPath);
            return files.Length;
        }
        else { return -1; }
    }
}

