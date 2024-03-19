using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;


// Initialize a fight when fight present

public enum PlayerState
{
    Enemy,
    Character,
}

namespace ProjetC_
{
    public class Fight
    {
        private Character m_c1;
        private List<Pokemon> m_characterPokemonsList;
        // Opponent team or simply savage pokemon
        private List<Pokemon> m_enemyPokemonsList;


        // Constructor
        public Fight(Character c1, List<Pokemon> pokemonsEnemy) 
        {
            Console.WriteLine("Fight Start");
            Start(c1, pokemonsEnemy);


            Battle();

            Console.WriteLine("Fight End");
        }

        public void Start(Character c1, List<Pokemon> pokemonsEnemy)
        {
            
            m_c1 = c1;
            m_characterPokemonsList = c1.GetPokemonList();
            m_enemyPokemonsList = pokemonsEnemy;

            Console.WriteLine("------- FIGHT STARTING -------");

            Console.WriteLine("Enemy Pokemons : ");
            foreach (Pokemon item in m_enemyPokemonsList)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("My Pokemons : ");
            foreach (Pokemon item in m_characterPokemonsList)
            {
                Console.WriteLine(item.Name);
            }
        }

        // Begin the attack player has more speed attack

        //PlayerState GetFirstPlayer() {
        //    bool returnPlayer = 
        //    return 
        //}

        public void Round()
        {
            // We set the pokemon will fight
            Pokemon currentEnemyPokemon = m_enemyPokemonsList[m_enemyPokemonsList.Count - 1];
            Pokemon currentCharacterPokemon = m_characterPokemonsList[m_characterPokemonsList.Count - 1];

            while (currentEnemyPokemon.CurrentLifePoints > 0 || currentCharacterPokemon.CurrentLifePoints > 0) {
                Console.WriteLine("Attack du pokemon 1");

                Console.WriteLine("Attack du pokemon 2");
                // Choice Your attack
                // Fight
            }

            // Round finish / They fought

            m_enemyPokemonsList.RemoveAt(m_characterPokemonsList.Count - 1);
            m_characterPokemonsList.RemoveAt(m_characterPokemonsList.Count - 1);
        }
        public void Battle()
        {
            bool enemyPokemonCount = m_enemyPokemonsList.Count() <= 0;
            bool characterPokemonCount = m_characterPokemonsList.Count() <= 0;

            if (enemyPokemonCount || characterPokemonCount)
            {
                // Finish
                return;
            }

            Round();

        }
    }
}