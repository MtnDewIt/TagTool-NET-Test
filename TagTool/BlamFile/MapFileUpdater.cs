using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using TagTool.BlamFile.MCC;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile
{
    public class MapFileUpdater
    {
        /// <summary>
        /// Updates or creates map files for each of the scenario tags in the cache
        /// </summary>
        public static void UpdateMapFiles(GameCache cache, string mapInfoDir = "", bool forceUpdate = false)
        {
            if (!Directory.Exists(mapInfoDir))
                return;

            using var cacheStream = cache.OpenCacheRead();
            new UpdateMapFilesHelper(cache, cacheStream).UpdateMapFiles(mapInfoDir, forceUpdate);
        }

        /// <summary>
        /// Updates or creates map files for each of the scenario tags in the cache
        /// </summary>
        public static void UpdateMapFiles(GameCache cache, GameCache blamCache, bool forceUpdate = false)
        {
            string mapInfoDir = blamCache.Directory != null ? Path.Combine(blamCache.Directory.FullName, "info") : "";
            UpdateMapFiles(cache, mapInfoDir, forceUpdate);
        }

        class UpdateMapFilesHelper
        {
            public GameCache _cache;
            private Stream _cacheStream;

            public UpdateMapFilesHelper(GameCache cache, Stream cacheStream)
            {
                _cache = cache;
                _cacheStream = cacheStream;
            }

            public void UpdateMapFiles(string mapInfoPath, bool forceUpdate)
            {
                foreach (CachedTagHaloOnline scnrTag in _cache.TagCache.FindAllInGroup<Scenario>())
                {
                    if (scnrTag.IsEmpty())
                        continue;

                    UpdateMapFile(scnrTag, mapInfoPath, forceUpdate);
                }
            }

            public void UpdateMapFile(CachedTagHaloOnline scnrTag, string mapInfoDir, bool forceUpdate)
            {
                string mapName = scnrTag.Name.Split('\\').Last();
                string mapInfoFilePath = Path.Combine(mapInfoDir, $"{mapName}.mapinfo");

                bool isExcessionData = File.Exists(Path.Combine(mapInfoDir, "ModInfo.json"));
                if (isExcessionData)
                    mapInfoFilePath = mapInfoDir;

                Scenario scnr = _cache.Deserialize<Scenario>(_cacheStream, scnrTag);
                Blf mapInfo = LoadMapInfo(scnrTag, mapInfoFilePath, isExcessionData);
                MapFile map = LoadOrBuildMapFile(scnrTag, forceUpdate, scnr, mapInfo);

                var header = (CacheFileHeaderGenHaloOnline)map.Header;
                header.ScenarioTagIndex = scnrTag.Index;
                if (mapInfo != null && (forceUpdate || map.MapFileBlf == null))
                    map.MapFileBlf = mapInfo;

                SaveMapFile(map, mapName, scnr.MapId);

                if (mapInfo == null)
                    new TagToolWarning($"Scenario 0x{scnrTag.Index:X4} \"{mapName}\" NOT using map info");
                else
                    Console.WriteLine($"Scenario 0x{scnrTag.Index:X4} \"{mapName}\" using map info");
            }

            private MapFile LoadOrBuildMapFile(CachedTagHaloOnline scnrTag, bool forceUpdate, Scenario scnr, Blf mapInfo)
            {
                try
                {
                    return _cache switch
                    {
                        GameCacheHaloOnline hoCache => LoadMapFile(Path.Combine(_cache.Directory.FullName, $"{scnrTag.Name.Split('\\').Last()}.map")),
                        GameCacheModPackage modCache => LoadMapFile(modCache.BaseModPackage.MapFileStreams[modCache.BaseModPackage.MapIds.IndexOf(scnr.MapId)]),
                        _ => throw new NotSupportedException("Unsupported cache"),
                    };
                }
                catch (Exception)
                {
                    return BuildMapFile(scnrTag, scnr, mapInfo);
                }
            }

            private void SaveMapFile(MapFile map, string mapName, int mapId)
            {
                switch (_cache)
                {
                    case GameCacheModPackage modCache:
                        {
                            var mapStream = new MemoryStream();
                            SaveMapFile(map, mapStream);
                            modCache.AddMapFile(mapStream, mapId);
                        }
                        break;

                    case GameCacheHaloOnline hoCache:
                        {
                            string mapFilePath = Path.Combine(_cache.Directory.FullName, $"{mapName}.map");
                            SaveMapFile(map, mapFilePath);
                        }
                        break;

                    default:
                        throw new NotSupportedException("Unsupported cache type");
                }
            }

            private MapFile BuildMapFile(CachedTagHaloOnline scnrTag, Scenario scnr, Blf mapInfo)
            {
                var mapBuilder = new MapFileBuilder(_cache.Version);
                if (mapInfo != null)
                    mapBuilder.MapInfo = mapInfo.Scenario;
                return mapBuilder.Build(scnrTag, scnr);
            }

            private static MapFile LoadMapFile(string filePath)
            {
                using var stream = File.OpenRead(filePath);
                return LoadMapFile(stream);
            }

            private static MapFile LoadMapFile(Stream stream)
            {
                stream.Position = 0;
                var map = new MapFile();
                var reader = new EndianReader(stream);
                map.Read(reader);
                return map;
            }

            private static void SaveMapFile(MapFile map, string filePath)
            {
                using var stream = File.Create(filePath);
                SaveMapFile(map, stream);
            }

            private static void SaveMapFile(MapFile map, Stream stream)
            {
                stream.Position = 0;
                using var writer = new EndianWriter(stream, leaveOpen: true);
                map.Write(writer);
            }

            private Blf LoadMapInfo(CachedTag scenario, string filePath, bool isExcessionData)
            {
                if (isExcessionData)
                    return GenerateMapInfo(_cacheStream, scenario, filePath);

                if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                    return null;

                using var reader = new EndianReader(File.OpenRead(filePath));

                CacheVersion version = reader.Length switch
                {
                    0x4e91 => CacheVersion.Halo3Retail,
                    0x9A01 => CacheVersion.Halo3ODST,
                    0xCDD9 => CacheVersion.HaloReach,
                    _ => throw new Exception("Unexpected map info file size")
                };

                var mapInfo = new Blf(version, CachePlatform.Original);
                mapInfo.Read(reader);
                mapInfo.ConvertBlf(_cache.Version);
                return mapInfo;
            }

            private Blf GenerateMapInfo(Stream stream, CachedTag scenario, string mapInfoPath)
            {
                var jsonData = File.ReadAllText(Path.Combine(mapInfoPath, "ModInfo.json"));
                var modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonData);
                var mapInfoList = modInfo.GetMapInfoList(mapInfoPath);
                var campaignInfoTable = ModInfo.GetCampaignInfoTable(mapInfoPath);
                var scenarioTable = CampaignInfo.GetScenarioTable(_cache, stream);

                foreach (var mapInfo in mapInfoList)
                {
                    if (scenario.Name.EndsWith(mapInfo.Key))
                    {
                        var scnr = _cache.Deserialize<Scenario>(stream, scenario);

                        var mapBlf = new Blf(_cache.Version, _cache.Platform)
                        {
                            ContentFlags = BlfFileContentFlags.StartOfFile | BlfFileContentFlags.EndOfFile | BlfFileContentFlags.Scenario,

                            StartOfFile = new BlfChunkStartOfFile
                            {
                                Signature = "_blf",
                                Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkStartOfFile), _cache.Version, _cache.Platform),
                                MajorVersion = 1,
                                MinorVersion = 2,
                                ByteOrderMarker = -2,
                            },

                            EndOfFile = new BlfChunkEndOfFile
                            {
                                Signature = "_eof",
                                Length = (int)TagStructure.GetStructureSize(typeof(BlfChunkEndOfFile), _cache.Version, _cache.Platform),
                                MajorVersion = 1,
                                MinorVersion = 2
                            },

                            Scenario = new BlfScenario
                            {
                                Signature = "levl",
                                Length = (int)TagStructure.GetStructureSize(typeof(BlfScenario), _cache.Version, _cache.Platform),
                                MajorVersion = 3,
                                MinorVersion = 1,
                                Names = Enumerable.Repeat(new NameUnicode32 { Name = "" }, 12).ToArray(),
                                Descriptions = Enumerable.Repeat(new NameUnicode128 { Name = "" }, 12).ToArray(),
                                Insertions = Enumerable.Repeat(new BlfScenarioInsertion { Names = Enumerable.Repeat(new NameUnicode32 { Name = "" }, 12).ToArray(), Descriptions = Enumerable.Repeat(new NameUnicode128 { Name = "" }, 12).ToArray() }, 9).ToArray(),
                            },
                        };

                        ModInfo.ConvertMapInfo(scenarioTable, campaignInfoTable, mapInfo.Value, mapBlf.Scenario, scnr);

                        return mapBlf;
                    }
                }

                return null;
            }
        }
    }
}
