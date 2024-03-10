using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class objects_vehicles_wraith_wraith_anti_air_vehicle : TagFile
    {
        public objects_vehicles_wraith_wraith_anti_air_vehicle(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<Vehicle>($@"objects\vehicles\wraith\wraith_anti_air");
            var vehi = CacheContext.Deserialize<Vehicle>(Stream, tag);
            vehi.DefaultModelVariant = CacheContext.StringTable.GetStringId($@"anti_air");
            CacheContext.Serialize(Stream, tag, vehi);
        }
    }
}
