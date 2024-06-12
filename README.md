# CLI for GroupDocs.Conversion for .NET

![Nuget](https://img.shields.io/nuget/v/groupdocs.conversion-cli)
![Nuget](https://img.shields.io/nuget/dt/groupdocs.conversion-cli)


CLI - Command Line Interface for [GroupDocs.Conversion for .NET](https://products.groupdocs.com/conversion/net/) document conversion and automation API.

## How to install

GroupDocs.Conversion CLI is a dotnet tool. To start using the CLI you'll need .NET runtime and GroupDocs.Conversion CLI.

1. Install .NET Core runtime following by the [instructions](https://docs.microsoft.com/en-us/dotnet/core/install/)
2. Install dotnet tool by running `dotnet tool install --global GroupDocs.Conversion-CLI`
3. You can run GroupDocs.Conversion.CLI by using command `groupdocs-conversion`

GroupDocs.Conversion CLI is also distributed as self-contained executable.

## Example usage

Type `convert` command to convert specified source filename to desired format:

```bash
groupdocs-conversion convert --source source.docx --output-file ./converted.pdf
```

Set `output-directory` parameter to specify where the converted files will be stored and `target-format` to specify the desired format:

```bash
groupdocs-conversion convert --source source.docx --output-directory ./converted --target-format png
```

Type `get-document-info` to retrieve document of the source filename:

```bash
groupdocs-conversion get-document-info --source source.docx
```

The `--help` or `convert --help` option provides more detail about each parameter. \
The `--version` option provides information about CLI version in use.

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

## Linux dependencies

For correct deploy please install the following package dependencies:

* `apt-transport-https`
* `dirmngr`
* `gnupg`
* `libc6-dev`
* `libgdiplus`
* `libx11-dev`
* `ttf-mscorefonts-installer`

As an example the following commands should be executed to install the dependencies on [Ubuntu 18.04.5 LTS (Bionic Beaver)](https://releases.ubuntu.com/18.04.5/):

* `apt-get update`
* `apt-get install -y apt-transport-https`
* `apt-get install -y dirmngr`
* `apt-get install -y gnupg`
* `apt-get install -y ca-certificates`
* `apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys $ 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF`
* `echo "deb https://download.mono-project.com/repo/ubuntu stable-bionic $ main" >> /etc/apt/sources.list.d/mono-official-stable.list`
* `apt-get update`
* `apt-get install -y --allow-unauthenticated libc6-dev libgdiplus libx11-dev`
* `apt-get install -y ttf-mscorefonts-installer`
