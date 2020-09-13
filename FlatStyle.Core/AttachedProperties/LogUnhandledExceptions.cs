using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace FlatStyle
{
    /// <summary>
    /// Logs unhandled exceptions if true in <see cref="fileName"/>
    /// </summary>
    public class LogUnhandledExceptions : BaseAttachedProperty<LogUnhandledExceptions, bool>
    {
        private const string fileName = "Exceptions.log";

        /// <summary>
        /// Logs message in <see cref="fileName"/> file
        /// </summary>
        /// <param name="message">Message to log</param>
        public static void Log(string message)
        {
            Trace.TraceError($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}\t{message}");
        }

        /// <summary>
        /// Logs message in <see cref="fileName"/> file
        /// </summary>
        /// <param name="ex">Exception to log</param>
        public static void Log(Exception ex)
        {
            Log(TranslateStack(ex));
        }

        /// <summary>
        /// Hook all unhandled exceptions to the log method
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="value">bool</param>
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (value is bool isLoggingRequired)
            {
                Trace.Listeners.Add(new TextWriterTraceListener(fileName, "Errors"));
                Trace.AutoFlush = true;
                Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
                AppDomain.CurrentDomain.UnhandledException += LogExceptions;
            }
            else
            {
                try
                {
                    Application.Current.DispatcherUnhandledException -= Current_DispatcherUnhandledException;
                    AppDomain.CurrentDomain.UnhandledException -= LogExceptions;
                }
                catch
                {
                }
            }
        }

        private static string TranslateStack(Exception exception)
        {
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
                    subBuilder.Append(info.ParameterType.Name).Append(' ').Append(info.Name);
                }
                if (builder.Length != 0)
                {
                    builder.Append(Environment.NewLine);
                }
                builder.Append(name).Append(", ").Append(subBuilder).Append(", ").Append(fullName).Append(", ").Append(fileName).Append(", ").Append(str);
            }
            return builder.ToString();
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Log($"{Environment.NewLine}{sender} {TranslateStack(e.Exception)} {Environment.NewLine}");
            e.Handled = false;
        }

        private void LogExceptions(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Log($"{Environment.NewLine}UnHandledException : {e.Message}  \tStack: {TranslateStack(e)}, Terminating app: {args.IsTerminating} {Environment.NewLine}");
        }
    }
}