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
        /// Tile Background Color property
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(TilePanel), new PropertyMetadata(new SolidColorBrush(FlatStyle.GetColor(ColorFlat.BackgroundColor))));

        /// <summary>
        /// Title color property
        /// </summary>
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("HeaderColor", typeof(Brush), typeof(TilePanel), new PropertyMetadata(new SolidColorBrush(FlatStyle.GetColor(ColorFlat.PrimaryColor))));

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

        /// <summary>
        /// This will be title of tile
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Tile Background Color
        /// </summary>
        public Brush BackgroundColor
        {
            get { return (Brush)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        /// <summary>
        /// Title Header Color
        /// </summary>
        public Brush HeaderColor
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
    }
}