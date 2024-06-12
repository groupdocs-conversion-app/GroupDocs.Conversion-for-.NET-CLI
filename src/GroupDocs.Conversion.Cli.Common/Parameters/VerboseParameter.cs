namespace GroupDocs.Conversion.Cli.Common.Parameters;

internal sealed class VerboseParameter: BooleanParameter
{
    public VerboseParameter() : base("verbose", "Specifies whether to output detailed logs", false, "v")
    {
    }
}