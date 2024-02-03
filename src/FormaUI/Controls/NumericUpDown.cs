using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace FormaUI.Controls;

[TemplatePart(Name = "PART_UpButton", Type = typeof(RepeatButton))]
[TemplatePart(Name = "PART_DownButton", Type = typeof(RepeatButton))]
public abstract class NumericUpDown : TextBox
{
    static NumericUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
    }
}

public abstract class NumericUpDown<T> : NumericUpDown where T : struct, INumber<T>, IMinMaxValue<T>
{
    private const string UpButtonName = "PART_UpButton";
    private const string DownButtonName = "PART_DownButton";

    static NumericUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown<T>), new FrameworkPropertyMetadata(typeof(NumericUpDown<T>)));
    }

    private RepeatButton _upButton;
    private RepeatButton _downButton;

    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            nameof(Value),
            typeof(T?),
            typeof(NumericUpDown<T>),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnValueChanged,
                CoerceValue));

    public T? Value
    {
        get => (T?)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NumericUpDown<T>)d).OnValueChanged((T?)e.NewValue);
    }

    private static object? CoerceValue(DependencyObject d, object baseValue)
    {
        return ((NumericUpDown<T>)d).CoerceValue((T?)baseValue);
    }

    public static readonly DependencyProperty StepProperty =
        DependencyProperty.Register(
            nameof(Step),
            typeof(T),
            typeof(NumericUpDown<T>),
            new FrameworkPropertyMetadata(1,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnStepChanged));

    public T Step
    {
        get => (T)GetValue(StepProperty);
        set => SetValue(StepProperty, Step);
    }

    private static void OnStepChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NumericUpDown<T>)d).OnStepChanged((T)e.NewValue);
    }

    public static readonly DependencyProperty MinProperty =
        DependencyProperty.Register(
            nameof(Min),
            typeof(T?),
            typeof(NumericUpDown<T>),
            new FrameworkPropertyMetadata(T.MinValue,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnMinChanged));

    public T? Min
    {
        get => (T?)GetValue(MinProperty);
        set => SetValue(MinProperty, Min);
    }

    private static void OnMinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NumericUpDown<T>)d).OnMinChanged((T?)e.NewValue);
    }

    public static readonly DependencyProperty MaxProperty =
        DependencyProperty.Register(
            nameof(Max),
            typeof(T?),
            typeof(NumericUpDown<T>),
            new FrameworkPropertyMetadata(T.MaxValue,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnMaxChanged));

    public T? Max
    {
        get => (T?)GetValue(MaxProperty);
        set => SetValue(MaxProperty, Max);
    }

    private static void OnMaxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((NumericUpDown<T>)d).OnMaxChanged((T?)e.NewValue);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _upButton = (RepeatButton)GetTemplateChild(UpButtonName);
        _downButton = (RepeatButton)GetTemplateChild(DownButtonName);

        _upButton.Click += (sender, e) =>
        {
            Value ??= T.Zero;
            Value += Step;
        };

        _downButton.Click += (sender, e) =>
        {
            Value ??= T.Zero;
            Value -= Step;
        };

        UpdateButtonsState();
    }

    protected virtual void OnValueChanged(T? newValue)
    {
        UpdateButtonsState();

        SetCurrentValue(TextProperty, newValue?.ToString());
    }

    protected virtual T? CoerceValue(T? newValue)
    {
        if (newValue is null)
        {
            return null;
        }

        var maxValue = Max ?? T.MaxValue;
        if (newValue > maxValue)
        {
            return maxValue;
        }

        var minValue = Min ?? T.MinValue;
        if (newValue < minValue)
        {
            return minValue;
        }

        return newValue;
    }

    protected virtual void OnStepChanged(T newValue)
    {

    }

    protected virtual void OnMinChanged(T? newValue)
    {
        newValue ??= T.MinValue;
        if (Value < newValue)
        {
            SetCurrentValue(ValueProperty, newValue);
        }

        UpdateButtonsState();
    }

    protected virtual void OnMaxChanged(T? newValue)
    {
        newValue ??= T.MaxValue;
        if (Value > newValue)
        {
            SetCurrentValue(ValueProperty, newValue);
        }

        UpdateButtonsState();
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);

        if (!T.TryParse(Text, null, out T result))
        {
            SetCurrentValue(TextProperty, Value?.ToString());
        }
        else if (result <= (Max ?? T.MaxValue) && result >= (Min ?? T.MinValue))
        {
            SetCurrentValue(ValueProperty, result);
        }
        else
        {
            SetCurrentValue(TextProperty, Value?.ToString());
        }
    }

    private void UpdateButtonsState()
    {
        if (Value is null)
        {
            _upButton?.SetCurrentValue(IsEnabledProperty, true);
            _downButton?.SetCurrentValue(IsEnabledProperty, true);
            return;
        }

        var maxValue = Max ?? T.MaxValue;
        var minValue = Min ?? T.MinValue;

        _upButton?.SetCurrentValue(IsEnabledProperty, Value < maxValue);
        _downButton?.SetCurrentValue(IsEnabledProperty, Value > minValue);
    }
}
