using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static TagTool.Tags.Definitions.ModelAnimationGraph;
using TagTool.Geometry;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class TagStructureHandler : JsonConverter<TagStructure>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        private HashSet<Type> ExludedTypes = new HashSet<Type>
        {
            typeof(List<ResourceGroup>),
            typeof(List<Scripting.HsScript>),
            typeof(List<Scripting.HsGlobal>),
            typeof(List<Scripting.HsSyntaxNode>),
            typeof(TagResourceReference),
            typeof(RenderGeometry),
        };

        private HashSet<string> ExcludedNames = new HashSet<string> 
        {
            $@"ScriptStrings",
            $@"ScriptSourceFileReferences",
        };

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