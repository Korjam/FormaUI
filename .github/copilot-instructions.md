# Copilot Coding Agent Instructions for FormaUI

## Project Overview

FormaUI is an open-source WPF UI framework that provides FluentUI (Fluent Design) styles for standard WPF controls. It is a C#/.NET library published on NuGet. The library styles 30+ built-in WPF controls (Button, CheckBox, ComboBox, DataGrid, etc.) without requiring custom control replacements, and adds a few custom controls (`FluentWindow`, `FluentMessageBox`, `NumericUpDown`, `SymbolIcon`).

## Tech Stack

- **Language:** C#
- **UI Framework:** WPF (Windows Presentation Foundation)
- **Target Frameworks:** .NET 8, .NET 9, .NET 10 (`net8.0-windows`, `net9.0-windows`, `net10.0-windows`)
- **Build System:** .NET SDK / MSBuild
- **Package Manager:** NuGet
- **Versioning:** MinVer (automatic semantic versioning from git tags)
- **Static Analysis:** WpfAnalyzers (4.1.1)

## Repository Structure

```
FormaUI/
├── .github/workflows/       # CI/CD (build.yaml, publish.yaml)
├── src/FormaUI/             # Main library project
│   ├── Behaviors/           # WPF attached behaviors (DataGrid, PasswordBox, TreeView, etc.)
│   ├── Common/              # Utilities (RelayCommand)
│   ├── Controls/            # Custom controls (FluentWindow, FluentDialog, NumericUpDown, SymbolIcon)
│   ├── Converters/          # XAML value converters
│   ├── Dialogs/             # FluentMessageBox implementation
│   ├── Styles/              # XAML resource dictionaries
│   │   ├── Controls/        # Per-control style files (Button.xaml, TextBox.xaml, etc.)
│   │   ├── Themes/          # Theme color dictionaries (ColorsLight.xaml, ColorsDark.xaml, Accent.xaml)
│   │   ├── Values/          # Shared values (Text.xaml)
│   │   └── Fluent.xaml      # Root style dictionary that merges everything
│   ├── Themes/Generic.xaml  # WPF generic theme dictionary for custom controls
│   ├── ThemeManager.cs      # Runtime theme switching (Light/Dark/System)
│   ├── Constans.cs          # Internal constants
│   ├── TreeHelper.cs        # Visual/logical tree helpers
│   └── FormaUI.csproj       # Project file
├── samples/
│   └── FormaUI.Demo.ControlSample/  # Demo WPF app (.NET 10 only)
├── Directory.Build.props    # Shared MSBuild properties (metadata, analyzers)
├── FormaUI.slnx             # Solution file
├── README.md
└── LICENSE.md
```

## Build Commands

### On Windows (CI environment)

```bash
dotnet restore
dotnet build -c Release --no-restore
```

### On Linux/macOS (local development or Codespaces)

WPF projects target Windows. To build on non-Windows systems, you must pass `EnableWindowsTargeting`:

```bash
dotnet restore -p:EnableWindowsTargeting=true
dotnet build -c Release -p:EnableWindowsTargeting=true
```

Without this flag, the build will fail with:
> `error NETSDK1100: To build a project targeting Windows on this operating system, set the EnableWindowsTargeting property to true.`

### Packaging

```bash
dotnet pack -c Release --no-build -o .
```

## Testing

There is **no test project or test framework** in this repository. The project relies on:
- Manual testing via the `samples/FormaUI.Demo.ControlSample` demo application
- WpfAnalyzers for static code analysis during build
- Building successfully across all three target frameworks (.NET 8, 9, 10)

When making changes, validate by building the full solution across all target frameworks. On non-Windows, use:
```bash
dotnet build -c Release -p:EnableWindowsTargeting=true
```

## CI/CD

- **`build.yaml`** — Runs on PRs to `development` and pushes to `development` or `feature/**` branches. Performs restore + build in Release configuration on `windows-latest` with .NET 10.
- **`publish.yaml`** — Runs on pushes to `main`. Builds, packs, and publishes the NuGet package to nuget.org.

Both workflows run on `windows-latest` and use .NET 10.0.x SDK.

## Branching Model

- `main` — Release branch; pushes trigger NuGet package publishing
- `development` — Integration branch; PRs target this branch
- `feature/**` — Feature branches; CI builds run on push

## Key Conventions

- **XAML styles** live in `src/FormaUI/Styles/Controls/`, one file per WPF control type.
- **Theme colors** are defined in `src/FormaUI/Styles/Themes/ColorsLight.xaml` and `ColorsDark.xaml`. Adding new themed resources requires updating both files.
- **Custom controls** must have their default styles in `src/FormaUI/Themes/Generic.xaml` and visual templates in corresponding files under `Styles/Controls/`.
- **Behaviors** use `Microsoft.Xaml.Behaviors.Wpf` and are located in `src/FormaUI/Behaviors/`.
- The root style entry point is `src/FormaUI/Styles/Fluent.xaml`, which merges all sub-dictionaries. New style files must be added to this dictionary.
- Implicit usings and nullable reference types are enabled project-wide (`Directory.Build.props`).
- The project uses `MinVer` for versioning from git tags—no manual version bumps needed.

## Common Pitfalls

1. **Building on non-Windows:** Always pass `-p:EnableWindowsTargeting=true` when building on Linux or macOS.
2. **Adding a new styled control:** Remember to add its XAML resource dictionary to `Fluent.xaml` so it gets merged at runtime.
3. **Theme resources:** Any new color or brush resource must be defined in both `ColorsLight.xaml` and `ColorsDark.xaml` to avoid runtime `ResourceReferenceKeyNotFoundException`.
4. **Solution file format:** The solution uses the newer `.slnx` format (not `.sln`). Use `dotnet` CLI commands which support this format.
