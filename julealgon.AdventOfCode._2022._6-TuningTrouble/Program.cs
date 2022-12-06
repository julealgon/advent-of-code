using julealgon.AdventOfCode.Extensions;
using MoreLinq;

Part1();
//Part2();

void Part1()
{
    var index =
        Console.In
        .IterateLines()
        .First()
        .FindFirstMarker(markerSize: 4);
}

void Part2()
{
    var index =
        Console.In
        .IterateLines()
        .First()
        .FindFirstMarker(markerSize: 14);
}

public static class StringExtensions
{
    public static int FindFirstMarker(this string value, int markerSize)
    {
        ArgumentNullException.ThrowIfNull(value);

        return value
            .Select((c, index) => (Character: c, index))
            .Window(markerSize)
            .First(window => window.AreUniqueBy(w => w.Character))
            .Last().index + 1;
    }
}