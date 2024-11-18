using Newtonsoft.Json;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.JSON.Objects;

namespace TagTool.JSON.Handlers
{
    public class MapObjectHandler
    {
        private GameCache Cache;
        private GameCacheHaloOnlineBase CacheContext;

        private static List<JsonConverter> Converters;

        public MapObjectHandler(GameCache cache, GameCacheHaloOnlineBase cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;

            Converters = new List<JsonConverter>
            {
                new StringIdHandler(Cache, CacheContext),
                new TagStructureHandler(Cache.Version, Cache.Platform),

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
                new FileCreatorHandler(),
                new LastModificationDateHandler(),
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

        public string Serialize(MapObject input)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = Converters,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(input, settings);
        }

        public MapObject Deserialize(string input)
        {
            var converters = new List<JsonConverter>
            {
                new StringIdHandler(Cache, CacheContext),

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
                new FileCreatorHandler(),
                new LastModificationDateHandler(),
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

            return JsonConvert.DeserializeObject<MapObject>(input, settings);
        }
    }
}
