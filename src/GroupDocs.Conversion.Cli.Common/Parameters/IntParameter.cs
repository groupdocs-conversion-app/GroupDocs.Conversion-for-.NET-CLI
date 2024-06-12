namespace GroupDocs.Conversion.Cli.Common.Parameters;

public abstract class IntParameter : Parameter<int>
{
    protected IntParameter(string name, string description, bool isRequired = false, string? shortName = null)
        : base(name, description, isRequired, shortName)
    {
    }

    public override bool TrySetValue(string input)
    {
        var result = int.TryParse(input, out var value);

        if (result)
        {
            Value = value;
        }

        return result;
    }
}