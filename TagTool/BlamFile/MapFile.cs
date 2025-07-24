﻿using System;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.MCC;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Common.Logging;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile
{
    public class MapFile 
    {
        private static readonly Tag Head = new Tag("head");
        private static readonly Tag Foot = new Tag("foot");
        private static readonly int MapFileVersionOffset = 0x4;

        public CacheVersion Version { get; set; }
        public CacheFileVersion MapVersion { get; set; }
        public EndianFormat EndianFormat { get; set; }
        public CachePlatform CachePlatform { get; set; }

        public CacheFileHeader Header;

        public Blf MapFileBlf;

        public MapFile()
        {
        }

        public void Write(EndianWriter writer)
        {
            var dataContext = new DataSerializationContext(writer);
            var serializer = new TagSerializer(Version, CachePlatform, EndianFormat);
            serializer.Serialize(dataContext, Header);

            if(CacheVersionDetection.IsBetween(Version, CacheVersion.HaloOnlineED, CacheVersion.HaloOnline106708))
            {
                if(MapFileBlf != null)
                    MapFileBlf.Write(writer);
            }
        }

        public void Read(EndianReader reader)
        {
            EndianFormat = DetectEndianFormat(reader);
            MapVersion = GetMapFileVersion(reader);
            CacheVersion version = CacheVersion.Unknown;
            CachePlatform platform = CachePlatform.All;
            DetectCacheVersionAndPlatform(reader, MapVersion, ref version, ref platform);
            Version = version;
            CachePlatform = platform;

            Header = CacheFileHeader.Read(MapVersion, Version, CachePlatform, reader);

            if (!Header.IsValid())
            {
                Log.Warning($"Invalid map file header or footer detected. Verify definition");
            }

            // temporary code until map file format cleanup
            if (MapVersion == CacheFileVersion.HaloOnline)
            {
                var mapFileHeaderSize = (int)TagStructure.GetTagStructureInfo(Header.GetType(), Version, CachePlatform).TotalSize;

                // Seek to the blf
                reader.SeekTo(mapFileHeaderSize);
                // Read blf
                MapFileBlf = new Blf(Version, CachePlatform);
                if (!MapFileBlf.Read(reader))
                    MapFileBlf = null;
            }
        }

        private static EndianFormat DetectEndianFormat(EndianReader reader)
        {
            reader.SeekTo(0);
            reader.Format = EndianFormat.LittleEndian;
            if (reader.ReadTag() == Head)
                return EndianFormat.LittleEndian;
            else
            {
                reader.SeekTo(0);
                reader.Format = EndianFormat.BigEndian;
                if (reader.ReadTag() == Head)
                    return EndianFormat.BigEndian;
                else
                    throw new Exception("Invalid map file header tag!");
            }
        }

        private static bool IsHalo2Vista(EndianReader reader)
        {
            reader.SeekTo(0x24);
            var unknownValue = reader.ReadInt32();
            if (unknownValue == -1 || unknownValue == 0xB165400)
                return true;
            else
                return false;
        }

        private static bool IsGen3MCCFormat(EndianReader reader)
        {
            reader.SeekTo(0x120);
            CacheVersion version = CacheVersion.Unknown;
            CachePlatform platform = CachePlatform.All;
            CacheVersionDetection.GetFromBuildName(reader.ReadString(0x20), ref version, ref platform);
            if (platform == CachePlatform.MCC)
                return true;
            else
                return false;
        }

        private static bool IsModifiedReachFormat(EndianReader reader)
        {
            reader.SeekTo(0x120);
            CacheVersion version = CacheVersion.Unknown;
            CachePlatform platform = CachePlatform.All;
            CacheVersionDetection.GetFromBuildName(reader.ReadString(0x20), ref version, ref platform);
            if (version == CacheVersion.Unknown)
                return false;
            else
                return true;
        }

        private static string GetBuildDate(EndianReader reader, CacheFileVersion version)
        {
            var buildDataLength = 0x20;
            switch (version)
            {
                case CacheFileVersion.HaloPC:
                case CacheFileVersion.HaloCustomEdition:
                case CacheFileVersion.HaloXbox:
                    reader.SeekTo(0x40);
                    break;
                case CacheFileVersion.Halo2:
                    if (IsHalo2Vista(reader))
                        reader.SeekTo(0x12C);
                    else
                        reader.SeekTo(0x120);
                    break;

                case CacheFileVersion.Halo3Beta:
                case CacheFileVersion.Halo3:
                case CacheFileVersion.HaloOnline:
                    if (IsGen3MCCFormat(reader))
                        reader.SeekTo(0x120);
                    else
                        reader.SeekTo(0x11C);
                    break;
                case CacheFileVersion.HaloMCCUniversal:
                    reader.SeekTo(0xA0);
                    break;

                case CacheFileVersion.HaloReach:
                    if (IsModifiedReachFormat(reader))
                        reader.SeekTo(0x120);
                    else
                        reader.SeekTo(0x11C);
                    break; 

                default:
                    throw new Exception("Map file version not supported (build date)!");
            }
            return reader.ReadString(buildDataLength);
        }

        private static CacheFileVersion GetMapFileVersion(EndianReader reader)
        {
            reader.SeekTo(MapFileVersionOffset);
            return (CacheFileVersion)reader.ReadInt32();
        }

        private static void DetectCacheVersionAndPlatform(EndianReader reader, CacheFileVersion mapVersion, ref CacheVersion cacheVersion, ref CachePlatform cachePlatform)
        {
            var version = GetMapFileVersion(reader);
            var buildDate = GetBuildDate(reader, version);

            if (mapVersion == CacheFileVersion.HaloMCCUniversal)
            {
                reader.SeekTo(0xC);
                var engineVersion = (CacheFileHeaderMCC.HaloEngineVersion)reader.ReadSByte();
                switch(engineVersion)
                {
                    case CacheFileHeaderMCC.HaloEngineVersion.Halo3:
                        cacheVersion = CacheVersion.Halo3Retail;
                        break;
                    case CacheFileHeaderMCC.HaloEngineVersion.Halo3ODST:
                        cacheVersion = CacheVersion.Halo3ODST;
                        break;
                    case CacheFileHeaderMCC.HaloEngineVersion.HaloReach:
                        cacheVersion = CacheVersion.HaloReach;
                        break;
                    default:
                        throw new NotSupportedException("Unsupported engine version");
                }
                cachePlatform = CachePlatform.MCC;
            }
            else
            {
                CacheVersionDetection.GetFromBuildName(buildDate, ref cacheVersion, ref cachePlatform);
            }
        }
    }
}