using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags.Definitions.Common;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class ui_chud_elite_chud_definition : TagFile
    {
        public ui_chud_elite_chud_definition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ChudDefinition>($@"ui\chud\elite");
            var chdt = CacheContext.Deserialize<ChudDefinition>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
