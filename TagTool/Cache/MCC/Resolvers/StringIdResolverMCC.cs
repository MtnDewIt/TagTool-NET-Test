using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.Cache.MCC.Resolvers
{
    public class StringIdResolverMCC : StringIdResolver
    {
        private readonly int[] SetOffsets;
        private readonly int SetMin;   // Mininum index that goes in a set
        private readonly int SetMax = 0x7FFFF; // Maximum index that goes in a set

        public StringIdResolverMCC(EndianReader reader, CacheFileSectionTable sectionTable, int namespaceCount, uint namespaceOffset)
        {
            LengthBits = 5;
            SetBits = 8;
            IndexBits = 19;
            SetOffsets = ReadSetOffsets(reader, sectionTable, namespaceCount, namespaceOffset);
            SetMin = SetOffsets?.Length > 1 ? SetOffsets[1] : 0;
        }

        private int[] ReadSetOffsets(EndianReader reader, CacheFileSectionTable sectionTable, int namespaceCount, uint namespaceOffset)
        {
            if (sectionTable == null || namespaceCount == 0 || namespaceOffset == 0)
                return Array.Empty<int>();

            List<int> offsetList = new List<int>();
            uint namespacesOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, namespaceOffset);
            reader.SeekTo(namespacesOffset);
            int current = 0;
            for (int i = 0; i < namespaceCount; i++)
            {
                current += reader.ReadInt32();
                offsetList.Add(current);
            }

            var prepend = offsetList.Last();
            offsetList.RemoveAt(offsetList.Count - 1);
            offsetList.Insert(0, prepend);

            return offsetList.ToArray();
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