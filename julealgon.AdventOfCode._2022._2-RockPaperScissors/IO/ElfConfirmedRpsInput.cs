using CsvHelper.Configuration;
using julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;
using static julealgon.AdventOfCode._2022._2_RockPaperScissors.Game.RockPaperScissorGame;

namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.IO;

public sealed class ElfConfirmedRpsInput
{
    public required Move OppositionMove { get; init; }

    public required Outcome TargetOutcome { get; init; }

    public sealed class ClassMap : ClassMap<ElfConfirmedRpsInput>
    {
        public ClassMap()
        {
            Map(i => i.OppositionMove).Index(0).TypeConverter<EncodedRpsMoveCsvReadOnlyConverter>();
            Map(i => i.TargetOutcome).Index(1).TypeConverter<EncodedRpsOutcomeCsvReadOnlyConverter>();
        }
    }
}
