using ProjetC_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;



public class Map
{
    public static void Play_Map(Game oGame)
    {
        //Ici tout ce qui se passe sur la map

        Console.WriteLine("Vous êtes sur la carte.");
        Console.WriteLine("1. Combattre");
        Console.WriteLine("2. Sauvergarder la partie et retourner au menu");

        Console.Write("Choix : ");
        string choice = Console.ReadLine();

        Dictionary<int, GameMenuStates> stateTransitions = new Dictionary<int, GameMenuStates>
        {
            { 1, GameMenuStates.OnFight },
            { 2, GameMenuStates.InSaveMenu }
        };

        oGame.UpdateCurrentGameState(choice, stateTransitions);
    }


}
    