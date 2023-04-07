using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Controls;

public class SymbolIcon : Control
{
    static SymbolIcon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SymbolIcon), new FrameworkPropertyMetadata(typeof(SymbolIcon)));
    }

    private static readonly DependencyPropertyKey SymbolTextPropertyKey = DependencyProperty.RegisterReadOnly(
        nameof(SymbolText),
        typeof(string),
        typeof(SymbolIcon),
        new PropertyMetadata(string.Empty));
    public static readonly DependencyProperty SymbolTextProperty = SymbolTextPropertyKey.DependencyProperty;

    public string SymbolText
    {
        get => (string)GetValue(SymbolTextProperty);
        private set => SetValue(SymbolTextPropertyKey, value);
    }

    public static readonly DependencyProperty SymbolProperty = DependencyProperty.Register(
        nameof(Symbol),
        typeof(Symbol),
        typeof(SymbolIcon),
        new PropertyMetadata(Symbol.None, OnSymbolChanged));

    public Symbol Symbol
    {
        get => (Symbol)GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }

    private static void OnSymbolChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is SymbolIcon fluentIcon)
        {
            fluentIcon.SymbolText = ((char)fluentIcon.Symbol).ToString();
        }
    }
}
