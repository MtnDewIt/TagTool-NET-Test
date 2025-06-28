using System;

namespace TagTool.Common
{
    public class RealMath
    {
        // TODO: Look into consolidating reach specific functions (Gotta wait until someone smarter than me delves more into reach variants)

        public const float WORLD_UNITS_TO_INCHES = 10.0f * 12.0f;
        public const float INCHES_TO_WORLD_UNITS = 1.0f / WORLD_UNITS_TO_INCHES;

        public const float TEST_REAL_EPSILON = 0.001f;
        public const float REAL_EPSILON = 0.0001f;
        public const float REAL_PI = 3.1415927f;

        public static readonly RealVector3d GLOBAL_UP = new RealVector3d(0.0f, 0.0f, 1.0f);
        public static readonly RealVector3d GLOBAL_FORWARD = new RealVector3d(1.0f, 0.0f, 0.0f);
        public static readonly RealVector3d GLOBAL_LEFT = new RealVector3d(0.0f, 1.0f, 0.0f);

        public static readonly int[][] UNIT_VECTOR_QUANTIZATION_TABLE =
        [
            [0xA, 0x2],
            [0x15, 0x3],
            [0x2A, 0x5],
            [0x55, 0x8],
            [0xAA, 0xC],
            [0x155, 0x11],
            [0x2AA, 0x19],
            [0x555, 0x23],
            [0xAAA, 0x33],
            [0x1555, 0x48],
            [0x2AAA, 0x67],
            [0x5555, 0x92],
            [0xAAAA, 0xD0],
            [0x15555, 0x126],
            [0x2AAAA, 0x1A1],
            [0x55555, 0x24E],
            [0xAAAAA, 0x343],
            [0x155555, 0x49D],
            [0xAAAAAA, 0x687],
            [0x555555, 0x93B],
            [0x2AAAAAA, 0x1A1F],
            [0x5555555, 0x24F4],
            [0xAAAAAAA, 0x3440],
        ];

        public static float SafeDiv(float x, float y) => y == 0 ? 0.0f : x / y;

        public static float SafeRcp(float x) => x == 0 ? 0.0f : 1.0f / x;

        public unsafe static RealPoint3d ReadQuantizedPosition(BitStream stream, int axisEncodingSizeInBits, RealRectangle3d worldBounds)
        {
            var point = stackalloc int[3]
            {
                (int)stream.ReadUnsigned(axisEncodingSizeInBits),
                (int)stream.ReadUnsigned(axisEncodingSizeInBits),
                (int)stream.ReadUnsigned(axisEncodingSizeInBits),
            };

            return DequantizeRealPoint3d(point, worldBounds, axisEncodingSizeInBits);
        }

        public unsafe static RealPoint3d ReadQuantizedPositionPerAxis(BitStream stream, int axisEncodingSizeInBits, RealRectangle3d worldBounds)
        {
            var perAxisBitCounts = stackalloc int[3]
            {
                axisEncodingSizeInBits,
                axisEncodingSizeInBits,
                axisEncodingSizeInBits,
            };

            AdjustAxisEncodingBitCountToMatchErrorGoals(axisEncodingSizeInBits, worldBounds, 26, perAxisBitCounts);

            var point = stackalloc int[3]
            {
                (int)stream.ReadUnsigned(perAxisBitCounts[0]),
                (int)stream.ReadUnsigned(perAxisBitCounts[1]),
                (int)stream.ReadUnsigned(perAxisBitCounts[2]),
            };

            return DequantizeRealPoint3dPerAxis(point, worldBounds, perAxisBitCounts);
        }

        public unsafe static void AdjustAxisEncodingBitCountToMatchErrorGoals(int axisEncodingSizeInBits, RealRectangle3d bounds, int maxBitCount, int* perAxisBitCounts)
        {
            var dimensions = stackalloc float[3]
            {
                bounds.X1 - bounds.X0,
                bounds.Y1 - bounds.Y0,
                bounds.Z1 - bounds.Z0
            };

            float maxError = GetMaximumAxisError(axisEncodingSizeInBits);

            for (int axis = 0; axis < 3; axis++)
            {
                if (maxError < REAL_EPSILON)
                {
                    perAxisBitCounts[axis] = axisEncodingSizeInBits;
                }
                else
                {
                    int maxValue = (int)Math.Ceiling(dimensions[axis] / (maxError * 2.0f));

                    if (maxValue > 0x800000)
                        maxValue = 0x800000;

                    int requiredBits = (int)(Math.Ceiling(Math.Log(maxValue) / Math.Log(2)));

                    perAxisBitCounts[axis] = requiredBits > maxBitCount ? maxBitCount : requiredBits;
                }
            }

            return;
        }

