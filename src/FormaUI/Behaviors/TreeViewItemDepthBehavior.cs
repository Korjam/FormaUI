using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FormaUI.Behaviors;

public class TreeViewItemDepthBehavior : Behavior<TreeViewItem>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.Loaded += AssociatedObject_Loaded;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.Loaded -= AssociatedObject_Loaded;
    }

    private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
    {
        CalculateDepth();
    }

    private void CalculateDepth()
    {
        DependencyObject parent = AssociatedObject;
        int depth = 0;

        do
        {
            parent = VisualTreeHelper.GetParent(parent);

            if (parent is TreeViewItem treeViewItem)
            {
                var value = TreeViewBehaviors.GetDepth(treeViewItem);
                if (value >= 0)
                {
                    depth = value + 1;
                    break;
                }
                else
                {
                    depth++;
                }
            }
            else if (parent is TreeView)
            {
                break;
            }
        } while (parent != null);

        TreeViewBehaviors.SetDepth(AssociatedObject, depth);
    }
}
