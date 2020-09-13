using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace FlatStyle
{
    public class MouseBehaviour : Behavior<Image>
    {
        #region Public Fields

        // Using a DependencyProperty as the backing store for Color. This enables animation,
        // styling, binding, etc...
        public static readonly DependencyProperty MouseXProperty = DependencyProperty.Register(
          "MouseX", typeof(int), typeof(MouseBehaviour), new PropertyMetadata(default(int)));

        public static readonly DependencyProperty MouseYProperty = DependencyProperty.Register(
                           "MouseY", typeof(int), typeof(MouseBehaviour), new PropertyMetadata(default(int)));

        #endregion Public Fields

        #region Public Properties

        public int MouseX
        {
            get => (int)GetValue(MouseXProperty);
            set => SetValue(MouseXProperty, value);
        }

        public int MouseY

        {
            get => (int)GetValue(MouseYProperty);
            set => SetValue(MouseYProperty, value);
        }

        #endregion Public Properties

        #region Protected Methods

        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += AssociatedObjectOnMouseMove;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= AssociatedObjectOnMouseMove;
        }

        #endregion Protected Methods

        #region Private Methods

        private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            double ratio = AssociatedObject.Source.Width / AssociatedObject.ActualWidth;
            Point pos = mouseEventArgs.GetPosition(AssociatedObject);
            MouseX = (int)(pos.X * ratio);
            MouseY = (int)(pos.Y * ratio);
            if (MouseX >= AssociatedObject.Source.Width)
            {
                MouseX = (int)AssociatedObject.Source.Width - 1;
            }

            if (MouseY >= AssociatedObject.Source.Height)
            {
                MouseY = (int)AssociatedObject.Source.Height - 1;
            }
        }

        #endregion Private Methods
    }
}