using System.Windows.Controls;
using System.Windows;

namespace FlatStyle
{
    /// <summary>
    /// Interaction logic for TileSoftDown.xaml
    /// </summary>
    public partial class TileSoftDown : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
                   DependencyProperty.Register("Title", typeof(string), typeof(TileSoftDown), new PropertyMetadata(string.Empty));

        public TileSoftDown()
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