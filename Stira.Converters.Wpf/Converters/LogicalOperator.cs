using System;

namespace Stira.Converters.Wpf
{
    /// <summary>
    /// It checks the condition greater than or less than and returns bool
    /// <para>e.g. Set ConverterParameter=>10 if value is greater than 10 it returns true else false</para>
    /// </summary>
    public class LogicalOperator : BaseValueConverter<LogicalOperator>
    {
        /// <summary>
        /// It checks the condition greater than or less than and returns bool
        /// <para>e.g. Set ConverterParameter=g10 if value is greater than 10 it returns true else false</para>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result;
            _ = double.TryParse(value.ToString(), out double valueDouble);

            if (value != null && parameter != null)
            {
                if (parameter.ToString().Contains("g"))
                {
                    _ = double.TryParse(parameter.ToString().Trim('g'), out result);
                    return valueDouble > result;
                }
                else if (parameter.ToString().Contains("l"))
                {
                    _ = double.TryParse(parameter.ToString().Trim('l'), out result);
                    return valueDouble < result;
                }
            }
            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}