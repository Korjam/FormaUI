using System.Globalization;
using System.Windows.Data;

namespace FormaUI.Converters;

[ValueConversion(typeof(double), typeof(double))]
public sealed class DividerConverter : IValueConverter
{
    public double Divider { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double doubleValue)
        {
            return doubleValue / Divider;
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double doubleValue)
        {
            return doubleValue * Divider;
        }

        return value;
    }
}
