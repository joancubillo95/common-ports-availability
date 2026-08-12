# Common Ports Availability

A tiny .NET console application built as a small experiment:

> **How little do you need to create and run a useful piece of code?**

The application checks whether a few commonly used ports are available on the local machine.

The port checker itself isn't the main point. The goal was to start from an empty directory and see how minimal the complete setup could be.

## Reproduce It From Zero

### 1. Create the project directory

```powershell
mkdir common-ports-availability
cd common-ports-availability
```

### 2. Set up .NET with Mise

Install [Mise](https://mise.jdx.dev/) if you don't already have it.

Then install and activate the required .NET version:

```powershell
mise use dotnet@10.0.302
(& mise activate pwsh) | Out-String | Invoke-Expression
```

Add Mise activation to your PowerShell profile so that `dotnet` is available in future sessions.

Once PowerShell recognizes .NET:

```powershell
dotnet --version
```

You should get:

```text
10.0.302
```

### 3. Create the application

From the empty directory:

```powershell
dotnet new console
```

That's it.

You now have a minimal .NET application.

### 4. Add the code

Replace the generated `Program.cs` with the implementation in this repository. Or don't, and  in step 5 you will get the famous Hello, World! printed in your console.

### 5. Run it

Once .NET is available in PowerShell:

```powershell
dotnet run
```

The application checks the configured ports and displays whether each one is available.

## Build a Standalone Executable

If you want to distribute the application without requiring .NET to be installed:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

The resulting executable will be under:

```text
bin\Release\net10.0\win-x64\publish\
```

You can copy the `.exe` to another Windows machine and run it directly.

## The Point

The interesting part of this project isn't the port checker.

It's how little is actually required to go from:

**empty directory → working code → standalone executable**

No framework.
No external services.
No unnecessary dependencies.

Just .NET, a small amount of code, and a reason to run it.


## Windows SmartScreen
Because this is a small open-source project and the executable is not code-signed, Windows may display a security warning when downloading or running the release. This is expected for unsigned executables.
