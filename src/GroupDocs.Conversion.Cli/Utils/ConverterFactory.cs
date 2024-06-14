using GroupDocs.Conversion.Cli.Logging;

namespace GroupDocs.Conversion.Cli.Utils;

internal static class ConverterFactory
{
    public static Converter GetConfiguredConverter(string source)
    {
        var settings = new ConverterSettings();
        if (CommandContext.IsVerbose())
        {
            settings.Logger = new CliLogger();
        }

        return new Converter(source, () => settings);
    }
}