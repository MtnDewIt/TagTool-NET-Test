using Newtonsoft.Json;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.MtnDewIt.BlamFiles;
using System;
using System.Collections;

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
            var authorString = "";

            if (!Array.TrueForAll(value.Data, b => b == 0))
            {
                authorString = CacheFileHeaderDataHaloOnline.GetAuthor(value.Data);
            }

            writer.WriteValue(authorString);
        }

        public override FileAuthor ReadJson(JsonReader reader, Type objectType, FileAuthor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var authorData = Array.Empty<byte>();
            var authorString = reader.Value.ToString();

            if (authorString != "") 
            {
                authorData = CacheFileHeaderDataHaloOnline.SetAuthor(authorString);
            }

            var fileAuthor = new FileAuthor() 
            {
                Data = authorData,
            };

            return fileAuthor;
        }
    }
}
