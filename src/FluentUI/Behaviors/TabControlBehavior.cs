using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Behaviors;

public static class TabControlBehavior
{
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.RegisterAttached(
            "Icon",
            typeof(object),
            typeof(TabControlBehavior),
            new PropertyMetadata(null));

    [Category("FluentUI")]
    [AttachedPropertyBrowsableForType(typeof(TabItem))]
    public static object? GetIcon(UIElement element) =>
        (object?)element.GetValue(IconProperty);

    [Category("FluentUI")]
    [AttachedPropertyBrowsableForType(typeof(TabItem))]
    public static void SetIcon(UIElement element, object? value) =>
        element.SetValue(IconProperty, value);
}
