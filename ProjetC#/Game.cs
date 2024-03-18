using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum State
{
    Menu,
    OnMap,
    OnFight
}

namespace ProjetC_
{
    public class Game
    {
        private State currentState;

        public Game()
        {
            currentState = State.Menu;
        }

        public void Start()
        {
            switch (currentState)
            {
                case State.Menu:
                    DisplayMenu();
                    break;
                case State.OnMap:
                    StartMap();
                    break;
                case State.OnFight:
                    StartFight();
                    break;
                default:
                    Console.WriteLine("État du jeu non géré.");
                    break;
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Jouer");
            Console.WriteLine("2. Quitter");

            Console.Write("Choix : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    currentState = State.OnMap;
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }

        private void StartMap()
        {
            Console.WriteLine("Vous êtes sur la carte.");
            Console.WriteLine("1. Combattre");
            Console.WriteLine("2. Retourner au menu");

            Console.Write("Choix : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    currentState = State.OnFight;
                    break;
                case "2":
                    currentState = State.Menu;
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }

        private void StartFight()
        {
            Console.WriteLine("Combat en cours...");
            // LE fiiiiiiight;
            Console.WriteLine("Combat terminé.");

            currentState = State.OnMap;
        }
    }
}
