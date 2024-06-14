# CLI for GroupDocs.Conversion for .NET

![Version 24.5.0](https://img.shields.io/badge/nuget-v24.5.0-blue) ![Nuget](https://img.shields.io/nuget/dt/GroupDocs.Conversion-CLI)

[![banner](https://raw.githubusercontent.com/groupdocs/groupdocs.github.io/master/img/banners/groupdocs-conversion-net-banner.png)](https://downloads.groupdocs.com/conversion/net)

[Product Page](https://products.groupdocs.com/conversion/net/) | [Docs](https://docs.groupdocs.com/conversion/net/) | [Demos](https://products.groupdocs.app/conversion/family) | [API Reference](https://reference.groupdocs.com/conversion/net/) | [Examples](https://github.com/groupdocs-conversion/GroupDocs.Conversion-for-.NET) | [Blog](https://blog.groupdocs.com/category/conversion/) | [Releases](https://releases.groupdocs.com/conversion/net/) | [Free Support](https://forum.groupdocs.com/c/conversion) | [Temporary License](https://purchase.groupdocs.com/temporary-license/)


CLI - Command Line Interface for `GroupDocs.Conversion for .NET` document conversion and automation API.

`GroupDocs.Conversion` is a class-library that enables you to build seamless document conversion applications for mobile, web, and desktop platforms using C#, F#, or VB.NET. It supports more than 10 000 combinations for converting popular file formats in HTML, PNG, JPEG, and PDF. Our library is self-sufficient and doesn't depend on any third-party software, such as Microsoft Word, OpenOffice, or other office suites.

## Features 

- Thousands of different file [conversion pairs](https://docs.groupdocs.com/conversion/net/supported-file-formats/): office documents, presentations, spreadsheets, images and much more.
- Ability to convert [whole document](https://docs.groupdocs.com/conversion/net/convert/) or [specific pages range](https://docs.groupdocs.com/conversion/net/convert-specific-pages/).
- [Place watermarks](https://docs.groupdocs.com/conversion/net/add-watermark/) at document pages during conversion.
- Huge amount of [additional options](https://docs.groupdocs.com/conversion/net/conversion-options-by-document-family/) to customize the appearance of the converted document.
- Load document from [Amazon S3](https://docs.groupdocs.com/conversion/net/load-file-from-amazon-s3-storage/), [Azure Blob](https://docs.groupdocs.com/conversion/net/load-file-from-azure-blob-storage/), [FTP](https://docs.groupdocs.com/conversion/net/load-file-from-ftp/), or from [local disk](https://docs.groupdocs.com/conversion/net/load-file-from-local-disk/).
- Load document via [stream](https://docs.groupdocs.com/conversion/net/load-file-from-stream/) or from a [specific URL](https://docs.groupdocs.com/conversion/net/load-file-from-url/).
- Load [password-protected](https://docs.groupdocs.com/conversion/net/load-password-protected-document/) documents.
- Enable [listening of conversion process stages](https://docs.groupdocs.com/conversion/net/listening/).

See the [Features overview](https://docs.groupdocs.com/conversion/net/features-overview/) documentation topic for more details.


## Supported platforms

- Windows: Microsoft Windows XP and later, Microsoft Windows Server 2003 and later.
- Linux: Ubuntu, OpenSUSE, CentOS and others.
- Mac OS X Catalina (10.15) and later.

If you build applications for Linux and macOS, we recommend using [GroupDocs.Conversion.CrossPlatform](https://www.nuget.org/packages/GroupDocs.Conversion.CrossPlatform) package instead of this one. `GroupDocs.Conversion.CrossPlatform` does not use on `System.Drawing.Common` as a graphical subsystem, [which is only supported on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only).

See the [System requirements](https://docs.groupdocs.com/conversion/net/system-requirements/) documentation topic for more details.


## Supported formats

- Documents: PDF, XPS, TEX
- Word: DOC, DOCX, DOCM, DOT, DOTX, DOTM, RTF, TXT
- Powepoint: PPT, PPTX, PPS, PPSX, ODP, OTP
- Excel: XLS, XLSX, XLSM, XLSB, XLTM, XLTX, XLT, XLAM
- Visio: VSDX, VSDM, VSSX, VSTX, VSTM, VSSM, VSX, VTX, VDX
- OpenDocument: ODT, OTT, ODS
- Images: BMP, JPEG, PNG, GIF, TIFF, SVG, PS
- Diagram: VSDX, DRAW, LUCIDCHART
- CAD & GIS: DWG, DXF, DWF, IFC, SHP, KML, GEOJSON
- Audio: MP3, WAV, FLAC, AAC, OGG
- Video: MP4, AVI, MKV, MOV, WMV
- 3D & Vector: SVG, AI, EPS, CDR, STL, OBJ, FBX, DAE, GLB
- eBook: EPUB, MOBI, AZW, FB2
- Web: HTML, MHTML, MHT
- Archives: ZIP, TAR, RAR, 7Z, BZ2, GZ
- Email & Outlook: PST, OST, MSG, EML
- Finance: QFX, OFX
- OneNote: ONE

See the [Supported file formats](https://docs.groupdocs.com/conversion/net/supported-file-formats/) documentation topic for a complete list of supported formats.

## Getting Started

`GroupDocs.Conversion CLI` is a dotnet tool. To start using the CLI you'll need .NET runtime and GroupDocs.Conversion CLI:

1. Install .NET Core runtime following by the [instructions](https://learn.microsoft.com/en-us/dotnet/core/install/)
2. Install dotnet tool by running `dotnet tool install --global GroupDocs.Conversion-CLI`
3. You can run GroupDocs.Conversion.CLI by using command `groupdocs-conversion`

GroupDocs.Conversion CLI is also distributed as a self-contained executable.

## Example usage

### Convert DOCX to PDF

```bash
groupdocs-conversion convert --source source.docx --output-file ./converted.pdf
```

### Convert DOCX to PNG

```bash
groupdocs-conversion convert --source source.docx --output-directory ./converted --target-format png
```

### Retrieve a document info

```bash
groupdocs-conversion get-document-info --source source.docx
```

## Commands

* `convert` converts source document to target format. If target format is not provided, the target format is detected from the target file extension.

* `get-document-info` gets document information

## Parameters

### Parameters for "convert" command

* `--output-directory` [short: `-d`]:  Specifies the output directory

* `--output-file` [short: `-f`]: Specifies the output document
 
* `--source` [short: `-s`]: Specifies the source document that will be converted (Required)

* `--target-format` [short: `-t`]: Specifies the desired format after conversion

### Parameters for "get-document-info" command

* `--source` [short: `-s`]: Specifies the source document that will be converted (Required)
 
### Parameters for "convert" and "get-document-info" commands

* `--license-path` [short: `-l`]: Specifies the path to the license file

* `--timeout`: Specifies the command timeout in seconds
 
* `--verbose` [short: `-v`]: Specifies whether to output detailed logs

## Setting the license

Without a license the tool will work in trial mode so you can convert only first three pages of a document see [Evaluation Limitations and Licensing of GroupDocs.Conversion](https://docs.groupdocs.com/conversion/net/licensing-and-subscription/) for more details. A temporary license can be requested at [Get a Temporary License](https://purchase.groupdocs.com/temporary-license).

The license can be set with `--license-path` parameter:

```bash
groupdocs-conversion convert --source source.docx --output-file ./converted.pdf --license-path c:\\licenses\\GroupDocs.Conversion.lic
```

Also, you can set path to the license file in `GROUPDOCS_CONVERSION_LICENSE_PATH` environment variable.

## Support

Our technical support is available to all users, including those evaluating our product. We offer assistance through our [Free Support Forum](https://forum.groupdocs.com/c/conversion/11) and [Paid Support Helpdesk](). Let us know if you have any questions or issues, and we'll do our best to help you.


[Product Page](https://products.groupdocs.com/conversion/net/) | [Docs](https://docs.groupdocs.com/conversion/net/) | [Demos](https://products.groupdocs.app/conversion/family) | [API Reference](https://reference.groupdocs.com/conversion/net/) | [Examples](https://github.com/groupdocs-conversion/GroupDocs.Conversion-for-.NET) | [Blog](https://blog.groupdocs.com/category/conversion/) | [Releases](https://releases.groupdocs.com/conversion/net/) | [Free Support](https://forum.groupdocs.com/c/conversion) | [Temporary License](https://purchase.groupdocs.com/temporary-license/)
