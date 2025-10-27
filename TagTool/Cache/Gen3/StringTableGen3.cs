using System;
using TagTool.Common;
using TagTool.IO;
using TagTool.BlamFile;

namespace TagTool.Cache.Gen3
{
    public class StringTableGen3 : StringTable
    {
        public string StringKey = "";

        public StringTableGen3(EndianReader reader, MapFile baseMapFile) : base()
        {
            var gen3Header = (CacheFileHeaderGen3)baseMapFile.Header;
            var stringIDHeader = gen3Header.GetStringIDHeader();
            var sectionTable = gen3Header.SectionTable;

            if (baseMapFile.CachePlatform == CachePlatform.Original)
            {
                switch (baseMapFile.Version)
                {
                    case CacheVersion.Halo3Beta:
                        Resolver = new StringIdResolverHalo3Beta();
                        break;

                    case CacheVersion.Halo3Retail:
                        Resolver = new StringIdResolverHalo3();
                        break;

                    case CacheVersion.Halo3ODST:
                        Resolver = new StringIdResolverHalo3ODST();
                        break;

                    case CacheVersion.HaloReach:
                        Resolver = new StringIdResolverHaloReach();
                        StringKey = "ILikeSafeStrings";
                        break;
                    case CacheVersion.Halo4:
                        Resolver = new StringIdResolverHalo4();
                        break;

                    default:
                        throw new NotSupportedException(CacheVersionDetection.GetBuildName(baseMapFile.Version, baseMapFile.CachePlatform));
                }
            }
            else if(baseMapFile.CachePlatform == CachePlatform.MCC)
                Resolver = new StringIdResolverMCC(reader, stringIDHeader, sectionTable);

            // means no strings
            if (sectionTable != null && sectionTable.Sections[(int)CacheFileSectionType.StringSection].Size == 0)
                return;

            uint stringIdIndexTableOffset;
            uint stringIdBufferOffset;
            if (baseMapFile.Version > CacheVersion.Halo3Beta)
            {
                stringIdIndexTableOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, stringIDHeader.IndicesOffset);
                stringIdBufferOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, stringIDHeader.BufferOffset);
            }
            else
            {
                stringIdIndexTableOffset = stringIDHeader.IndicesOffset;
                stringIdBufferOffset = stringIDHeader.BufferOffset;
            }
            

            //
            // Read offsets
            //

            reader.SeekTo(stringIdIndexTableOffset);

            int[] stringOffset = new int[stringIDHeader.Count];
            for (var i = 0; i < stringIDHeader.Count; i++)
            {
                stringOffset[i] = reader.ReadInt32();
            }


            //
            // Read strings
            //

            reader.SeekTo(stringIdBufferOffset);

            StringBuffer strings = StringKey == ""
                ? new StringBuffer(reader.ReadBytes(stringIDHeader.BufferSize))
                : new StringBuffer(reader.DecryptAesSegment(stringIDHeader.BufferSize, StringKey));

            EnsureCapacity(stringOffset.Length);
            for (var i = 0; i < stringOffset.Length; i++)
            {
                Add(stringOffset[i] == -1 ? "<null>" : strings.GetString(stringOffset[i]));
            }
        }

        /*
         * To resize the stringId Buffer in Gen3 caches, there are a few values to update. The map file section table needs to be updated
         * The 2 addresses for the buffer and index table in the map file header.
         */

        public override StringId AddString(string newString)
        {
            throw new NotImplementedException();
        }
    }
}
