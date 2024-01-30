using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FormaUI.Controls;

[TemplatePart(Name = "PART_UpButton", Type = typeof(RepeatButton))]
[TemplatePart(Name = "PART_DownButton", Type = typeof(RepeatButton))]
public class NumericUpDown : TextBox
{
    private const string UpButtonName = "PART_UpButton";
    private const string DownButtonName = "PART_DownButton";

    static NumericUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
    }

    private RepeatButton _upButton;
    private RepeatButton _downButton;

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            nameof(Value),
            typeof(int?),
            typeof(NumericUpDown),
            new FrameworkPropertyMetadata(0, OnValueChanged, CoerceValue));

    public int? Value
    {
        get => (int?)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NumericUpDown)d).OnValueChanged((int?)e.NewValue);
    }

    private static object? CoerceValue(DependencyObject d, object baseValue)
    {
        return ((NumericUpDown)d).CoerceValue((int?)baseValue);
    }

    public static readonly DependencyProperty StepProperty =
        DependencyProperty.Register(
            nameof(Step),
            typeof(int),
            typeof(NumericUpDown),
            new FrameworkPropertyMetadata(1, OnStepChanged));

    public int Step
    {
        get => (int)GetValue(StepProperty);
        set => SetValue(StepProperty, Step);
    }

    private static void OnStepChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NumericUpDown)d).OnStepChanged((int)e.NewValue);
    }

    public static readonly DependencyProperty MinProperty =
        DependencyProperty.Register(
            nameof(Min),
            typeof(int),
            typeof(NumericUpDown),
            new FrameworkPropertyMetadata(int.MinValue, OnMinChanged));

    public int Min
    {
        get => (int)GetValue(MinProperty);
        set => SetValue(MinProperty, Min);
    }

    private static void OnMinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NumericUpDown)d).OnMinChanged((int)e.NewValue);
    }

    public static readonly DependencyProperty MaxProperty =
        DependencyProperty.Register(
            nameof(Max),
            typeof(int),
            typeof(NumericUpDown),
            new FrameworkPropertyMetadata(int.MaxValue, OnMaxChanged));

    public int Max
    {
        get => (int)GetValue(MaxProperty);
        set => SetValue(MaxProperty, Max);
    }

    private static void OnMaxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NumericUpDown)d).OnMaxChanged((int)e.NewValue);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _upButton = (RepeatButton)GetTemplateChild(UpButtonName);
        _downButton = (RepeatButton)GetTemplateChild(DownButtonName);

        _upButton.Click += (sender, e) =>
        {
            Value += Step;
        };

        _downButton.Click += (sender, e) =>
        {
            Value -= Step;
        };
    }

    protected virtual void OnValueChanged(int? newValue)
    {
        if (newValue is null)
        {
            return;
        }

        _upButton.SetCurrentValue(IsEnabledProperty, newValue < Max);
        _downButton.SetCurrentValue(IsEnabledProperty, newValue > Min);

        SetCurrentValue(TextProperty, newValue.ToString());
    }

    protected virtual int? CoerceValue(int? newValue)
    {
        if (newValue is null)
        {
            return null;
        }
        if (newValue > Max)
        {
            return Max;
        }
        if (newValue < Min)
        {
            return Min;
        }
        return newValue;
    }

    protected virtual void OnStepChanged(int newValue)
    {

    }

    protected virtual void OnMinChanged(int newValue)
    {
        if (Value < newValue)
        {
            SetCurrentValue(ValueProperty, newValue);
        }
    }

    protected virtual void OnMaxChanged(int newValue)
    {
        if (Value > newValue)
        {
            SetCurrentValue(ValueProperty, newValue);
        }
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);

        if (!int.TryParse(Text, out int result))
        {
            SetCurrentValue(TextProperty, Value?.ToString());
        }
        else
        {
            SetCurrentValue(ValueProperty, result);
        }
    }
}
