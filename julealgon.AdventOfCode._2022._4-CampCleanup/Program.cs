
using CsvHelper;
using CsvHelper.Configuration;
using julealgon.AdventOfCode._2022._4_CampCleanup;
using static System.Globalization.CultureInfo;

Part1();

void Part1()
{
    var configuration = new CsvConfiguration(InvariantCulture) { HasHeaderRecord = false };
    using var reader = new CsvReader(Console.In, configuration);
    reader.Context.RegisterClassMap<ElfPairInput.ClassMap>();
    var fullOverlaps = reader
        .GetRecords<ElfPairInput>()
        .Count(i =>
        {
            var intersectionRange = i.FirstElfRange.Intersection(i.SecondElfRange);

            return intersectionRange is Range<int> range && 
                (range == i.FirstElfRange ||
                range == i.SecondElfRange);
        });
}
