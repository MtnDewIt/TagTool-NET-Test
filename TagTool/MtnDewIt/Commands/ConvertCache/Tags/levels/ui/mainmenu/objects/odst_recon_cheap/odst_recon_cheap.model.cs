using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_model : TagFile
    {
        public levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Model>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
            var hlmt = CacheContext.Deserialize<Model>(Stream, tag);
            hlmt.RenderModel = GetCachedTag<RenderModel>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
            hlmt.CollisionModel = GetCachedTag<CollisionModel>($@"objects\characters\odst\odst");
            hlmt.Animation = GetCachedTag<ModelAnimationGraph>($@"objects\characters\marine\marine");
            hlmt.PhysicsModel = GetCachedTag<PhysicsModel>($@"objects\characters\marine\marine");
            CacheContext.Serialize(Stream, tag, hlmt);
        }
    }
}
