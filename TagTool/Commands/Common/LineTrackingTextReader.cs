using System;
using System.IO;

namespace TagTool.Commands.Common
{
    public class LineTrackingTextReader : TextReader
    {
        private readonly TextReader _innerReader;
        private int _lineNumber;

        public LineTrackingTextReader(TextReader innerReader)
        {
            _innerReader = innerReader;
            _lineNumber = 0;
        }

        public int LineNumber => _lineNumber;

        public override string ReadLine()
        {
            string line = _innerReader.ReadLine();
            if (line != null)
            {
                _lineNumber++;
            }
            return line;
        }

        public override int Read() => _innerReader.Read();

        public override int Read(char[] buffer, int index, int count) => _innerReader.Read(buffer, index, count);

        public override void Close() => _innerReader.Close();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _innerReader.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
