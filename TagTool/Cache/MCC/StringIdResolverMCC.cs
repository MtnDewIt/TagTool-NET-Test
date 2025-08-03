using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Common;
using TagTool.IO;

namespace TagTool.Cache
{
    public class StringIdResolverMCC : StringIdResolver
    {
        private readonly int[] SetOffsets;
        private readonly int SetMin;   // Mininum index that goes in a set
        private readonly int SetMax = 0x7FFFF; // Maximum index that goes in a set

        public StringIdResolverMCC(EndianReader reader, StringIDHeader stringIDheader, CacheFileSectionTable sectionTable)
        {
            LengthBits = 5;
            SetBits = 8;
            IndexBits = 19;
            SetOffsets = ReadSetOffsets(reader, stringIDheader, sectionTable);
            SetMin = SetOffsets?.Length > 1 ? SetOffsets[1] : 0;
        }

        private int[] ReadSetOffsets(EndianReader reader, StringIDHeader header, CacheFileSectionTable sectionTable)
        {
            if (sectionTable == null || header.NamespacesCount == 0 || header.NamespacesOffset == 0)
                return Array.Empty<int>();

            List<int> offsetList = new List<int>();
            uint namespacesOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, header.NamespacesOffset);
            reader.SeekTo(namespacesOffset);
            int current = 0;
            for (int i = 0; i < header.NamespacesCount; i++)
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