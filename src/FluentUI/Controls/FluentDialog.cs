using System.Windows;

namespace FluentUI.Controls;

public class FluentDialog : FluentWindow
{
    static FluentDialog()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentDialog), new FrameworkPropertyMetadata(typeof(FluentDialog)));
    }

    public FluentDialog()
    {
        SetResourceReference(StyleProperty, typeof(FluentDialog));
    }

    public static readonly DependencyProperty CanCloseProperty = DependencyProperty.Register(
        nameof(CanClose),
        typeof(bool),
        typeof(FluentDialog),
        new PropertyMetadata(false));

    public bool CanClose
    {
        get => (bool)GetValue(CanCloseProperty);
        set => SetValue(CanCloseProperty, value);
    }
}
