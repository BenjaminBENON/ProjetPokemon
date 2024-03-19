using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;


// Initialize a fight when fight present
namespace ProjetC_
{
    public class Fight
    {
        // Constructor
        public Fight(Character c1, Character c2) 
        {
            c1.GetPokemonList();
            c1.GetObjectList();
        }
        public void Battle()
        {

        }
    }
}