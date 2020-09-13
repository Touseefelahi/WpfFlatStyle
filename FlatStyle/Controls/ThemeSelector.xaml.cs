using FlatStyle.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FlatStyle
{
    /// <summary>
    /// Interaction logic for ThemeSelector.xaml
    /// </summary>
    public partial class ThemeSelector : UserControl
    {
        public ThemeSelector()
        {
            InitializeComponent();
            DataContext = this;
        }

        public bool IsLightTheme { get => FlatStyle.IsLightTheme; set => FlatStyle.SwitchTheme(!FlatStyle.IsLightTheme); }

        public string PrimaryColor
        {
            get => FlatStyle.GetColor(ColorFlat.PrimaryColor).ToString();
            set => FlatStyle.SetPrimaryColor(value);
        }

        public ColorFlat SelectedColorName { get; set; }

        public string SecondaryColor
        {
            get => FlatStyle.GetColor(ColorFlat.SecondaryColor).ToString();
            set => FlatStyle.SetSecondaryColor(value);
        }

        private void SaveTheme(object sender, RoutedEventArgs e)
        {
            FlatStyle.SaveTheme();
        }

        private void TextBox_PreviewMouseDoubleClickPrimary(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(FlatStyle.GetColor(ColorFlat.PrimaryColor));
            if (colorPicker.ShowDialog().Value)
            {
                PrimaryColor = colorPicker.SelectedColor.ToString();
            }
        }

        private void TextBox_PreviewMouseDoubleClickSecondary(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(FlatStyle.GetColor(ColorFlat.SecondaryColor));
            if (colorPicker.ShowDialog().Value)
            {
                SecondaryColor = colorPicker.SelectedColor.ToString();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedColorText.Text = FlatStyle.GetColor(SelectedColorName).ToString();
            SelectedColorDisplay.Background = new SolidColorBrush(FlatStyle.GetColor(SelectedColorName));
        }

        private void TextBox_PreviewMouseDoubleClickCustom(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(FlatStyle.GetColor(SelectedColorName));
            if (colorPicker.ShowDialog().Value)
            {
                selectedColorText.Text = colorPicker.SelectedColor.ToString();
                FlatStyle.SetColor(SelectedColorName, selectedColorText.Text);
                SelectedColorDisplay.Background = new SolidColorBrush(FlatStyle.GetColor(SelectedColorName));
            }
        }

        private void LoadDefaultOnRestart(object sender, RoutedEventArgs e)
        {
            FlatStyle.LoadDefaultOnRestart();
            MessageBox.Show("Will be effective on restart");
        }
    }
}