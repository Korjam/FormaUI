using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Behaviors;

public class PasswordBoxTextBehavior : Behavior<PasswordBox>
{
    protected override void OnAttached()
    {
        base.OnAttached();

        PasswordBoxBehaviors.SetPassword(AssociatedObject, AssociatedObject.Password);
        AssociatedObject.PasswordChanged += OnPasswordChanged;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        AssociatedObject.PasswordChanged -= OnPasswordChanged;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBoxBehaviors.SetPassword(AssociatedObject, AssociatedObject.Password);
    }
}