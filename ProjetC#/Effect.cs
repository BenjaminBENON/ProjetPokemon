using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

public enum EffectType
{
    Stun,
    Poisoned,
}

public class Effect
{
    protected string m_name;
    protected int m_duration;

    protected EffectType m_type;

    protected Pokemon m_pokemon;

    public Effect(string name, int duration, Pokemon pokemon)
    {
        m_name = name;
        m_duration = duration;
        m_pokemon = pokemon;
    }

    public virtual void Inflict()
    {
    }
}

public class PhysicEffect : Effect
{
    private float m_damage;


    public PhysicEffect(string name, int duration, Pokemon pokemon, float damage) : base(name, duration, pokemon)
    {
        m_type = EffectType.Poisoned;
        m_damage = damage;
    }

    public override void Inflict()
    {
        if (m_duration > 0)
        {
            m_duration--;
            float oldLifePoints = m_pokemon.CurrentLifePoints;
            m_pokemon.CurrentLifePoints -= m_damage;
            CustomConsole.Instance.WriteText("Inflict a poison : passant de " + oldLifePoints + " points de vie, à " + m_pokemon.CurrentLifePoints + " points de vie ");
        }
        // turn Duration finish
        else
        {
            CustomConsole.Instance.WriteText("Poison is Finish");
        }
    }
}

public class StateEffect : Effect
{


    public StateEffect(string name, int duration, Pokemon pokemon) : base(name, duration, pokemon)
    {
        m_type = EffectType.Stun;
    }

    public override void Inflict()
    {

        if (m_duration > 0) {
            m_duration--;
            CustomConsole.Instance.WriteText("Inflict a stun, you are stun for still " + m_duration + " turn ");
            m_pokemon.PokemonState = PokemonState.CannotAttack;
        }
        // turn Duration finish
        else
        {
            CustomConsole.Instance.WriteText("Stun is Finish");
            m_pokemon.PokemonState = PokemonState.Normal;
        }
    }
}
