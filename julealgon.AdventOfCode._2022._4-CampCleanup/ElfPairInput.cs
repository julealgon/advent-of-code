using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace julealgon.AdventOfCode._2022._4_CampCleanup;

internal sealed record ElfPairInput
{
    public required Range<int> FirstElfRange { get; set; }

    public required Range<int> SecondElfRange { get; set; }

    internal sealed class ClassMap : ClassMap<ElfPairInput>
    {
        public ClassMap()
        {
            Map(i => i.FirstElfRange).Index(0).Parsable();
            Map(i => i.SecondElfRange).Index(1).Parsable();
        }
    }
}
