using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 2d vector
using System.Numerics;

namespace ProjetC_
{
    public class Character
    {
        private string m_name;
        List<Pokemon> m_vPokemonsCaught;
        List<Pokemon> m_vPokemonsDiscovered; 
        List<Pokemon> m_vPokemonsFighter; 
        List<Item> m_vObject;

        // + attribute 
        Vector2 m_2dlocation;

        public Character(string name)
        {
            m_name = name;
            m_2dlocation = new Vector2(0.0f, 0.0f);
            m_vPokemonsCaught = new List<Pokemon>(); // Give One start Low level Pokemon
            m_vObject = new List<Item>();
        }


        // * Inventory 
        public void AddPokemon(Pokemon pokemon)
        {
            m_vPokemonsCaught.Add(pokemon);
        }

        public void RemovePokemon(Pokemon pokemon)
        {
            m_vPokemonsCaught.Remove(pokemon);
        }

        public void AddObject(Item item)
        {
            m_vObject.Add(item);
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
}
