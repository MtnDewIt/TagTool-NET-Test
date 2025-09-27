using System;
using System.IO;
using TagTool.Common;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.Cache.MCC.Resolvers;
using TagTool.Cache.Gen4.Resolvers;

namespace TagTool.Cache.Gen4
{
    public class StringTableGen4 : StringTable
    {
        public string StringKey = "";

        public StringTableGen4(EndianReader reader, MapFile baseMapFile) : base()
        {
            Version = baseMapFile.Version;

            var gen4Header = baseMapFile.Header;
            var sectionTable = gen4Header.GetSectionTable();

            var stringCount = gen4Header.GetStringIdCount();
            var dataCount = gen4Header.GetStringIdDataCount();
            var indexOffset = gen4Header.GetStringIdIndexOffset();
            var dataOffset = gen4Header.GetStringIdDataOffset();
            var namespaceCount = gen4Header.GetStringIdNamespaceCount();
            var namespaceOffset = gen4Header.GetStringIdNamespaceOffset();

            // means no strings
            if (sectionTable != null && sectionTable.OriginalSectionBounds[(int)CacheFileSectionType.StringSection].Size == 0)
                return;

            if (baseMapFile.Platform == CachePlatform.Original)
            {
                switch (Version) 
                {
                    case CacheVersion.Halo4E3:
                        Resolver = new StringIdResolverHalo4E3();
                        StringKey = "ILikeSafeStrings";
                        break;

                    case CacheVersion.Halo4:
                        Resolver = new StringIdResolverHalo4();
                        StringKey = "ILikeSafeStrings";
                        break;

                    default:
                        throw new NotSupportedException(CacheVersionDetection.GetBuildName(Version, baseMapFile.Platform));
                }
            }
            else if (baseMapFile.Platform == CachePlatform.MCC)
                Resolver = new StringIdResolverMCC(reader, sectionTable, namespaceCount, namespaceOffset);

            uint stringIdIndexOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, indexOffset);
            uint stringIdDataOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, dataOffset);
            
            //
            // Read offsets
            //

            reader.SeekTo(stringIdIndexOffset);

            int[] stringOffset = new int[stringCount];
            for (var i = 0; i < stringCount; i++)
            {
                stringOffset[i] = reader.ReadInt32();
                Add("");
            }

            reader.SeekTo(stringIdDataOffset);

            EndianReader newReader;

            if (StringKey == "")
                newReader = new EndianReader(new MemoryStream(reader.ReadBytes(dataCount)), reader.Format);
            else
                newReader = new EndianReader(reader.DecryptAesSegment(dataCount, StringKey), reader.Format);

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
