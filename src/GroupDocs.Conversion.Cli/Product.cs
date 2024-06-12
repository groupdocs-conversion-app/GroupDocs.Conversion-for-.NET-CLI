using System.Reflection;

namespace GroupDocs.Conversion.Cli;

public class Product
{
    public static readonly string GroupDocsConversionVersion = GetGroupDocsConversionProductVersion();

    private static string GetGroupDocsConversionProductVersion()
    {
        var conversionAssembly = Assembly.GetAssembly(typeof(GroupDocs.Conversion.License));
        if (conversionAssembly == null) return string.Empty;

        var version = conversionAssembly.GetName().Version;
        return version?.ToString() ?? string.Empty;
    }

    public static readonly string CLIVersion = GetCliProductVersion();

    private static string GetCliProductVersion()
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        // Using AssemblyName.Version to get version information
        var version = executingAssembly.GetName().Version;
        return version?.ToString() ?? string.Empty;
    }
}