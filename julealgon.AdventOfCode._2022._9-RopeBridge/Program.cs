// See https://aka.ms/new-console-template for more information

using julealgon.AdventOfCode._2022._9_RopeBridge;
using julealgon.AdventOfCode.Extensions;
using System.Numerics;
using System.Reactive.Linq;

//Part1();
Part2();

void Part1()
{
    Rope rope = new(numberOfKnots: 2);
    int distinctTailPositions = 0;
    rope.Tail.Position.Distinct().Subscribe(c => distinctTailPositions++);

    foreach (var command in Console.In.IterateLines().ReadParsed<MoveCommand>())
    {
        command.ApplyTo(rope);
    }

    _ = distinctTailPositions;
}

void Part2()
{
    Rope rope = new(numberOfKnots: 10);
    int distinctTailPositions = 0;
    rope.Tail.Position.Distinct().Subscribe(c => distinctTailPositions++);

    foreach (var command in Console.In.IterateLines().ReadParsed<MoveCommand>())
    {
        command.ApplyTo(rope);
    }

    _ = distinctTailPositions;
}