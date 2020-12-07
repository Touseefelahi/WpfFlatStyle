using FlatStyle.Resizer;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace FlatStyle
{
    /// <summary>
    /// Shows theme selector on window
    /// </summary>
    public class ShowThemeSelector : BaseAttachedProperty<ShowThemeSelector, bool> { }

    /// <summary>
    /// Title bar thickness
    /// </summary>
    public class TitleBar : BaseAttachedProperty<TitleBar, GridLength> { }

    /// <summary>
    /// Loads the saved theme on BootUp
    /// </summary>
    public class OnloadThemeUpdate : BaseAttachedProperty<OnloadThemeUpdate, bool>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (value is bool isLoadRequired)
            {
                if (isLoadRequired)
                    Style.LoadTheme();
            }
        }
    }
}