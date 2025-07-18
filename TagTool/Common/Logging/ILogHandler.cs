using System;

namespace TagTool.Common.Logging
{
    public readonly ref struct LogMessage
    {
        public readonly string Message;
        public readonly LogLevel Level;
        public readonly Exception Exception;

        public LogMessage(LogLevel level, string message)
        {
            Level = level;
            Message = message;
        }

        public LogMessage(LogLevel level, Exception exception, string message) : this(level, message)
        {
            Exception = exception;
        }
    }

    public interface ILogHandler
    {
        void Log(in LogMessage message);
    }
}
