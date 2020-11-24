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

        /// <summary>
        /// This is for Textbox. Triggers the update source event on return key
        /// </summary>
        public static ParameterizedDelegateCommand ReturnCommand = new ParameterizedDelegateCommand((parameter) => Return(parameter));

        /// <summary>
        /// Theme Setter for Flat window
        /// </summary>
        public static ParameterizedDelegateCommand Theme =
            new ParameterizedDelegateCommand(
            (parameter) =>
            ThemeSetter(parameter)
            );

        private static Window windowTheme;

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
            if (windowTheme != null)
            {
                if (!windowTheme.IsLoaded)
                {
                    ShowThemeWindow();
                }
                else
                {
                    windowTheme.Topmost = true;
                    windowTheme.Topmost = false;
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
            windowTheme = new Window
            {
                Content = new ThemeSelector(),
                Width = 300,
                Height = 260,
                ResizeMode = ResizeMode.NoResize,
            };
            windowTheme.Show();
        }

        private static void MaximizeWindow(object sender)
        {
            Window window = sender as Window;
            switch (window.WindowState)
            {
                case WindowState.Normal:
                    if (window.ResizeMode != ResizeMode.NoResize)
                    {
                        window.WindowState = WindowState.Maximized;
                        window.WindowStyle = WindowStyle.None;
                    }
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
            windowTheme?.Close();
        }
    }
}