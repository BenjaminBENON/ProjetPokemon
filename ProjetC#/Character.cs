using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// 2d vector
using System.Numerics;


public class Character
{
    int _iPosX = 40;
    int _iPosY = 22;

    public int PosX { get => _iPosX; set => _iPosX = value; }
    public int PosY { get => _iPosY; set => _iPosY = value; }

    public string _sCharac = "@";

    private string m_name;
    List<Pokemon> m_vPokemonsCaught;
    List<Pokemon> m_vPokemonsDiscovered;
    List<Pokemon> m_vPokemonsFighter;
    List<Item> m_vObject;

    private int m_money; // Allow buy consommable at market
    private Level m_level; // Level instance

    // + attribute 
    Vector2 m_2dlocation;

    public Character(string name)
    {
        m_name = name;
        m_2dlocation = new Vector2(0.0f, 0.0f);
        m_vPokemonsCaught = new List<Pokemon>(); // Give One start Low level Pokemon
        m_vPokemonsDiscovered = new List<Pokemon>();
        m_vPokemonsFighter = new List<Pokemon>();
        m_vObject = new List<Item>();
    }

    public int Money
    {
        get { return m_money; }
        set { m_money = value; }
    }

    public Level Level
    {
        get { return m_level; }
        set { m_level = value; }
    }


    // * Inventory 
    public void AddPokemon(Pokemon pokemon)
    {
        m_vPokemonsCaught.Add(pokemon);
        m_vPokemonsDiscovered.Add(pokemon);

    }

    public void RemovePokemon(Pokemon pokemon)
    {
        m_vPokemonsCaught.Remove(pokemon);
    }

    public void AddObject(Item item)
    {
        m_vObject.Add(item);
    }

    public void UseObject(int iItem, Pokemon pokemon)
    {
        m_vObject[iItem].Use(pokemon);
    }

    public void RemoveObject(Item item)
    {
        m_vObject.Remove(item);
    }

    public List<Pokemon> GetPokemonList()
    {
        return m_vPokemonsCaught;
    }

    public List<Item> GetObjectList()
    {
        return m_vObject;
    }

    // Inventory *
}

