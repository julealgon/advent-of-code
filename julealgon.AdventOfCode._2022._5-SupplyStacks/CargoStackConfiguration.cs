using System.Diagnostics.CodeAnalysis;

namespace julealgon.AdventOfCode._2022._5_SupplyStacks;

internal readonly record struct CargoStackConfiguration : IParsable<CargoStackConfiguration>
{
    public required int StackNumber { get; init; }

    public required Stack<Crate> Crates { get; init; }

    public static CargoStackConfiguration Parse(string s, IFormatProvider? provider)
    {
        throw new NotSupportedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out CargoStackConfiguration result)
    {
        if (s?.Trim() is [>= '0' and <= '9' and char stackNumber, .. var crates])
        {
            result = new() 
            { 
                StackNumber = int.Parse(stackNumber.ToString()),
                Crates = new(crates.Select(c => new Crate(c))),
            };

            return true;
        }

        result = default;

        return false;
    }
}
