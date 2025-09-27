using TagTool.Common;

namespace TagTool.Cache.Gen3.Resolvers
{
    /// <summary>
    /// StringID resolver for Halo Reach Alpha. Halo Reach Alpha StringId are 7-8-17 (length-set-index) format instead of (8-8-16)
    /// </summary>
    public class StringIdResolverHaloReachAlpha : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x1327, 0x453, 0x9FD, 0xAA4, 0xB07, 0xBDC, 0xBFE, 0xC03, 0x1102, 0x1237, 0x1245, 0x12A1, 0x12B9, 0x12C6, 0x12E8 };
        private const int SetMin = 0x453;   // Mininum index that goes in a set
        private const int SetMax = 0x1FFFF; // Maximum index that goes in a set

        public StringIdResolverHaloReachAlpha()
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
