using System;
using System.Globalization;

namespace Stira.Converters.Wpf
{
    public class ToString : BaseValueConverter<ToString>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}