using TagTool.Common;

namespace TagTool.Cache
{
    /// <summary>
    /// StringID resolver for Halo 4 MCC. 
    /// Halo 4 StringId are 5-8-19 (length-set-index) format instead of (8-8-16)
    /// </summary>
    public class StringIdResolverHalo4MCC : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x20E0, 0x631, 0xEA8, 0xFB3, 0x1040, 0x1138, 0x118D, 0x11B8, 0x1CB4, 0x1EC4, 0x1EF7, 0x1F7A, 0x1FAE, 0x1FBB, 0x1FFD };
        private const int SetMin = 0x631; // Mininum index that goes in a set
        private const int SetMax = 0x7FFFF; // Maximum index that goes in a set

        public StringIdResolverHalo4MCC()
        {
            LengthBits = 5;
            SetBits = 8;
            IndexBits = 19;
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