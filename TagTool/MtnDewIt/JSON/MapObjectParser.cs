using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.IO;
using TagTool.MtnDewIt.BlamFiles;

namespace TagTool.MtnDewIt.JSON
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
                    Header = mapObject.CacheFileHeaderData,
                    MapFileBlf = mapObject.BlfData,
                };

                // TODO: Add checks for map variant data, check if the map variant or the tag list isn't null

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
