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
        private Character m_c1;
        private Character m_c2;

        // Constructor
        public Fight(Character c1, Character c2) 
        {
            Console.WriteLine("Fight Start");
            Start(c1, c2);
            Battle();
            Console.WriteLine("Fight End");
        }

        public void Start(Character c1, Character c2)
        {
            m_c1 = c1;
            m_c2 = c2;
        }
        public void Battle()
        {

            //c1.GetPokemonList();
            //c1.GetObjectList();

        }
    }
}