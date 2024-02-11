using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FormaUI.Behaviors;

public static class TextBoxBehaviors
{
    public static readonly DependencyProperty WatermarkProperty =
    DependencyProperty.RegisterAttached(
        "Watermark",
        typeof(string),
        typeof(TextBoxBehaviors),
        new PropertyMetadata(null));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static string? GetWatermark(UIElement element)
    {
        return (string?)element.GetValue(WatermarkProperty);
    }

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static void SetWatermark(UIElement element, string? value)
    {
        element.SetValue(WatermarkProperty, value);
    }


    public static readonly DependencyProperty HasTextProperty =
    DependencyProperty.RegisterAttached(
        "HasText",
        typeof(bool),
        typeof(TextBoxBehaviors),
        new PropertyMetadata(false));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static bool GetHasText(UIElement element)
    {
        return (bool)element.GetValue(HasTextProperty);
    }

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static void SetHasText(UIElement element, bool value)
    {
        element.SetValue(HasTextProperty, value);
    }


    public static readonly DependencyProperty MonitorPropertiesProperty =
    DependencyProperty.RegisterAttached(
        "MonitorProperties",
        typeof(bool),
        typeof(TextBoxBehaviors),
        new PropertyMetadata(false, OnMonitorPropertiesChanged));

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
    public static bool GetMonitorProperties(UIElement element)
    {
        return (bool)element.GetValue(MonitorPropertiesProperty);
    }

    [Category(Constans.WpfCategory)]
    [AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
    [AttachedPropertyBrowsableForType(typeof(PasswordBox))]
    public static void SetMonitorProperties(UIElement element, bool value)
    {
        element.SetValue(MonitorPropertiesProperty, value);
    }

    private static void OnMonitorPropertiesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        switch (d)
        {
            case TextBox textBox:
                if ((bool)e.NewValue)
                {
                    textBox.TextChanged += OnTextChanged;
                }
                else
                {
                    textBox.TextChanged -= OnTextChanged;
                }
                SetHasText(textBox, textBox.Text.Length > 0);
                break;
            case PasswordBox passwordBox:
                if ((bool)e.NewValue)
                {
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                }
                else
                {
                    passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                }
                SetHasText(passwordBox, passwordBox.Password.Length > 0);
                break;
            default:
                break;
        }
    }

    private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var passwordBox = (PasswordBox)sender;

        SetHasText(passwordBox, passwordBox.Password.Length > 0);
    }

    private static void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;

        SetHasText(textBox, textBox.Text.Length > 0);
    }
}
