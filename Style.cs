using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace FlatStyle
{
    public static class Style
    {
        public static void SetTheme(Color primaryColor, Color secondaryColor, bool isLightTheme = true)
        {
            SetColor(ColorFlat.PrimaryColor, primaryColor);
            SetColor(ColorFlat.SecondaryColor, secondaryColor);

            SetColor(ColorFlat.SecondaryMidColor, GetBrightColor(secondaryColor, 30));
            SetColor(ColorFlat.SecondaryLightColor, GetBrightColor(secondaryColor, 50));

            SetColor(ColorFlat.PrimaryMidColor, GetBrightColor(primaryColor, 30));
            SetColor(ColorFlat.PrimaryLightColor, GetBrightColor(primaryColor, 50));

            if (isLightTheme)
            {
                SetColor(ColorFlat.BackgroundColor, GetBrightColor(primaryColor, 90));
                SetColor(ColorFlat.ForegroundMainColor, "232323");
            }
            else
            {
                SetColor(ColorFlat.ForegroundMainColor, GetBrightColor(primaryColor, 90));
                SetColor(ColorFlat.BackgroundColor, "232323");
            }
        }

        public static void SetTheme(string primaryColor, string secondaryColor, bool isLightTheme = true)
        {
            SetTheme(FromHtmlHexadecimal(primaryColor), FromHtmlHexadecimal(secondaryColor), isLightTheme);
        }

        public static void SetColor(ColorFlat color, byte r, byte g, byte b, byte a = 255)
        {
            SetColor(a, r, g, b, color.ToString());
        }

        public static void SetColor(ColorFlat color, string colorValue)
        {
            Color colorInput = FromHtmlHexadecimal(colorValue);
            SetColor(colorInput, color);
        }

        public static Color GetColor(ColorFlat colorName)
        {
            return (Color)Application.Current.Resources[colorName.ToString()];
        }

        public static void SetColor(ColorFlat color, Color colorValue)
        {
            Application.Current.Resources[color.ToString()] = colorValue;
            Application.Current.Resources[color.ToString().Replace("Color", "Brush")] = new SolidColorBrush(colorValue);
        }

        private static Color FromHtmlHexadecimal(string colorStringInput)
        {
            string colorString = colorStringInput.ToLower().Replace("#", "");
            byte[] color = Enumerable.Range(0, colorString.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(colorString.Substring(x, 2), 16))
                             .ToArray();
            if (color.Length == 3)
            {
                return Color.FromRgb(color[0], color[1], color[2]);
            }
            else if (color.Length == 4)
            {
                return Color.FromArgb(color[0], color[1], color[2], color[3]);
            }
            else
            {
                return new Color();
            }
        }

        private static void SetColor(Color color, ColorFlat colorName)
        {
            Application.Current.Resources[colorName.ToString()] = color;
            Application.Current.Resources[colorName.ToString().Replace("Color", "Brush")] = new SolidColorBrush(color);
        }

        private static Color GetBrightColor(Color color, int increaseByThisPercent)
        {
            const int maxColorValue = 255;
            double percentIncrement = increaseByThisPercent / 100.0;
            return new Color
            {
                A = color.A,
                R = (byte)(color.R + ((maxColorValue - color.R) * percentIncrement)),
                G = (byte)(color.G + ((maxColorValue - color.G) * percentIncrement)),
                B = (byte)(color.B + ((maxColorValue - color.B) * percentIncrement)),
            };
        }

        private static void SetColor(byte a, byte r, byte g, byte b, string colorName)
        {
            var color = new Color
            {
                A = a,
                R = r,
                G = g,
                B = b
            };
            Application.Current.Resources[colorName] = color;
            Application.Current.Resources[colorName.Replace("Color", "Brush")] = new SolidColorBrush(color);
        }
    }
}