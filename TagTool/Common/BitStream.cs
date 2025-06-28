using System;
using System.IO;
using System.Text;
using TagTool.IO;

namespace TagTool.Common
{
    public class BitStream
    {
        const int QWORD_BITS = 64;

        private readonly EndianReader _reader;
        private ulong _accumulator;
        private int _accumulatorBitsUsed;

        public BitStream(Stream stream)
        {
            _reader = new EndianReader(stream, EndianFormat.BigEndian);
            _accumulator = DecodeAccumulator();
        }

        // TODO: Redo Base Read Functions
        // TODO: Add Write Functionality

        public static void ReadAxis(BitStream stream, int forwardBits, int upBits, bool withEndPoints, out RealVector3d forward, out RealVector3d up)
        {
            var isUp = stream.ReadBool();

            if (isUp)
            {
                up = RealMath.GLOBAL_UP;
            }
            else
            {
                int quantizedUp = (int)stream.ReadUnsigned(upBits);

                if (withEndPoints)
                {
                    RealMath.DequantizeUnitVector3dWithTable(quantizedUp, upBits, out up);
                }
                else 
                {
                    RealMath.DequantizeUnitVector3d(quantizedUp, forwardBits, out up);
                }
            }

            float forwardAngle;

            if (withEndPoints)
            {
                forwardAngle = ReadQuantizedRealWithEndPoints(stream, -RealMath.REAL_PI, RealMath.REAL_PI, forwardBits, false, false);
            }
            else
            {
                forwardAngle = ReadQuantizedReal(stream, -RealMath.REAL_PI, RealMath.REAL_PI, forwardBits, true, false);
            }

            AngleToAxes(up, forwardAngle, out forward);
        }

        public static void AngleToAxes(RealVector3d up, float angle, out RealVector3d forward)
        {
            var forwardReference = new RealVector3d();
            var leftReference = new RealVector3d();

            AxesComputeReference(up, out forwardReference, out leftReference);

            forward = new RealVector3d
            {
                I = forwardReference.I,
                J = forwardReference.J,
                K = forwardReference.K,
            };

            float u;
            float v;

            if (angle == (float)Math.PI || angle == -(float)Math.PI)
            {
                u = 0.0f;
                v = -1.0f;
            }
            else
            {
                u = (float)Math.Sin(angle);
                v = (float)Math.Cos(angle);
            }

            forward = RealMath.RotateVectorAboutAxis(forward, up, u, v);
            RealMath.Normalize3d(forward, out forward);

            if (!RealMath.ValidReadlVector3dAxes2(forward, up))
            {
                throw new InvalidOperationException("Invalid forward and up vectors");
            }
        }

        public static void AxesComputeReference(RealVector3d up, out RealVector3d forwardReference, out RealVector3d leftReference)
        {
            if (!RealMath.ValidRealVector(up))
            {
                throw new ArgumentException("Up vector is not a valid vector");
            }

            float forwardAmount = Math.Abs(RealVector3d.DotProduct(up, RealMath.GLOBAL_FORWARD));
            float leftAmount = Math.Abs(RealVector3d.DotProduct(up, RealMath.GLOBAL_LEFT));

            if (forwardAmount >= leftAmount)
            {
                forwardReference = RealVector3d.CrossProductNoNorm(RealMath.GLOBAL_LEFT, up);
            }
            else
            {
                forwardReference = RealVector3d.CrossProductNoNorm(up, RealMath.GLOBAL_FORWARD);
            }

            float forwardMagnitude = RealMath.Normalize3d(forwardReference, out forwardReference);

            if (forwardMagnitude < RealMath.REAL_EPSILON)
            {
                throw new InvalidOperationException("Forward Magnitude was less than epsilon");
            }

            leftReference = RealVector3d.CrossProductNoNorm(up, forwardReference);

            float leftMagnitude = RealMath.Normalize3d(leftReference, out leftReference);

            if (leftMagnitude < RealMath.REAL_EPSILON)
            {
                throw new InvalidOperationException("Left Magnitude was less than epsilon");
            }

            if (!RealMath.ValidReadlVector3dAxes3(forwardReference, leftReference, up))
            {
                throw new InvalidOperationException("Invalid vector axes");
            }
        }

