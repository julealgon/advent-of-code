using julealgon.AdventOfCode._2022._5_SupplyStacks;
using julealgon.AdventOfCode.Extensions;
using MoreLinq;
using SuccincT.Functional;

//Part1();
Part2();

void Part1()
{
    var (stackInputs, (commandInputs, _)) = Console.In.IterateLines().Split(string.Empty);

    var cargoConfiguration = stackInputs
        .Reverse()
        .Transpose()
        .Select(l => l.AsString())
        .TryReadParsed<CargoStackConfiguration>();

    CargoShip ship = new(cargoConfiguration);

    foreach (var command in commandInputs.ReadParsed<CraneCommand>())
    {
        command.ApplyTo(ship);
    }

    var topStacks = new string(ship.CrateStacks.Select(s => s.Peek().Id)
        .ToArray());
}

void Part2()
{
    var (stackInputs, (commandInputs, _)) = Console.In.IterateLines().Split(string.Empty);

    var cargoConfiguration = stackInputs
        .Reverse()
        .Transpose()
        .Select(l => l.AsString())
        .TryReadParsed<CargoStackConfiguration>();

    CargoShip ship = new(cargoConfiguration);

    foreach (var command in commandInputs.ReadParsed<CraneCommand>())
    {
        command.ApplyTo2(ship);
    }

    var topStacks = new string(ship.CrateStacks.Select(s => s.Peek().Id)
        .ToArray());
}
