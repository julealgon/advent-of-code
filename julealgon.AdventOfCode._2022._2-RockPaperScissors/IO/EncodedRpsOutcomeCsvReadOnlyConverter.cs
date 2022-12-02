using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;
using static julealgon.AdventOfCode._2022._2_RockPaperScissors.Game.Outcome;

namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.IO;

public sealed class EncodedRpsOutcomeCsvReadOnlyConverter : ITypeConverter
{
    public object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        => text switch
        {
            "X" => new Outcome(ISingleton<Loss>.Value),
            "Y" => new Outcome(ISingleton<Draw>.Value),
            "Z" => new Outcome(ISingleton<Win>.Value),
            _ => throw new InvalidOperationException(),
        };

    public string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        => throw new NotSupportedException();
}
