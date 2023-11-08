using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_multi_spawning_initial_spawn_point_scenery : TagFile
    {
        public objects_multi_spawning_initial_spawn_point_scenery(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Scenery>($@"objects\multi\spawning\initial_spawn_point");
            var scen = CacheContext.Deserialize<Scenery>(Stream, tag);
            scen.MultiplayerObject[0].EngineFlags = GameEngineSubTypeFlags.All;
            CacheContext.Serialize(Stream, tag, scen);
        }
    }
}
