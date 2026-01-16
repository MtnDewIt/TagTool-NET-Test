namespace TagTool.Cache.MCC.Resolvers
{
    /// <summary>
    /// StringID resolver for Halo 3 MCC Xbox One (Oct  1 2014 16:20:07)
    /// </summary>
    public class StringIdResolverHalo3XboxOneA : StringIdResolver
    {
        // These values were figured out through trial-and-error
        private static readonly int[] SetOffsets = { 0xC57, 0x4BB, 0xAB9, 0xB4B, 0xBED, 0xBA1, 0xBFD, 0xC36, 0xC4A };
        private const int SetMin = 0x4BB;   // Mininum index that goes in a set
        private const int SetMax = 0xFFFF; // Maximum index that goes in a set

        public StringIdResolverHalo3XboxOneA()
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
