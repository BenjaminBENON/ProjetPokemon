
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

public enum AttackType
{
    Normal = 0,
    Water = 1,
    Fire = 2,
    Plant = 3,
    Electric = 4
}

public enum Stat
{
    Attack,
    Defense,
    SpeedAttack,
    Precision,
    Esquive
}



public class Attack
{
    private string m_name;
    private AttackType m_type;
    private int m_power;

    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }

    public AttackType Type
    {
        get { return m_type; }
        set { m_type = value; }
    }

    public int Power
    {
        get { return m_power; }
        set { m_power = value; }
    }

    public virtual void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        CustomConsole.Instance.WriteText($"USE CLASSE ATTACK");
    }

    public Attack(string name, int power)
    {
        //CustomConsole.Instance.WriteText("Setup du name : " + name);
        Name = name;

        Power = power;
    }

}

public class PhysicalAttack : Attack
{
    public int PhysicalPower { get; set; }

    public PhysicalAttack(string name, int power) : base(name, power)
    {
        PhysicalPower = power;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        CustomConsole.Instance.WriteText($"USE CLASSE PHYSICAL ATTACK");
        CustomConsole.Instance.WriteText($"{pokemon.Name} utilise {Name} !");
        int seed = DateTime.Now.Millisecond;
        Random randomPrec = new Random(seed);
        int accuracyPrec = randomPrec.Next(0, 101);
        seed = DateTime.Now.Millisecond;
        Random randomEsq = new Random(seed);
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq >= pokemonEnemy.EsquivePoint)
            {
                int iType = (int)Type;
                float attackRatio = pokemon.AttackPoint / pokemonEnemy.DefensePoint;
                float resistanceModifier = pokemonEnemy.Resistances[iType];
                float totalModifier = attackRatio * PhysicalPower * resistanceModifier;
                float damage = totalModifier;
                pokemonEnemy.CurrentLifePoints -= damage;

                CustomConsole.Instance.WriteText($"{Name} inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                CustomConsole.Instance.WriteText("Le pokemon a esquivé");
            }
        }
        else
        {
            CustomConsole.Instance.WriteText("L'attaque a raté !");
        }
    }
}

public class StatAttack : Attack
{
    public Stat StatToBoost { get; set; }
    public float BoostCoefficient { get; set; }

    public StatAttack(string name, Stat stat, float boostCoefficient) : base(name, 0)
    {
        StatToBoost = stat;
        BoostCoefficient = boostCoefficient;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        CustomConsole.Instance.WriteText($"{pokemon.Name} utilise {Name} !");
        float oldValue = 0;
        switch (StatToBoost)
        {
            case Stat.Attack:
                oldValue = pokemon.AttackPoint;
                pokemon.AttackPoint *= BoostCoefficient;
                break;
            case Stat.Defense:
                oldValue = pokemon.DefensePoint;
                pokemon.DefensePoint *= BoostCoefficient;
                break;
            case Stat.SpeedAttack:
                oldValue = pokemon.SpeedAttackPoint;
                pokemon.SpeedAttackPoint *= BoostCoefficient;
                break;
            case Stat.Precision:
                oldValue = pokemon.PrecisionPoint;
                pokemon.PrecisionPoint = (int)(pokemon.PrecisionPoint * BoostCoefficient);
                break;
            case Stat.Esquive:
                oldValue = pokemon.EsquivePoint;
                pokemon.EsquivePoint = (int)(pokemon.EsquivePoint * BoostCoefficient);
                break;
        }
        CustomConsole.Instance.WriteText($"La statistique {StatToBoost} de {pokemon.Name} augmente de {BoostCoefficient} fois !");
        CustomConsole.Instance.WriteText($"Ancienne valeur : {oldValue}, Nouvelle valeur : {GetStatValue(pokemon, StatToBoost)}");
    }

    private float GetStatValue(Pokemon pokemon, Stat stat)
    {
        switch (stat)
        {
            case Stat.Attack:
                return pokemon.AttackPoint;
            case Stat.Defense:
                return pokemon.DefensePoint;
            case Stat.SpeedAttack:
                return pokemon.SpeedAttackPoint;
            case Stat.Precision:
                return pokemon.PrecisionPoint;
            case Stat.Esquive:
                return pokemon.EsquivePoint;
            default:
                return 0;
        }
    }
}

