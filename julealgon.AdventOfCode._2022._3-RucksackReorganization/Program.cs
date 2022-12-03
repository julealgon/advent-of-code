using julealgon.AdventOfCode._2022._3_RucksackReorganization;
using julealgon.AdventOfCode.Extensions;
using System.Globalization;
using MoreLinq;

Part1();

void Part1()
{
    var totalPriority = Console.In
        .IterateLines()
        .Select(line => Rucksack.Parse(line, CultureInfo.InvariantCulture))
        .SelectMany(sack => sack.FirstCompartment.Intersect(sack.SecondCompartment).Distinct())
        .Sum(common => common.Priority);
}