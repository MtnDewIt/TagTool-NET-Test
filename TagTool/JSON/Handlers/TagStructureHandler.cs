using TagTool.Cache;
using TagTool.Tags;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static TagTool.Tags.Definitions.ModelAnimationGraph;
using TagTool.Geometry;
using TagTool.Scripting;

namespace TagTool.JSON.Handlers
{
    public class TagStructureHandler : JsonConverter<TagStructure>
    {
        private CacheVersion Version;
        private CachePlatform Platform;

        private HashSet<Type> ExludedTypes = new HashSet<Type>
        {
            typeof(List<HsGlobal>),
            typeof(List<HsScript>),
            typeof(List<HsSyntaxNode>),
            typeof(List<ResourceGroup>),
            typeof(List<TagResourceReference>),
            typeof(RenderGeometry),
            typeof(TagResourceReference),
        };

        private HashSet<string> ExcludedNames = new HashSet<string>
        {
            $@"ScriptStrings",
            $@"ScriptSourceFileReferences",
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

                if (!isInvalidField && !ExludedTypes.Contains(fieldType) && !ExcludedNames.Contains(fieldName))
                {
                    writer.WritePropertyName(fieldName);
                    serializer.Serialize(writer, fieldValue);
                }
            }

            writer.WriteEndObject();
        }

        public override TagStructure ReadJson(JsonReader reader, Type objectType, TagStructure existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // TODO: Maybe figure out a proper way of deserializing the data
            return existingValue;
        }
    }
}