using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace FlatStyle
{
    public class LogUnhandledExceptions : BaseAttachedProperty<LogUnhandledExceptions, bool>
    {
        private static string fileName = "Log.txt";

        public static void Log(string message)
        {
            using (StreamWriter sw = File.AppendText(fileName))
            {
                try
                {
                    sw.WriteLine($"{DateTime.Now.ToShortDateString()} # {DateTime.Now.TimeOfDay} # {message}");
                }
                catch
                {
                }
            }
        }

        public static void Log(Exception ex)
        {
            Log(TranslateStack(ex));
        }

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (value is bool isLoggingRequired)
            {
                Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
                AppDomain.CurrentDomain.UnhandledException += LogExceptions;
            }
        }

        private static string TranslateStack(Exception exception)
        {
            string format = "{0};{1};{2};{3};{4}";
            StringBuilder builder = new StringBuilder();
            StackTrace trace = new StackTrace(exception, true);
            StackFrame[] stackFrames = trace.GetFrames();
            if (stackFrames == null)
            {
                return builder.ToString();
            }

            foreach (StackFrame frame in stackFrames)
            {
                string name = frame.GetMethod().Name;
                StringBuilder subBuilder = new StringBuilder();
                string fileName = frame.GetFileName();
                string str = frame.GetFileLineNumber().ToString(CultureInfo.InvariantCulture);
                if ((frame.GetMethod() == null) || (frame.GetMethod().DeclaringType == null))
                {
                    continue;
                }

                string fullName = frame.GetMethod().DeclaringType.FullName;
                foreach (ParameterInfo info in frame.GetMethod().GetParameters())
                {
                    if (subBuilder.Length != 0)
                    {
                        subBuilder.Append(", ");
                    }
                    subBuilder.Append(info.ParameterType.Name + " " + info.Name);
                }
                if (builder.Length != 0)
                {
                    builder.Append("\r\n");
                }
                builder.AppendFormat(CultureInfo.CurrentCulture, format, new object[] { name, subBuilder, fullName, fileName, str });
            }
            return builder.ToString();
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Log($"{Environment.NewLine} {sender} {TranslateStack(e.Exception)} {Environment.NewLine}");
            e.Handled = false;
        }

        private void LogExceptions(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Log($"{Environment.NewLine}UnHandledException : {e.Message}  \tStack: {TranslateStack(e)}, Terminating app: {args.IsTerminating} {Environment.NewLine}");
        }
    }
}