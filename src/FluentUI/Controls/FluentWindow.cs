using System.Windows;
using System.Windows.Input;

namespace FluentUI.Controls;

public class FluentWindow : Window
{
    static FluentWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentWindow), new FrameworkPropertyMetadata(typeof(FluentWindow)));
    }

    public FluentWindow()
    {
        SetResourceReference(StyleProperty, typeof(FluentWindow));

        CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
        CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
        CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
        CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));
    }

    private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e) =>
        e.CanExecute = ResizeMode != ResizeMode.NoResize;

    private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e) =>
        e.CanExecute = ResizeMode == ResizeMode.CanResize
            || ResizeMode == ResizeMode.CanResizeWithGrip;

    private void OnCloseWindow(object sender, ExecutedRoutedEventArgs e) =>
        SystemCommands.CloseWindow(this);

    private void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e) =>
        SystemCommands.MaximizeWindow(this);

    private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e) =>
        SystemCommands.MinimizeWindow(this);

    private void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e) =>
        SystemCommands.RestoreWindow(this);
}
