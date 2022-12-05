namespace julealgon.AdventOfCode.Extensions;

using MoreLinq;

public static class EnumerableExtensions
{
    public static string AsString(this IEnumerable<char> sequence)
    {
        ArgumentNullException.ThrowIfNull(sequence);

        return new(sequence.ToArray());
    }

    public static IEnumerable<T> ReadParsed<T>(this IEnumerable<string> sequence, IFormatProvider? formatProvider = null)
        where T : IParsable<T>
    {
        ArgumentNullException.ThrowIfNull(sequence);

        return sequence.Select(e => T.Parse(e, formatProvider));
    }

    public static IEnumerable<T> TryReadParsed<T>(this IEnumerable<string?> sequence, IFormatProvider? formatProvider = null)
        where T : IParsable<T>
    {
        ArgumentNullException.ThrowIfNull(sequence);

        return sequence.Choose(e => (T.TryParse(e, formatProvider, out T? result), result))!;
    }
}
