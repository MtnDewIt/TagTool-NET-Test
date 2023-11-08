using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        // Applies various HUD patches
        public void applyHUDPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    // Applies some minor patches to the spartan HUD, including adding adjusting some bitmap offsets and adding equipment icons
                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\spartan")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].BitmapWidgets[1].PlacementData[0].Scale = new RealPoint2d(24.28f, 1f);
                        chdt.HudWidgets[2].BitmapWidgets[0].PlacementData[0].Origin = new RealPoint2d(1.89865f, 0.999f);
                        chdt.HudWidgets[13].TextWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, 49f);
                        chdt.HudWidgets.Add(new ChudDefinition.HudWidget());
                        chdt.HudWidgets[22] = new ChudDefinition.HudWidget()
                        {
                            Name = CacheContext.StringTable.GetStringId("consumable1"),
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
                                    Name = CacheContext.StringTable.GetStringId("cons_icon"),
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    // Applies some minor patches to the elite HUD, including adding adjusting some bitmap offsets and adding equipment icons
                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\elite")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].BitmapWidgets[2].PlacementData[0].Origin = new RealPoint2d(1.010415f, 5.8f);
                        chdt.HudWidgets.Add(new ChudDefinition.HudWidget());
                        chdt.HudWidgets[19] = new ChudDefinition.HudWidget()
                        {
                            Name = CacheContext.StringTable.GetStringId("consumable1"),
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
                                    Name = CacheContext.StringTable.GetStringId("cons_icon"),
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
                                            Offset = new RealPoint2d(34f,100f),
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
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    // Fixes minor issues with the scoreboard, including adjusting some offsets, and adding the player identifier to forge
                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\scoreboard")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[0].PlacementData[0].Offset = new RealPoint2d(0f, -72f);
                        chdt.HudWidgets[5].BitmapWidgets[8].StateData[0].GameState |= ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.Editor;
                        chdt.HudWidgets[5].BitmapWidgets[8].PlacementData[0].Offset = new RealPoint2d(-221.5f, -3f);
                        CacheContext.Serialize(stream, tag, chdt);
                    }
                    
                    // Fixes forge title not appearing in summary widget
                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_editor")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[1].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.None;
                        chdt.HudWidgets[1].TextWidgets[0].StateData[0].GameTeam = ChudDefinition.HudWidgetBase.StateDatum.ChudGameTeam.Offense | ChudDefinition.HudWidgetBase.StateDatum.ChudGameTeam.Defense | ChudDefinition.HudWidgetBase.StateDatum.ChudGameTeam.NotApplicable;
                        CacheContext.Serialize(stream, tag, chdt);
                    }
                    
                    // Fixes infection title not appearing summary widget
                    if (tag.IsInGroup("chdt") && tag.Name == $@"ui\chud\multiplayer_intro\summary_infection")
                    {
                        var chdt = CacheContext.Deserialize<ChudDefinition>(stream, tag);
                        chdt.HudWidgets[1].TextWidgets[0].StateData[0].GameState = ChudDefinition.HudWidgetBase.StateDatum.ChudGameStateED.None;
                        CacheContext.Serialize(stream, tag, chdt);
                    }

                    // Fixes minor graphical issue with the battle rifle ammo bitmap
                    if (tag.IsInGroup("bitm") && tag.Name == $@"ui\chud\bitmaps\ballistic_meters")
                    {
                        var bitm = CacheContext.Deserialize<Bitmap>(stream, tag);
                        bitm.Sequences[7].Sprites[0].Top = 0.275625f;
                        CacheContext.Serialize(stream, tag, bitm);
                    }
                }
            }
        }

        // Patches the chud globals definition after it has been ported
        public void ChudGlobals() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    // Applies patches to the chud globals defintion after it has been ported
                    if (tag.IsInGroup("chgd") && tag.Name == $@"ui\chud\globals") 
                    {
                        var chgd = CacheContext.Deserialize<ChudGlobalsDefinition>(stream, tag);
                        chgd.HudGlobals[0].NavpointFriendly = new ArgbColor(0, 0, 255, 9);
                        chgd.HudGlobals[0].NavpointAllyBlue = new ArgbColor(0, 0, 96, 255);
                        chgd.HudGlobals[0].HudAttributes[0].ResolutionFlags |= ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.StandardFull;
                        chgd.HudGlobals[0].HudAttributes[0].StateLeftRightOffset_HO = new RealPoint2d(0f, 0.16f);
                        chgd.HudGlobals[0].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.64f);
                        chgd.HudGlobals[0].HudAttributes[0].Unknown32 = 1;
                        chgd.HudGlobals[0].HudAttributes[0].StateMessageScale = 1.5f;
                        chgd.HudGlobals[0].HudAttributes[0].MessageScale = 1.5f;
                        chgd.HudGlobals[0].DirectionalArrowScale = 50f;
                        chgd.HudGlobals[0].ScoreboardSpacingSize = 37;
                        chgd.HudGlobals[1].HudAttributes[0].ResolutionFlags |= ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.StandardFull;
                        chgd.HudGlobals[1].HudAttributes[0].StateLeftRightOffset_HO = new RealPoint2d(0f, 0.16f);
                        chgd.HudGlobals[1].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.64f);
                        chgd.HudGlobals[1].HudAttributes[0].Unknown32 = 1;
                        chgd.HudGlobals[1].HudAttributes[0].StateMessageScale = 1.5f;
                        chgd.HudGlobals[1].HudAttributes[0].MessageScale = 1.5f;
                        chgd.HudGlobals[1].DirectionalArrowScale = 50f;
                        chgd.HudGlobals[1].ScoreboardSpacingSize = 37f;
                        chgd.HudGlobals[1].GrenadeSchematicsOffset = new RealPoint2d(0f, 0.003f);
                        chgd.HudGlobals[2].PrimaryBackground = new ArgbColor(0, 3, 28, 56);
                        chgd.HudGlobals[2].SecondaryBackground = new ArgbColor(0, 36, 139, 255);
                        chgd.HudGlobals[2].HighlightForeground = new ArgbColor(0, 93, 169, 255);
                        chgd.HudGlobals[2].CrosshairNormal = new ArgbColor(0, 55, 149, 255);
                        chgd.HudGlobals[2].NavpointFriendly = new ArgbColor(0, 0, 255, 9);
                        chgd.HudGlobals[2].NavpointAllyBlue = new ArgbColor(0, 0, 96, 255);
                        chgd.HudGlobals[2].HudAttributes[0].ResolutionFlags |= ChudGlobalsDefinition.HudGlobal.HudAttribute.ResolutionFlagValue.StandardFull;
                        chgd.HudGlobals[2].HudAttributes[0].StateLeftRightOffset_HO = new RealPoint2d(0f, 0.16f);
                        chgd.HudGlobals[2].HudAttributes[0].SurvivalMedalsOffset = new RealPoint2d(0f, 0.64f);
                        chgd.HudGlobals[2].HudAttributes[0].Unknown32 = 1;
                        chgd.HudGlobals[2].HudAttributes[0].StateMessageScale = 1.5f;
                        chgd.HudGlobals[2].HudAttributes[0].MessageScale = 1.5f;
                        chgd.HudGlobals[2].DirectionalArrowScale = 50f;
                        chgd.HudGlobals[2].ScoreboardSpacingSize = 37f;
                        chgd.MotionSensorLevelHeightRange = 1.8f;
                        chgd.ShieldMajorThreshold = 0.5f;
                        chgd.ShieldCriticalThreshold = 0.25f;
                        chgd.HealthMultiplyColor1 = new RealRgbColor(0, 0, 0);
                        chgd.ShieldMultiplyColor0 = new RealRgbColor(1, 1, 1);
                        chgd.ShieldMultiplyColor1 = new RealRgbColor(-0.362636f, -0.840421f, -0.857739f);
                        chgd.ShieldMultiplyColor1Alpha = 0.5f;
                        chgd.ShieldAdditiveColor1 = new RealRgbColor(0.121569f, 0.00984327f, 0.0071511f);
                        chgd.ShieldAdditiveColor1Alpha = 0.5f;
                        CacheContext.Serialize(stream, tag, chgd);
                    }
                }
            }
        }
    }
}