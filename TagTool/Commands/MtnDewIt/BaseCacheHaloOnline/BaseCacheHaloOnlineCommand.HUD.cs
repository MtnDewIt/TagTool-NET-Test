using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags.Definitions.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheHaloOnlineCommand : Command
    {
        public void ApplyHUDPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\spartan")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\elite")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].BitmapWidgets[0].StateData[0].WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull;
                        chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[0].BitmapWidgets[1].StateData[0].WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull;
                        chdt.HudWidgets[0].BitmapWidgets[1].PlacementData[0].Origin = new RealPoint2d(-2.7f, 0f);
                        chdt.HudWidgets[0].BitmapWidgets[1].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[0].BitmapWidgets[2].StateData[0].WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull;
                        chdt.HudWidgets[0].BitmapWidgets[2].PlacementData[0].Origin = new RealPoint2d(1f, 5.69f);
                        chdt.HudWidgets[0].BitmapWidgets[2].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorVertically | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[0].BitmapWidgets[3].Name = CacheContext.StringTable.GetStringId("upper_corners_480_wide");
                        chdt.HudWidgets[0].BitmapWidgets[3].StateData[0].WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull;
                        chdt.HudWidgets[0].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(-2.4f, 0f);
                        chdt.HudWidgets[0].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 109.5f);
                        chdt.HudWidgets[0].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(1.8f, -1.8f);
                        chdt.HudWidgets[0].BitmapWidgets[3].RuntimeWidgetIndex = 7;
                        chdt.HudWidgets[0].BitmapWidgets[3].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally;
                        chdt.HudWidgets[0].BitmapWidgets[4].Name = CacheContext.StringTable.GetStringId("center_480_wide");
                        chdt.HudWidgets[0].BitmapWidgets[4].StateData[0].WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull;
                        chdt.HudWidgets[0].BitmapWidgets[4].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Center;
                        chdt.HudWidgets[0].BitmapWidgets[4].PlacementData[0].Origin = new RealPoint2d(1.01f, 9f);
                        chdt.HudWidgets[0].BitmapWidgets[4].PlacementData[0].Offset = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[0].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(1.305f, 0.9f);
                        chdt.HudWidgets[0].BitmapWidgets[4].RuntimeWidgetIndex = 8;
                        chdt.HudWidgets[0].BitmapWidgets[4].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorVertically;
                        chdt.HudWidgets[0].BitmapWidgets[4].Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\elite_middle");
                        chdt.HudWidgets[0].BitmapWidgets[5].Name = CacheContext.StringTable.GetStringId("lower_corners_480_wide");
                        chdt.HudWidgets[0].BitmapWidgets[5].StateData[0].WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull;
                        chdt.HudWidgets[0].BitmapWidgets[5].PlacementData[0].Origin = new RealPoint2d(-2.4f, 0f);
                        chdt.HudWidgets[0].BitmapWidgets[5].PlacementData[0].Offset = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[0].BitmapWidgets[5].RuntimeWidgetIndex = 9;
                        chdt.HudWidgets[0].BitmapWidgets[5].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally;
                        chdt.HudWidgets[0].BitmapWidgets.Remove(chdt.HudWidgets[0].BitmapWidgets[9]);
                        chdt.HudWidgets[0].BitmapWidgets.Remove(chdt.HudWidgets[0].BitmapWidgets[8]);
                        chdt.HudWidgets[0].BitmapWidgets.Remove(chdt.HudWidgets[0].BitmapWidgets[7]);
                        chdt.HudWidgets[0].BitmapWidgets.Remove(chdt.HudWidgets[0].BitmapWidgets[6]);
                        chdt.HudWidgets[1].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_medium");
                        chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1f, -1f);
                        chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, -30f);
                        chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(2.07f, 1.55f);
                        chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[1].BitmapWidgets[1].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[1].BitmapWidgets[2].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[1].BitmapWidgets[3].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[1].BitmapWidgets[4].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[1].BitmapWidgets[5].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[2].PlacementData[0].Offset = new RealPoint2d(17f, 11f);
                        chdt.HudWidgets[2].PlacementData[0].Scale = new RealPoint2d(1.07f, 1.07f);
                        chdt.HudWidgets[2].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_medium");
                        chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(82f, -96f);
                        chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Offset = new RealPoint2d(82f, -94f);
                        chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(82f, -94f);
                        chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Offset = new RealPoint2d(135f, 2f);
                        chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Offset = new RealPoint2d(135f, 2f);
                        chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Offset = new RealPoint2d(135f, 2f);
                        chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[2].BitmapWidgets[7].PlacementData[0].Offset = new RealPoint2d(135f, 2f);
                        chdt.HudWidgets[2].BitmapWidgets[7].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[3].PlacementData[0].Offset = new RealPoint2d(-38f, 22f);
                        chdt.HudWidgets[3].PlacementData[0].Scale = new RealPoint2d(1.25f, 1.25f);
                        chdt.HudWidgets[3].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[4].PlacementData[0].Offset = new RealPoint2d(-38f, 22f);
                        chdt.HudWidgets[4].PlacementData[0].Scale = new RealPoint2d(1.25f, 1.25f);
                        chdt.HudWidgets[4].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
                        chdt.HudWidgets[4].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[4].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
                        chdt.HudWidgets[4].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].PlacementData[0].Offset = new RealPoint2d(-38f, 22f);
                        chdt.HudWidgets[5].PlacementData[0].Scale = new RealPoint2d(1.25f, 1.25f);
                        chdt.HudWidgets[5].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
                        chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
                        chdt.HudWidgets[5].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[6].PlacementData[0].Offset = new RealPoint2d(-38f, 22f);
                        chdt.HudWidgets[6].PlacementData[0].Scale = new RealPoint2d(1.25f, 1.25f);
                        chdt.HudWidgets[6].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
                        chdt.HudWidgets[6].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.45f);
                        chdt.HudWidgets[6].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[7].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_zero");
                        chdt.HudWidgets[7].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.605f, 0.605f);
                        chdt.HudWidgets[8].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[9].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_large");
                        chdt.HudWidgets[9].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[9].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[9].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[10].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Center;
                        chdt.HudWidgets[10].PlacementData[0].Offset = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[10].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[10].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[11].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Center;
                        chdt.HudWidgets[11].PlacementData[0].Offset = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[11].PlacementData[0].Scale = new RealPoint2d(1.31f, 1.29f);
                        chdt.HudWidgets[11].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[12].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_large");
                        chdt.HudWidgets[12].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[12].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[12].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[13].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_zero");
                        chdt.HudWidgets[13].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[13].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[14].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[15].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small");
                        chdt.HudWidgets[16].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_large");
                        chdt.HudWidgets[16].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[16].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[16].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[17].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_large");
                        chdt.HudWidgets[17].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[17].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[17].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[18].PlacementData[0].Scale = new RealPoint2d(0.7f, 0.7f);
                        chdt.HudWidgets[18].ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_zero");
                        chdt.HudWidgets.Add(new ChudDefinition.HudWidget());
                        chdt.HudWidgets.Add(new ChudDefinition.HudWidget());
                        chdt.HudWidgets.Add(new ChudDefinition.HudWidget());
                        chdt.HudWidgets.Add(new ChudDefinition.HudWidget());
                        chdt.HudWidgets[19] = new ChudDefinition.HudWidget 
                        {
                            Name = CacheContext.StringTable.GetStringId("consumable1"),
                            ScriptingClass = ChudDefinition.ChudScriptingClass.Consumable,
                            SortLayer = ChudDefinition.WidgetLayerEnum.Foreground,
                            StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>()
                            {
                                new ChudDefinition.HudWidgetBase.StateDatum()
                                {
                                    InverseFlags = ChudDefinition.HudWidgetBase.StateDatum.Inverse.NotZoomedIn,
                                },
                            },
                            PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>()
                            {
                                new ChudDefinition.HudWidgetBase.PlacementDatum()
                                {
                                    Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Equipment,
                                    Offset = new RealPoint2d(0f, -10f),
                                    Scale = new RealPoint2d(1.1f, 1.1f),
                                },
                            },
                            ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_small"),
                            BitmapWidgets = new List<ChudDefinition.HudWidget.BitmapWidget>()
                            {
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("cons_icon"),
                                    SortLayer = ChudDefinition.WidgetLayerEnum.Foreground,
                                    RuntimeWidgetIndex = 90,
                                    Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.SpriteFromConsumable,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\equipment_scematics_h3"),
                                    StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>()
                                    {
                                        new ChudDefinition.HudWidgetBase.StateDatum()
                                        {
                                            ConsumableFlags = ChudDefinition.HudWidgetBase.StateDatum.Consumable.Consumable1Available,
                                        },
                                    },
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>()
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum()
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Offset = new RealPoint2d(20f, 120f),
                                            Scale = new RealPoint2d(1.4f, 1.4f),
                                        },
                                    },
                                    AnimationData = new List<ChudDefinition.HudWidgetBase.AnimationDatum>()
                                    {
                                        new ChudDefinition.HudWidgetBase.AnimationDatum()
                                        {
                                            Active = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct()
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\equipment_kablam"),
                                            },
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>()
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum()
                                        {
                                            ExternalInput = ChudDefinition.HudWidgetBase.RenderDatum.ChudRenderExternalInputHO.UnknownX51,
                                            OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground,
                                            OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.LocalA,
                                            OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.LocalA,
                                            OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.LocalA,
                                            OutputColorE = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.LocalA,
                                            OutputColorF = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.LocalA,
                                            OutputScalarA = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarB = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarC = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarD = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarE = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarF = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                        },
                                    },
                                },
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("consumable1_activation"),
                                    ScriptingClass = ChudDefinition.ChudScriptingClass.UseParent,
                                    SortLayer = ChudDefinition.WidgetLayerEnum.Background,
                                    RuntimeWidgetIndex = 175,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\hud_meter"),
                                    StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>()
                                    {
                                        new ChudDefinition.HudWidgetBase.StateDatum()
                                        {
                                            ConsumableFlags = ChudDefinition.HudWidgetBase.StateDatum.Consumable.Consumable1Active,
                                        },
                                    },
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>()
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum()
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Offset = new RealPoint2d(120f, 125f),
                                            Scale = new RealPoint2d(-0.6f, 0.6f),
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>()
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum()
                                        {
                                            ShaderType = ChudDefinition.HudWidgetBase.RenderDatum.ChudShaderType.Meter,
                                            BlendModeHO = ChudDefinition.HudWidgetBase.RenderDatum.ChudBlendMode.AlphaBlend,
                                            ExternalInput = ChudDefinition.HudWidgetBase.RenderDatum.ChudRenderExternalInputHO.Consumable1Charge,
                                            LocalScalarB = 0.75f,
                                            LocalScalarC = 0.075f,
                                            OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground,
                                            OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground,
                                            OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground,
                                            OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.LocalA,
                                            OutputColorE = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.LocalA,
                                            OutputColorF = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.LocalA,
                                            OutputScalarA = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.Input,
                                            OutputScalarB = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalA,
                                            OutputScalarC = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalB,
                                            OutputScalarD = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalC,
                                            OutputScalarE = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalD,
                                            OutputScalarF = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.Input,
                                        },
                                    },
                                },
                            },
                        };
                        chdt.HudWidgets[20] = new ChudDefinition.HudWidget
                        {
                            Name = CacheContext.StringTable.GetStringId("hit_marker"),
                            ScriptingClass = ChudDefinition.ChudScriptingClass.Crosshair,
                            SortLayer = ChudDefinition.WidgetLayerEnum.Foreground,
                            StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>()
                            {
                                new ChudDefinition.HudWidgetBase.StateDatum()
                                {

                                },
                            },
                            PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>()
                            {
                                new ChudDefinition.HudWidgetBase.PlacementDatum()
                                {
                                    Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Crosshair,
                                    Scale = new RealPoint2d(1.75f, 1.75f),
                                },
                            },
                            ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_zero"),
                            BitmapWidgets = new List<ChudDefinition.HudWidget.BitmapWidget> 
                            {
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("hit_marker_low"),
                                    SortLayer = ChudDefinition.WidgetLayerEnum.Parent,
                                    RuntimeWidgetIndex = 102,
                                    Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally | ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorVertically,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\hit_markers"),
                                    BitmapSequenceIndex = 2,
                                    StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.StateDatum
                                        {
                                            WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideHalf | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardHalf | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideQuarter | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeQuarter | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardQuarter,
                                            GeneralKudosFlags = ChudDefinition.HudWidgetBase.StateDatum.GeneralKudos.HitMarkerLow,
                                        },
                                    },
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Origin = new RealPoint2d(-3f, 3f),
                                            Scale = new RealPoint2d(1f, 1f),
                                        },
                                    },
                                    AnimationData = new List<ChudDefinition.HudWidgetBase.AnimationDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.AnimationDatum
                                        {
                                            Active = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\invisible"),
                                            },
                                            Impulse = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\hit_marker_low"),
                                            },
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum
                                        {
                                            ShaderType = ChudDefinition.HudWidgetBase.RenderDatum.ChudShaderType.Crosshair,
                                            ExternalInput = ChudDefinition.HudWidgetBase.RenderDatum.ChudRenderExternalInputHO.Autoaim,
                                            OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairEnemy,
                                            OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairEnemy,
                                            OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairFriendly,
                                            OutputScalarB = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarC = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarD = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarE = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarF = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                        },
                                    },
                                },
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("hit_marker_med"),
                                    SortLayer = ChudDefinition.WidgetLayerEnum.Parent,
                                    RuntimeWidgetIndex = 103,
                                    Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\hit_markers"),
                                    BitmapSequenceIndex = 1,
                                    StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.StateDatum
                                        {
                                            WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideHalf | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardHalf | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideQuarter | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeQuarter | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardQuarter,
                                            GeneralKudosFlags = ChudDefinition.HudWidgetBase.StateDatum.GeneralKudos.HitMarkerMedium,
                                        },
                                    },
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Origin = new RealPoint2d(-6.5f, 0f),
                                            Scale = new RealPoint2d(1f, 1f),
                                        },
                                    },
                                    AnimationData = new List<ChudDefinition.HudWidgetBase.AnimationDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.AnimationDatum
                                        {
                                            Active = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\invisible"),
                                            },
                                            Impulse = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\hit_marker_high"),
                                            },
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum
                                        {
                                            ShaderType = ChudDefinition.HudWidgetBase.RenderDatum.ChudShaderType.Crosshair,
                                            ExternalInput = ChudDefinition.HudWidgetBase.RenderDatum.ChudRenderExternalInputHO.Autoaim,
                                            OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairEnemy,
                                            OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairEnemy,
                                            OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairFriendly,
                                            OutputScalarB = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarC = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarD = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarE = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarF = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                        },
                                    },
                                },
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("hit_marker_high"),
                                    SortLayer = ChudDefinition.WidgetLayerEnum.Parent,
                                    RuntimeWidgetIndex = 104,
                                    Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\hit_markers"),
                                    StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.StateDatum
                                        {
                                            WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideHalf | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardHalf | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideQuarter | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeQuarter | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardQuarter,
                                            GeneralKudosFlags = ChudDefinition.HudWidgetBase.StateDatum.GeneralKudos.HitMarkerHigh,
                                        },
                                    },
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Origin = new RealPoint2d(-5f, 0f),
                                            Scale = new RealPoint2d(1f, 1f),
                                        },
                                    },
                                    AnimationData = new List<ChudDefinition.HudWidgetBase.AnimationDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.AnimationDatum
                                        {
                                            Active = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\invisible"),
                                            },
                                            Impulse = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\hit_marker_high"),
                                            },
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum
                                        {
                                            ShaderType = ChudDefinition.HudWidgetBase.RenderDatum.ChudShaderType.Crosshair,
                                            ExternalInput = ChudDefinition.HudWidgetBase.RenderDatum.ChudRenderExternalInputHO.Autoaim,
                                            OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairEnemy,
                                            OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairEnemy,
                                            OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.CrosshairFriendly,
                                            OutputScalarB = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarC = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarD = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarE = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                            OutputScalarF = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                        },
                                    },
                                },
                            },
                        };
                        chdt.HudWidgets[21] = new ChudDefinition.HudWidget
                        {
                            Name = CacheContext.StringTable.GetStringId("stamina_meter"),
                            ScriptingClass = ChudDefinition.ChudScriptingClass.Stamina,
                            SortLayer = ChudDefinition.WidgetLayerEnum.Parent,
                            StateData = new List<ChudDefinition.HudWidgetBase.StateDatum> 
                            {
                                new ChudDefinition.HudWidgetBase.StateDatum
                                {
                                    UnitGeneralFlags = ChudDefinition.HudWidgetBase.StateDatum.UnitGeneral.ThirdPersonCamera,
                                    InverseFlags = ChudDefinition.HudWidgetBase.StateDatum.Inverse.NotZoomedIn,
                                },
                            },
                            PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>()
                            {
                                new ChudDefinition.HudWidgetBase.PlacementDatum()
                                {
                                    Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.BottomLeft,
                                    Offset = new RealPoint2d(68f, -50f),
                                    Scale = new RealPoint2d(1.16f, 1.16f),
                                },
                            },
                            ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_medium"),
                            BitmapWidgets = new List<ChudDefinition.HudWidget.BitmapWidget>
                            {
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("border"),
                                    RuntimeWidgetIndex = 144,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\stamina_meter_border"),
                                    StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.StateDatum
                                        {
                                            Player_SpecialFlags = ChudDefinition.HudWidgetBase.StateDatum.Player_Special.Bit10_HO,
                                        },
                                    },
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Offset = new RealPoint2d(3f, -3f),
                                            Scale = new RealPoint2d(-0.96f, -0.97f),
                                        },
                                    },
                                    AnimationData = new List<ChudDefinition.HudWidgetBase.AnimationDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.AnimationDatum
                                        {
                                            Initializing = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\sprint_meter"),
                                            },
                                            Flashing = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\sprint_border"),
                                            },
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum
                                        {
                                            OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground,
                                            OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.PrimaryBackground,
                                            OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground,
                                            OutputScalarA = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.FlashAnimation,
                                        },
                                    },
                                },
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("meter"),
                                    SortLayer = ChudDefinition.WidgetLayerEnum.Foreground,
                                    RuntimeWidgetIndex = 145,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\stamina_meter"),
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Offset = new RealPoint2d(3f, -3f),
                                            Scale = new RealPoint2d(-0.96f, -0.97f),
                                        },
                                    },
                                    AnimationData = new List<ChudDefinition.HudWidgetBase.AnimationDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.AnimationDatum
                                        {
                                            Initializing = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\sprint_meter"),
                                            },
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum
                                        {
                                            ShaderType = ChudDefinition.HudWidgetBase.RenderDatum.ChudShaderType.Meter,
                                            ExternalInput = ChudDefinition.HudWidgetBase.RenderDatum.ChudRenderExternalInputHO.UnitStaminaCurrent,
                                            LocalScalarB = 1,
                                            OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground,
                                            OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.PrimaryBackground,
                                            OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground,
                                            OutputScalarB = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalA,
                                            OutputScalarC = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalB,
                                            OutputScalarD = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalC,
                                            OutputScalarE = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalD,
                                            OutputScalarF = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.RangeInput,
                                        },
                                    },
                                },
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("icon"),
                                    RuntimeWidgetIndex = 146,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\stamina_icon_elite"),
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Offset = new RealPoint2d(-110f, -90f),
                                            Scale = new RealPoint2d(0.9f, 0.9f),
                                        },
                                    },
                                    AnimationData = new List<ChudDefinition.HudWidgetBase.AnimationDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.AnimationDatum
                                        {
                                            Initializing = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\sprint_meter"),
                                            },
                                            Active = new ChudDefinition.HudWidgetBase.AnimationDatum.ChudWidgetAnimationStruct
                                            {
                                                Animation = GetCachedTag<ChudAnimationDefinition>($@"ui\chud\animations\dim_lines"),
                                            },
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum
                                        {
                                            OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground,
                                            OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.PrimaryBackground,
                                            OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground,
                                            OutputScalarA = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.FlashAnimation,
                                        },
                                    },
                                },
                            },
                        };
                        chdt.HudWidgets[22] = new ChudDefinition.HudWidget
                        {
                            Name = CacheContext.StringTable.GetStringId("vision_warning"),
                            ScriptingClass = ChudDefinition.ChudScriptingClass.UseParent,
                            SortLayer = ChudDefinition.WidgetLayerEnum.Parent,
                            StateData = new List<ChudDefinition.HudWidgetBase.StateDatum> 
                            {
                                new ChudDefinition.HudWidgetBase.StateDatum
                                {
                                    WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideHalf | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardHalf | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideQuarter | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeQuarter,
                                    GeneralKudosFlags = ChudDefinition.HudWidgetBase.StateDatum.GeneralKudos.EnemyVisionActive,
                                    UnitZoomFlags = ChudDefinition.HudWidgetBase.StateDatum.UnitZoom.BinocularsEnabled,
                                    UnitGeneralFlags = ChudDefinition.HudWidgetBase.StateDatum.UnitGeneral.BinocularsNotActive,
                                },
                            },
                            PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>()
                            {
                                new ChudDefinition.HudWidgetBase.PlacementDatum()
                                {
                                    Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.TopCenter,
                                    Offset = new RealPoint2d(0f, 60f),
                                    Scale = new RealPoint2d(1f, 1f),
                                },
                            },
                            ParallaxData = GetCachedTag<ChudWidgetParallaxData>($@"ui\chud\parallax_data\angle_medium"),
                            BitmapWidgets = new List<ChudDefinition.HudWidget.BitmapWidget>
                            {
                                new ChudDefinition.HudWidget.BitmapWidget
                                {
                                    Name = CacheContext.StringTable.GetStringId("visr_warning"),
                                    SortLayer = ChudDefinition.WidgetLayerEnum.Inherited,
                                    RuntimeWidgetIndex = 158,
                                    Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch,
                                    Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\visr_warning"),
                                    PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.PlacementDatum()
                                        {
                                            Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Parent,
                                            Origin = new RealPoint2d(2.9f, -0.2f),
                                            Scale = new RealPoint2d(1f, 1f),
                                        },
                                    },
                                    RenderData = new List<ChudDefinition.HudWidgetBase.RenderDatum>
                                    {
                                        new ChudDefinition.HudWidgetBase.RenderDatum
                                        {
                                            LocalColorA = new ArgbColor(0, 255, 0, 0),
                                            LocalScalarA = 1,
                                            OutputScalarA = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalA,
                                            OutputScalarB = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalA,
                                            OutputScalarC = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalA,
                                            OutputScalarD = ChudDefinition.HudWidgetBase.RenderDatum.OutputScalarValue.LocalA,
                                        },
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\scoreboard")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[0].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-11f, 2.5f);
                        chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.56f, 0.56f);
                        chdt.HudWidgets[1].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[7].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-11f, 2.5f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.56f, 0.56f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[6].Name = CacheContext.StringTable.GetStringId("bomb_dropped");
                        chdt.HudWidgets[2].TextWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[6].InputString = CacheContext.StringTable.GetStringId("gm_assault_bomb_dropped");
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-2f, 2);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.58f, 0.58f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Offset = new RealPoint2d(-2f, 2);
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.58f, 0.58f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[4].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[4].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.88f, 1.2f);
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, -25f);
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.38f, 0.38f);
                        chdt.HudWidgets[4].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
                        chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
                        chdt.HudWidgets[5].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[7].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.BottomRight;
                        chdt.HudWidgets[7].PlacementData[0].Offset = new RealPoint2d(55f, -150f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\scoreboard_elite")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset.X = 40f;
                        chdt.HudWidgets[0].TextWidgets[0].RenderData[0].OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[0].TextWidgets[0].RenderData[0].OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[0].TextWidgets[0].RenderData[0].OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[0].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[0].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].PlacementData[0].Offset.X = 40f;
                        chdt.HudWidgets[1].BitmapWidgets[0].RenderData[0].OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[1].BitmapWidgets[0].RenderData[0].OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.PrimaryBackground;
                        chdt.HudWidgets[1].BitmapWidgets[1].RenderData[0].OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground;
                        chdt.HudWidgets[1].BitmapWidgets[2].RenderData[0].OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[1].BitmapWidgets[2].RenderData[0].OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.PrimaryBackground;
                        chdt.HudWidgets[1].BitmapWidgets[4].RenderData[0].OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[1].TextWidgets[0].RenderData[0].OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[1].TextWidgets[0].RenderData[0].OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[1].TextWidgets[0].RenderData[0].OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[1].TextWidgets[0].RenderData[0].OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-11f, 2.5f);
                        chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.56f, 0.56f);
                        chdt.HudWidgets[1].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[1].TextWidgets[7].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].PlacementData[0].Offset.X = 40f;
                        chdt.HudWidgets[2].BitmapWidgets[0].RenderData[0].OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[2].BitmapWidgets[0].RenderData[0].OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.PrimaryBackground;
                        chdt.HudWidgets[2].BitmapWidgets[1].RenderData[0].OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground;
                        chdt.HudWidgets[2].BitmapWidgets[1].RenderData[0].OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground;
                        chdt.HudWidgets[2].BitmapWidgets[1].RenderData[0].OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground;
                        chdt.HudWidgets[2].BitmapWidgets[1].RenderData[0].OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.HighlightForeground;
                        chdt.HudWidgets[2].BitmapWidgets[2].RenderData[0].OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[2].BitmapWidgets[2].RenderData[0].OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.PrimaryBackground;
                        chdt.HudWidgets[2].TextWidgets[0].RenderData[0].OutputColorA = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[2].TextWidgets[0].RenderData[0].OutputColorB = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[2].TextWidgets[0].RenderData[0].OutputColorC = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[2].TextWidgets[0].RenderData[0].OutputColorD = ChudDefinition.HudWidgetBase.RenderDatum.OutputColorValue_HO.SecondaryBackground;
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-11f, 2.5f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.56f, 0.56f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[6].Name = CacheContext.StringTable.GetStringId("bomb_dropped");
                        chdt.HudWidgets[2].TextWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.6476191f, 0.6476191f);
                        chdt.HudWidgets[2].TextWidgets[6].InputString = CacheContext.StringTable.GetStringId("gm_assault_bomb_dropped");
                        chdt.HudWidgets[3].PlacementData[0].Offset.X = 40;
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-2f, 2);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.58f, 0.58f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Offset = new RealPoint2d(-2f, 2);
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.58f, 0.58f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[4].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, -75f);
                        chdt.HudWidgets[4].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(1f, 1f);
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, -100f);
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.38f, 0.38f);
                        chdt.HudWidgets[4].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
                        chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
                        chdt.HudWidgets[5].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[7].PlacementData[0].Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.BottomRight;
                        chdt.HudWidgets[7].PlacementData[0].Offset = new RealPoint2d(55f, -140f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_assault")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        chdt.HudWidgets[2].TextWidgets[3].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        chdt.HudWidgets[2].TextWidgets[4].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_ctf")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        chdt.HudWidgets[2].TextWidgets[3].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        chdt.HudWidgets[2].TextWidgets[4].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_editor")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[1].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[1].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_infection")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[1].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[1].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[1].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_juggernaut")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[1].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[1].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[1].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_king")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[0].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[0].BitmapWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[0].BitmapWidgets[2].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[2].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].BitmapWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].BitmapWidgets[2].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[2].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].TextWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].TextWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[3].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].TextWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].TextWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_oddball")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[0].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[0].BitmapWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[0].BitmapWidgets[2].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[2].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].BitmapWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].BitmapWidgets[2].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[2].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].TextWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].TextWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[3].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].TextWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].TextWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_slayer")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[0].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[0].BitmapWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[0].BitmapWidgets[2].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[0].BitmapWidgets[2].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].BitmapWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[1].BitmapWidgets[2].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[1].BitmapWidgets[2].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].TextWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.FreeForAll;
                        chdt.HudWidgets[2].TextWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[3].BitmapWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].BitmapWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].TextWidgets[0].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.TeamGame;
                        chdt.HudWidgets[3].TextWidgets[1].StateData[0].EnergyMeterFlags = ChudDefinition.HudWidgetBase.StateDatum.EnergyMeter.None;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_territories")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        chdt.HudWidgets[2].TextWidgets[3].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        chdt.HudWidgets[2].TextWidgets[4].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_vip")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[1].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[2].TextWidgets[2].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        chdt.HudWidgets[2].TextWidgets[3].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[2].TextWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        chdt.HudWidgets[2].TextWidgets[4].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[3].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[4].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[5].PlacementData[0].Offset = new RealPoint2d(0f, 140f);
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.LargeBodyText;
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.55f, 0.55f);
                        chdt.HudWidgets[5].TextWidgets[1].Font = WidgetFontValue.LargeBodyText;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\assault_rifle") 
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        //chdt.HudWidgets[5].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.585f, 0.585f);
                        //chdt.HudWidgets[5].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.None;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\assault_rifle_v5")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\assault_rifle_v2")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\assault_rifle_v6")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\assault_rifle_v3")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\battle_rifle")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.585f, 0.585f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.None;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\battle_rifle_v2")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.22f, 1.22f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.47f, 0.47f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.8f, 0.8f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 33;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\battle_rifle_v3")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.22f, 1.22f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.61f, 0.61f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.8f, 0.8f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 33;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\battle_rifle_v4")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.22f, 1.22f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.8f, 0.8f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 33;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\battle_rifle_v6")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.22f, 1.22f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.51f, 0.51f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.8f, 0.8f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 33;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\battle_rifle_v5")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.22f, 1.22f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.61f, 0.61f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.8f, 0.8f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 33;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\battle_rifle_v1")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.22f, 1.22f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.61f, 0.61f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.8f, 0.8f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 33;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 33;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\beam_rifle")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(-20f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(3.65f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.56f, 0.56f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.53f, 0.53f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\brute_shot")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[4].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[4].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[4].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[4].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\carbine")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.575f, 0.575f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\carbine_v2")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].Name = CacheContext.StringTable.GetStringId($@"overheat_flash");
                        //chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].SkinState = ChudDefinition.HudWidgetBase.StateDatum.ChudSkinState.Elite;
                        //chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].WindowState = ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.WideFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.NativeFull | ChudDefinition.HudWidgetBase.StateDatum.ChudWindowState.StandardFull;
                        //chdt.HudWidgets[1].BitmapWidgets[0].StateData[0].Weapon_SpecialFlags = ChudDefinition.HudWidgetBase.StateDatum.Weapon_Special.Overheated;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(11f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(10.5f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.47f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 37;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\carbine_v4")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(11f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(10.5f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.47f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 37;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\carbine_v6")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(11f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(10.5f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.47f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 37;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\carbine_v3")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(11f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(10.5f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.47f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 37;
                        chdt.HudWidgets[7].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[7].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[7].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[7].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[7].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\carbine_v1")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(11f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.45f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(10.5f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.47f, 0.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 39;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[5].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].BitmapSequenceIndex = 37;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\dmr")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.49f, 0.49f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.76f, 0.76f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\dmr_v2")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.4f, 0.4f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.49f, 0.49f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\dmr_v1")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.49f, 0.49f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.76f, 0.76f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\dmr_v4")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.575f, 0.575f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.9f, 0.9f);
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\dmr_v6")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.44f, 0.44f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.69f, 0.69f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\dmr_v3")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.58f, 0.58f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.9f, 0.9f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\excavator")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\excavator_v3")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\flamethrower")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.61f, 0.61f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].BitmapSequenceIndex = 53;
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[2].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\fuel_rod_cannon")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        //chdt.HudWidgets[4].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.47f, 0.47f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\hammer")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\machinegun_turret")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[0].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[0].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[0].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[0].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\magnum")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.586f, 0.586f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 14;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(134f, 16f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\magnum_v2")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
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
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\magnum_v3")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\missile")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[1].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[1].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[1].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[1].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        //chdt.HudWidgets[3].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.605f, 0.605f);
                        //chdt.HudWidgets[3].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.605f, 0.605f);
                        //chdt.HudWidgets[3].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.605f, 0.605f);
                        //chdt.HudWidgets[3].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.7139f, 0.7139f);
                        //chdt.HudWidgets[3].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.7139f, 0.7139f);
                        //chdt.HudWidgets[3].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0.7139f, 0.7139f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\needler")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.423f, 0.423f);
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[4].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[4].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[4].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[4].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\plasma_pistol")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(-20, 30);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(3.65f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.62f, 0.62f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\plasma_pistol_v3")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(-20f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(3.65f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0f, -0.01f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 0;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.7f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.7f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.7f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 37;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Origin = new RealPoint2d(0f, -0.01f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 0;
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\plasma_rifle")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(-20f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(3.65f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.567f, 0.567f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\plasma_rifle_v6")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(-20f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(3.65f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(3.42f, 3.42f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.37f, 0.37f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 6;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Origin = new RealPoint2d(19.5f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally;
                        //chdt.HudWidgets[2].BitmapWidgets[1].BitmapSequenceIndex = 41;
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Origin = new RealPoint2d(19.5f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.MirrorHorizontally;
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 41;
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.7619048f, 0.7619048f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\plasma_turret")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[0].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[0].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[0].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[0].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\rocket")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.69f, 0.69f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.9904762f, 0.9904762f);
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.9904762f, 0.9904762f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\sentinel_beam")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(-20f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(3.65f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.59f, 0.59f);
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[4].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\shotgun")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.474f, 0.474f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.None;
                        chdt.HudWidgets[4].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[4].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[4].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[4].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[4].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        //chdt.HudWidgets[5].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.474f, 0.474f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\smg")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.595f, 0.595f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(134f, 16f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\smg_v2")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.745f, 0.745f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.None;
                        //chdt.HudWidgets[1].BitmapWidgets[0].BitmapSequenceIndex = 42;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[1].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[1].BitmapWidgets[4].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[1].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[1].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[1].BitmapWidgets[7].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[1].BitmapWidgets[8].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(134f, 16f);
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[2].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        //chdt.HudWidgets[6].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[6].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[6].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[7].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[7].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[7].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[7].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\smg_v4")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.745f, 0.745f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.None;
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 42;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[7].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[8].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(134f, 16f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\smg_v6")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.745f, 0.745f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.None;
                        //chdt.HudWidgets[1].BitmapWidgets[0].BitmapSequenceIndex = 42;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[1].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[1].BitmapWidgets[2].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[1].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[1].BitmapWidgets[3].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[1].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[1].BitmapWidgets[4].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[1].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[1].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[1].BitmapWidgets[7].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[1].BitmapWidgets[8].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[2].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[2].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(134f, 16f);
                        chdt.HudWidgets[2].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[2].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        //chdt.HudWidgets[6].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[6].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[6].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[7].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[7].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[7].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[7].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\smg_v1")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.745f, 0.745f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.None;
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 42;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[2].BitmapWidgets[4].PlacementData[0].Scale = new RealPoint2d(0.25f, 0.55f);
                        //chdt.HudWidgets[2].BitmapWidgets[4].BitmapSequenceIndex = 34;
                        //chdt.HudWidgets[2].BitmapWidgets[5].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[7].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[8].PlacementData[0].Scale = new RealPoint2d(0f, 0f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(134f, 16f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[6].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[6].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[6].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\sniper_rifle")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.65f, 0.65f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.53f, 0.53f);
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\spartan_laser")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(-20f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(3.65f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.38f, 0.38f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].BitmapSequenceIndex = 43;
                        //chdt.HudWidgets[2].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.38f, 0.38f);
                        //chdt.HudWidgets[2].BitmapWidgets[1].BitmapSequenceIndex = 43;
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Origin = new RealPoint2d(0f, -33f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].PlacementData[0].Scale = new RealPoint2d(1f, 0.9f);
                        //chdt.HudWidgets[2].BitmapWidgets[2].BitmapSequenceIndex = 45;
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Origin = new RealPoint2d(0f, 33f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].PlacementData[0].Scale = new RealPoint2d(1f, 0.9f);
                        //chdt.HudWidgets[2].BitmapWidgets[3].BitmapSequenceIndex = 45;
                        //chdt.HudWidgets[2].BitmapWidgets[6].PlacementData[0].Scale = new RealPoint2d(0.41f, 0.41f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(175f, 16f);
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[0].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\spike_rifle")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.51f, 0f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 64f);
                        //chdt.HudWidgets[0].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0.04f, -0.01f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(3.75f, 3.75f);
                        //chdt.HudWidgets[1].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.Stretch;
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Offset = new RealPoint2d(45f, 30f);
                        //chdt.HudWidgets[1].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(-3.4f, 3.75f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(0f, 0f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.6f, 0.6f);
                        //chdt.HudWidgets[2].BitmapWidgets[0].Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.None;
                        chdt.HudWidgets[3].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(134f, 16f);
                        chdt.HudWidgets[3].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[3].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        chdt.HudWidgets[5].TextWidgets[0].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[1].PlacementData[0].Scale = new RealPoint2d(0.5f, 0.5f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Offset = new RealPoint2d(-134f, 16f);
                        chdt.HudWidgets[5].TextWidgets[2].PlacementData[0].Scale = new RealPoint2d(0.465f, 0.465f);
                        chdt.HudWidgets[5].TextWidgets[2].Font = WidgetFontValue.FullscreenHudMessage;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\sword")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }
                }
            }
        }

        public void ChudGlobals()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                foreach (var tag in CacheContext.TagCache.NonNull())
                {
                    if (tag.IsInGroup("chgd") && tag.Name == $@"ui\chud\globals")
                    {
                        var chgd = CacheContext.Deserialize<ChudGlobalsDefinition>(stream, tag);
                        chgd.HudGlobals[0].HudAttributes[0].StateMessageScale = 0.7f;
                        chgd.HudGlobals[0].HudAttributes[0].MessageAnchorVerticalOffset = 0.0935f;
                        chgd.HudGlobals[0].HudAttributes[0].MedalScale = 1.15f;
                        chgd.HudGlobals[0].HudAttributes[0].MedalWidth = 66f;
                        chgd.HudGlobals[0].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.61f);
                        chgd.HudGlobals[0].HudAttributes[0].MessageScale = 0.7f;
                        chgd.HudGlobals[0].HudAttributes[0].MessageHeight = 30f;
                        chgd.HudGlobals[0].HudAttributes[0].MessageOffset = new RealPoint2d(0f, 0.67f);
                        chgd.HudGlobals[0].HudSounds[14].LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None;
                        chgd.HudGlobals[0].HudSounds[15].LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None;
                        chgd.HudGlobals[0].WaypointMaxDistanceScale = 1f;
                        chgd.HudGlobals[1].HudAttributes[0].ResolutionFlags = ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.WideFull | ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.StandardFull;
                        chgd.HudGlobals[1].HudAttributes[0].MotionSensorOrigin = new RealPoint2d(104.5f, 988f);
                        chgd.HudGlobals[1].HudAttributes[0].MotionSensorRadius = 87f;
                        chgd.HudGlobals[1].HudAttributes[0].StateMessageScale = 0.7f;
                        chgd.HudGlobals[1].HudAttributes[0].StateLeftRightOffset_HO = new RealPoint2d(0.016f, 0.16f);
                        chgd.HudGlobals[1].HudAttributes[0].MessageAnchorVerticalOffset = 0.1f;
                        chgd.HudGlobals[1].HudAttributes[0].MedalScale = 1.15f;
                        chgd.HudGlobals[1].HudAttributes[0].MedalWidth = 66f;
                        chgd.HudGlobals[1].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.61f);
                        chgd.HudGlobals[1].HudAttributes[0].MultiplayerMedalsOffset = new RealPoint2d(0.64f, 2f);
                        chgd.HudGlobals[1].HudAttributes[0].MessageScale = 0.7f;
                        chgd.HudGlobals[1].HudAttributes[0].MessageHeight = 30f;
                        chgd.HudGlobals[1].HudAttributes[0].MessageOffset = new RealPoint2d(0f, 0.67f);
                        chgd.HudGlobals[1].HudAttributes[1].MessageAnchorVerticalOffset = 0.15f;
                        chgd.HudGlobals[1].HudSounds = new List<ChudGlobalsDefinition.HudGlobal.HudSound>
                        {
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldRecharging,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\shield_charge_dervish\shield_charge_dervish"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldLow,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\shield_low_dervish\shield_low_dervish"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldEmpty,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\shield_depleted_dervish\shield_depleted_dervish"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.RocketLocking,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\weapons\rocket_launcher\tracking_locking\tracking_locking"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.RocketLocked,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\weapons\rocket_launcher\tracking_locked\tracking_locked"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.TrackedTarget,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\weapons\missile_launcher\tracking_locking\tracking_locking"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.LockedTarget,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\weapons\missile_launcher\tracking_locked\tracking_locked"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.StaminaRecharge,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\stamina_charge\stamina_charge"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.StaminaFull,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\stamina_charged\stamina_charged"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.StaminaWarning,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<SoundLooping>($@"sound\game_sfx\ui\stamina_depleted\stamina_depleted"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.WinningPoints,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\points_earn\points_earn"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldMinorDamage,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\shield_hit_small\shield_hit_small"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldMajorDamage,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\shield_hit_med\shield_hit_med"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.ShieldCriticalDamage,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\shield_hit_large\shield_hit_large"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.TacticalPackageUsed,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\tactical_package_used\tactical_package_used"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.TacticalPackageError,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\tactical_package_error\tactical_package_error"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\tactical_package_available\tactical_package_available"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\tactical_package_full\tactical_package_full"),
                                    },
                                },
                            },
                            new ChudGlobalsDefinition.HudGlobal.HudSound
                            {
                                LatchedTo = ChudGlobalsDefinition.HudGlobal.HudSound.ChudSoundCueFlags.None,
                                Scale = 0,
                                Bipeds = new List<ChudGlobalsDefinition.HudGlobal.HudSound.BipedData>
                                {
                                    new ChudGlobalsDefinition.HudGlobal.HudSound.BipedData
                                    {
                                        BipedType_HO = ChudGlobalsDefinition.HudGlobal.HudSound.BipedData.BipedTypeValue_HO.Elite,
                                        Sound = GetCachedTag<Sound>($@"sound\game_sfx\ui\headshot_indicator\headshot_indicator"),
                                    },
                                },
                            },
                        };
                        chgd.HudGlobals[1].DirectionalArrowScale = 45f;
                        chgd.HudGlobals[1].ScoreboardHud = GetCachedTag<ChudDefinition>($@"ui\chud\scoreboard_elite");
                        chgd.HudGlobals[1].GrenadeAnchorOffset = 79.5f;
                        chgd.HudGlobals[1].EquipmentVerticalOffsetDual = 35f;
                        chgd.HudGlobals[1].WaypointMaxDistanceScale = 1f;
                        chgd.HudGlobals[2].HudAttributes[0].StateMessageScale = 0.7f;
                        chgd.HudGlobals[2].HudAttributes[0].MedalScale = 1.15f;
                        chgd.HudGlobals[2].HudAttributes[0].MedalWidth = 66f;
                        chgd.HudGlobals[2].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.61f);
                        chgd.HudGlobals[2].HudAttributes[0].MessageScale = 0.7f;
                        chgd.HudGlobals[2].HudAttributes[0].MessageHeight = 30f;
                        chgd.HudGlobals[2].HudAttributes[0].MessageOffset = new RealPoint2d(0f, 0.67f);
                        chgd.HudGlobals[2].WaypointMaxDistanceScale = 1f;
                        chgd.CampaignMetagame.MedalChudAnchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.BottomRight;
                        chgd.CampaignMetagame.MedalSpacing = 45f;
                        chgd.CampaignMetagame.MedalOffset = new RealPoint2d(-270f, -135f);
                        chgd.CampaignMetagame.ScoreboardTopY = 1f;
                        chgd.CampaignMetagame.ScoreboardSpacing = 33f;
                        CacheContext.Serialize(stream, tag, chgd);
                    }
                }
            }
        }
    }
}