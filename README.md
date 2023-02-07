# generate-qrcode-cli

This is a simple dotnet console app that will accept a text (e.g. URL) and a file name (must be .svg or .png), and encode the text as a QR code
written to the file.

## Dependencies

This code depends on `Net.Codecrete.QrCodeGenerator` and `SkiaSharp`, which you can install using NuGet Package Manager GUI in VS Code, or however else
you'd like.

## Usage
The `launch.json` includes an example for svg, png, and usage.

The app accepts 0, 1, or 2 console arguments.  Passing `-h` will return the following and then safely exit.

```
Usage:
  Provide 2 arguments, the text ( e.g. URL) and the output filename (.svg or .png) for the QR code.
```

Providing 1 argument other than `-h` or `--help` will use the argument as the text (e.g. URL), and will prompt for the output file name.

Providing 0 arguments will prompt the user first for the text, and then for the file name.

## Build and Publish

To publish a self-contained console app __for Mac__, that requires no dependencies or dotnet runtime, do the following.

```
dotnet publish -r osx-x64 --self-contained=true /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true -o .
```

The output of this is included in this repository at `generate-qrcode-cli`.  It is executable on Mac.  The first time you
want to run it, you need to right-click it in Finder, and Open it.  You'll be asked to confirm you trust the developer.  After
that one time, you can simply run it in the terminal.  For example ...

`./generate-qrcode-cli https://www.sweetalscookies.com sweetals-qrcode.png`

If you have dotnet installed, likely you know all the other ways you can build and publish this simple little console app.
