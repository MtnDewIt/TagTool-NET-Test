using Newtonsoft.Json;
using TagTool.MtnDewIt.BlamFiles;
using System;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class FileAuthorHandler : JsonConverter<FileAuthor>
    {
        public override void WriteJson(JsonWriter writer, FileAuthor value, JsonSerializer serializer)
        {
            var authorString = "";

            if (!Array.TrueForAll(value.Data, b => b == 0))
            {
                authorString = FileAuthor.GetAuthor(value.Data);
            }

            writer.WriteValue(authorString);
        }

        public override FileAuthor ReadJson(JsonReader reader, Type objectType, FileAuthor existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var authorData = Array.Empty<byte>();
            var authorString = reader.Value.ToString();

            if (authorString != "") 
            {
                authorData = FileAuthor.SetAuthor(authorString);
            }

            var fileAuthor = new FileAuthor() 
            {
                Data = authorData,
            };

            return fileAuthor;
        }
    }
}
