using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Stira.Converters.Wpf
{
    public class MultiValueConverter : MarkupExtension, IMultiValueConverter
    {
        private MultiValueConverter multiValueConverter = null;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return multiValueConverter ?? new MultiValueConverter();
        }
    }
}