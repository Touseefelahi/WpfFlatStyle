using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlatStyle
{
    /// <summary>
    /// Interaction logic for TileStackPanel.xaml
    /// </summary>
    public partial class TilePanel : UserControl
    {
        /// <summary>
        /// This will be title of tile
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }




        /// <summary>
        /// Title Color
        /// </summary>
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        /// <summary>
        /// TItle color property
        /// </summary>
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(TilePanel), new PropertyMetadata(new SolidColorBrush(FlatStyle.Style.GetColor(ColorFlat.PrimaryColor))));




        /// <summary>
        /// This will be the Title of tile
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TilePanel), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Tile stack panel is just a normal stack panel with shadow and Title
        /// </summary>
        public TilePanel()
        {
            InitializeComponent();
        }
    }
}
