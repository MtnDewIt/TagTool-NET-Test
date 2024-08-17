using System;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.JSON.Handlers;
using TagTool.Tags;

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

            // TODO: Try and reduce the number of passes required to get a tag

            if (tagObject.Generate)
            {
                if (!Cache.TagCache.TryGetTag($@"{tagObject.TagName}.{tagObject.TagData.GetTagStructureInfo(Cache.Version, Cache.Platform).Structure.Name}", out var result)) 
                {
                    // TODO: Figure out how to pull definition from existing tag table
                    // Once again, we assume that the all the tag definitions are in the same namespace
                    var type = Type.GetType($@"TagTool.Tags.Definitions.{tagObject.TagType}");
                    result = Cache.TagCache.AllocateTag(type, tagObject.TagName);
                    var definition = (TagStructure)Activator.CreateInstance(type);
                    CacheContext.Serialize(CacheStream, result, definition);
                    CacheContext.SaveTagNames();
                }
            }

            var tag = Cache.TagCache.GetTag($@"{tagObject.TagName}.{tagObject.TagData.GetTagStructureInfo(Cache.Version, Cache.Platform).Structure.Name}");

            Cache.Serialize(CacheStream, tag, tagObject.TagData);
            Cache.SaveStrings();
        }
    }
}
