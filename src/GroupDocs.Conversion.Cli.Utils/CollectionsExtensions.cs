namespace GroupDocs.Conversion.Cli.Utils;

internal static class CollectionsExtensions
{
    public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T>? enumerable)
    {
        return enumerable ?? Enumerable.Empty<T>();
    }
}