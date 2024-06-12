using GroupDocs.Conversion.Cli;
using GroupDocs.Conversion.Cli.Commands;
using GroupDocs.Conversion.Cli.Common;

var commandRegistry = new CommandRegistry("groupdocs-conversion", Product.CLIVersion, Product.GroupDocsConversionVersion);

// Register commands
commandRegistry.RegisterCommand(new ConvertCommand());
commandRegistry.RegisterCommand(new GetDocumentInfoCommand());

// Execute the appropriate command
commandRegistry.ExecuteCommand(args);