        public static float GetMaximumAxisError(int axisEncodingSizeInBits)
        {
            return axisEncodingSizeInBits <= 16 ? INCHES_TO_WORLD_UNITS * (1 << (16 - axisEncodingSizeInBits)) : INCHES_TO_WORLD_UNITS / (1 << (axisEncodingSizeInBits - 16));
        }

        public unsafe static RealPoint3d DequantizeRealPoint3d(int* point, RealRectangle3d worldBounds, int axisEncodingSizeInBits)
        {
            var dequantizedPoint = new RealPoint3d
            {
                X = DequantizeReal(point[0], worldBounds.X0, worldBounds.X1, axisEncodingSizeInBits, false),
                Y = DequantizeReal(point[1], worldBounds.Y0, worldBounds.Y1, axisEncodingSizeInBits, false),
                Z = DequantizeReal(point[2], worldBounds.Z0, worldBounds.Z1, axisEncodingSizeInBits, false),
            };

            return dequantizedPoint;
        }

        public unsafe static RealPoint3d DequantizeRealPoint3dPerAxis(int* point, RealRectangle3d worldBounds, int* perAxisBitCounts)
        {
            var dequantizedPoint = new RealPoint3d
            {
                X = DequantizeRealWithEndPoints(point[0], worldBounds.X0, worldBounds.X1, perAxisBitCounts[0], false, false),
                Y = DequantizeRealWithEndPoints(point[1], worldBounds.Y0, worldBounds.Y1, perAxisBitCounts[1], false, false),
                Z = DequantizeRealWithEndPoints(point[2], worldBounds.Z0, worldBounds.Z1, perAxisBitCounts[2], false, false),
            };

            return dequantizedPoint;
        }

        public static RealVector3d RotateVectorAboutAxis(RealVector3d forward, RealVector3d up, float u, float v)
        {
            float v1 = (1.0f - v) * (((forward.I * up.I) + (forward.J * up.J)) + (forward.K * up.K));
            float v2 = (forward.K * up.I) - (forward.I * up.K);
            float v3 = (forward.I * up.J) - (forward.J * up.I);
            forward.I = ((v * forward.I) + (v1 * up.I)) - (u * ((forward.J * up.K) - (forward.K * up.J)));
            forward.J = ((v * forward.J) + (v1 * up.J)) - (u * v2);
            forward.K = ((v * forward.K) + (v1 * up.K)) - (u * v3);

            return forward;
        }

        public static float DequantizeReal(int quantized, float minValue, float maxValue, int sizeInBits, bool exactMidPoint)
        {
            if (sizeInBits <= 0)
            {
                throw new ArgumentException("Number of bits must be greater than zero");
            }

            if (maxValue <= minValue)
            {
                throw new ArgumentException("Maximum Value must be greater than Minimum Value");
            }

            if (exactMidPoint && sizeInBits <= 1)
            {
                throw new ArgumentException("Number of bits must be greater than 1 when exact mid point is enabled");
            }

            int stepCount = (1 << sizeInBits) - 1;

            if (exactMidPoint)
            {
                stepCount -= stepCount % 2;
            }

            if (stepCount <= 0)
            {
                throw new InvalidOperationException("Number of steps was less than or equal to zero");
            }

            float dequantized;

            if (quantized != 0)
            {
                if (quantized < stepCount)
                {
                    dequantized = (((stepCount - quantized) * minValue) + (quantized * maxValue)) / stepCount;
                }
                else
                {
                    dequantized = maxValue;
                }
            }
            else
            {
                dequantized = minValue;
            }

            if (exactMidPoint && 2 * quantized == stepCount)
            {
                if (dequantized != (minValue + maxValue) / 2.0f)
                {
                    throw new InvalidOperationException("Dequantized value must be equal to the exact mid point of Minimum Value and Maximum Value");
                }
            }

            return dequantized;
        }

