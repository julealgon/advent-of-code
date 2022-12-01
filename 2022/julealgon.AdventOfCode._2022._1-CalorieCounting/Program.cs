using julealgon.AdventOfCode.Extensions;
using MoreLinq;

//Part1();
Part2();

void Part1()
{
    var maximumCalorieTotal = Console.In
        .IterateLines()
        .Split(string.Empty)
        .Select(elf => elf.Select(calorie => Convert.ToInt32(calorie)).Sum())
        .Max();

    Console.Write(maximumCalorieTotal);
}

void Part2()
{
    var totalCaloriesTop3Elves = Console.In
        .IterateLines()
        .Split(string.Empty)
        .Select(elf => elf.Select(calorie => Convert.ToInt32(calorie)).Sum())
        .OrderDescending()
        .Take(3)
        .Sum();

    Console.Write(totalCaloriesTop3Elves);
}