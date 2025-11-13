using TagTool.Common;

namespace TagTool.Cache.Gen3.Resolvers
{
    /// <summary>
    /// StringID resolver for Halo 3 Alpha.
    /// </summary>
    public class StringIdResolverHalo3Alpha : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x944, 0x754, 0x8E6, 0x8FE, 0x911, 0x91D };
        private const int SetMin = 0x754;   // Mininum index that goes in a set
        private const int SetMax = 0xFFFF; // Maximum index that goes in a set

        public StringIdResolverHalo3Alpha()
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
