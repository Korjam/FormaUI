using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FormaUI.Converters;

[ValueConversion(typeof(int), typeof(Thickness))]
public sealed class ThicknessConverter : IValueConverter
{
    public Thickness Factor { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int intValue)
        {
            return new Thickness(
                intValue * Factor.Left,
                intValue * Factor.Top,
                intValue * Factor.Right,
                intValue * Factor.Bottom);
        }

        return value;
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException($"{nameof(ThicknessConverter)} can only be used in OneWay bindings");
    }
}