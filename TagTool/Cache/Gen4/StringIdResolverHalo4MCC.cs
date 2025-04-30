using TagTool.Common;

namespace TagTool.Cache
{
    /// <summary>
    /// StringID resolver for Halo 4 MCC. 
    /// Halo 4 StringId are 5-8-19 (length-set-index) format instead of (8-8-16)
    /// </summary>
    public class StringIdResolverHalo4MCC : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x20EC, 0x633, 0xEB0, 0xFBB, 0x1048, 0x1140, 0x1195, 0x11C0, 0x1CBE, 0x1ECF, 0x1F02, 0x1F85, 0x1FB9, 0x1FC6, 0x2008 };
        private const int SetMin = 0x633; // Mininum index that goes in a set
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