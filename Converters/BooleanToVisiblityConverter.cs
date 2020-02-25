using System;
using System.Globalization;
using System.Windows;

namespace FlatStyle.Converters
{
    /// <summary>
    /// Converts bool to Visibility parameters: | NC = normal collapsed | IC = Inverted Collapsed |
    /// NH = Normal Hidden | IH = Inverted Hidden
    /// </summary>
    public class BooleanToVisiblityConverter : BaseValueConverter<BooleanToVisiblityConverter>
    {
        #region Public Methods

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) //Normal Collapsed
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                switch (parameter.ToString().ToUpper())
                {
                    case "NC": //Normal Collapsed
                        return (bool)value ? Visibility.Visible : Visibility.Collapsed;

                    case "IC": //Inverted Collapsed
                        return (bool)value ? Visibility.Collapsed : Visibility.Visible;

                    case "NH": //Normal Hidden
                        return (bool)value ? Visibility.Visible : Visibility.Hidden;

                    case "IH": //Inverted Hidden
                        return (bool)value ? Visibility.Hidden : Visibility.Visible;

                    default://Normal collapsed
                        return (bool)value ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}