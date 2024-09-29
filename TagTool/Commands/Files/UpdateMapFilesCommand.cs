using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.Cache.HaloOnline;
using TagTool.BlamFile.MCC;
using TagTool.Tags;
using Newtonsoft.Json;

namespace TagTool.Commands.Files
{
    class UpdateMapFilesCommand : Command
    {
        public GameCache Cache { get; }

        public UpdateMapFilesCommand(GameCache cache)
            : base(true,

                  "UpdateMapFiles",
                  "Updates the game's .map files to contain valid scenario indices.",

                  "UpdateMapFiles <MapInfo Directory> [forceupdate]",

                  "Updates the game's .map files to contain valid scenario indices.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            bool forceUpdate = false;
            bool pathProvided = false;
            string mapInfoPath = "";
            string modInfoPath = "";

            if (args.Count >= 1)
            {
                pathProvided = true;

                if (!Directory.Exists(args[0])) 
                {
                    return new TagToolError(CommandError.ArgInvalid, "Given mapinfo directory does not exist.");
                }
                else 
                {
                    mapInfoPath = args[0];
                    modInfoPath = Path.Combine(args[0], "ModInfo.json");
                }
            }

            if (args.Count == 2)
                if (args[1].ToLower() == "forceupdate")
                    forceUpdate = true;

            var isExcessionData = File.Exists(modInfoPath);

            var cacheStream = Cache.OpenCacheRead();

            if (Cache is GameCacheHaloOnline)
            {
                // Generate / update the map files
                foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
                {
                    var name = scenario.Name.Split('\\').Last();
                    var mapInfoName = $"{name}.mapinfo";
                    var mapFileName = $"{name}.map";
                    var targetPath = Path.Combine(Cache.Directory.FullName, mapFileName);

                    MapFile map;
                    Blf mapInfo = null;

                    if (pathProvided && !isExcessionData)
                    {
                        mapInfo = GetMapInfo(mapInfoPath, mapInfoName);
                    }
                    else if (pathProvided)
                    {
                        mapInfo = GenerateMapInfo(cacheStream, scenario, mapInfoPath, modInfoPath);
                    }

                    try
                    {
                        var fileInfo = Cache.Directory.GetFiles(mapFileName)[0];
                        map = new MapFile();
                        using (var stream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                        using (var reader = new EndianReader(stream))
                            map.Read(reader);

                        var header = (CacheFileHeaderGenHaloOnline)map.Header;
                        header.ScenarioTagIndex = scenario.Index;

                        if (mapInfo != null)
                            if (forceUpdate || map.MapFileBlf == null)
                                map.MapFileBlf = mapInfo;

                    }
                    catch (Exception)
                    {
                        using(var tagStream = Cache.OpenCacheRead())
                        {
                            var scnr = Cache.Deserialize<Scenario>(tagStream, scenario);

                            var mapBuilder = new MapFileBuilder(Cache.Version);
                            mapBuilder.MapInfo = mapInfo?.Scenario;

                            map = mapBuilder.Build(scenario, scnr);
                        }
                    }

                    var targetFile = new FileInfo(targetPath);
                    using (var stream = targetFile.Create())
                    using (var writer = new EndianWriter(stream))
                    {
                        map.Write(writer);
                    }

                    if (mapInfo != null)
                        Console.WriteLine($"Scenario 0x{scenario.Index:X4} \"{name}\" using map info");
                    else
                        new TagToolWarning($"Scenario 0x{scenario.Index:X4} \"{name}\" NOT using map info");

                }
                Console.WriteLine("Done!");
                return true;
            }
            else if(Cache is GameCacheModPackage modCache)
            {
                // Generate / update the map files
                foreach (var scenario in Cache.TagCache.FindAllInGroup("scnr"))
                {
                    // ignore maps that are in the base cache unmodified
                    if ((scenario as CachedTagHaloOnline).IsEmpty())
                        continue;

                    var name = scenario.Name.Split('\\').Last();
                    var mapInfoName = $"{name}.mapinfo";
                    var mapFileName = $"{name}.map";

                    MapFile map;
                    Blf mapInfo = null;

                    if (pathProvided && !isExcessionData)
                    {
                        mapInfo = GetMapInfo(mapInfoPath, mapInfoName);
                    }
                    else if (pathProvided) 
                    {
                        mapInfo = GenerateMapInfo(cacheStream, scenario, mapInfoPath, modInfoPath);
                    }

                    var tagStream = Cache.OpenCacheRead();
                    var scnr = Cache.Deserialize<Scenario>(tagStream, scenario);

                    var mapBuilder = new MapFileBuilder(Cache.Version);
                    mapBuilder.MapInfo = mapInfo?.Scenario;
                    map = mapBuilder.Build(scenario, scnr);

                    var mapStream = new MemoryStream();
                    var writer = new EndianWriter(mapStream, leaveOpen: true);
                    map.Write(writer);

                    var header = (CacheFileHeaderGenHaloOnline)map.Header;
                    modCache.AddMapFile(mapStream, header.MapId);

                    if (mapInfo != null)
                        Console.WriteLine($"Scenario 0x{scenario.Index:X4} \"{name}\" using map info");
                    else
                        new TagToolWarning($"Scenario 0x{scenario.Index:X4} \"{name}\" NOT using map info");
                }
                Console.WriteLine("Done!");
                return true;
            }

            return new TagToolError(CommandError.CacheUnsupported);
        }

        public Blf GetMapInfo(string mapInfoPath, string mapInfoName) 
        {
            var mapInfoDir = new DirectoryInfo(mapInfoPath);
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

                    var mapInfo = new Blf(version, platform);
                    mapInfo.Read(reader);
                    mapInfo.ConvertBlf(Cache.Version);

                    return mapInfo;
                }
            }

