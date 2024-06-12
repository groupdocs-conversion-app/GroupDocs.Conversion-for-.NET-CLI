using GroupDocs.Conversion.Cli.Common.Parameters;
using GroupDocs.Conversion.FileTypes;

namespace GroupDocs.Conversion.Cli.Parameters;

internal class TargetFormatParameter: Parameter<FileType>
{
    public TargetFormatParameter() : base("target-format", "Specifies the desired format after conversion", false, "t")
    {
    }

    public override bool TrySetValue(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        var outputFormat = FileType.FromExtension(input);

        if (outputFormat == FileType.Unknown)
        {
            return false;
        }

        Value = outputFormat;
        return true;
    }
}