using System.IO;
using TagTool.Cache;
using TagTool.IO;
using TagTool.BlamFile;
using TagTool.JSON.Handlers;

namespace TagTool.JSON.Parsers
{
    public class BlfObjectParser
    {
        private GameCache Cache;
        private GameCacheHaloOnlineBase CacheContext;
        private Stream CacheStream;
        private BlfObjectHandler Handler;
        private string InputPath;

        public BlfObjectParser(GameCache cache, GameCacheHaloOnlineBase cacheContext, Stream cacheStream, string inputPath)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;
            Handler = new BlfObjectHandler(Cache.Version, Cache.Platform);
            InputPath = inputPath;
        }

        public void ParseFile(string filePath)
        {
            var jsonData = File.ReadAllText($@"{InputPath}\{filePath}.json");
            var blfObject = Handler.Deserialize(jsonData);

            var blfFile = new FileInfo($@"{Cache.Directory.FullName}\{blfObject.FileName}.{blfObject.FileType}");

            using (var stream = blfFile.Create())
            using (var writer = new EndianWriter(stream))
            {
                if (blfObject.Blf.Version == CacheVersion.HaloOnlineED)
                {
                    if (blfObject.Blf != null && blfObject.Blf.MapVariant != null && blfObject.Blf.MapVariantTagNames != null)
                    {
                        UpdateQuotaIndexes(blfObject.Blf.MapVariantTagNames.Names, blfObject.Blf.MapVariant.MapVariant.Quotas);
                    }
                }

                blfObject.Blf.Write(writer);
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
