﻿using System;
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
        PlayerState m_playerState;

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
            m_type = fightType;
            m_c1 = c1;
            m_characterPokemonsList = c1.GetPokemonList();
            m_enemyPokemonsList = pokemonsEnemy;

            Console.WriteLine("------- FIGHT STARTING -------");
        }

        // Begin the attack player has more speed attack

        PlayerState GetFirstPlayerState(Pokemon pokemon, Pokemon pokemonEnemy)
        {
            return (pokemon.SpeedAttackPoint > pokemonEnemy.SpeedAttackPoint) ? PlayerState.Character : PlayerState.Enemy;
        }

        public void Round()
        {
            Console.WriteLine("--- NEW ROUND ! ---");
            Pokemon currentCharacterPokemon = m_characterPokemonsList[m_characterPokemonsList.Count - 1];
            Pokemon currentEnemyPokemon = m_enemyPokemonsList[m_enemyPokemonsList.Count - 1];

            int turnCount = 0;
            while (true)
            {
                m_playerState = GetFirstPlayerState(currentCharacterPokemon, currentEnemyPokemon);

                DisplayInitialInfo(currentCharacterPokemon, currentEnemyPokemon);

                switch (m_playerState)
                {
                    case PlayerState.Character:
                        Console.WriteLine("LE POKEMON DU CHARACTER ATTAQUE EN PREMIER");
                        Console.WriteLine("--------------------");
                        Console.WriteLine(" Le premier Pokemon a attaquer est " + currentCharacterPokemon.Name + " Avec " + currentCharacterPokemon.SpeedAttackPoint + " Points de speed attack" + " Par rapport a l'autre : " + currentEnemyPokemon.Name + "Avec " + currentEnemyPokemon.SpeedAttackPoint + " De points de speed Attack ");
                        Console.WriteLine("--------------------");
                        if (HandleCharacterTurn(currentCharacterPokemon, currentEnemyPokemon) == "InputNotValid")
                        {
                            continue;
                        }
                        HandleEnemyTurn(currentEnemyPokemon, currentCharacterPokemon);
                        break;
                    case PlayerState.Enemy:
                        Console.WriteLine("L'ENEMY ATTAQUE EN PREMIER");
                        Console.WriteLine("--------------------");
                        Console.WriteLine(" Le premier Pokemon a attaquer est " + currentEnemyPokemon.Name + " Avec " + currentEnemyPokemon.SpeedAttackPoint + " Points de speed attack" + " Par rapport a l'autre : " + currentCharacterPokemon.Name + "Avec " + currentCharacterPokemon.SpeedAttackPoint + " De points de speed Attack ");
                        Console.WriteLine("--------------------");
                        HandleEnemyTurn(currentEnemyPokemon, currentCharacterPokemon);
                        HandleCharacterTurn(currentCharacterPokemon, currentEnemyPokemon);
                        
                        break;
                }

                SwitchPlayerState();

                if (CheckEndOfBattle(currentCharacterPokemon, currentEnemyPokemon))
                {
                    DisplayEndOfBattleInfo(currentCharacterPokemon, currentEnemyPokemon);
                    break;
                }

                if (turnCount >= 4)
                {
                    // Clear console
                    //Console.Clear();
                    turnCount = 0;
                }
                turnCount++;
            }

            FinishRound();
        }

        private void DisplayInitialInfo(Pokemon currentCharacterPokemon, Pokemon currentEnemyPokemon)
        {
            if (m_playerState == PlayerState.Character)
            {
                Console.WriteLine($"Le premier Pokemon à attaquer est {currentCharacterPokemon.Name} avec {currentCharacterPokemon.SpeedAttackPoint} points de speed attack par rapport à {currentEnemyPokemon.Name} avec {currentEnemyPokemon.SpeedAttackPoint} de points de speed Attack");
            }
            else
            {
                Console.WriteLine($"Le premier Pokemon à attaquer est {currentEnemyPokemon.Name} avec {currentEnemyPokemon.SpeedAttackPoint} points de speed attack par rapport à {currentCharacterPokemon.Name} avec {currentCharacterPokemon.SpeedAttackPoint} de points de speed Attack");
            }

            Console.WriteLine("-------------------");
            Console.WriteLine($"Les pokemons en combat sont {currentEnemyPokemon.Name.ToUpper()} avec {currentEnemyPokemon.CurrentLifePoints} points de vie et {currentCharacterPokemon.Name.ToUpper()} avec {currentCharacterPokemon.CurrentLifePoints} points de vie");
            Console.WriteLine("-------------------");
        }

        private string HandleCharacterTurn(Pokemon currentCharacterPokemon, Pokemon currentEnemyPokemon)
        {
            // Item choice
            int k = 0;
            Console.WriteLine("-------------------");
            Console.WriteLine("Items disponibles");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Ne pas utiliser d'item\n");
            foreach (Item item in m_c1.GetObjectList())
            {
                Console.WriteLine(k + 2 + ". " + item.Name + "\n");
                k++;
            }
            string sItem = Console.ReadLine();
            if (!Utils.IsValidItemInput(sItem, m_c1.GetObjectList().Count))
            {
                return "InputNotValid";
            }
            int iItem = int.Parse(sItem);

            // If don't want use item
            if (iItem > 1)
            {
                m_c1.UseObject(iItem - 2, currentCharacterPokemon);
            }

            // Attack choice
            int i = 0;
            //Console.WriteLine("Attaques disponibles CHARACTER");
            List<Attack> attackListChar = currentCharacterPokemon.GetAttackList();
            Console.WriteLine("-------------------");
            Console.WriteLine("Attaques Disponibles : \n");
            Console.WriteLine("-------------------");
            foreach (Attack item in attackListChar)
            {
                Console.WriteLine(i + 1 + ". " + item.Name + "\n");
                i++;
            }
            Console.WriteLine("Choisis l'attaque que tu veux lancer : \n");
            string sAttackChar = Console.ReadLine();
            if (!Utils.IsValidAttackInput(sAttackChar))
            {
                return "InputNotValid";
            }
            int iAttackChar = int.Parse(sAttackChar);
            // Character use attack on Enemy and himself
            currentCharacterPokemon.UseAttack(iAttackChar, currentEnemyPokemon);

            return "";
        }

        

        private void HandleEnemyTurn(Pokemon currentEnemyPokemon, Pokemon currentCharacterPokemon)
        {
            // L'IA de l'ennemi choisit une attaque au hasard
            int seed = DateTime.Now.Millisecond;
            Random random = new Random(seed);
            int randomIndex = random.Next(1, 4);

            // Affichage des attaques disponibles pour l'ennemi
            Console.WriteLine("-------------------");
            Console.WriteLine("ENEMY IA PART");
            Console.WriteLine("-------------------");

            List<Attack> attackListEnemy = currentEnemyPokemon.GetAttackList();
            for (int j = 0; j < attackListEnemy.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {attackListEnemy[j].Name}");
            }

            // Utilisation de l'attaque sélectionnée par l'ennemi sur le personnage joueur
            currentEnemyPokemon.UseAttack(randomIndex, currentCharacterPokemon);
            Console.WriteLine("-------------------");
            Console.WriteLine("ENEMY IA PART");
            Console.WriteLine("-------------------");
        }

        private void SwitchPlayerState()
        {
            m_playerState = (m_playerState == PlayerState.Character) ? PlayerState.Enemy : PlayerState.Character;
        }

        private bool CheckEndOfBattle(Pokemon currentCharacterPokemon, Pokemon currentEnemyPokemon)
        {
            return currentEnemyPokemon.PokemonState == PokemonState.Out || currentCharacterPokemon.PokemonState == PokemonState.Out;
        }

        private void DisplayEndOfBattleInfo(Pokemon currentCharacterPokemon, Pokemon currentEnemyPokemon)
        {
            Console.WriteLine("---------- Un pokemon est OUT, round terminé ----------\n");
            string aliveText = " est resté vivant, il a gagné le round ";
            string outText = " est ko !, il a perdu le round ";
            Console.WriteLine("---------- Un pokemon est OUT, round terminé ----------\n");

            Pokemon winner = currentEnemyPokemon.CurrentLifePoints > currentCharacterPokemon.CurrentLifePoints ? currentEnemyPokemon : currentCharacterPokemon;
            Pokemon loser = currentEnemyPokemon.CurrentLifePoints > currentCharacterPokemon.CurrentLifePoints ? currentCharacterPokemon : currentEnemyPokemon;
            Console.WriteLine($"{winner.Name}{aliveText} avec {winner.CurrentLifePoints} points de vie \n");
            Console.WriteLine($"{loser.Name}{outText} avec {loser.CurrentLifePoints} points de vie \n");
            loser.CurrentLifePoints = 0;
        }

        private void FinishRound()
        {
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