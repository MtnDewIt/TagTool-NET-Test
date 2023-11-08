using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_equipment_hologram_bipeds_masterchief_hologram_biped : TagFile
    {
        public objects_equipment_hologram_bipeds_masterchief_hologram_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"objects\equipment\hologram\bipeds\masterchief_hologram");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
