using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum PokemonState {
    Normal,
    Stun,
    Out,
}

namespace ProjetC_
{

    public class Pokemon
    {
        private string m_name;
        private string m_type;

        private PokemonState m_pokemonState;

        private int m_baseLifePoints;
        private int m_currentLifePoints;

        private int m_speedAttackPoint;
        private int m_attackPoint;
        private int m_defensePoint;

        private int m_precisionPoint;
        private int m_esquivePoint;

        private int m_level;



        // Attack list (4)
        List<Attack> m_vAttacks;

        // Getter / Setter -> Attribute
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public string Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        public PokemonState PokemonState
        {
            get { return m_pokemonState; }
            set { m_pokemonState = value; }
        }

        public int BaseLifePoints
        {
            get { return m_baseLifePoints; }
            set { m_baseLifePoints = value; }
        }

        public int CurrentLifePoints
        {
            get { return m_currentLifePoints; }
            set 
            {
                m_currentLifePoints = value; 
                if (m_currentLifePoints <=  0)
                {
                    m_pokemonState = PokemonState.Out;
                }
            }
        }

        public int SpeedAttackPoint
        {
            get { return m_speedAttackPoint; }
            set { m_speedAttackPoint = value; }
        }

        public int AttackPoint
        {
            get { return m_attackPoint; }
            set { m_attackPoint = value; }
        }

        public int DefensePoint
        {
            get { return m_defensePoint; }
            set { m_defensePoint = value; }
        }

        public int PrecisionPoint
        {
            get { return m_precisionPoint; }
            set { m_precisionPoint = value; }
        }

        public int EsquivePoint
        {
            get { return m_esquivePoint; }
            set { m_esquivePoint = value; }
        }

        public int Level
        {
            get { return m_level; }
            set { m_level = value; }
        }


        public List<Attack> GetAttackList()
        {
            return m_vAttacks;
        }

        public void AddAttack(Attack attack)
        {
            m_vAttacks.Add(attack);
        }

        // Constructor
        public Pokemon(string name, string type, int baseLifePoints, int speedAttackPoints, int attackPoints, int defensePoints, int precisionPoints, int esquivePoints)
        {
            Name = name;
            Type = type;
            m_pokemonState = PokemonState.Normal;
            BaseLifePoints = baseLifePoints;
            CurrentLifePoints = baseLifePoints;
            SpeedAttackPoint = speedAttackPoints;
            AttackPoint = attackPoints;
            DefensePoint = defensePoints;
            PrecisionPoint = precisionPoints;
            EsquivePoint = esquivePoints;
            Level = 0;

            // Lists
            m_vAttacks = new List<Attack>();
        }

    }
}
