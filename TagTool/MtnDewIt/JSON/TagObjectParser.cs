using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.JSON.Handlers;

namespace TagTool.MtnDewIt.JSON
{
    public class TagObjectParser 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private Stream CacheStream;
        private TagObjectHandler Handler;

        public TagObjectParser(GameCache cache, GameCacheHaloOnline cacheContext, Stream cacheStream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            Handler = new TagObjectHandler(Cache, CacheContext, CacheStream);
        }

        public void ParseFile(string filePath) 
        {
            var jsonData = File.ReadAllText($@"{filePath}.json");
            var tagObject = Handler.Deserialize(jsonData);

            var tag = Cache.TagCache.GetTag($@"{tagObject.TagName}.{tagObject.TagData.GetTagStructureInfo(Cache.Version, Cache.Platform).Structure.Name}");

            Cache.Serialize(CacheStream, tag, tagObject.TagData);
            Cache.SaveStrings();
        }
    }
}
