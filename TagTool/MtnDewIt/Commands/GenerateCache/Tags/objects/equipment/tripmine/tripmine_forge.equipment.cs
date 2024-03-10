using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class objects_equipment_tripmine_tripmine_forge_equipment : TagFile
    {
        public objects_equipment_tripmine_tripmine_forge_equipment(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Equipment>($@"objects\equipment\tripmine\tripmine_forge");
            var eqip = CacheContext.Deserialize<Equipment>(Stream, tag);
            eqip.MultiplayerObject[0].DefaultSpawnTime = 30;
            eqip.UseDuration = 1E+07f;
            eqip.ProximityMine[0].SelfDestructTime = 1E+07f;
            CacheContext.Serialize(Stream, tag, eqip);
        }
    }
}
