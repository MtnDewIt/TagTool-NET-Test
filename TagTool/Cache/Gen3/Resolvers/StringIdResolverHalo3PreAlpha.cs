using TagTool.Common;

namespace TagTool.Cache.Gen3.Resolvers
{
    /// <summary>
    /// StringID resolver for Halo 3 Alpha.
    /// </summary>
    public class StringIdResolverHalo3PreAlpha : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x8A1, 0x73B, 0x879, 0x889, 0x89C };
        private const int SetMin = 0x73B;   // Mininum index that goes in a set
        private const int SetMax = 0xFFFF; // Maximum index that goes in a set

        public StringIdResolverHalo3PreAlpha()
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
