using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

    public static readonly DependencyProperty CanCloseProperty =
        DependencyProperty.RegisterAttached(
            "CanClose",
            typeof(bool),
            typeof(TabControlBehavior),
            new PropertyMetadata(false));

    [Category("FluentUI")]
    [AttachedPropertyBrowsableForType(typeof(TabItem))]
    [AttachedPropertyBrowsableForType(typeof(TabControl))]
    public static bool GetCanClose(UIElement element) =>
        (bool)element.GetValue(CanCloseProperty);

    [Category("FluentUI")]
    [AttachedPropertyBrowsableForType(typeof(TabItem))]
    [AttachedPropertyBrowsableForType(typeof(TabControl))]
    public static void SetCanClose(UIElement element, bool value) =>
        element.SetValue(CanCloseProperty, value);

    public static readonly RoutedCommand CloseCommand = new("Close", typeof(TabControlBehavior));

    static TabControlBehavior()
    {
        CommandManager.RegisterClassCommandBinding(
            typeof(TabItem),
            new(CloseCommand, OnCloseCommand, CanCloseCommand));
    }

    private static void OnCloseCommand(object sender, ExecutedRoutedEventArgs e)
    {
        var tabItem = (TabItem)sender;
        var tabControl = tabItem.FindParent<TabControl>();
        if (tabControl != null)
        {
            if (tabControl.ItemsSource is null)
            {
                tabControl.Items.Remove(tabItem);
            }
            else if (tabControl.ItemsSource is IList list)
            {
                list.Remove(tabItem.DataContext);
            }
        }
    }

    private static void CanCloseCommand(object sender, CanExecuteRoutedEventArgs e)
    {
        var tabItem = (TabItem)sender;
        var tabControl = tabItem.FindParent<TabControl>();
        if (tabControl != null)
        {
            if (tabControl.ItemsSource is null)
            {
                e.CanExecute = GetCanClose(tabItem)
                    && GetCanClose(tabControl);
            }
            else if (tabControl.ItemsSource is IList list)
            {
                e.CanExecute = !list.IsReadOnly
                    && GetCanClose(tabItem)
                    && GetCanClose(tabControl);
            }
        }
    }
}
