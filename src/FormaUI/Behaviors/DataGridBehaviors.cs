using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FormaUI.Behaviors;

public class DataGridBehaviors
{
    public static readonly DependencyProperty ApplyFuentStylesProperty =
        DependencyProperty.RegisterAttached(
            "ApplyFuentStyles",
            typeof(bool),
            typeof(DataGridBehaviors),
            new PropertyMetadata(false, OnApplyFuentStylesChanged));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(DataGrid))]
    public static bool GetApplyFuentStyles(UIElement element)
    {
        return (bool)element.GetValue(ApplyFuentStylesProperty);
    }

    [Category(Constans.WpfCategory)]
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

        dataGrid.AddOrRemoveBehavior<DataGridFluentStylesBehavior>((bool)e.NewValue);
    }
}
