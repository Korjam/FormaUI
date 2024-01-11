using Microsoft.Xaml.Behaviors;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace FluentUI.Behaviors;

public static class SelectorBehaviors
{
    public static readonly DependencyProperty ScrollIntoSelectedItemProperty =
        DependencyProperty.RegisterAttached(
            "ScrollIntoSelectedItem",
            typeof(bool),
            typeof(SelectorBehaviors),
            new PropertyMetadata(false, OnScrollIntoSelectedItemChanged));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(Selector))]
    public static bool GetScrollIntoSelectedItem(UIElement element)
    {
        return (bool)element.GetValue(ScrollIntoSelectedItemProperty);
    }

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(Selector))]
    public static void SetScrollIntoSelectedItem(UIElement element, bool value)
    {
        element.SetValue(ScrollIntoSelectedItemProperty, value);
    }

    private static void OnScrollIntoSelectedItemChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue == e.NewValue)
        {
            return;
        }

        if (dependencyObject is not Selector selector)
        {
            return;
        }

        OnScrollIntoSelectedItemChanged(selector, (bool)e.NewValue);
    }

    private static void OnScrollIntoSelectedItemChanged(Selector selector, bool newValue)
    {
        if (newValue)
        {
            Interaction.GetBehaviors(selector).Add(new ScrollToSelectedItemBehaviour());
        }
        else
        {
            var behaviors = Interaction.GetBehaviors(selector);
            behaviors.Remove(behaviors.OfType<ScrollToSelectedItemBehaviour>().First());
        }
    }
}
