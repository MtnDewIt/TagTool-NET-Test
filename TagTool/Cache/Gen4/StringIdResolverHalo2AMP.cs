using TagTool.Common;

namespace TagTool.Cache
{
    /// <summary>
    /// StringID resolver for Halo 2 Anniversary Multiplayer. 
    /// Halo 2 Anniversary Multiplayer StringId are 5-8-19 (length-set-index) format instead of (8-8-16)
    /// </summary>
    public class StringIdResolverHalo2AMP : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x212B, 0x635, 0xED1, 0xFDC, 0x1069, 0x1161, 0x11B6, 0x11E1, 0x1CF2, 0x1F05, 0x1F39, 0x1FBC, 0x1FF0, 0x1FFD, 0x203F };
        private const int SetMin = 0x635; // Mininum index that goes in a set
        private const int SetMax = 0x7FFFF; // Maximum index that goes in a set

        public StringIdResolverHalo2AMP()
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