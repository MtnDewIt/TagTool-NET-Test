using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
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
            var tag = GetCachedTag<Equipment>($@"objects/equipment/concussiveblast_equipment/concussiveblast_equipment");
        }
    }
}
