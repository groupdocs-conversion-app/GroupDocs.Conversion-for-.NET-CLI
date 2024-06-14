namespace GroupDocs.Conversion.Cli.Tests.Utils;

public class ConsoleOutput : IDisposable
{
    private readonly StringWriter _outputStringWriter;
    private readonly TextWriter _originalOutput;

    private readonly StringWriter _errorStringWriter;
    private readonly TextWriter _originalErrorOutput;

    public ConsoleOutput()
    {
        _outputStringWriter = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_outputStringWriter);

        _errorStringWriter = new StringWriter();
        _originalErrorOutput = Console.Error;
        Console.SetError(_errorStringWriter);
    }

    public string GetOuput()
    {
        return _outputStringWriter.ToString();
    }

    public string GetError()
    {
        return _errorStringWriter.ToString();
    }

    public void Dispose()
    {
        Console.SetOut(_originalOutput);
        Console.SetError(_originalErrorOutput);

        _outputStringWriter.Dispose();
        _errorStringWriter.Dispose();
    }
}