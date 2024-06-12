using GroupDocs.Conversion.Cli.Common.Parameters;
using GroupDocs.Conversion.Cli.Utils;

namespace GroupDocs.Conversion.Cli.Common;

public abstract class Command : ICommand
{
    private readonly List<Parameter> _parameters = new();

    public string Name { get; }
    public string Description { get; }

    protected Command(string name, string description)
    {
        Name = name;
        Description = description;

        AddParameter(new TimeoutParameter());
        AddParameter(new VerboseParameter());
    }

    public void AddParameter(Parameter parameter)
    {
        _parameters.Add(parameter);
    }

    protected ParseResult ParseParameters(string[] args)
    {
        var result = new ParseResult();
        var argumentsDict = new Dictionary<string, string>();

        for (int i = 1; i < args.Length; i++)
        {
            var arg = args[i];
            Parameter? parameter = null;

            foreach (var p in _parameters)
            {
                if (arg.Equals(p.GetFullName(), StringComparison.OrdinalIgnoreCase) || 
                    (p.ShortName != null && arg.Equals(p.GetShortName(), StringComparison.OrdinalIgnoreCase)))
                {
                    parameter = p;
                    break;
                }
            }

            if (parameter == null)
            {
                continue;
            }

            if (parameter is BooleanParameter)
            {
                // For boolean parameters, presence means true
                argumentsDict[arg] = "true";
                continue;
            }
            
            if (i + 1 < args.Length)
            {
                argumentsDict[arg] = args[i + 1];
                i++;
            }
            else
            {
                result.AddError($"Invalid option or missing value for {arg}");
            }
        }

        foreach (var parameter in _parameters)
        {
            if (argumentsDict.TryGetValue(parameter.GetFullName(), out string? value) || 
                (parameter.ShortName != null && argumentsDict.TryGetValue(parameter.GetShortName(), out value)))
            {
                if (parameter.TrySetValue(value))
                {
                    result.AddParameter(parameter);
                }
                else
                {
                    result.AddError($"Invalid value for parameter: {parameter.Name}");
                }
            }
            else if (parameter.IsRequired)
            {
                result.AddError($"Missing required parameter: {parameter.Name}");
            }
        }

        return result;
    }

    public void Execute(string[] args)
    {
        var parsedResult = ParseParameters(args);
        if (parsedResult.HasErrors)
        {
            foreach (var error in parsedResult.Errors)
            {
                Reporter.Error.WriteLine(error);
            }
            PrintHelp();
            return;
        }

        if (!ValidateParameters(parsedResult))
        {
            PrintHelp();
            return;
        }

        var timeout = GetTimeout(parsedResult);
        SetVerbose(parsedResult);

        try
        {
            var cts = new CancellationTokenSource(timeout);
            var token = cts.Token;

            var commandTask =  Task.Run(() =>
            {
                Execute(parsedResult);
            }, token);
            
            commandTask.Wait(token);
        }
        catch (OperationCanceledException)
        {
            Reporter.Error.WriteLine("The conversion was cancelled due to timeout.");
        }
        catch (AggregateException ae)
        {
            ae.Handle(e =>
            {
                switch (e)
                {
                    case OperationCanceledException:
                        Reporter.Error.WriteLine("The conversion was cancelled due to timeout.");
                        return true;
                    default:
                        return false;
                }
            });
        }
        catch (Exception e)
        {
            Reporter.Error.WriteLine(e.Message);
        }
    }

    protected abstract bool ValidateParameters(ParseResult parsed);
    protected abstract void Execute(ParseResult parsed);

    public void PrintHelp(bool skipOptions = true)
    {
        if (skipOptions)
        {
            Reporter.Output.WriteLine($"{Name}: {Description}");
            return;
        }

        Reporter.Output.WriteLine("Options:");
        const int padCount = 25;
        foreach (var argument in _parameters.OrderBy(p => p.Name))
        {
            var argNames =  !string.IsNullOrEmpty(argument.ShortName)
                ? $"{argument.GetFullName()} | {argument.GetShortName()}".PadRight(padCount)
                : argument.GetFullName().PadRight(padCount);

            Reporter.Output.WriteLine($" {argNames}{argument.Description} {(argument.IsRequired ? "(Required)" : "")}");
        }
    }

    private static TimeSpan GetTimeout(ParseResult parsed)
    {
        var timeout = parsed.Get<TimeoutParameter>()?.Value ??
                          CommandContext.GetCommandTimeout();
        return TimeSpan.FromSeconds(timeout);
    }

    private static void SetVerbose(ParseResult parsed)
    {
        var verbose = parsed.Get<VerboseParameter>()?.Value ?? false;

        if (verbose)
        {
            CommandContext.SetVerbose(true);
        }
    }   
}