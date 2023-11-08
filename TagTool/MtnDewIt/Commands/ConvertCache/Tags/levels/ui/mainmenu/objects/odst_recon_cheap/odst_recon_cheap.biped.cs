using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_biped : TagFile
    {
        public levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_biped(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<Biped>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
            var bipd = CacheContext.Deserialize<Biped>(Stream, tag);
            bipd.CollisionDamage = null;
            bipd.BoundingRadius = 0.365f;
            bipd.BoundingOffset = new RealPoint3d(-0.05f, 0f, 0f);
            bipd.AccelerationScale = 1.25f;
            bipd.DefaultModelVariant = StringId.Invalid;
            bipd.Model = GetCachedTag<Model>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
            bipd.AiProperties = null;
            bipd.Functions = null;
            bipd.Attachments = null;
            bipd.ChangeColors = new List<GameObject.ChangeColor> 
            {
                new GameObject.ChangeColor
                {
                    InitialPermutations = new List<GameObject.ChangeColor.InitialPermutation>
                    {
                        new GameObject.ChangeColor.InitialPermutation
                        {
                            Weight = 1,
                            ColorLowerBound = new RealRgbColor(0.1557059f, 0.1557059f, 0.155706f),
                            ColorUpperBound = new RealRgbColor(0.1529412f, 0.1529412f, 0.1529412f),
                            VariantName = CacheContext.StringTable.GetStringId($@"default"),
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
                            ColorLowerBound = new RealRgbColor(0.5019608f, 0.5019608f, 0.5019608f),
                            ColorUpperBound = new RealRgbColor(0.5019608f, 0.5019608f, 0.5019608f),
                            VariantName = CacheContext.StringTable.GetStringId($@"default"),
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
                            ColorLowerBound = new RealRgbColor(1f, 1f, 1f),
                            ColorUpperBound = new RealRgbColor(1f, 1f, 1f),
                            VariantName = CacheContext.StringTable.GetStringId($@"default"),
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
                            ColorLowerBound = new RealRgbColor(1f, 1f, 1f),
                            ColorUpperBound = new RealRgbColor(1f, 1f, 1f),
                        },
                    },
                },
            };
            bipd.PathfindingSpheres = null;
            bipd.UnitFlags = Unit.UnitFlagBits.FiresFromCamera | Unit.UnitFlagBits.MeleeAttackersCannotAttach | Unit.UnitFlagBits.ShieldSapping | Unit.UnitFlagBits.UseAimStillXxForAirborne;
            bipd.CameraFieldOfView = Angle.FromDegrees(80f);
            bipd.MotionTrackerRangeModifier = 25f;
            bipd.GrenadeAngle = Angle.FromDegrees(15f);
            bipd.GrenadeAngleMaxElevation = Angle.FromDegrees(35f);
            bipd.GrenadeAngleMinElevation = Angle.FromDegrees(60f);
            bipd.GrenadeVelocity =  8.25f;
            bipd.GrenadeCount = 3;
            bipd.BipedFlags = Biped.BipedDefinitionFlags.StunnedByEmpDamage;
            bipd.JumpVelocity = 2.6f;
            bipd.MaximumSoftLandingTime = 0f;
            bipd.MinimumHardLandingTime = 0f;
            bipd.MinimumHardLandingVelocity = 3.8f;
            bipd.StunDuration = 1.5f;
            bipd.StandingCameraHeight = 0.575f;
            bipd.RunningCameraHeight = 0.57f;
            bipd.CrouchingCameraHeight = 0.375f;
            bipd.CrouchWalkingCameraHeight = 0.4f;
            bipd.CameraForwardMovementScale = 0.5f;
            bipd.CameraExclusionDistance = 0.23f;
            bipd.AutoaimWidth = 0.13f;
            bipd.PhysicsControlNodeIndex = 2;
            bipd.CameraHeightVelocity = 0.9999999f;
            bipd.HeadNodeIndex = 16;
            bipd.HeadshotAccelerationScale = 0f;
            bipd.FpCrouchMovingAnimSpeedScale = 0.65f;
            bipd.HeadshotAccelerationScale = 1.25f;
            bipd.MovementGates = new List<Biped.MovementGateBlock> 
            {
                new Biped.MovementGateBlock
                {
                    Period = 0.34f,
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
                new Biped.MovementGateBlock
                {
                    Period = 0.34f,
                    ZOffset = 0.0025f,
                    ConstantZOffset = 0.035f,
                    YOffset = 0.75f,
                    DefaultFunction = new TagFunction
                    {
                        Data = new byte[]
                        {
                            0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x00,
                            0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                            0xCD, 0xCC, 0xCC, 0x3E, 0xF6, 0xFF, 0x79, 0xC1, 0xFA, 0xFF,
                            0x3D, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x07, 0x4C, 0xF3, 0xBD, 0x9A, 0x99, 0x19, 0x3F, 0x00, 0x00,
                            0xF0, 0x37, 0x2E, 0x00, 0x20, 0xC1, 0x18, 0x00, 0x20, 0x41,
                            0x24, 0x00, 0xC0, 0xBF, 0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF,
                            0x7F, 0x7F, 0x01, 0x00, 0x7A, 0x41, 0x01, 0x00, 0x0C, 0xC2,
                            0x02, 0x00, 0xB9, 0x41, 0x06, 0x00, 0x70, 0xC0,
                        },
                    },
                },
                new Biped.MovementGateBlock
                {
                    Period = 0.34f,
                    ZOffset = 0.01f,
                    ConstantZOffset = 0.0075f,
                    YOffset = 1.25f,
                    DefaultFunction = new TagFunction
                    {
                        Data = new byte[]
                        {
                            0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x00,
                            0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                            0xCD, 0xCC, 0xCC, 0x3E, 0x22, 0x0B, 0x8A, 0xC1, 0x4E, 0x6F,
                            0x48, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x07, 0x4C, 0xF3, 0xBD, 0x9A, 0x99, 0x19, 0x3F, 0xEF, 0x73,
                            0x12, 0xC1, 0xA0, 0xCE, 0x83, 0x40, 0x3A, 0x9A, 0x35, 0x40,
                            0x96, 0xD1, 0x9D, 0xBE, 0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF,
                            0x7F, 0x7F, 0x4A, 0x79, 0x6F, 0x41, 0x70, 0x28, 0x05, 0xC2,
                            0xD1, 0x6B, 0xAD, 0x41, 0xAF, 0xBC, 0x56, 0xC0,
                        },
                    },
                },
            };
            bipd.MovementGatesCrouching = new List<Biped.MovementGateBlock> 
            {
                new Biped.MovementGateBlock
                {
                    Period = 0.1f,
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
                new Biped.MovementGateBlock
                {
                    Period = 0.78f,
                    ZOffset = 0.05f,
                    ConstantZOffset = 0.05f,
                    YOffset = 0.25f,
                    DefaultFunction = new TagFunction
                    {
                        Data = new byte[]
                        {
                            0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x00,
                            0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                            0xCD, 0xCC, 0xCC, 0x3E, 0xF6, 0xFF, 0x79, 0xC1, 0xFA, 0xFF,
                            0x3D, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x07, 0x4C, 0xF3, 0xBD, 0x9A, 0x99, 0x19, 0x3F, 0x00, 0x00,
                            0xF0, 0x37, 0x2E, 0x00, 0x20, 0xC1, 0x18, 0x00, 0x20, 0x41,
                            0x24, 0x00, 0xC0, 0xBF, 0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF,
                            0x7F, 0x7F, 0x01, 0x00, 0x7A, 0x41, 0x01, 0x00, 0x0C, 0xC2,
                            0x02, 0x00, 0xB9, 0x41, 0x06, 0x00, 0x70, 0xC0,
                        },
                    },
                },
                new Biped.MovementGateBlock
                {
                    Period = 0.78f,
                    ZOffset = 0.075f,
                    ConstantZOffset = 0.075f,
                    YOffset = 0.5f,
                    DefaultFunction = new TagFunction
                    {
                        Data = new byte[]
                        {
                            0x08, 0x34, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4C, 0x00,
                            0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0xCD,
                            0xCD, 0xCC, 0xCC, 0x3E, 0xF6, 0xFF, 0x79, 0xC1, 0xFA, 0xFF,
                            0x3D, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x07, 0x4C, 0xF3, 0xBD, 0x9A, 0x99, 0x19, 0x3F, 0x00, 0x00,
                            0xF0, 0x37, 0x2E, 0x00, 0x20, 0xC1, 0x18, 0x00, 0x20, 0x41,
                            0x24, 0x00, 0xC0, 0xBF, 0x07, 0x00, 0x00, 0x00, 0xFF, 0xFF,
                            0x7F, 0x7F, 0x01, 0x00, 0x7A, 0x41, 0x01, 0x00, 0x0C, 0xC2,
                            0x02, 0x00, 0xB9, 0x41, 0x06, 0x00, 0x70, 0xC0,
                        },
                    },
                },
            };
            bipd.JumpAimOffsetDistance = -0.055f;
            bipd.JumpAimOffsetDuration = 0.075f;
            bipd.LandAimOffsetDistance = -0.045f;
            bipd.LandAimOffsetDuration = 0.25f;
            bipd.AimCompensateMinDistance = 2.5f;
            bipd.AimCompensateMaxDistance = 10f;
            bipd.HeightStanding = 0.61f;
            bipd.HeightCrouching = 0.45f;
            bipd.Radius = 0.135f;
            bipd.Mass = 100f;
            bipd.LivingMaterialName = StringId.Invalid;
            bipd.DeadMaterialName = StringId.Invalid;
            bipd.LivingGlobalMaterialIndex = 9;
            bipd.DeadGlobalMaterialIndex = 9;
            bipd.DeadSphereShapes = new List<PhysicsModel.Sphere>
            {
                new PhysicsModel.Sphere
                {
                    MaterialIndex = -1,
                    PhantomIndex = -1,
                    ShapeBase = new PhysicsModel.HavokShapeBase
                    {
                        FieldPointerSkip = new PlatformUnsignedValue(0x0),
                        Count = 128,
                        Userdata = new PlatformUnsignedValue(0x0),
                        ShapeType = 3,
                        Radius = 0.135f,
                    },
                    Pad = new byte[]
                    {
                        12
                    },
                    ConvexBase = new PhysicsModel.HavokShapeBase
                    {
                        FieldPointerSkip = new PlatformUnsignedValue(0x0),
                        Count = 128,
                        Userdata = new PlatformUnsignedValue(0x20),
                        ShapeType = 12,
                        Radius = 0.135f,
                    },
                    FieldPointerSkip = new PlatformUnsignedValue(0x0),
                    Translation = new RealVector3d(0f, 0f, 0.135f),
                },
                new PhysicsModel.Sphere
                {
                    MaterialIndex = -1,
                    PhantomIndex = -1,
                    ShapeBase = new PhysicsModel.HavokShapeBase
                    {
                        FieldPointerSkip = new PlatformUnsignedValue(0x0),
                        Count = 128,
                        Userdata = new PlatformUnsignedValue(0x70),
                        ShapeType = 3,
                        Radius = 0.18225f,
                    },
                    Pad = new byte[]
                    {
                        12
                    },
                    ConvexBase = new PhysicsModel.HavokShapeBase
                    {
                        FieldPointerSkip = new PlatformUnsignedValue(0x0),
                        Count = 128,
                        Userdata = new PlatformUnsignedValue(0x90),
                        ShapeType = 12,
                        Radius = 0.18225f,
                    },
                    FieldPointerSkip = new PlatformUnsignedValue(0x0),
                    Translation = new RealVector3d(0f, 0f, 0.18225f),
                },
                new PhysicsModel.Sphere
                {
                    MaterialIndex = -1,
                    PhantomIndex = -1,
                    ShapeBase = new PhysicsModel.HavokShapeBase
                    {
                        FieldPointerSkip = new PlatformUnsignedValue(0x0),
                        Count = 128,
                        Userdata = new PlatformUnsignedValue(0xE0),
                        ShapeType = 3,
                        Radius = 0.2295f,
                    },
                    Pad = new byte[]
                    {
                        12
                    },
                    ConvexBase = new PhysicsModel.HavokShapeBase
                    {
                        FieldPointerSkip = new PlatformUnsignedValue(0x0),
                        Count = 128,
                        Userdata = new PlatformUnsignedValue(0x100),
                        ShapeType = 12,
                        Radius = 0.2295f,
                    },
                    FieldPointerSkip = new PlatformUnsignedValue(0x0),
                    Translation = new RealVector3d(0f, 0f, 0.2295f),
                },
            };
            bipd.PillShapes = new List<PhysicsModel.Pill>
            {
                new PhysicsModel.Pill
                {
                    MaterialIndex = -1,
                    PhantomIndex = -1,
                    ShapeBase = new PhysicsModel.HavokShapeBase
                    {
                        FieldPointerSkip = new PlatformUnsignedValue(0x0),
                        Count = 128,
                        Userdata = new PlatformUnsignedValue(0x0),
                        ShapeType = 7,
                        Radius = 0.135f,
                    },
                    Pad = new byte[]
                    {
                        12
                    },
                    Bottom = new RealVector3d(0f, 0f, 0.475f),
                    BottomRadius = 0.135f,
                    Top = new RealVector3d(0f, 0f, 0.135f),
                    TopRadius = 0.135f,
                },
                new PhysicsModel.Pill
                {
                    MaterialIndex = -1,
                    PhantomIndex = -1,
                    ShapeBase = new PhysicsModel.HavokShapeBase
                    {
                        FieldPointerSkip = new PlatformUnsignedValue(0x0),
                        Count = 128,
                        Userdata = new PlatformUnsignedValue(0x60),
                        ShapeType = 7,
                        Radius = 0.135f,
                    },
                    Pad = new byte[]
                    {
                        12
                    },
                    Bottom = new RealVector3d(0f, 0f, 0.315f),
                    BottomRadius = 0.135f,
                    Top = new RealVector3d(0f, 0f, 0.135f),
                    TopRadius = 0.135f,
                },
            };
            bipd.BipedGroundPhysics = new Biped.CharacterPhysicsGroundStruct 
            {
                MaximumSlopeAngle = Angle.FromDegrees(35f),
                DownhillFalloffAngle = Angle.FromDegrees(45f),
                DownhillCutoffAngle = Angle.FromDegrees(50f),
                UphillFalloffAngle = Angle.FromDegrees(30f),
                UphillCutoffAngle = Angle.FromDegrees(40f),
                DownhillVelocityScale = 1.5f,
                UphillVelocityScale = 0.5f,
                RuntimeMinimumNormalK = 0.8191521f,
                RuntimeDownhillK0 = -0.7071068f,
                RuntimeDownhillK1 = -0.7660444f,
                RuntimeUphillK0 = 0.5f,
                RuntimeUphillK1 = 0.6427876f,
                ClimbInflectionAngle = Angle.FromDegrees(-20f),
                GravityScale = 1.075f,
            };
            bipd.BipedGroundFittingData = new Biped.BipedGroundFitting
            {
                GroundNormalDampening = 0.75f,
                RootOffsetMaxScale = 0.5f,
                RootOffsetDampening = 0.8f,
                FollowingCamScale = 0.5f,
                RootLeaningScale = 0.1f,
                FootRollMax = Angle.FromDegrees(5.00003f),
                FootPitchMax = Angle.FromDegrees(40f),
                PivotonfootScale = 1,
                PivotMinFootDelta = 0.005f,
                PivotStrideLengthScale = 1,
                PivotThrottleScale = 0.5f,
                PivotOffsetDampening = 0.1f,
            };
            bipd.UnitCamera = null;
            bipd.RightHandNode = StringId.Invalid;
            bipd.LeftHandNode = StringId.Invalid;
            bipd.PreferredGunNode = StringId.Invalid;
            bipd.BoardingMeleeDamage = null;
            bipd.BoardingMeleeResponse = null;
            CacheContext.Serialize(Stream, tag, bipd);
        }
    }
}
