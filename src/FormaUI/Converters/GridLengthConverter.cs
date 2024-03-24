using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FormaUI.Converters;

[ValueConversion(typeof(double), typeof(GridLength))]
public sealed class GridLengthConverter : IValueConverter
{
    public static readonly GridLengthConverter Default = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double doubleValue)
        {
            return new GridLength(doubleValue);
        }
        if (value is int intValue)
        {
            return new GridLength(intValue);
        }

        return value;
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException($"{nameof(GridLengthConverter)} can only be used in OneWay bindings");
    }
}
