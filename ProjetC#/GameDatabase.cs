using System;
using System.Collections;
using System.Collections.Generic;

public class GameDatabase
{
    private List<Item> items;
    private List<Attack> attacks;
    private List<Pokemon> pokemons;

    public GameDatabase()
    {
        items = new List<Item>();
        attacks = new List<Attack>();
        pokemons = new List<Pokemon>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void AddAttack(Attack attack)
    {
        attacks.Add(attack);
    }

    public void AddPokemon(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
    }

    public Item GetItem(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }
        Console.WriteLine("Aucun Item Trouvé");
        return null;
    }

    public Attack GetAttack(string name)
    {
        foreach (Attack attack in attacks)
        {
            if (attack.Name == name)
            {
                return attack;
            }
        }
        Console.WriteLine("Aucune Attack Trouvé");
        Console.WriteLine(name);
        return null;
    }

    public Pokemon GetPokemon(string name)
    {
        foreach (Pokemon pokemon in pokemons)
        {
            if (pokemon.Name == name)
            {
                return pokemon;
            }
        }
        Console.WriteLine("Aucun Pokemon Trouvé");
        return null;
    }
}

