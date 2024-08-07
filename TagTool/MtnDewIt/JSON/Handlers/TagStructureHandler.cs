using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Reflection;

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
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            Type objType = value.GetType();

            if (objType.IsPrimitive || objType == typeof(string) || objType.IsValueType)
            {
                writer.WriteValue(value);
                return;
            }

            if (typeof(IEnumerable).IsAssignableFrom(objType))
            {
                writer.WriteStartArray();
                foreach (var item in (IEnumerable)value)
                {
                    serializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
                return;
            }

            writer.WriteStartObject();
            FieldInfo[] fields = objType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                writer.WritePropertyName(field.Name);
                var fieldValue = field.GetValue(value);
                serializer.Serialize(writer, fieldValue);
            }
            writer.WriteEndObject();
        }

        public override TagStructure ReadJson(JsonReader reader, Type objectType, TagStructure existingValue, bool hasExistingValue, JsonSerializer serializer) 
        {
            return existingValue;
        }
    }
}