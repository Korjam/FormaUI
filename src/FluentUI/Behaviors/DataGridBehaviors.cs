using Microsoft.Xaml.Behaviors;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Behaviors;

public class DataGridBehaviors
{
    public static readonly DependencyProperty ApplyFuentStylesProperty =
        DependencyProperty.RegisterAttached(
            "ApplyFuentStyles",
            typeof(bool),
            typeof(DataGridBehaviors),
            new PropertyMetadata(false, OnApplyFuentStylesChanged));

    [Category("FluentUI")]
    [AttachedPropertyBrowsableForType(typeof(DataGrid))]
    public static bool GetApplyFuentStyles(UIElement element)
    {
        return (bool)element.GetValue(ApplyFuentStylesProperty);
    }

    [Category("FluentUI")]
    [AttachedPropertyBrowsableForType(typeof(DataGrid))]
    public static void SetApplyFuentStyles(UIElement element, bool value)
    {
        element.SetValue(ApplyFuentStylesProperty, value);
    }

    private static void OnApplyFuentStylesChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue == e.NewValue)
        {
            return;
        }

        if (dependencyObject is not DataGrid dataGrid)
        {
            return;
        }

        OnApplyFuentStylesChanged(dataGrid, (bool)e.NewValue);
    }

    private static void OnApplyFuentStylesChanged(DataGrid dataGrid, bool newValue)
    {
        if (newValue)
        {
            Interaction.GetBehaviors(dataGrid).Add(new DataGridFluentStylesBehavior());
        }
        else
        {
            var behaviors = Interaction.GetBehaviors(dataGrid);
            behaviors.Remove(behaviors.OfType<DataGridFluentStylesBehavior>().First());
        }
    }
}
