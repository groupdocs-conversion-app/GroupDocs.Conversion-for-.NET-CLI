using GroupDocs.Conversion.Cli.Common.Parameters;

namespace GroupDocs.Conversion.Cli.Common;

public class ParseResult
{
    private readonly Dictionary<Type, object> _parameters = new Dictionary<Type, object>();
    public List<string> Errors { get; } = new List<string>();

    public T? Get<T>() where T : Parameter
    {
        if (_parameters.TryGetValue(typeof(T), out var value))
        {
            return value as T;
        }

        return null;
    }

    public void AddParameter(Parameter parameter)
    {
        _parameters[parameter.GetType()] = parameter;
    }

    public void AddError(string error)
    {
        Errors.Add(error);
    }

    public bool HasErrors => Errors.Count > 0;
}