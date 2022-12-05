namespace julealgon.AdventOfCode.Extensions;

public static class RangeExtensions
{
    public static IEnumerator<int> GetEnumerator(this Range range)
    {
        var (offset, length) = range.GetOffsetAndLength(int.MaxValue);
        foreach (var i in Enumerable.Range(offset, length + 1))
        {
            yield return i;
        }
    }
}
