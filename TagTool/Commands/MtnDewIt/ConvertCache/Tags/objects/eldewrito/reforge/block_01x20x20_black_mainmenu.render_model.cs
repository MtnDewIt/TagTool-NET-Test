using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class objects_eldewrito_reforge_block_01x20x20_black_mainmenu_render_model : TagFile
    {
        public objects_eldewrito_reforge_block_01x20x20_black_mainmenu_render_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<RenderModel>($@"objects/eldewrito/reforge/block_01x20x20_black_mainmenu");
        }
    }
}
