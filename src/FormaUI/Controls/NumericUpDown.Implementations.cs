using System.Windows;

namespace FormaUI.Controls;

public class IntegerUpDown : NumericUpDown<int>
{
    static IntegerUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(IntegerUpDown), new FrameworkPropertyMetadata(typeof(IntegerUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override int Zero => 0;
    protected override int MaxValue => int.MaxValue;
    protected override int MinValue => int.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(int step) => SetCurrentValue(ValueProperty, (Value ?? Zero) - step);
    protected override void Increment(int step) => SetCurrentValue(ValueProperty, (Value ?? Zero) + step);
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(int left, int right) => left > right;
    protected override bool IsGreaterThanOrEquals(int left, int right) => left >= right;
    protected override bool IsLessThan(int left, int right) => left < right;
    protected override bool IsLessThanOrEquals(int left, int right) => left <= right;

    protected override bool TryParse(string? s, out int result) => int.TryParse(s, out result);
#endif
}

public class DoubleUpDown : NumericUpDown<double>
{
    static DoubleUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleUpDown), new FrameworkPropertyMetadata(typeof(DoubleUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override double Zero => 0;
    protected override double MaxValue => double.MaxValue;
    protected override double MinValue => double.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(double step) => SetCurrentValue(ValueProperty, (Value ?? Zero) - step);
    protected override void Increment(double step) => SetCurrentValue(ValueProperty, (Value ?? Zero) + step);
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(double left, double right) => left > right;
    protected override bool IsGreaterThanOrEquals(double left, double right) => left >= right;
    protected override bool IsLessThan(double left, double right) => left < right;
    protected override bool IsLessThanOrEquals(double left, double right) => left <= right;

    protected override bool TryParse(string? s, out double result) => double.TryParse(s, out result);
#endif
}

public class FloatUpDown : NumericUpDown<float>
{
    static FloatUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatUpDown), new FrameworkPropertyMetadata(typeof(FloatUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override float Zero => 0;
    protected override float MaxValue => float.MaxValue;
    protected override float MinValue => float.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(float step) => SetCurrentValue(ValueProperty, (Value ?? Zero) - step);
    protected override void Increment(float step) => SetCurrentValue(ValueProperty, (Value ?? Zero) + step);
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(float left, float right) => left > right;
    protected override bool IsGreaterThanOrEquals(float left, float right) => left >= right;
    protected override bool IsLessThan(float left, float right) => left < right;
    protected override bool IsLessThanOrEquals(float left, float right) => left <= right;

    protected override bool TryParse(string? s, out float result) => float.TryParse(s, out result);
#endif
}

public class DecimalUpDown : NumericUpDown<decimal>
{
    static DecimalUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DecimalUpDown), new FrameworkPropertyMetadata(typeof(DecimalUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override decimal Zero => 0;
    protected override decimal MaxValue => decimal.MaxValue;
    protected override decimal MinValue => decimal.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(decimal step) => SetCurrentValue(ValueProperty, (Value ?? Zero) - step);
    protected override void Increment(decimal step) => SetCurrentValue(ValueProperty, (Value ?? Zero) + step);
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(decimal left, decimal right) => left > right;
    protected override bool IsGreaterThanOrEquals(decimal left, decimal right) => left >= right;
    protected override bool IsLessThan(decimal left, decimal right) => left < right;
    protected override bool IsLessThanOrEquals(decimal left, decimal right) => left <= right;

    protected override bool TryParse(string? s, out decimal result) => decimal.TryParse(s, out result);
#endif
}

public class LongUpDown : NumericUpDown<long>
{
    static LongUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(LongUpDown), new FrameworkPropertyMetadata(typeof(LongUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override long Zero => 0;
    protected override long MaxValue => long.MaxValue;
    protected override long MinValue => long.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(long step) => SetCurrentValue(ValueProperty, (Value ?? Zero) - step);
    protected override void Increment(long step) => SetCurrentValue(ValueProperty, (Value ?? Zero) + step);
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(long left, long right) => left > right;
    protected override bool IsGreaterThanOrEquals(long left, long right) => left >= right;
    protected override bool IsLessThan(long left, long right) => left < right;
    protected override bool IsLessThanOrEquals(long left, long right) => left <= right;

    protected override bool TryParse(string? s, out long result) => long.TryParse(s, out result);
#endif
}

public class ShortUpDown : NumericUpDown<short>
{
    static ShortUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ShortUpDown), new FrameworkPropertyMetadata(typeof(ShortUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override short Zero => 0;
    protected override short MaxValue => short.MaxValue;
    protected override short MinValue => short.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(short step) => SetCurrentValue(ValueProperty, (short)((Value ?? Zero) - step));
    protected override void Increment(short step) => SetCurrentValue(ValueProperty, (short)((Value ?? Zero) + step));
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(short left, short right) => left > right;
    protected override bool IsGreaterThanOrEquals(short left, short right) => left >= right;
    protected override bool IsLessThan(short left, short right) => left < right;
    protected override bool IsLessThanOrEquals(short left, short right) => left <= right;

    protected override bool TryParse(string? s, out short result) => short.TryParse(s, out result);
#endif
}

public class ByteUpDown : NumericUpDown<byte>
{
    static ByteUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ByteUpDown), new FrameworkPropertyMetadata(typeof(ByteUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override byte Zero => 0;
    protected override byte MaxValue => byte.MaxValue;
    protected override byte MinValue => byte.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(byte step) => SetCurrentValue(ValueProperty, (byte)((Value ?? Zero) - step));
    protected override void Increment(byte step) => SetCurrentValue(ValueProperty, (byte)((Value ?? Zero) + step));
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(byte left, byte right) => left > right;
    protected override bool IsGreaterThanOrEquals(byte left, byte right) => left >= right;
    protected override bool IsLessThan(byte left, byte right) => left < right;
    protected override bool IsLessThanOrEquals(byte left, byte right) => left <= right;

    protected override bool TryParse(string? s, out byte result) => byte.TryParse(s, out result);
#endif
}

public class SByteUpDown : NumericUpDown<sbyte>
{
    static SByteUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SByteUpDown), new FrameworkPropertyMetadata(typeof(SByteUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override sbyte Zero => 0;
    protected override sbyte MaxValue => sbyte.MaxValue;
    protected override sbyte MinValue => sbyte.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(sbyte step) => SetCurrentValue(ValueProperty, (sbyte)((Value ?? Zero) - step));
    protected override void Increment(sbyte step) => SetCurrentValue(ValueProperty, (sbyte)((Value ?? Zero) + step));
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(sbyte left, sbyte right) => left > right;
    protected override bool IsGreaterThanOrEquals(sbyte left, sbyte right) => left >= right;
    protected override bool IsLessThan(sbyte left, sbyte right) => left < right;
    protected override bool IsLessThanOrEquals(sbyte left, sbyte right) => left <= right;

    protected override bool TryParse(string? s, out sbyte result) => sbyte.TryParse(s, out result);
#endif
}

public class UShortUpDown : NumericUpDown<ushort>
{
    static UShortUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UShortUpDown), new FrameworkPropertyMetadata(typeof(UShortUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override ushort Zero => 0;
    protected override ushort MaxValue => ushort.MaxValue;
    protected override ushort MinValue => ushort.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(ushort step) => SetCurrentValue(ValueProperty, (ushort)((Value ?? Zero) - step));
    protected override void Increment(ushort step) => SetCurrentValue(ValueProperty, (ushort)((Value ?? Zero) + step));
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(ushort left, ushort right) => left > right;
    protected override bool IsGreaterThanOrEquals(ushort left, ushort right) => left >= right;
    protected override bool IsLessThan(ushort left, ushort right) => left < right;
    protected override bool IsLessThanOrEquals(ushort left, ushort right) => left <= right;

    protected override bool TryParse(string? s, out ushort result) => ushort.TryParse(s, out result);
#endif
}

public class UIntUpDown : NumericUpDown<uint>
{
    static UIntUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UIntUpDown), new FrameworkPropertyMetadata(typeof(UIntUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override uint Zero => 0;
    protected override uint MaxValue => uint.MaxValue;
    protected override uint MinValue => uint.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(uint step) => SetCurrentValue(ValueProperty, (Value ?? Zero) - step);
    protected override void Increment(uint step) => SetCurrentValue(ValueProperty, (Value ?? Zero) + step);
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(uint left, uint right) => left > right;
    protected override bool IsGreaterThanOrEquals(uint left, uint right) => left >= right;
    protected override bool IsLessThan(uint left, uint right) => left < right;
    protected override bool IsLessThanOrEquals(uint left, uint right) => left <= right;

    protected override bool TryParse(string? s, out uint result) => uint.TryParse(s, out result);
#endif
}

public class ULongUpDown : NumericUpDown<ulong>
{
    static ULongUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ULongUpDown), new FrameworkPropertyMetadata(typeof(ULongUpDown)));
    }

#if !NET7_0_OR_GREATER
    protected override ulong Zero => 0;
    protected override ulong MaxValue => ulong.MaxValue;
    protected override ulong MinValue => ulong.MinValue;

#pragma warning disable WPF0014 // SetValue must use registered type
    protected override void Decrement(ulong step) => SetCurrentValue(ValueProperty, (Value ?? Zero) - step);
    protected override void Increment(ulong step) => SetCurrentValue(ValueProperty, (Value ?? Zero) + step);
#pragma warning restore WPF0014 // SetValue must use registered type

    protected override bool IsGreaterThan(ulong left, ulong right) => left > right;
    protected override bool IsGreaterThanOrEquals(ulong left, ulong right) => left >= right;
    protected override bool IsLessThan(ulong left, ulong right) => left < right;
    protected override bool IsLessThanOrEquals(ulong left, ulong right) => left <= right;

    protected override bool TryParse(string? s, out ulong result) => ulong.TryParse(s, out result);
#endif
}