        public static float DequantizeRealWithTable(int quantized, float minValue, float maxValue, int sizeInBits, bool exactMidPoint, bool exactEndPoints) 
        {
            if (sizeInBits <= 0)
            {
                throw new ArgumentException("Number of bits must be greater than zero");
            }

            if (maxValue <= minValue)
            {
                throw new ArgumentException("Maximum Value must be greater than Minimum Value");
            }

            if (exactMidPoint && sizeInBits <= 1)
            {
                throw new ArgumentException("Number of bits must be greater than 1 when exact mid point is enabled");
            }

            // This is a magic declaration which makes everything work nicely
            // This value could probably be derived from the quantized value
            // reach's dequantize functions are mysterious and confusing :/
            int stepCount = UNIT_VECTOR_QUANTIZATION_TABLE[sizeInBits - 6][1] - 1;

            if (exactMidPoint)
            {
                stepCount -= stepCount % 2;
            }

            if (stepCount <= 0)
            {
                throw new InvalidOperationException("Number of steps was less than or equal to zero");
            }

            float dequantized;

            if (exactEndPoints) 
            {
                if (quantized != 0)
                {
                    if (quantized < stepCount)
                    {
                        float step = (maxValue - minValue) / (stepCount - 2);
                        dequantized = (((quantized - 1) * step) + minValue) + (step / 2.0f);
                    }
                    else
                    {
                        dequantized = maxValue;
                    }
                }
                else
                {
                    dequantized = minValue;
                }
            }
            else
            {
                float step = (maxValue - minValue) / stepCount;
                dequantized = ((quantized * step) + minValue) + (step / 2.0f);
            }

            if (exactMidPoint && 2 * quantized == stepCount - 1)
            {
                if (dequantized != (minValue + maxValue) / 2.0f)
                {
                    throw new InvalidOperationException("Dequantized value must be equal to the exact mid point of Minimum Value and Maximum Value");
                }
            }

            return dequantized;
        }

        public static float DequantizeRealWithEndPoints(int quantized, float minValue, float maxValue, int sizeInBits, bool exactMidPoint, bool exactEndPoints)
        {
            if (sizeInBits <= 0)
            {
                throw new ArgumentException("Number of bits must be greater than zero");
            }

            if (maxValue <= minValue)
            {
                throw new ArgumentException("Maximum Value must be greater than Minimum Value");
            }

            if (exactMidPoint && sizeInBits <= 1)
            {
                throw new ArgumentException("Number of bits must be greater than 1 when exact mid point is enabled");
            }

            int stepCount = (1 << sizeInBits);

            if (exactMidPoint)
            {
                stepCount -= stepCount % 2;
            }

            if (stepCount <= 0)
            {
                throw new InvalidOperationException("Number of steps was less than or equal to zero");
            }

            float dequantized;

            if (exactEndPoints)
            {
                if (quantized != 0)
                {
                    if (quantized < stepCount)
                    {
                        float step = (maxValue - minValue) / (stepCount - 2);
                        dequantized = (((quantized - 1) * step) + minValue) + (step / 2.0f);
                    }
                    else
                    {
                        dequantized = maxValue;
                    }
                }
                else
                {
                    dequantized = minValue;
                }
            }
            else
            {
                float step = (maxValue - minValue) / stepCount;
                dequantized = ((quantized * step) + minValue) + (step / 2.0f);
            }

            if (exactMidPoint && 2 * quantized == stepCount - 1)
            {
                if (dequantized != (minValue + maxValue) / 2.0f)
                {
                    throw new InvalidOperationException("Dequantized value must be equal to the exact mid point of Minimum Value and Maximum Value");
                }
            }

            return dequantized;
        }

        public static float Magnitude3d(RealVector3d vector)
        {
            return (float)Math.Sqrt(RealVector3d.Magnitude(vector));
        }

        public static RealVector3d ScaleVector3d(RealVector3d vector, float scale)
        {
            vector.I *= scale;
            vector.J *= scale;
            vector.K *= scale;

            return vector;
        }

