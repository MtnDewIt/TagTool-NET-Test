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
                        bipd.HologramUnit = GetCachedTag<Biped>($@"objects\equipment\hologram\bipeds\masterchief_hologram");
                        bipd.DefaultTeam = Unit.DefaultTeamValue.Human;
                        bipd.SyncActionCamera.PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85), Angle.FromDegrees(10));
                        bipd.SyncActionCamera.CameraTracks = new List<Unit.UnitCameraTrack>
                        {
                            new Unit.UnitCameraTrack
                            {
                                Track = GetCachedTag<CameraTrack>($@"camera\biped_assassination_camera"),
                            },
                        };
                        bipd.Assassination.Response = GetCachedTag<DamageResponseDefinition>($@"globals\damage_responses\player_assassination");
                        bipd.Assassination.Weapon = GetCachedTag<Scenery>($@"objects\props\human\unsc\spartan_knife\spartan_knife");
                        bipd.Assassination.ToolStowAnchor = CacheContext.StringTable.GetStringId($@"knife_stow_anchor");
                        bipd.Assassination.ToolHandMarker = CacheContext.StringTable.GetStringId($@"right_hand");
                        bipd.Assassination.ToolMarker = CacheContext.StringTable.GetStringId($@"ass_wpn_placement");
                        bipd.ShieldPopDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\shield_pop_melee");
                        bipd.AssassinationDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\assassination");
                        bipd.RunningCameraHeight = 0.62f;
                        bipd.CrouchWalkingCameraHeight = 0.45f;
                        bipd.CameraHeightVelocity = 0.8500001f;
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\characters\elite\mp_elite\mp_elite")
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.HologramUnit = GetCachedTag<Biped>($@"objects\equipment\hologram\bipeds\elite_hologram");
                        bipd.DefaultTeam = Unit.DefaultTeamValue.Covenant;
                        bipd.SyncActionCamera.PitchRange = new Bounds<Angle>(Angle.FromDegrees(-85), Angle.FromDegrees(10));
                        bipd.SyncActionCamera.CameraTracks = new List<Unit.UnitCameraTrack>
                        {
                            new Unit.UnitCameraTrack
                            {
                                Track = GetCachedTag<CameraTrack>($@"camera\biped_assassination_camera"),
                            },
                        };
                        bipd.Assassination.Response = GetCachedTag<DamageResponseDefinition>($@"globals\damage_responses\player_assassination");
                        bipd.ShieldPopDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\shield_pop_melee");
                        bipd.AssassinationDamage = GetCachedTag<DamageEffect>($@"globals\damage_effects\assassination");
                        bipd.RunningCameraHeight = 0.62f;
                        bipd.CrouchWalkingCameraHeight = 0.45f;
                        bipd.CameraHeightVelocity = 0.8500001f;
                        CacheContext.Serialize(stream, tag, bipd);
                    }

                    if (tag.IsInGroup("bipd") && tag.Name == $@"objects\equipment\hologram\bipeds\masterchief_hologram")
                    {
                        var bipd = CacheContext.Deserialize<Biped>(stream, tag);
                        bipd.ObjectFlags = ObjectDefinitionFlags.DoesNotCastShadow;
                        bipd.Model = GetCachedTag<Model>($@"objects\equipment\hologram\bipeds\masterchief_hologram");
                        bipd.CollisionDamage = null;
                        bipd.MaterialEffects = null;
                        bipd.ArmorSounds = null;
                        bipd.MeleeImpactSound = null;
                        bipd.AiProperties = null;
                        bipd.Functions = null;
                        bipd.Attachments = null;
                        bipd.UnitFlags = Unit.UnitFlagBits.ShieldSapping;
                        bipd.DefaultTeam = Unit.DefaultTeamValue.Player;
                        bipd.UnitCamera.CameraTracks = null;
                        bipd.UnitCamera.CameraAcceleration = null;
                        bipd.SyncActionCamera.PitchRange.Lower = Angle.FromRadians(0);
                        bipd.SyncActionCamera.PitchRange.Upper = Angle.FromRadians(0);
                        bipd.SyncActionCamera.CameraTracks = null;
                        bipd.Assassination.Response = null;
                        bipd.Assassination.Weapon = null;
                        bipd.Assassination.ToolStowAnchor = StringId.Invalid;
                        bipd.Assassination.ToolHandMarker = StringId.Invalid;
                        bipd.Assassination.ToolMarker = StringId.Invalid;
                        bipd.BoardingMeleeDamage = null;
                        bipd.BoardingMeleeResponse = null;
                        bipd.EvictionMeleeDamage = null;
                        bipd.EvictionMeleeResponse = null;
                        bipd.ShieldPopDamage = null;
                        bipd.AssassinationDamage = null;
                        bipd.HudInterfaces = null;
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
                        hlmt.Materials[0].DamageSectionIndex = 0;
                        hlmt.Materials[0].GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        hlmt.Materials[0].GlobalMaterialIndex = 157;
                        hlmt.Materials[1].GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        hlmt.Materials[1].GlobalMaterialIndex = 157;
                        hlmt.NewDamageInfo[0].GlobalIndirectMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        hlmt.NewDamageInfo[0].GlobalShieldMaterialName = CacheContext.StringTable.GetStringId($@"energy_shield_thin");
                        hlmt.NewDamageInfo[0].ShieldDepletedEffect = null;
                        hlmt.NewDamageInfo[0].ShieldRechargingEffect = null;
                        hlmt.NewDamageInfo[0].DamageSections = new List<Model.GlobalDamageInfoBlock.DamageSection>
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
                        };
                        hlmt.NewDamageInfo[0].GlobalShieldMaterialIndex = 145;
                        hlmt.NewDamageInfo[0].GlobalIndirectMaterialIndex = 157;
                        hlmt.Targets = null;
                        hlmt.CollisionRegions[0].PhysicsRegionIndex = 0;
                        hlmt.CollisionRegions[0].Permutations[0].PhysicsPermutationIndex = 0;
                        hlmt.CollisionRegions[2].PhysicsRegionIndex = 0;
                        hlmt.CollisionRegions[2].Permutations[0].PhysicsPermutationIndex = 0;
                        hlmt.CollisionRegions[3].PhysicsRegionIndex = 0;
                        hlmt.CollisionRegions[3].Permutations[0].PhysicsPermutationIndex = 0;
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
                        bipd.UnitCamera.CameraTracks = null;
                        bipd.UnitCamera.CameraAcceleration = null;
                        bipd.SyncActionCamera.PitchRange.Lower = Angle.FromRadians(0);
                        bipd.SyncActionCamera.PitchRange.Upper = Angle.FromRadians(0);
                        bipd.SyncActionCamera.CameraTracks = null;
                        bipd.Assassination.Response = null;
                        bipd.Assassination.Weapon = null;
                        bipd.Assassination.ToolStowAnchor = StringId.Invalid;
                        bipd.Assassination.ToolHandMarker = StringId.Invalid;
                        bipd.Assassination.ToolMarker = StringId.Invalid;
                        bipd.BoardingMeleeDamage = null;
                        bipd.BoardingMeleeResponse = null;
                        bipd.EvictionMeleeDamage = null;
                        bipd.EvictionMeleeResponse = null;
                        bipd.ShieldPopDamage = null;
                        bipd.AssassinationDamage = null;
                        bipd.HudInterfaces = null;
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
                        bipd.AreaDamageEffect = null;
                        bipd.PhysicsFlags.Halo3ODST = Havok.BipedPhysicsFlags.Halo3OdstBits.None;
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
                        hlmt.Materials[0].DamageSectionIndex = 0;
                        hlmt.Materials[0].GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        hlmt.Materials[0].GlobalMaterialIndex = 157;
                        hlmt.Materials[1].GlobalMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        hlmt.Materials[1].GlobalMaterialIndex = 157;
                        hlmt.NewDamageInfo[0].GlobalIndirectMaterialName = CacheContext.StringTable.GetStringId($@"energy_holo");
                        hlmt.NewDamageInfo[0].GlobalShieldMaterialName = CacheContext.StringTable.GetStringId($@"energy_shield_thin");
                        hlmt.NewDamageInfo[0].ShieldDepletedEffect = null;
                        hlmt.NewDamageInfo[0].ShieldRechargingEffect = null;
                        hlmt.NewDamageInfo[0].DamageSections = new List<Model.GlobalDamageInfoBlock.DamageSection>
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
                        };
                        hlmt.NewDamageInfo[0].GlobalShieldMaterialIndex = 145;
                        hlmt.NewDamageInfo[0].GlobalIndirectMaterialIndex = 157;
                        hlmt.Targets = null;
                        hlmt.CollisionRegions[0].PhysicsRegionIndex = 0;
                        hlmt.CollisionRegions[0].Permutations[0].PhysicsPermutationIndex = 0;
                        hlmt.CollisionRegions[2].PhysicsRegionIndex = 0;
                        hlmt.CollisionRegions[2].Permutations[0].PhysicsPermutationIndex = 0;
                        hlmt.CollisionRegions[3].PhysicsRegionIndex = 0;
                        hlmt.CollisionRegions[3].Permutations[0].PhysicsPermutationIndex = 0;
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
                    // Will Populate if we ever find tag data for it :/
                };
                CacheContext.Serialize(stream, pactTag, pact);
            }
        }
    }
}