using System;
using System.ComponentModel.DataAnnotations;

internal class PokemonCenter
{
    PokemonCenter() { }

    public static void DisplayCenter()
    {
        //Cr�er le lieu centre POKEMON
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2 - 3);
        Console.WriteLine("-------------------");
        Console.WriteLine("|                 |");
        Console.WriteLine("|                 |");
        Console.WriteLine("|                 |");
        Console.WriteLine("|                 |");
        Console.WriteLine("|                 |");
        Console.WriteLine("-------------------");
    }

}