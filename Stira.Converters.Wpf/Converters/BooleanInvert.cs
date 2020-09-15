using System;
using System.Globalization;

namespace Stira.Converters.Wpf
{
    public class BooleanInvert : BaseValueConverter<BooleanInvert>
    {
        #region Public Methods

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}