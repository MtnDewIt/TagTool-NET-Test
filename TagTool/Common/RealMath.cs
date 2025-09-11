using System;

namespace TagTool.Common
{
    public class RealMath
    {
        public const float TEST_REAL_EPSILON = 0.001f;
        public const float REAL_EPSILON = 0.0001f;
        public const float REAL_PI = 3.1415927f;

        public static readonly RealVector3d GLOBAL_UP = new RealVector3d(0.0f, 0.0f, 1.0f);
        public static readonly RealVector3d GLOBAL_FORWARD = new RealVector3d(1.0f, 0.0f, 0.0f);
        public static readonly RealVector3d GLOBAL_LEFT = new RealVector3d(0.0f, 1.0f, 0.0f);

        public static float SafeDiv(float x, float y) => y == 0 ? 0.0f : x / y;

        public static float SafeRcp(float x) => x == 0 ? 0.0f : 1.0f / x;

        public static void DequantizeRealPoint3d(Int32Point3d point, RealRectangle3d worldBounds, int axisEncodingSizeInBits, out RealPoint3d dequantizedPoint)
        {
            // TODO: Add Assert

            dequantizedPoint = new RealPoint3d
            {
                X = DequantizeReal(point.X, worldBounds.X0, worldBounds.X1, axisEncodingSizeInBits, false, true),
                Y = DequantizeReal(point.Y, worldBounds.Y0, worldBounds.Y1, axisEncodingSizeInBits, false, true),
                Z = DequantizeReal(point.Z, worldBounds.Z0, worldBounds.Z1, axisEncodingSizeInBits, false, true),
            };
        }

        public static void DequantizeRealPoint3dPerAxis(Int32Point3d quantized, RealRectangle3d bounds, Int32Point3d bits, out RealPoint3d position, bool exactMidPoints, bool exactEndPoints) 
        {
            if (bits.X > 32 && bits.Y > 32 && bits.Z > 32) 
            {
                throw new ArgumentException("Number of bits exceeded maximum value");
            }

            position = new RealPoint3d
            {
                X = DequantizeReal(quantized.X, bounds.X0, bounds.X1, bits.X, exactMidPoints, exactEndPoints),
                Y = DequantizeReal(quantized.Y, bounds.Y0, bounds.Y1, bits.Y, exactMidPoints, exactEndPoints),
                Z = DequantizeReal(quantized.Z, bounds.Z0, bounds.Z1, bits.Z, exactMidPoints, exactEndPoints),
            };
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

        public static float DequantizeReal(int quantized, float minValue, float maxValue, int sizeInBits, bool exactMidPoint, bool exactEndPoints)
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

            if (exactEndPoints)
            {
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
            }
            else 
            {
                float step = (maxValue - minValue) / stepCount;

                if (step <= 0.0f) 
                {
                    throw new ArgumentException("Step must be greater than zero");
                }

                dequantized = ((quantized * step) + minValue) + (step / 2.0f);
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

        public static float DequantizeReal(int quantized, float minValue, float maxValue, uint quantizedValueCount, bool exactMidPoint, bool exactEndPoints)
        {
            if (quantizedValueCount <= 3) 
            {
                throw new ArgumentException("Quantized Value Count must be greater than 3");
            }

            if (maxValue <= minValue)
            {
                throw new ArgumentException("Maximum Value must be greater than Minimum Value");
            }

            float dequantized;

            if (exactEndPoints)
            {
                if (quantized != 0)
                {
                    if (quantized < quantizedValueCount)
                    {
                        dequantized = (((quantizedValueCount - quantized) * minValue) + (quantized * maxValue)) / quantizedValueCount;
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
                float step = (maxValue - minValue) / quantizedValueCount;

                if (step <= 0.0f)
                {
                    throw new ArgumentException("Step must be greater than zero");
                }

                dequantized = ((quantized * step) + minValue) + (step / 2.0f);
            }

            if (exactMidPoint && 2 * quantized == quantizedValueCount)
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

        public static void DequantizeUnitVector3d(int value, out RealVector3d vector, int bitCount) 
        {
            UnitVectorQuantization.EncodingConstants encodingConstants = UnitVectorQuantization.GetUnitVectorEncodingConstants(bitCount);

            int face = Math.Max(0, (int)((float)value / encodingConstants.ActualPerAxisMaxCount));
            float quantizedX = (float)(value % (int)encodingConstants.ActualPerAxisMaxCount) / encodingConstants.QuantizedValueCount;
            float quantizedY = (float)(value % (int)encodingConstants.ActualPerAxisMaxCount) % encodingConstants.QuantizedValueCount;

            float x = DequantizeReal((int)quantizedX, -1.0f, 1.0f, encodingConstants.QuantizedValueCount, true, false);
            float y = DequantizeReal((int)quantizedY, -1.0f, 1.0f, encodingConstants.QuantizedValueCount, true, false);

            vector = face switch
            {
                0 => new RealVector3d(1.0f, x, y),
                1 => new RealVector3d(x, 1.0f, y),
                2 => new RealVector3d(x, y, 1.0f),
                3 => new RealVector3d(-1.0f, x, y),
                4 => new RealVector3d(x, -1.0f, y),
                5 => new RealVector3d(x, y, -1.0f),
                _ => throw new InvalidOperationException($"Invalid face value {face} when reading unit vector"),
            };

            Normalize3d(vector, out vector);
        }

        public static void DequantizeUnitVector3d(int value, out RealVector3d vector)
        {
            int face = value & 7;
            float x = DequantizeReal((value >> 3) & 0xFF, -1.0f, 1.0f, 8, false, true);
            float y = DequantizeReal((value >> 11) & 0xFF, -1.0f, 1.0f, 8, false, true);

            vector = face switch
            {
                0 => new RealVector3d(1.0f, x, y),
                1 => new RealVector3d(x, 1.0f, y),
                2 => new RealVector3d(x, y, 1.0f),
                3 => new RealVector3d(-1.0f, x, y),
                4 => new RealVector3d(x, -1.0f, y),
                5 => new RealVector3d(x, y, -1.0f),
                _ => throw new InvalidOperationException($"Invalid face value {face} when reading unit vector"),
            };

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
