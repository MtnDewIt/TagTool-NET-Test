using System;

namespace TagTool.Common.Logging
{
    public class ConsoleLogHandler : ILogHandler
    {
        public void Log(in LogMessage message)
        {
            // if we're not at the start of the line, insert a new one to avoid ugliness with Console.Write()
            if (Console.LargestWindowWidth != 0 && Console.CursorLeft > 0)
                Console.WriteLine();

            Console.WriteLine(FormatLogMessage(message));
        }

        private string FormatLogMessage(LogMessage message)
        {
            switch (message.Level)
            {
                case LogLevel.Debug:
                    return $"{Ansi.BrightBlack}[DEBUG]: {message.Message}";
                case LogLevel.Info:
                    return $"{Ansi.BrightBlue}[INFO]: {message.Message}";
                case LogLevel.Warning:
                    return $"{Ansi.BrightYellow}[WARNING]: {message.Message}";
                case LogLevel.Error:
                    return FormatError(message);
                default:
                    return message.Message;
            }
        }

        private string FormatError(LogMessage message)
        {
            if (message.Exception != null)
            {
                if (!string.IsNullOrEmpty(message.Message))
                    return $"{Ansi.BrightRed}[ERROR]: {message.Message}\n{message.Exception}";
                else
                    return $"{Ansi.BrightRed}[ERROR]: {message.Exception}";
            }
            else
            {
                return $"{Ansi.BrightRed}[ERROR]: {message.Message}";
            }
        }
    }
}
