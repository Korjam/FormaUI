using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace FluentUI.Controls;

[TemplatePart(Name = "PART_BottomContent", Type = typeof(ContentControl))]
public class FluentDialog : FluentWindow
{
    static FluentDialog()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FluentDialog), new FrameworkPropertyMetadata(typeof(FluentDialog)));
    }

    public FluentDialog()
    {
        SetResourceReference(StyleProperty, typeof(FluentDialog));
    }

    public static readonly DependencyProperty CanCloseProperty = DependencyProperty.Register(
        nameof(CanClose),
        typeof(bool),
        typeof(FluentDialog),
        new PropertyMetadata(false));

    public bool CanClose
    {
        get => (bool)GetValue(CanCloseProperty);
        set => SetValue(CanCloseProperty, value);
    }

    public static readonly DependencyProperty BottomContentProperty =
        DependencyProperty.Register(
            nameof(BottomContent),
            typeof(object),
            typeof(FluentDialog),
            new FrameworkPropertyMetadata(null, OnBottomContentChanged));

    [Bindable(true), Category("Content")]
    public object? BottomContent
    {
        get => GetValue(BottomContentProperty);
        set => SetValue(BottomContentProperty, value);
    }

    private static void OnBottomContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var ctrl = (FluentDialog)d;
        ctrl.SetValue(HasBottomContentPropertyKey, e.NewValue != null);
    }

    private static readonly DependencyPropertyKey HasBottomContentPropertyKey =
        DependencyProperty.RegisterReadOnly(
            nameof(HasBottomContent),
            typeof(bool),
            typeof(FluentDialog),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.None));

    public static readonly DependencyProperty HasBottomContentProperty =
            HasBottomContentPropertyKey.DependencyProperty;

    [Browsable(false), ReadOnly(true)]
    public bool HasBottomContent => (bool)GetValue(HasBottomContentProperty);
}
