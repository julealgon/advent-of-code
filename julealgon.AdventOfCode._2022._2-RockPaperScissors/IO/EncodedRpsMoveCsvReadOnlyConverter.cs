using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;
using static julealgon.AdventOfCode._2022._2_RockPaperScissors.Game.Move;

namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.IO;

public sealed class EncodedRpsMoveCsvReadOnlyConverter : ITypeConverter
{
    public object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        => text switch
        {
            "A" or "X" => new Move(new Rock()),
            "B" or "Y" => new Move(new Paper()),
            "C" or "Z" => new Move(new Scissors()),
            _ => throw new InvalidOperationException(),
        };

    public string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        => throw new NotSupportedException();
}
