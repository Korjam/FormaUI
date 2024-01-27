using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace FormaUI.Behaviors;

internal static class Extensions
{
    public static void AddOrRemoveBehavior<T>(this DependencyObject obj, bool newValue)
        where T : Behavior, new()
    {
        var behaviors = Interaction.GetBehaviors(obj);

        if (newValue)
        {
            behaviors.Add(new T());
        }
        else
        {
            var behavior = behaviors.OfType<T>().FirstOrDefault();
            if (behavior != null)
            {
                behaviors.Remove(behavior);
            }
        }
    }
}
