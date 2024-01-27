# FormaUI

FormaUI implements FluentUI styles for existing WPF components.

## Getting Started

Follow these steps to setup FormaUI in your WPF application.

### Configuring App.xaml

Like any other WPF library, the styles needs to be imported through the App.xaml file, declaring
the proper resource dictionary in the merged dictionaries.

```XML
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

Additionally you can add the following dicctionary to use the dark theme.

```xml
<ResourceDictionary Source="pack://application:,,,/FormaUI;component/Styles/Themes/ColorsDark.xaml" />
```

You can switch between the light and dark theme at runtime by changing calling this function

```csharp
ThemeManager.ChangeTheme(Theme.Light);
ThemeManager.ChangeTheme(Theme.Dark);
ThemeManager.ChangeTheme(Theme.SystemTheme);
```

### Configuring a Window

Additionally any window that you want to use the Forma styles needs to be declared as a FluentWindow.

```xml
<forma:FluentWindow
  x:Class="WpfApplication.MainWindow"
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
  xmlns:forma="clr-namespace:FormaUI.Controls;assembly=FormaUI"
  xmlns:local="clr-namespace:WpfApplication"
  Title="MainWindow"
  Width="800"
  Height="600"
  mc:Ignorable="d">

</forma:FluentWindow>
```