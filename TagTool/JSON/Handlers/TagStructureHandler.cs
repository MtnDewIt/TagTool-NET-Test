using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TagTool.BlamFile.Chunks.Megalo;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.JSON.Handlers
{
    public class TagStructureHandler : JsonConverter<TagStructure>
    {
        private CacheVersion Version;
        private CachePlatform Platform;

        private readonly HashSet<Type> ExludedTypes = new HashSet<Type>
        {
            typeof(TagResourceReference),
            typeof(List<TagResourceReference>),
        };

        public TagStructureHandler(CacheVersion version, CachePlatform platform)
        {
            Version = version;
            Platform = platform;
        }

        public override void WriteJson(JsonWriter writer, TagStructure value, JsonSerializer serializer)
        {
            var structureInfo = TagStructure.GetTagStructureInfo(value.GetType(), Version, Platform);

            writer.WriteStartObject();

            for (int i = 0; i < TagStructure.GetTagFieldEnumerable(structureInfo).Count; i++)
            {
                var tagFieldInfo = TagStructure.GetTagFieldEnumerable(structureInfo)[i];

                var fieldName = tagFieldInfo.Name;
                var fieldType = tagFieldInfo.FieldType;
                var fieldInfo = tagFieldInfo.FieldInfo;
                var fieldValue = tagFieldInfo.GetValue(value);
                var isInvalidField = tagFieldInfo.Attribute != null && tagFieldInfo.Attribute.Flags.HasFlag(TagFieldFlags.Padding) || fieldName.Contains("unused", StringComparison.OrdinalIgnoreCase) || fieldName.Contains("padding", StringComparison.OrdinalIgnoreCase);

                if (!isInvalidField && !ExludedTypes.Contains(fieldType))
                {
                    switch (fieldValue) 
                    {
                        // TODO: Figure out a better way of handling this
                        case SingleLanguageStringTable table:
                            ParseSingleLanguageStringTable(writer, serializer, fieldName, table);
                            break;
                        default:
                            writer.WritePropertyName(fieldName);
                            serializer.Serialize(writer, fieldValue);
                            break;
                    }
                }
            }

            writer.WriteEndObject();
        }

        // TODO: Some how feed this into its own handler
        public static void ParseSingleLanguageStringTable(JsonWriter writer, JsonSerializer serializer, string fieldName, SingleLanguageStringTable table) 
        {
            List<string> strings = SingleLanguageStringTable.GetStrings(table);

            writer.WritePropertyName(fieldName);
            writer.WriteStartObject();

            // TODO: Create a static member to store this (Can only do this if it has its own handler)
            writer.WritePropertyName("Strings");
            serializer.Serialize(writer, strings);

            writer.WriteEndObject();
        }

        public override TagStructure ReadJson(JsonReader reader, Type objectType, TagStructure existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // TODO: Maybe figure out a proper way of deserializing the data
            return existingValue;
        }
    }
}