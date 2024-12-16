using Newtonsoft.Json;
using TagTool.Cache;
using System;

namespace TagTool.JSON.Handlers
{
    public class FileCreatorHandler : JsonConverter<FileCreator>
    {
        public override void WriteJson(JsonWriter writer, FileCreator value, JsonSerializer serializer)
        {
            var creatorString = "";

            if (!Array.TrueForAll(value.Data, b => b == 0))
            {
                creatorString = FileCreator.GetCreator(value.Data);
            }

            writer.WriteValue(creatorString);
        }

        public override FileCreator ReadJson(JsonReader reader, Type objectType, FileCreator existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var creatorData = Array.Empty<byte>();
            var creatorString = reader.Value.ToString();

            if (creatorString != "")
            {
                creatorData = FileCreator.SetCreator(creatorString);
            }

            var fileCreator = new FileCreator()
            {
                Data = creatorData,
            };

            return fileCreator;
        }
    }
}
