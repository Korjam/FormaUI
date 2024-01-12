using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Behaviors;

public static class PasswordBoxBehaviors
{
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.RegisterAttached(
            "Password",
            typeof(string),
            typeof(PasswordBoxBehaviors),
            new PropertyMetadata(string.Empty));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static string GetPassword(UIElement element)
    {
        return (string)element.GetValue(PasswordProperty);
    }

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static void SetPassword(UIElement element, string value)
    {
        element.SetValue(PasswordProperty, value);
    }

    public static readonly DependencyProperty ShowPasswordProperty =
        DependencyProperty.RegisterAttached(
            "ShowPassword",
            typeof(bool),
            typeof(PasswordBoxBehaviors),
            new PropertyMetadata(false, OnShowPasswordChanged));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static bool GetShowPassword(UIElement element)
    {
        return (bool)element.GetValue(ShowPasswordProperty);
    }

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static void SetShowPassword(UIElement element, bool value)
    {
        element.SetValue(ShowPasswordProperty, value);
    }

    private static void OnShowPasswordChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        if (e.OldValue == e.NewValue)
        {
            return;
        }

        if (dependencyObject is not PasswordBox passwordBox)
        {
            return;
        }

        passwordBox.AddOrRemoveBehavior<PasswordBoxTextBehavior>((bool)e.NewValue);
    }
}
