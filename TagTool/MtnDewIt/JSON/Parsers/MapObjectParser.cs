using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.JSON.Parsers
{
    public class MapObjectParser 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private Stream CacheStream;
        private MapObjectHandler Handler;

        public MapObjectParser(GameCache cache, GameCacheHaloOnline cacheContext, Stream cacheStream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            Handler = new MapObjectHandler(Cache, CacheContext);
        }

        public void ParseFile(string filePath) 
        {
            var jsonData = File.ReadAllText($@"{filePath}.json");
            var mapObject = Handler.Deserialize(jsonData);

            var mapFile = new FileInfo($@"{Cache.Directory.FullName}\{mapObject.MapName}.map");

            using (var stream = mapFile.Create())
            using (var writer = new EndianWriter(stream))
            {
                var mapData = new MapFileData()
                {
                    Version = mapObject.MapVersion,
                    CachePlatform = CachePlatform.Original,
                    Header = mapObject.CacheFileHeaderData,
                    MapFileBlf = mapObject.BlfData,
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

                mapData.WriteData(writer);
            }
        }

        public void UpdateQuotaIndexes(BlfTagName[] tagNames, VariantDataObjectQuota[] quotaList) 
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
