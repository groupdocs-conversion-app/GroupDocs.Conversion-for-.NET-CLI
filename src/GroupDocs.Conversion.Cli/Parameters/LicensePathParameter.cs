using GroupDocs.Conversion.Cli.Common.Parameters;

namespace GroupDocs.Conversion.Cli.Parameters;

internal class LicensePathParameter: StringParameter
{
    public LicensePathParameter() : base("license-path", "Specifies the path to the license file", false, "l")
    {
    }
}