public class WaterGun : PhysicalAttack
{
    public WaterGun() : base("Water Gun", 10)
    {
        Type = AttackType.Water;
    }
}

public class Tackle : PhysicalAttack
{
    public Tackle() : base("Tackle", 5) // Less Damage But Poison
    {
        Type = AttackType.Normal;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        CustomConsole.Instance.WriteText($"USE CLASSE TACKLE");
        base.Use(pokemon, pokemonEnemy);

        CustomConsole.Instance.WriteText("We add a poison To the enemy");
        Effect effect = new PhysicEffect("Poison", 5, pokemonEnemy, pokemonEnemy.BaseLifePoints / 50.0f);
        pokemonEnemy.AddActiveEffect(effect);
    }
}

public class Ember : PhysicalAttack
{
    public Ember() : base("Ember", 10)
    {
        Type = AttackType.Fire;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        base.Use(pokemon, pokemonEnemy);

        CustomConsole.Instance.WriteText("We add a stun To the enemy");
        Effect effect = new StateEffect("Stun", 5, pokemonEnemy);
        pokemonEnemy.AddActiveEffect(effect);
    }
}

public class VineWhip : PhysicalAttack
{
    public VineWhip() : base("Vine Whip", 10)
    {
        Type = AttackType.Plant;
    }
}

public class ThunderShock : PhysicalAttack
{
    public ThunderShock() : base("Thunder Shock", 10)
    {
        Type = AttackType.Electric;
    }
}

public class BubbleBeam : PhysicalAttack
{
    public BubbleBeam() : base("Bubble Beam", 10)
    {
        Type = AttackType.Water;
    }
}

public class QuickAttack : PhysicalAttack
{
    public QuickAttack() : base("Quick Attack", 10)
    {
        Type = AttackType.Normal;
    }
}

public class FireSpin : PhysicalAttack
{
    public FireSpin() : base("Fire Spin", 10)
    {
        Type = AttackType.Fire;
    }
}

public class RazorLeaf : PhysicalAttack
{
    public RazorLeaf() : base("Razor Leaf", 10)
    {
        Type = AttackType.Plant;
    }
}

public class Thunderbolt : PhysicalAttack
{
    public Thunderbolt() : base("Thunderbolt", 10)
    {
        Type = AttackType.Electric;
    }

}

public class AttackBoost : StatAttack
{
    public AttackBoost() : base("Attack Boost", Stat.Attack, 1.5f)
    {
    }

}

public class DefenseBoost : StatAttack
{
    public DefenseBoost() : base("Defense Boost", Stat.Defense, 1.5f)
    {
    }

}

public class SpeedBoost : StatAttack
{
    public SpeedBoost() : base("Speed Boost", Stat.SpeedAttack, 1.5f)
    {
    }

}

public class AccuracyBoost : StatAttack
{
    public AccuracyBoost() : base("Accuracy Boost", Stat.Precision, 1.5f)
    {
    }

}

public class EsquiveBoost : StatAttack
{
    public EsquiveBoost() : base("Esquive Boost", Stat.Esquive, 1.5f)
    {
    }

}

public class AttackLower : StatAttack
{
    public AttackLower() : base("Attack Lower", Stat.Attack, 0.75f)
    {
    }

}

public class DefenseLower : StatAttack
{
    public DefenseLower() : base("Defense Lower", Stat.Defense, 0.75f)
    {
    }

}

public class SpeedLower : StatAttack
{
    public SpeedLower() : base("Speed Lower", Stat.SpeedAttack, 0.75f)
    {
    }

}

public class AccuracyLower : StatAttack
{
    public AccuracyLower() : base("Accuracy Lower", Stat.Precision, 0.75f)
    {
    }

}

public class EsquiveLower : StatAttack
{
    public EsquiveLower() : base("Esquive Lower", Stat.Esquive, 0.75f)
    {
    }

}