        public static float ReadQuantizedReal(BitStream stream, float minValue, float maxValue, int bitCount, bool exactMidPoint, bool exactEndPoints)
        {
            int value = (int)stream.ReadUnsigned(bitCount);
            return RealMath.DequantizeReal(value, minValue, maxValue, bitCount, exactMidPoint);
        }

        public static float ReadQuantizedRealWithEndPoints(BitStream stream, float minValue, float maxValue, int bitCount, bool exactMidPoint, bool exactEndPoints)
        {
            var value = (int)stream.ReadUnsigned(bitCount);
            return RealMath.DequantizeRealWithEndPoints(value, minValue, maxValue, bitCount, exactMidPoint, exactEndPoints);
        }

        public byte[] ReadBytes(int count)
        {
            var Buffer = new byte[count];
            for (int index = 0; index < count; index++)
                Buffer[index] = (byte)ReadUnsigned(8);
            return Buffer;
        }

        public string ReadUnicodeString(int length, bool packed = true)
        {
            var buffer = new StringBuilder(length);
            while (length > 0)
            {
                ushort b = (ushort)ReadUnsigned(16);

                if (packed)
                {
                    if (b == 0)
                        break;
                }

                if (b != 0)
                    buffer.Append(Convert.ToChar(b));

                length--;
            }
            return buffer.ToString();
        }

        public string ReadString(int length, bool packed = true)
        {
            var buffer = new StringBuilder(length);
            while (length > 0)
            {
                byte b = (byte)ReadUnsigned(8);

                if (packed)
                {
                    if (b == 0)
                        break;
                }

                if (b != 0)
                    buffer.Append(Convert.ToChar(b));

                length--;
            }
            return buffer.ToString();
        }

        public bool ReadBool()
        {
            return ReadUnsigned(1) != 0;
        }

        public float ReadFloat(int bits)
        {
            // TODO: Make not ass
            return BitConverter.ToSingle(BitConverter.GetBytes(ReadUnsigned(bits)), 0);
        }

        public uint ReadUnsigned(int bits)
        {
            if (bits > QWORD_BITS - _accumulatorBitsUsed)
            {
                return (uint)ReadIntoAccumulator(bits);
            }
            else
            {
                uint value = (uint)(_accumulator >> (QWORD_BITS - bits));
                _accumulator <<= bits;
                _accumulatorBitsUsed += bits;
                return value;
            }
        }

        public ulong ReadUnsigned64(int bits)
        {
            if (bits > QWORD_BITS - _accumulatorBitsUsed)
            {
                return ReadIntoAccumulator(bits);
            }
            else
            {
                ulong value = _accumulator >> (QWORD_BITS - bits);
                _accumulator <<= bits;
                _accumulatorBitsUsed += bits;
                return value;
            }
        }

        private ulong ReadIntoAccumulator(int sizeInBits)
        {
            ulong oldAccumulator = _accumulator;
            ulong newAccumulator = DecodeAccumulator();
            int nextBits = _accumulatorBitsUsed + sizeInBits - QWORD_BITS;
            _accumulator = nextBits < QWORD_BITS ? newAccumulator << nextBits : 0;
            _accumulatorBitsUsed = nextBits;
            ulong carry = oldAccumulator >> (QWORD_BITS - sizeInBits);
            ulong value = newAccumulator >> (QWORD_BITS - nextBits);
            return carry | value;
        }

        private ulong DecodeAccumulator()
        {
            ulong acc = 0;
            if (_reader.Position + 8 > _reader.Length)
            {
                int shiftBits = 0;
                while (_reader.Position < _reader.Length)
                {
                    shiftBits += 8;
                    acc <<= 8;
                    acc |= _reader.ReadByte();
                }
                acc <<= (QWORD_BITS - shiftBits);
            }
            else
            {
                acc = _reader.ReadUInt64();
            }

            return acc;
        }
    }
}
