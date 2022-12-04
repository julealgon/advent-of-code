using System.Globalization;
using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public sealed class ParsableReadOnlyTypeConverter<T> : ITypeConverter
    where T : IParsable<T>
{
    public object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData) 
        => text switch
        {
            null => default,
            _ => T.Parse(text, CultureInfo.InvariantCulture),
        };

    public string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
    {
        throw new NotSupportedException();
    }
}
