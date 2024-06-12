using GroupDocs.Conversion.Cli.Common.Parameters;

namespace GroupDocs.Conversion.Cli.Parameters;

internal class SourceParameter: StringParameter
{
    public SourceParameter() : base("source", "Specifies the source document that will be converted", true, "s")
    {
    }

}