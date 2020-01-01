using System;
using System.Windows;

namespace FlatStyle
{
    public static class Command
    {
        public static ParameterizedDelegateCommand Close = new ParameterizedDelegateCommand((parameter) => CloseWindow(parameter));
        public static ParameterizedDelegateCommand Maximize = new ParameterizedDelegateCommand((parameter) => MaximizeWindow(parameter));

        public static ParameterizedDelegateCommand Minimize = new ParameterizedDelegateCommand((parameter) => MinimizeWindow(parameter));

        public static ParameterizedDelegateCommand Theme =
            new ParameterizedDelegateCommand(
            (parameter) =>
            ThemeSetter(parameter)
            );

        private static void ThemeSetter(object parameter)
        {
            Style.SwitchTheme(!Style.IsLightTheme);
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