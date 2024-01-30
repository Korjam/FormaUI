using System.Windows;

namespace FormaUI.Controls;

public class IntegerUpDown : NumericUpDown<int>
{
    static IntegerUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(IntegerUpDown), new FrameworkPropertyMetadata(typeof(IntegerUpDown)));
    }
}

public class DoubleUpDown : NumericUpDown<double>
{
    static DoubleUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DoubleUpDown), new FrameworkPropertyMetadata(typeof(DoubleUpDown)));
    }
}

public class FloatUpDown : NumericUpDown<float>
{
    static FloatUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatUpDown), new FrameworkPropertyMetadata(typeof(FloatUpDown)));
    }
}

public class DecimalUpDown : NumericUpDown<decimal>
{
    static DecimalUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(DecimalUpDown), new FrameworkPropertyMetadata(typeof(DecimalUpDown)));
    }
}

public class LongUpDown : NumericUpDown<long>
{
    static LongUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(LongUpDown), new FrameworkPropertyMetadata(typeof(LongUpDown)));
    }
}

public class ShortUpDown : NumericUpDown<short>
{
    static ShortUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ShortUpDown), new FrameworkPropertyMetadata(typeof(ShortUpDown)));
    }
}

public class ByteUpDown : NumericUpDown<byte>
{
    static ByteUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ByteUpDown), new FrameworkPropertyMetadata(typeof(ByteUpDown)));
    }
}

public class SByteUpDown : NumericUpDown<sbyte>
{
    static SByteUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SByteUpDown), new FrameworkPropertyMetadata(typeof(SByteUpDown)));
    }
}

public class UShortUpDown : NumericUpDown<ushort>
{
    static UShortUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UShortUpDown), new FrameworkPropertyMetadata(typeof(UShortUpDown)));
    }
}

public class UIntUpDown : NumericUpDown<uint>
{
    static UIntUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UIntUpDown), new FrameworkPropertyMetadata(typeof(UIntUpDown)));
    }
}

public class ULongUpDown : NumericUpDown<ulong>
{
    static ULongUpDown()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ULongUpDown), new FrameworkPropertyMetadata(typeof(ULongUpDown)));
    }
}