using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.Commands.MtnDewIt.ConvertCache 
{
    public class levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_render_model : TagFile
    {
        public levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_render_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<RenderModel>($@"levels/ui/mainmenu/objects/odst_recon_cheap/odst_recon_cheap");
        }
    }
}
