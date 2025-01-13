using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.IO;
using TagTool.Tags.Definitions;
using TagTool.BlamFile;
using TagTool.JSON.Handlers;

namespace TagTool.JSON.Parsers
{
    public class MapObjectParser
    {
        private GameCache Cache;
        private GameCacheHaloOnlineBase CacheContext;
        private Stream CacheStream;
        private MapObjectHandler Handler;
        private string InputPath;

        public MapObjectParser(GameCache cache, GameCacheHaloOnlineBase cacheContext, Stream cacheStream, string inputPath)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            InputPath = inputPath;
            Handler = new MapObjectHandler(Cache, CacheContext);
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
                    Version = mapObject.MapVersion,
                    CachePlatform = CachePlatform.Original,
                    Header = mapObject.Header,
                    MapFileBlf = mapObject.MapFileBlf,
                };

                var headerData = mapData.Header as CacheFileHeaderGenHaloOnline;
                var scnrTag = Cache.TagCache.GetTag<Scenario>(headerData.ScenarioPath);
                var scnr = CacheContext.Deserialize<Scenario>(CacheStream, scnrTag);

                switch (scnr.MapType)
                {
                    case ScenarioMapType.MainMenu:
                        headerData.CacheType = CacheFileType.MainMenu;
                        break;
                    case ScenarioMapType.SinglePlayer:
                        headerData.CacheType = CacheFileType.Campaign;
                        break;
                    case ScenarioMapType.Multiplayer:
                        headerData.CacheType = CacheFileType.Multiplayer;
                        break;
                }

                headerData.ScenarioTagIndex = scnrTag.Index;

                if (mapData.Version == CacheVersion.HaloOnlineED)
                {
                    if (mapData.MapFileBlf != null && mapData.MapFileBlf.MapVariant.MapVariant != null && mapData.MapFileBlf.MapVariantTagNames.Names != null)
                    {
                        UpdateQuotaIndexes(mapData.MapFileBlf.MapVariantTagNames.Names, mapData.MapFileBlf.MapVariant.MapVariant.Quotas);
                    }
                }

                mapData.Write(writer);
            }
        }

        public void UpdateQuotaIndexes(TagName[] tagNames, VariantObjectQuota[] quotaList)
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
