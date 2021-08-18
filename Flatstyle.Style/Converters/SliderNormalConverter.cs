using Stira.Converters.Wpf;
using System;
using System.Globalization;

namespace FlatStyle.Converters
{
    public class SliderNormalConverter : BaseValueConverter<SliderNormalConverter>
    {
        #region Public Methods

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value.ToString();
            var stringSplits = stringValue.Split(".");
            if (stringSplits.Length == 2 && stringSplits[1].Length > 12)
            {
                int zeroCount = stringSplits[1].Split('0').Length - 1;
                double percentage = 0.6;
                if (zeroCount > stringSplits[1].Length * percentage)
                {
                    return Math.Round((double)value, 5).ToString();
                }

                int nineCount = stringSplits[1].Split('9').Length - 1;
                if (nineCount > stringSplits[1].Length * percentage)
                {
                    return Math.Round((double)value, 5).ToString();
                }
                for (int i = 1; i < 9; i++)
                {
                    int count = stringSplits[1].Split($"{i}").Length - 1;
                    if (count > stringSplits[1].Length * percentage)
                    {
                        return Math.Round((double)value, 3).ToString();
                    }
                }
            }
            return stringValue;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        #endregion Public Methods
    }
}