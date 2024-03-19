using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetC_
{
    public class Character
    {
        List<Pokemon> m_vPokemons;
        List<Item> m_vObject;

        public Character()
        {
            m_vPokemons = new List<Pokemon>();
            m_vObject = new List<Item>();
        }

        public List<Pokemon> GetPokemonList()
        {
            return m_vPokemons;
        }

        public List<Item> GetObjectList()
        {
            return m_vObject;
        }
    }
}
