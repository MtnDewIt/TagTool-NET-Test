using System;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands.Common;
using TagTool.Common.Logging;
using TagTool.IO;
using TagTool.Tags.Definitions;

namespace TagTool.BlamFile
{
    public static class MapFileUpdater
    {
        /// <summary>
        /// Creates or updates the map files for each scenario tag in the cache
        /// </summary>
        /// <param name="cache">Cache</param>
        /// <param name="mapInfoDir">Path to the map info directory</param>
        /// <param name="forceUpdate">Force recreation of the .map file</param>
        public static void UpdateMapFiles(GameCacheHaloOnlineBase cache, string mapInfoDir = "", bool forceUpdate = false)
        {
            var helper = new UpdateMapFilesHelper(cache, mapInfoDir, forceUpdate);
            using Stream cacheStream = cache.OpenCacheRead();
            foreach (CachedTagHaloOnline scnrTag in cache.TagCache.FindAllInGroup<Scenario>())
            {
                // ignore base cache references for mod paks
                if (scnrTag.IsEmpty())
                    continue;

                var scnr = cache.Deserialize<Scenario>(cacheStream, scnrTag);
                helper.UpdateMapFile(scnrTag, scnr);
            }
        }

        /// <summary>
        /// Creates or updates the map file for the given scenario
        /// </summary>
        /// <param name="cache">Cache</param>
        /// <param name="scnrTag">Scenario Tag</param>
        /// <param name="scnr">Scenario Definition</param>
        /// <param name="mapInfoDir">Path to the map info directory</param>
        /// <param name="forceUpdate">Force recreation of the .map file</param>
        public static void UpdateMapFile(GameCacheHaloOnlineBase cache, CachedTag scnrTag, Scenario scnr, string mapInfoDir = "", bool forceUpdate = false)
        {
            var helper = new UpdateMapFilesHelper(cache, mapInfoDir, forceUpdate);
            helper.UpdateMapFile(scnrTag, scnr);
        }

        class UpdateMapFilesHelper
        {
            private readonly GameCacheHaloOnlineBase _cache;
            private readonly string _mapInfoDir;
            private readonly bool _forceUpdate;

            public UpdateMapFilesHelper(GameCacheHaloOnlineBase cache, string mapInfoDir, bool forceUpdate)
            {
                _cache = cache;
                _mapInfoDir = mapInfoDir;
                _forceUpdate = forceUpdate;
            }

            public void UpdateMapFile(CachedTag scnrTag, Scenario scnr)
            {
                string mapName = scnrTag.Name.Split('\\').Last();
                string mapInfoFilePath = Path.Combine(_mapInfoDir, $"{mapName}.mapinfo");

                Blf mapInfo = LoadMapInfo(mapInfoFilePath);
                MapFile map = LoadOrBuildMapFile(scnrTag, _forceUpdate, scnr, mapInfo);

                var header = (CacheFileHeaderGenHaloOnline)map.Header;
                header.ScenarioTagIndex = scnrTag.Index;
                if (mapInfo != null && (_forceUpdate || map.MapFileBlf == null))
                {
                    if (map.MapFileBlf == null)
                    {
                        map.MapFileBlf = mapInfo;
                    }
                    else
                    {
                        string name = mapInfo.Scenario.Names[0].Name;
                        string description = mapInfo.Scenario.Descriptions[0].Name;

                        map.MapFileBlf.Scenario = mapInfo.Scenario;
                        map.MapFileBlf.ContentFlags |= BlfFileContentFlags.Scenario;

                        if (map.MapFileBlf.ContentHeader != null)
                        {
                            map.MapFileBlf.ContentHeader.Metadata.Name = name;
                            map.MapFileBlf.ContentHeader.Metadata.Description = description;
                        }

                        if (map.MapFileBlf.MapVariant != null)
                        {
                            map.MapFileBlf.MapVariant.MapVariant.Metadata.Name = name;
                            map.MapFileBlf.MapVariant.MapVariant.Metadata.Description = description;
                        }           
                    }
                }

                SaveMapFile(map, mapName, scnr.MapId);

                if (mapInfo == null)
                    Log.Warning($"Scenario 0x{scnrTag.Index:X4} \"{mapName}\" NOT using map info");
                else
                    Console.WriteLine($"Scenario 0x{scnrTag.Index:X4} \"{mapName}\" using map info");
            }

            private MapFile LoadOrBuildMapFile(CachedTag scnrTag, bool forceUpdate, Scenario scnr, Blf mapInfo)
            {
                try
                {
                    var mapFile = _cache.MapFiles.FindByMapId(scnr.MapId);
                    if (mapFile != null)
                        return mapFile;
                }
                catch (Exception) 
                {
                    Log.Warning($"Unable to load map file for '{scnrTag.Name}'. Building new...");
                }

                return BuildMapFile(scnrTag, scnr, mapInfo);
            }

            private void SaveMapFile(MapFile map, string mapName, int mapId)
            {
                switch (_cache)
                {
                    case GameCacheModPackage modCache:
                        {
                            var mapStream = new MemoryStream();
                            SaveMapFile(map, mapStream);
                            modCache.MapFiles.Add(map, modCache.GetCurrentTagCacheIndex());
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

            private MapFile BuildMapFile(CachedTag scnrTag, Scenario scnr, Blf mapInfo)
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

            private Blf LoadMapInfo(string filePath)
            {
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
        }
    }
}
