using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_equipment_concussiveblast_equipment_concussiveblast_equipment_equipment : TagFile
    {
        public objects_equipment_concussiveblast_equipment_concussiveblast_equipment_equipment(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Equipment>($@"objects\equipment\concussiveblast_equipment\concussiveblast_equipment");
            var eqip = CacheContext.Deserialize<Equipment>(Stream, tag);
            eqip.EnterAnimation = CacheContext.StringTable.GetStringId($@"con_blast_enter");
            eqip.ExitAnimation = CacheContext.StringTable.GetStringId($@"con_blast_exit");
            CacheContext.Serialize(Stream, tag, eqip);
        }
    }
}
