using System.Windows;

namespace FlatStyle
{
    public class OnloadThemeUpdate : BaseAttachedProperty<OnloadThemeUpdate, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            base.OnValueChanged(sender, e);
        }

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