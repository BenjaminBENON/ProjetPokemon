using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;


// Initialize a fight when fight present

public enum FirstPlayerState // who starts the round
{
    Character,
    Enemy,
}

public enum FightType
{
    SavagePokemon,
    Trainer,
}

public enum FightState
{
    Run,
    LeaveFight,
}


public class Fight
{
    //
    FirstPlayerState m_playerState;

    private ConsoleUI m_consoleUI;
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

    private FightState m_fightState; // Fight state at case player leave

    // for pokemon savage
    private Pokemon m_pokemonToCatch;

    // Selection choice 
    private int m_iCharacterPokemonChoice;
    private int m_iCharacterItemChoice;
    private int m_iCharacterAttackChoice;

    private int m_iEnemyPokemonChoice;
    private int m_iEnemyItemChoice;
    private int m_iEnemyAttackChoice;

    // Constructor
    public Fight(Character c1, List<Pokemon> pokemonsEnemy, FightType fightType)
    {
        Initialize(c1, pokemonsEnemy, fightType);
        m_consoleUI.Add("Fight Start");

        PerformFight();

        // #TODO -> if savage we catch the pokemon / if npc, we get xp

        m_consoleUI.Add("Fight End");
    }

    // Initialize
    public void Initialize(Character c1, List<Pokemon> pokemonsEnemy, FightType fightType)
    {
        m_consoleUI = new ConsoleUI();
        m_fightType = fightType;
        m_fightState = FightState.Run;
        m_c1 = c1;
        m_characterPokemonsList = new List<Pokemon>(c1.GetPokemonList());
        m_enemyPokemonsList = new List<Pokemon>(pokemonsEnemy); // We make a capy because we don't want affect original character array or enemy array

        // Store pokemon for catch it after
        if (m_fightType == FightType.SavagePokemon)
        {
            m_pokemonToCatch = pokemonsEnemy[0];
        }

        m_consoleUI.Add("------- FIGHT STARTING -------");
    }

    // Begin the attack player has more speed attack

    FirstPlayerState GetFirstPlayerState(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        return (pokemon.SpeedAttackPoint > pokemonEnemy.SpeedAttackPoint) ? FirstPlayerState.Character : FirstPlayerState.Enemy;
    }

