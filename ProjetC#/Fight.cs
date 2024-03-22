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

public enum FightType
{
    SavagePokemon,
    Trainer,
}


public class Fight
{
    //
    PlayerState m_playerState;

    private Character m_c1;
    private List<Pokemon> m_characterPokemonsList;
    private int m_itCurrentCharacterPokemon;

    // Opponent team or simply savage pokemon
    private List<Pokemon> m_enemyPokemonsList;
    private int m_itCurrentEnemyPokemon;

    // Current
    private Pokemon m_currentCharacterPokemon;
    private Pokemon m_currentEnemyPokemon;


    private FightType m_fightType; // fight Type

    // for pokemon savage
    private Pokemon m_pokemonToCatch;


    // Constructor
    public Fight(Character c1, List<Pokemon> pokemonsEnemy, FightType fightType)
    {
        Console.WriteLine("Fight Start");
        Start(c1, pokemonsEnemy, fightType);

        Battle();

        // #TODO -> if savage we catch the pokemon / if npc, we get xp

        Console.WriteLine("Fight End");
    }

    public void Start(Character c1, List<Pokemon> pokemonsEnemy, FightType fightType)
    {
        m_fightType = fightType;
        m_c1 = c1;
        m_characterPokemonsList = c1.GetPokemonList();
        m_enemyPokemonsList = pokemonsEnemy;

        // Store pokemon for catch it after
        if (m_fightType == FightType.SavagePokemon)
        {
            m_pokemonToCatch = pokemonsEnemy[0];
        }

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
        m_currentCharacterPokemon = m_characterPokemonsList[m_characterPokemonsList.Count - 1];
        m_itCurrentCharacterPokemon = m_characterPokemonsList.Count - 1;

        m_currentEnemyPokemon = m_enemyPokemonsList[m_enemyPokemonsList.Count - 1];
        m_itCurrentEnemyPokemon = m_enemyPokemonsList.Count - 1;

        int turnCount = 0;
        while (true)
        {
            turnCount++;
            Console.Write("\n------------------------------------------------------------------------------------\n");
            Console.Write("\n------------------------------------------------------------------------------------\n");
            Console.Write("\n------------------------------------ Turn Count ------------------------------------\n");
            Console.Write(turnCount);
            Console.Write("\n------------------------------------------------------------------------------------\n");
            Console.Write("\n------------------------------------------------------------------------------------");
            m_playerState = GetFirstPlayerState(m_currentCharacterPokemon, m_currentEnemyPokemon);

            DisplayInitialInfo();

            // #TODO Separe logic of Input choice / Action system priority speed attack etc... 

            switch (m_playerState)
            {
                case PlayerState.Character:
                    Console.WriteLine("LE POKEMON DU CHARACTER ATTAQUE EN PREMIER");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("\n Le premier Pokemon a attaquer est " + m_currentCharacterPokemon.Name + " Avec " + m_currentCharacterPokemon.SpeedAttackPoint + " Points de speed attack" + " Par rapport a l'autre : " + m_currentEnemyPokemon.Name + "Avec " + m_currentEnemyPokemon.SpeedAttackPoint + " De points de speed Attack ");
                    Console.WriteLine("--------------------");
                    HandleCharacterTurn();
                    if (CheckEndOfTurn())
                    {
                        EndOfTurn();
                        return;
                    }
                    HandleEnemyTurn();
                    if (CheckEndOfTurn())
                    {
                        EndOfTurn();
                        return;
                    }
                    break;
                case PlayerState.Enemy:
                    Console.WriteLine("L'ENEMY ATTAQUE EN PREMIER");
                    Console.WriteLine("--------------------");
                    Console.WriteLine(" Le premier Pokemon a attaquer est " + m_currentEnemyPokemon.Name + " Avec " + m_currentEnemyPokemon.SpeedAttackPoint + " Points de speed attack" + " Par rapport a l'autre : " + m_currentCharacterPokemon.Name + "Avec " + m_currentCharacterPokemon.SpeedAttackPoint + " De points de speed Attack ");
                    Console.WriteLine("--------------------");
                    HandleEnemyTurn();
                    if (CheckEndOfTurn())
                    {
                        EndOfTurn();
                        return;
                    }
                    HandleCharacterTurn();
                    if (CheckEndOfTurn())
                    {
                        EndOfTurn();
                        return;
                    }
                    break;
            }

            SwitchPlayerState();
        }
    }

