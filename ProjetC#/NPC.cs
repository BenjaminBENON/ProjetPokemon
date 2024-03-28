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

    public void launchDialog()
    {
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;

        int xPosition = (windowWidth) / 2 - 45;
        int yPosition = (windowHeight / 6) * 4;

        List<string> list = new List<string>();

        list.Add("Hello dresseur, il parait que tu as des pokemons puissants !");
        list.Add("Affrontons-nous pour que je teste ta force");

        for (int i = 0; i < list.Count; i++)
        {
            Console.SetCursorPosition(xPosition, yPosition + i * 2);
            Console.WriteLine(list[i]);
            Console.SetCursorPosition(xPosition, yPosition + i * 2 + 1);
            Console.Read();
        }

    }


    public List<Pokemon> VPokemons { get => m_vPokemons; set => m_vPokemons = value; }
}

