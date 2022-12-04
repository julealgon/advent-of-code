using CsvHelper.Configuration;

namespace CsvHelper.TypeConversion;

public static class MemberMapExtensions
{
    public static MemberMap<TClass, TMember> Parsable<TClass, TMember>(this MemberMap<TClass, TMember> memberMap)
        where TMember : IParsable<TMember>
    {
        ArgumentNullException.ThrowIfNull(memberMap);

        return memberMap.TypeConverter<ParsableReadOnlyTypeConverter<TMember>>();
    }
}
