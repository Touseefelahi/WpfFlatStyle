using System;
using System.Globalization;

namespace FlatStyle.Converters
{
    public class GridLengthToDouble : BaseValueConverter<GridLengthToDouble>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}