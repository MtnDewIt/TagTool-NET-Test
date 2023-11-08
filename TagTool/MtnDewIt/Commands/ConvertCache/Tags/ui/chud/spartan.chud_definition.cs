using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_spartan_chud_definition : TagFile
    {
        public ui_chud_spartan_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\spartan");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
            chdt.HudWidgets.Remove(chdt.HudWidgets[38]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[37]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[36]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[35]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[34]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[33]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[32]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[31]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[30]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[29]);
            chdt.HudWidgets[28].TextWidgets.Remove(chdt.HudWidgets[28].TextWidgets[0]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[23]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[22]);
            chdt.HudWidgets.Remove(chdt.HudWidgets[21]);
            chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1f, 0);
            chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[0].BitmapWidgets[1].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[0].BitmapWidgets[2].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[0].BitmapWidgets[3].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[0].BitmapWidgets[4].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[0].BitmapWidgets[5].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.38f, 0.38f);
            chdt.HudWidgets[1].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[2].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[4].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[4].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[4].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[5].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[6].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.605f, 0.605f);
            chdt.HudWidgets[8].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[8].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[10].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Center;
            chdt.HudWidgets[10].PlacementData[0].Offset = new RealPoint2d(0f, 0f);
            chdt.HudWidgets[11].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[11].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[12].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[12].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[16].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[16].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[17].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[17].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
            chdt.HudWidgets[20].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
            chdt.HudWidgets[20].BitmapWidgets[1].PlacementData[0].Origin = new RealPoint2d(-4.7f, 0f);
            chdt.HudWidgets[20].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
            chdt.HudWidgets[20].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.5f);
            chdt.HudWidgets[22].BitmapWidgets[0].RenderData[0].ShaderType = ChudDefinition.HudWidgetBase.RenderDatum.ChudShaderType.MeterGradient;
            chdt.HudWidgets[22].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[22].BitmapWidgets[1].PlacementData[0].Origin = new RealPoint2d(-1f, -0.253f);
            chdt.HudWidgets[22].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(1.1665f, 1.1665f);
            chdt.HudWidgets[22].BitmapWidgets[1].RenderData[0].ShaderType = ChudDefinition.HudWidgetBase.RenderDatum.ChudShaderType.MeterGradient;
            chdt.HudWidgets[22].BitmapWidgets[1].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[23].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(2.515f, 0.75f);
            chdt.HudWidgets[23].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 579f);
            chdt.HudWidgets[23].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[23].BitmapWidgets[1].PlacementData[0].Origin = new RealPoint2d(-1f, 0f);
            chdt.HudWidgets[23].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(1.121f, 1.121f);
            chdt.HudWidgets[23].BitmapWidgets[1].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[23].BitmapWidgets[2].PlacementData[0].Origin = new RealPoint2d(-2.515f, 0.75f);
            chdt.HudWidgets[23].BitmapWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 579f);
            chdt.HudWidgets[23].BitmapWidgets[2].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[24].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(-3.49f, 0f);
            chdt.HudWidgets[24].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 74f);
            chdt.HudWidgets[24].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[24].BitmapWidgets[1].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.TopLeft;
            chdt.HudWidgets[24].BitmapWidgets[1].PlacementData[0].Origin = new RealPoint2d(-1.25f, 0f);
            chdt.HudWidgets[24].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, -50f);
            chdt.HudWidgets[24].BitmapWidgets[1].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[24].BitmapWidgets[2].PlacementData[0].Origin = new RealPoint2d(5.95f, 0f);
            chdt.HudWidgets[24].BitmapWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 44f);
            chdt.HudWidgets[24].BitmapWidgets[2].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[24].BitmapWidgets[3].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.TopLeft;
            chdt.HudWidgets[24].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(-2.645f, 0f);
            chdt.HudWidgets[24].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 164f);
            chdt.HudWidgets[24].BitmapWidgets[3].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[24].BitmapWidgets[4].PlacementData[0].Origin = new RealPoint2d(2.01f, 0f);
            chdt.HudWidgets[24].BitmapWidgets[4].PlacementData[0].Offset = new RealPoint2d(0f, -49f);
            chdt.HudWidgets[24].BitmapWidgets[4].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[24].BitmapWidgets[5].PlacementData[0].Origin = new RealPoint2d(0.1f, 0f);
            chdt.HudWidgets[24].BitmapWidgets[5].PlacementData[0].Offset = new RealPoint2d(0f, 192f);
            chdt.HudWidgets[24].BitmapWidgets[5].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            chdt.HudWidgets[25].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.TopCenter;
            chdt.HudWidgets[25].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
            chdt.HudWidgets[25].PlacementData[0].Offset = new RealPoint2d(0f, 105f);
            chdt.HudWidgets[25].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(2.99f, 0f);
            chdt.HudWidgets[25].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