    private void DisplayInitialInfo()
    {
        if (m_playerState == PlayerState.Character)
        {
            Console.WriteLine($"Le premier Pokemon à attaquer est {m_currentCharacterPokemon.Name} avec {m_currentCharacterPokemon.SpeedAttackPoint} points de speed attack par rapport à {m_currentEnemyPokemon.Name} avec {m_currentEnemyPokemon.SpeedAttackPoint} de points de speed Attack");
        }
        else
        {
            Console.WriteLine($"Le premier Pokemon à attaquer est {m_currentEnemyPokemon.Name} avec {m_currentEnemyPokemon.SpeedAttackPoint} points de speed attack par rapport à {m_currentCharacterPokemon.Name} avec {m_currentCharacterPokemon.SpeedAttackPoint} de points de speed Attack");
        }

        Console.WriteLine("-------------------");
        Console.WriteLine($"Les pokemons en combat sont {m_currentEnemyPokemon.Name.ToUpper()} avec {m_currentEnemyPokemon.CurrentLifePoints} points de vie et {m_currentCharacterPokemon.Name.ToUpper()} avec {m_currentCharacterPokemon.CurrentLifePoints} points de vie");
        Console.WriteLine("-------------------");
    }

    private void HandleCharacterTurn()
    {
        string userInput;
        //do
        //{
        //    int m = 0;
        //    Console.WriteLine("-------------------");
        //    Console.WriteLine("Pokemon Switch");
        //    Console.WriteLine("-------------------");



        //    Console.WriteLine("Choisis un pokemon remplacant : \n");

        //    Console.WriteLine("1. Ne pas switch de pokemon\n");
        //    foreach (Pokemon item in m_characterPokemonsList)
        //    {
        //        if (item.Name == m_currentCharacterPokemon.Name)
        //        {
        //            continue;
        //        }
        //        Console.WriteLine(m + 2 + ". " + item.Name + "\n");
        //        m++;
        //    }

        //    userInput = Console.ReadLine();
        //    if (!Utils.IsValidSwitchPokemonInput(userInput, m_characterPokemonsList.Count)) // We use attack for Pokemon choice beacause we have same number for pokemon than of attack
        //    {
        //        Console.WriteLine("Entrée non valide. Veuillez réessayer.");
        //        continue;
        //    }

        //    int iPokemon = int.Parse(userInput);

        //    // Action

        //    if (iPokemon > 1)
        //    {
        //        string sOldPokemonName = m_currentCharacterPokemon.Name;

        //        m_itCurrentCharacterPokemon = iPokemon - 2;
        //        m_currentCharacterPokemon = m_characterPokemonsList[m_itCurrentCharacterPokemon];


        //        Console.WriteLine(" Vous avez choisir de changer de pokemon, " + " Passant de " + sOldPokemonName + " à " + m_currentCharacterPokemon.Name);
        //    }
        //    else
        //    {
        //        Console.WriteLine(" Vous n'avez pas choisi de switch de pokemon ");
        //    }
        //    break;
        //} while (true);


        //do
        //{
        //    // Item choice
        //    int k = 0;
        //    Console.WriteLine("-------------------");
        //    Console.WriteLine("Items disponibles");
        //    Console.WriteLine("-------------------");
        //    Console.WriteLine("1. Ne pas utiliser d'item\n");
        //    foreach (Item item in m_c1.GetObjectList())
        //    {
        //        Console.WriteLine(k + 2 + ". " + item.Name + "\n");
        //        k++;
        //    }
        //    userInput = Console.ReadLine();
        //    if (!Utils.IsValidItemInput(userInput, m_c1.GetObjectList().Count))
        //    {
        //        Console.WriteLine("Entrée non valide. Veuillez réessayer.");
        //        // Input again
        //        continue;
        //    }
        //    int iItem = int.Parse(userInput);

        //    // Action

        //    if (iItem > 1)
        //    {
        //        m_c1.UseObject(iItem - 2, m_currentCharacterPokemon);
        //    }
        //    else
        //    {
        //        Console.WriteLine(" Vous n'avez pas choisi d'utiliser d'item ");
        //    }
        //    break;

        //} while (true);

        do
        {
            // Attack choice
            int i = 0;
            //Console.WriteLine("Attaques disponibles CHARACTER");
            List<Attack> attackListChar = m_currentCharacterPokemon.GetAttackList();
            Console.WriteLine("-------------------");
            Console.WriteLine("Attaques Disponibles : \n");
            Console.WriteLine("-------------------");
            foreach (Attack item in attackListChar)
            {
                Console.WriteLine(i + 1 + ". " + item.Name + "\n");
                i++;
            }
            Console.WriteLine("Choisis l'attaque que tu veux lancer : \n");
            userInput = Console.ReadLine();
            if (!Utils.IsValidAttackInput(userInput))
            {
                Console.WriteLine("Entrée non valide. Veuillez réessayer.");
                continue;
            }
            int iAttackChar = int.Parse(userInput);
            // Character use attack on Enemy and himself
            Console.WriteLine("-------------------- -------------------- --------------------");
            Console.WriteLine("-------------------- CHARACTER USE ATTACK --------------------");
            m_currentCharacterPokemon.UseAttack(iAttackChar, m_currentEnemyPokemon);
            Console.WriteLine("-------------------- CHARACTER USE ATTACK --------------------");
            Console.WriteLine("-------------------- -------------------- --------------------");
            break; // Sortir de la boucle une fois que le choix de l'attaque est valide

        } while (true);
    }


