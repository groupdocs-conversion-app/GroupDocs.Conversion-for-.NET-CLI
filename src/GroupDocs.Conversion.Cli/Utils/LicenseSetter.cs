using GroupDocs.Conversion.Cli.Common;
using GroupDocs.Conversion.Cli.Parameters;

namespace GroupDocs.Conversion.Cli.Utils
{
    internal class LicenseSetter
    {
        private readonly ParseResult _parsed;

        public LicenseSetter(ParseResult parsed)
        {
            _parsed = parsed;
        }

        /// <summary>
        /// Set license for the application either from the environment variable in CommandContext or from a parameter provided by the user
        /// </summary>
        internal void SetLicense()
        {
            var licensePath = _parsed.Get<LicensePathParameter>()?.Value ??
                              CommandContext.GetLicensePath();
            if (string.IsNullOrEmpty(licensePath))
            {
                return;
            }

            try
            {
                var license = new License();
                license.SetLicense(licensePath);
                Reporter.Output.WriteLine("License set.");
            }
            catch 
            {
                // ignored
            }
        }
    }
}
