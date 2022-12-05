using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace julealgon.AdventOfCode._2022._5_SupplyStacks;

internal readonly partial record struct CraneCommand : IParsable<CraneCommand>
{
    public required int NumberOfCrates { get; init; }

    public required int SourceStack { get; init; }

    public required int TargetStack { get; init; }

    public void ApplyTo(CargoShip cargoShip)
    {
        cargoShip.OperateCrane(NumberOfCrates, SourceStack, TargetStack);
    }

    public void ApplyTo2(CargoShip cargoShip)
    {
        cargoShip.OperateCrane9001(NumberOfCrates, SourceStack, TargetStack);
    }

    public static CraneCommand Parse(string s, IFormatProvider? provider)
    {
        var match = CommandFormat().Match(input: s);

        return new()
        {
            NumberOfCrates = int.Parse(match.Groups[nameof(NumberOfCrates)].Value),
            SourceStack = int.Parse(match.Groups[nameof(SourceStack)].Value) - 1,
            TargetStack = int.Parse(match.Groups[nameof(TargetStack)].Value) - 1,
        };
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out CraneCommand result)
    {
        throw new NotSupportedException();
    }

    [GeneratedRegex("move (?<NumberOfCrates>\\d+) from (?<SourceStack>\\d+) to (?<TargetStack>\\d+)", RegexOptions.ExplicitCapture)]
    private static partial Regex CommandFormat();
}
