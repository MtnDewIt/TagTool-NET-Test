using Newtonsoft.Json;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.BlamFiles;
using System;

namespace TagTool.MtnDewIt.JSON
{
    public class FileAuthorHandler : JsonConverter<FileAuthor>
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public FileAuthorHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, FileAuthor value, JsonSerializer serializer)
        {
            var fileAuthor = new InlineFileAuthor(CacheFileHeaderDataHaloOnline.GetAuthor(value.Data));

            serializer.Serialize(writer, fileAuthor);
        }

        public override FileAuthor ReadJson(JsonReader reader, Type objectType, FileAuthor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var inlineFileAuthor = serializer.Deserialize<InlineFileAuthor>(reader);

            var fileAuthor = new FileAuthor() 
            {
                Data = CacheFileHeaderDataHaloOnline.SetAuthor(inlineFileAuthor.FileAuthor),
            };

            return fileAuthor;
        }
    }

    public class InlineFileAuthor 
    {
        public string FileAuthor { get; set; }

        public InlineFileAuthor(string author)
        {
            FileAuthor = author;
        }
    }
}
