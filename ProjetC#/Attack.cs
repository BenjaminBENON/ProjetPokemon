using ProjetC_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum AttackType
{
    Normal = 0,
    Water = 1,
    Fire = 2,
    Plant = 3,
    Electric = 4
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
    }

    public Attack(string name, int power)
    {
        Name = name;
        Power = power;
    }

}

public class WaterGun : Attack
{
    public WaterGun() : base("Water Gun",10)
    {
        Type = AttackType.Water;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Water Gun !");

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
                float damage = ((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Water Gun inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class Tackle : Attack
{
    public Tackle() : base("Tackle", 10)
    {
        Type = AttackType.Normal;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Tackle!");

        int seed = DateTime.Now.Millisecond;
        Random randomPrec = new Random(seed);
        int accuracyPrec = randomPrec.Next(0, 101);
        seed = DateTime.Now.Millisecond;
        Random randomEsq = new Random(seed);
        int accuracyEsq = randomEsq.Next(0, 101);

        Console.WriteLine("Random precision\n" + accuracyPrec);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq >= pokemonEnemy.EsquivePoint)
            {
                int iType = (int)Type;
                float attackDamage = pokemon.AttackPoint / pokemonEnemy.DefensePoint;
                float modifiedDamage = attackDamage * Power;
                float resistanceModifier = modifiedDamage * pokemonEnemy.Resistances[iType];
                float damage = resistanceModifier;

                Console.WriteLine("Calcul des dégâts :");
                Console.WriteLine($"Point d'attaque du Pokémon : {pokemon.AttackPoint}");
                Console.WriteLine($"Point de défense de l'ennemi : {pokemonEnemy.DefensePoint}");
                Console.WriteLine($"Puissance de l'attaque : {Power}");
                Console.WriteLine($"Résistance de l'ennemi au type de l'attaque : {pokemonEnemy.Resistances[iType]}");
                Console.WriteLine($"Dégâts infligés : {damage}");

                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Tackle inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class Ember : Attack
{
    public Ember() : base("Ember",10)
    {
        Type = AttackType.Fire;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Ember !");

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
                float damage = ((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Ember inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class VineWhip : Attack
{
    public VineWhip() : base("Vine Whip",10)
    {
        Type = AttackType.Plant;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Vine Whip !");

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
                float damage = ((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Vine Whip inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class ThunderShock : Attack
{
    public ThunderShock() : base("Thunder Shock",10)
    {
        Type = AttackType.Electric;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Thunder Shock !");

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
                float damage = ((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Thunder Shock inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class BubbleBeam : Attack
{
    public BubbleBeam() : base("Bubble Beam",10)
    {
        Type = AttackType.Water;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Bubble Beam !");

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
                float damage = ((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Bubble Beam inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class QuickAttack : Attack
{
    public QuickAttack() : base("Quick Attack", 10)
    {
        Type = AttackType.Normal;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Quick Attack !");

        int seed = DateTime.Now.Millisecond;
        Random randomPrec = new Random(seed);
        int accuracyPrec = randomPrec.Next(0, 101);
        seed = DateTime.Now.Millisecond;
        Random randomEsq = new Random(seed);
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyEsq <= pokemonEnemy.EsquivePoint)
        {
            if (accuracyEsq >= pokemonEnemy.EsquivePoint)
            {
                int iType = (int)Type;
                float damage = ((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Quick Attack inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class FireSpin : Attack
{
    public FireSpin() : base("Fire Spin",10)
    {
        Type = AttackType.Fire;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Fire Spin !");

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
                float damage = ( (pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Fire Spin inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class RazorLeaf : Attack
{
    public RazorLeaf() : base("Razor Leaf",10)
    {
        Type = AttackType.Plant;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

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
                float damage = ((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];


                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}

public class Thunderbolt : Attack
{
    public Thunderbolt() : base("Thunderbolt",10)
    {
        Type = AttackType.Electric;
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Thunder bolt !");

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
                float damage = ((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * Power) * pokemonEnemy.Resistances[iType];
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Thunder bolt inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
            }
            else
            {
                Console.WriteLine("Le pokemon a esquivé");
            }

        }
        else
        {
            Console.WriteLine("L'attaque  a raté !");
        }
    }
}


// Stats Attack 









public class DefenseBoost : Attack
{
    private const float BoostCoefficient = 1.5f;

    public DefenseBoost() : base("Defense Boost", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Defense Boost !");
        float oldDefense = pokemon.DefensePoint;
        pokemon.DefensePoint *= BoostCoefficient;
        Console.WriteLine($"La défense de {pokemon.Name} augmente de {BoostCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldDefense}, Nouvelle valeur : {pokemon.DefensePoint}");
    }
}

public class SpeedBoost : Attack
{
    private const float BoostCoefficient = 1.5f;

    public SpeedBoost() : base("Speed Boost", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Speed Boost !");
        float oldSpeed = pokemon.SpeedAttackPoint;
        pokemon.SpeedAttackPoint *= BoostCoefficient;
        Console.WriteLine($"La vitesse d'attaque de {pokemon.Name} augmente de {BoostCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldSpeed}, Nouvelle valeur : {pokemon.SpeedAttackPoint}");
    }
}

public class AccuracyBoost : Attack
{
    private const float BoostCoefficient = 1.5f;

    public AccuracyBoost() : base("Accuracy Boost", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Accuracy Boost !");
        Console.WriteLine("Voici les points " + pokemon.PrecisionPoint + " de " + pokemon.Name);
        float oldPrecision = pokemon.PrecisionPoint;
        pokemon.PrecisionPoint = (int)(pokemon.PrecisionPoint * BoostCoefficient);
        Console.WriteLine($"La précision de {pokemon.Name} augmente de {BoostCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldPrecision}, Nouvelle valeur : {pokemon.PrecisionPoint}");
    }
}

public class EsquiveBoost : Attack
{
    private const float BoostCoefficient = 1.5f;

    public EsquiveBoost() : base("Evasion Boost", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Evasion Boost !");
        float oldEsquive = pokemon.EsquivePoint;
        pokemon.EsquivePoint = (int)(pokemon.EsquivePoint * BoostCoefficient);
        Console.WriteLine($"L'esquive de {pokemon.Name} augmente de {BoostCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldEsquive}, Nouvelle valeur : {pokemon.EsquivePoint}");
    }
}

public class AttackLower : Attack
{
    private const float ReductionCoefficient = 0.75f;

    public AttackLower() : base("Attack Lower", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemonEnemy.Name} subit Attack Lower !");
        float oldAttack = pokemonEnemy.AttackPoint;
        pokemonEnemy.AttackPoint *= ReductionCoefficient;
        Console.WriteLine($"L'attaque de {pokemonEnemy.Name} diminue de {ReductionCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldAttack}, Nouvelle valeur : {pokemonEnemy.AttackPoint}");
    }
}

public class DefenseLower : Attack
{
    private const float ReductionCoefficient = 0.75f;

    public DefenseLower() : base("Defense Lower", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemonEnemy.Name} subit Defense Lower !");
        float oldDefense = pokemonEnemy.DefensePoint;
        pokemonEnemy.DefensePoint *= ReductionCoefficient;
        Console.WriteLine($"La défense de {pokemonEnemy.Name} diminue de {ReductionCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldDefense}, Nouvelle valeur : {pokemonEnemy.DefensePoint}");
    }
}

public class SpeedLower : Attack
{
    private const float ReductionCoefficient = 0.75f;

    public SpeedLower() : base("Speed Lower", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemonEnemy.Name} subit Speed Lower !");
        float oldSpeed = pokemonEnemy.SpeedAttackPoint;
        pokemonEnemy.SpeedAttackPoint *= ReductionCoefficient;
        Console.WriteLine($"La vitesse d'attaque de {pokemonEnemy.Name} diminue de {ReductionCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldSpeed}, Nouvelle valeur : {pokemonEnemy.SpeedAttackPoint}");
    }
}

public class AccuracyLower : Attack
{
    private const float ReductionCoefficient = 0.75f;

    public AccuracyLower() : base("Accuracy Lower", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemonEnemy.Name} subit Accuracy Lower !");
        float oldPrecision = pokemonEnemy.PrecisionPoint;
        pokemonEnemy.PrecisionPoint = (int)(pokemonEnemy.PrecisionPoint * ReductionCoefficient);
        Console.WriteLine($"La précision de {pokemonEnemy.Name} diminue de {ReductionCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldPrecision}, Nouvelle valeur : {pokemonEnemy.PrecisionPoint}");
    }
}

public class EsquiveLower : Attack
{
    private const float ReductionCoefficient = 0.75f;

    public EsquiveLower() : base("Esquive Lower", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemonEnemy.Name} subit Esquive Lower !");
        float oldEsquive = pokemonEnemy.EsquivePoint;
        pokemonEnemy.EsquivePoint = (int)(pokemonEnemy.EsquivePoint * ReductionCoefficient);
        Console.WriteLine($"L'esquive de {pokemonEnemy.Name} diminue de {ReductionCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur : {oldEsquive}, Nouvelle valeur : {pokemonEnemy.EsquivePoint}");
    }
}

public class AllStatsBoost : Attack
{
    private const float BoostCoefficient = 1.1f;

    public AllStatsBoost() : base("All Stats Boost", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise All Stats Boost !");
        float oldAttack = pokemon.AttackPoint;
        float oldDefense = pokemon.DefensePoint;
        float oldSpeed = pokemon.SpeedAttackPoint;
        float oldPrecision = pokemon.PrecisionPoint;
        float oldEsquive = pokemon.EsquivePoint;

        pokemon.AttackPoint *= BoostCoefficient;
        pokemon.DefensePoint *= BoostCoefficient;
        pokemon.SpeedAttackPoint *= BoostCoefficient;
        pokemon.PrecisionPoint = (int)(pokemon.PrecisionPoint * BoostCoefficient);
        pokemon.EsquivePoint = (int)(pokemon.EsquivePoint * BoostCoefficient);

        Console.WriteLine($"Toutes les statistiques de {pokemon.Name} augmentent de {BoostCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur d'attaque : {oldAttack}, Nouvelle valeur : {pokemon.AttackPoint}");
        Console.WriteLine($"Ancienne valeur de défense : {oldDefense}, Nouvelle valeur : {pokemon.DefensePoint}");
        Console.WriteLine($"Ancienne valeur de vitesse d'attaque : {oldSpeed}, Nouvelle valeur : {pokemon.SpeedAttackPoint}");
        Console.WriteLine($"Ancienne valeur de précision : {oldPrecision}, Nouvelle valeur : {pokemon.PrecisionPoint}");
        Console.WriteLine($"Ancienne valeur d'esquive : {oldEsquive}, Nouvelle valeur : {pokemon.EsquivePoint}");
    }
}

public class AllStatsLower : Attack
{
    private const float ReductionCoefficient = 0.9f;

    public AllStatsLower() : base("All Stats Lower", 0)
    {
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemonEnemy.Name} subit All Stats Lower !");
        float oldAttack = pokemonEnemy.AttackPoint;
        float oldDefense = pokemonEnemy.DefensePoint;
        float oldSpeed = pokemonEnemy.SpeedAttackPoint;
        float oldPrecision = pokemon.PrecisionPoint;
        float oldEsquive = pokemon.EsquivePoint;

        pokemonEnemy.AttackPoint *= ReductionCoefficient;
        pokemonEnemy.DefensePoint *= ReductionCoefficient;
        pokemonEnemy.SpeedAttackPoint *= ReductionCoefficient;
        pokemon.PrecisionPoint = (int)(pokemon.PrecisionPoint * ReductionCoefficient);
        pokemon.EsquivePoint = (int)(pokemon.EsquivePoint * ReductionCoefficient);

        Console.WriteLine($"Toutes les statistiques de {pokemonEnemy.Name} diminuent de {ReductionCoefficient} fois !");
        Console.WriteLine($"Ancienne valeur d'attaque : {oldAttack}, Nouvelle valeur : {pokemonEnemy.AttackPoint}");
        Console.WriteLine($"Ancienne valeur de défense : {oldDefense}, Nouvelle valeur : {pokemonEnemy.DefensePoint}");
        Console.WriteLine($"Ancienne valeur de vitesse d'attaque : {oldSpeed}, Nouvelle valeur : {pokemonEnemy.SpeedAttackPoint}");
        Console.WriteLine($"Ancienne valeur de précision : {oldPrecision}, Nouvelle valeur : {pokemon.PrecisionPoint}");
        Console.WriteLine($"Ancienne valeur d'esquive : {oldEsquive}, Nouvelle valeur : {pokemon.EsquivePoint}");
    }
}
