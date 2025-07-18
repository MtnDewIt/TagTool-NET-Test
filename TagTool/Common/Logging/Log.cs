using System;
using System.Collections.Immutable;

namespace TagTool.Common.Logging
{
    public static class Log
    {
        private static ImmutableList<ILogHandler> _handlers = [];

        public static LogLevel Level { get; set; } = LogLevel.Info;

        public static void Debug(string message)
        {
            Handle(new LogMessage(LogLevel.Debug, message));
        }

        public static void Info(string message)
        {
            Handle(new LogMessage(LogLevel.Info, message));
        }

        public static void Warning(string message)
        {
            Handle(new LogMessage(LogLevel.Warning, message));
        }

        public static void Error(string message)
        {
            Handle(new LogMessage(LogLevel.Error, message));
        }

        public static void Error(Exception exception, string message = "")
        {
            Handle(new LogMessage(LogLevel.Error, exception, message));
        }

        public static void AddHandler(ILogHandler handler)
        {
            _handlers = _handlers.Add(handler);
        }

        public static void RemoveHandler(ILogHandler handler)
        {
            _handlers = _handlers.Remove(handler);
        }

        private static void Handle(LogMessage message)
        {
            foreach (ILogHandler handler in _handlers)
            {
                if (handler.IgnoresFilter || message.Level >= Level)
                    handler.Log(message);
            }
        }
    }
}
