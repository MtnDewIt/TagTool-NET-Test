using Newtonsoft.Json;
using System;
using System.Text;
using TagTool.Tags;

namespace TagTool.JSON.Handlers
{
    public class TagDataHandler : JsonConverter<TagData>
    {
        public override void WriteJson(JsonWriter writer, TagData value, JsonSerializer serializer)
        {
            byte[] data = null;

            if (value.Data != null) 
            {
                data = value.Data;
            }

            writer.WriteValue(data);
        }

        public override TagData ReadJson(JsonReader reader, Type objectType, TagData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var data = serializer.Deserialize<byte[]>(reader);

            if (data != null) 
            {
                return new TagData 
                {
                    Data = data,
                };
            }

            return null;
        }
    }
}
