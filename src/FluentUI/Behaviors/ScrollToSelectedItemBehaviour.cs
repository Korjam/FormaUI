using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FluentUI.Behaviors;

public sealed class ScrollToSelectedItemBehaviour : Behavior<Selector>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.SelectionChanged += AssociatedObjectOnSelectionChanged;
        AssociatedObject.SizeChanged += AssociatedObjectOnSizeChanged;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.SelectionChanged -= AssociatedObjectOnSelectionChanged;
        AssociatedObject.SizeChanged -= AssociatedObjectOnSizeChanged;
        base.OnDetaching();
    }

    private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ScrollIntoFirstSelectedItem();
    }

    private void AssociatedObjectOnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        ScrollIntoFirstSelectedItem();
    }

    private void ScrollIntoFirstSelectedItem()
    {
        if (AssociatedObject.SelectedItem is null)
        {
            return;
        }

        var container = AssociatedObject.ItemContainerGenerator.ContainerFromItem(AssociatedObject.SelectedItem);
        if (container is FrameworkElement fe)
        {
            fe.BringIntoView();
        }
    }
}
