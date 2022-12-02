using CsvHelper;
using CsvHelper.Configuration;
using julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;
using julealgon.AdventOfCode._2022._2_RockPaperScissors.IO;
using System.Globalization;

//Part1();
Part2();

void Part1()
{
    CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture)
    {
        Delimiter = " ",
        HasHeaderRecord = false,
        WhiteSpaceChars = Array.Empty<char>(),
    };

    RockPaperScissorGame game = new();
    using CsvReader reader = new(Console.In, csvConfiguration);
    reader.Context.RegisterClassMap<InferredRpsInput.ClassMap>();
    var totalScore = reader
        .GetRecords<InferredRpsInput>()
        .Select(i => game.Against(i.OppositionMove).Play(i.PlayerMove))
        .Sum(r => r.TotalScore);
}

void Part2()
{
    CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture)
    {
        Delimiter = " ",
        HasHeaderRecord = false,
        WhiteSpaceChars = Array.Empty<char>(),
    };

    RockPaperScissorGame game = new();
    using CsvReader reader = new(Console.In, csvConfiguration);
    reader.Context.RegisterClassMap<ElfConfirmedRpsInput.ClassMap>();
    var totalScore = reader
        .GetRecords<ElfConfirmedRpsInput>()
        .Select(i => game.Against(i.OppositionMove).PlayFor(i.TargetOutcome))
        .Sum(r => r.TotalScore);
}
