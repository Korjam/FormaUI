using FormaUI.Dialogs;
using System.Windows;

namespace FormaUI.Demo.ControlSample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    const string Text = "This is body text. Windows 11 marks a visual evolution of the operating system.";
    const string Caption = "Title";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowOkDialog(object sender, RoutedEventArgs e) => FluentMessageBox.Show(Text, Caption, MessageBoxButton.OK);
    private void ShowOkCancelDialog(object sender, RoutedEventArgs e) => FluentMessageBox.Show(Text, Caption, MessageBoxButton.OKCancel);
    private void ShowYesNoDialog(object sender, RoutedEventArgs e) => FluentMessageBox.Show(Text, Caption, MessageBoxButton.YesNo);
    private void ShowYesNoCancelDialog(object sender, RoutedEventArgs e) => FluentMessageBox.Show(Text, Caption, MessageBoxButton.YesNoCancel);
}
