using System.Diagnostics.CodeAnalysis;
using julealgon.AdventOfCode.Extensions;
using MoreLinq;

namespace julealgon.AdventOfCode._2022._3_RucksackReorganization;

internal sealed record Rucksack : IParsable<Rucksack>
{
    public ICollection<Item> FirstCompartment { get; } = new List<Item>();

    public ICollection<Item> SecondCompartment { get; } = new List<Item>();

    public IEnumerable<Item> AllItems => FirstCompartment.Concat(SecondCompartment);

    public static Rucksack Parse(string s, IFormatProvider? provider)
    {
        var items = ParseItems().Batch(s.Length / 2);

        return new()
        {
            FirstCompartment = { items.First() },
            SecondCompartment = { items.Last() },
        };

        IEnumerable<Item> ParseItems()
        {
            foreach (var itemId in s)
            {
                yield return new()
                {
                    Id = itemId,
                    Priority = GetItemPriority(itemId),
                };
            }

            int GetItemPriority(char itemId) => itemId - 
                (char.IsLower(itemId) 
                    ? 'a' - 1 
                    : 'A' - 27);
        }
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Rucksack result)
    {
        throw new NotSupportedException();
    }
}

internal sealed record Item
{
    public required char Id { get; init; }

    public required int Priority { get; init; }
}
