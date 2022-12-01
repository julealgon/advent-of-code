using julealgon.AdventOfCode.Extensions;
using MoreLinq;

Part1();

void Part1()
{
    var maximumCalorieTotal = Console.In
        .IterateLines()
        .Split(string.Empty)
        .Select(elf => elf.Select(calorie => Convert.ToInt32(calorie)).Sum())
        .Max();

    Console.Write(maximumCalorieTotal);
}
