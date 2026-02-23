# FormaUI

[![NuGet](https://img.shields.io/nuget/v/FormaUI)](https://www.nuget.org/packages/FormaUI)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.md)

FormaUI is an open source implementation of FluentUI styles for existing WPF components. It provides modern, Fluent Design styling for standard WPF controls without requiring you to replace them with custom control types.

## Features

- Fluent Design styles for 30+ WPF controls including Button, CheckBox, ComboBox, DataGrid, DatePicker, Expander, ListBox, ListView, Menu, ProgressBar, RadioButton, Slider, TabControl, TextBox, TreeView, and more
- Light and Dark theme support with runtime switching
- System theme detection to match the user's Windows preference
- Custom `FluentWindow` with modern title bar styling
- `FluentMessageBox` as a styled replacement for the standard `MessageBox`
- `NumericUpDown` and `SymbolIcon` custom controls
- Supports .NET 8, .NET 9, and .NET 10

## Installation

Install FormaUI from NuGet:

```
dotnet add package FormaUI
```

## Getting Started

Follow these steps to set up FormaUI in your WPF application.

### Configuring App.xaml

Import the FormaUI styles through your `App.xaml` file by adding the resource dictionary to the merged dictionaries:

```xml
<Application
  x:Class="WpfApplication.App"
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:local="clr-namespace:WpfApplication"
  StartupUri="MainWindow.xaml">
  <Application.Resources>
    <ResourceDictionary>
      <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="pack://application:,,,/FormaUI;component/Styles/Fluent.xaml" />
      </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
  </Application.Resources>
</Application>
```

Additionally you can add the following dictionary to use the dark theme:

```xml
<ResourceDictionary Source="pack://application:,,,/FormaUI;component/Styles/Themes/ColorsDark.xaml" />
```

You can switch between the light and dark theme at runtime by calling these methods:

```csharp
ThemeManager.ChangeTheme(Theme.Light);
ThemeManager.ChangeTheme(Theme.Dark);
ThemeManager.ChangeTheme(Theme.SystemTheme);
```

### Configuring a Window

Any window that you want to use the FormaUI styles needs to be declared as a `FluentWindow`. Update both the XAML root element and the code-behind base class.

In your XAML file:

```xml
<forma:FluentWindow
  x:Class="WpfApplication.MainWindow"
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
  xmlns:forma="clr-namespace:FormaUI.Controls;assembly=FormaUI"
  xmlns:local="clr-namespace:WpfApplication"
  Title="MainWindow"
  Width="800"
  Height="600"
  mc:Ignorable="d">

</forma:FluentWindow>
```

In your code-behind file, remove the `: Window` base class (the XAML partial class will inherit from `FluentWindow` automatically):

```csharp
public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
```

### Using FluentMessageBox

FormaUI provides `FluentMessageBox` as a styled drop-in replacement for the standard WPF `MessageBox`:

```csharp
using FormaUI.Dialogs;

FluentMessageBox.Show("Hello, World!");
FluentMessageBox.Show("Message text", "Title", MessageBoxButton.OKCancel);
```

## License

This project is licensed under the [MIT License](LICENSE.md).