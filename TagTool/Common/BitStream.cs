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

        public void ReadAxisReach(int forwardBits, int upBits, out RealVector3d forward, out RealVector3d up) 
        {
            if (ReadBool())
            {
                up = RealMath.GLOBAL_UP;
            }
            else 
            {
                int quantized = ReadSignedInteger(upBits);
                RealMath.DequantizeUnitVector3dReach(quantized, out up, 20);
            }

            float forwardAngle = ReadQuantizedReal(-RealMath.REAL_PI, RealMath.REAL_PI, forwardBits, false, false);
            AngleToAxesInternal(up, forwardAngle, out forward);
        }

        public void ReadAxis(out RealVector3d forward, out RealVector3d up)
        {
            if (ReadBool())
            {
                up = RealMath.GLOBAL_UP;
            }
            else
            {
                int quantized = ReadSignedInteger(19);
                RealMath.DequantizeUnitVector3d(quantized, out up);
            }

            float forwardAngle = ReadQuantizedReal(-RealMath.REAL_PI, RealMath.REAL_PI, 8, true, true);
            AngleToAxesInternal(up, forwardAngle, out forward);
        }

        public static void AngleToAxesInternal(RealVector3d up, float angle, out RealVector3d forward)
        {
            AxesComputeReferenceInternal(up, out RealVector3d forwardReference, out RealVector3d leftReference);

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

        public static void AxesComputeReferenceInternal(RealVector3d up, out RealVector3d forwardReference, out RealVector3d leftReference)
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

        public float ReadQuantizedReal(float minValue, float maxValue, int bitCount, bool exactMidPoint, bool exactEndPoints)
        {
            int value = (int)ReadUnsigned(bitCount);
            return RealMath.DequantizeReal(value, minValue, maxValue, bitCount, exactMidPoint, exactEndPoints);
        }

        public byte[] ReadBytes(int count)
        {
            var Buffer = new byte[count];
            for (int index = 0; index < count; index++)
                Buffer[index] = (byte)ReadUnsigned(8);
            return Buffer;
        }

        public string ReadStringWchar(int length, bool packed = true)
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

        public string ReadStringUtf8(int length, bool packed = true)
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
            return ReadUnsigned(1) == 1;
        }

        public float ReadFloat(int bits)
        {
            // TODO: Make not ass
            return BitConverter.ToSingle(BitConverter.GetBytes(ReadUnsigned(bits)), 0);
        }

        public RealRectangle3d ReadRealRectangle3d(int bitCount) 
        {
            return new RealRectangle3d 
            {
                X0 = ReadFloat(bitCount),
                X1 = ReadFloat(bitCount),
                Y0 = ReadFloat(bitCount),
                Y1 = ReadFloat(bitCount),
                Z0 = ReadFloat(bitCount),
                Z1 = ReadFloat(bitCount),
            };
        }

        public int ReadIndex(int sizeInBits, int maxValue) 
        {
            if (ReadBool())
            {
                return -1;
            }
            else 
            {
                int value = (int)ReadUnsigned(sizeInBits);

                if (value > maxValue) 
                {
                    throw new ArgumentException("Number of bits exceeded maximum value");
                }

                return value;
            }
        }

        public int ReadSignedInteger(int sizeInBits) 
        {
            uint result = ReadUnsigned(sizeInBits);

            if (sizeInBits < 32 && (result & (1 << (sizeInBits - 1))) != 0)
            {
                result |= (uint)~((1 << sizeInBits) - 1);
            }

            return (int)result;
        }

        public void ReadPoint3d(out Int32Point3d point, int axisEncodingSizeInBits) 
        {
            if (0 >= axisEncodingSizeInBits || axisEncodingSizeInBits > 32) 
            {
                throw new ArgumentException("Number of bits must be greater than or equal to zero or less than or equal to 32");
            }

            point = new Int32Point3d
            {
                X = (int)ReadUnsigned(axisEncodingSizeInBits),
                Y = (int)ReadUnsigned(axisEncodingSizeInBits),
                Z = (int)ReadUnsigned(axisEncodingSizeInBits),
            };
        }

        public void ReadPoint3dEfficient(out Int32Point3d point, Int32Point3d axisEncodingSizeInBits) 
        {
            if ((0 >= axisEncodingSizeInBits.X || axisEncodingSizeInBits.X > 32) ||
                (0 >= axisEncodingSizeInBits.Y || axisEncodingSizeInBits.Y > 32) ||
                (0 >= axisEncodingSizeInBits.Z || axisEncodingSizeInBits.Z > 32))
            {
                throw new ArgumentException("Number of bits must be greater than or equal to zero or less than or equal to 32");
            }

            point = new Int32Point3d 
            {
                X = (int)ReadUnsigned(axisEncodingSizeInBits.X),
                Y = (int)ReadUnsigned(axisEncodingSizeInBits.Y),
                Z = (int)ReadUnsigned(axisEncodingSizeInBits.Z),
            };
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
