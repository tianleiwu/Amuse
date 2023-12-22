using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Amuse.UI.Converters
{
    [ValueConversion(typeof(object), typeof(bool))]
    public class NullVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
