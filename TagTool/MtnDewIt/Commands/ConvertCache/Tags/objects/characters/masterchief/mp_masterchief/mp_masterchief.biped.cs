using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_mp_masterchief_mp_masterchief_biped : TagFile
    {
        public objects_characters_masterchief_mp_masterchief_mp_masterchief_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"objects\characters\masterchief\mp_masterchief\mp_masterchief");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
