using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class levels_ui_mainmenu_objects_spartan_cheap_spartan_cheap_biped : TagFile
    {
        public levels_ui_mainmenu_objects_spartan_cheap_spartan_cheap_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\spartan_cheap\spartan_cheap");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
            bipd.PathfindingSpheres = null;
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
