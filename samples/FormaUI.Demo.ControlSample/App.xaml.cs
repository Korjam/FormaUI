using System.Windows;

namespace FormaUI.Demo.ControlSample;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        AppContext.SetSwitch("Switch.System.Windows.Controls.Text.UseAdornerForTextboxSelectionRendering", false);

        ThemeManager.ChangeTheme(Theme.SystemTheme);
    }
}
