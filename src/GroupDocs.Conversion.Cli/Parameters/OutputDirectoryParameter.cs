using GroupDocs.Conversion.Cli.Common.Parameters;

namespace GroupDocs.Conversion.Cli.Parameters;

internal class OutputDirectoryParameter: StringParameter
{
    public OutputDirectoryParameter() : base("output-directory", "Specifies the output directory", false, "d")
    {
    }
}