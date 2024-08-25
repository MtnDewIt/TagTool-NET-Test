using Newtonsoft.Json;
using System;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class RealMatrix4x3Handler : JsonConverter<RealMatrix4x3>
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;

        public RealMatrix4x3Handler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override void WriteJson(JsonWriter writer, RealMatrix4x3 value, JsonSerializer serializer)
        {
            writer.WriteValue($@"M11: {value.m11}, M12: {value.m12}, M13: {value.m13}, M21: {value.m21}, M22: {value.m22}, M23: {value.m23}, M31: {value.m31}, M32: {value.m32}, M33: {value.m33}, M41: {value.m41}, M42: {value.m42}, M43: {value.m43}");
        }

        public override RealMatrix4x3 ReadJson(JsonReader reader, Type objectType, RealMatrix4x3 existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return new RealMatrix4x3();
        }
    }
}
