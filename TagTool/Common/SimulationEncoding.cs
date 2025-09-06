using System;

namespace TagTool.Common
{
    public class SimulationEncoding
    {
        public const float WORLD_UNITS_TO_INCHES = 10.0f * 12.0f;
        public const float INCHES_TO_WORLD_UNITS = 1.0f / WORLD_UNITS_TO_INCHES;

        public static void AdjustAxisEncodingBitCountToMatchErrorGoals(int bitCount, RealRectangle3d bounds, int maxBitCount, out Int32Point3d perAxisBitCounts) 
        {
            RealPoint3d dimensions = new()
            {
                X = bounds.X1 - bounds.X0,
                Y = bounds.Y1 - bounds.Y0,
                Z = bounds.Z1 - bounds.Z0
            };

            perAxisBitCounts = new Int32Point3d
            {
                X = bitCount,
                Y = bitCount,
                Z = bitCount,
            };

            float maxError;

            if (bitCount <= 16)
            {
                maxError = INCHES_TO_WORLD_UNITS * (1 << (16 - bitCount));
            }
            else 
            {
                maxError = INCHES_TO_WORLD_UNITS / (1 << (bitCount - 16));
            }

            int maxValueX = Math.Min((int)Math.Ceiling(dimensions.X / (maxError * 2.0f)), 0x800000);
            int requiredBitsX = (int)Math.Ceiling(Math.Log(maxValueX) / Math.Log(2.0f));
            perAxisBitCounts.X = Math.Min(requiredBitsX, maxBitCount);

            int maxValueY = Math.Min((int)Math.Ceiling(dimensions.Y / (maxError * 2.0f)), 0x800000);
            int requiredBitsY = (int)Math.Ceiling(Math.Log(maxValueY) / Math.Log(2.0f));
            perAxisBitCounts.Y = Math.Min(requiredBitsY, maxBitCount);

            int maxValueZ = Math.Min((int)Math.Ceiling(dimensions.Z / (maxError * 2.0f)), 0x800000);
            int requiredBitsZ = (int)Math.Ceiling(Math.Log(maxValueZ) / Math.Log(2.0f));
            perAxisBitCounts.Z = Math.Min(requiredBitsZ, maxBitCount);
        }

        public static void SimulationReadPosition(BitStream stream, out RealPoint3d position, int axisEncodingSizeInBits, bool exactMidPoints, bool exactEndPoints, RealRectangle3d worldBounds) 
        {
            if (stream.ReadBool())
            {
                AdjustAxisEncodingBitCountToMatchErrorGoals(axisEncodingSizeInBits, worldBounds, 26, out Int32Point3d perAxisBitCounts);

                Int32Point3d quantizedPoint = new()
                {
                    X = (int)stream.ReadUnsigned(perAxisBitCounts.X),
                    Y = (int)stream.ReadUnsigned(perAxisBitCounts.Y),
                    Z = (int)stream.ReadUnsigned(perAxisBitCounts.Z),
                };

                RealMath.DequantizeRealPoint3dPerAxis(quantizedPoint, worldBounds, perAxisBitCounts, out position, exactMidPoints, exactEndPoints);
            }
            else 
            {
                throw new InvalidOperationException("Tried to read a position outside of world bounds! Fallback behaviour is only supported in-engine.");
            }
        }

        public static void SimulationReadQuantizedPosition(BitStream stream, out RealPoint3d position, int axisEncodingSizeInBits, RealRectangle3d worldBounds) 
        {
            stream.ReadPoint3d(out Int32Point3d point, axisEncodingSizeInBits);
            RealMath.DequantizeRealPoint3d(point, worldBounds, axisEncodingSizeInBits, out position);
        }
    }
}
