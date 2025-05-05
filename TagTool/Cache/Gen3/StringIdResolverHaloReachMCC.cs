using System.Security.Cryptography;

namespace TagTool.Cache
{
    /// <summary>
    /// StringID resolver for Halo Reach MCC. Halo Reach MCC Convert th StringId are 7-8-17 (length-set-index) format instead of (8-8-16)
    /// </summary>
    public class StringIdResolverHaloReachMCC : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x1755, 0x4CA, 0xB3C, 0xC15, 0xC81, 0xD5A, 0xD82, 0xD87, 0x1447, 0x15B9, 0x15D0, 0x1632, 0x1632, 0x164A, 0x1657, 0x1680, 0x16E2 };
        private const int SetMin = 0x4CA;   // Mininum index that goes in a set
        private const int SetMax = 0x1FFFF; // Maximum index that goes in a set

        public StringIdResolverHaloReachMCC()
        {
            LengthBits = 7;
            SetBits = 8;
            IndexBits = 17;
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