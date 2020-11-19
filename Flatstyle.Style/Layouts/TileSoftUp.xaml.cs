using System.Windows;
using System.Windows.Controls;

namespace FlatStyle
{
    /// <summary>
    /// Interaction logic for TileSoft.xaml
    /// </summary>
    public partial class TileSoftUp : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
                    DependencyProperty.Register("Title", typeof(string), typeof(TileSoftUp), new PropertyMetadata(string.Empty));

        public TileSoftUp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This will be title of tile
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
    }
}