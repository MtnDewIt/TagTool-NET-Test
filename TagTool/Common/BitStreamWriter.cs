using System;
using System.IO;
using System.Text;
using TagTool.IO;

namespace TagTool.Common
{
    public class BitStreamWriter
    {
        private readonly EndianWriter _writer;
        private ulong _accumulator;
        private int _accumulatorBitsUsed;

        public BitStreamWriter(Stream stream)
        {
            _writer = new EndianWriter(stream, EndianFormat.BigEndian);
        }

        public void WriteBool(bool value) 
        {
            WriteInteger(value ? 1U : 0U, 1);
        }

        public void WriteSignedInteger(int value, int sizeInBits)
        {
            int maxValue = (1 << (sizeInBits - 1) - 1);

            // TODO: Add asserts :/

            WriteInteger((uint)value, sizeInBits);
        }

        public void WriteInteger(uint value, int sizeInBits) 
        {
            WriteBitsInternal(value, sizeInBits);
        }

        public void WriteFloat(float value, int sizeInBits) 
        {
            WriteInteger((uint)value, sizeInBits);
        }

        public void WriteQWord(ulong value, int sizeInBits) 
        {
            WriteBitsInternal(value, sizeInBits);
        }

        public void WriteStringUtf8(string charString, int maxStringSize) 
        {
            // TODO: Add asserts :/

            byte[] charBuffer = Encoding.UTF8.GetBytes(charString);

            foreach (byte c in charBuffer) 
            {
                WriteBitsInternal(c, 8);
            }

            WriteBitsInternal(0, 8);
        }

        public void WriteStringWchar(string value, int maxStringSize) 
        {
            // TODO: Add asserts :/

            foreach (char c in value) 
            {
                WriteBitsInternal(c, 16);
            }

            WriteBitsInternal(0, 16);
        }

        public void WriteBitsInternal(ulong value, int sizeInBits) 
        {
            if (sizeInBits <= 0 || sizeInBits > 64)
            {
                throw new ArgumentException("Number of bits must be between 1 and 64");
            }

            ulong mask = (sizeInBits == 64) ? ulong.MaxValue : ((1UL << sizeInBits) - 1);
            ulong maskedValue = value & mask;

            _accumulator = (_accumulator << sizeInBits) | maskedValue;
            _accumulatorBitsUsed += sizeInBits;

            while (_accumulatorBitsUsed >= 8)
            {
                _accumulatorBitsUsed -= 8;
                byte output = (byte)(_accumulator >> _accumulatorBitsUsed);
                _writer.Write(output);

                _accumulator &= (1UL << _accumulatorBitsUsed) - 1;
            }
        }

        /*
        public void AxesComputeReferenceInternal(RealVector3d up, out RealVector3d forwardReference, out RealVector3d leftReference) 
        {
            
        }

        public void AxesToAngleInternal(RealVector3d forward, RealVector3d up) 
        {
            
        }

        public void WriteAxes(RealVector3d forward, RealVector3d up) 
        {
            
        }

        public void WriteAxesReach(int fowardBits, int upBits, RealVector3d forward, RealVector3d up) 
        {
            
        }
        */
    }
}
