using System.Windows;
using System.Windows.Controls;

namespace FormaUI.Controls;

public class NavigationViewItemBase : ContentControl
{
    static NavigationViewItemBase()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationViewItemBase), new FrameworkPropertyMetadata(typeof(NavigationViewItemBase)));
    }
}
