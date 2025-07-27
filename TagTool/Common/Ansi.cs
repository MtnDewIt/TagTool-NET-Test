using System.IO;
using System.Text;

namespace TagTool.Common
{
    public abstract class Ansi
    {
        // ANSI escape sequences

        public const string Reset = "\x1b[0m";

        public const string Black = "\x1b[30m";
        public const string Red = "\x1b[31m";
        public const string Green = "\x1b[32m";
        public const string Yellow = "\x1b[33m";
        public const string Blue = "\x1b[34m";
        public const string Magenta = "\x1b[35m";
        public const string Cyan = "\x1b[36m";
        public const string White = "\x1b[37m";

        public const string BrightBlack = "\x1b[90m";
        public const string BrightRed = "\x1b[91m";
        public const string BrightGreen = "\x1b[92m";
        public const string BrightYellow = "\x1b[93m";
        public const string BrightBlue = "\x1b[94m";
        public const string BrightMagenta = "\x1b[95m";
        public const string BrightCyan = "\x1b[96m";
        public const string BrightWhite = "\x1b[97m";
    }

    /// <summary>
    /// A Textwriter implementation that automatically appends the ansi reset sequence
    /// </summary>
    public class AnsiWriter : TextWriter
    {
        private TextWriter _writer;

        public AnsiWriter(TextWriter writer)
        {
            _writer = writer;
        }

        public override Encoding Encoding => _writer.Encoding;

        public override void Write(string value)
        {
            _writer.Write($"{value}{Ansi.Reset}");
        }

        public override void WriteLine(string value)
        {
            _writer.WriteLine($"{value}{Ansi.Reset}");
        }

        public override void WriteLine()
        {
            _writer.WriteLine(Ansi.Reset);
        }
    }
}
