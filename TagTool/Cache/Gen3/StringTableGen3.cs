using System;
using System.IO;
using TagTool.Common;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.Cache.Gen3.Resolvers;
using TagTool.Cache.MCC.Resolvers;

namespace TagTool.Cache.Gen3
{
    public class StringTableGen3 : StringTable
    {
        public string StringKey = "";

        public StringTableGen3(EndianReader reader, MapFile baseMapFile) : base()
        {
            Version = baseMapFile.Version;

            var gen3Header = baseMapFile.Header;
            var cachePlatform = baseMapFile.Platform;
            var sectionTable = gen3Header.GetSectionTable();

            var stringCount = gen3Header.GetStringIdCount();
            var dataCount = gen3Header.GetStringIdDataCount();
            var indexOffset = gen3Header.GetStringIdIndexOffset();
            var dataOffset = gen3Header.GetStringIdDataOffset();
            var namespaceCount = gen3Header.GetStringIdNamespaceCount();
            var namespaceOffset = gen3Header.GetStringIdNamespaceOffset();

            if (cachePlatform == CachePlatform.Original)
            {
                switch (Version)
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

                    case CacheVersion.HaloReachAlpha:
                        Resolver = new StringIdResolverHaloReachAlpha();
                        StringKey = "rs&m*l#/t%_()e;[";
                        break;

                    case CacheVersion.HaloReachPreBeta:
                    case CacheVersion.HaloReachBeta:
                        Resolver = new StringIdResolverHaloReachBeta();
                        StringKey = "rs&m*l#/t%_()e;[";
                        break;

                    case CacheVersion.HaloReach:
                        Resolver = new StringIdResolverHaloReach();
                        StringKey = "ILikeSafeStrings";
                        break;

                    default:
                        throw new NotSupportedException(CacheVersionDetection.GetBuildName(Version, cachePlatform));
                }
            }
            else if(cachePlatform == CachePlatform.MCC)
                Resolver = new StringIdResolverMCC(reader, sectionTable, namespaceCount, namespaceOffset);

            // means no strings
            if (sectionTable != null && sectionTable.Sections[(int)CacheFileSectionType.StringSection].Size == 0)
                return;

            uint stringIdTableOffset;
            uint stringIdDataOffset;
            if (Version > CacheVersion.Halo3Beta)
            {
                stringIdTableOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, indexOffset);
                stringIdDataOffset = sectionTable.GetOffset(CacheFileSectionType.StringSection, dataOffset);
            }
            else
            {
                stringIdTableOffset = indexOffset;
                stringIdDataOffset = dataOffset;
            }
            

            //
            // Read offsets
            //

            reader.SeekTo(stringIdTableOffset);

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
         * To resize the stringId Buffer in Gen3 caches, there are a few values to update. The map file section table needs to be updated
         * The 2 addresses for the buffer and index table in the map file header.
         */

        public override StringId AddString(string newString)
        {
            throw new NotImplementedException();
        }
    }
}