        public static float Normalize3d(RealVector3d vector, out RealVector3d output)
        {
            float result = Magnitude3d(vector);

            if (Math.Abs(result) >= REAL_EPSILON)
            {
                float scale = 1.0f / result;
                output = ScaleVector3d(vector, scale);
            }
            else
            {
                output = vector;
                result = 0.0f;
            }

            return result;
        }

        public static void DequantizeUnitVector3d(int value, int bitCount, out RealVector3d vector)
        {
            int face = value & 7;
            float x = DequantizeReal((value >> 3) & 0xFF, -1.0f, 1.0f, bitCount, true);
            float y = DequantizeReal((value >> 11) & 0xFF, -1.0f, 1.0f, bitCount, true);

            switch (face)
            {
                case 0:
                    vector = new RealVector3d(1.0f, x, y);
                    break;
                case 1:
                    vector = new RealVector3d(x, 1.0f, y);
                    break;
                case 2:
                    vector = new RealVector3d(x, y, 1.0f);
                    break;
                case 3:
                    vector = new RealVector3d(-1.0f, x, y);
                    break;
                case 4:
                    vector = new RealVector3d(x, -1.0f, y);
                    break;
                case 5:
                    vector = new RealVector3d(x, y, -1.0f);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid face value {face} when reading unit vector");
            }

            Normalize3d(vector, out vector);
        }

        public static void DequantizeUnitVector3dWithTable(int value, int bitCount, out RealVector3d vector)
        {
            int bitPattern = UNIT_VECTOR_QUANTIZATION_TABLE[bitCount - 6][0];
            int patternSqrt = UNIT_VECTOR_QUANTIZATION_TABLE[bitCount - 6][1];

            int face = value / bitPattern;

            int quantizedX = (value % bitPattern) / patternSqrt;
            int quantizedY = (value % bitPattern) % patternSqrt;

            float x = DequantizeRealWithTable(quantizedX, -1.0f, 1.0f, bitCount, false, false);
            float y = DequantizeRealWithTable(quantizedY, -1.0f, 1.0f, bitCount, false, false);

            switch (face)
            {
                case 0:
                    vector = new RealVector3d(1.0f, x, y);
                    break;
                case 1:
                    vector = new RealVector3d(x, 1.0f, y);
                    break;
                case 2:
                    vector = new RealVector3d(x, y, 1.0f);
                    break;
                case 3:
                    vector = new RealVector3d(-1.0f, x, y);
                    break;
                case 4:
                    vector = new RealVector3d(x, -1.0f, y);
                    break;
                case 5:
                    vector = new RealVector3d(x, y, -1.0f);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid face value ? when reading unit vector");
            }

            Normalize3d(vector, out vector);
        }

        public static bool ValidReal(float value)
        {
            return !float.IsInfinity(value) && !float.IsNaN(value);
        }

        public static bool ValidRealComparison(float a1, float a2)
        {
            return ValidReal(a1 - a2) && Math.Abs(a1 - a2) < TEST_REAL_EPSILON;
        }

        public static bool ValidRealVector(RealVector3d vector)
        {
            var squaredLength = RealVector3d.Magnitude(vector) - 1.0f;

            if (float.IsNaN(squaredLength) || float.IsInfinity(squaredLength))
            {
                return false;
            }

            return Math.Abs(squaredLength) < TEST_REAL_EPSILON;
        }

        public static bool ValidReadlVector3dAxes2(RealVector3d forward, RealVector3d up)
        {
            return ValidRealVector(forward)
                && ValidRealVector(up)
                && ValidRealComparison(RealVector3d.DotProduct(forward, up), 0.0f);
        }

        public static bool ValidReadlVector3dAxes3(RealVector3d forward, RealVector3d left, RealVector3d up)
        {
            return ValidRealVector(forward)
                && ValidRealVector(left)
                && ValidRealVector(up)
                && ValidRealComparison(RealVector3d.DotProduct(forward, left), 0.0f)
                && ValidRealComparison(RealVector3d.DotProduct(left, up), 0.0f)
                && ValidRealComparison(RealVector3d.DotProduct(forward, up), 0.0f);
        }
    }
}
