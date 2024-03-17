using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
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
            chdt.HudWidgets[0].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(24.28f, 1f);
            chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.89865f, 0.999f);
            chdt.HudWidgets[13].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 49f);
            chdt.HudWidgets.Add(new ChudDefinition.HudWidget());
            chdt.HudWidgets[22] = new ChudDefinition.HudWidget()
            {
                Name = CacheContext.StringTable.GetOrAddString("consumable1"),
                ScriptingClass = ChudDefinition.ChudScriptingClass.Consumable,
                SortLayer = ChudDefinition.WidgetLayerEnum.Foreground,
                StateData = new List<ChudDefinition.HudWidgetBase.StateDatum>()
                {
                    new ChudDefinition.HudWidgetBase.StateDatum()
                    {
                        InverseFlags = ChudDefinition.HudWidgetBase.StateDatum.Inverse.NotZoomedIn | ChudDefinition.HudWidgetBase.StateDatum.Inverse.NotArmedWithSupportWeapon,
                    },
                },
                PlacementData = new List<ChudDefinition.HudWidgetBase.PlacementDatum>()
                {
                    new ChudDefinition.HudWidgetBase.PlacementDatum()
                    {
                        Anchor = ChudDefinition.HudWidgetBase.PlacementDatum.ChudAnchorType.Equipment,
                        Scale = new RealPoint2d(1f,1f),
                    },
                },
                BitmapWidgets = new List<ChudDefinition.HudWidget.BitmapWidget>()
                {
                    new ChudDefinition.HudWidget.BitmapWidget
                    {
                        Name = CacheContext.StringTable.GetOrAddString("cons_icon"),
                        SortLayer = ChudDefinition.WidgetLayerEnum.Foreground,
                        RuntimeWidgetIndex = 90,
                        Flags = ChudDefinition.HudWidget.BitmapWidget.WidgetBitmapFlagsHO.SpriteFromConsumable,
                        Bitmap = GetCachedTag<Bitmap>($@"ui\chud\bitmaps\equipment_scematics"),
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
                                Offset = new RealPoint2d(27f,100f),
                                Scale = new RealPoint2d(2f,2f),
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
                },
            };
            CacheContext.Serialize(Stream, tag, chdt);
        }
    }
}
