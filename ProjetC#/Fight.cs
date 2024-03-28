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
        CustomConsole.Instance.WriteText("Fight Start");

        PerformFight();

        // #TODO -> if savage we catch the pokemon / if npc, we get xp

        CustomConsole.Instance.WriteText("Fight End");
        
    }

    // Initialize
    public void Initialize(Character c1, List<Pokemon> pokemonsEnemy, FightType fightType)
    {

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
    }

    // Begin the attack player has more speed attack

    FirstPlayerState GetFirstPlayerState(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        return (pokemon.SpeedAttackPoint > pokemonEnemy.SpeedAttackPoint) ? FirstPlayerState.Character : FirstPlayerState.Enemy;
    }

    // Several Round - Each round one pokemon is KO
    public void PerformFight()
    {

        CustomConsole.Instance.DisplayPokemons();

        CustomConsole.Instance.m_allowWrite = true;
        CustomConsole.Instance.SetPositionState(CustomConsole.PositionState.Middle);
        CustomConsole.Instance.WriteText("------- FIGHT STARTING -------");

        // is rest something in arrays
        bool isRestInArrayEnemyList = m_enemyPokemonsList.Count > 0;
        bool isRestInArrayCharacterList = m_characterPokemonsList.Count > 0;


        while (true)
        {
            
            isRestInArrayEnemyList = m_enemyPokemonsList.Count > 0;
            isRestInArrayCharacterList = m_characterPokemonsList.Count > 0;

            CustomConsole.Instance.WriteText("Les pokemon RESTANT DU CHARACTER");
            foreach (Pokemon item in m_characterPokemonsList)
            {
                CustomConsole.Instance.WriteText(item.Name);
            }

            CustomConsole.Instance.WriteText("Les pokemon RESTANT DU ENEMY");
            foreach (Pokemon item in m_enemyPokemonsList)
            {
                CustomConsole.Instance.WriteText(item.Name);
            }

            if (!isRestInArrayCharacterList || !isRestInArrayEnemyList)
            {
                CustomConsole.Instance.WriteText("Un des 2 opponent n'a plus de pokemon");
                break;
            }
            // Finish round if pokemon is ko
            PerformRound();
            if (m_fightState == FightState.LeaveFight)
            {
                CustomConsole.Instance.WriteText("Le joueur a abandonné le combat");
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

        CustomConsole.Instance.WriteText("Combat Terminé");

        // Enemy loose the battle
        if (isRestInArrayCharacterList)
        {
            CustomConsole.Instance.WriteText($" Vous avez gagné le combat");
        }
        // Character loose the battle
        if (isRestInArrayEnemyList)
        {
            CustomConsole.Instance.WriteText($" Le gagnant est l'enemy");
        }

    }

    // #TODO -> Voir la carte du pokemon / voir les stats de l'attaque 

    // Round -> End when pokemon is KO
    public void PerformRound()
    {
        CustomConsole.Instance.WriteText("--- NEW ROUND ! ---");
        m_currentCharacterPokemon = m_characterPokemonsList[m_characterPokemonsList.Count - 1];
        m_itCurrentCharacterPokemon = m_characterPokemonsList.Count - 1;

        m_currentEnemyPokemon = m_enemyPokemonsList[m_enemyPokemonsList.Count - 1];
        m_itCurrentEnemyPokemon = m_enemyPokemonsList.Count - 1;

        // #TODO add a Attack count by pokemon to follow Effect - Chose place to update effects

        while (true)
        {
            m_playerState = GetFirstPlayerState(m_currentCharacterPokemon, m_currentEnemyPokemon);

            CustomConsole.Instance.WriteText("-------------------");
            CustomConsole.Instance.WriteText($"Les pokemons en combat sont {m_currentEnemyPokemon.Name.ToUpper()} avec {m_currentEnemyPokemon.CurrentLifePoints} points de vie");
            CustomConsole.Instance.WriteText($"et {m_currentCharacterPokemon.Name.ToUpper()} avec {m_currentCharacterPokemon.CurrentLifePoints} points de vie");


            CustomConsole.Instance.WriteText("-------------------");

            // #TODO Separe logic of Input choice / Action system priority speed attack etc... 

            CharacterSelection();
            if (m_fightState == FightState.LeaveFight)
            {
                return;
            }
            CustomConsole.Instance.SetPositionState(CustomConsole.PositionState.Middle);

            switch (m_playerState)
            {
                case FirstPlayerState.Character:
                    CustomConsole.Instance.WriteText("LE POKEMON DU CHARACTER ATTAQUE EN PREMIER");
                    CustomConsole.Instance.WriteText("--------------------");
                    CustomConsole.Instance.WriteText("Le premier Pokemon à attaquer est " + m_currentCharacterPokemon.Name);
                    CustomConsole.Instance.WriteText("Avec " + m_currentCharacterPokemon.SpeedAttackPoint + " Points de speed attack");
                    CustomConsole.Instance.WriteText("Par rapport à l'autre : " + m_currentEnemyPokemon.Name);
                    CustomConsole.Instance.WriteText("Avec " + m_currentEnemyPokemon.SpeedAttackPoint + " De points de speed Attack");
                    CustomConsole.Instance.WriteText("--------------------");
                    PerformCharacterActions();
                    PerformEnemyActions();
                    break;
                case FirstPlayerState.Enemy:
                    CustomConsole.Instance.WriteText("L'ENEMY ATTAQUE EN PREMIER");
                    CustomConsole.Instance.WriteText("--------------------");
                    CustomConsole.Instance.WriteText("Le premier Pokemon à attaquer est " + m_currentEnemyPokemon.Name);
                    CustomConsole.Instance.WriteText("Avec " + m_currentEnemyPokemon.SpeedAttackPoint + " Points de speed attack");
                    CustomConsole.Instance.WriteText("Par rapport à l'autre : " + m_currentCharacterPokemon.Name);
                    CustomConsole.Instance.WriteText("Avec " + m_currentCharacterPokemon.SpeedAttackPoint + " De points de speed Attack");
                    CustomConsole.Instance.WriteText("--------------------");
                    PerformEnemyActions();
                    PerformCharacterActions();
                    break;
            }
        }
    }
    private void PerformCharacterActions()
    {
        CustomConsole.Instance.SetPositionState(CustomConsole.PositionState.Left);
        //Update Effects
        m_currentCharacterPokemon.UpdateEffects();

        if (m_currentCharacterPokemon.PokemonState == PokemonState.CannotAttack)
        {
            return;
        }


        CustomConsole.Instance.WriteText("PerformCharacterActions");
        // Switch Pokemon Action
        if (m_iCharacterPokemonChoice > 1)
        {
            CustomConsole.Instance.WriteText("Switch de pokemon");
            string sOldPokemonName = m_currentCharacterPokemon.Name;

            m_itCurrentCharacterPokemon = m_iCharacterPokemonChoice - 2; // Handle user experience with 1.0 / 2.0 etc ...
            m_currentCharacterPokemon = m_characterPokemonsList[m_itCurrentCharacterPokemon];
            CustomConsole.Instance.WriteText(" Vous avez choisir de changer de pokemon, " + " Passant de " + sOldPokemonName + " à " + m_currentCharacterPokemon.Name);
        }
        // Use Item Action
        if (m_iCharacterItemChoice > 1)
        {
            CustomConsole.Instance.WriteText("Utilisation d'item");
            m_c1.UseObject(m_iCharacterItemChoice - 2, m_currentCharacterPokemon);
        }
        // Update effects action

        // Attack Action

        // Character use attack on Enemy and himself
        CustomConsole.Instance.WriteText("-------------------- -------------------- --------------------");
        CustomConsole.Instance.WriteText("-------------------- CHARACTER USE ATTACK --------------------");
        m_currentCharacterPokemon.UseAttack(m_iCharacterAttackChoice-1, m_currentEnemyPokemon);
        CustomConsole.Instance.WriteText("-------------------- CHARACTER USE ATTACK --------------------");
        CustomConsole.Instance.WriteText("-------------------- -------------------- --------------------");

        if (CheckEndOfRound())
        {
            PerformEndOfRound();
            return;
        }
    }
    private void PerformEnemyActions()
    {
        CustomConsole.Instance.SetPositionState(CustomConsole.PositionState.Right);
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
        CustomConsole.Instance.WriteText("-------------------");
        CustomConsole.Instance.WriteText("ENEMY IA PART");
        CustomConsole.Instance.WriteText("-------------------");

        //List<Attack> attackListEnemy = m_currentEnemyPokemon.GetAttackList();
        //for (int j = 0; j < attackListEnemy.Count; j++)
        //{
        //    CustomConsole.Instance.WriteText($"{j + 1}. {attackListEnemy[j].Name}");
        //}

        // Utilisation de l'attaque sélectionnée par l'ennemi sur le personnage joueur
        m_currentEnemyPokemon.UseAttack(randomIndex, m_currentCharacterPokemon);
        CustomConsole.Instance.WriteText("-------------------");
        CustomConsole.Instance.WriteText("ENEMY IA PART");
        CustomConsole.Instance.WriteText("-------------------");

        if (CheckEndOfRound())
        {
            PerformEndOfRound();
            return;
        }
    }

    // Character Selection
    private void LeaveFightSelection(string userInput)
    {
        CustomConsole.Instance.WriteText("-------------------");
        CustomConsole.Instance.WriteText("Abandon du combat");
        CustomConsole.Instance.WriteText("-------------------");
        do
        {
            CustomConsole.Instance.WriteText("Souhaitez vous abandonner le combat ? (oui/non)");
            userInput = Console.ReadLine();
            if (!Utils.IsValidTrueFalseInput(userInput))
            {
                CustomConsole.Instance.WriteText("Entrée non valide. Veuillez réessayer.");
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
        CustomConsole.Instance.WriteText("Pokemon Actuel");
        CustomConsole.Instance.WriteText("Nom : " + m_currentCharacterPokemon.Name);
        CustomConsole.Instance.WriteText("Type : " + m_currentCharacterPokemon.Type);
        CustomConsole.Instance.WriteText("Points de vie actuels :" + m_currentCharacterPokemon.CurrentLifePoints);
        CustomConsole.Instance.WriteText("Vitesse d'attaque : " + m_currentCharacterPokemon.SpeedAttackPoint);
        CustomConsole.Instance.WriteText("Points d'attaque :" + m_currentCharacterPokemon.AttackPoint);
        CustomConsole.Instance.WriteText("Points de défense :" + m_currentCharacterPokemon.DefensePoint);
        CustomConsole.Instance.WriteText("Points de précision : " + m_currentCharacterPokemon.PrecisionPoint);
        CustomConsole.Instance.WriteText("Points d'esquive : " + m_currentCharacterPokemon.EsquivePoint);

        CustomConsole.Instance.WriteText("Attaques :");
        foreach (Attack attack in m_currentCharacterPokemon.GetAttackList())
        {
            CustomConsole.Instance.WriteText("Nom -> " + attack.Name);
            CustomConsole.Instance.WriteText("Power -> " + attack.Power);
            CustomConsole.Instance.WriteText("-------");
        }
    }
    private void SwitchPokemonSelection(string userInput)
    {
        do
        {
            int m = 0;
            CustomConsole.Instance.WriteText("-------------------");
            CustomConsole.Instance.WriteText("Pokemon Switch");
            CustomConsole.Instance.WriteText("-------------------");
            CustomConsole.Instance.WriteText("Choisis un pokemon remplacant : ");
            CustomConsole.Instance.WriteText("1. Ne pas switch de pokemon");
            foreach (Pokemon item in m_characterPokemonsList)
            {
                if (item.Name == m_currentCharacterPokemon.Name)
                {
                    continue;
                }
                CustomConsole.Instance.WriteText(m + 2 + ". " + item.Name + "");
                m++;
            }

            userInput = Console.ReadLine();
            if (!Utils.IsValidSwitchPokemonInput(userInput, m_characterPokemonsList.Count)) // We use attack for Pokemon choice beacause we have same number for pokemon than of attack
            {
                CustomConsole.Instance.WriteText("Entrée non valide. Veuillez réessayer.");
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


                CustomConsole.Instance.WriteText(" Vous avez choisir de changer de pokemon, " + " Passant de " + sOldPokemonName + " à " + currentCharacterPokemon.Name);
            }
            else
            {
                CustomConsole.Instance.WriteText(" Vous n'avez pas choisi de switch de pokemon ");
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
            CustomConsole.Instance.WriteText("-------------------");
            CustomConsole.Instance.WriteText("Items disponibles");
            CustomConsole.Instance.WriteText("-------------------");
            CustomConsole.Instance.WriteText("1. Ne pas utiliser d'item");
            foreach (Item item in m_c1.GetObjectList())
            {
                CustomConsole.Instance.WriteText(k + 2 + ". " + item.Name + "");
                k++;
            }
            userInput = Console.ReadLine();
            if (!Utils.IsValidItemInput(userInput, m_c1.GetObjectList().Count))
            {
                CustomConsole.Instance.WriteText("Entrée non valide. Veuillez réessayer.");
                // Input again
                continue;
            }
            m_iCharacterItemChoice = int.Parse(userInput);

            // Action

            if (m_iCharacterItemChoice > 1)
            {
                CustomConsole.Instance.WriteText("Vous avez choisi d'utiliser :" + m_c1.GetObjectList()[m_iCharacterItemChoice-2].Name + "");
            }
            else
            {
                CustomConsole.Instance.WriteText(" Vous n'avez pas choisi d'utiliser d'item ");
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
            //CustomConsole.Instance.WriteText("Attaques disponibles CHARACTER");
            List<Attack> attackListChar = m_currentCharacterPokemon.GetAttackList();
            CustomConsole.Instance.WriteText("-------------------");
            CustomConsole.Instance.WriteText("Attaques Disponibles : ");
            CustomConsole.Instance.WriteText("-------------------");
            foreach (Attack item in attackListChar)
            {
                CustomConsole.Instance.WriteText(i + 1 + ". " + item.Name + "");
                i++;
            }
            CustomConsole.Instance.WriteText("Choisis l'attaque que tu veux lancer : ");
            userInput = Console.ReadLine();
            if (!Utils.IsValidAttackInput(userInput))
            {
                CustomConsole.Instance.WriteText("Entrée non valide. Veuillez réessayer.");
                continue;
            }
            m_iCharacterAttackChoice = int.Parse(userInput);

            break;

        } while (true);
    }
    private void CharacterSelection()
    {
        CustomConsole.Instance.SetPositionState(CustomConsole.PositionState.Left);
        string userInput = "";

        LeaveFightSelection(userInput);
        if (m_fightState == FightState.LeaveFight)
        {
            return;
        }
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
        CustomConsole.Instance.WriteText("---------- Un pokemon est OUT, round terminé ----------");
        string aliveText = " est resté vivant, il a gagné le round ";
        string outText = " est ko !, il a perdu le round ";
        CustomConsole.Instance.WriteText("---------- Un pokemon est OUT, round terminé ----------");

        Pokemon winner = m_currentEnemyPokemon.CurrentLifePoints > m_currentCharacterPokemon.CurrentLifePoints ? m_currentEnemyPokemon : m_currentCharacterPokemon;
        Pokemon loser = m_currentEnemyPokemon.CurrentLifePoints > m_currentCharacterPokemon.CurrentLifePoints ? m_currentCharacterPokemon : m_currentEnemyPokemon;
        CustomConsole.Instance.WriteText($"{winner.Name}{aliveText} avec {winner.CurrentLifePoints} points de vie ");
        CustomConsole.Instance.WriteText($"{loser.Name}{outText} avec {loser.CurrentLifePoints} points de vie ");



        if (m_currentCharacterPokemon.CurrentLifePoints > m_currentEnemyPokemon.CurrentLifePoints)
        {
            // Si le gagnant est le character on remove le pokemon enemy
            CustomConsole.Instance.WriteText("Remove Pokemon de L'enemy");
            m_enemyPokemonsList.RemoveAt(m_itCurrentEnemyPokemon);
        }
        else
        {
            // Inversement
            CustomConsole.Instance.WriteText("Remove Pokemon du Character");
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
        CustomConsole.Instance.WriteText("Le combat contre le Pokémon sauvage est terminé.");



        bool hasPokeball = false;
        Item removeItem = null;
        do
        {
            CustomConsole.Instance.WriteText("Voulez-vous capturer le Pokémon sauvage ? (Oui/Non)");
            string sChoice = Console.ReadLine();


            if (!Utils.IsValidTrueFalseInput(sChoice))
            {
                continue;
            }

            if (sChoice.ToLower() == "non")
            {
                CustomConsole.Instance.WriteText("Vous avez choisi de ne pas capturer le Pokémon sauvage.");
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
                CustomConsole.Instance.WriteText("Le Pokémon sauvage a été capturé !");

                // Vous voici avec ces pokemon / ses objets 


                //foreach (Pokemon item in m_c1.GetPokemonList()) { 
                //    CustomConsole.Instance.WriteText(item.Name);
                //}


                foreach (Item item in m_c1.GetObjectList())
                {
                    CustomConsole.Instance.WriteText(item.Name);
                }
            }
            else
            {
                CustomConsole.Instance.WriteText("Vous n'avez pas de pokeball pour capturer ce pokemon");
            }
            break;
            
        } while (true);

        m_c1.Money += 10;
        m_c1.Level.CurrentXp += 100;
        m_c1.Level.Update();
    }
}
