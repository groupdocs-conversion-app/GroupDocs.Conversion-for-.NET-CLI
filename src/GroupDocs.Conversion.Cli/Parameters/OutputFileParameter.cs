using GroupDocs.Conversion.Cli.Common.Parameters;

namespace GroupDocs.Conversion.Cli.Parameters;

internal class OutputFileParameter: StringParameter
{
    public OutputFileParameter() : base("output-file", "Specifies the output document", false, "f")
    {
    }
}