using CsvHelper.Configuration;
using julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.IO;

public sealed class InferredRpsInput
{
    public required Move OppositionMove { get; init; }

    public required Move PlayerMove { get; init; }

    public sealed class ClassMap : ClassMap<InferredRpsInput>
    {
        public ClassMap()
        {
            Map(i => i.OppositionMove).Index(0).TypeConverter<EncodedRpsMoveCsvReadOnlyConverter>();
            Map(i => i.PlayerMove).Index(1).TypeConverter<EncodedRpsMoveCsvReadOnlyConverter>();
        }
    }
}
