using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_elite_mp_elite_mp_elite_biped : TagFile
    {
        public objects_characters_elite_mp_elite_mp_elite_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"objects\characters\elite\mp_elite\mp_elite");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
