using System;

namespace Stira.Converters.Wpf
{
    /// <summary>
    /// It converts the parameter with given airthmetic oeprator
    /// <para>e.g. Set ConverterParameter=+10 to add 10 to the given value</para>
    /// </summary>
    public class AirthmeticOperator : BaseValueConverter<AirthmeticOperator>
    {
        /// <summary>
        /// It converts the parameter with given airthmetic oeprator
        /// <para>e.g. Set ConverterParameter=+10 to add 10 to the given value</para>
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
                if (parameter.ToString().Contains("+"))
                {
                    _ = double.TryParse(parameter.ToString().Trim('+'), out result);
                    return valueDouble + result;
                }
                else if (parameter.ToString().Contains("*"))
                {
                    _ = double.TryParse(parameter.ToString().Trim('*'), out result);
                    return valueDouble * result;
                }
                else if (parameter.ToString().Contains("-"))
                {
                    _ = double.TryParse(parameter.ToString().Trim('-'), out result);
                    return valueDouble - result;
                }
                else if (parameter.ToString().Contains("/"))
                {
                    _ = double.TryParse(parameter.ToString().Trim('/'), out result);
                    return valueDouble / result;
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