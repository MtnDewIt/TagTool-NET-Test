using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_magnum_power_chud_definition : TagFile
    {
        public ui_chud_magnum_power_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\magnum_power");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
            //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
            //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
            //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
            //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
            //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.53f, 0.53f);
            //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 14;
            //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
            //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.615f, 0.615f);
            //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(37f, 37f);
            //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 45;
            //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Offset = new RealPoint2d(37f, -37f);
            //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 45;
            //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Offset = new RealPoint2d(-37f, -37f);
            //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 45;
            //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Offset = new RealPoint2d(-37f, 37f);
            //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 45;
            chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(134f, 16f);
            chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
            chdt.HudWidgets[3].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
            chdt.HudWidgets[7].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[7].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[7].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
            chdt.HudWidgets[7].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
            chdt.HudWidgets[7].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