            return null;
        }

        public BlfScenario GenerateScenario(object mapInfo, Scenario scnr)
        {
            var scenario = new BlfScenario()
            {
                Signature = "levl",
                Length = (int)TagStructure.GetStructureSize(typeof(BlfScenario), Cache.Version, Cache.Platform),
                MajorVersion = 3,
                MinorVersion = 1,
                Names = Enumerable.Range(0, 12).Select(x => new NameUnicode32 { Name = "" }).ToArray(),
                Descriptions = Enumerable.Range(0, 12).Select(x => new NameUnicode128 { Name = "" }).ToArray(),
            };

            switch (mapInfo)
            {
                case CampaignMapInfo campaignMapInfo:
                    campaignMapInfo.ConvertCampaignMapInfo(scenario, scnr);
                    break;

                case MultiplayerMapInfo multiplayerMapInfo:
                    multiplayerMapInfo.ConvertMultiplayerMapInfo(scenario, scnr);
                    break;

                case FirefightMapInfo firefightMapInfo:
                    firefightMapInfo.ConvertFirefightMapInfo(scenario, scnr);
                    break;
            }

            return scenario;
        }

        public Blf GenerateMapInfo(Stream stream, CachedTag scenario, string mapInfoPath, string modInfoPath) 
        {
            var jsonData = File.ReadAllText(modInfoPath);
            var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);
            var mapInfoList = modInfo.GetMapInfoList(mapInfoPath);

            foreach (var mapInfo in mapInfoList)
            {
                if (scenario.Name.EndsWith(mapInfo.Key))
                {
                    var scnr = Cache.Deserialize<Scenario>(stream, scenario);
                    var blfScenario = GenerateScenario(mapInfo.Value, scnr);

                    var mapBlf = new Blf(Cache.Version, Cache.Platform)
                    {
                        ContentFlags = BlfFileContentFlags.StartOfFile | BlfFileContentFlags.EndOfFile | BlfFileContentFlags.Scenario,

                        StartOfFile = new BlfChunkStartOfFile 
                        {
                            Signature = "_blf",
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkStartOfFile), Cache.Version, Cache.Platform),
                            MajorVersion = 1,
                            MinorVersion = 2,
                            ByteOrderMarker = -2,
                        },

                        EndOfFile = new BlfChunkEndOfFile 
                        {
                            Signature = "_eof",
                            Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkEndOfFile), Cache.Version, Cache.Platform),
                            MajorVersion = 1,
                            MinorVersion = 2
                        },

                        Scenario = blfScenario,
                    };

                    return mapBlf;
                }
            }

            return null;
        }
    }
}