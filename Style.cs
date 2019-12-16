using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace FlatStyle
{
    public static class Style
    {
        public static void SetColor(ColorFlat color, byte r, byte g, byte b, byte a = 255)
        {
            SetColor(a, r, g, b, color.ToString());
        }

        public static void SetColor(ColorFlat color, string colorValue)
        {
            Color colorInput = FromHtmlHexadecimal(colorValue);
            SetColor(colorInput, color);
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