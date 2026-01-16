namespace TagTool.Cache.MCC.Resolvers
{
    /// <summary>
    /// StringID resolver for Halo 3 MCC Xbox One (Oct 30 2014 19:01:55)
    /// </summary>
    public class StringIdResolverHalo3XboxOneB : StringIdResolver
    {
        // These values were figured out through trial-and-error
        private static readonly int[] SetOffsets = { 0xC58, 0x4BB, 0xABA, 0xB4C, 0xBEE, 0xBA2, 0xBFE, 0xC37, 0xC4B };
        private const int SetMin = 0x4BB;   // Mininum index that goes in a set
        private const int SetMax = 0xFFFF; // Maximum index that goes in a set

        public StringIdResolverHalo3XboxOneB()
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
