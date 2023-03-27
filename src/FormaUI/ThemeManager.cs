using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;

namespace FormaUI;

public static class ThemeManager
{
    private const string LightDictionary = "/FormaUI;component/Styles/Themes/ColorsLight.xaml";
    private const string DarkDictionary = "/FormaUI;component/Styles/Themes/ColorsDark.xaml";

    private static Theme _currentTheme;
    private static Theme _appliedTheme;

    public static Theme CurrentTheme
    {
        get
        {
            if (_currentTheme == Theme.Unknown)
            {
                _currentTheme = FindTheme();
            }

            return _currentTheme;
        }
        private set => _currentTheme = value;
    }

    public static Theme AppliedTheme
    {
        get
        {
            if (_appliedTheme == Theme.Unknown)
            {
                _appliedTheme = CurrentTheme;
            }

            if (_appliedTheme == Theme.SystemTheme)
            {
                _appliedTheme = GetSystemTheme();
            }

            return _appliedTheme;
        }
        private set => _appliedTheme = value;
    }

    public static void SwitchTheme() =>
        ChangeTheme(AppliedTheme switch
        {
            Theme.Light => Theme.Dark,
            Theme.Dark => Theme.Light,
            Theme.Unknown => throw new ArgumentOutOfRangeException(nameof(AppliedTheme), AppliedTheme, "Cannot switch to an unknown theme."),
            _ => throw new UnreachableException(),
        });

    public static void ChangeTheme(Theme theme)
    {
        if (CurrentTheme == theme)
        {
            return;
        }

        ChangeThemeInternal(theme == Theme.SystemTheme
            ? GetSystemTheme()
            : theme);

        CurrentTheme = theme;
    }

    private static void ChangeThemeInternal(Theme theme)
    {
        if (AppliedTheme == theme)
        {
            return;
        }

        var originalUri = GetUri(AppliedTheme);

        var dictionary = Application.Current.Resources.MergedDictionaries
            .FirstOrDefault(x => x.Source.LocalPath == originalUri);

        if (dictionary is not null)
        {
            Application.Current.Resources.MergedDictionaries.Remove(dictionary);
        }

        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
        {
            Source = new Uri($"pack://application:,,,{GetUri(theme)}")
        });

        AppliedTheme = theme;
    }

    private static string GetUri(Theme theme) => theme switch
    {
        Theme.Light => LightDictionary,
        Theme.Dark => DarkDictionary,
        Theme.Unknown => throw new InvalidOperationException(),
        _ => throw new UnreachableException(),
    };

    private static Theme FindTheme()
    {
        foreach (var item in GetMergedDictionariesRecursive().Where(x => x.Source != null).Reverse())
        {
            if (item.Source.LocalPath == LightDictionary)
            {
                return Theme.Light;
            }
            if (item.Source.LocalPath == DarkDictionary)
            {
                return Theme.Dark;
            }
        }

        return Theme.Unknown;
    }

    private static Theme GetSystemTheme()
    {
        using var registry = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize");

        if (registry is null)
        {
            return Theme.Unknown;
        }

        var appsLightTheme = registry.GetValue("AppsUseLightTheme");

        if (appsLightTheme is not int appsLightThemeValue)
        {
            return Theme.Unknown;
        }

        return appsLightThemeValue switch
        {
            0 => Theme.Dark,
            1 => Theme.Light,
            _ => Theme.Unknown
        };
    }

    private static IEnumerable<ResourceDictionary> GetMergedDictionariesRecursive() =>
        Application.Current.Resources.GetMergedDictionariesRecursive();

    private static IEnumerable<ResourceDictionary> GetMergedDictionariesRecursive(this ResourceDictionary dictionary) =>
        dictionary.MergedDictionaries.SelectMany(GetMergedDictionariesRecursive).Prepend(dictionary);
}

public enum Theme
{
    Unknown,
    Light,
    Dark,
    SystemTheme
}