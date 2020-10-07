using FlatStyle.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ColorUpdateCommand = new DelegateCommand(ColorUpdated);
        }

        public ICommand ColorUpdateCommand { get; set; }

        public bool IsLightTheme { get => FlatStyle.Style.IsLightTheme; set => FlatStyle.Style.SwitchTheme(!FlatStyle.Style.IsLightTheme); }

        public string PrimaryColor
        {
            get => FlatStyle.Style.GetColor(ColorFlat.PrimaryColor).ToString();
            set => FlatStyle.Style.SetPrimaryColor(value);
        }

        public ColorFlat SelectedColorName { get; set; }

        public string SecondaryColor
        {
            get => FlatStyle.Style.GetColor(ColorFlat.SecondaryColor).ToString();
            set => FlatStyle.Style.SetSecondaryColor(value);
        }

        private void ColorUpdated()
        {
            try
            {
                FlatStyle.Style.SetColor(SelectedColorName, selectedColorText.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void SaveTheme(object sender, RoutedEventArgs e)
        {
            FlatStyle.Style.SaveTheme();
        }

        private void TextBox_PreviewMouseDoubleClickPrimary(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(FlatStyle.Style.GetColor(ColorFlat.PrimaryColor));
            if (colorPicker.ShowDialog().Value)
            {
                PrimaryColor = colorPicker.SelectedColor.ToString();
            }
        }

        private void TextBox_PreviewMouseDoubleClickSecondary(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(FlatStyle.Style.GetColor(ColorFlat.SecondaryColor));
            if (colorPicker.ShowDialog().Value)
            {
                SecondaryColor = colorPicker.SelectedColor.ToString();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedColorText.Text = FlatStyle.Style.GetColor(SelectedColorName).ToString();
            SelectedColorDisplay.Background = new SolidColorBrush(FlatStyle.Style.GetColor(SelectedColorName));
        }

        private void TextBox_PreviewMouseDoubleClickCustom(object sender, MouseButtonEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker(FlatStyle.Style.GetColor(SelectedColorName));
            if (colorPicker.ShowDialog().Value)
            {
                selectedColorText.Text = colorPicker.SelectedColor.ToString();
                FlatStyle.Style.SetColor(SelectedColorName, selectedColorText.Text);
                SelectedColorDisplay.Background = new SolidColorBrush(FlatStyle.Style.GetColor(SelectedColorName));
            }
        }

        private void LoadDefaultOnRestart(object sender, RoutedEventArgs e)
        {
            FlatStyle.Style.LoadDefaultOnRestart();
            MessageBox.Show("Will be effective on restart");
        }
    }
}