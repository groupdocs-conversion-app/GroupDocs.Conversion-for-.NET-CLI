namespace GroupDocs.Conversion.Cli.Common.Parameters;

public abstract class Parameter
{
    public string Name { get; }
    public string? ShortName { get; }
    public string Description { get; }
    public bool IsRequired { get; }

    protected Parameter(string name, string description, bool isRequired = false, string? shortName = null)
    {
        Name = name;
        Description = description;
        IsRequired = isRequired;
        ShortName = shortName;
    }

    public string GetFullName() => $"--{Name}";

    public string GetShortName() => ShortName == null ? string.Empty : $"-{ShortName}";

    public abstract bool TrySetValue(string input);
}

public abstract class Parameter<T> : Parameter
{
    protected Parameter(string name, string description, bool isRequired = false, string? shortName = null)
        : base(name, description, isRequired, shortName)
    {
    }

    public T? Value { get; protected set; } 
}