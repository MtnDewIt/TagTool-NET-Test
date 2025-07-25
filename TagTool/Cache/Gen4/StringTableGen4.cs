using System;
using System.IO;
using TagTool.Common;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.Cache.MCC;

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

            reader.SeekTo(stringIdBufferOffset);

            EndianReader newReader;

            if (StringKey == "")
                newReader = new EndianReader(new MemoryStream(reader.ReadBytes(stringIDHeader.BufferSize)), reader.Format);
            else
                newReader = new EndianReader(reader.DecryptAesSegment(stringIDHeader.BufferSize, StringKey), reader.Format);

            //
            // Read strings
            //

            for (var i = 0; i < stringOffset.Length; i++)
            {
                if (stringOffset[i] == -1)
                {
                    this[i] = "<null>";
                    continue;
                }

                newReader.SeekTo(stringOffset[i]);
                this[i] = newReader.ReadNullTerminatedString();
            }
            newReader.Close();
            newReader.Dispose();
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
