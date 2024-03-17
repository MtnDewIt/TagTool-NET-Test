using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class objects_vehicles_warthog_warthog_snow_no_turret_vehicle : TagFile
    {
        public objects_vehicles_warthog_warthog_snow_no_turret_vehicle(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Vehicle>($@"objects\vehicles\warthog\warthog_snow_no_turret");
            var vehi = CacheContext.Deserialize<Vehicle>(Stream, tag);
            vehi.DefaultModelVariant = CacheContext.StringTable.GetOrAddString($@"no_turret");
            CacheContext.Serialize(Stream, tag, vehi);
        }
    }
}
