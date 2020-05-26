using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FlatStyle
{
    /// <summary>
    /// All custom routed commands
    /// </summary>
    public static class Command
    {
        /// <summary>
        /// It updates the numeric updown value
        /// </summary>
        public static ParameterizedDelegateCommand UpdateNumericUpDownValue = new ParameterizedDelegateCommand((sender) => UpdateValue(sender));

        /// <summary>
        /// close command for window
        /// </summary>
        public static ParameterizedDelegateCommand Close = new ParameterizedDelegateCommand((parameter) => CloseWindow(parameter));

        /// <summary>
        /// Always on top command for window
        /// </summary>
        public static ParameterizedDelegateCommand AlwaysOnTop = new ParameterizedDelegateCommand((parameter) => AlwaysOnTopWindow(parameter));

        /// <summary>
        /// maximize command for window
        /// </summary>
        public static ParameterizedDelegateCommand Maximize = new ParameterizedDelegateCommand((parameter) => MaximizeWindow(parameter));

        /// <summary>
        /// Minimize command for window
        /// </summary>
        public static ParameterizedDelegateCommand Minimize = new ParameterizedDelegateCommand((parameter) => MinimizeWindow(parameter));

        public static ParameterizedDelegateCommand ReturnCommand = new ParameterizedDelegateCommand((parameter) => Return(parameter));

        /// <summary>
        /// Theme Setter for Flat window
        /// </summary>
        public static ParameterizedDelegateCommand Theme =
            new ParameterizedDelegateCommand(
            (parameter) =>
            ThemeSetter(parameter)
            );

        private static Window windowContact;

        private static void Return(object sender)
        {
            if (sender is TextBox textBox)//Update source
            {
                BindingOperations.GetBindingExpression(textBox, TextBox.TextProperty)?.UpdateSource();
            }
        }

        private static void UpdateValue(object sender)
        {
            if (sender is object[] objects && objects[0] is Slider slider && objects[1] is TextBox textBox)
            {
                try
                {
                    try
                    {
                        slider.Value = Convert.ToDouble(textBox.Text.Replace(" ", ""));
                    }
                    catch { }
                    textBox.Text = slider.Value.ToString();
                    textBox.CaretIndex = textBox.Text.Length;
                }
                catch
                {
                    throw;
                }
            }
        }

        private static void ThemeSetter(object parameter)
        {
            if (windowContact != null)
            {
                if (!windowContact.IsLoaded)
                {
                    ShowThemeWindow();
                }
                else
                {
                    windowContact.Topmost = true;
                    windowContact.Topmost = false;
                }
            }
            else
            {
                ShowThemeWindow();
            }
        }

        private static void AlwaysOnTopWindow(object parameter)
        {
            Window window = parameter as Window;
            window.Topmost = !window.Topmost;
        }

        private static void ShowThemeWindow()
        {
            windowContact = new Window
            {
                Content = new ThemeSelector(),
                Width = 250,
                Height = 200,
                ResizeMode = ResizeMode.NoResize,
            };
            windowContact.Show();
        }

        private static void MaximizeWindow(object sender)
        {
            Window window = sender as Window;
            switch (window.WindowState)
            {
                case WindowState.Normal:
                    window.WindowState = WindowState.Maximized;
                    break;

                case WindowState.Maximized:
                    window.WindowState = WindowState.Normal;
                    break;
            }
        }

        private static void MinimizeWindow(object sender)
        {
            Window window = sender as Window;
            window.WindowState = WindowState.Minimized;
        }

        private static void CloseWindow(object sender)
        {
            Window window = sender as Window;
            window.Close();
        }
    }
}