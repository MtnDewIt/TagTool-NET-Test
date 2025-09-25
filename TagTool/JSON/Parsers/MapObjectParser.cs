using System.IO;
using TagTool.Cache.Eldorado;
using TagTool.Cache;
using TagTool.IO;
using TagTool.Tags.Definitions;
using TagTool.BlamFile;
using TagTool.JSON.Handlers;
using TagTool.BlamFile.Chunks;
using TagTool.BlamFile.Chunks.MapVariants;

namespace TagTool.JSON.Parsers
{
    public class MapObjectParser
    {
        private GameCache Cache;
        private GameCacheEldoradoBase CacheContext;
        private Stream CacheStream;
        private MapObjectHandler Handler;
        private string InputPath;

        public MapObjectParser(GameCache cache, GameCacheEldoradoBase cacheContext, Stream cacheStream, string inputPath)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            InputPath = inputPath;
            Handler = new MapObjectHandler(Cache.Version, Cache.Platform);
        }

        public void ParseFile(string filePath)
        {
            var jsonData = File.ReadAllText($@"{InputPath}\data\{filePath}.json");
            var mapObject = Handler.Deserialize(jsonData);

            var mapFile = new FileInfo($@"{Cache.Directory.FullName}\{mapObject.MapName}.map");

            using (var stream = mapFile.Create())
            using (var writer = new EndianWriter(stream))
            {
                var mapData = new MapFile()
                {
                    Version = mapObject.Version,
                    Platform = CachePlatform.Original,
                    Header = mapObject.Header,
                    MapFileBlf = mapObject.MapFileBlf,
                    Reports = mapObject.Reports,
                };

                var scnrTag = Cache.TagCache.GetTag<Scenario>(mapData.Header.GetTagPath());
                var scnr = CacheContext.Deserialize<Scenario>(CacheStream, scnrTag);

                switch (scnr.MapType)
                {
                    case ScenarioMapType.MainMenu:
                        mapData.Header.SetScenarioType(ScenarioType.MainMenu);
                        break;
                    case ScenarioMapType.SinglePlayer:
                        mapData.Header.SetScenarioType(ScenarioType.Solo);
                        break;
                    case ScenarioMapType.Multiplayer:
                        mapData.Header.SetScenarioType(ScenarioType.Multiplayer);
                        break;
                }

                mapData.Header.SetScenarioIndex(scnrTag.Index);

                if (mapData.Version == CacheVersion.EldoradoED)
                {
                    if (mapData.MapFileBlf != null && mapData.MapFileBlf.MapVariant.MapVariant != null && mapData.MapFileBlf.MapVariantTagNames.Names != null)
                    {
                        UpdateQuotaIndexes(mapData.MapFileBlf.MapVariantTagNames.Names, mapData.MapFileBlf.MapVariant.MapVariant.Quotas);
                    }
                }

                mapData.Write(writer);
            }
        }

        public void UpdateQuotaIndexes(BlfMapVariantTagNames.TagName[] tagNames, VariantObjectQuota[] quotaList)
        {
            for (int i = 0; i < tagNames.Length; i++)
            {
                var tagName = tagNames[i];

                if (tagName.Name != null && tagName.Name != "")
                {
                    var tag = CacheContext.TagCache.GetTag(tagName.Name);

                    quotaList[i].ObjectDefinitionIndex = tag.Index;
                }
            }
        }
    }
}
