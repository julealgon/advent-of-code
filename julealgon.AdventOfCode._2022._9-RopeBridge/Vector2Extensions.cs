using System.Numerics;
using static julealgon.AdventOfCode._2022._9_RopeBridge.Direction;

namespace julealgon.AdventOfCode._2022._9_RopeBridge;

internal static class Vector2Extensions
{
    public static Direction ToDirection(this Vector2 vector) => (vector.X, vector.Y) switch
    {
        (0, > 0) => Up,
        ( > 0, > 0) => UpRight,
        ( > 0, 0) => Right,
        ( > 0, < 0) => DownRight,
        (0, < 0) => Down,
        ( < 0, < 0) => DownLeft,
        ( < 0, 0) => Left,
        ( < 0, > 0) => UpLeft,
        _ => throw new InvalidOperationException(),
    };
}
