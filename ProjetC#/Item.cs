
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum ItemType
{
    Pokeball,
    Heal,
    PokemonState,
    Stat,
}



public class Item
{
    private string m_name;
    private ItemType m_type;

    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }

    public ItemType Type
    {
        get { return m_type; }
        set { m_type = value; }
    }

    public virtual void Use(Pokemon pokemon)
    {

    }

    public Item(string name)
    {
        Name = name;
    }

    

}

public class Potion : Item
{
    

    private int m_iRestorePv;

    public int RestorePv
    {
        get { return m_iRestorePv; }
        set { m_iRestorePv = value; }
    }

    public Potion(string name, int iRestorePv) : base(name)
    {
        Type = ItemType.Heal;
        RestorePv = iRestorePv;
    }

    public override void Use(Pokemon pokemon)
    {
        // Restore Pokemon Pv
        pokemon.CurrentLifePoints += RestorePv;
        Console.WriteLine($"{pokemon.Name} a été soigné avec une {Name}.");
    }
}

public class Berry : Item
{
    public Berry(string name) : base(name) { }

    public override void Use(Pokemon pokemon)
    {
        // Remove Bad Pokemon effect
        Type = ItemType.PokemonState;
        pokemon.PokemonState = PokemonState.Normal;
    }
}

public class Pokeball : Item
{
    public Pokeball(string name) : base(name) 
    {
        Type = ItemType.Pokeball;
    }

    public override void Use(Pokemon pokemon)
    {
        // Capture a pokemon
        Console.WriteLine($"Lancer de la {Name}...");
    }
}

public class StatItem : Item
{
    public StatItem(string name) : base(name) { }
    public override void Use(Pokemon pokemon)
    {
        pokemon.DefensePoint = (int)(pokemon.DefensePoint * 1.1f);
        pokemon.SpeedAttackPoint = (int)(pokemon.SpeedAttackPoint * 1.1f);
        pokemon.AttackPoint = (int)(pokemon.AttackPoint * 1.1f);
        pokemon.PrecisionPoint = (int)(pokemon.PrecisionPoint * 1.1f);
        pokemon.EsquivePoint = (int)(pokemon.EsquivePoint * 1.1f);
    }
}