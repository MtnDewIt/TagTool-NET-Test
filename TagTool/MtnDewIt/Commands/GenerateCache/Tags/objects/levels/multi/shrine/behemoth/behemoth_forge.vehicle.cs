using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class objects_levels_multi_shrine_behemoth_behemoth_forge_vehicle : TagFile
    {
        public objects_levels_multi_shrine_behemoth_behemoth_forge_vehicle(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Vehicle>($@"objects\levels\multi\shrine\behemoth\behemoth_forge");
            var vehi = CacheContext.Deserialize<Vehicle>(Stream, tag);
            vehi.ObjectFlags = new ObjectDefinitionFlags() 
            {
                Flags = ObjectFlags.None,
            };
            vehi.VehicleFlags = Vehicle.VehicleFlagBits.NoFrictionWithDriver | Vehicle.VehicleFlagBits.CanTriggerAutomaticOpeningDoors | Vehicle.VehicleFlagBits.AiDriverEnable;
            CacheContext.Serialize(Stream, tag, vehi);
        }
    }
}
