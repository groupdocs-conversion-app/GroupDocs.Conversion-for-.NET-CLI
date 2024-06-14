using System.Reflection;
using GroupDocs.Conversion.Cli.Utils;
using NUnit.Framework;

namespace GroupDocs.Conversion.Cli.Tests.Utils;

public class BaseConsoleTests
{
    protected static object LockObject = new();
    protected ConsoleOutput? ConsoleOutput;

    [SetUp]
    public void TestPreClean()
    {
        // Clear console 
        lock (LockObject)
        {
            ConsoleOutput?.Dispose();
            // Clear console 
            ConsoleOutput = new ConsoleOutput();
            Reporter.Reset();
        }
    }

    [TearDown]
    public void TearDown()
    {
        Reporter.Reset();
    }

    /// <summary>
    /// Call CLI application and get console output.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>Console output.</returns>
    protected string CallCliApplication(string[] args)
    {
        string result;

        var assembly = Assembly.LoadFrom("groupdocs-conversion.dll");

        lock (LockObject)
        {
            assembly.EntryPoint?.Invoke(null, new object[] { args });
            result = ConsoleOutput?.GetOuput() + ConsoleOutput?.GetError();
        }

        return result;
    }

    protected void DeleteFileIfExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}