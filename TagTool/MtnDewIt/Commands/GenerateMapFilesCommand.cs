using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands
{
    class GenerateMapFilesCommand : Command
    {
        public GameCache Cache { get; set; }

        public GenerateMapFilesCommand(GameCache cache) : base
        (
            true,
            "GenerateMapFiles",
            "Generates new .map files containing valid scenario and map data.",
            "GenerateMapFiles [MapInfo Directory] [ForceUpdate]",
            "Generates new .map files containing valid scenario and map data."
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            bool forceUpdate = false;
            bool hasMapInfo = false;
            string mapInfo = "";

            if (args.Count >= 1) 
            {
                mapInfo = args[0];
                hasMapInfo = true;
            }
            if (args.Count == 2) 
            {
                if (args[1].ToLower() == "forceupdate") 
                {
                    forceUpdate = true;
                }
            }

            if (Cache is GameCacheHaloOnline)
            {
                if (Cache.Version == CacheVersion.HaloOnlineED)
                {
                    GenerateEDMap(mapInfo, forceUpdate, hasMapInfo);
                }

                if (Cache.Version == CacheVersion.HaloOnlineEDLegacy) 
                {
                    if (Is05Cache())
                    {
                        GenerateMS23Map(mapInfo, forceUpdate, hasMapInfo);
                    }
                    else 
                    {
                        GenerateLegacyMap(mapInfo, forceUpdate, hasMapInfo);
                    }
                }

                if (Cache.Version == CacheVersion.HaloOnline106708)
                {
                    GenerateMS23Map(mapInfo, forceUpdate, hasMapInfo);
                }

                if (Cache.Version >= CacheVersion.HaloOnline235640)
                {
                    GenerateAnvilMap(mapInfo, forceUpdate, hasMapInfo);
                }
            }
            else if (Cache is GameCacheModPackage modPackCache)
            {
                GenerateModPackageMap(modPackCache, mapInfo, hasMapInfo);
            }

            return true;
        }

        public void GenerateModPackageMap(GameCacheModPackage modPackCache, string mapInfo, bool hasMapInfo)
        {
            foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
            {
                if ((scenario as CachedTagHaloOnline).IsEmpty())
                    continue;

                var name = scenario.Name.Split('\\').Last();
                var mapInfoName = $"{name}.mapinfo";
                var mapFileName = $"{name}.map";

                MapFileData map;
                BlfData mapInfoData = null;

                if (hasMapInfo)
                {
                    var mapInfoDir = new DirectoryInfo(mapInfo);
                    var files = mapInfoDir.GetFiles(mapInfoName);
                    if (files.Length != 0)
                    {
                        var mapInfoFile = files[0];
                        using (var stream = mapInfoFile.Open(FileMode.Open, FileAccess.Read))
                        using (var reader = new EndianReader(stream))
                        {
                            CacheVersion version = CacheVersion.Halo3Retail;
                            CachePlatform platform = CachePlatform.Original;

                            switch (reader.Length)
                            {
                                case 0x4e91:
                                    version = CacheVersion.Halo3Retail;
                                    break;
                                case 0x9A01:
                                    version = CacheVersion.Halo3ODST;
                                    break;
                                case 0xCDD9:
                                    version = CacheVersion.HaloReach;
                                    break;
                                default:
                                    throw new Exception("Unexpected map info file size");
                            }

                            mapInfoData = new BlfData(version, platform);
                            mapInfoData.ReadData(reader);
                            mapInfoData.ConvertBlfFormat(CacheVersion.HaloOnlineED);
                        }
                    }
                }

                var tagStream = Cache.OpenCacheRead();
                var scnr = Cache.Deserialize<Scenario>(tagStream, scenario);

                var mapBuilder = new MapFileDataGenerator(CacheVersion.HaloOnlineED);

                if (mapInfoData != null)
                {
                    mapBuilder.MapInfo = mapInfoData.Scenario;
                }

                map = mapBuilder.BuildMap(scenario, scnr);

                var mapStream = new MemoryStream();
                var writer = new EndianWriter(mapStream, leaveOpen: true);
                map.WriteData(writer);

                var header = (CacheFileHeaderDataHaloOnline)map.Header;
                modPackCache.AddMapFile(mapStream, header.MapId);

                if (mapInfoData != null)
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (using map info)");
                }
                else
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (WARNING: not using map info)");
                }
            }
        }

        public void GenerateEDMap(string mapInfo, bool forceUpdate ,bool hasMapInfo)
        {
            foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
            {
                var name = scenario.Name.Split('\\').Last();
                var mapInfoName = $"{name}.mapinfo";
                var mapFileName = $"{name}.map";
                var targetPath = Path.Combine(Cache.Directory.FullName, mapFileName);

                MapFileData map;
                BlfData mapInfoData = null;

                if (hasMapInfo)
                {
                    var mapInfoDir = new DirectoryInfo(mapInfo);
                    var files = mapInfoDir.GetFiles(mapInfoName);
                    if (files.Length != 0)
                    {
                        var mapInfoFile = files[0];
                        using (var stream = mapInfoFile.Open(FileMode.Open, FileAccess.Read))
                        using (var reader = new EndianReader(stream))
                        {
                            CacheVersion version = CacheVersion.Halo3Retail;
                            CachePlatform platform = CachePlatform.Original;

                            switch (reader.Length)
                            {
                                case 0x4e91:
                                    version = CacheVersion.Halo3Retail;
                                    break;
                                case 0x9A01:
                                    version = CacheVersion.Halo3ODST;
                                    break;
                                case 0xCDD9:
                                    version = CacheVersion.HaloReach;
                                    break;
                                default:
                                    throw new Exception("Unexpected map info file size");
                            }

                            mapInfoData = new BlfData(version, platform);
                            mapInfoData.ReadData(reader);
                            mapInfoData.ConvertBlfFormat(CacheVersion.HaloOnlineED);
                        }
                    }
                }

                try
                {
                    var fileInfo = Cache.Directory.GetFiles(mapFileName)[0];
                    map = new MapFileData();
                    using (var stream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                    using (var reader = new EndianReader(stream))
                    {
                        map.ReadData(reader);
                    }

                    // Default values for 0.7 map files (Some values get inverted when the data is deserialized)

                    var header = (CacheFileHeaderDataHaloOnline)map.Header;
                    header.Unknown1 = false;
                    header.TrackedBuild = false;
                    header.HasInsertionPoints = false;
                    header.ScenarioTagIndex = scenario.Index;

                    if (map.MapFileBlf != null)
                    {
                        map.MapFileBlf.Scenario.AllowSavedFilms = false;

                        for (int i = 0; i < map.MapFileBlf.Scenario.Insertions.Length; i++)
                        {
                            var insertion = map.MapFileBlf.Scenario.Insertions[i];

                            insertion.Visible = false;
                        }

                        if (map.MapFileBlf.MapVariant != null)
                        {
                            map.MapFileBlf.MapVariant.MapVariant.Metadata.UserIsOnline = false;
                            map.MapFileBlf.MapVariant.MapVariant.Metadata.IsSurvival = false;
                            map.MapFileBlf.MapVariant.MapVariant.RuntimeShowHelpers = false;
                            map.MapFileBlf.MapVariant.MapVariant.BuiltIn = false;
                        }
                    }

                    if (mapInfoData != null)
                    {
                        if (forceUpdate || map.MapFileBlf == null)
                        {
                            map.MapFileBlf = mapInfoData;
                        }
                    }
                }
                catch (Exception)
                {
                    using (var tagStream = Cache.OpenCacheRead())
                    {
                        var scnr = Cache.Deserialize<Scenario>(tagStream, scenario);

                        var mapBuilder = new MapFileDataGenerator(CacheVersion.HaloOnlineED);

                        if (mapInfoData != null) 
                        {
                            mapBuilder.MapInfo = mapInfoData.Scenario;
                        }

                        map = mapBuilder.BuildMap(scenario, scnr);
                    }
                }

                var targetFile = new FileInfo(targetPath);
                using (var stream = targetFile.Create())
                using (var writer = new EndianWriter(stream))
                {
                    map.WriteData(writer);
                }

                if (mapInfoData != null)
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (using map info)");
                }
                else
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (WARNING: not using map info)");
                }
            }
        }

        public void GenerateLegacyMap(string mapInfo, bool forceUpdate, bool hasMapInfo)
        {
            foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
            {
                var name = scenario.Name.Split('\\').Last();
                var mapInfoName = $"{name}.mapinfo";
                var mapFileName = $"{name}.map";
                var targetPath = Path.Combine(Cache.Directory.FullName, mapFileName);

                MapFileData map;
                BlfData mapInfoData = null;

                if (hasMapInfo)
                {
                    var mapInfoDir = new DirectoryInfo(mapInfo);
                    var files = mapInfoDir.GetFiles(mapInfoName);
                    if (files.Length != 0)
                    {
                        var mapInfoFile = files[0];
                        using (var stream = mapInfoFile.Open(FileMode.Open, FileAccess.Read))
                        using (var reader = new EndianReader(stream))
                        {
                            CacheVersion version = CacheVersion.Halo3Retail;
                            CachePlatform platform = CachePlatform.Original;

                            switch (reader.Length)
                            {
                                case 0x4e91:
                                    version = CacheVersion.Halo3Retail;
                                    break;
                                case 0x9A01:
                                    version = CacheVersion.Halo3ODST;
                                    break;
                                case 0xCDD9:
                                    version = CacheVersion.HaloReach;
                                    break;
                                default:
                                    throw new Exception("Unexpected map info file size");
                            }

                            mapInfoData = new BlfData(version, platform);
                            mapInfoData.ReadData(reader);
                            mapInfoData.ConvertBlfFormat(CacheVersion.HaloOnlineEDLegacy);
                        }
                    }
                }

                try
                {
                    var fileInfo = Cache.Directory.GetFiles(mapFileName)[0];
                    map = new MapFileData();
                    using (var stream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                    using (var reader = new EndianReader(stream))
                    {
                        map.ReadData(reader);
                    }
                
                    // Default values for 0.6 map files (Some values get inverted when the data is deserialized)
                
                    var header = (CacheFileHeaderDataHaloOnline)map.Header;
                    header.FileLength = 339984;
                    header.HasInsertionPoints = false;
                    header.ScenarioTagIndex = scenario.Index;
                
                    if (map.MapFileBlf != null) 
                    {
                        map.MapFileBlf.Scenario.AllowSavedFilms = false;
                
                        for (int i = 0; i < map.MapFileBlf.Scenario.Insertions.Length; i++)
                        {
                            var insertion = map.MapFileBlf.Scenario.Insertions[i];
                
                            insertion.Visible = false;
                        }
                
                        if (map.MapFileBlf.MapVariant != null)
                        {
                            map.MapFileBlf.MapVariant.MapVariant.Metadata.UserIsOnline = false;
                            map.MapFileBlf.MapVariant.MapVariant.Metadata.IsSurvival = false;
                            map.MapFileBlf.MapVariant.MapVariant.RuntimeShowHelpers = false;
                            map.MapFileBlf.MapVariant.MapVariant.BuiltIn = false;
                        }
                    }
                    
                    if (mapInfoData != null)
                    {
                        if (forceUpdate || map.MapFileBlf == null)
                        {
                            map.MapFileBlf = mapInfoData;
                        }
                    }
                }
                catch (Exception)
                {
                    using (var tagStream = Cache.OpenCacheRead())
                    {
                        var scnr = Cache.Deserialize<Scenario>(tagStream, scenario);
                    
                        var mapBuilder = new MapFileDataGenerator(CacheVersion.HaloOnlineEDLegacy);
                
                        if (mapInfoData != null)
                        {
                            mapBuilder.MapInfo = mapInfoData.Scenario;
                        }
                
                        map = mapBuilder.BuildMap(scenario, scnr);
                    }
                }

                var targetFile = new FileInfo(targetPath);
                using (var stream = targetFile.Create())
                using (var writer = new EndianWriter(stream))
                {
                    UpdateBlfData(map);
                    map.WriteData(writer);
                }

                if (mapInfoData != null)
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (using map info)");
                }
                else
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (WARNING: not using map info)");
                }
            }
        }

        public void GenerateMS23Map(string mapInfo, bool forceUpdate, bool hasMapInfo)
        {
            foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
            {
                var name = scenario.Name.Split('\\').Last();
                var mapInfoName = $"{name}.mapinfo";
                var mapFileName = $"{name}.map";
                var targetPath = Path.Combine(Cache.Directory.FullName, mapFileName);

                MapFileData map;
                BlfData mapInfoData = null;

                if (hasMapInfo)
                {
                    var mapInfoDir = new DirectoryInfo(mapInfo);
                    var files = mapInfoDir.GetFiles(mapInfoName);
                    if (files.Length != 0)
                    {
                        var mapInfoFile = files[0];
                        using (var stream = mapInfoFile.Open(FileMode.Open, FileAccess.Read))
                        using (var reader = new EndianReader(stream))
                        {
                            CacheVersion version = CacheVersion.Halo3Retail;
                            CachePlatform platform = CachePlatform.Original;

                            switch (reader.Length)
                            {
                                case 0x4e91:
                                    version = CacheVersion.Halo3Retail;
                                    break;
                                case 0x9A01:
                                    version = CacheVersion.Halo3ODST;
                                    break;
                                case 0xCDD9:
                                    version = CacheVersion.HaloReach;
                                    break;
                                default:
                                    throw new Exception("Unexpected map info file size");
                            }

                            mapInfoData = new BlfData(version, platform);
                            mapInfoData.ReadData(reader);
                            mapInfoData.ConvertBlfFormat(CacheVersion.HaloOnline106708);
                        }
                    }
                }

                try
                {
                    var fileInfo = Cache.Directory.GetFiles(mapFileName)[0];
                    map = new MapFileData();
                    using (var stream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                    using (var reader = new EndianReader(stream))
                    {
                        map.ReadData(reader);
                    }

                    var header = (CacheFileHeaderDataHaloOnline)map.Header;
                    header.FileLength = 339984;
                    header.ScenarioTagIndex = scenario.Index;
                    header.HasInsertionPoints = false;

                    if (mapInfoData != null)
                    {
                        if (forceUpdate || map.MapFileBlf == null)
                        {
                            map.MapFileBlf = mapInfoData;
                        }
                    }
                }
                catch (Exception)
                {
                    using (var tagStream = Cache.OpenCacheRead())
                    {
                        var scnr = Cache.Deserialize<Scenario>(tagStream, scenario);

                        var mapBuilder = new MapFileDataGenerator(CacheVersion.HaloOnline106708);

                        if (mapInfoData != null)
                        {
                            mapBuilder.MapInfo = mapInfoData.Scenario;
                        }

                        map = mapBuilder.BuildMap(scenario, scnr);
                    }
                }

                var targetFile = new FileInfo(targetPath);
                using (var stream = targetFile.Create())
                using (var writer = new EndianWriter(stream))
                {
                    map.WriteData(writer);
                }

                if (mapInfoData != null)
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (using map info)");
                }
                else
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (WARNING: not using map info)");
                }
            }
        }

        public void GenerateAnvilMap(string mapInfo, bool forceUpdate, bool hasMapInfo)
        {
            foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
            {
                var name = scenario.Name.Split('\\').Last();
                var mapInfoName = $"{name}.mapinfo";
                var mapFileName = $"{name}.map";
                var targetPath = Path.Combine(Cache.Directory.FullName, mapFileName);

                MapFileData map;
                BlfData mapInfoData = null;

                if (hasMapInfo)
                {
                    var mapInfoDir = new DirectoryInfo(mapInfo);
                    var files = mapInfoDir.GetFiles(mapInfoName);
                    if (files.Length != 0)
                    {
                        var mapInfoFile = files[0];
                        using (var stream = mapInfoFile.Open(FileMode.Open, FileAccess.Read))
                        using (var reader = new EndianReader(stream))
                        {
                            CacheVersion version = CacheVersion.Halo3Retail;
                            CachePlatform platform = CachePlatform.Original;

                            switch (reader.Length)
                            {
                                case 0x4e91:
                                    version = CacheVersion.Halo3Retail;
                                    break;
                                case 0x9A01:
                                    version = CacheVersion.Halo3ODST;
                                    break;
                                case 0xCDD9:
                                    version = CacheVersion.HaloReach;
                                    break;
                                default:
                                    throw new Exception("Unexpected map info file size");
                            }

                            mapInfoData = new BlfData(version, platform);
                            mapInfoData.ReadData(reader);
                            mapInfoData.ConvertBlfFormat(Cache.Version);
                        }
                    }
                }

                try
                {
                    var fileInfo = Cache.Directory.GetFiles(mapFileName)[0];
                    map = new MapFileData();
                    using (var stream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                    using (var reader = new EndianReader(stream))
                    {
                        map.ReadData(reader);
                    }

                    var header = (CacheFileHeaderDataHaloOnline)map.Header;
                    header.ScenarioTagIndex = scenario.Index;
                    header.HasInsertionPoints = false;

                    if (mapInfoData != null)
                    {
                        if (forceUpdate || map.MapFileBlf == null)
                        {
                            map.MapFileBlf = mapInfoData;
                        }
                    }
                }
                catch (Exception)
                {
                    using (var tagStream = Cache.OpenCacheRead())
                    {
                        var scnr = Cache.Deserialize<Scenario>(tagStream, scenario);

                        var mapBuilder = new MapFileDataGenerator(Cache.Version);

                        if (mapInfoData != null)
                        {
                            mapBuilder.MapInfo = mapInfoData.Scenario;
                        }

                        map = mapBuilder.BuildMap(scenario, scnr);
                    }
                }

                var targetFile = new FileInfo(targetPath);
                using (var stream = targetFile.Create())
                using (var writer = new EndianWriter(stream))
                {
                    map.WriteData(writer);
                }

                if (mapInfoData != null)
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (using map info)");
                }
                else
                {
                    Console.WriteLine($"Scenario tag index for {name}: 0x{scenario.Index:X4} (WARNING: not using map info)");
                }
            }
        }

        // Since the tag cache header data for 0.5 is the exact same as 0.6, we need to perform additional checks to distinguish between the two
        public bool Is05Cache()
        {
            // Tracks the number of legacy tags in the cache file globals
            var legacyTagCount = 0;

            using (var stream = Cache.OpenCacheRead()) 
            {
                var cfgtTag = Cache.TagCache.FindFirstInGroup("cfgt");

                var cfgt = Cache.Deserialize<CacheFileGlobalTags>(stream, cfgtTag);

                for (int i = 0; i < cfgt.GlobalTags.Count; i++)
                {
                    var globalTag = cfgt.GlobalTags[i];

                    if (globalTag.Instance != null) 
                    {
                        // Since 0.6 lacks these specific tag types in the cache file globals, these should only appear in a 0.5 cache
                        if (globalTag.Instance.IsInGroup("draw") || globalTag.Instance.IsInGroup("vfsl"))
                        {
                            legacyTagCount++;
                        }
                    }
                }
            }

            // If it detects one or more legacy tags in the cache file globals, it is safe to assume that this is a 0.5 cache
            if (legacyTagCount >= 1)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void UpdateBlfData(MapFileData mapFile) 
        {
            mapFile.MapFileBlf.StartOfFile.Signature = new Tag(InvertString(mapFile.MapFileBlf.StartOfFile.Signature.ToString()));
            mapFile.MapFileBlf.StartOfFile.Length = InvertInt(mapFile.MapFileBlf.StartOfFile.Length);
            mapFile.MapFileBlf.StartOfFile.MajorVersion = InvertShort(mapFile.MapFileBlf.StartOfFile.MajorVersion);
            mapFile.MapFileBlf.StartOfFile.MinorVersion = InvertShort(mapFile.MapFileBlf.StartOfFile.MinorVersion);
            mapFile.MapFileBlf.StartOfFile.ByteOrderMarker = InvertShort(mapFile.MapFileBlf.StartOfFile.ByteOrderMarker);

            mapFile.MapFileBlf.Scenario.Signature = new Tag(InvertString(mapFile.MapFileBlf.Scenario.Signature.ToString()));
            mapFile.MapFileBlf.Scenario.Length = InvertInt(mapFile.MapFileBlf.Scenario.Length);
            mapFile.MapFileBlf.Scenario.MajorVersion = InvertShort(mapFile.MapFileBlf.Scenario.MajorVersion);
            mapFile.MapFileBlf.Scenario.MinorVersion = InvertShort(mapFile.MapFileBlf.Scenario.MinorVersion);

            if (mapFile.MapFileBlf.MapVariant != null) 
            {
                mapFile.MapFileBlf.MapVariant.Signature = new Tag(InvertString(mapFile.MapFileBlf.MapVariant.Signature.ToString()));
                mapFile.MapFileBlf.MapVariant.Length = InvertInt(mapFile.MapFileBlf.MapVariant.Length);
                mapFile.MapFileBlf.MapVariant.MajorVersion = InvertShort(mapFile.MapFileBlf.MapVariant.MajorVersion);
                mapFile.MapFileBlf.MapVariant.MinorVersion = InvertShort(mapFile.MapFileBlf.MapVariant.MinorVersion);
            }

            mapFile.MapFileBlf.EndOfFile.Signature = new Tag(InvertString(mapFile.MapFileBlf.EndOfFile.Signature.ToString()));
            mapFile.MapFileBlf.EndOfFile.Length = InvertInt(mapFile.MapFileBlf.EndOfFile.Length);
            mapFile.MapFileBlf.EndOfFile.MajorVersion = InvertShort(mapFile.MapFileBlf.EndOfFile.MajorVersion);
            mapFile.MapFileBlf.EndOfFile.MinorVersion = InvertShort(mapFile.MapFileBlf.EndOfFile.MinorVersion);

            mapFile.MapFileBlf.EndOfFile.Length = 0;
            mapFile.MapFileBlf.EndOfFile.MajorVersion = 0;
            mapFile.MapFileBlf.EndOfFile.MinorVersion = 0;
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
    }
}