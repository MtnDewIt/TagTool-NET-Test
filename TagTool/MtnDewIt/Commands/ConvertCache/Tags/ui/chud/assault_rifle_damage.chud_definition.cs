using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_assault_rifle_damage_chud_definition : TagFile
    {
        public ui_chud_assault_rifle_damage_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\assault_rifle_damage");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
            //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
            //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
            //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
            //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[4].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[4].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
            chdt.HudWidgets[4].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
            chdt.HudWidgets[4].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
            //chdt.HudWidgets[5].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.22f, 1.22f);
            //chdt.HudWidgets[5].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.61f, 0.61f);
            //chdt.HudWidgets[5].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorVertically;
            //chdt.HudWidgets[5].BitmapWidgets[1].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            //chdt.HudWidgets[5].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(-10f, 0f);
            //chdt.HudWidgets[5].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.23f, 0.4f);
            //chdt.HudWidgets[5].BitmapWidgets[1].BitmapSequenceIndex = 34;
            //chdt.HudWidgets[5].BitmapWidgets[2].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            //chdt.HudWidgets[5].BitmapWidgets[2].PlacementData[0].Offset = new RealPoint2d(10f, 0f);
            //chdt.HudWidgets[5].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.23f, 0.4f);
            //chdt.HudWidgets[5].BitmapWidgets[2].BitmapSequenceIndex = 34;
            //chdt.HudWidgets[5].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            //chdt.HudWidgets[5].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 10f);
            //chdt.HudWidgets[5].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.4f);
            //chdt.HudWidgets[5].BitmapWidgets[3].BitmapSequenceIndex = 34;
            //chdt.HudWidgets[5].BitmapWidgets[4].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            //chdt.HudWidgets[5].BitmapWidgets[4].PlacementData[0].Offset = new RealPoint2d(0f, -10f);
            //chdt.HudWidgets[5].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.23f, 0.4f);
            //chdt.HudWidgets[5].BitmapWidgets[4].BitmapSequenceIndex = 34;
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
