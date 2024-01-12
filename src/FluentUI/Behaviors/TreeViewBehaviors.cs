using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Behaviors;

public static class TreeViewBehaviors
{
    public static readonly DependencyProperty DepthProperty =
        DependencyProperty.RegisterAttached(
            "Depth",
            typeof(int),
            typeof(TreeViewBehaviors),
            new PropertyMetadata(-1));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
    public static int GetDepth(UIElement element)
    {
        return (int)element.GetValue(DepthProperty);
    }

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
    public static void SetDepth(UIElement element, int value)
    {
        element.SetValue(DepthProperty, value);
    }

    public static readonly DependencyProperty CalculateDepthProperty =
        DependencyProperty.RegisterAttached(
            "CalculateDepth",
            typeof(bool),
            typeof(TreeViewBehaviors),
            new PropertyMetadata(false, OnCalculateDepthChanged));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
    public static bool GetCalculateDepth(UIElement element)
    {
        return (bool)element.GetValue(CalculateDepthProperty);
    }

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TreeViewItem))]
    public static void SetCalculateDepth(UIElement element, bool value)
    {
        element.SetValue(CalculateDepthProperty, value);
    }

    private static void OnCalculateDepthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue == e.NewValue)
        {
            return;
        }

        if (dependencyObject is not TreeViewItem treeViewItem)
        {
            return;
        }

        treeViewItem.AddOrRemoveBehavior<TreeViewItemDepthBehavior>((bool)e.NewValue);
    }
}
