using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum PokemonState
{
    Normal,
    Stun,
    Out,
}

public enum PokemonType
{
    Normal = 0,
    Water = 1,
    Fire = 2,
    Plant = 3,
    Electric = 4
}



public class Pokemon
{
    private string m_name;
    private PokemonType m_type;

    private PokemonState m_pokemonState;

    private float m_baseLifePoints;
    private float m_currentLifePoints;

    private float m_speedAttackPoints;
    private float m_attackPoints;
    private float m_defensePoints;

    // Max value
    private const float m_maxLifePoints = 100;

    // Not use 
    private const float m_maxAttackPoints = 200;
    private const float m_maxDefensePoints = 200;
    //

    private const float m_maxPrecisionPoints = 100;
    private const float m_maxEsquivePoints = 100;
    // Max Value *



    private float[] m_res = new float[5];

    private float m_precisionPoints;
    private float m_esquivePoints;

    private int m_level;



    // Attack list (4)
    List<Attack> m_vAttacks;

    // Getter / Setter -> Attribute
    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }

    public PokemonType Type
    {
        get { return m_type; }
        set { m_type = value; }
    }

    public PokemonState PokemonState
    {
        get { return m_pokemonState; }
        set { m_pokemonState = value; }
    }

    public float BaseLifePoints
    {
        get { return m_baseLifePoints; }
        set { m_baseLifePoints = value; }
    }

    public float[] Resistances
    {
        get { return m_res; }
        set { m_res = value; }
    }

    public float CurrentLifePoints
    {
        get { return m_currentLifePoints; }
        set
        {
            m_currentLifePoints = value;
            if (m_currentLifePoints <= 0)
            {
                m_pokemonState = PokemonState.Out;
                return;
            }
            if (m_currentLifePoints + value >= m_maxLifePoints)
            {
                m_currentLifePoints = m_maxLifePoints;
                return;
            }
            
        }
    }

    public float SpeedAttackPoint
    {
        get { return m_speedAttackPoints; }
        set { m_speedAttackPoints = value; }
    }

    public float AttackPoint
    {
        get { return m_attackPoints; }
        set { m_attackPoints = value; }
    }

    public float DefensePoint
    {
        get { return m_defensePoints; }
        set { m_defensePoints = value; }
    }

    public float PrecisionPoint
    {
        get { return m_precisionPoints; }
        set {
            if (m_precisionPoints + value >= m_maxPrecisionPoints)
            {
                m_precisionPoints = m_maxPrecisionPoints;
                return;
            }
            m_precisionPoints = value;
        }
    }

    public float EsquivePoint
    {
        get { return m_esquivePoints; }
        set {
            if (m_esquivePoints + value >= m_maxEsquivePoints)
            {
                m_esquivePoints = m_maxEsquivePoints;
                return;
            }
            m_esquivePoints = value;
        }
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

    public void UseAttack(int iAttack, Pokemon pokemonEnemy)
    {
        m_vAttacks[iAttack - 1].Use(this, pokemonEnemy);
    }

    // Constructor
    public Pokemon(string name, PokemonType type, float baseLifePoints, float speedAttackPoints, float attackPoints, float defensePoints, float precisionPoints, float esquivePoints, float[] res)
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
        Resistances = res;
    }
}
