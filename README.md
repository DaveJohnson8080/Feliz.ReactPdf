[![Build status](https://ci.appveyor.com/api/projects/status/xoua995yn45vf2kq?svg=true)](https://ci.appveyor.com/project/DaveJohnson8080/feliz-reactpdf) [![NuGet](https://img.shields.io/nuget/v/Feliz.ReactPdf.svg?style=flat-square)](https://www.nuget.org/packages/Feliz.ReactPdf/)

# Feliz.ReactPdf

Feliz/Fable bindings for [react-pdf](https://github.com/wojtekmaj/react-pdf)

## Installation

### npm

```npm install react-pdf```

```dotnet paket add Feliz.ReactPdf --project <path to your proj>```

### femto

(From the target project folder)
```dotnet femto install Feliz.ReactPdf```

## Caveats

Current version requires webpack. Will add support for other options if there's demand (or if there's a helpful pull request ;) )

## Contributing

This project uses `fake`, `paket`, and `femto` as .NET Core local tools. Therefore, run `dotnet tool restore` to restore the necessary CLI tools before doing anything else.

To run targets using Fake: `dotnet fake build -t TargetName`

### Regular maintenance

1. Run the `CiBuild` target to check that everything compiles
2. Commit and tag the commit (this is what triggers deployment from  AppVeyor). For consistency, the tag should be identical to the version (e.g. `1.2.3`).