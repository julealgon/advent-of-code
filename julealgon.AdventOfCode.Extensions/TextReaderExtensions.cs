namespace julealgon.AdventOfCode.Extensions
{
    public static class TextReaderExtensions
    {
        public static IEnumerable<string> IterateLines(this TextReader reader)
        {
            while (reader.ReadLine() is string line)
            {
                yield return line;
            }
        }
    }
}