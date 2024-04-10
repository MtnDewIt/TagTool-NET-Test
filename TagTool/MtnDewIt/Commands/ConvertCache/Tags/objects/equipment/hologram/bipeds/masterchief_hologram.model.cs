using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using static TagTool.Tags.Definitions.Model.GlobalDamageInfoBlock.DamageSection;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_equipment_hologram_bipeds_masterchief_hologram_model : TagFile
    {
        public objects_equipment_hologram_bipeds_masterchief_hologram_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Model>($@"objects\equipment\hologram\bipeds\masterchief_hologram");
            var hlmt = CacheContext.Deserialize<Model>(Stream, tag);
            hlmt.PhysicsModel = null;
            hlmt.DisappearDistance = 150;
            hlmt.BeginFadeDistance = 130;
            hlmt.Materials = new List<Model.Material>
            {
                new Model.Material
                {
                    MaterialName = CacheContext.StringTable.GetOrAddString($@"head"),
                    MaterialType = Model.Material.MaterialTypeValue.Dirt,
                    RuntimeDamagerMaterialIndex = -1,
                    GlobalMaterialName = CacheContext.StringTable.GetOrAddString($@"energy_holo"),
                    GlobalMaterialIndex = 157,
                },
                new Model.Material
                {
                    MaterialName = CacheContext.StringTable.GetOrAddString($@"body"),
                    MaterialType = Model.Material.MaterialTypeValue.Dirt,
                    RuntimeCollisionMaterialIndex = 1,
                    RuntimeDamagerMaterialIndex = -1,
                    GlobalMaterialName = CacheContext.StringTable.GetOrAddString($@"energy_holo"),
                    GlobalMaterialIndex = 157,
                },
            };
            hlmt.NewDamageInfo = new List<Model.GlobalDamageInfoBlock> 
            {
                new Model.GlobalDamageInfoBlock
                {
                    Flags = Model.GlobalDamageInfoBlock.FlagsValue.TakesShieldDamageForChildren | Model.GlobalDamageInfoBlock.FlagsValue.TakesBodyDamageForChildren,
                    GlobalIndirectMaterialName = CacheContext.StringTable.GetOrAddString($@"energy_holo"),
                    IndirectDamageSection = 0,
                    CollisionDamageReportingType = new Damage.DamageReportingType
                    {
                        HaloOnline = Damage.DamageReportingType.HaloOnlineValue.Guardians,
                    },
                    ResponseDamageReportingType = new Damage.DamageReportingType
                    {
                        HaloOnline = Damage.DamageReportingType.HaloOnlineValue.Guardians,
                    },
                    MaximumVitality = 45,
                    MinStunDamage = 0,
                    StunTime = 10,
                    RechargeTime = 5,
                    RechargeFraction = 1,
                    MaxShieldVitality = 70,
                    GlobalShieldMaterialName = CacheContext.StringTable.GetOrAddString($@"energy_shield_thin"),
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
                            Name = CacheContext.StringTable.GetOrAddString($@"main"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"arms"),
                    Permutations = new List<Model.CollisionRegion.Permutation>
                    {
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"base"),
                            Pad = new byte[1],
                        },
                    },
                },
                new Model.CollisionRegion
                {
                    Pad1 = new byte[2],
                    Name = CacheContext.StringTable.GetOrAddString($@"body"),
                    CollisionRegionIndex = 1,
                    Permutations = new List<Model.CollisionRegion.Permutation>
                    {
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"base"),
                            Pad = new byte[1],
                        },
                    },
                },
                new Model.CollisionRegion
                {
                    Pad1 = new byte[2],
                    Name = CacheContext.StringTable.GetOrAddString($@"chest"),
                    CollisionRegionIndex = -1,
                    Permutations = new List<Model.CollisionRegion.Permutation>
                    {
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                            CollisionPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_regulator"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_ryu"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_katana"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_bungie"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                    },
                },
                new Model.CollisionRegion
                {
                    Pad1 = new byte[2],
                    Name = CacheContext.StringTable.GetOrAddString($@"decals"),
                    CollisionRegionIndex = -1,
                    Permutations = new List<Model.CollisionRegion.Permutation>
                    {
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"base"),
                            CollisionPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                    },
                },
                new Model.CollisionRegion
                {
                    Pad1 = new byte[2],
                    Name = CacheContext.StringTable.GetOrAddString($@"helmet"),
                    CollisionRegionIndex = 2,
                    PhysicsRegionIndex = -1,
                    Permutations = new List<Model.CollisionRegion.Permutation>
                    {
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"base"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"realtime"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_regulator"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"ui"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_ryu"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_marathon"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_markv"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_rogue"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_odst"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                    },
                },
                new Model.CollisionRegion
                {
                    Pad1 = new byte[2],
                    Name = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                    CollisionRegionIndex = -1,
                    PhysicsRegionIndex = -1,
                    Permutations = new List<Model.CollisionRegion.Permutation>
                    {
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"base"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_regulator"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_ryu"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_marathon"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                    },
                },
                new Model.CollisionRegion
                {
                    Pad1 = new byte[2],
                    Name = CacheContext.StringTable.GetOrAddString($@"legs"),
                    CollisionRegionIndex = 3,
                    PhysicsRegionIndex = -1,
                    Permutations = new List<Model.CollisionRegion.Permutation>
                    {
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"base"),
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                    },
                },
                new Model.CollisionRegion
                {
                    Pad1 = new byte[2],
                    Name = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                    CollisionRegionIndex = -1,
                    PhysicsRegionIndex = -1,
                    Permutations = new List<Model.CollisionRegion.Permutation>
                    {
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"base"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_regulator"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_ryu"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_marathon"),
                            CollisionPermutationIndex = -1,
                            PhysicsPermutationIndex = -1,
                            Pad = new byte[1],
                        },
                        new Model.CollisionRegion.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
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
            CacheContext.Serialize(Stream, tag, hlmt);
        }
    }
}
