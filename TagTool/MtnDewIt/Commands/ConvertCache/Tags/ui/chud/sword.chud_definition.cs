using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_sword_chud_definition : TagFile
    {
        public ui_chud_sword_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\sword");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
            //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
            //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
            //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
            chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
            chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
            //chdt.HudWidgets[3].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.483f, 0.483f);
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
