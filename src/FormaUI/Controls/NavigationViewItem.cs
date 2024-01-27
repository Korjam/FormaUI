using System.Windows;

namespace FormaUI.Controls;

public class NavigationViewItem : NavigationViewItemBase
{
    static NavigationViewItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationViewItem), new FrameworkPropertyMetadata(typeof(NavigationViewItem)));
    }

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon),
        typeof(Symbol),
        typeof(NavigationViewItem),
        new PropertyMetadata(Symbol.None));

    public Symbol Icon
    {
        get => (Symbol)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public static readonly DependencyProperty NavigationTypeProperty = DependencyProperty.Register(
        nameof(NavigationType),
        typeof(Type),
        typeof(NavigationViewItem),
        new PropertyMetadata(null));

    public Type? NavigationType
    {
        get => (Type?)GetValue(NavigationTypeProperty);
        set => SetValue(NavigationTypeProperty, value);
    }
}
