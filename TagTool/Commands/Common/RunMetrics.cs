using System;
using System.Diagnostics;
using TagTool.Common;
using TagTool.Common.Logging;

namespace TagTool.Commands.Common
{
    public class RunMetrics
    {
        private static readonly object Mutex = new();
        private static readonly Stopwatch Stopwatch = new();
        private static int ErrorCount = 0;
        private static int WarningCount = 0;

        public static void ReportElapsed()
        {
            lock (Mutex)
            {
                Stopwatch.Stop();
                TimeSpan t = TimeSpan.FromMilliseconds(Stopwatch.ElapsedMilliseconds);

                string timeDisplay = $"{t.TotalMilliseconds} milliseconds";

                if (t.TotalMilliseconds > 10000)
                {
                    timeDisplay = $"{t.Minutes} minutes and {t.Seconds} seconds";

                    if (t.Hours > 0)
                        timeDisplay = $"{t.Hours} hours, " + timeDisplay;
                }

                string errorColor = ErrorCount == 0 ? Ansi.BrightGreen : Ansi.BrightRed;
                string warningColor = WarningCount == 0 ? Ansi.Reset : Ansi.Yellow;
                Console.WriteLine($"{timeDisplay} elapsed with {errorColor}{ErrorCount} errors{Ansi.Reset} and {warningColor}{WarningCount} warnings.");

                ErrorCount = 0;
                WarningCount = 0;
                Stopwatch.Reset();
            }
        }

        public static void Start()
        {
            lock (Mutex)
            {
                ErrorCount = 0;
                WarningCount = 0;
                Stopwatch.Start();
            }
        }

        public static void IncrementErrorCount()
        {
            lock (Mutex)
            {
                ErrorCount++;
            }
        }

        public static void IncrementWarningCount()
        {
            lock (Mutex)
            {
                WarningCount++;
            }
        }
    }

    public class RunMetricsLogHandler : ILogHandler
    {
        public bool IgnoresFilter => true;

        public void Log(in LogMessage message)
        {
            switch (message.Level)
            {
                case LogLevel.Error:
                    RunMetrics.IncrementErrorCount();
                    break;
                case LogLevel.Warning:
                    RunMetrics.IncrementWarningCount();
                    break;
            }
        }
    }
}
