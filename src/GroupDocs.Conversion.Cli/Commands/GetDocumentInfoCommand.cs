using GroupDocs.Conversion.Cli.Common;
using GroupDocs.Conversion.Cli.Parameters;
using GroupDocs.Conversion.Cli.Utils;
using GroupDocs.Conversion.Contracts;

namespace GroupDocs.Conversion.Cli.Commands;

internal class GetDocumentInfoCommand: Command
{
    public GetDocumentInfoCommand() : base("get-document-info", "Gets document information")
    {
        AddParameter(new SourceParameter());
        AddParameter(new LicensePathParameter());   
    }

    protected override bool ValidateParameters(ParseResult parsed)
    {
        return true;
    }

    protected override void Execute(ParseResult parsed)
    {
        var source = parsed.Get<SourceParameter>()?.Value ?? string.Empty;
        
        var licenseSetter = new LicenseSetter(parsed);
        licenseSetter.SetLicense();

        using(var converter = new Converter(source))
        {
            var info = converter.GetDocumentInfo();
            PrintInfo(info);
        }   
    }

    private void PrintInfo(IDocumentInfo info)
    {
        var keys = info.PropertyNames;

        foreach(var key in keys)
        {
            Reporter.Output.WriteLine($"{key}: {info[key]}");
        }
    }
}