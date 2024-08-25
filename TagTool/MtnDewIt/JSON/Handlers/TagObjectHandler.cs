using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Tags;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class TagObjectHandler 
    {
        private GameCache Cache;
        private GameCacheHaloOnline CacheContext;
        private Stream CacheStream;

        private static List<JsonConverter> Converters;

        public TagObjectHandler(GameCache cache, GameCacheHaloOnline cacheContext, Stream cacheStream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            CacheStream = cacheStream;

            Converters = new List<JsonConverter>
            {
                new StringIdHandler(Cache, CacheContext),
                new CachedTagHandler(Cache, CacheContext, CacheStream),
                new TagHandler(Cache, CacheContext),
                new TagStructureHandler(Cache, CacheContext),
                new EnumHandler(Cache, CacheContext),

                // I really need to merge all these into a single handler which just takes a generic type as an input :/
                new AngleHandler(Cache, CacheContext),
                new ArgbColorHandler(Cache, CacheContext),
                new BoundsHandler(Cache, CacheContext),
                new DatumHandleHandler(Cache, CacheContext),
                new RealArgbColorHandler(Cache, CacheContext),
                new RealEulerAngles2dHandler(Cache, CacheContext),
                new RealEulerAngles3dHandler(Cache, CacheContext),
                new RealMatrix4x3Handler(Cache, CacheContext),
                new RealPlane2dHandler(Cache, CacheContext),
                new RealPlane3dHandler(Cache, CacheContext),
                new RealPoint2dHandler(Cache, CacheContext),
                new RealPoint3dHandler(Cache, CacheContext),
                new RealQuaternionHandler(Cache, CacheContext),
                new RealRectangle3dHandler(Cache, CacheContext),
                new RealRgbColorHandler(Cache, CacheContext),
                new RealVector3dHandler(Cache, CacheContext),
                new Rectangle2dHandler(Cache, CacheContext),
            };
        }

        public string Serialize(TagObject input)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = Converters,
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public TagObject Deserialize(string input)
        {
            var converters = new List<JsonConverter> 
            {
                new StringIdHandler(Cache, CacheContext),
                new CachedTagHandler(Cache, CacheContext, CacheStream),
                new TagHandler(Cache, CacheContext),
                new EnumHandler(Cache, CacheContext),
            };

            var settings = new JsonSerializerSettings
            {
                Converters = converters,
                Formatting = Formatting.Indented
            };

            return JsonConvert.DeserializeObject<TagObject>(input, settings);
        }
    }
}