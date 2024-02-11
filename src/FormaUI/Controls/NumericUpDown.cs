#if NET7_0_OR_GREATER
using System.Numerics;
#endif
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

#if NET7_0_OR_GREATER
public abstract class NumericUpDown<T> : NumericUpDown where T : struct, INumber<T>, IMinMaxValue<T>
#else
public abstract class NumericUpDown<T> : NumericUpDown where T : struct
#endif
{
    private const string UpButtonName = "PART_UpButton";
    private const string DownButtonName = "PART_DownButton";

    static NumericUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown<T>), new FrameworkPropertyMetadata(typeof(NumericUpDown<T>)));
    }

    private RepeatButton? _upButton;
    private RepeatButton? _downButton;
    private bool _blockReentrantCalls = false;

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

    private static object? CoerceValue(DependencyObject d, object? baseValue)
    {
        return ((NumericUpDown<T>)d).CoerceValue((T?)baseValue);
    }

    public static readonly DependencyProperty StepProperty =
        DependencyProperty.Register(
            nameof(Step),
            typeof(T),
            typeof(NumericUpDown<T>),
#pragma warning disable WPF0010 // Default value type must match registered type
            new FrameworkPropertyMetadata(1,
#pragma warning restore WPF0010 // Default value type must match registered type
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
#if NET7_0_OR_GREATER
            new FrameworkPropertyMetadata(T.MinValue,
#else
            new FrameworkPropertyMetadata(null,
#endif
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
#if NET7_0_OR_GREATER
            new FrameworkPropertyMetadata(T.MaxValue,
#else
            new FrameworkPropertyMetadata(null,
#endif
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
#if NET7_0_OR_GREATER
            SetCurrentValue(ValueProperty, (Value ?? T.Zero) + Step);
#else
            Increment(Step);
#endif
        };

        _downButton.Click += (sender, e) =>
        {
#if NET7_0_OR_GREATER
            SetCurrentValue(ValueProperty, (Value ?? T.Zero) - Step);
#else
            Decrement(Step);
#endif
        };

        UpdateButtonsState();
    }

    protected virtual void OnValueChanged(T? newValue)
    {
        UpdateButtonsState();

        if (_blockReentrantCalls)
        {
            return;
        }

        _blockReentrantCalls = true;

        SetCurrentValue(TextProperty, newValue?.ToString());

        _blockReentrantCalls = false;
    }

    protected virtual T? CoerceValue(T? newValue)
    {
        if (newValue is null)
        {
            return null;
        }

#if NET7_0_OR_GREATER
        var maxValue = Max ?? T.MaxValue;
        if (newValue > maxValue)
#else
        var maxValue = Max ?? MaxValue;
        if (IsGreaterThan(newValue.Value, maxValue))
#endif
        {
            return maxValue;
        }

#if NET7_0_OR_GREATER
        var minValue = Min ?? T.MinValue;
        if (newValue < minValue)
#else
        var minValue = Min ?? MinValue;
        if (IsLessThan(newValue.Value, minValue))
#endif
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
#if NET7_0_OR_GREATER
        newValue ??= T.MinValue;
        if (Value < newValue)
#else
        newValue ??= MinValue;
        if (IsLessThan(Value ?? Zero, newValue.Value))
#endif
        {
            SetCurrentValue(ValueProperty, newValue);
        }

        UpdateButtonsState();
    }

    protected virtual void OnMaxChanged(T? newValue)
    {
#if NET7_0_OR_GREATER
        newValue ??= T.MaxValue;
        if (Value > newValue)
#else
        newValue ??= MaxValue;
        if (IsGreaterThan(Value ?? Zero, newValue.Value))
#endif
        {
            SetCurrentValue(ValueProperty, newValue);
        }

        UpdateButtonsState();
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);

        if (_blockReentrantCalls)
        {
            return;
        }

        _blockReentrantCalls = true;

        if (string.IsNullOrEmpty(Text))
        {
            SetCurrentValue(ValueProperty, null);
        }
#if NET7_0_OR_GREATER
        else if (!T.TryParse(Text, null, out T result))
#else
        else if (!TryParse(Text, out T result))
#endif
        {
            if (Text.Trim() == "-")
            {
                SetCurrentValue(ValueProperty, null);
            }
            else
            {
                SetCurrentValue(TextProperty, Value?.ToString());
            }
        }
#if NET7_0_OR_GREATER
        else if (result <= (Max ?? T.MaxValue) && result >= (Min ?? T.MinValue))
#else
        else if (IsLessThanOrEquals(result, Max ?? MaxValue) && IsGreaterThanOrEquals(result, (Min ?? MinValue)))
#endif
        {
            SetCurrentValue(ValueProperty, result);
        }
        else
        {
            SetCurrentValue(TextProperty, Value?.ToString());
        }

        _blockReentrantCalls = false;
    }

    private void UpdateButtonsState()
    {
        if (Value is null)
        {
            _upButton?.SetCurrentValue(IsEnabledProperty, true);
            _downButton?.SetCurrentValue(IsEnabledProperty, true);
            return;
        }

#if NET7_0_OR_GREATER
        var maxValue = Max ?? T.MaxValue;
        var minValue = Min ?? T.MinValue;

        _upButton?.SetCurrentValue(IsEnabledProperty, Value < maxValue);
        _downButton?.SetCurrentValue(IsEnabledProperty, Value > minValue);
#else
        var maxValue = Max ?? MaxValue;
        var minValue = Min ?? MinValue;

        _upButton?.SetCurrentValue(IsEnabledProperty, IsLessThan(Value.Value, maxValue));
        _downButton?.SetCurrentValue(IsEnabledProperty, IsGreaterThan(Value.Value, minValue));
#endif
    }

#if !NET7_0_OR_GREATER
    protected abstract T Zero { get; }
    protected abstract T MaxValue { get; }
    protected abstract T MinValue { get; }
    protected abstract bool TryParse(string? s, out T result);
    protected abstract bool IsLessThan(T left, T right);
    protected abstract bool IsLessThanOrEquals(T left, T right);
    protected abstract bool IsGreaterThan(T left, T right);
    protected abstract bool IsGreaterThanOrEquals(T left, T right);
    protected abstract void Increment(T step);
    protected abstract void Decrement(T step);
#endif
}
