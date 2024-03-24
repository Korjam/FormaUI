using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;

namespace FormaUI.Controls;

public class FluentWindow : Window
{
    static FluentWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentWindow), new FrameworkPropertyMetadata(typeof(FluentWindow)));
    }

    public static readonly DependencyProperty BackCommandProperty =
        DependencyProperty.Register(
            nameof(BackCommand),
            typeof(ICommand),
            typeof(FluentWindow),
            new FrameworkPropertyMetadata(null));

    public ICommand? BackCommand
    {
        get => (ICommand?)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }

    public static readonly DependencyProperty BackCommandParameterProperty =
        DependencyProperty.Register(
            nameof(BackCommandParameter),
            typeof(object),
            typeof(FluentWindow),
            new FrameworkPropertyMetadata(null));

    public object? BackCommandParameter
    {
        get => GetValue(BackCommandParameterProperty);
        set => SetValue(BackCommandParameterProperty, value);
    }

    public static readonly DependencyProperty CaptionHeightProperty =
        DependencyProperty.Register(
            nameof(CaptionHeight),
            typeof(int),
            typeof(FluentWindow),
            new FrameworkPropertyMetadata(32, OnCaptionHeightChanged));

    private static void OnCaptionHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((FluentWindow)d).OnCaptionHeightChanged((int)e.NewValue);
    }

    public int CaptionHeight
    {
        get => (int)GetValue(CaptionHeightProperty);
        set => SetValue(CaptionHeightProperty, value);
    }

    public static readonly DependencyProperty CaptionControlProperty =
        DependencyProperty.Register(
            nameof(CaptionControl),
            typeof(object),
            typeof(FluentWindow),
            new FrameworkPropertyMetadata(null));

    public object? CaptionControl
    {
        get => (object?)GetValue(CaptionControlProperty);
        set => SetValue(CaptionControlProperty, value);
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

    private void OnCaptionHeightChanged(int newValue)
    {
        var chrome = WindowChrome.GetWindowChrome(this);
        if (chrome is not null)
        {
            WindowChrome.SetWindowChrome(this, new WindowChrome
            {
                CaptionHeight = newValue,
                CornerRadius = chrome.CornerRadius,
                GlassFrameThickness = chrome.GlassFrameThickness,
                NonClientFrameEdges = chrome.NonClientFrameEdges,
                ResizeBorderThickness = chrome.ResizeBorderThickness,
                UseAeroCaptionButtons = chrome.UseAeroCaptionButtons,
            });
        }
    }
}
