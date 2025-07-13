using System;
using System.Diagnostics;

namespace TagTool.Commands.Common
{
    public class RunMetrics
    {
        public static readonly Stopwatch Stopwatch = new();
        public static int ErrorCount = 0;
        public static int WarningCount = 0;

        public static void ReportElapsed()
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

            Console.Write($"{timeDisplay} elapsed with ");

            Console.ForegroundColor = ErrorCount == 0 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{ErrorCount} errors ");
            Console.ResetColor();

            Console.Write("and ");

            Console.ForegroundColor = WarningCount == 0 ? Console.ForegroundColor : ConsoleColor.DarkYellow;
            Console.Write($"{WarningCount} warnings");
            Console.ResetColor();

            Console.Write(".\n");

            ErrorCount = 0;
            WarningCount = 0;
            Stopwatch.Reset();
        }

        public static void Start()
        {
            ErrorCount = 0;
            WarningCount = 0;
            Stopwatch.Start();
        }
    }
}
