using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using julealgon.AdventOfCode.Extensions;

namespace julealgon.AdventOfCode._2022._4_CampCleanup;

internal readonly record struct Range<TNumber> : IParsable<Range<TNumber>>
    where TNumber : INumber<TNumber>
{
    public required TNumber Start { get; init; }

    public required TNumber End { get; init; }

    public Range<TNumber>? Intersection(Range<TNumber> range)
    {
        var maxStart = TNumber.Max(this.Start, range.Start);
        var minEnds = TNumber.Min(this.End, range.End);

        if (maxStart > minEnds)
        {
            return null;
        }

        return new()
        {
            Start = maxStart,
            End = minEnds,
        };
    }

    public static Range<TNumber> Parse(string s, IFormatProvider? provider)
    {
        s.AsSpan().SplitAtFirst('-', out var first, out var second);

        return new()
        {
            Start = TNumber.Parse(first, provider),
            End = TNumber.Parse(second, provider),
        };
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Range<TNumber> result)
    {
        throw new NotSupportedException();
    }
}
