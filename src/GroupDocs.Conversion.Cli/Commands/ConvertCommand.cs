using GroupDocs.Conversion.Cli.Common;
using GroupDocs.Conversion.Cli.Logging;
using GroupDocs.Conversion.Cli.Parameters;
using GroupDocs.Conversion.Cli.Utils;
using GroupDocs.Conversion.Exceptions;
using GroupDocs.Conversion.FileTypes;

namespace GroupDocs.Conversion.Cli.Commands;

internal class ConvertCommand : Command
{
    private bool _hasOutputFile;    
    private bool _hasOutputDirectory;
    private bool _hasTargetFormat;
    
    public ConvertCommand() : base("convert",
        "Converts source document to target format. If target format is not provided, the target format is detected from the target file extension.")
    {
        AddParameter(new SourceParameter());
        AddParameter(new OutputFileParameter());
        AddParameter(new OutputDirectoryParameter());
        AddParameter(new TargetFormatParameter());
        AddParameter(new LicensePathParameter());
    }

    protected override bool ValidateParameters(ParseResult parsed)
    {
        _hasOutputFile = parsed.Get<OutputFileParameter>() != null;
        _hasOutputDirectory = parsed.Get<OutputDirectoryParameter>() != null;
        _hasTargetFormat = parsed.Get<TargetFormatParameter>() != null;

        if (_hasOutputFile && _hasOutputDirectory)
        {
            Reporter.Error.WriteLine("The output-file and output-directory parameters cannot be used together.");
            return false;
        }

        if (_hasOutputFile && _hasTargetFormat)
        {
            Reporter.Error.WriteLine("The output-file and target-format parameters cannot be used together.");
            return false;
        }

        if (_hasOutputDirectory && !_hasTargetFormat)
        {
            Reporter.Error.WriteLine("The output-directory parameter requires the target-format parameter.");
            return false;
        }

        if (_hasTargetFormat)
        {
            var targetFormat = parsed.Get<TargetFormatParameter>()?.Value ?? FileType.Unknown;
            if (targetFormat == FileType.Unknown)
            {
                Reporter.Error.WriteLine("The target-format parameter is invalid.");
                return false;
            }
        }

        return true;
    }

    protected override void Execute(ParseResult parsed)
    {
        var source = parsed.Get<SourceParameter>()?.Value ?? string.Empty;
        
        var licenseSetter = new LicenseSetter(parsed);
        licenseSetter.SetLicense();
        try
        {
            if (_hasOutputFile)
            {
                var outputFile = parsed.Get<OutputFileParameter>()?.Value ?? string.Empty;
                ConvertToFile(source, outputFile);
                Reporter.Output.WriteLine($"The document has been converted to {outputFile}");
                return;
            }

            if (_hasOutputDirectory)
            {
                var outputDirectory = parsed.Get<OutputDirectoryParameter>()?.Value ?? string.Empty;
                var targetFormat = parsed.Get<TargetFormatParameter>()?.Value!;

                ConvertToDirectory(source, outputDirectory, targetFormat);
                Reporter.Output.WriteLine($"The document has been converted to {outputDirectory}");
                return;
            }

        }
        catch (GroupDocsConversionException e)
        {
            Reporter.Error.WriteLine(e.Message);
        }
    }

    private void ConvertToDirectory(string source, string outputDirectory, FileType targetFormat)
    {
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        var sourceFileName = Path.GetFileNameWithoutExtension(source);

        using (var converter = ConverterFactory.GetConfiguredConverter(source))
        {
            var convertOptions = converter.GetPossibleConversions()[targetFormat].ConvertOptions;
            converter.Convert(_ => new MemoryStream(),
                (_, _, page, convertedStream) =>
                {
                    using (var fileStream = File.Create(Path.Combine(outputDirectory, $"{sourceFileName}_{page}.{targetFormat.Extension}")))
                    {
                        convertedStream.CopyTo(fileStream);
                    }
                },convertOptions);
        }
    }

    private void ConvertToFile(string source, string target)
    {
        using (var converter = ConverterFactory.GetConfiguredConverter(source))
        {
            var extension = Path.GetExtension(target);
            var convertOptions = converter.GetPossibleConversions()[extension].ConvertOptions;
            converter.Convert(target, convertOptions);
        }
    }
}

