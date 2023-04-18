using System.Diagnostics;
using System.Windows;

namespace FluentUI;

public static class ThemeManager
{
    private const string LightDictionary = "/FluentUI;component/Styles/Themes/ColorsLight.xaml";
    private const string DarkDictionary = "/FluentUI;component/Styles/Themes/ColorsDark.xaml";

    private static Theme _currentTheme;

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

    public static void ChangeTheme(Theme newTheme)
    {
        if (CurrentTheme == newTheme)
        {
            return;
        }

        var originalUri = GetUri(CurrentTheme);

        var dictionary = Application.Current.Resources.MergedDictionaries
            .FirstOrDefault(x => x.Source.LocalPath == originalUri);

        if (dictionary is not null)
        {
            Application.Current.Resources.MergedDictionaries.Remove(dictionary);
        }

        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
        {
            Source = new Uri($"pack://application:,,,{GetUri(newTheme)}")
        });

        CurrentTheme = newTheme;
    }

    private static string GetUri(Theme currentTheme) => currentTheme switch
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

    private static IEnumerable<ResourceDictionary> GetMergedDictionariesRecursive() =>
        Application.Current.Resources.GetMergedDictionariesRecursive();

    private static IEnumerable<ResourceDictionary> GetMergedDictionariesRecursive(this ResourceDictionary dictionary) =>
        dictionary.MergedDictionaries.SelectMany(GetMergedDictionariesRecursive).Prepend(dictionary);
}

public enum Theme
{
    Unknown,
    Light,
    Dark
}