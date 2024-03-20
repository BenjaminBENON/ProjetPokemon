using ProjetC_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Attack
{
    private string m_name;
    private string m_type;

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

    public virtual void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        //Console.WriteLine("Utilisation de l'attaque ->" + Name);
    }

    public Attack(string name)
    {
        Name = name;
    }

}

public class WaterGun : Attack
{
    public WaterGun() : base("Water Gun")
    {
        Type = "Eau";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Water Gun !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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
    public Tackle() : base("Tackle")
    {
        Type = "Normal";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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

public class Ember : Attack
{
    public Ember() : base("Ember")
    {
        Type = "Feu";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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

public class VineWhip : Attack
{
    public VineWhip() : base("Vine Whip")
    {
        Type = "Plante";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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

public class ThunderShock : Attack
{
    public ThunderShock() : base("Thunder Shock")
    {
        Type = "Electrik";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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

public class BubbleBeam : Attack
{
    public BubbleBeam() : base("Bubble Beam")
    {
        Type = "Eau";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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

public class QuickAttack : Attack
{
    public QuickAttack() : base("Quick Attack")
    {
        Type = "Normal";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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

public class FireSpin : Attack
{
    public FireSpin() : base("Fire Spin")
    {
        Type = "Feu";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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

public class RazorLeaf : Attack
{
    public RazorLeaf() : base("Razor Leaf")
    {
        Type = "Plante";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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
    public Thunderbolt() : base("Thunderbolt")
    {
        Type = "Electrik";
    }

    public override void Use(Pokemon pokemon, Pokemon pokemonEnemy)
    {
        Console.WriteLine($"{pokemon.Name} utilise Razor Leaf !");

        Random randomPrec = new Random();
        int accuracyPrec = randomPrec.Next(0, 101);
        Random randomEsq = new Random();
        int accuracyEsq = randomEsq.Next(0, 101);

        if (accuracyPrec <= pokemon.PrecisionPoint)
        {
            if (accuracyEsq <= pokemonEnemy.EsquivePoint)
            {
                int damage = (int)((pokemon.AttackPoint / pokemonEnemy.DefensePoint) * 3);
                pokemonEnemy.CurrentLifePoints -= damage;
                Console.WriteLine($"Razor Leaf inflige {damage} points de dégâts à {pokemonEnemy.Name} !");
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