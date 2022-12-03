using julealgon.AdventOfCode._2022._3_RucksackReorganization;
using julealgon.AdventOfCode.Extensions;
using System.Globalization;
using MoreLinq;

//Part1();
Part2();

void Part1()
{
    var totalPriority = Console.In
        .IterateLines()
        .Select(line => Rucksack.Parse(line, CultureInfo.InvariantCulture))
        .SelectMany(sack => sack.FirstCompartment.Intersect(sack.SecondCompartment).Distinct())
        .Sum(common => common.Priority);
}

void Part2()
{
    const int elfGroupSize = 3;
    var totalBadgePriority = Console.In
        .IterateLines()
        .Select(line => Rucksack.Parse(line, CultureInfo.InvariantCulture))
        .Chunk(elfGroupSize)
        .Select(
            group => group
                .Select(sack => sack.AllItems)
                .Aggregate((previousItems, currentItems) => previousItems.Intersect(currentItems)))
        .SelectMany(item => item)
        .Sum(common => common.Priority);
}