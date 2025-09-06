using System;

namespace TagTool.Common
{
    public class UnitVectorQuantization
    {
        public const int UNIT_VECTOR_QUANTIZATION_MINIMUM_BIT_COUNT = 6;
        public const int UNIT_VECTOR_QUANTIZATION_MAXIMUM_BIT_COUNT = 30;

        public static EncodingConstants[] UnitVectorGeneratedEncodingConstants =
        [
            EncodingConstants.Compute(6),
            EncodingConstants.Compute(7),
            EncodingConstants.Compute(8),
            EncodingConstants.Compute(9),
            EncodingConstants.Compute(10),
            EncodingConstants.Compute(11),
            EncodingConstants.Compute(12),
            EncodingConstants.Compute(13),
            EncodingConstants.Compute(14),
            EncodingConstants.Compute(15),
            EncodingConstants.Compute(16),
            EncodingConstants.Compute(17),
            EncodingConstants.Compute(18),
            EncodingConstants.Compute(19),
            EncodingConstants.Compute(20),
            EncodingConstants.Compute(21),
            EncodingConstants.Compute(22),
            EncodingConstants.Compute(23),
            EncodingConstants.Compute(24),
            EncodingConstants.Compute(25),
            EncodingConstants.Compute(26),
            EncodingConstants.Compute(27),
            EncodingConstants.Compute(28),
            EncodingConstants.Compute(29),
            EncodingConstants.Compute(30),
        ];

        public static EncodingConstants GetUnitVectorEncodingConstants(int bitCount) 
        {
            if (bitCount < UNIT_VECTOR_QUANTIZATION_MINIMUM_BIT_COUNT) 
            {
                throw new ArgumentException("Number of bits was below minimum value");
            }

            if (bitCount > UNIT_VECTOR_QUANTIZATION_MAXIMUM_BIT_COUNT) 
            {
                throw new ArgumentException("Number of bits exceeded maximum value");
            }

            return UnitVectorGeneratedEncodingConstants[bitCount - UNIT_VECTOR_QUANTIZATION_MINIMUM_BIT_COUNT];
        }

        public readonly struct EncodingConstants 
        {
            public uint QuantizedValueCount { get; }
            public uint ActualPerAxisMaxCount { get; }

            private EncodingConstants(uint quantizedValueCount, uint actualPerAxisMaxCount)
            {
                QuantizedValueCount = quantizedValueCount;
                ActualPerAxisMaxCount = actualPerAxisMaxCount;
            }

            public static EncodingConstants Compute(int bitCount) 
            {
                if (bitCount < UNIT_VECTOR_QUANTIZATION_MINIMUM_BIT_COUNT)
                {
                    throw new ArgumentException("Number of bits was below minimum value");
                }

                if (bitCount > UNIT_VECTOR_QUANTIZATION_MAXIMUM_BIT_COUNT)
                {
                    throw new ArgumentException("Number of bits exceeded maximum value");
                }

                int mask = 0;
                int index = 0;

                for (int bit = bitCount - 2; bit >= 0; bit--, index++) 
                {
                    if (index % 2 == 1) 
                    {
                        mask |= 1 << bit;
                    }
                }

                uint actualPerAxisMaxCount = (uint)mask;
                uint quantizedValueCount = (uint)(Math.Sqrt(mask) - 1);

                return new EncodingConstants(quantizedValueCount, actualPerAxisMaxCount);
            }
        }
    }
}
