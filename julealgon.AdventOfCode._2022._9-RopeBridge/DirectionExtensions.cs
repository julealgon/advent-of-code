using System.Diagnostics;
using System.Numerics;
using static julealgon.AdventOfCode._2022._9_RopeBridge.Direction;
using static System.Numerics.Vector2;

namespace julealgon.AdventOfCode._2022._9_RopeBridge;

internal static class DirectionExtensions
{
    public static Vector2 ToDelta(this Direction direction) => direction switch
    {
        Up => UnitY,
        UpRight => UnitY + UnitX,
        Right => UnitX,
        DownRight => -UnitY + UnitX,
        Down => -UnitY,
        DownLeft => -UnitY - UnitX,
        Left => -UnitX,
        UpLeft => UnitY - UnitX,
        _ => throw new UnreachableException(),
    };
}
