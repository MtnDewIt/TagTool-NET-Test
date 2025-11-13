using TagTool.Common;

namespace TagTool.Cache.Gen3.Resolvers
{
    /// <summary>
    /// StringID resolver for Halo 3 March 7 Delta.
    /// </summary>
    public class StringIdResolverHalo3March7Delta : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x8BB, 0x4B8, 0x7F1, 0x828, 0x87E, 0x84A, 0x88E };
        private const int SetMin = 0x4B8;   // Mininum index that goes in a set
        private const int SetMax = 0xFFFF; // Maximum index that goes in a set

        public StringIdResolverHalo3March7Delta()
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
