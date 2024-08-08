using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags;
using Newtonsoft.Json;
using System;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class TagStructureHandler : JsonConverter<TagStructure>
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;
        object TagData;

        public TagStructureHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, TagStructure value, JsonSerializer serializer) 
        {
            var structureInfo = TagStructure.GetTagStructureInfo(value.GetType(), Cache.Version, Cache.Platform);

            writer.WriteStartObject();

            for (int i = 0; i < TagStructure.GetTagFieldEnumerable(structureInfo).Count; i++)
            {
                var tagFieldInfo = TagStructure.GetTagFieldEnumerable(structureInfo)[i];

                var fieldName = tagFieldInfo.Name;
                var fieldType = tagFieldInfo.FieldType;
                var fieldInfo = tagFieldInfo.FieldInfo;
                var fieldValue = tagFieldInfo.GetValue(value);
                var isInvalidField = tagFieldInfo.Attribute != null && tagFieldInfo.Attribute.Flags.HasFlag(TagFieldFlags.Padding) || fieldName.Contains("unused", StringComparison.OrdinalIgnoreCase) || fieldName.Contains("padding", StringComparison.OrdinalIgnoreCase);

                if (!isInvalidField)
                {
                    writer.WritePropertyName(fieldName);
                    serializer.Serialize(writer, fieldValue);
                }
            }

            writer.WriteEndObject();
        }

        public override TagStructure ReadJson(JsonReader reader, Type objectType, TagStructure existingValue, bool hasExistingValue, JsonSerializer serializer) 
        {
            return existingValue;
        }
    }
}