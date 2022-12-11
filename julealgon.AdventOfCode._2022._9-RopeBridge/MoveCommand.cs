using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using SuccincT.Functional;
using static julealgon.AdventOfCode._2022._9_RopeBridge.Direction;

namespace julealgon.AdventOfCode._2022._9_RopeBridge;

internal readonly record struct MoveCommand : IParsable<MoveCommand>
{
    public required Direction Direction { get; init; }

    public required int Amount { get; init; }

    public void ApplyTo(Rope rope)
    {
        rope.DragByHead(this.Direction, this.Amount);
    }

    public static MoveCommand Parse(string s, IFormatProvider? provider)
    {
        var (directionText, (amountText, _)) = s.Split(' ');
        
        return new()
        {
            Amount = int.Parse(amountText),
            Direction = directionText switch
            {
                "U" => Up,
                "D" => Down,
                "L" => Left,
                "R" => Right,
                _ => throw new UnreachableException(),
            }
        };
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MoveCommand result)
    {
        throw new NotSupportedException();
    }
}
