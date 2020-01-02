using System.Windows;
using System.Windows.Media;

namespace FlatStyle
{
    public class BaseColor : BaseAttachedProperty<BaseColor, Brush>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            base.OnValueChanged(sender, e);
        }
    }
}