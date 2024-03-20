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
        List<Pokemon> m_vPokemonsDiscovered; // Inventory Class -> ?
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

        public List<Pokemon> GetPokemonList()
        {
            return m_vPokemonsCaught;
        }

        public List<Item> GetObjectList()
        {
            return m_vObject;
        }
    }
}
