using System.Windows.Media;
using System.Windows;

namespace FluentUI;

internal static class TreeHelper
{
    public static T? FindChild<T>(this DependencyObject dependencyObject) where T : DependencyObject
    {
        int count = VisualTreeHelper.GetChildrenCount(dependencyObject);

        for (int i = 0; i < count; i++)
        {
            var child = VisualTreeHelper.GetChild(dependencyObject, i);

            if (child is T match)
            {
                return match;
            }

            var result = FindChild<T>(child);

            if (result is not null)
            {
                return result;
            }
        }

        return null;
    }

    public static IEnumerable<T> FindChildren<T>(this DependencyObject dependencyObject) where T : DependencyObject
    {
        int count = VisualTreeHelper.GetChildrenCount(dependencyObject);

        for (int i = 0; i < count; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);

            if (child is T match)
            {
                yield return match;
            }

            foreach (T childOfChild in FindChildren<T>(child))
            {
                yield return childOfChild;
            }
        }
    }

    public static T? FindParent<T>(this DependencyObject dependencyObject) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(dependencyObject);

        return parent switch
        {
            null => null,
            T match => match,
            _ => parent.FindParent<T>()
        };
    }
}
