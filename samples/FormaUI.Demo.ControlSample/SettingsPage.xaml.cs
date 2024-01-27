using System.Windows.Controls;

namespace FormaUI.Demo.ControlSample;

/// <summary>
/// Interaction logic for SettingsPage.xaml
/// </summary>
public partial class SettingsPage : Page
{
    public SettingsPage()
    {
        InitializeComponent();
        _themeComboBox.SelectedItem = ThemeManager.CurrentTheme;
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (!IsLoaded)
        {
            return;
        }
        ThemeManager.ChangeTheme((Theme)_themeComboBox.SelectedItem);
    }
}
