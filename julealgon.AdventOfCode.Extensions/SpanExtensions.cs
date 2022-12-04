namespace julealgon.AdventOfCode.Extensions;

public static class SpanExtensions
{
    public static void SplitAtFirst(
        this ReadOnlySpan<char> span, 
        char value, 
        out ReadOnlySpan<char> first, 
        out ReadOnlySpan<char> second)
    {
        var valueIndex = span.IndexOf(value);
        first = span[..valueIndex];
        second = span[(valueIndex + 1)..];
    }
}
