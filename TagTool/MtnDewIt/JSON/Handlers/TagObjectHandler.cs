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
                new TagStructureHandler(Cache, CacheContext),

                // I really need to merge all these into a single handler which just takes a generic type as an input :/
                new AngleHandler(),
                new ArgbColorHandler(),
                new BoundsAngleHandler(),
                new BoundsByteHandler(),
                new BoundsFloatHandler(),
                new BoundsIntHandler(),
                new BoundsLongHandler(),
                new BoundsSByteHandler(),
                new BoundsShortHandler(),
                new BoundsUIntHandler(),
                new BoundsULongHandler(),
                new BoundsUShortHandler(),
                new CacheAddressHandler(),
                new DatumHandleHandler(),
                new EnumHandler(),
                new Point2dHandler(),
                new RealArgbColorHandler(),
                new RealBoundingBoxHandler(),
                new RealEulerAngles2dHandler(),
                new RealEulerAngles3dHandler(),
                new RealMatrix4x3Handler(),
                new RealPlane2dHandler(),
                new RealPlane3dHandler(),
                new RealPoint2dHandler(),
                new RealPoint3dHandler(),
                new RealQuaternionHandler(),
                new RealRectangle3dHandler(),
                new RealRgbColorHandler(),
                new RealVector2dHandler(),
                new RealVector3dHandler(),
                new Rectangle2dHandler(),
                new TagHandler(),
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

                // I really need to merge all these into a single handler which just takes a generic type as an input :/
                new AngleHandler(),
                new ArgbColorHandler(),
                new BoundsAngleHandler(),
                new BoundsByteHandler(),
                new BoundsFloatHandler(),
                new BoundsIntHandler(),
                new BoundsLongHandler(),
                new BoundsSByteHandler(),
                new BoundsShortHandler(),
                new BoundsUIntHandler(),
                new BoundsULongHandler(),
                new BoundsUShortHandler(),
                new CacheAddressHandler(),
                new DatumHandleHandler(),
                new EnumHandler(),
                new Point2dHandler(),
                new RealArgbColorHandler(),
                new RealBoundingBoxHandler(),
                new RealEulerAngles2dHandler(),
                new RealEulerAngles3dHandler(),
                new RealMatrix4x3Handler(),
                new RealPlane2dHandler(),
                new RealPlane3dHandler(),
                new RealPoint2dHandler(),
                new RealPoint3dHandler(),
                new RealQuaternionHandler(),
                new RealRectangle3dHandler(),
                new RealRgbColorHandler(),
                new RealVector2dHandler(),
                new RealVector3dHandler(),
                new Rectangle2dHandler(),
                new TagHandler(),
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