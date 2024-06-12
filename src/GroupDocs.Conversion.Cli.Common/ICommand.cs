namespace GroupDocs.Conversion.Cli.Common;

public interface ICommand
{
    string Name { get; }
    string Description { get; }

    void Execute(string[] args);

    void PrintHelp(bool skipOptions = true);
}