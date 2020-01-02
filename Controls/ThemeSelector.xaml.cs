using FlatStyle.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public bool IsLightTheme { get => FlatStyle.Style.IsLightTheme; set => FlatStyle.Style.SwitchTheme(!FlatStyle.Style.IsLightTheme); }

        public string PrimaryColor
        {
            get => FlatStyle.Style.GetColor(ColorFlat.PrimaryColor).ToString();
            set => FlatStyle.Style.SetPrimaryColor(value);
        }

        public string SecondaryColor
        {
            get => FlatStyle.Style.GetColor(ColorFlat.SecondaryColor).ToString();
            set => FlatStyle.Style.SetSecondaryColor(value);
        }

        public string ContentColor
        {
            get => FlatStyle.Style.GetColor(ColorFlat.ControlForegroundColor).ToString();
            set => FlatStyle.Style.SetColor(ColorFlat.ControlForegroundColor, value);
        }

        private void SaveTheme(object sender, RoutedEventArgs e)
        {
            FlatStyle.Style.SaveTheme();
        }

        private void TextBox_PreviewMouseDoubleClickPrimary(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker();
            colorPicker.ShowDialog();
            PrimaryColor = colorPicker.SelectedColor.ToString();
        }

        private void TextBox_PreviewMouseDoubleClickSecondary(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker();
            colorPicker.ShowDialog();
            SecondaryColor = colorPicker.SelectedColor.ToString();
        }

        private void TextBox_PreviewMouseDoubleClickContent(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker();
            colorPicker.ShowDialog();
            ContentColor = colorPicker.SelectedColor.ToString();
        }
    }
}