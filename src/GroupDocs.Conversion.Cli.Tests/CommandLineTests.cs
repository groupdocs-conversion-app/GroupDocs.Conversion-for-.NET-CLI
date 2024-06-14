using GroupDocs.Conversion.Cli.Tests.Utils;
using NUnit.Framework;
using System.Reflection;
using GroupDocs.Conversion.Cli.Common.Parameters;

namespace GroupDocs.Conversion.Cli.Tests;

/// <summary>
/// Command-line tests.
/// </summary>
public class CommandLineTests : BaseConsoleTests
{
    [Test]
    public void HelpIsDisplayed()
    {
        string result = CallCliApplication(new string[] { });

        Assert.IsTrue(result.Contains("Usage: groupdocs-conversion [command]"));
    }

    [Test]
    public void ConversionPerformedNoneVerbose()
    {
        const string source = "Resources/test.docx";
        const string target = "converted.pdf";

        DeleteFileIfExists(target);

        string result = CallCliApplication(new string[] { "convert", "-s", source, "-f", target });
        Assert.IsTrue(result.Contains("The document has been converted"));
        Assert.IsFalse(result.Contains("[TRACE] Determine loaded for source document"));
    }

    [TestCase("-v")]
    [TestCase("--verbose")]
    public void DisplayedVerbose(string parameter)
    {
        const string source = "Resources/test.docx";
        const string target = "converted.pdf";

        DeleteFileIfExists(target);

        string result = CallCliApplication(new string[] { "convert", "-s", source, "-f", target, parameter });

        Assert.IsTrue(result.Contains("[TRACE] Determine loaded for source document"));
    }

    /// <summary>
    /// Check that parameter help exist in help (launch CLI without any arguments). 
    /// </summary>
    [Test]
    public void CheckAllParametersExistInHelpWhenToolInvokedWithoutAnyArguments()
    {
        List<Parameter> parameters = GetAllParameters();

        string result = CallCliApplication(Array.Empty<string>());

        Assert.IsTrue(result.Contains("convert"), 
            "Full parameter name should be displayed in console" + result);

        Assert.IsTrue(result.Contains("get-document-info"), 
            "Full parameter name should be displayed in console" + result);
    }

    /// <summary>
    /// Check that all parameters help exist in help for convert command. 
    /// </summary>
    [Test]
    public void CheckAllParametersExistInHelpForConvertCommand()
    {
        List<Parameter> parameters = GetAllParameters();

        string result = CallCliApplication(new string[] { "convert", "-h" });

        foreach (Parameter parameter in parameters)
        {
            Assert.IsTrue(result.Contains(parameter.Description),
                "Full parameter name should be displayed in console" + result);
        }
    }

    /// <summary>
    /// Check that three parameters help exist in help for get-document-info command. 
    /// </summary>
    [Test]
    public void CheckThreeParametersExistInHelpForGetDocumentInfoCommand()
    {
        List<Parameter> parameters = GetAllParameters().
            Where(x =>
                x.Name == "license-path" ||
                x.Name == "source" ||
                x.Name == "verbose").ToList();

        string result = CallCliApplication(new string[] { "get-document-info", "-h" });

        foreach (Parameter parameter in parameters)
        {
            Assert.IsTrue(result.Contains(parameter.Description), "Full parameter name should be displayed in console" + result);
        }
    }

    /// <summary>
    /// Check that other parameters not exist in help for get-document-info command. 
    /// </summary>
    [Test]
    public void CheckOtherParametersNotExistInHelpForGetDocumentInfoCommand()
    {
        List<Parameter> parameters = GetAllParameters().
            Where(x =>
                x.Name != "license-path" &&
                x.Name != "source" &&
                x.Name != "timeout" &&
                x.Name != "verbose").ToList();

        string result = CallCliApplication(new string[] { "get-document-info", "-h" });

        foreach (Parameter parameter in parameters)
        {
            Assert.IsFalse(result.Contains(parameter.Description), 
                "Full parameter name should not be displayed in console" + result);
        }
    }

    private List<Parameter> GetAllParameters()
    {
        var type = typeof(Parameter);
        var types = Assembly.GetAssembly(typeof(Parameter))
            .GetTypes()
            .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract)
            .Select(x => Activator.CreateInstance(x) as Parameter).ToList();

        return types;
    }
}