using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagTool.Cache.Gen4.Resolvers
{
    /// <summary>
    /// StringID resolver for Halo 4 E3. 
    /// Halo 4 E3 StringId are 5-8-19 (length-set-index) format instead of (8-8-16)
    /// </summary>
    public class StringIdResolverHalo4E3 : StringIdResolver
    {
        private static readonly int[] SetOffsets = { 0x1DAF, 0x5FE, 0xE02, 0xEE9, 0xF55, 0x1039, 0x1067, 0x107C, 0x1A4F, 0x1C29, 0x1C47, 0x1CAC, 0x1CC8, 0x1CD5, 0x1D03 };
        private const int SetMin = 0x5FE;   // Mininum index that goes in a set
        private const int SetMax = 0x7FFFF; // Maximum index that goes in a set

        public StringIdResolverHalo4E3()
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
