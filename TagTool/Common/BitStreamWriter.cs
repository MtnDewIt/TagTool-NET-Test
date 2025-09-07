using System;
using System.IO;
using System.Text;
using TagTool.IO;

namespace TagTool.Common
{
    public class BitStreamWriter
    {
        private readonly EndianWriter _writer;

        private int _bitBuffer = 0;
        private int _bitCount = 0;

        public BitStreamWriter(Stream stream)
        {
            _writer = new EndianWriter(stream, EndianFormat.BigEndian);
        }

        public void WriteTest(int value, int sizeInBits)
        {
            if (sizeInBits <= 0 || sizeInBits > 32)
            {
                throw new ArgumentException("Number of bits must be between 1 and 32");
            }

            int mask = (1 << sizeInBits) - 1;
            int maskedValue = value & mask;

            _bitBuffer = (_bitBuffer << sizeInBits) | maskedValue;
            _bitCount += sizeInBits;

            while (_bitCount >= 8)
            {
                _bitCount -= 8;
                byte output = (byte)(_bitBuffer >> _bitCount);
                _writer.Write(output);

                _bitBuffer &= (1 << _bitCount) - 1;
            }
        }

        public void FlushTest() 
        {
            if (_bitCount > 0)
            {
                byte outputByte = (byte)(_bitBuffer << (8 - _bitCount));
                _writer.Write(outputByte);
                _bitBuffer = 0;
                _bitCount = 0;
            }
        }
    }
}
