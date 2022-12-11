// See https://aka.ms/new-console-template for more information
using julealgon.AdventOfCode._2022._10_CathodeRayTube;
using julealgon.AdventOfCode.Extensions;
using System.Reactive.Linq;

Cpu cpu = new(Console.Out);
//var sampler = Observable.Generate()
var sampler = cpu.Cicle.Where(cicle => cicle is 20 or 60 or 100 or 140 or 180 or 220);
var signalStrengths = 0;
cpu.SignalStrength.Sample(sampler).Subscribe(strength => signalStrengths+= strength);
foreach (var command in Console.In.IterateLines())
{
    cpu.ProcessCommand(command);
}

_ = signalStrengths;
