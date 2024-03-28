using System;
using System.Collections;
using System.Collections.Generic;

public class GameDatabase
{
    private static GameDatabase instance;
    private List<Item> items = new List<Item>();
    private List<Attack> attacks = new List<Attack>();
    private List<Pokemon> pokemons = new List<Pokemon>();

    private GameDatabase() { }

    public static GameDatabase Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameDatabase();
            }
            return instance;
        }
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

    public List<Pokemon> GetAllPokemons()
    {
        return pokemons;
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

