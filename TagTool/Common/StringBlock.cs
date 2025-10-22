using System;
using System.IO;
using System.Text;

namespace TagTool.Common
{
    public class StringBuffer
    {
        private readonly byte[] _data;
        private readonly Encoding _encoding;
        private readonly byte[] _nullBytes;

        public StringBuffer(byte[] data, Encoding encoding)
        {
            _data = data;
            _encoding = encoding;
            _nullBytes = encoding.GetBytes("\0");
        }

        public StringBuffer(byte[] data) : this(data, Encoding.UTF8) { }

        public string GetString(int offset)
        {
            if (offset < 0 || offset > _data.Length - _nullBytes.Length)
                throw new ArgumentOutOfRangeException(nameof(offset));

            int length = GetStringLength(_data.AsSpan()[offset..], _nullBytes);
            if (length == -1)
                throw new InvalidDataException("Failed to find null terminator in string block");

            return _encoding.GetString(_data, offset, length);
        }

        private static int GetStringLength(ReadOnlySpan<byte> data, ReadOnlySpan<byte> nullBytes)
        {
            int nullLength = nullBytes.Length;

            if (nullBytes.Length == 1 && nullBytes[0] == 0)
                return data.IndexOf<byte>(0);

            int n = data.Length - nullLength;
            for (int i = 0; i <= n; i++)
            {
                if (nullBytes.SequenceEqual(data.Slice(i, nullLength)))
                    return i;
            }

            return -1;
        }
    }
}
