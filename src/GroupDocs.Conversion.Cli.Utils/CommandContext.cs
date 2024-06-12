namespace GroupDocs.Conversion.Cli.Utils;

public static class CommandContext
{
    public static class Variables
    {
        private static readonly string Prefix = "GROUPDOCS_CONVERSION_CLI_CONTEXT_";
        public static readonly string LicensePathPrefix = "GROUPDOCS_CONVERSION_LICENSE_PATH";
        public static readonly string Verbose = Prefix + "VERBOSE";
        public static readonly string AnsiPassThru = Prefix + "ANSI_PASS_THRU";
        public static readonly string Timeout = Prefix + "TIMEOUT";
    }

    private static Lazy<bool> _verbose = new(() => Env.GetEnvironmentVariableAsBool(Variables.Verbose));
    private static Lazy<bool> _ansiPassThru = new(() => Env.GetEnvironmentVariableAsBool(Variables.AnsiPassThru));

    public static string? GetLicensePath()
    {
        return Env.GetEnvironmentVariable(Variables.LicensePathPrefix);
    }

    public static int GetCommandTimeout()
    {
        const int defaultTimeout = 60;
        var environmentTimeout = Env.GetEnvironmentVariable(Variables.Timeout);
        return int.TryParse(environmentTimeout, out var timeout) ? timeout : defaultTimeout;
    }

    public static bool IsVerbose()
    {
        return _verbose.Value;
    }

    public static bool ShouldPassAnsiCodesThrough()
    {
        return _ansiPassThru.Value;
    }

    public static void SetVerbose(bool value)
    {
        _verbose = new Lazy<bool>(() => value);
        Reporter.Reset();
    }
}