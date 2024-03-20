using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            //Console.WriteLine("Enemy Pokemons : ");
            //foreach (Pokemon item in m_enemyPokemonsList)
            //{
            //    Console.WriteLine("POKEMON NAME : " + item.Name);
            //    foreach (Attack atc in item.GetAttackList())
            //    {
            //        Console.WriteLine(atc.Name); 
            //    }
                    
            //}

            //Console.WriteLine("My Pokemons : ");
            //foreach (Pokemon item in m_characterPokemonsList)
            //{
            //    Console.WriteLine("POKEMON NAME : " + item.Name);
            //    foreach (Attack atc in item.GetAttackList())
            //    {
            //        Console.WriteLine(atc.Name);
            //    }
            //}
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

            // Round start
            while (true)
            {
                Console.WriteLine("Les pokemons en combat sont " + currentEnemyPokemon.Name + " Avec " + currentEnemyPokemon.CurrentLifePoints + " Point de vie " + "et " + currentCharacterPokemon.Name + " Avec " + currentCharacterPokemon.CurrentLifePoints + " Point de vie ");
                int i;
                int k;
                if (Convert.ToInt32(playerState) == 0)
                {
                    // Item choice
                    k = 0;
                    Console.Write("Items disponibles\n");
                    Console.Write("0. Ne pas utiliser d'item\n");
                    foreach (Item item in m_c1.GetObjectList())
                    {
                        Console.WriteLine(k + 1 + ". " + item.Name);
                        k++;
                    }
                    string sItem = Console.ReadLine();
                    int iItem = int.Parse(sItem);

                    if (!Utils.IsValidItemInput(sItem))
                    {
                        continue;
                    }
                    // If don't want use item
                    if (iItem != 0)
                    {
                        m_c1.UseObject(iItem, currentCharacterPokemon);
                    }

                    // Attack choice
                    i = 0;
                    Console.Write("Attaques disponibles CHARACTER\n");
                    List<Attack> attackList = currentCharacterPokemon.GetAttackList();
                    foreach (Attack item in attackList)
                    {

                        Console.WriteLine(i + 1 + ". " + item.Name);
                        i++;
                    }
                    Console.Write("Choisis l'attaque que tu veux lancer : \n");
                    string sAttack = Console.ReadLine();
                    if (!Utils.IsValidAttackInput(sAttack))
                    {
                        continue;
                    }
                    int iAttack = int.Parse(sAttack);
                    // Character use attack on Enemy and himself
                    currentCharacterPokemon.UseAttack(iAttack, currentEnemyPokemon);
                }
                if ((Convert.ToInt32(playerState) == 1))
                {
                    i = 0;
                    Console.Write("Attaques disponibles ENEMY\n");
                    List<Attack> attackList = currentEnemyPokemon.GetAttackList();
                    foreach (Attack item in attackList)
                    {

                        Console.WriteLine(i + ". " + item.Name);
                        i++;
                    }
                    Console.Write("Choisis l'attaque que tu veux lancer : \n");
                    string sAttack = Console.ReadLine();
                    if (!Utils.IsValidAttackInput(sAttack))
                    {
                        continue;
                    }
                    int iAttack = int.Parse(sAttack);
                    // Enemy use attack on Character and himself
                    currentEnemyPokemon.UseAttack(iAttack, currentCharacterPokemon);
                }
                // Turn Finish
                // Switch turn
                playerState = (playerState == PlayerState.Character) ? PlayerState.Enemy : PlayerState.Character;

                // Check end
                if (currentEnemyPokemon.PokemonState == PokemonState.Out || currentCharacterPokemon.PokemonState == PokemonState.Out)
                {
                    Console.WriteLine("---------- Un pokemon est OUT, round terminé ----------");
                    string aliveText = "est resté vivant, il a gangé le round";
                    string outText = "est ko !, il a perdu le round";
                    Console.WriteLine("---------- Un pokemon est OUT, round terminé ----------");
                    // Determine object pokemon who win and defeat
                    Pokemon winner = currentEnemyPokemon.CurrentLifePoints > currentCharacterPokemon.CurrentLifePoints ? currentEnemyPokemon : currentCharacterPokemon;
                    Pokemon loser = currentEnemyPokemon.CurrentLifePoints > currentCharacterPokemon.CurrentLifePoints ? currentCharacterPokemon : currentEnemyPokemon;
                    Console.WriteLine(winner.Name + " Avec " + winner.CurrentLifePoints + " Points de vie "+ loser.Name + " Avec " + loser.CurrentLifePoints + " Points de vie ");
                    loser.CurrentLifePoints = 0;
                    break;
                }
            }

            // Round Finish

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
            Battle();

        }
    }
}