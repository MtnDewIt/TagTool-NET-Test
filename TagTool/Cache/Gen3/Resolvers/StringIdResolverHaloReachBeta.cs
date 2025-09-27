using TagTool.Common;

namespace TagTool.Cache.Gen3.Resolvers
{
    /// <summary>
    /// StringID resolver for Halo Reach Beta. Halo Reach Beta StringId are 7-8-17 (length-set-index) format instead of (8-8-16)
    /// </summary>
    public class StringIdResolverHaloReachBeta: StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x13F3, 0x464, 0xA28, 0xAD2, 0xB37, 0xC0C, 0xC31, 0xC36, 0x11BE, 0x1302, 0x1311, 0x136D, 0x1385, 0x1392, 0x13B9 };
        private const int SetMin = 0x464;   // Mininum index that goes in a set
        private const int SetMax = 0x1FFFF; // Maximum index that goes in a set

        public StringIdResolverHaloReachBeta()
        {
            LengthBits = 8;
            SetBits = 8;
            IndexBits = 16;
        }

        public override int GetMinSetStringIndex()
        {
            return SetMin;
        }

        public override int GetMaxSetStringIndex()
        {
            return SetMax;
        }

        public override int[] GetSetOffsets()
        {
            return SetOffsets;
        }
    }
}
