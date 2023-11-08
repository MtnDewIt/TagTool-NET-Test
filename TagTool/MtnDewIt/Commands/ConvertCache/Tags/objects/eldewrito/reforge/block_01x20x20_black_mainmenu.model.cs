using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_eldewrito_reforge_block_01x20x20_black_mainmenu_model : TagFile
    {
        public objects_eldewrito_reforge_block_01x20x20_black_mainmenu_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Model>($@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");
            var hlmt = CacheContext.Deserialize<Model>(Stream, tag);
            hlmt.RenderModel = GetCachedTag<RenderModel>($@"objects\eldewrito\reforge\block_01x20x20_black_mainmenu");
            CacheContext.Serialize(Stream, tag, hlmt);
        }
    }
}
