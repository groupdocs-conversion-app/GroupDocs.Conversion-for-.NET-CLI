namespace GroupDocs.Conversion.Cli.Common.Parameters;

public abstract class BooleanParameter : Parameter<bool>
{
    protected BooleanParameter(string name, string description, bool isRequired = false, string? shortName = null)
        : base(name, description, isRequired, shortName)
    {
    }

    public override bool TrySetValue(string input)
    {
        Value = true;
        return true;
    }
}