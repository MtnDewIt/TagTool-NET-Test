using System;
using TagTool.Common;
using TagTool.IO;
using TagTool.BlamFile;

namespace TagTool.Cache.Gen4
{
    public class StringTableGen4 : StringTable
    {
        public string StringKey = "";

        public StringTableGen4(EndianReader reader, MapFile baseMapFile) : base()
        {
            Version = baseMapFile.Version;

            var Gen4Header = (CacheFileHeaderGen4)baseMapFile.Header;
            var stringIDHeader = Gen4Header.GetStringIDHeader();
            var sectionTable = Gen4Header.SectionTable;

            // means no strings
            if (sectionTable != null && sectionTable.Sections[(int)CacheFileSectionType.StringSection].Size == 0)
                return;

            switch (baseMapFile.CachePlatform)
            {
                case CachePlatform.MCC:
                    Resolver = new StringIdResolverMCC(reader, stringIDHeader, sectionTable);
                    break;
                default:
                    Resolver = new StringIdResolverHalo4();
                    StringKey = "ILikeSafeStrings";
                    break;
            }

            uint stringIdIndexTableOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, stringIDHeader.IndicesOffset);
            uint stringIdBufferOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, stringIDHeader.BufferOffset);
            
            //
            // Read offsets
            //

            reader.SeekTo(stringIdIndexTableOffset);

            int[] stringOffset = new int[stringIDHeader.Count];
            for (var i = 0; i < stringIDHeader.Count; i++)
            {
                stringOffset[i] = reader.ReadInt32();
                Add("");
            }


            //
            // Read strings
            //

            reader.SeekTo(stringIdBufferOffset);

            StringBuffer stringsBuffer = StringKey == ""
                ? new StringBuffer(reader.ReadBytes(stringIDHeader.BufferSize))
                : new StringBuffer(reader.DecryptAesSegment(stringIDHeader.BufferSize, StringKey));

            for (var i = 0; i < stringOffset.Length; i++)
            {
                this[i] = stringOffset[i] == -1 ? "<null>" : stringsBuffer.GetString(stringOffset[i]);
            }
        }

        /*
         * To resize the stringId Buffer in Gen4 caches, there are a few values to update. The map file section table needs to be updated
         * The 2 addresses for the buffer and index table in the map file header.
         */

        public override StringId AddString(string newString)
        {
            throw new NotImplementedException();
        }
    }
}