    private void HandleEnemyTurn()
    {
        // L'IA de l'ennemi choisit une attaque au hasard
        int seed = DateTime.Now.Millisecond;
        Random random = new Random(seed);
        int randomIndex = random.Next(1, 4);

        // Affichage des attaques disponibles pour l'ennemi
        Console.WriteLine("-------------------");
        Console.WriteLine("ENEMY IA PART");
        Console.WriteLine("-------------------");

        List<Attack> attackListEnemy = m_currentEnemyPokemon.GetAttackList();
        for (int j = 0; j < attackListEnemy.Count; j++)
        {
            Console.WriteLine($"{j + 1}. {attackListEnemy[j].Name}");
        }

        // Utilisation de l'attaque sélectionnée par l'ennemi sur le personnage joueur
        m_currentEnemyPokemon.UseAttack(randomIndex, m_currentCharacterPokemon);
        Console.WriteLine("-------------------");
        Console.WriteLine("ENEMY IA PART");
        Console.WriteLine("-------------------");
    }

    private void SwitchPlayerState()
    {
        m_playerState = (m_playerState == PlayerState.Character) ? PlayerState.Enemy : PlayerState.Character;
    }

    private bool CheckEndOfTurn()
    {
        return m_currentEnemyPokemon.PokemonState == PokemonState.Out || m_currentCharacterPokemon.PokemonState == PokemonState.Out;
    }