    // Several Round - Each round one pokemon is KO
    public void PerformFight()
    {
        // is rest something in arrays
        bool isRestInArrayEnemyList = m_enemyPokemonsList.Count > 0;
        bool isRestInArrayCharacterList = m_characterPokemonsList.Count > 0;
        //


        while (true)
        {
            
            isRestInArrayEnemyList = m_enemyPokemonsList.Count > 0;
            isRestInArrayCharacterList = m_characterPokemonsList.Count > 0;

            m_consoleUI.Add("Les pokemon RESTANT DU CHARACTER");
            foreach (Pokemon item in m_characterPokemonsList)
            {
                m_consoleUI.Add(item.Name);
            }

            m_consoleUI.Add("Les pokemon RESTANT DU ENEMY");
            foreach (Pokemon item in m_enemyPokemonsList)
            {
                m_consoleUI.Add(item.Name);
            }

            if (!isRestInArrayCharacterList || !isRestInArrayEnemyList)
            {
                m_consoleUI.Add("Un des 2 opponent n'a plus de pokemon");
                break;
            }
            // Finish round if pokemon is ko
            PerformRound();
            if (m_fightState == FightState.LeaveFight)
            {
                m_consoleUI.Add("Le joueur a abandonné le combat");
                return;
            }
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

        m_consoleUI.Add("Combat Terminé");

        // Enemy loose the battle
        if (isRestInArrayCharacterList)
        {
            m_consoleUI.Add($" Vous avez gagné le combat\n");
        }
        // Character loose the battle
        if (isRestInArrayEnemyList)
        {
            m_consoleUI.Add($" Le gagnant est l'enemy\n");
        }

    }

    // #TODO -> Voir la carte du pokemon / voir les stats de l'attaque 

    // Round -> End when pokemon is KO
    public void PerformRound()
    {
        m_consoleUI.Add("--- NEW ROUND ! ---");
        m_currentCharacterPokemon = m_characterPokemonsList[m_characterPokemonsList.Count - 1];
        m_itCurrentCharacterPokemon = m_characterPokemonsList.Count - 1;

        m_currentEnemyPokemon = m_enemyPokemonsList[m_enemyPokemonsList.Count - 1];
        m_itCurrentEnemyPokemon = m_enemyPokemonsList.Count - 1;

        // #TODO add a Attack count by pokemon to follow Effect - Chose place to update effects

        while (true)
        {
            m_playerState = GetFirstPlayerState(m_currentCharacterPokemon, m_currentEnemyPokemon);

            if (m_playerState == FirstPlayerState.Character)
            {
                m_consoleUI.Add($"Le premier Pokemon à attaquer est {m_currentCharacterPokemon.Name} avec {m_currentCharacterPokemon.SpeedAttackPoint} points de speed attack par rapport à {m_currentEnemyPokemon.Name} avec {m_currentEnemyPokemon.SpeedAttackPoint} de points de speed Attack");
            }
            else
            {
                m_consoleUI.Add($"Le premier Pokemon à attaquer est {m_currentEnemyPokemon.Name} avec {m_currentEnemyPokemon.SpeedAttackPoint} points de speed attack par rapport à {m_currentCharacterPokemon.Name} avec {m_currentCharacterPokemon.SpeedAttackPoint} de points de speed Attack");
            }

            m_consoleUI.Add("-------------------");
            m_consoleUI.Add($"Les pokemons en combat sont {m_currentEnemyPokemon.Name.ToUpper()} avec {m_currentEnemyPokemon.CurrentLifePoints} points de vie et {m_currentCharacterPokemon.Name.ToUpper()} avec {m_currentCharacterPokemon.CurrentLifePoints} points de vie");
            m_consoleUI.Add("-------------------");

            // #TODO Separe logic of Input choice / Action system priority speed attack etc... 

            CharacterSelection();
            if (m_fightState == FightState.LeaveFight)
            {
                return;
            }

            switch (m_playerState)
            {
                case FirstPlayerState.Character:
                    m_consoleUI.Add("LE POKEMON DU CHARACTER ATTAQUE EN PREMIER");
                    m_consoleUI.Add("--------------------");
                    m_consoleUI.Add("\n Le premier Pokemon a attaquer est " + m_currentCharacterPokemon.Name + " Avec " + m_currentCharacterPokemon.SpeedAttackPoint + " Points de speed attack" + " Par rapport a l'autre : " + m_currentEnemyPokemon.Name + "Avec " + m_currentEnemyPokemon.SpeedAttackPoint + " De points de speed Attack ");
                    m_consoleUI.Add("--------------------");
                    PerformCharacterActions();
                    PerformEnemyActions();
                    break;
                case FirstPlayerState.Enemy:
                    m_consoleUI.Add("L'ENEMY ATTAQUE EN PREMIER");
                    m_consoleUI.Add("--------------------");
                    m_consoleUI.Add(" Le premier Pokemon a attaquer est " + m_currentEnemyPokemon.Name + " Avec " + m_currentEnemyPokemon.SpeedAttackPoint + " Points de speed attack" + " Par rapport a l'autre : " + m_currentCharacterPokemon.Name + "Avec " + m_currentCharacterPokemon.SpeedAttackPoint + " De points de speed Attack ");
                    m_consoleUI.Add("--------------------");
                    PerformEnemyActions();
                    PerformCharacterActions();
                    break;
            }
        }
    }
    private void PerformCharacterActions()
    {
        //Update Effects
        m_currentCharacterPokemon.UpdateEffects();

        if (m_currentCharacterPokemon.PokemonState == PokemonState.CannotAttack)
        {
            return;
        }


        m_consoleUI.Add("PerformCharacterActions");
        // Switch Pokemon Action
        if (m_iCharacterPokemonChoice > 1)
        {
            m_consoleUI.Add("Switch de pokemon\n");
            string sOldPokemonName = m_currentCharacterPokemon.Name;

            m_itCurrentCharacterPokemon = m_iCharacterPokemonChoice - 2; // Handle user experience with 1.0 / 2.0 etc ...
            m_currentCharacterPokemon = m_characterPokemonsList[m_itCurrentCharacterPokemon];
            m_consoleUI.Add(" Vous avez choisir de changer de pokemon, " + " Passant de " + sOldPokemonName + " à " + m_currentCharacterPokemon.Name);
        }
        // Use Item Action
        if (m_iCharacterItemChoice > 1)
        {
            m_consoleUI.Add("Utilisation d'item\n");
            m_c1.UseObject(m_iCharacterItemChoice - 2, m_currentCharacterPokemon);
        }
        // Update effects action

        // Attack Action

        // Character use attack on Enemy and himself
        m_consoleUI.Add("-------------------- -------------------- --------------------");
        m_consoleUI.Add("-------------------- CHARACTER USE ATTACK --------------------");
        m_currentCharacterPokemon.UseAttack(m_iCharacterAttackChoice-1, m_currentEnemyPokemon);
        m_consoleUI.Add("-------------------- CHARACTER USE ATTACK --------------------");
        m_consoleUI.Add("-------------------- -------------------- --------------------");

        if (CheckEndOfRound())
        {
            PerformEndOfRound();
            return;
        }
    }
    private void PerformEnemyActions()
    {

        //Update Effects
        m_currentEnemyPokemon.UpdateEffects();

        if (m_currentEnemyPokemon.PokemonState == PokemonState.CannotAttack)
        {
            return;
        }

        // L'IA de l'ennemi choisit une attaque au hasard
        int seed = DateTime.Now.Millisecond;
        Random random = new Random(seed);
        int randomIndex = random.Next(1, 4);

        // Affichage des attaques disponibles pour l'ennemi
        m_consoleUI.Add("-------------------");
        m_consoleUI.Add("ENEMY IA PART");
        m_consoleUI.Add("-------------------");

        //List<Attack> attackListEnemy = m_currentEnemyPokemon.GetAttackList();
        //for (int j = 0; j < attackListEnemy.Count; j++)
        //{
        //    m_consoleUI.Add($"{j + 1}. {attackListEnemy[j].Name}");
        //}

        // Utilisation de l'attaque sélectionnée par l'ennemi sur le personnage joueur
        m_currentEnemyPokemon.UseAttack(randomIndex, m_currentCharacterPokemon);
        m_consoleUI.Add("-------------------");
        m_consoleUI.Add("ENEMY IA PART");
        m_consoleUI.Add("-------------------");

        if (CheckEndOfRound())
        {
            PerformEndOfRound();
            return;
        }
    }

    // Character Selection
    private void LeaveFightSelection(string userInput)
    {
        m_consoleUI.Add("-------------------");
        m_consoleUI.Add("Abandon du combat");
        m_consoleUI.Add("-------------------");
        do
        {
            m_consoleUI.Add("Souhaitez vous abandonner le combat ? (oui/non)");
            userInput = Console.ReadLine();
            if (!Utils.IsValidTrueFalseInput(userInput))
            {
                m_consoleUI.Add("Entrée non valide. Veuillez réessayer.");
                continue;

            }
            if (userInput.ToLower() == "non")
            {
                break;
            }
            m_fightState = FightState.LeaveFight;
            break;
        } while (true);
    }

    public void DisplayPokemonCard()
    {
        m_consoleUI.Add("Pokemon Actuel\n");
        m_consoleUI.Add("Nom : \n" + m_currentCharacterPokemon.Name);
        m_consoleUI.Add("Type : \n" + m_currentCharacterPokemon.Type);
        m_consoleUI.Add("Points de vie actuels : \n" + m_currentCharacterPokemon.CurrentLifePoints);
        m_consoleUI.Add("Vitesse d'attaque : \n" + m_currentCharacterPokemon.SpeedAttackPoint);
        m_consoleUI.Add("Points d'attaque : \n" + m_currentCharacterPokemon.AttackPoint);
        m_consoleUI.Add("Points de défense : \n" + m_currentCharacterPokemon.DefensePoint);
        m_consoleUI.Add("Points de précision : \n" + m_currentCharacterPokemon.PrecisionPoint);
        m_consoleUI.Add("Points d'esquive : \n" + m_currentCharacterPokemon.EsquivePoint);

        m_consoleUI.Add("Attaques :\n");
        foreach (Attack attack in m_currentCharacterPokemon.GetAttackList())
        {
            m_consoleUI.Add("Nom -> " + attack.Name);
            m_consoleUI.Add("Power -> " + attack.Power);
            m_consoleUI.Add("-------\n");
        }
    }
    private void SwitchPokemonSelection(string userInput)
    {
        do
        {
            int m = 0;
            m_consoleUI.Add("-------------------");
            m_consoleUI.Add("Pokemon Switch");
            m_consoleUI.Add("-------------------");
            m_consoleUI.Add("Choisis un pokemon remplacant : \n");
            m_consoleUI.Add("1. Ne pas switch de pokemon\n");
            foreach (Pokemon item in m_characterPokemonsList)
            {
                if (item.Name == m_currentCharacterPokemon.Name)
                {
                    continue;
                }
                m_consoleUI.Add(m + 2 + ". " + item.Name + "\n");
                m++;
            }

            userInput = Console.ReadLine();
            if (!Utils.IsValidSwitchPokemonInput(userInput, m_characterPokemonsList.Count)) // We use attack for Pokemon choice beacause we have same number for pokemon than of attack
            {
                m_consoleUI.Add("Entrée non valide. Veuillez réessayer.");
                continue;
            }

            m_iCharacterPokemonChoice = int.Parse(userInput); 

            // Action
            if (m_iCharacterPokemonChoice > 1)
            {
                string sOldPokemonName = m_currentCharacterPokemon.Name;

                //m_itCurrentCharacterPokemon = m_iCharacterPokemonChoice - 2; // Handle user experience with 1.0 / 2.0 etc ...
                //m_currentCharacterPokemon = m_characterPokemonsList[m_itCurrentCharacterPokemon];

                // Temporarily
                int itCurrentCharacterPokemon = m_iCharacterPokemonChoice - 2; // Handle user experience with 1.0 / 2.0 etc ...
                Pokemon currentCharacterPokemon = m_characterPokemonsList[itCurrentCharacterPokemon];


                m_consoleUI.Add(" Vous avez choisir de changer de pokemon, " + " Passant de " + sOldPokemonName + " à " + currentCharacterPokemon.Name);
            }
            else
            {
                m_consoleUI.Add(" Vous n'avez pas choisi de switch de pokemon ");
            }
            break;
        } while (true);

    }
    private void ItemSelection(string userInput)
    {
        do
        {
            // Item choice
            int k = 0;
            m_consoleUI.Add("-------------------");
            m_consoleUI.Add("Items disponibles");
            m_consoleUI.Add("-------------------");
            m_consoleUI.Add("1. Ne pas utiliser d'item\n");
            foreach (Item item in m_c1.GetObjectList())
            {
                m_consoleUI.Add(k + 2 + ". " + item.Name + "\n");
                k++;
            }
            userInput = Console.ReadLine();
            if (!Utils.IsValidItemInput(userInput, m_c1.GetObjectList().Count))
            {
                m_consoleUI.Add("Entrée non valide. Veuillez réessayer.");
                // Input again
                continue;
            }
            m_iCharacterItemChoice = int.Parse(userInput);

            // Action

            if (m_iCharacterItemChoice > 1)
            {
                m_consoleUI.Add("Vous avez choisi d'utiliser :" + m_c1.GetObjectList()[m_iCharacterItemChoice-2].Name + "\n");
            }
            else
            {
                m_consoleUI.Add(" Vous n'avez pas choisi d'utiliser d'item ");
            }
            break;

        } while (true);
    }
    private void AttackSelection(string userInput)
    {
        do
        {
            // Attack choice
            int i = 0;
            //m_consoleUI.Add("Attaques disponibles CHARACTER");
            List<Attack> attackListChar = m_currentCharacterPokemon.GetAttackList();
            m_consoleUI.Add("-------------------");
            m_consoleUI.Add("Attaques Disponibles : \n");
            m_consoleUI.Add("-------------------");
            foreach (Attack item in attackListChar)
            {
                m_consoleUI.Add(i + 1 + ". " + item.Name + "\n");
                i++;
            }
            m_consoleUI.Add("Choisis l'attaque que tu veux lancer : \n");
            userInput = Console.ReadLine();
            if (!Utils.IsValidAttackInput(userInput))
            {
                m_consoleUI.Add("Entrée non valide. Veuillez réessayer.");
                continue;
            }
            m_iCharacterAttackChoice = int.Parse(userInput);

            break;

        } while (true);
    }
    private void CharacterSelection()
    {
        string userInput = "";

        //LeaveFightSelection(userInput);
        //if (m_fightState == FightState.LeaveFight)
        //{
        //    return;
        //}
        DisplayPokemonCard();
        SwitchPokemonSelection(userInput);
        ItemSelection(userInput);
        AttackSelection(userInput);
    }

    // Check
    private bool CheckEndOfRound()
    {
        // The pokemon is set Out in his Current Life method if his life go down 0, this finish the pokemon round
        return m_currentEnemyPokemon.PokemonState == PokemonState.Out || m_currentCharacterPokemon.PokemonState == PokemonState.Out;
    }
    private void PerformEndOfRound()
    {
        m_consoleUI.Add("---------- Un pokemon est OUT, round terminé ----------\n");
        string aliveText = " est resté vivant, il a gagné le round ";
        string outText = " est ko !, il a perdu le round ";
        m_consoleUI.Add("---------- Un pokemon est OUT, round terminé ----------\n");

        Pokemon winner = m_currentEnemyPokemon.CurrentLifePoints > m_currentCharacterPokemon.CurrentLifePoints ? m_currentEnemyPokemon : m_currentCharacterPokemon;
        Pokemon loser = m_currentEnemyPokemon.CurrentLifePoints > m_currentCharacterPokemon.CurrentLifePoints ? m_currentCharacterPokemon : m_currentEnemyPokemon;
        m_consoleUI.Add($"{winner.Name}{aliveText} avec {winner.CurrentLifePoints} points de vie \n");
        m_consoleUI.Add($"{loser.Name}{outText} avec {loser.CurrentLifePoints} points de vie \n");



        if (m_currentCharacterPokemon.CurrentLifePoints > m_currentEnemyPokemon.CurrentLifePoints)
        {
            // Si le gagnant est le character on remove le pokemon enemy
            m_consoleUI.Add("Remove Pokemon de L'enemy");
            m_enemyPokemonsList.RemoveAt(m_itCurrentEnemyPokemon);
        }
        else
        {
            // Inversement
            m_consoleUI.Add("Remove Pokemon du Character");
            m_characterPokemonsList.RemoveAt(m_itCurrentCharacterPokemon);
        }
        


        // Set 0 health loser in case his health is negative
        loser.CurrentLifePoints = 0;
    }



    // End fight #TO THINK -> Make 2 deriv class
    public void handleFinishBattleDresserFight()
    {
        m_c1.Money += 10;
        m_c1.Level.CurrentXp += 100;
        m_c1.Level.Update();
    }
    public void handleFinishBattleSavagePokemonFight()
    {
        m_consoleUI.Add("Le combat contre le Pokémon sauvage est terminé.");



        bool hasPokeball = false;
        Item removeItem = null;
        do
        {
            m_consoleUI.Add("Voulez-vous capturer le Pokémon sauvage ? (Oui/Non)");
            string sChoice = Console.ReadLine();


            if (!Utils.IsValidTrueFalseInput(sChoice))
            {
                continue;
            }

            if (sChoice.ToLower() == "non")
            {
                m_consoleUI.Add("Vous avez choisi de ne pas capturer le Pokémon sauvage.");
                break;
            }

            int i = 0;
            foreach (Item item in m_c1.GetObjectList())
            {
                if (item.Type == ItemType.Pokeball)
                {
                    // Remove object don't need iterator
                    removeItem = item;
                    hasPokeball = true;
                }
                i++;
            }

            if (hasPokeball)
            {
                m_c1.RemoveObject(removeItem);
                m_c1.AddPokemon(m_pokemonToCatch);
                m_consoleUI.Add("Le Pokémon sauvage a été capturé !");

                // Vous voici avec ces pokemon / ses objets 


                //foreach (Pokemon item in m_c1.GetPokemonList()) { 
                //    m_consoleUI.Add(item.Name);
                //}


                foreach (Item item in m_c1.GetObjectList())
                {
                    m_consoleUI.Add(item.Name);
                }
            }
            else
            {
                m_consoleUI.Add("Vous n'avez pas de pokeball pour capturer ce pokemon");
            }
            break;
            
        } while (true);

        m_c1.Money += 10;
        m_c1.Level.CurrentXp += 100;
        m_c1.Level.Update();
    }
}
