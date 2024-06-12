using GroupDocs.Conversion.Cli.Utils;

namespace GroupDocs.Conversion.Cli.Common;

public class CommandRegistry
{
    private readonly string _mainCommand;
    private readonly string _cliVersion;
    private readonly string _productVersion;
    private readonly Dictionary<string, ICommand> _commands = new();

    public CommandRegistry(string mainCommand, string cliVersion, string productVersion)
    {
        _mainCommand = mainCommand;
        _cliVersion = cliVersion;
        _productVersion = productVersion;
    }

    public void RegisterCommand(ICommand command)
    {
        _commands[command.Name.ToLower()] = command;
    }

    public void ExecuteCommand(string[] args)
    {
        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

        if (args[0] == "-h" || args[0] == "--help")
        {
            ShowHelp();
            return;
        }

        if (args[0] == "--version")
        {
            ShowVersion();
            return;
        }

        var commandName = args[0].ToLower();

        if (_commands.TryGetValue(commandName, out var command))
        {
            if (args.Length > 1 && (args[1] == "-h" || args[1] == "--help"))
            {
                ShowCommandHelp(command);
            }
            else
            {
                command.Execute(args);
            }
        }
        else
        {
            Reporter.Error.WriteLine($"Unknown command: {args[0]}");
            ShowHelp();
        }
    }

    private void ShowCommandHelp(ICommand command)
    {
        Reporter.Output.Write("Usage: ");

        Reporter.Output.WriteLine($"{_mainCommand} {command.Name} [options]");
        Reporter.Output.WriteLine();
        command.PrintHelp(false);
    }

    private void ShowHelp()
    {
        Reporter.Output.Write("Usage: ");

        Reporter.Output.WriteLine($"{_mainCommand} [command] [options]");
        Reporter.Output.WriteLine();
        Reporter.Output.WriteLine($"Commands: ");
        foreach (var command in _commands.Values)
        {
            command.PrintHelp();
            Reporter.Output.WriteLine();
        }
        Reporter.Output.WriteLine();
        Reporter.Output.WriteLine("Options: ");
        Reporter.Output.WriteLine(" -h|--help         Display help.");
        Reporter.Output.WriteLine(" --version         Display CLI version in use.");
    }

    private void ShowVersion()
    {
        Reporter.Output.WriteLine($"GroupDocs.Conversion CLI version: {_cliVersion}");
        Reporter.Output.WriteLine($"GroupDocs.Conversion version: {_productVersion}");
    }
}