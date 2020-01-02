using System.Windows;

namespace FlatStyle
{
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