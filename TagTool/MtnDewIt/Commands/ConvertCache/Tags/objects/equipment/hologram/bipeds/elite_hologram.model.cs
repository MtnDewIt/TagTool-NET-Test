using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using static TagTool.Tags.Definitions.Model.GlobalDamageInfoBlock.DamageSection;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_equipment_hologram_bipeds_elite_hologram_model : TagFile
    {
        public objects_equipment_hologram_bipeds_elite_hologram_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Model>($@"objects\equipment\hologram\bipeds\elite_hologram");
            var hlmt = CacheContext.Deserialize<Model>(Stream, tag);
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
            CacheContext.Serialize(Stream, tag, hlmt);
        }
    }
}
