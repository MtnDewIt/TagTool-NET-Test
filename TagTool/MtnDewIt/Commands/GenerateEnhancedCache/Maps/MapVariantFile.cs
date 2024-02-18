using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.IO;
using System.Linq;
using TagTool.Common;
using TagTool.IO;
using TagTool.Tags.Definitions;
using TagTool.Tags;
using TagTool.Commands.Common;
using TagTool.MtnDewIt.BlamFiles;
using System;
using System.Text;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps 
{
    public abstract class MapVariantFile 
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public Stream Stream { get; set; }

        public MapVariantFile(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
        }

        public void GenerateMapFile(CachedTag scnrTag, BlfData mapVariant)
        {
            MapFileData mapFileData;

            Scenario scnr = CacheContext.Deserialize<Scenario>(Stream, scnrTag);

            if (mapVariant != null)
            {
                UpdateBlfData(mapVariant, scnr);
            }

            mapFileData = GenerateMap(scnrTag, scnr, mapVariant, Cache.Endianness, Cache.Version);

            var mapFilePath = $"{Path.Combine(Cache.Directory.FullName, scnrTag.Name.Split('\\').Last())}.map";
            var mapFile = new FileInfo(mapFilePath);

            using (var stream = mapFile.Create())
            using (var writer = new EndianWriter(stream))
            {
                mapFileData.WriteData(writer);
            }
        }

        public MapFileData GenerateMap(CachedTag scnrTag, Scenario scnr, BlfData mapVariant, EndianFormat format, CacheVersion version)
        {
            var mapFile = new MapFileData();
            mapFile.Version = version;
            mapFile.CachePlatform = CachePlatform.Original;
            mapFile.EndianFormat = format;
            mapFile.MapVersion = CacheFileVersion.HaloOnline;
            var header = new CacheFileHeaderGenHaloOnline();
            header.HeaderSignature = new Tag("head");
            header.FileVersion = CacheFileVersion.HaloOnline;
            header.FileLength = 339984;
            header.Build = CacheVersionDetection.GetBuildName(version, CachePlatform.Original);

            switch (scnr.MapType)
            {
                case ScenarioMapType.MainMenu:
                    header.CacheType = CacheFileType.MainMenu;
                    break;
                case ScenarioMapType.SinglePlayer:
                    header.CacheType = CacheFileType.Campaign;
                    break;
                case ScenarioMapType.Multiplayer:
                    header.CacheType = CacheFileType.Multiplayer;
                    break;
            }

            header.SharedCacheType = CacheFileSharedType.None;
            header.Unknown2 = true;
            header.TrackedBuild = true;
            header.ExternalDependencies = 62;
            header.Timestamp = 130713362601925231;
            header.ExternalDependencyTimestamps = new ulong[6] 
            {
                130713360239499012,
                130713360241169179,
                130713360241169179,
                130713360241169179,
                130713360241169179,
                130713360241169179,
            };
            header.Name = scnrTag.Name.Split('\\').Last();
            header.ScenarioPath = scnrTag.Name;
            header.MinorVersion = -1;
            header.Checksum = 13200;
            header.Unknown14 = 326784;
            header.UnknownHO1 = new byte[32]
            {
                0x67, 0x64, 0x03, 0xCF, 0xAE, 0xD0, 0x75, 0xDF, 0x50, 0xE7,
                0x5B, 0x75, 0x6B, 0x4A, 0xBB, 0xF4, 0xE8, 0x54, 0x8F, 0xC6,
                0xD6, 0xCC, 0x92, 0x15, 0x97, 0xDC, 0xF5, 0xEE, 0xB9, 0x3C,
                0x01, 0x3C,
            };
            header.Unknown17 = 6132;
            header.Unknown20 = 1679391740;
            header.Unknown21_1 = 394268326;

            switch (header.Name) 
            {
                case "riverworld":
                    header.Timestamp = 130713364037918816;
                    header.Hash = new byte[20]
                    {
                        0x9E, 0xB7, 0xA7, 0x51, 0x33, 0x62, 0xEC, 0xB9, 0xC8, 0xE4,
                        0xB7, 0x7A, 0x1D, 0x68, 0xD2, 0x89, 0x40, 0x11, 0x99, 0x93,
                    };
                    header.RSASignature = new byte[256]
                    {
                        0x43, 0x85, 0x48, 0xC9, 0x96, 0x14, 0x4A, 0xA6, 0x87, 0x7E, 0x42, 0x94, 0x88, 0x67, 0xED, 0xB1, 0x87, 0x04, 0xEB, 0x00,
                        0x99, 0xF1, 0xD7, 0x55, 0x94, 0x44, 0x3B, 0x95, 0xE2, 0x00, 0x7D, 0xC0, 0x77, 0xCC, 0xDA, 0xA1, 0x89, 0x7D, 0x6B, 0x3F,
                        0x41, 0x1B, 0xFD, 0x95, 0x57, 0x34, 0xD4, 0x1F, 0x17, 0x62, 0xFE, 0x9F, 0x51, 0xB3, 0xED, 0x20, 0xF0, 0xFB, 0xCA, 0x9C,
                        0x38, 0x3B, 0xB8, 0x06, 0xE4, 0x22, 0x69, 0xC6, 0xB6, 0x35, 0x48, 0xD2, 0x06, 0x47, 0x6E, 0x94, 0xB8, 0x41, 0xAD, 0x41,
                        0x7B, 0x99, 0x82, 0xAC, 0x57, 0x97, 0x25, 0x81, 0xBB, 0xA6, 0x7C, 0x48, 0x79, 0x64, 0x7F, 0x33, 0x19, 0xBC, 0xF8, 0x9C,
                        0xF7, 0xB8, 0xCC, 0x65, 0x4A, 0xEB, 0x31, 0x55, 0x94, 0x6A, 0xB0, 0x69, 0x8C, 0x3D, 0xAF, 0xFD, 0xEC, 0x5A, 0x97, 0xE9,
                        0x32, 0x9F, 0x15, 0x29, 0x29, 0x8E, 0x57, 0xAB, 0xA9, 0x57, 0x02, 0xE3, 0xA8, 0xD7, 0xB3, 0xA5, 0xA2, 0x9A, 0x35, 0xB9,
                        0xE0, 0x41, 0x2D, 0xFD, 0xB0, 0x52, 0xE8, 0xF1, 0x77, 0x75, 0xDD, 0xE3, 0x0C, 0x0F, 0x4A, 0x06, 0x9D, 0x68, 0x52, 0xDA,
                        0xE3, 0x0C, 0xDE, 0xD9, 0xEB, 0xEA, 0x2C, 0xB9, 0x3D, 0xA8, 0x02, 0xA7, 0xBF, 0x51, 0x43, 0x7C, 0x09, 0x1F, 0xDA, 0x32,
                        0x8D, 0x93, 0x94, 0x68, 0x54, 0x90, 0x9A, 0x80, 0x38, 0xD6, 0x6B, 0xA8, 0xEC, 0xD3, 0xC8, 0x54, 0xC7, 0x56, 0xDD, 0x15,
                        0xD2, 0x87, 0x65, 0x83, 0x3C, 0xB8, 0xB6, 0xF2, 0x10, 0x67, 0x99, 0xB1, 0xAA, 0x35, 0xD5, 0x7B, 0xAB, 0x73, 0x07, 0x26,
                        0x63, 0xA2, 0xA0, 0x53, 0x2C, 0x4F, 0xB1, 0x38, 0x9B, 0xEB, 0x0D, 0xCD, 0xC0, 0xA7, 0x09, 0x93, 0x49, 0xDD, 0x25, 0x36,
                        0x80, 0x29, 0x39, 0x4F, 0x74, 0x28, 0x4F, 0x22, 0x05, 0x1D, 0xBF, 0xA8, 0x76, 0x9A, 0x46, 0xAA,
                    };
                    break;
                case "s3d_avalanche":
                    header.Timestamp = 130713369696144582;
                    header.Hash = new byte[20]
                    {
                        0xF9, 0xC0, 0xDA, 0xC4, 0xFA, 0x29, 0x7A, 0x70, 0xA9, 0x24,
                        0xF7, 0x65, 0x7A, 0x0C, 0xE9, 0xE5, 0xB4, 0x26, 0x76, 0x00,
                    };
                    header.RSASignature = new byte[256]
                    {
                        0x08, 0xC2, 0x96, 0x35, 0x17, 0x89, 0xC6, 0xED, 0x19, 0x64, 0x0A, 0x28, 0x58, 0xB5, 0x41, 0xE7, 0x97, 0x4D, 0xB2, 0xBA,
                        0xC9, 0xB1, 0x3A, 0x20, 0x95, 0x1E, 0x55, 0x03, 0xDC, 0xB1, 0x20, 0x01, 0xFC, 0x54, 0x35, 0x82, 0x01, 0xCB, 0x00, 0xD0,
                        0x26, 0x8A, 0xCE, 0x0C, 0xCD, 0x28, 0xCE, 0xAE, 0x37, 0x63, 0xAE, 0x1C, 0xF7, 0x09, 0x4A, 0x87, 0x96, 0x1B, 0xB3, 0x67,
                        0x37, 0x54, 0x4E, 0x5B, 0xF3, 0x12, 0xD0, 0x31, 0xB1, 0x36, 0xF8, 0x19, 0x35, 0xCC, 0x38, 0x77, 0x3D, 0x2D, 0x57, 0xB8,
                        0x1E, 0x6F, 0xB4, 0x06, 0x3E, 0xCB, 0x6E, 0x65, 0xAC, 0x68, 0x4B, 0x5B, 0x82, 0xB1, 0x13, 0x8F, 0x3D, 0xD7, 0x0C, 0x8C,
                        0xE6, 0xF3, 0x49, 0x5A, 0xED, 0x0B, 0x8D, 0x12, 0xBA, 0xE4, 0x40, 0x80, 0x4C, 0x6F, 0x28, 0x80, 0x09, 0x9D, 0xC6, 0x5C,
                        0x60, 0x98, 0xA2, 0xB9, 0xBC, 0xB3, 0x81, 0x90, 0x81, 0x78, 0x4A, 0x36, 0x54, 0xFA, 0x02, 0xB1, 0x6C, 0xC8, 0x86, 0x37,
                        0x45, 0xCA, 0x3F, 0xF3, 0x5D, 0x01, 0xC0, 0xB7, 0x1F, 0x27, 0x7C, 0x0E, 0xBF, 0xE3, 0x17, 0xB2, 0x49, 0x0A, 0x58, 0x82,
                        0xC5, 0xB7, 0x2F, 0xD7, 0x7A, 0x01, 0xE3, 0x95, 0x6D, 0x0F, 0xA9, 0x0F, 0x2F, 0xAB, 0x71, 0x5D, 0xBF, 0x41, 0x8B, 0x15,
                        0x39, 0x94, 0x7A, 0xEC, 0xE7, 0x2F, 0x56, 0xFE, 0xD0, 0x87, 0xFD, 0x69, 0xE9, 0x5E, 0x02, 0x7C, 0x82, 0x3B, 0x65, 0xFC,
                        0xFB, 0xE9, 0xE3, 0x13, 0x46, 0x9A, 0xCF, 0x17, 0xBE, 0xBC, 0xE1, 0x59, 0xDE, 0x2F, 0xED, 0x75, 0xC5, 0xD1, 0x85, 0xD9,
                        0xEF, 0xB1, 0x51, 0x76, 0xA1, 0xD6, 0x6B, 0x0B, 0xB5, 0xBC, 0x54, 0x13, 0xE7, 0x0D, 0xD0, 0xF2, 0xDA, 0x61, 0xB7, 0xCD,
                        0x83, 0xA9, 0x5E, 0x96, 0xA3, 0x2C, 0x47, 0x43, 0xFB, 0x33, 0x9E, 0x96, 0x73, 0x21, 0x1A, 0x49,
                    };
                    break;
                case "s3d_edge":
                    header.Timestamp = 130713371237088661;
                    header.Hash = new byte[20]
                    {
                        0x9A, 0xB5, 0x2D, 0x04, 0x49, 0xC6, 0xD5, 0xE2, 0x53, 0xEF,
                        0x1D, 0x1B, 0xDA, 0x08, 0x5A, 0x17, 0xA7, 0x22, 0x7D, 0xEA,
                    };
                    header.RSASignature = new byte[256]
                    {
                        0x56, 0x99, 0x63, 0xAC, 0xC1, 0x66, 0xE3, 0xD0, 0xE8, 0xAB, 0x9A, 0x6E, 0x8D, 0xBB, 0x52, 0x76, 0x2E, 0xCA, 0xC3, 0x36,
                        0x1C, 0x0E, 0x87, 0x9C, 0xD3, 0xED, 0xFE, 0x6B, 0xA4, 0xCA, 0xA2, 0x05, 0x49, 0x38, 0x7F, 0xC6, 0x16, 0x8D, 0xFA, 0x03,
                        0xF3, 0xB7, 0xE6, 0x71, 0xD6, 0x2F, 0x07, 0xBF, 0x0E, 0xD7, 0x46, 0xFB, 0x60, 0x57, 0x58, 0x79, 0x2B, 0x60, 0x75, 0x08,
                        0xE1, 0x4B, 0x91, 0xF4, 0xC9, 0x86, 0x9A, 0xEC, 0x57, 0x02, 0x7E, 0x58, 0xE2, 0x36, 0x2B, 0xD6, 0x59, 0xD8, 0xF0, 0x17,
                        0x4A, 0x3F, 0x8D, 0xEE, 0x78, 0x1F, 0x57, 0x04, 0xB3, 0x28, 0x13, 0xF1, 0x96, 0x5B, 0xDE, 0x8E, 0x12, 0x1E, 0x9D, 0x45,
                        0xEF, 0xE3, 0xDE, 0xCD, 0xEB, 0x89, 0x3B, 0x1D, 0x61, 0x8A, 0xA5, 0xDB, 0x41, 0xCE, 0x4F, 0x85, 0x30, 0x35, 0xFF, 0x54,
                        0x6D, 0x04, 0x76, 0x0A, 0xFB, 0xCD, 0x87, 0x95, 0xA2, 0x65, 0xA0, 0x5F, 0xEF, 0xFB, 0x9D, 0x7E, 0xBC, 0x06, 0xB0, 0x4A,
                        0x59, 0xC4, 0x94, 0x60, 0xD2, 0xFE, 0x46, 0x1D, 0xB9, 0xA2, 0x58, 0x54, 0x7D, 0x62, 0x1C, 0x99, 0xC4, 0xB4, 0xA2, 0x61,
                        0x49, 0x45, 0x3F, 0x9E, 0xF9, 0x7C, 0x33, 0x8F, 0xB5, 0xD2, 0xFC, 0x9F, 0x8D, 0xEA, 0x13, 0xE4, 0x5A, 0xCF, 0xB7, 0xF5,
                        0x08, 0x79, 0xD4, 0x61, 0x32, 0xFA, 0x84, 0xCC, 0xD0, 0xF1, 0xB1, 0x24, 0x6D, 0xBB, 0x6D, 0x96, 0x9E, 0xCF, 0x5D, 0x96,
                        0xE5, 0x9F, 0x0D, 0x15, 0x32, 0x00, 0x18, 0x0C, 0x59, 0x96, 0xE1, 0x1D, 0xDA, 0x79, 0x09, 0x1C, 0xE2, 0x5C, 0x15, 0x21,
                        0xA9, 0xBC, 0xA1, 0x94, 0xAD, 0x00, 0x62, 0x31, 0xD6, 0x30, 0x00, 0x85, 0x90, 0x78, 0xC0, 0x3E, 0x7F, 0x2C, 0xBF, 0x04,
                        0x34, 0x2E, 0x81, 0xF9, 0xAB, 0x3E, 0xA8, 0xAA, 0x0A, 0x78, 0x8A, 0x74, 0xF6, 0xFB, 0x48, 0x88,
                    };
                    break;
                case "s3d_reactor":
                    header.Timestamp = 130713373145889522;
                    header.Hash = new byte[20]
                    {
                        0xF4, 0x88, 0xAD, 0x01, 0xB8, 0x3D, 0xCE, 0xE9, 0x62, 0x6C,
                        0xD2, 0x1C, 0xF6, 0xA5, 0x4C, 0x15, 0xE5, 0xA7, 0xC6, 0x28,
                    };
                    header.RSASignature = new byte[256]
                    {
                        0xD2, 0x37, 0xC6, 0xCE, 0x84, 0x36, 0x68, 0x18, 0xAB, 0x2D, 0x74, 0x72, 0x6E, 0xB3, 0x40, 0x47, 0x55, 0x10, 0xCB, 0x86,
                        0x89, 0x0D, 0x67, 0x1B, 0xBE, 0x4F, 0x14, 0x5C, 0x1D, 0xA5, 0x83, 0xF8, 0xB3, 0x39, 0x73, 0x4B, 0x9E, 0xE7, 0x7D, 0x62,
                        0x8D, 0x5F, 0x36, 0xDB, 0xEC, 0xF6, 0x52, 0x0D, 0x7E, 0x0B, 0x7B, 0xF6, 0xCD, 0x25, 0xEB, 0x81, 0x3D, 0x2D, 0x3B, 0x36,
                        0x9B, 0xD7, 0x4D, 0x7F, 0x14, 0xE9, 0xED, 0x05, 0x2D, 0x12, 0x78, 0x35, 0xE9, 0x25, 0xAF, 0xAC, 0xA9, 0xD1, 0x84, 0x0A,
                        0xA2, 0x19, 0xC5, 0xF2, 0x73, 0x4B, 0x1C, 0xD5, 0x2F, 0xC8, 0x33, 0xC2, 0x86, 0x93, 0xA1, 0x5B, 0x91, 0x47, 0xC6, 0x16,
                        0x4D, 0xC8, 0x03, 0x31, 0x5D, 0xB2, 0x3E, 0x66, 0x91, 0xDE, 0x85, 0x99, 0x5D, 0xAB, 0x6C, 0xD3, 0xF0, 0xCC, 0xEB, 0xA1,
                        0xEA, 0x51, 0xE8, 0x04, 0x13, 0x63, 0xEB, 0xB2, 0x8B, 0x24, 0x02, 0x0F, 0x50, 0x4E, 0x43, 0x9A, 0x9B, 0x66, 0xE5, 0x23,
                        0x98, 0xBF, 0x1D, 0x26, 0x85, 0x91, 0xA8, 0x70, 0x8E, 0xCF, 0x83, 0x76, 0x67, 0x55, 0xB0, 0x17, 0x6F, 0x55, 0x91, 0x2F,
                        0xC4, 0x17, 0xB1, 0x59, 0x22, 0xC9, 0xD3, 0xA7, 0xEA, 0x48, 0xBB, 0x7D, 0x5F, 0xC5, 0x0D, 0xA0, 0xF1, 0x1F, 0xC6, 0xCA,
                        0x6B, 0xA1, 0xF2, 0xAC, 0x16, 0x06, 0x71, 0x28, 0x4F, 0xAB, 0xA9, 0xD7, 0xEE, 0x75, 0x5D, 0x55, 0x24, 0x11, 0x09, 0x73,
                        0xA1, 0x09, 0xE9, 0x0F, 0xD3, 0x5C, 0xD5, 0x99, 0x6B, 0xC0, 0x39, 0x0F, 0xDE, 0xB6, 0x5F, 0xB7, 0xF5, 0x66, 0x40, 0x61,
                        0xCC, 0xD5, 0xCA, 0xD9, 0xD9, 0xF4, 0xA3, 0xC0, 0xB6, 0x83, 0xDC, 0xD2, 0xA7, 0xDD, 0xC8, 0x3B, 0xE3, 0x7E, 0x67, 0xAD,
                        0xC7, 0x08, 0xA7, 0xC1, 0x35, 0xD3, 0x2A, 0x7D, 0x50, 0x45, 0x8A, 0x11, 0x5E, 0xCE, 0xC5, 0x76,
                    };
                    break;
                case "s3d_turf":
                    header.Timestamp = 130713374616636582;
                    header.Hash = new byte[20]
                    {
                        0xC6, 0xA5, 0xAF, 0xC9, 0x96, 0xD2, 0xA1, 0x81, 0x51, 0x41,
                        0x8F, 0x56, 0x5C, 0x93, 0x1B, 0xF5, 0x89, 0x69, 0x16, 0xB6,
                    };
                    header.RSASignature = new byte[256]
                    {
                        0x09, 0xD1, 0xE7, 0xF2, 0x14, 0x25, 0xB9, 0x5E, 0x62, 0x58, 0x8E, 0x6C, 0xA7, 0xA8, 0xE2, 0x49, 0xE2, 0x47, 0x7E, 0xF9,
                        0x5F, 0xB1, 0xEF, 0xD6, 0x52, 0xE8, 0x9F, 0x70, 0xF4, 0x8E, 0x4C, 0x6E, 0x7C, 0x01, 0x6F, 0xCE, 0x4F, 0x8C, 0x1A, 0x04,
                        0x48, 0xBB, 0x9E, 0xB0, 0x95, 0x2A, 0xCA, 0xFF, 0x6A, 0x9C, 0x10, 0x25, 0xA3, 0xD3, 0x53, 0x54, 0x81, 0x7F, 0xDC, 0xB2,
                        0x50, 0xE3, 0x20, 0x4F, 0x9B, 0x9B, 0x9A, 0xC5, 0xE5, 0x68, 0x6C, 0x44, 0x0C, 0xD2, 0xC8, 0xE5, 0x10, 0xF5, 0x6B, 0x8C,
                        0xFD, 0x89, 0xB2, 0x40, 0x6D, 0xF2, 0x69, 0xFB, 0x47, 0x78, 0x27, 0xF5, 0x0C, 0xC4, 0x7E, 0xEE, 0xE2, 0x09, 0x41, 0xD1,
                        0x72, 0xB0, 0xFF, 0x25, 0xE7, 0xE4, 0xB7, 0x08, 0x17, 0x55, 0x56, 0xDD, 0x03, 0xF1, 0xEE, 0x5E, 0xE2, 0x2F, 0xDE, 0xD3,
                        0xE5, 0xD9, 0x17, 0x04, 0xEF, 0x25, 0x8E, 0xD7, 0xE4, 0x1B, 0xC3, 0x84, 0x5F, 0x05, 0xB6, 0x65, 0x12, 0xC9, 0x75, 0x49,
                        0x93, 0x33, 0xB8, 0x81, 0x5F, 0x8D, 0x70, 0xF8, 0x0A, 0xD4, 0x5E, 0x9F, 0x81, 0x87, 0x25, 0x07, 0x17, 0xBF, 0xD2, 0xAF,
                        0xE1, 0x5D, 0xD9, 0x94, 0xA8, 0xE1, 0x6B, 0xB8, 0xD3, 0x59, 0x00, 0x8C, 0x3D, 0x24, 0xDE, 0x7F, 0xD7, 0x18, 0xE2, 0x81,
                        0x47, 0xCC, 0x5D, 0x2D, 0x28, 0x44, 0x7F, 0xC4, 0x14, 0x74, 0x34, 0xF3, 0x00, 0xDB, 0x86, 0xB4, 0xD1, 0xCA, 0xAE, 0x3F,
                        0x47, 0x4C, 0x47, 0x99, 0xCA, 0x72, 0x8F, 0xC1, 0x63, 0x15, 0xC5, 0xDD, 0x66, 0xF4, 0x36, 0x9C, 0xFB, 0x41, 0x9B, 0x74,
                        0xFA, 0x7F, 0xDD, 0xD9, 0x1E, 0x70, 0x49, 0x27, 0x6C, 0xFC, 0x48, 0xC0, 0xD9, 0xEB, 0x7A, 0xED, 0x3C, 0x96, 0x2C, 0x9A,
                        0x70, 0xBE, 0x72, 0xAA, 0xB9, 0x6C, 0x9C, 0x02, 0x12, 0xC4, 0x28, 0x79, 0x1A, 0x1C, 0xDE, 0x68,
                    };
                    break;
                default:
                    header.Timestamp = 130713362601925231;
                    header.Hash = new byte[20]
                    {
                        0xC2, 0xAD, 0xE7, 0x74, 0x1B, 0x43, 0x51, 0x23, 0xD5, 0x50,
                        0xCE, 0x52, 0x26, 0x51, 0xAC, 0xC6, 0x9C, 0x1F, 0x59, 0x5D,
                    };
                    header.RSASignature = new byte[256]
                    {
                        0xFA, 0x4F, 0x6C, 0x23, 0xDC, 0xC6, 0xF0, 0x12, 0x1A, 0x79, 0x86, 0x23, 0xA7, 0xDE, 0x8B, 0xFD, 0x44, 0x44, 0x62, 0x98,
                        0x0D, 0x02, 0x32, 0x20, 0x85, 0x8E, 0xB8, 0x86, 0x7F, 0x68, 0xDC, 0xC1, 0x33, 0xEB, 0x11, 0x77, 0x69, 0x77, 0x53, 0xF6,
                        0x3D, 0xD2, 0xFE, 0x70, 0x0D, 0x20, 0x1C, 0xC9, 0x4F, 0x82, 0x8D, 0xE4, 0x83, 0x84, 0xED, 0xA0, 0xC2, 0xBB, 0x2C, 0x83,
                        0x61, 0x30, 0x73, 0x87, 0x7A, 0xBB, 0xF2, 0x12, 0x3A, 0xA1, 0xB5, 0x85, 0x47, 0x4C, 0x39, 0xFF, 0x9A, 0xDE, 0x7D, 0x13,
                        0x0A, 0x12, 0x79, 0xD3, 0x02, 0xE7, 0x2A, 0x81, 0x58, 0x3C, 0xBF, 0xBF, 0x90, 0xA6, 0x19, 0x91, 0x51, 0x19, 0xA9, 0x2C,
                        0xEC, 0xFA, 0xA6, 0x69, 0xF1, 0x42, 0xF5, 0xF0, 0x73, 0xB5, 0xED, 0xEB, 0x65, 0x72, 0x63, 0x90, 0x78, 0x74, 0xF0, 0x9D,
                        0xB7, 0x25, 0x7A, 0x1D, 0x37, 0x29, 0xE6, 0xEF, 0xBC, 0xAE, 0xF1, 0xE5, 0xA3, 0x20, 0x1F, 0xAE, 0x4C, 0x17, 0x20, 0x2E,
                        0x38, 0x56, 0x76, 0xED, 0x6F, 0x35, 0x9A, 0x18, 0x4C, 0x72, 0x1F, 0x0C, 0x21, 0x89, 0x2B, 0x45, 0xF5, 0xAA, 0x98, 0x0D,
                        0x91, 0xAD, 0x09, 0x4C, 0xDF, 0x67, 0x78, 0xD4, 0x60, 0x45, 0xE6, 0x1E, 0xC6, 0xF5, 0x1D, 0x09, 0xE5, 0xD2, 0x31, 0x85,
                        0x29, 0xFC, 0x24, 0x9C, 0x40, 0x38, 0xFB, 0xBB, 0x91, 0x84, 0x75, 0xAC, 0x32, 0x24, 0x33, 0x2E, 0x99, 0xE5, 0xDE, 0xF0,
                        0xFC, 0x06, 0x92, 0xE4, 0x56, 0xA5, 0xA8, 0xF2, 0xE1, 0x93, 0x7B, 0x29, 0x4B, 0x23, 0x86, 0xA6, 0x19, 0xB0, 0x70, 0xE7,
                        0xB0, 0x46, 0x01, 0x8A, 0x6C, 0xE4, 0x41, 0xA0, 0x35, 0xD6, 0xF6, 0xD7, 0x57, 0xE0, 0x94, 0x07, 0xE3, 0xAE, 0x98, 0xC1,
                        0x34, 0x64, 0x80, 0x2D, 0x79, 0xD0, 0x4D, 0x9E, 0x21, 0x76, 0x97, 0x14, 0x6A, 0x2D, 0xA2, 0x4F,
                    };
                    break;
            };
            header.Partitions = new CacheFilePartition[6]
            {
                new CacheFilePartition
                {
                    VirtualAddress = new PlatformUnsignedValue(0x0),
                    Size = new PlatformSignedValue(0),
                },
                new CacheFilePartition
                {
                    VirtualAddress = new PlatformUnsignedValue(0x0),
                    Size = new PlatformSignedValue(0),
                },
                new CacheFilePartition
                {
                    VirtualAddress = new PlatformUnsignedValue(0x3390),
                    Size = new PlatformSignedValue(326784),
                },
                new CacheFilePartition
                {
                    VirtualAddress = new PlatformUnsignedValue(0x3390),
                    Size = new PlatformSignedValue(0),
                },
                new CacheFilePartition
                {
                    VirtualAddress = new PlatformUnsignedValue(0x3390),
                    Size = new PlatformSignedValue(0),
                },
                new CacheFilePartition
                {
                    VirtualAddress = new PlatformUnsignedValue(0xFFFFFFFF),
                    Size = new PlatformSignedValue(0),
                },
            };
            header.MapId = scnr.MapId;
            header.ScenarioTagIndex = scnrTag.Index;
            header.FooterSignature = new Tag("foot");
            mapFile.Header = header;
            mapFile.MapFileBlf = mapVariant;
            return mapFile;
        }

        public void UpdateBlfData(BlfData mapVariant, Scenario scnr)
        {
            mapVariant.StartOfFile.Signature = new Tag(InvertString(mapVariant.StartOfFile.Signature.ToString()));
            mapVariant.StartOfFile.Length = InvertInt(mapVariant.StartOfFile.Length);
            mapVariant.StartOfFile.MajorVersion = InvertShort(mapVariant.StartOfFile.MajorVersion);
            mapVariant.StartOfFile.MinorVersion = InvertShort(mapVariant.StartOfFile.MinorVersion);
            mapVariant.StartOfFile.ByteOrderMarker = InvertShort(mapVariant.StartOfFile.ByteOrderMarker);

            mapVariant.Scenario.Signature = new Tag(InvertString(mapVariant.Scenario.Signature.ToString()));
            mapVariant.Scenario.Length = InvertInt(mapVariant.Scenario.Length);
            mapVariant.Scenario.MajorVersion = InvertShort(mapVariant.Scenario.MajorVersion);
            mapVariant.Scenario.MinorVersion = InvertShort(mapVariant.Scenario.MinorVersion);

            mapVariant.MapVariant.Signature = new Tag(InvertString(mapVariant.MapVariant.Signature.ToString()));
            mapVariant.MapVariant.Length = InvertInt(mapVariant.MapVariant.Length);
            mapVariant.MapVariant.MajorVersion = InvertShort(mapVariant.MapVariant.MajorVersion);
            mapVariant.MapVariant.MinorVersion = InvertShort(mapVariant.MapVariant.MinorVersion);

            if (mapVariant.MapVariant.MapVariant.Objects != null) 
            {
                for (int i = 0; i < mapVariant.MapVariant.MapVariant.Objects.Length; i++)
                {
                    var variantObject = mapVariant.MapVariant.MapVariant.Objects[i];

                    if (variantObject.QuotaIndex == -1)
                    {
                        if (variantObject.Properties == null)
                        {
                            variantObject.Properties = new VariantMultiplayerProperties();
                        }

                        if (variantObject.Properties.Team != (VariantDataMultiplayerTeamDesignator)9)
                        {
                            variantObject.Properties.EngineFlags = VariantDataGameEngineSubTypeFlags.None;
                            variantObject.Properties.Team = VariantDataMultiplayerTeamDesignator.None;
                            variantObject.Properties.Type = VariantDataMultiplayerObjectType.None;
                        }
                    }
                }

                mapVariant.MapVariant.MapVariant.VariantObjectCount = GetVariantObjectCount(mapVariant.MapVariant.MapVariant);
            }

            if (mapVariant.MapVariant.MapVariant.Quotas != null) 
            {
                for (int i = 0; i < mapVariant.MapVariant.MapVariant.Quotas.Length; i++)
                {
                    var quota = mapVariant.MapVariant.MapVariant.Quotas[i];

                    if (quota.ObjectDefinitionIndex == -1)
                    {
                        quota.MaxAllowed = 0;
                        quota.Cost = -1f;
                    }
                    else
                    {
                        quota.MaxAllowed = 255;

                        if (quota.Cost != -1f)
                        {
                            quota.Cost = 0f;
                        }
                    }
                }

                mapVariant.MapVariant.MapVariant.PlaceableQuotaCount = GetVariantObjectCount(mapVariant.MapVariant.MapVariant);
            }

            if (mapVariant.MapVariant.MapVariant.ObjectTypeStartIndex != null) 
            {
                mapVariant.MapVariant.MapVariant.ScenarioObjectCount = GetScenarioObjectCount(mapVariant.MapVariant.MapVariant, scnr);
            }

            mapVariant.EndOfFile.Signature = new Tag(InvertString(mapVariant.EndOfFile.Signature.ToString()));
            mapVariant.EndOfFile.Length = InvertInt(mapVariant.EndOfFile.Length);
            mapVariant.EndOfFile.MajorVersion = InvertShort(mapVariant.EndOfFile.MajorVersion);
            mapVariant.EndOfFile.MinorVersion = InvertShort(mapVariant.EndOfFile.MinorVersion);
        }

        public short GetScenarioObjectCount(MapVariantData mapVariant, Scenario scnr)
        {
            var scenarioObjectTypes = new Dictionary<GameObjectTypeHalo3ODST, MapVariantDataGenerator.ScenarioObjectTypeDefinition>()
            {
                { GameObjectTypeHalo3ODST.Vehicle, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Vehicles, scnr.VehiclePalette) },
                { GameObjectTypeHalo3ODST.Weapon, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Weapons, scnr.WeaponPalette) },
                { GameObjectTypeHalo3ODST.Equipment, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Equipment, scnr.EquipmentPalette) },
                { GameObjectTypeHalo3ODST.Scenery, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Scenery, scnr.SceneryPalette) },
                { GameObjectTypeHalo3ODST.Crate, new MapVariantDataGenerator.ScenarioObjectTypeDefinition(scnr.Crates, scnr.CratePalette) },
            };

            short scenarioDatumsOffset = 0;
            for (var objectType = GameObjectTypeHalo3ODST.Biped; objectType <= GameObjectTypeHalo3ODST.EffectScenery; objectType++)
            {
                if (scenarioObjectTypes.TryGetValue(objectType, out MapVariantDataGenerator.ScenarioObjectTypeDefinition objectTypeDefinition))
                {
                    mapVariant.ObjectTypeStartIndex[(int)objectType] = scenarioDatumsOffset;
                    scenarioDatumsOffset += (short)objectTypeDefinition.Instances.Count;
                }
                else
                {
                    mapVariant.ObjectTypeStartIndex[(int)objectType] = -1;
                }
            }

            return scenarioDatumsOffset;
        }

        public short GetVariantObjectCount(MapVariantData mapVariant)
        {
            short count = 0;
            
            for (int i = mapVariant.Objects.Length - 1; i >= 0; i--)
            {
                var variantObject = mapVariant.Objects[i];
            
                if (variantObject.QuotaIndex == -1)
                {
                    count++;
                }
                else 
                {
                    break;
                }
            }
            
            return (short)(mapVariant.Objects.Length - count);
        }

        public short GetPlaceableQuotaCount(MapVariantData mapVariant)
        {
            short count = 0;
            
            for (int i = mapVariant.Quotas.Length - 1; i >= 0; i--)
            {
                var quota = mapVariant.Quotas[i];
            
                if (quota.ObjectDefinitionIndex == -1)
                {
                    count++;
                }
                else 
                {
                    break;
                }
            }
            
            return (short)(mapVariant.Quotas.Length - count);
        }

        private string InvertString(string value)
        {
            byte[] data = Encoding.UTF8.GetBytes(value);

            Array.Reverse(data);

            return Encoding.UTF8.GetString(data);
        }

        private int InvertInt(int value)
        {
            byte[] data = BitConverter.GetBytes(value);

            Array.Reverse(data);

            return BitConverter.ToInt32(data, 0);
        }

        private short InvertShort(short value)
        {
            byte[] data = BitConverter.GetBytes(value);

            Array.Reverse(data);

            return BitConverter.ToInt16(data, 0);
        }

        public void GenerateMapVariant(CachedTag tag, BlfData mapVariant)
        {
            var scenario = Cache.Deserialize<Scenario>(Stream, tag);

            var culledObjects = new HashSet<CachedTag>() 
            {
                GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_2way\teleporter_2way"),
                GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_reciever\teleporter_reciever"),
                GetCachedTag<Crate>($@"objects\levels\dlc\chillout\teleporter_sender\teleporter_sender"),
                GetCachedTag<Crate>($@"objects\levels\dlc\descent\base_gravlift_descent\base_gravlift_descent"),
                GetCachedTag<Crate>($@"objects\levels\dlc\descent\base_gravlift_descent_yellow\base_gravlift_descent_yellow"),
                GetCachedTag<Crate>($@"objects\levels\dlc\descent\egg_shield\egg_shield"),
                GetCachedTag<Crate>($@"objects\levels\dlc\descent\man_cannon_descent\man_cannon_descent"),
                GetCachedTag<Crate>($@"objects\levels\dlc\lockout\lift_interior\lift_interior"),
                GetCachedTag<Crate>($@"objects\levels\dlc\midship\middle_physics_volume\middle_physics_volume"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sandbox\teleporter_2way_sandbox"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\lift_sidewinder\lift_sidewinder"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_01\man_cannon_sidewinder_01"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_02\man_cannon_sidewinder_02"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_03\man_cannon_sidewinder_03"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_04\man_cannon_sidewinder_04"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_05\man_cannon_sidewinder_05"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_06\man_cannon_sidewinder_06"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_07\man_cannon_sidewinder_07"),
                GetCachedTag<Crate>($@"objects\levels\dlc\sidewinder\man_cannon_sidewinder_08\man_cannon_sidewinder_08"),
                GetCachedTag<Crate>($@"objects\levels\multi\chill\man_cannon_chill\man_cannon_chill"),
                GetCachedTag<Crate>($@"objects\levels\multi\construct\construct_lift_lg\construct_lift_lg"),
                GetCachedTag<Crate>($@"objects\levels\multi\construct\construct_lift_sm\construct_lift_sm"),
                GetCachedTag<Crate>($@"objects\levels\multi\cyberdyne\cyber_pad\cyber_pad"),
                GetCachedTag<Crate>($@"objects\levels\multi\cyberdyne\cyber_pad\cyber_pad_midship"),
                GetCachedTag<Crate>($@"objects\levels\multi\guardian\man_cannon_guardian_ii\man_cannon_guardian_ii"),
                GetCachedTag<Crate>($@"objects\levels\multi\isolation\isolation_lift_curve\isolation_lift_curve"),
                GetCachedTag<Crate>($@"objects\levels\multi\isolation\launch_tube\launch_tube"),
                GetCachedTag<Crate>($@"objects\levels\multi\isolation\launch_tube_opp\launch_tube_opp"),
                GetCachedTag<Crate>($@"objects\levels\multi\riverworld\man_cannon_river\man_cannon_river"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_lockout\s3d_lockout_lift\s3d_lockout_lift"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_bridge\man_cannon_bridge"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_skybridge\man_cannon_skybridge"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\man_cannon_skybridge_new\man_cannon_skybridge_new"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_sky_bridgenew\s3d_sky_bridge_lift\sky_bridge"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_waterfall\cyber_pad\cyber_pad"),
                GetCachedTag<Crate>($@"objects\levels\multi\s3d_waterfall\man_cannon_waterfall_2\man_cannon_waterfall_2"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\grav_platform\grav_platform"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_01\holo_panel_01"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_02\holo_panel_02"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holo_panel_03\holo_panel_03"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_jump_pad\holy_jump_pad"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_light_main\holy_light_main"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\holy_light_side\holy_light_side"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo\jittery_holo"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_01\jittery_holo_01"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_02\jittery_holo_02"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_03\jittery_holo_03"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_04\jittery_holo_04"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\jittery_holo_05\jittery_holo_05"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\platform_volume\platform_volume"),
                GetCachedTag<Crate>($@"objects\levels\multi\salvation\small_field\small_field"),
                GetCachedTag<Crate>($@"objects\levels\multi\shrine\sand_jump_pad\sand_jump_pad"),
                GetCachedTag<Crate>($@"objects\levels\solo\060_floodship\flood_danglers\large_dangler\large_dangler"),
                GetCachedTag<Crate>($@"objects\levels\solo\060_floodship\flood_danglers\small_dangler\small_dangler"),
                GetCachedTag<Scenery>($@"levels\dlc\descent\sky\scarab_inc\scarab_inc"),
                GetCachedTag<Scenery>($@"levels\dlc\docks\sky\aircraft_carrier\aircraft_carrier"),
                GetCachedTag<Scenery>($@"levels\dlc\midship\sky\spacedust"),
                GetCachedTag<Scenery>($@"levels\solo\070_waste\sky\waterfall\waterfall"),
                GetCachedTag<Scenery>($@"objects\gear\human\industrial\man_cannon_01\man_cannon_01"),
                GetCachedTag<Scenery>($@"objects\gear\human\industrial\man_cannon_02\man_cannon_02"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\armory\bulb_flicker\bulb_flicker"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\armory\industrial_vent_large\industrial_vent_large"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\chillout\flood_tank\flood_tank"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\descent\egg_shield\egg_shield"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\descent\holo_panel_script1\holo_panel_script1"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\descent\holo_panel_script_yellow\holo_panel_script_yellow"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_3\decal_holiday_3"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_\decal_holiday_"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\decal_holiday_menu\decal_holiday_menu"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\security_red_light\security_red_light"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\docks\speaker\speaker_sound"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\ghosttown\god_ray_small\god_ray_small"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\celltower\celltower"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\celltower_simple\celltower_simple"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\core_shelf\core_shelf"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\h_locker_closed"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\windcups\windcups"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\windsock\windsock"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\lockout\z_poop_cover\z_poop_cover"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\base_floor\base_floor"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\base_floor_red\base_floor_red"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\cov_capital_ship\cov_capital_ship"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\cov_cruiser\cov_cruiser"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\jump_pad\jump_pad"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\midship\jump_pad_mirror\jump_pad_mirror"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\sandbox\grid\grid"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\flag_waver_blue\flag_waver_blue"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\flag_waver_red\flag_waver_red"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_ad_blue\space_ad_blue"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_ad_red\space_ad_red"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_door_small\space_door_small"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_lamp2\space_lamp2"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_lamp\space_lamp"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\space_rays\space_rays"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_hall_lower\spacecamp_collision_hall_lower"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_hall_upper\spacecamp_collision_hall_upper"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_lobase_backedge\spacecamp_collision_lobase_backedge"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_collision_ramp\spacecamp_collision_ramp"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\spacecamp\spacecamp_welcome\spacecamp_welcome"),
                GetCachedTag<Scenery>($@"objects\levels\dlc\warehouse\security_yellow_light\security_yellow_light"),
                GetCachedTag<Scenery>($@"objects\levels\multi\isolation\isolation_collision_walls\isolation_collision_walls"),
                GetCachedTag<Scenery>($@"objects\levels\multi\s3d_lockout\s3d_lockout_lift_visual\s3d_lockout_lift_visual"),
                GetCachedTag<Scenery>($@"objects\levels\multi\s3d_sky_bridge\man_cannon\man_cannon"),
                GetCachedTag<Scenery>($@"objects\levels\multi\s3d_waterfall\longsword_waterfall\longsword_waterfall"),
                GetCachedTag<Scenery>($@"objects\levels\multi\salvation\altar_holo\altar_holo"),
                GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_01\holo_panel_01"),
                GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_02\holo_panel_02"),
                GetCachedTag<Scenery>($@"objects\levels\multi\salvation\holo_panel_03\holo_panel_03"),
                GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field\airlock_field"),
                GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field_cave\airlock_field_cave"),
                GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\airlock_field_lg\airlock_field_lg"),
                GetCachedTag<Scenery>($@"objects\levels\multi\snowbound\cov_defender_mon\cov_defender_mon"),
                GetCachedTag<Scenery>($@"objects\levels\solo\040_voi\voi_door_warehouse_door_a\voi_door_warehouse_door_a"),
                GetCachedTag<Scenery>($@"objects\levels\solo\060_floodship\floodball_pulsing\floodball_pulsing"),
                GetCachedTag<Scenery>($@"objects\levels\solo\060_floodship\floodball_pulsing\floodball_pulsing_isolation"),
                GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays\god_rays"),
                GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays_blue\god_rays_blue"),
                GetCachedTag<Scenery>($@"objects\levels\solo\110_hc\god_rays_long\god_rays_long"),
                GetCachedTag<Scenery>($@"objects\multi\spawning\respawn_point_invisible"),
                GetCachedTag<Scenery>($@"objects\multi\test\player_spawn"),
                GetCachedTag<Scenery>($@"objects\vehicles\hornet\hornet_waterfall"),
                GetCachedTag<Scenery>($@"objects\vehicles\longsword\longsword"),
                GetCachedTag<Scenery>($@"objects\vehicles\pelican\pelican_parked\pelican_parked"),
                GetCachedTag<Scenery>($@"objects\vehicles\pelican\pelican_waterfall"),
                GetCachedTag<Vehicle>($@"objects\levels\dlc\chillout\monitor\monitor"),
                GetCachedTag<Vehicle>($@"objects\levels\dlc\sandbox\sandbox_defender\sandbox_defender"),
                GetCachedTag<Vehicle>($@"objects\levels\multi\cyberdyne\security_camera\security_camera"),
                GetCachedTag<Vehicle>($@"objects\levels\multi\s3d_sky_bridge\hornet_lite\hornet_lite"),
                GetCachedTag<Vehicle>($@"objects\levels\multi\snowbound\cov_defender\cov_defender"),
            };

            var generator = new MapVariantDataGenerator();

            var oldBlf = generator.GenerateData(Stream, Cache, scenario, mapVariant.MapVariant.MapVariant.Metadata, culledObjects);

            var newUserPlacements = generator.GetForgeablePlacements(oldBlf.MapVariant.MapVariant);

            generator.CullForgeObjectsFromScenario(scenario);

            var blf = generator.GenerateData(Stream, Cache, scenario, mapVariant.MapVariant.MapVariant.Metadata, culledObjects);

            generator.ConvertScenarioPlacements(blf.MapVariant.MapVariant, oldBlf.MapVariant.MapVariant.Quotas, newUserPlacements);

            mapVariant.MapVariant.MapVariant.ScenarioObjectCount = GetScenarioObjectCount(blf.MapVariant.MapVariant, scenario);
            mapVariant.MapVariant.MapVariant.VariantObjectCount = GetVariantObjectCount(blf.MapVariant.MapVariant);
            mapVariant.MapVariant.MapVariant.PlaceableQuotaCount = GetPlaceableQuotaCount(blf.MapVariant.MapVariant);
            mapVariant.MapVariant.MapVariant.Objects = blf.MapVariant.MapVariant.Objects;
            mapVariant.MapVariant.MapVariant.ObjectTypeStartIndex = blf.MapVariant.MapVariant.ObjectTypeStartIndex;
            mapVariant.MapVariant.MapVariant.Quotas = blf.MapVariant.MapVariant.Quotas;

            Cache.Serialize(Stream, tag, scenario);
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assigning null tag instead");
                return null;
            }
        }

        public abstract void MapVariantData();
    }
}