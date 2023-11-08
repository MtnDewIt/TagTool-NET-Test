using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_plasma_turret_chud_definition : TagFile
    {
        public ui_chud_plasma_turret_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\plasma_turret");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            chdt.HudWidgets[0].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[0].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[0].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
            chdt.HudWidgets[0].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
            chdt.HudWidgets[0].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
