using System.Windows;

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
    }
}
