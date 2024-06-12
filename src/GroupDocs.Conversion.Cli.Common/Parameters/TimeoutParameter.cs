namespace GroupDocs.Conversion.Cli.Common.Parameters;

internal sealed class TimeoutParameter: IntParameter
{
    public TimeoutParameter() : base("timeout", "Specifies the command timeout in seconds")
    {
    }
}