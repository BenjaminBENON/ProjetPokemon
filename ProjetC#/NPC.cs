using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public  class NPC
{
    private List<Pokemon> m_vPokemons = new List<Pokemon>();

    public NPC(Game oGame)
    {
        m_vPokemons.Add(oGame.Database.GetPokemon("Salamèche"));
        m_vPokemons.Add(oGame.Database.GetPokemon("Pikachu"));
        m_vPokemons.Add(oGame.Database.GetPokemon("Carapuce"));
        m_vPokemons.Add(oGame.Database.GetPokemon("Bulbizarre"));
    }

    public void launchDialog(Game oGame)
    {
        int relaunch = 0;
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        int xPosition = (windowWidth) / 2 - 45;
        int yPosition = (windowHeight / 6) * 4;

        List<string> list = new List<string>();

        list.Add("Hello dresseur, c'est bien toi " + oGame.CurrentCharacter.Name + " ?");
        list.Add("Il parait que tu as des pokemons puissants !");
        list.Add("Affrontons-nous pour que je teste ta force");
        list.Add("Tu veux bien ?");

        if (relaunch == 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.SetCursorPosition(xPosition, yPosition + i * 2);
                Console.WriteLine(list[i]);
                Console.SetCursorPosition(xPosition, yPosition + i * 2 + 1);
                Console.Read();
            }

            string answer = Console.ReadLine();
            if (answer.ToLower() == "oui") launchFight(oGame);
            if (answer.ToLower() == "non") oGame.UpdateCurrentGameState(GameMenuStates.OnMap);
            else
            {
                relaunch++;
                launchDialog(oGame);
            }
        }
        
        if (relaunch>0)
        {
            Console.SetCursorPosition(xPosition, yPosition + (list.Count+relaunch-1) * 2 );
            Console.WriteLine("Je n'ai pas compris ta réponse ... Oui ou Non ?");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "oui") launchFight(oGame);
            if (answer.ToLower() == "non") oGame.UpdateCurrentGameState(GameMenuStates.OnMap);
            else 
            {
                relaunch++;
                launchDialog(oGame);
            }
        }
    }

    private void launchFight(Game oGame)
    {
        Fight fight = new Fight(oGame.CurrentCharacter, m_vPokemons, FightType.Trainer);
    }


    public List<Pokemon> VPokemons { get => m_vPokemons; set => m_vPokemons = value; }
}

