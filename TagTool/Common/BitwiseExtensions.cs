namespace TagTool.Common
{
    public static class BitwiseExtensions
    {
        /// <summary>
        /// Extracts <paramref name="count"/> bits from a 32-bit unsigned integer starting at <paramref name="offset"/>
        /// </summary>
        public static uint Bits(this uint value, int offset, int count)
        {
            uint mask = (1U << count) - 1;
            mask <<= offset;

            return (value & mask) >> offset;
        }

        /// <summary>
        /// Extracts <paramref name="count"/> bits from a 64-bit unsigned integer starting at <paramref name="offset"/>
        /// </summary>
        public static ulong Bits(this ulong value, int offset, int count)
        {
            ulong mask = (1UL << count) - 1;
            mask <<= offset;

            return (value & mask) >> offset;
        }
    }
}
