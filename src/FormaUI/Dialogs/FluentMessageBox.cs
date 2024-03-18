using System.Windows;

namespace FormaUI.Dialogs;

public static class FluentMessageBox
{
    public static MessageBoxResult Show(string messageBoxText) => Show(messageBoxText, string.Empty);
    public static MessageBoxResult Show(string messageBoxText, string caption) => Show(messageBoxText, caption, MessageBoxButton.OK);
    public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button) => Show(messageBoxText, caption, button, MessageBoxImage.None);
    public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon) => Show(messageBoxText, caption, button, icon, MessageBoxResult.None);
    public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult) => Show(messageBoxText, caption, button, icon, defaultResult, MessageBoxOptions.None);
    public static MessageBoxResult Show(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
    {
        var owner = GetCurrentWindow();

        if (owner is not null)
        {
            return Show(owner, messageBoxText, caption, button, icon, defaultResult, options);
        }

        var dialog = new MessageBoxDialog
        {
            Title = caption,
            Message = messageBoxText,
            Button = button,
            //Icon = icon,
            //DefaultResult = defaultResult,
            //Options = options,

            WindowStartupLocation = WindowStartupLocation.CenterScreen,
        };

        dialog.ShowDialog();

        return dialog.Result;
    }

    public static MessageBoxResult Show(Window owner, string messageBoxText) => Show(owner, messageBoxText, string.Empty);
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption) => Show(owner, messageBoxText, caption, MessageBoxButton.OK);
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button) => Show(owner, messageBoxText, caption, button, MessageBoxImage.None);
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon) => Show(owner, messageBoxText, caption, button, icon, MessageBoxResult.None);
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult) => Show(owner, messageBoxText, caption, button, icon, defaultResult, MessageBoxOptions.None);
    public static MessageBoxResult Show(Window owner, string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options)
    {
        var dialog = new MessageBoxDialog
        {
            Title = caption,
            Message = messageBoxText,
            Button = button,

            Owner = owner,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
        };

        dialog.ShowDialog();

        return dialog.Result;
    }

    private static Window? GetCurrentWindow() =>
        Application.Current.Windows.Cast<Window>()
            .Where(x => x.IsVisible)
            .LastOrDefault();
}
