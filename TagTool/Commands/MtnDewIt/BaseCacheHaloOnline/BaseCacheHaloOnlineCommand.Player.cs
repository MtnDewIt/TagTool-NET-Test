using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;
using static TagTool.Tags.Definitions.Model.GlobalDamageInfoBlock.DamageSection;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheHaloOnlineCommand : Command
    {
        // Applies tag patches specific to each playable biped
        public void ApplyPlayerPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                Cache.StringTable.Add("flaming_ninja_active");
                Cache.SaveStrings();

                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    // The shield impact tags need to be manually assigned, as Halo Online makes use of the halo reach shield impact system, which is not replicated when porting halo 3 and odst bipeds

                    // Assigns shield impact tags to multiplayer spartan model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\masterchief\mp_masterchief\mp_masterchief")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = GetCachedTag<ShieldImpact>($@"globals\masterchief_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = GetCachedTag<ShieldImpact>($@"globals\masterchief_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    // Assigns shield impact tags to masterchief model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\masterchief\masterchief")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = GetCachedTag<ShieldImpact>($@"globals\masterchief_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = GetCachedTag<ShieldImpact>($@"globals\masterchief_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    // Assigns shield impact tags to multiplayer elite model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\elite\mp_elite\mp_elite")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = GetCachedTag<ShieldImpact>($@"globals\elite_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = GetCachedTag<ShieldImpact>($@"globals\elite_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    // Assigns shield impact tags to campaign elite model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\elite\elite_sp")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = GetCachedTag<ShieldImpact>($@"globals\elite_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = GetCachedTag<ShieldImpact>($@"globals\elite_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    // Assigns shield impact tags to arbiter model
                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\characters\dervish\dervish")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.ShieldImpactThirdPerson = GetCachedTag<ShieldImpact>($@"globals\elite_3p_shield_impact");
                        hlmt.ShieldImpactFirstPerson = GetCachedTag<ShieldImpact>($@"globals\elite_fp_shield_impact");
                        hlmt.OvershieldFirstPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_1p");
                        hlmt.OvershieldThirdPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\overshield_3p");
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\characters\masterchief\mp_masterchief\mp_masterchief") 
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.Functions = new List<GameObject.Function> 
                        {
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"current_shield_damage"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_hit"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"shield_depleted"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_down"),
                                TurnOffWith = CacheContext.StringTable.GetStringId($@"body_vitality"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"integrated_light_power"),
                                ExportName = CacheContext.StringTable.GetStringId($@"flashlight_intensity"),
                                TurnOffWith = CacheContext.StringTable.GetStringId($@"alive"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"current_shield_damage"),
                                ExportName = CacheContext.StringTable.GetStringId($@"taking_damage"),
                                TurnOffWith = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"one"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_static"),
                                TurnOffWith = CacheContext.StringTable.GetStringId($@"shield_depleted"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x03, 0x14, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x0B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x40,
                                        0x00, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"shield_static"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_static_invert"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0xBF, 0x00, 0x00,
                                        0x80, 0x3F,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x51, 0x7C, 0x1B, 0x42, 0x83, 0x8F,
                                        0x9B, 0xC2, 0x3A, 0x8E, 0x1B, 0x42, 0x8F, 0xC2, 0xF5, 0x3C,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x97, 0x49,
                                        0x9E, 0x3D,
                                    },
                                },
                                ScaleBy = CacheContext.StringTable.GetStringId($@"shield_static_invert"),
                            },
                            new GameObject.Function
                            {
                                Flags = GameObject.Function.ObjectFunctionFlags.Invert,
                                ImportName = CacheContext.StringTable.GetStringId($@"active_camouflage"),
                                ExportName = CacheContext.StringTable.GetStringId($@"flaming_ninja_active"),
                                TurnOffWith = CacheContext.StringTable.GetStringId($@"alive"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x3F,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                        };
                        bipd.Attachments = new List<GameObject.Attachment> 
                        {
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Effect>($@"objects\characters\masterchief\fx\shield\shield_down"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"shield_down"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Light>($@"objects\characters\masterchief\flashlight_1p"),
                                Marker = CacheContext.StringTable.GetStringId($@"flashlight"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"integrated_light_power"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Light>($@"objects\characters\masterchief\flashlight_3p"),
                                Marker = CacheContext.StringTable.GetStringId($@"flashlight"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"integrated_light_power"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Effect>($@"objects\characters\masterchief\fx\flaming_ninja"),
                                Marker = CacheContext.StringTable.GetStringId($@"flaming_ninja"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"flaming_ninja_active"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Light>($@"objects\characters\masterchief\fx\shield\shield_down"),
                                Marker = CacheContext.StringTable.GetStringId($@"body"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"shield_down"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Effect>($@"objects\characters\masterchief\fx\flashlight"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"integrated_light_power"),
                            },
                        };
                        bipd.ChangeColors = new List<GameObject.ChangeColor> 
                        {
                            new GameObject.ChangeColor
                            {
                                InitialPermutations = new List<GameObject.ChangeColor.InitialPermutation>
                                {
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.501961f, 0.501961f, 0.501961f),
                                        ColorUpperBound = new RealRgbColor(0.501961f, 0.501961f, 0.501961f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"default"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.172549f, 0.231373f, 0.517647f),
                                        ColorUpperBound = new RealRgbColor(0.172549f, 0.231373f, 0.517647f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"blue"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.156863f, 0.156863f, 0.156863f),
                                        ColorUpperBound = new RealRgbColor(0.156863f, 0.156863f, 0.156863f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"grey"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.596078f, 0.133333f, 0.133333f),
                                        ColorUpperBound = new RealRgbColor(0.596078f, 0.133333f, 0.133333f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"red"),
                                    },
                                },
                            },
                            new GameObject.ChangeColor
                            {
                                InitialPermutations = new List<GameObject.ChangeColor.InitialPermutation>
                                {
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.501961f, 0.501961f, 0.501961f),
                                        ColorUpperBound = new RealRgbColor(0.501961f, 0.501961f, 0.501961f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"default"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.564706f, 0.564706f, 0.564706f),
                                        ColorUpperBound = new RealRgbColor(0.560784f, 0.560784f, 0.560784f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"blue"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.564706f, 0.564706f, 0.564706f),
                                        ColorUpperBound = new RealRgbColor(0.560784f, 0.560784f, 0.560784f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"grey"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.835294f, 0.807843f, 0.545098f),
                                        ColorUpperBound = new RealRgbColor(0.835294f, 0.807843f, 0.545098f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"red"),
                                    },
                                },
                            },
                            new GameObject.ChangeColor
                            {
                                InitialPermutations = new List<GameObject.ChangeColor.InitialPermutation>
                                {
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(1f, 0.294118f, 0f),
                                        ColorUpperBound = new RealRgbColor(0.909804f, 0.329412f, 0f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"default"),
                                    },
                                },
                            },
                            new GameObject.ChangeColor
                            {

                            },
                            new GameObject.ChangeColor
                            {

                            },
                        };
                        bipd.HologramUnit = GetCachedTag<Biped>($@"objects\equipment\hologram\bipeds\masterchief_hologram");
                        bipd.DefaultTeam = Unit.DefaultTeamValue.Human;
                        bipd.SyncActionCamera = new Unit.UnitCameraBlock
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85), Angle.FromDegrees(10)),
                            CameraTracks = new List<Unit.UnitCameraTrack>
                            {
                                new Unit.UnitCameraTrack
                                {
                                     Track = GetCachedTag<CameraTrack>($@"camera\biped_assassination_camera"),
                                },
                            },
                        };
                        bipd.Assassination = new Unit.UnitAssassination
                        {
                            Response = GetCachedTag<DamageResponseDefinition>($@"globals\damage_responses\player_assassination"),
                            Weapon = GetCachedTag<Scenery>($@"objects\props\human\unsc\spartan_knife\spartan_knife"),
                            ToolStowAnchor = CacheContext.StringTable.GetStringId($@"knife_stow_anchor"),
                            ToolHandMarker = CacheContext.StringTable.GetStringId($@"right_hand"),
                            ToolMarker = CacheContext.StringTable.GetStringId($@"ass_wpn_placement"),
                        };
                        bipd.ShieldPopDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\shield_pop_melee");
                        bipd.AssassinationDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\assassination");
                        bipd.RunningCameraHeight = 0.62f;
                        bipd.CrouchWalkingCameraHeight = 0.45f;
                        bipd.CameraHeightVelocity = 0.8500001f;
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\characters\masterchief\masterchief") 
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.PathfindingSpheres = null;
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("effe") && tag.Name == $@"objects\characters\masterchief\fx\flaming_ninja") 
                    {
                        var effe = CacheContext.Deserialize<Effect>(stream, tag);
                        effe.Events[0].ParticleSystems[0].NearCutoff = 0.34f;
                        CacheContext.Serialize(stream, tag, effe);
                    }

                    if (tag.IsInGroup("ligh") && tag.Name == $@"objects\characters\masterchief\fx\shield\shield_down") 
                    {
                        var ligh = CacheContext.Deserialize<Light>(stream, tag);
                        ligh.Flags = Light.LightFlags.RenderThirdPersonOnly;
                        ligh.MaximumDistance = 0.45f;
                        ligh.FrustumNearWidth = 0.15f;
                        ligh.FrustumHeightScale = 1f;
                        ligh.FrustumFieldOfView = 1.570796f;
                        ligh.Color = new Light.LightColorFunctionStruct 
                        {
                            Function = new TagFunction 
                            {
                                Data = new byte[] 
                                {
                                    0x03, 0x14, 0x03, 0x00, 0x00, 0x02, 0x0B, 0x00, 0x15, 0x59,
                                    0xDB, 0x00, 0x00, 0x00, 0x00, 0x00, 0x37, 0xAA, 0xFA, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                    0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x80, 0x3F,
                                },
                            },
                        };
                        ligh.Intensity = new Light.LightScalarFunctionStruct 
                        {
                            Function = new TagFunction 
                            {
                                Data = new byte[] 
                                {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00,
                                    0x00, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00,
                                },
                            },
                        };
                        ligh.DistanceDiffusion = 0.05f;
                        ligh.AngularSmoothness = 5f;
                        ligh.FarPriority = Light.LightPriorityEnumeration._4;
                        CacheContext.Serialize(stream, tag, ligh);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\characters\elite\mp_elite\mp_elite")
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.Functions = new List<GameObject.Function> 
                        {
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"current_shield_damage"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_glow_source"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"shield_depleted"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_down"),
                                TurnOffWith = CacheContext.StringTable.GetStringId($@"body_vitality"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"one"),
                                ExportName = CacheContext.StringTable.GetStringId($@"elite_burnt"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"one"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_static"),
                                TurnOffWith = CacheContext.StringTable.GetStringId($@"shield_depleted"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x03, 0x14, 0x00, 0x00, 0x00, 0x00, 0x40, 0x3F, 0x00, 0x00,
                                        0x80, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x0B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x40,
                                        0x00, 0x00, 0x00, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"shield_static"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_static_invert"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0xBF, 0x00, 0x00,
                                        0x80, 0x3F,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"shield_vitality"),
                                ExportName = CacheContext.StringTable.GetStringId($@"shield_intensity"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x59, 0x14, 0x14, 0x42, 0x8F, 0xBA,
                                        0x93, 0xC2, 0xBB, 0xAA, 0x12, 0x42, 0xA5, 0x4F, 0x7A, 0x3E,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x92, 0x4E,
                                        0xA3, 0x3D,
                                    },
                                },
                                ScaleBy = CacheContext.StringTable.GetStringId($@"shield_static_invert"),
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"alive"),
                                ExportName = CacheContext.StringTable.GetStringId($@"membrane"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x03, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F,
                                        0x00, 0x00, 0x00, 0x00, 0x9A, 0x99, 0x99, 0xBE, 0x00, 0x00,
                                        0x00, 0x41,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"zero"),
                                ExportName = CacheContext.StringTable.GetStringId($@"blade_right_on"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"zero"),
                                ExportName = CacheContext.StringTable.GetStringId($@"blade_left_on"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                ImportName = CacheContext.StringTable.GetStringId($@"integrated_light_power"),
                                ExportName = CacheContext.StringTable.GetStringId($@"flashlight_intensity"),
                                TurnOffWith = CacheContext.StringTable.GetStringId($@"alive"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                        };
                        bipd.Attachments = new List<GameObject.Attachment> 
                        {
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Effect>($@"objects\characters\elite\fx\shield\shield_down"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"shield_down"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Light>($@"objects\characters\masterchief\flashlight_1p"),
                                Marker = CacheContext.StringTable.GetStringId($@"flashlight"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"integrated_light_power"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Light>($@"objects\characters\masterchief\flashlight_3p"),
                                Marker = CacheContext.StringTable.GetStringId($@"flashlight"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"integrated_light_power"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Effect>($@"objects\characters\dervish\fx\flashlight"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"integrated_light_power"),
                            },
                            new GameObject.Attachment
                            {
                                Type = GetCachedTag<Light>($@"objects\characters\dervish\fx\shield\shield_down"),
                                Marker = CacheContext.StringTable.GetStringId($@"body"),
                                PrimaryScale = CacheContext.StringTable.GetStringId($@"shield_down"),
                            },
                        };
                        bipd.HologramUnit = GetCachedTag<Biped>($@"objects\equipment\hologram\bipeds\elite_hologram");
                        bipd.DefaultTeam = Unit.DefaultTeamValue.Covenant;
                        bipd.SyncActionCamera = new Unit.UnitCameraBlock
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85), Angle.FromDegrees(10)),
                            CameraTracks = new List<Unit.UnitCameraTrack>
                            {
                                new Unit.UnitCameraTrack
                                {
                                     Track = GetCachedTag<CameraTrack>($@"camera\biped_assassination_camera"),
                                },
                            },
                        };
                        bipd.Assassination = new Unit.UnitAssassination 
                        {
                            Response = GetCachedTag<DamageResponseDefinition>($@"globals\damage_responses\player_assassination"),
                        };
                        bipd.ShieldPopDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\shield_pop_melee");
                        bipd.AssassinationDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\assassination");
                        bipd.RunningCameraHeight = 0.62f;
                        bipd.CrouchWalkingCameraHeight = 0.45f;
                        bipd.CameraHeightVelocity = 0.8500001f;
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("mode") && tag.Name == $@"objects\characters\elite\mp_elite\mp_elite") 
                    {
                        var mode = CacheContext.Deserialize<RenderModel>(stream, tag);
                        mode.MarkerGroups = new List<RenderModel.MarkerGroup>
                        {
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"autoaim_melee"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.1799752f, 0.01038557f, 9.7043E-08f),
                                        Rotation = new RealQuaternion(-0.4999992f, -0.5000003f, -0.4999991f, -0.5000013f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"body"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.03574277f, -0.007496504f, -3.4553E-08f),
                                        Rotation = new RealQuaternion(-0.5215242f, -0.4775066f, -0.4775071f, -0.5215237f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"fp_body_cam"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 4,
                                        Translation = new RealPoint3d(0.1974106f, 0.03221082f, 0.04035645f),
                                        Rotation = new RealQuaternion(-0.5215237f, -0.4775071f, -0.4775068f, -0.521524f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"hammer_detonation"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 38,
                                        Translation = new RealPoint3d(0.04903453f, -0.01425571f, 0.31518f),
                                        Rotation = new RealQuaternion(-0.01682179f, -0.08228037f, 0.08493669f, -0.9928408f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"head"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 19,
                                        Translation = new RealPoint3d(0.02065074f, 0.04270457f, -1.9281E-07f),
                                        Rotation = new RealQuaternion(-0.6743803f, -0.2126316f, -0.2126309f, -0.6743791f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"infection_back"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.1031279f, -0.06536943f, 0.05846697f),
                                        Rotation = new RealQuaternion(-0.696095f, 0.3177367f, -0.5142785f, 0.3873147f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"infection_front"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.05538742f, 0.05927382f, 0.02797265f),
                                        Rotation = new RealQuaternion(-0.5418564f, -0.4543036f, -0.4543041f, -0.541856f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"left_foot"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 13,
                                        Translation = new RealPoint3d(0.1162547f, 0.05098096f, 0.001612802f),
                                        Rotation = new RealQuaternion(0.4999996f, 0.5000005f, -0.4999995f, -0.5000004f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"left_hand"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 21,
                                        Translation = new RealPoint3d(0.06256428f, 0.01001831f, -0.002007456f),
                                        Rotation = new RealQuaternion(-0.9960304f, -0.08898152f, -0.001657302f, 0.001715935f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"left_hand_elite"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 21,
                                        Translation = new RealPoint3d(0.06251547f, 0.01000951f, -0.002007639f),
                                        Rotation = new RealQuaternion(-0.9960304f, -0.08898152f, -0.001657302f, 0.001715935f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"melee"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 38,
                                        Translation = new RealPoint3d(-0.2086015f, 0.05588131f, 0.0008496161f),
                                        Rotation = new RealQuaternion(-0.2791958f, 0.03222927f, 0.1281927f, -0.951093f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"right_foot"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 14,
                                        Translation = new RealPoint3d(0.1162547f, 0.05098068f, -0.001177573f),
                                        Rotation = new RealQuaternion(0.4999995f, 0.5000006f, -0.4999995f, -0.5000004f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"right_hand"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 38,
                                        Translation = new RealPoint3d(0.05852192f, 0.009384068f, 0.003518221f),
                                        Rotation = new RealQuaternion(0.001851678f, -0.00150143f, -0.001833381f, -0.9999955f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"right_hand_elite"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 38,
                                        Translation = new RealPoint3d(0.05852192f, 0.009384068f, 0.003518221f),
                                        Rotation = new RealQuaternion(0.001851678f, -0.00150143f, -0.001833381f, -0.9999955f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"shield_recharge"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(-0.09023538f, 0.009551163f, -1.41033E-07f),
                                        Rotation = new RealQuaternion(-0.7071056f, 8.308E-07f, 1.596E-07f, -0.707108f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"target_head"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 19,
                                        Translation = new RealPoint3d(0.01701837f, 0.01884919f, -4.07824E-07f),
                                        Rotation = new RealQuaternion(-0.6743802f, -0.2126316f, -0.2126309f, -0.6743791f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"target_leg_l"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 5,
                                        Translation = new RealPoint3d(0.1262321f, 0.02450612f, 0.005931422f),
                                        Rotation = new RealQuaternion(0.4199602f, 0.5823395f, -0.4588009f, -0.5234652f),
                                    },
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 1,
                                        Translation = new RealPoint3d(0.02853655f, -0.005506793f, 0.006877085f),
                                        Rotation = new RealQuaternion(0.5428495f, 0.4698938f, -0.3258288f, -0.6151016f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"target_leg_r"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 6,
                                        Translation = new RealPoint3d(0.1263171f, 0.02668504f, 0.00344985f),
                                        Rotation = new RealQuaternion(0.5234631f, 0.458801f, -0.5823394f, -0.419963f),
                                    },
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 3,
                                        Translation = new RealPoint3d(0.03023802f, -0.002421259f, 0.008280637f),
                                        Rotation = new RealQuaternion(0.6150993f, 0.3258293f, -0.4698931f, -0.5428523f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"target_main"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.1283156f, -0.007224265f, -4.5666E-08f),
                                        Rotation = new RealQuaternion(-0.5215242f, -0.4775065f, -0.4775071f, -0.5215238f),
                                    },
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.004739819f, 0.008236676f, -5.2052E-08f),
                                        Rotation = new RealQuaternion(-0.4999993f, -0.5000002f, -0.4999992f, -0.5000014f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_arm01"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 15,
                                        Translation = new RealPoint3d(0.02690487f, -0.02371224f, -0.01066976f),
                                        Rotation = new RealQuaternion(-0.6377019f, 0.0462249f, -0.08799204f, -0.7638436f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_arm02"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 15,
                                        Translation = new RealPoint3d(0.06833898f, 0.04643075f, -0.0007777766f),
                                        Rotation = new RealQuaternion(0.703701f, -0.2662126f, -0.2044371f, -0.6262119f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_arm03"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 15,
                                        Translation = new RealPoint3d(0.1107497f, -0.01633057f, 0.02171804f),
                                        Rotation = new RealQuaternion(-0.3548906f, -0.06070545f, 0.2570218f, -0.8968319f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_thigh01"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 1,
                                        Translation = new RealPoint3d(0.01962783f, 0.01549957f, -0.0320834f),
                                        Rotation = new RealQuaternion(-0.940122f, 0.1744003f, 0.1106316f, 0.2711384f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_l_thigh02"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 4,
                                        Translation = new RealPoint3d(-0.05706913f, -0.04478194f, 0.0491551f),
                                        Rotation = new RealQuaternion(0.02752986f, -0.2919843f, -0.9560007f, -0.007069346f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_neck01"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 11,
                                        Translation = new RealPoint3d(0.0304031f, -0.01852239f, -0.0263923f),
                                        Rotation = new RealQuaternion(-0.7801918f, 0.5694979f, -0.2012519f, -0.1626976f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_neck02"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 11,
                                        Translation = new RealPoint3d(0.01437855f, -0.03735514f, 0.01858724f),
                                        Rotation = new RealQuaternion(-0.5786288f, 0.1161039f, -0.4026208f, -0.6997179f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm01"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 17,
                                        Translation = new RealPoint3d(-0.01156176f, -0.02033655f, 0.004039865f),
                                        Rotation = new RealQuaternion(-0.7067726f, 0.2379951f, -0.6652032f, 0.03654424f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm02"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 17,
                                        Translation = new RealPoint3d(-0.01481211f, 0.02051404f, 0.005928042f),
                                        Rotation = new RealQuaternion(0.6084152f, 0.4271791f, -0.02982261f, -0.6681763f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm03"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.04056877f, -0.03876587f, -0.1121205f),
                                        Rotation = new RealQuaternion(-0.01175296f, 0.6494383f, -0.7576989f, 0.06312039f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm04"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 17,
                                        Translation = new RealPoint3d(0.0765755f, -0.02796047f, -0.01276978f),
                                        Rotation = new RealQuaternion(-0.9326941f, 0.01988128f, -0.2514276f, 0.2578191f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm05"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 17,
                                        Translation = new RealPoint3d(0.0793365f, 0.04458105f, -0.01441297f),
                                        Rotation = new RealQuaternion(-0.04670968f, 0.08736467f, -0.005214368f, -0.9950671f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_arm06"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 17,
                                        Translation = new RealPoint3d(0.1210528f, 0.008050691f, -0.02251989f),
                                        Rotation = new RealQuaternion(0.3826088f, -0.00126087f, -0.1092994f, -0.9174218f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_thigh01"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 1,
                                        Translation = new RealPoint3d(-0.0163238f, 0.001268711f, 0.1159575f),
                                        Rotation = new RealQuaternion(-0.06471356f, 0.6105553f, 0.250048f, -0.7486724f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_thigh02"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 4,
                                        Translation = new RealPoint3d(-0.05697641f, -0.04479004f, -0.05662575f),
                                        Rotation = new RealQuaternion(-0.3871388f, 0.3298104f, -0.8428503f, 0.1759316f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_r_thigh03"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 4,
                                        Translation = new RealPoint3d(-0.05465327f, -0.01847751f, -0.07354491f),
                                        Rotation = new RealQuaternion(0.4553881f, -0.8691748f, 0.1794832f, -0.07030415f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back01"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.1357917f, -0.05742816f, -0.05739209f),
                                        Rotation = new RealQuaternion(0.08567107f, -0.8234234f, 0.441122f, -0.3464765f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back02"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.1187678f, -0.0749002f, 0.05937659f),
                                        Rotation = new RealQuaternion(-0.2935609f, 0.5472244f, -0.7804837f, -0.07220077f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back03"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.04307916f, -0.09597619f, 0.04374966f),
                                        Rotation = new RealQuaternion(-0.5293249f, 0.4768791f, -0.4258696f, -0.5577065f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back04"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 4,
                                        Translation = new RealPoint3d(0.07787018f, -0.1042351f, 0.004674229f),
                                        Rotation = new RealQuaternion(0.1064251f, -0.6730598f, 0.6576449f, 0.321197f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back05"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.0728678f, -0.1158325f, -0.005598636f),
                                        Rotation = new RealQuaternion(-0.04149873f, -0.7289374f, 0.654032f, -0.1979147f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back06"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(-0.02042438f, -0.08158603f, -0.001679986f),
                                        Rotation = new RealQuaternion(-0.155919f, -0.7523875f, 0.6365291f, -0.06658117f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back07"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 4,
                                        Translation = new RealPoint3d(0.01417869f, -0.06811558f, 0.02913354f),
                                        Rotation = new RealQuaternion(-0.1547724f, -0.2853118f, -0.9437906f, -0.0624662f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back08"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.01990321f, -0.07601078f, 0.06768318f),
                                        Rotation = new RealQuaternion(0.1648929f, 0.6120907f, -0.6866899f, -0.3558263f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_back09"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 4,
                                        Translation = new RealPoint3d(0.02663497f, -0.07514262f, -0.02470897f),
                                        Rotation = new RealQuaternion(-0.5251009f, -0.7160732f, 0.4573574f, -0.04829649f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_front01"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.05011288f, 0.08248291f, -0.001432333f),
                                        Rotation = new RealQuaternion(0.7435758f, 0.05047482f, 0.1591866f, -0.647462f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_front02"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.0275171f, 0.07999691f, -0.004159951f),
                                        Rotation = new RealQuaternion(-0.2608015f, -0.6730676f, -0.5929909f, 0.3568256f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_front03"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(-0.02561804f, 0.06192196f, -0.01568683f),
                                        Rotation = new RealQuaternion(0.2130293f, -0.7644876f, -0.5944196f, -0.1297793f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"trans_muffin_torso_front04"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(-0.0236889f, 0.06175156f, 0.02502768f),
                                        Rotation = new RealQuaternion(-0.01012471f, -0.7217582f, -0.6801273f, 0.128022f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"weapon_back"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.08590946f, -0.1335677f, -1.41056E-07f),
                                        Rotation = new RealQuaternion(-0.03112468f, -0.7064212f, -0.7064217f, -0.03112472f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"weapon_equip"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        Translation = new RealPoint3d(0.04339714f, -0.04264744f, -0.060889f),
                                        Rotation = new RealQuaternion(-0.6718104f, 0.2042295f, 0.6270984f, -0.3372071f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"weapon_grenade_frag"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.06213973f, 0.05512109f, 0.05804935f),
                                        Rotation = new RealQuaternion(-0.3297831f, -0.3652966f, -0.8174217f, -0.2993715f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"weapon_grenade_plasma"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.04718842f, 0.06805268f, 0.03158877f),
                                        Rotation = new RealQuaternion(-0.2177138f, -0.6190065f, -0.7322162f, -0.1824587f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"weapon_thigh"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 3,
                                        Translation = new RealPoint3d(0.1116038f, 0.02611289f, 0.05950713f),
                                        Rotation = new RealQuaternion(-0.9942661f, -0.01218014f, 0.01586942f, -0.1050465f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"flashlight"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 19,
                                        Translation = new RealPoint3d(-0.05970598f, -0.01428081f, 0.08475997f),
                                        Rotation = new RealQuaternion(-0.6743807f, -0.2126319f, -0.2126303f, -0.6743788f),
                                    },
                                },
                            },
                            new RenderModel.MarkerGroup
                            {
                                Name = CacheContext.StringTable.GetStringId($@"fx_light_flare"),
                                Markers = new List<RenderModel.MarkerGroup.Marker>
                                {
                                    new RenderModel.MarkerGroup.Marker
                                    {
                                        RegionIndex = -1,
                                        PermutationIndex = -1,
                                        NodeIndex = 7,
                                        Translation = new RealPoint3d(0.1422199f, 0.01072503f, 0.08512984f),
                                        Rotation = new RealQuaternion(-0.5215244f, -0.477507f, -0.4775064f, -0.5215238f),
                                    },
                                },
                            },
                        };
                        CacheContext.Serialize(stream, tag, mode);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\characters\dervish\dervish") 
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.SyncActionCamera = new Unit.UnitCameraBlock 
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85), Angle.FromDegrees(10)),
                            CameraTracks = new List<Unit.UnitCameraTrack> 
                            {
                                new Unit.UnitCameraTrack 
                                {
                                     Track = GetCachedTag<CameraTrack>($@"camera\biped_assassination_camera"),
                                },
                            },
                        };
                        bipd.Assassination = new Unit.UnitAssassination 
                        {
                            Response = GetCachedTag<DamageResponseDefinition>($@"globals\damage_responses\player_assassination"),
                            ToolStowAnchor = CacheContext.StringTable.GetStringId($@"weapon_thigh"),
                            ToolHandMarker = CacheContext.StringTable.GetStringId($@"right_hand_elite"),
                            ToolMarker = CacheContext.StringTable.GetStringId($@"weapon_thigh"),
                        };
                        bipd.ShieldPopDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\shield_pop_melee");
                        bipd.AssassinationDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\assassination");
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("ligh") && tag.Name == $@"objects\characters\dervish\fx\shield\shield_down") 
                    {
                        var ligh = CacheContext.Deserialize<Light>(stream, tag);
                        ligh.Flags = Light.LightFlags.RenderThirdPersonOnly;
                        ligh.MaximumDistance = 0.50f;
                        ligh.FrustumNearWidth = 0.15f;
                        ligh.FrustumHeightScale = 1f;
                        ligh.FrustumFieldOfView = 1.570796f;
                        ligh.Color = new Light.LightColorFunctionStruct
                        {
                            Function = new TagFunction
                            {
                                Data = new byte[]
                                {
                                    0x03, 0x14, 0x03, 0x00, 0x00, 0x02, 0x0B, 0x00, 0xBB, 0x80,
                                    0x6C, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFA, 0xAB, 0x8B, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                    0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x80, 0x3F,
                                },
                            },
                        };
                        ligh.Intensity = new Light.LightScalarFunctionStruct
                        {
                            Function = new TagFunction
                            {
                                Data = new byte[]
                                {
                                    0x01, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x00, 0x00,
                                    0x00, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                    0x00, 0x00,
                                },
                            },
                        };
                        ligh.DistanceDiffusion = 0.05f;
                        ligh.AngularSmoothness = 5f;
                        ligh.FarPriority = Light.LightPriorityEnumeration._4;
                        CacheContext.Serialize(stream, tag, ligh);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\characters\monitor\monitor_editor") 
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.Functions = new List<GameObject.Function> 
                        {
                            new GameObject.Function
                            {
                                Flags = GameObject.Function.ObjectFunctionFlags.None,
                                ImportName = CacheContext.StringTable.GetStringId($@"mouth_aperture"),
                                ExportName = CacheContext.StringTable.GetStringId($@"talking"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                Flags = GameObject.Function.ObjectFunctionFlags.AlwaysActive,
                                ImportName = CacheContext.StringTable.GetStringId($@"flying_speed"),
                                ExportName = CacheContext.StringTable.GetStringId($@"audio_move"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                            new GameObject.Function
                            {
                                Flags = GameObject.Function.ObjectFunctionFlags.AlwaysActive,
                                ImportName = CacheContext.StringTable.GetStringId($@"flying_speed"),
                                ExportName = CacheContext.StringTable.GetStringId($@"audio_amb"),
                                DefaultFunction = new TagFunction
                                {
                                    Data = new byte[]
                                    {
                                        0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                        0x48, 0xE1, 0xFA, 0x3E, 0x00, 0x00, 0x00, 0x3F, 0x14, 0x00,
                                        0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                        0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                        0x00, 0x00,
                                    },
                                },
                            },
                        };
                        bipd.CrouchingCameraFunction = new TagFunction
                        {
                            Data = new byte[] 
                            {
                                0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                0x00, 0x00,
                            }
                        };
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\equipment\hologram\bipeds\masterchief_hologram")
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.ObjectFlags = ObjectDefinitionFlags.DoesNotCastShadow;
                        bipd.Model = GetCachedTag<Model>($@"objects\equipment\hologram\bipeds\masterchief_hologram");
                        bipd.ChangeColors = new List<GameObject.ChangeColor>
                        {
                            new GameObject.ChangeColor
                            {
                                InitialPermutations = new List<GameObject.ChangeColor.InitialPermutation>
                                {
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.501961f, 0.501961f, 0.501961f),
                                        ColorUpperBound = new RealRgbColor(0.501961f, 0.501961f, 0.501961f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"default"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.172549f, 0.231373f, 0.517647f),
                                        ColorUpperBound = new RealRgbColor(0.172549f, 0.231373f, 0.517647f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"blue"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.156863f, 0.156863f, 0.156863f),
                                        ColorUpperBound = new RealRgbColor(0.156863f, 0.156863f, 0.156863f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"grey"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.596078f, 0.133333f, 0.133333f),
                                        ColorUpperBound = new RealRgbColor(0.596078f, 0.133333f, 0.133333f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"red"),
                                    },
                                },
                            },
                            new GameObject.ChangeColor
                            {
                                InitialPermutations = new List<GameObject.ChangeColor.InitialPermutation>
                                {
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.501961f, 0.501961f, 0.501961f),
                                        ColorUpperBound = new RealRgbColor(0.501961f, 0.501961f, 0.501961f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"default"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.564706f, 0.564706f, 0.564706f),
                                        ColorUpperBound = new RealRgbColor(0.560784f, 0.560784f, 0.560784f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"blue"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.564706f, 0.564706f, 0.564706f),
                                        ColorUpperBound = new RealRgbColor(0.560784f, 0.560784f, 0.560784f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"grey"),
                                    },
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(0.835294f, 0.807843f, 0.545098f),
                                        ColorUpperBound = new RealRgbColor(0.835294f, 0.807843f, 0.545098f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"red"),
                                    },
                                },
                            },
                            new GameObject.ChangeColor
                            {
                                InitialPermutations = new List<GameObject.ChangeColor.InitialPermutation>
                                {
                                    new GameObject.ChangeColor.InitialPermutation
                                    {
                                        Weight = 1,
                                        ColorLowerBound = new RealRgbColor(1f, 0.294118f, 0f),
                                        ColorUpperBound = new RealRgbColor(0.909804f, 0.329412f, 0f),
                                        VariantName = CacheContext.StringTable.GetStringId($@"default"),
                                    },
                                },
                            },
                            new GameObject.ChangeColor
                            {

                            },
                            new GameObject.ChangeColor
                            {

                            },
                        };
                        bipd.CollisionDamage = null;
                        bipd.MaterialEffects = null;
                        bipd.ArmorSounds = null;
                        bipd.MeleeImpactSound = null;
                        bipd.AiProperties = null;
                        bipd.Functions = null;
                        bipd.Attachments = null;
                        bipd.UnitFlags = Unit.UnitFlagBits.ShieldSapping;
                        bipd.DefaultTeam = Unit.DefaultTeamValue.Player;
                        bipd.UnitCamera = new Unit.UnitCameraBlock 
                        {
                            CameraTracks = null,
                            CameraAcceleration = null,
                        };
                        bipd.SyncActionCamera = new Unit.UnitCameraBlock 
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromRadians(0), Angle.FromRadians(0)),
                            CameraTracks = null,
                        };
                        bipd.Assassination = new Unit.UnitAssassination 
                        {
                            Response = null,
                            Weapon = null,
                            ToolStowAnchor = StringId.Invalid,
                            ToolHandMarker = StringId.Invalid,
                            ToolMarker = StringId.Invalid,
                        };
                        bipd.BoardingMeleeDamage = null;
                        bipd.BoardingMeleeResponse = null;
                        bipd.EvictionMeleeDamage = null;
                        bipd.EvictionMeleeResponse = null;
                        bipd.ShieldPopDamage = null;
                        bipd.AssassinationDamage = null;
                        bipd.HudInterfaces = null;
                        bipd.RunningCameraHeight = 0.62f;
                        bipd.CrouchWalkingCameraHeight = 0.45f;
                        bipd.CrouchingCameraFunction = new TagFunction
                        {
                            Data = new byte[52]
                            {
                                0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00,
                                0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0xCD,
                                0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00,
                                0x00, 0x00,
                            }
                        };
                        bipd.CameraHeights = null;
                        bipd.CameraHeightVelocity = 0.8500001f;
                        bipd.AreaDamageEffect = null;
                        bipd.PhysicsFlags.Halo3ODST = Havok.BipedPhysicsFlags.Halo3OdstBits.None;
                        bipd.LivingMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        bipd.DeadMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        bipd.LivingGlobalMaterialIndex = 157;
                        bipd.DeadGlobalMaterialIndex = 157;
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\equipment\hologram\bipeds\masterchief_hologram")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.PhysicsModel = null;
                        hlmt.DisappearDistance = 150;
                        hlmt.BeginFadeDistance = 130;
                        hlmt.Materials = new List<Model.Material>
                        {
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"head"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"body"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeCollisionMaterialIndex = 1,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                        };
                        hlmt.NewDamageInfo = new List<Model.GlobalDamageInfoBlock> 
                        {
                            new Model.GlobalDamageInfoBlock
                            {
                                Flags = Model.GlobalDamageInfoBlock.FlagsValue.TakesShieldDamageForChildren | Model.GlobalDamageInfoBlock.FlagsValue.TakesBodyDamageForChildren,
                                GlobalIndirectMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                IndirectDamageSection = 0,
                                CollisionDamageReportingType = new Damage.DamageReportingType
                                {
                                    HaloOnline = Damage.DamageReportingType.HaloOnlineValue.Guardians,
                                },
                                ResponseDamageReportingType = new Damage.DamageReportingType
                                {
                                    HaloOnline = Damage.DamageReportingType.HaloOnlineValue.Guardians,
                                },
                                UnknownHO = 0,
                                MaximumVitality = 45,
                                MinStunDamage = 0,
                                StunTime = 10,
                                RechargeTime = 5,
                                RechargeFraction = 1,
                                MaxShieldVitality = 70,
                                GlobalShieldMaterialName = CacheContext.StringTable.GetStringId($@"energy_shield_thin"),
                                ShieldMinStunDamage = 0,
                                ShieldStunTime = 5,
                                ShieldRechargeTime = 2,
                                ShieldDamagedThreshold = 0,
                                ShieldDamagedEffect = null,
                                ShieldDepletedEffect = null,
                                ShieldRechargingEffect = null,
                                DamageSections = new List<Model.GlobalDamageInfoBlock.DamageSection>
                                {
                                    new Model.GlobalDamageInfoBlock.DamageSection
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"main"),
                                        Flags = FlagsValue.TakesFullDamageWhenShieldDepleted,
                                        VitalityPercentage = 1,
                                        InstantResponses = new List<InstantResponse>
                                        {
                                            new InstantResponse
                                            {
                                                 Flags = InstantResponse.FlagsValue.KillsObject | InstantResponse.FlagsValue.DestroysObject,
                                                 RuntimeRegionIndex = -1,
                                                 SecondaryRuntimeRegionIndex = -1,
                                                 DestroyInstanceGroup = -1,
                                                 ResponseDelay = 0.3f,
                                                 DelayEffect = GetCachedTag<Effect>($@"objects\equipment\hologram_equipment\fx\hologram_pop"),
                                            },
                                        },
                                        StunTime = 1,
                                        RechargeTime = 1,
                                        RuntimeRechargeVelocity = 1,
                                        ResurrectionRegionRuntimeIndex = -1,
                                    },
                                },
                                Nodes = new List<Model.GlobalDamageInfoBlock.Node>
                                {
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 0,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 6,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 10,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 0,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 6,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 10,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 1,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 6,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 10,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 3,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 7,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 6,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 10,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 3,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 7,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                },
                                GlobalShieldMaterialIndex = 145,
                                GlobalIndirectMaterialIndex = 157,
                                RuntimeShieldRechargeVelocity = 0.5f,
                                RuntimeHealthRechargeVelocity = 0.2f,
                            },
                        };
                        hlmt.Targets = null;
                        hlmt.CollisionRegions = new List<Model.CollisionRegion>
                        {
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"arms"),
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"body"),
                                CollisionRegionIndex = 1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"chest"),
                                CollisionRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_cobra"),
                                        CollisionPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_intruder"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_ninja"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_regulator"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_ryu"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_scout"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_katana"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_bungie"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"decals"),
                                CollisionRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"helmet"),
                                CollisionRegionIndex = 2,
                                PhysicsRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"realtime"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_cobra"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_intruder"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_ninja"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_regulator"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"ui"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_ryu"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_marathon"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_markv"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_rogue"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_scout"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_odst"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_cobra"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_intruder"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_ninja"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_regulator"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_ryu"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_marathon"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_scout"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"legs"),
                                CollisionRegionIndex = 3,
                                PhysicsRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_cobra"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_intruder"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_ninja"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_regulator"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_ryu"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_marathon"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_scout"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                        };
                        hlmt.PrimaryDialogue = null;
                        hlmt.SecondaryDialogue = null;
                        hlmt.ShieldImpactThirdPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\hologram_damage");
                        hlmt.ShieldImpactFirstPerson = null;
                        hlmt.OvershieldThirdPerson = null;
                        hlmt.OvershieldFirstPerson = null;
                        CacheContext.Serialize(stream, tag, hlmt);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\equipment\hologram\bipeds\elite_hologram")
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.ObjectFlags = ObjectDefinitionFlags.DoesNotCastShadow;
                        bipd.Model = GetCachedTag<Model>($@"objects\equipment\hologram\bipeds\elite_hologram");
                        bipd.CollisionDamage = null;
                        bipd.MaterialEffects = null;
                        bipd.ArmorSounds = null;
                        bipd.MeleeImpactSound = null;
                        bipd.AiProperties = null;
                        bipd.Functions = null;
                        bipd.Attachments = null;
                        bipd.UnitFlags = Unit.UnitFlagBits.ShieldSapping;
                        bipd.DefaultTeam = Unit.DefaultTeamValue.Player;
                        bipd.EvictionMeleeResponse = GetCachedTag<DamageEffect>($@"objects\characters\masterchief\damage_effects\masterchief_ejection_melee_response");
                        bipd.UnitCamera = new Unit.UnitCameraBlock 
                        {
                            CameraTracks = null,
                            CameraAcceleration = null,
                        };
                        bipd.SyncActionCamera = new Unit.UnitCameraBlock 
                        {
                            PitchRange = new Bounds<Angle>(Angle.FromRadians(0), Angle.FromRadians(0)),
                            CameraTracks = null,
                        };
                        bipd.Assassination = new Unit.UnitAssassination 
                        {
                            Response = null,
                            Weapon = null,
                            ToolStowAnchor = StringId.Invalid,
                            ToolHandMarker = StringId.Invalid,
                            ToolMarker = StringId.Invalid,
                        };
                        bipd.BoardingMeleeDamage = null;
                        bipd.BoardingMeleeResponse = null;
                        bipd.EvictionMeleeDamage = null;
                        bipd.EvictionMeleeResponse = null;
                        bipd.ShieldPopDamage = null;
                        bipd.AssassinationDamage = null;
                        bipd.HudInterfaces = null;
                        bipd.CrouchingCameraFunction = new TagFunction
                        {
                            Data = new byte[]
                            {
                                0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                0xE0, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00, 
                                0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD, 
                                0xFF, 0xFF, 0x7F, 0x7F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                0x80, 0xC0, 0x00, 0x00, 0x80, 0x40, 0x00, 0x00, 0x00, 0x00,
                            }
                        };
                        bipd.CameraHeights = null;
                        bipd.AreaDamageEffect = null;
                        bipd.PhysicsFlags.Halo3ODST = Havok.BipedPhysicsFlags.Halo3OdstBits.UsePlayerPhysics;
                        bipd.LivingMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        bipd.DeadMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        bipd.LivingGlobalMaterialIndex = 157;
                        bipd.DeadGlobalMaterialIndex = 157;
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("hlmt") && tag.Name == $@"objects\equipment\hologram\bipeds\elite_hologram")
                    {
                        var hlmt = CacheContext.Deserialize<Model>(stream, tag);
                        hlmt.PhysicsModel = null;
                        hlmt.DisappearDistance = 150;
                        hlmt.BeginFadeDistance = 130;
                        hlmt.Materials = new List<Model.Material>
                        {
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"armored_head"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"nonheadshotable_head"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeCollisionMaterialIndex = 1,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"skinned_head"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeCollisionMaterialIndex = 2,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"skinned_arm"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeCollisionMaterialIndex = 3,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"armored_arms"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeCollisionMaterialIndex = 4,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"skinned_torso"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeCollisionMaterialIndex = 5,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"armored_legs"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeCollisionMaterialIndex = 6,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                            new Model.Material
                            {
                                MaterialName = CacheContext.StringTable.GetStringId($@"skinned_legs"),
                                MaterialType = Model.Material.MaterialTypeValue.Dirt,
                                RuntimeCollisionMaterialIndex = 7,
                                RuntimeDamagerMaterialIndex = -1,
                                GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                GlobalMaterialIndex = 157,
                            },
                        };
                        hlmt.NewDamageInfo = new List<Model.GlobalDamageInfoBlock>
                        {
                            new Model.GlobalDamageInfoBlock
                            {
                                Flags = Model.GlobalDamageInfoBlock.FlagsValue.TakesShieldDamageForChildren | Model.GlobalDamageInfoBlock.FlagsValue.TakesBodyDamageForChildren,
                                GlobalIndirectMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo"),
                                IndirectDamageSection = 0,
                                CollisionDamageReportingType = new Damage.DamageReportingType
                                {
                                    HaloOnline = Damage.DamageReportingType.HaloOnlineValue.Guardians,
                                },
                                ResponseDamageReportingType = new Damage.DamageReportingType
                                {
                                    HaloOnline = Damage.DamageReportingType.HaloOnlineValue.Guardians,
                                },
                                UnknownHO = 0,
                                MaximumVitality = 45,
                                MinStunDamage = 0,
                                StunTime = 10,
                                RechargeTime = 5,
                                RechargeFraction = 1,
                                MaxShieldVitality = 70,
                                GlobalShieldMaterialName = CacheContext.StringTable.GetStringId($@"energy_shield_thin"),
                                ShieldMinStunDamage = 0,
                                ShieldStunTime = 5,
                                ShieldRechargeTime = 2,
                                ShieldDamagedThreshold = 0,
                                ShieldDamagedEffect = null,
                                ShieldDepletedEffect = null,
                                ShieldRechargingEffect = null,
                                DamageSections = new List<Model.GlobalDamageInfoBlock.DamageSection>
                                {
                                    new Model.GlobalDamageInfoBlock.DamageSection
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"main"),
                                        Flags = FlagsValue.TakesFullDamageWhenShieldDepleted,
                                        VitalityPercentage = 1,
                                        InstantResponses = new List<InstantResponse>
                                        {
                                            new InstantResponse
                                            {
                                                 Flags = InstantResponse.FlagsValue.KillsObject | InstantResponse.FlagsValue.DestroysObject,
                                                 RuntimeRegionIndex = -1,
                                                 SecondaryRuntimeRegionIndex = -1,
                                                 DestroyInstanceGroup = -1,
                                                 ResponseDelay = 0.3f,
                                                 DelayEffect = GetCachedTag<Effect>($@"objects\equipment\hologram_equipment\fx\hologram_pop"),
                                            },
                                        },
                                        StunTime = 1,
                                        RechargeTime = 1,
                                        RuntimeRechargeVelocity = 1,
                                        ResurrectionRegionRuntimeIndex = -1,
                                    },
                                },
                                Nodes = new List<Model.GlobalDamageInfoBlock.Node>
                                {
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 0,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 6,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 0,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 10,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 0,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 6,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 10,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 1,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 6,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 10,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 3,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 7,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 6,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 10,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 3,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 7,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 2,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 4,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                    new Model.GlobalDamageInfoBlock.Node
                                    {
                                        RuntimeDamagePart = 8,
                                    },
                                },
                                GlobalShieldMaterialIndex = 145,
                                GlobalIndirectMaterialIndex = 157,
                                RuntimeShieldRechargeVelocity = 0.5f,
                                RuntimeHealthRechargeVelocity = 0.2f,
                            },
                        };
                        hlmt.Targets = null;
                        hlmt.CollisionRegions = new List<Model.CollisionRegion>
                        {
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"body"),
                                CollisionRegionIndex = 0,
                                PhysicsRegionIndex = 0,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = 0,
                                        PhysicsPermutationIndex = 0,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"chest"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = 0,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_raptor"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_predator"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_blades"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_scythe"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"d_torso"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = 0,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = 0,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"decals"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = 0,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = 0,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"eyelids"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"head"),
                                CollisionRegionIndex = 1,
                                PhysicsRegionIndex = 1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_raptor"),
                                        CollisionPermutationIndex = 1,
                                        PhysicsPermutationIndex = 0,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_blades"),
                                        CollisionPermutationIndex = 2,
                                        PhysicsPermutationIndex = 0,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = 0,
                                        PhysicsPermutationIndex = 0,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_scythe"),
                                        CollisionPermutationIndex = 4,
                                        PhysicsPermutationIndex = 0,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_predator"),
                                        CollisionPermutationIndex = 3,
                                        PhysicsPermutationIndex = 0,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"leftshoulder"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_raptor"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_predator"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_blades"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_scythe"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"lights"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                            new Model.CollisionRegion
                            {
                                Pad1 = new byte[2],
                                Name = CacheContext.StringTable.GetStringId($@"rightshoulder"),
                                CollisionRegionIndex = -1,
                                PhysicsRegionIndex = -1,
                                Permutations = new List<Model.CollisionRegion.Permutation>
                                {
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_raptor"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"base"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_predator"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_blades"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                    new Model.CollisionRegion.Permutation
                                    {
                                        Name = CacheContext.StringTable.GetStringId($@"mp_scythe"),
                                        CollisionPermutationIndex = -1,
                                        PhysicsPermutationIndex = -1,
                                        Pad = new byte[1],
                                    },
                                },
                            },
                        };
                        hlmt.PrimaryDialogue = null;
                        hlmt.SecondaryDialogue = null;
                        hlmt.ShieldImpactThirdPerson = GetCachedTag<ShieldImpact>($@"fx\shield_impacts\hologram_damage");
                        hlmt.ShieldImpactFirstPerson = null;
                        hlmt.OvershieldThirdPerson = null;
                        hlmt.OvershieldFirstPerson = null;
                        CacheContext.Serialize(stream, tag, hlmt);
                    }   
                }
            }
        }

        public void GenerateSpartanActionTag()
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                CacheContext.StringTable.AddString($@"thunder_clap");
                CacheContext.StringTable.AddString($@"twerk");
                CacheContext.StringTable.AddString($@"dance1test");
                CacheContext.StringTable.AddString($@"dance1");
                CacheContext.StringTable.AddString($@"mixamo");
                CacheContext.StringTable.AddString($@"fingerlay");
                CacheContext.StringTable.AddString($@"fingerstand");
                CacheContext.StringTable.AddString($@"breakdance");
                CacheContext.StringTable.AddString($@"hiphop");
                CacheContext.StringTable.AddString($@"ballskick");

                var trakTag = CacheContext.TagCache.AllocateTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera");
                var trak = new CameraTrack
                {
                    ControlPoints = new List<CameraTrack.CameraPoint>
                    {
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(3.934E-08f, 0f, 0.9f),
                            Orientation = new RealQuaternion(0f, -0.7071069f, 0f, -0.7071068f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.1732779f, 0f, 0.9380214f),
                            Orientation = new RealQuaternion(0f, -0.6234899f, 0f, -0.7818315f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.3668045f, 0f, 0.9310074f),
                            Orientation = new RealQuaternion(0f, -0.5320321f, 0f, -0.8467242f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.5661401f, 0f, 0.8719415f),
                            Orientation = new RealQuaternion(0f, -0.4338837f, 0f, -0.9009689f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.7549486f, 0f, 0.7586696f),
                            Orientation = new RealQuaternion(0f, -0.3302791f, 0f, -0.9438834f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.9165863f, 0f, 0.5943015f),
                            Orientation = new RealQuaternion(0f, -0.222521f, 0f, -0.9749279f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-1.035744f, 0f, 0.3871195f),
                            Orientation = new RealQuaternion(0f, -0.1119645f, 0f, -0.9937123f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-1.1f, 0f, 0.1500001f),
                            Orientation = new RealQuaternion(0f, -5.96E-08f, 0f, -1f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-1.083231f, 0f, -0.09652288f),
                            Orientation = new RealQuaternion(0f, 0.1119645f, 0f, -0.9937123f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.9699321f, 0f, -0.3141978f),
                            Orientation = new RealQuaternion(0f, 0.2225208f, 0f, -0.974928f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.7783985f, 0f, -0.4641338f),
                            Orientation = new RealQuaternion(0f, 0.330279f, 0f, -0.9438834f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.5408726f, 0f, -0.5162081f),
                            Orientation = new RealQuaternion(0f, 0.4338836f, 0f, -0.900969f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.2999597f, 0f, -0.4535427f),
                            Orientation = new RealQuaternion(0f, 0.532032f, 0f, -0.8467243f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.103738f, 0f, -0.2756643f),
                            Orientation = new RealQuaternion(0f, 0.6234898f, 0f, -0.7818316f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(0f, 0f, 1.9073E-08f),
                            Orientation = new RealQuaternion(0f, 0.7071067f, 0f, -0.7071069f),
                        },
                    },
                };
                CacheContext.Serialize(stream, trakTag, trak);

                var pactTag = CacheContext.TagCache.AllocateTag<PlayerActionSet>($@"objects\characters\masterchief\mp_masterchief\actions");
                var pact = new PlayerActionSet
                {
                    Widget = new PlayerActionSet.WidgetData
                    {
                        Title = "Spartan Actions",
                    },
                    Actions = new List<PlayerActionSet.Action>
                    {
                        new PlayerActionSet.Action
                        {
                            Title = "Dance",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"thunder_clap"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "twerk",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"twerk"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "dance1test",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"dance1test"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "dance1",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"dance1"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "mixamo",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"mixamo"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "fingerlay",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"fingerlay"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "fingerstand",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"fingerstand"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "breakdance",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"breakdance"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "hiphop",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"hiphop"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "ballskick",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"ballskick"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\masterchief\mp_masterchief\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                    },
                };
                CacheContext.Serialize(stream, pactTag, pact);
            }
        }

        public void GenerateEliteActionTag()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                var trakTag = CacheContext.TagCache.AllocateTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera");
                var trak = new CameraTrack
                {
                    ControlPoints = new List<CameraTrack.CameraPoint>
                    {
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(3.934E-08f, 0f, 0.9f),
                            Orientation = new RealQuaternion(0f, -0.7071069f, 0f, -0.7071068f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.1732779f, 0f, 0.9380214f),
                            Orientation = new RealQuaternion(0f, -0.6234899f, 0f, -0.7818315f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.3668045f, 0f, 0.9310074f),
                            Orientation = new RealQuaternion(0f, -0.5320321f, 0f, -0.8467242f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.5661401f, 0f, 0.8719415f),
                            Orientation = new RealQuaternion(0f, -0.4338837f, 0f, -0.9009689f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.7549486f, 0f, 0.7586696f),
                            Orientation = new RealQuaternion(0f, -0.3302791f, 0f, -0.9438834f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.9165863f, 0f, 0.5943015f),
                            Orientation = new RealQuaternion(0f, -0.222521f, 0f, -0.9749279f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-1.035744f, 0f, 0.3871195f),
                            Orientation = new RealQuaternion(0f, -0.1119645f, 0f, -0.9937123f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-1.1f, 0f, 0.1500001f),
                            Orientation = new RealQuaternion(0f, -5.96E-08f, 0f, -1f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-1.083231f, 0f, -0.09652288f),
                            Orientation = new RealQuaternion(0f, 0.1119645f, 0f, -0.9937123f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.9699321f, 0f, -0.3141978f),
                            Orientation = new RealQuaternion(0f, 0.2225208f, 0f, -0.974928f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.7783985f, 0f, -0.4641338f),
                            Orientation = new RealQuaternion(0f, 0.330279f, 0f, -0.9438834f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.5408726f, 0f, -0.5162081f),
                            Orientation = new RealQuaternion(0f, 0.4338836f, 0f, -0.900969f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.2999597f, 0f, -0.4535427f),
                            Orientation = new RealQuaternion(0f, 0.532032f, 0f, -0.8467243f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(-0.103738f, 0f, -0.2756643f),
                            Orientation = new RealQuaternion(0f, 0.6234898f, 0f, -0.7818316f),
                        },
                        new CameraTrack.CameraPoint
                        {
                            Position = new RealVector3d(0f, 0f, 1.9073E-08f),
                            Orientation = new RealQuaternion(0f, 0.7071067f, 0f, -0.7071069f),
                        },
                    },
                };
                CacheContext.Serialize(stream, trakTag, trak);

                var pactTag = CacheContext.TagCache.AllocateTag<PlayerActionSet>($@"objects\characters\elite\mp_elite\actions");
                var pact = new PlayerActionSet
                {
                    Widget = new PlayerActionSet.WidgetData
                    {
                        Title = "Elite Actions",
                    },
                    Actions = new List<PlayerActionSet.Action>
                    {
                        new PlayerActionSet.Action
                        {
                            Title = "Dance",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"thunder_clap"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "twerk",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"twerk"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "dance1test",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"dance1test"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "dance1",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"dance1"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "mixamo",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"mixamo"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "fingerlay",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"fingerlay"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "fingerstand",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"fingerstand"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "breakdance",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"breakdance"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "hiphop",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"hiphop"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "ballskick",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"ballskick"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "Berserk",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"berserk"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "Cheer",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"cheer"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "Warn",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"warn"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                        new PlayerActionSet.Action
                        {
                            Title = "Taunt",
                            IconName = "temp",
                            AnimationEnter = CacheContext.StringTable.GetStringId($@"taunt"),
                            Flags = PlayerActionSet.Action.ActionFlags.HideWeapon | PlayerActionSet.Action.ActionFlags.ForceThirdPersonCamera | PlayerActionSet.Action.ActionFlags.InhibitMovement,
                            OverrideCamera = new List<Unit.UnitCameraBlock>
                            {
                                new Unit.UnitCameraBlock
                                {
                                    PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85f), Angle.FromDegrees(10f)),
                                    CameraTracks = new List<Unit.UnitCameraTrack>
                                    {
                                        new Unit.UnitCameraTrack
                                        {
                                            Track = GetCachedTag<CameraTrack>($@"objects\characters\elite\mp_elite\action_camera"),
                                        },
                                    },
                                },
                            },
                        },
                    },
                };
                CacheContext.Serialize(stream, pactTag, pact);
            }
        }
    }
}