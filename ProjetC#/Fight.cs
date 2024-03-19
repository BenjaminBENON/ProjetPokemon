using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;


// Initialize a fight when fight present

public enum PlayerState
{
    Character,
    Enemy,
}

namespace ProjetC_
{
    public class Fight
    {
        //
        PlayerState playerState;

        private Character m_c1;
        private List<Pokemon> m_characterPokemonsList;
        // Opponent team or simply savage pokemon
        private List<Pokemon> m_enemyPokemonsList;

        string m_type; // fight Type


        // Constructor
        public Fight(Character c1, List<Pokemon> pokemonsEnemy, string fightType)
        {
            Console.WriteLine("Fight Start");
            Start(c1, pokemonsEnemy, fightType);

            Battle();

            // #TODO -> if savage we catch the pokemon / if npc, we get xp

            Console.WriteLine("Fight End");
        }

        public void Start(Character c1, List<Pokemon> pokemonsEnemy, string fightType)
        {
            playerState = PlayerState.Character;
            m_type = fightType;
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

            while (currentEnemyPokemon.PokemonState != PokemonState.Out || currentCharacterPokemon.PokemonState != PokemonState.Out)
            {
                Console.WriteLine("Player State" + playerState);
                //Console.WriteLine("Attack du pokemon 1");

                int i;
                if (Convert.ToInt32(playerState) == 0)
                {
                    Console.WriteLine("Character");
                    Console.WriteLine("Pokemon Attack");
                    i = 0;
                    foreach (Attack item in currentCharacterPokemon.GetAttackList())
                    {

                        Console.WriteLine(i + ". " + item.Name);
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("Enemy");
                    Console.WriteLine("Pokemon Attack");
                    i = 0;
                    foreach (Attack item in currentEnemyPokemon.GetAttackList())
                    {

                        Console.WriteLine(i + ". " + item.Name);
                        i++;
                    }
                }

                //Console.WriteLine("Attack du pokemon 2");



                playerState = (playerState == PlayerState.Character) ? PlayerState.Enemy : PlayerState.Character;
                // Choice Your attack
                // Fight
            }

            // Switch turn


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