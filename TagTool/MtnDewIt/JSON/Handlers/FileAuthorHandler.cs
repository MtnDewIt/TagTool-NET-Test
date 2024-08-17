using Newtonsoft.Json;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.BlamFiles;
using System;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class FileAuthorHandler : JsonConverter<FileAuthor>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public FileAuthorHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, FileAuthor value, JsonSerializer serializer)
        {
            writer.WriteValue(CacheFileHeaderDataHaloOnline.GetAuthor(value.Data));
        }

        public override FileAuthor ReadJson(JsonReader reader, Type objectType, FileAuthor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var fileAuthor = new FileAuthor() 
            {
                Data = CacheFileHeaderDataHaloOnline.SetAuthor(reader.Value.ToString()),
            };

            return fileAuthor;
        }
    }
}
