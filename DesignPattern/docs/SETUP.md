# Project Setup and Run Guide

Use this guide to prepare your machine and run the `DesignPattern` console application.

## Prerequisites

### Required

- **.NET 10 SDK** for the `net10.0` target framework. Install it from the [official .NET 10 download page](https://dotnet.microsoft.com/download/dotnet/10.0).
- A supported operating system: Windows, macOS, or Linux.
- A terminal such as PowerShell, Command Prompt, or a shell on macOS/Linux.

The **SDK** is required to build the project. Installing only the .NET runtime is not sufficient.

### Optional

- **Visual Studio Code** with the **C# Dev Kit** extension for editing and debugging.
- Visual Studio with .NET desktop development tools, if you prefer the full IDE.

No third-party NuGet libraries are required by `DesignPattern.csproj`. The project uses the .NET SDK and built-in framework libraries.

## Verify the SDK

Open a terminal and check the installed SDKs:

```powershell
dotnet --list-sdks
```

Confirm that the list includes a `10.0.x` SDK. If the `dotnet` command is not found or no .NET 10 SDK is listed, install the SDK and open a new terminal.

## Open the repository

Open the repository root in your terminal. It is the directory containing `c#.sln` and the `DesignPattern` folder.

For example, in PowerShell:

```powershell
cd C:\path\to\csharp
```

Replace the example path with the location where you cloned or extracted the repository.

## Clean, build, and run

Run these commands from the repository root:

```powershell
dotnet clean .\DesignPattern\DesignPattern.csproj
dotnet build .\DesignPattern\DesignPattern.csproj
dotnet run --project .\DesignPattern\DesignPattern.csproj -- composition
```

`dotnet build` and `dotnet run` restore the project automatically when needed. You can also restore explicitly:

```powershell
dotnet restore .\DesignPattern\DesignPattern.csproj
```

To show the interactive example menu instead of selecting an example on the command line:

```powershell
dotnet run --project .\DesignPattern\DesignPattern.csproj
```

## Select an example

Pass one of the following names after `--`:

| Example | Command argument |
|---|---|
| Abstraction | `abstraction` |
| Encapsulation | `encapsulation` |
| Inheritance | `inheritance` |
| Polymorphism | `polymorphism` |
| Coupling | `coupling` |
| Composition | `composition` |

For example:

```powershell
dotnet run --project .\DesignPattern\DesignPattern.csproj -- polymorphism
```

## Run from the project directory

You can also navigate into the project folder and use shorter commands:

```powershell
cd .\DesignPattern
dotnet clean
dotnet build
dotnet run -- composition
```

## Run and debug in Visual Studio Code

1. Open the repository root folder in Visual Studio Code.
2. Install the C# Dev Kit extension if it is not already installed.
3. Open **Run and Debug**.
4. Choose **Debug DesignPattern** and start debugging.
5. To pass an example name, add it to the `args` array for the `Debug DesignPattern` configuration in `.vscode/launch.json`, for example: `"composition"`.

The repository includes a `build DesignPattern` task and a `Debug DesignPattern` launch configuration.

## Troubleshooting

### `The current .NET SDK does not support targeting .NET 10.0`

Install the .NET 10 SDK from the official download page, then restart the terminal and verify it with `dotnet --list-sdks`.

### `dotnet` is not recognized or not found

Install the .NET 10 SDK and make sure its installation directory is available on your `PATH`. Restart the terminal after installation.

### A restore or build fails

Check the full error output and verify the project file is present:

```powershell
Test-Path .\DesignPattern\DesignPattern.csproj
dotnet restore .\DesignPattern\DesignPattern.csproj
dotnet build .\DesignPattern\DesignPattern.csproj
```

## Next

Return to the [book contents](README.md) to continue the guided lessons.
