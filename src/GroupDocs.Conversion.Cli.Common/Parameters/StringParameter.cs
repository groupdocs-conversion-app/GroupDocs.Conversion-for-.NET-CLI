namespace GroupDocs.Conversion.Cli.Common.Parameters;

public abstract class StringParameter : Parameter<string>
{
    protected StringParameter(string name, string description, bool isRequired = false, string? shortName = null)
        : base(name, description, isRequired, shortName)
    {
    }

    public override bool TrySetValue(string input)
    {
        Value = input;
        return true;
    }
}