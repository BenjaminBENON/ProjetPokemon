public static class Utils
{
    public static bool IsValidAttackInput(string input)
    {
        if (int.TryParse(input, out int attackIndex))
        {
            return attackIndex >= 1 && attackIndex <= 4;
        }
        else
        {
            return false;
        }
    }

    public static bool IsValidItemInput(string input, int objCount)
    {
        if (int.TryParse(input, out int attackIndex))
        {
            return attackIndex >= 1 && attackIndex <= objCount + 1;
        }
        else
        {
            return false;
        }
    }

    public static bool IsValidSwitchPokemonInput(string input, int objCount)
    {
        if (int.TryParse(input, out int pokemonIndex))
        {
            return pokemonIndex >= 1 && pokemonIndex <= objCount;
        }
        else
        {
            return false;
        }
    }
}