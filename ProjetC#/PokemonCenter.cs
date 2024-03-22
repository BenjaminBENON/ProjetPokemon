using System;
using System.ComponentModel.DataAnnotations;

internal class PokemonCenter
{
    PokemonCenter() { }

    public static void DisplayCenter()
    {
        //Créer le lieu centre POKEMON
        Console.SetCursorPosition(0,0);
        Console.WriteLine("-------------------");
        Console.WriteLine("|        @@       |");
        Console.WriteLine("|                 |");
        Console.WriteLine("|              @  |");
        Console.WriteLine("|              @  |");
        Console.WriteLine("|                 |");
        Console.WriteLine("-------------------");
    }

}