    private void EndOfTurn()
    {
        Console.WriteLine("---------- Un pokemon est OUT, round terminé ----------\n");
        string aliveText = " est resté vivant, il a gagné le round ";
        string outText = " est ko !, il a perdu le round ";
        Console.WriteLine("---------- Un pokemon est OUT, round terminé ----------\n");

        Pokemon winner = m_currentEnemyPokemon.CurrentLifePoints > m_currentCharacterPokemon.CurrentLifePoints ? m_currentEnemyPokemon : m_currentCharacterPokemon;
        Pokemon loser = m_currentEnemyPokemon.CurrentLifePoints > m_currentCharacterPokemon.CurrentLifePoints ? m_currentCharacterPokemon : m_currentEnemyPokemon;
        Console.WriteLine($"{winner.Name}{aliveText} avec {winner.CurrentLifePoints} points de vie \n");
        Console.WriteLine($"{loser.Name}{outText} avec {loser.CurrentLifePoints} points de vie \n");



        if (m_currentCharacterPokemon.CurrentLifePoints > m_currentEnemyPokemon.CurrentLifePoints)
        {
            // Si le gagnant est le character on remove le pokemon enemy
            Console.WriteLine("Remove Pokemon de L'enemy");
            m_enemyPokemonsList.RemoveAt(m_itCurrentEnemyPokemon);
        }
        else
        {
            // Inversement
            Console.WriteLine("Remove Pokemon du Character");
            m_characterPokemonsList.RemoveAt(m_itCurrentCharacterPokemon);
        }
        


        // Set 0 health loser in case his health is negative
        loser.CurrentLifePoints = 0;
    }


    public void Battle()
    {
        // is rest something in arrays
        bool isRestInArrayEnemyList = m_enemyPokemonsList.Count > 0;
        bool isRestInArrayCharacterList = m_characterPokemonsList.Count > 0;
        //


        while (true)
        {
            isRestInArrayEnemyList = m_enemyPokemonsList.Count > 0;
            isRestInArrayCharacterList = m_characterPokemonsList.Count > 0;

            Console.WriteLine("Les pokemon RESTANT DU CHARACTER");
            foreach (Pokemon item in m_characterPokemonsList)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Les pokemon RESTANT DU ENEMY");
            foreach (Pokemon item in m_enemyPokemonsList)
            {
                Console.WriteLine(item.Name);
            }

            if (!isRestInArrayCharacterList || !isRestInArrayEnemyList)
            {
                Console.WriteLine("Un des 2 opponent n'a plus de pokemon");
                break;
            }
            // Finish round if pokemon is ko
            Round();
        }

        // Fin du combat -> Dresser Fight or Savage Pokemon Fight

        if (m_fightType == FightType.Trainer)
        {
            handleFinishBattleDresserFight();
        }
        if (m_fightType == FightType.SavagePokemon)
        {
            handleFinishBattleSavagePokemonFight();
        }

        Console.WriteLine("Combat Terminé");

        // Enemy loose the battle
        if (isRestInArrayCharacterList)
        {
            Console.WriteLine($" Vous avez gagné le combat\n");
        }
        // Character loose the battle
        if (isRestInArrayEnemyList)
        {
            Console.WriteLine($" Le gagnant est l'enemy\n");
        }

    }

    public void handleFinishBattleDresserFight()
    {
        m_c1.Money += 10;
        m_c1.Level.CurrentXp += 100;
        m_c1.Level.Update();
    }

    public void handleFinishBattleSavagePokemonFight()
    {
        Console.WriteLine("Le combat contre le Pokémon sauvage est terminé.");

        Console.WriteLine("Voulez-vous capturer le Pokémon sauvage ? (Oui/Non)");
        string sChoice = Console.ReadLine();

        bool hasPokeball = false;
        if (sChoice.ToLower() == "oui")
        {
            int i = 0;
            foreach (Item item in m_c1.GetObjectList())
            {
                if (item.Type == ItemType.Pokeball)
                {
                    // Remove object don't need iterator
                    m_c1.RemoveObject(item);
                    hasPokeball = true;
                }
                i++;
            }
            
            if (hasPokeball)
            {
                m_c1.AddPokemon(m_pokemonToCatch);
                Console.WriteLine("Le Pokémon sauvage a été capturé !");
            }
            else
            {
                Console.WriteLine("Vous n'avez pas de pokeball pour capturer ce pokemon");
            }
            
        }
        else
        {
            Console.WriteLine("Vous avez choisi de ne pas capturer le Pokémon sauvage.");
        }
        m_c1.Money += 10;
        m_c1.Level.CurrentXp += 100;
        m_c1.Level.Update();
    }
}
