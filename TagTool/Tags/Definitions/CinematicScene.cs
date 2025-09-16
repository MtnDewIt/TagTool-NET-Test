using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;
using System;
using static TagTool.Tags.TagFieldFlags;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "cinematic_scene", Tag = "cisc", Size = 0x78, MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Eldorado700123)]
    [TagStructure(Name = "cinematic_scene", Tag = "cisc", Size = 0x5C, MinVersion = CacheVersion.HaloReach)]
    public class CinematicScene : TagStructure
    {
        public StringId Name;
        [TagField(Length = 32, MaxVersion = CacheVersion.Eldorado700123)]
        public string AnchorName;
        [TagField(MinVersion = CacheVersion.HaloReach)]
        public StringId Anchor;

        public SceneResetObjectLightingEnum ResetObjectLighting;

        [TagField(Length = 2, Flags = Padding)]
        public byte[] Padd;

        public byte[] ImportScriptHeader;

        public List<ObjectBlock> Objects;
        public List<ShotBlock> Shots;
        public List<ExtraCameraFrameDataBlock> ExtraCameraFrameData;
        public byte[] ImportScriptFooter;
        public uint Version;

        public enum SceneResetObjectLightingEnum : short
        {
            Default,
            DontResetLighting,
            ResetLighting
        }

        [TagStructure(Size = 0x74, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0x5C, MinVersion = CacheVersion.HaloReach)]
        public class ObjectBlock : TagStructure
        {
            [TagField(Length = 32, MaxVersion = CacheVersion.Eldorado700123)]
            public string ImportName;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public StringId Name;

            [TagField(Flags = Label)]
            public StringId Identifier;
            public StringId VariantName;
            public CachedTag PuppetAnimation;
            public CachedTag PuppetObject;
            public ObjectFlags Flags;
            public uint ShotsActiveFlags;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public uint LightmapShadowFlags;

            public CinematicCoopTypeFlags OverrideCreationFlags;
            public byte[] ImportOverrideCreationScript;
            public List<AttachmentsBlock> Attachments;

            [Flags]
            public enum ObjectFlags : uint
            {
                None,
                PlacedManuallyInSapien = 1 << 0,
                ObjectComesFromGame = 1 << 1,
                NameIsFunctionCall = 1 << 2,
                EffectObject = 1 << 3,
                NoLightmapShadow = 1 << 4,
                unknown5 = 1 << 5,
                unknown6 = 1 << 6,
                unknown7 = 1 << 7,
                UsePlayer1Appearance = 1 << 8,
                UsePlayer2Appearance = 1 << 9,
                UsePlayer3Appearance = 1 << 10,
                UsePlayer4Appearance = 1 << 11,
            }

            [Flags]
            public enum CinematicCoopTypeFlags : uint
            {
                SinglePlayer = 1 << 0,
                _2PlayerCoop = 1 << 1,
                _3PlayerCoop = 1 << 2,
                _4PlayerCoop = 1 << 3
            }

            [TagStructure(Size = 0x38, MaxVersion = CacheVersion.Eldorado700123)]
            [TagStructure(Size = 0x20, MinVersion = CacheVersion.HaloReach)]
            public class AttachmentsBlock : TagStructure
            {
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public SceneObjectAttachmentFlags Flags;
                [TagField(MinVersion = CacheVersion.HaloReach, Length = 0x3, Flags = Padding)]
                public byte[] Pad;

                public StringId ObjectMarkerName;
                [TagField(Length = 32, MaxVersion = CacheVersion.Eldorado700123)]
                public string AttachmentObjectName;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public StringId AttachmentObjectId;
                public StringId AttachmentMarkerName;
                public CachedTag AttachmentType;

                [Flags]
                public enum SceneObjectAttachmentFlags : byte
                {
                    Invisible = 1 << 0
                }

            }
        }

        [TagStructure(Size = 0xA4, MaxVersion = CacheVersion.Halo3Retail)]
        [TagStructure(Size = 0xBC, MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0xD0, MinVersion = CacheVersion.HaloReach)]
        public class ShotBlock : TagStructure
        {
            public byte[] ImportScriptHeader;
            public ShotFlags Flags;
            public float EnvironmentDarken;
            public float ForcedExposure;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public short MaximumLookAngleT;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public short MaximumLookAngleL;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public short MaximumLookAngleB;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public short MaximumLookAngleR;

            public List<LightingBlock> Lighting;
            public List<ClipBlock> Clips;
            public List<DialogueBlock> Dialogue;
            public List<MusicBlock> Music;
            public List<EffectBlock> Effects;
            public List<FunctionBlock> Functions;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public List<ScreenEffectBlock> ScreenEffects;

            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public List<CortanaEffectBlock> CortanaEffects;

            public List<ImportScriptBlock> ImportScripts;

            [TagField(MinVersion = CacheVersion.Halo3ODST)]
            public List<UserInputConstraintsBlock> UserInputConstraints;

            public byte[] ImportScriptFooter;
            public int FrameCount;
            public List<CameraFrame> CameraFrames;

            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<DynamicFrameDataBlock> DynamicFrameData;
            [TagField(MinVersion = CacheVersion.HaloReach)]
            public List<ConstantFrameDataBlock> ConstantFrameData;

            [Flags]
            public enum ShotFlags : int
            {
                None = 0,
                InstantAutoExposure = 1 << 0,
                ForceExposure = 1 << 1,
                GenerateLoopingScript = 1 << 2
            }

            [TagStructure(Size = 0x18, MaxVersion = CacheVersion.Halo3Retail)]
            [TagStructure(Size = 0x1C, MinVersion = CacheVersion.Halo3ODST)]
            public class LightingBlock : TagStructure
            {
                [TagField(MinVersion = CacheVersion.Halo3ODST)]
                public LightingFlags Flags;
                [TagField(Flags = Label)]
                public CachedTag CinematicLight;
                public int ObjectIndex;
                public StringId Marker;

                [Flags]
                public enum LightingFlags : int
                {
                    None = 0,
                    PersistsAcrossShots = 1 << 0
                }
            }

            [TagStructure(Size = 0x14)]
            public class UserInputConstraintsBlock : TagStructure
            {
                public int Frame;
                public int Ticks;
                public Rectangle2d MaximumLookAngles;
                public float FrictionalForce;
            }

            [TagStructure(Size = 0x2C)]
            public class ClipBlock : TagStructure
            {
                public RealPoint3d PlaneCenter;
                public RealPoint3d PlaneDirection;
                public uint FrameStart;
                public uint FrameEnd;

                public List<ClipObject> Objects;

                [TagStructure(Size = 0x4)]
                public class ClipObject : TagStructure
                {
                    public uint ObjectIndex;
                }
            }

            [TagStructure(Size = 0x24, MaxVersion = CacheVersion.Eldorado700123)]
            [TagStructure(Size = 0x3C, MinVersion = CacheVersion.HaloReach)]
            public class DialogueBlock : TagStructure
            {
                [TagField(Flags = Label)]
                public CachedTag Dialogue;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public CachedTag FemaleDialogue;
                public int Frame;
                public float Scale;
                public StringId LipsyncActor;
                public StringId DefaultSoundEffect;
                public StringId Subtitle;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public StringId FemaleSubtitle;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public StringId Character;
            }

            [TagStructure(Size = 0x18)]
            public class MusicBlock : TagStructure
            {
                public MusicFlags Flags;
                [TagField(Flags = Label)]
                public CachedTag Sound;
                public int Frame;

                [Flags]
                public enum MusicFlags : int
                {
                    None = 0,
                    StopMusicAtFrameRatherThanStartingIt = 1 << 0
                }
            }

            [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.Eldorado700123)]
            [TagStructure(Size = 0x28, MinVersion = CacheVersion.HaloReach)]
            public class EffectBlock : TagStructure
            {
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public CinematicShotEffectFlags Flags;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public SceneshotEffectState State;
                [TagField(MinVersion = CacheVersion.HaloReach, Length = 0x2, Flags = Padding)]
                public byte[] Pad;

                [TagField(Flags = Label)]
                public CachedTag Effect;
                public int Frame;
                public StringId Marker;
                public int MarkerParentIndex;

                [TagField(MinVersion = CacheVersion.HaloReach)]
                public StringId FunctionA;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public StringId FunctionB;

                [Flags]
                public enum CinematicShotEffectFlags : byte
                {
                    UseMayaValue = 1 << 0,
                    Looping = 1 << 1
                }

                public enum SceneshotEffectState : byte
                {
                    Start,
                    Stop,
                    Kill
                }
            }

            [TagStructure(Size = 0x14)]
            public class FunctionBlock : TagStructure
            {
                public int ObjectIndex;
                [TagField(Flags = Label)]
                public StringId TargetFunctionName;
                public List<KeyFrame> KeyFrames;

                [TagStructure(Size = 0x10)]
                public class KeyFrame : TagStructure
                {
                    public KeyFrameFlags Flags;
                    [Flags]
                    public enum KeyFrameFlags : int
                    {
                        None = 0,
                        ClearFunction = 1 << 0
                    }

                    public int Frame;
                    public float Value;
                    public float InterpolationTime;
                }
            }

            [TagStructure(Size = 0x18)]
            public class ScreenEffectBlock : TagStructure
            {
                [TagField(Flags = Label)]
                public CachedTag ScreenEffect;
                public int StartFrame;
                public int StopFrame;
            }

            [TagStructure(Size = 0x14)]
            public class CortanaEffectBlock : TagStructure
            {
                [TagField(Flags = Label)]
                public CachedTag CortanaEffect;
                public uint Frame;
            }

            [TagStructure(Size = 0x18, MaxVersion = CacheVersion.Eldorado700123)]
            [TagStructure(Size = 0x24, MinVersion = CacheVersion.HaloReach)]
            public class ImportScriptBlock : TagStructure
            {
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public ImportScriptFlags Flags;
                [TagField(MinVersion = CacheVersion.HaloReach, Length = 0x3, Flags = Padding)]
                public byte[] Pad;

                public int Frame;
                public byte[] ImportScript;

                [TagField(MinVersion = CacheVersion.HaloReach)]
                public int NodeID;
                [TagField(MinVersion = CacheVersion.HaloReach)]
                public int SequenceID;

                [Flags]
                public enum ImportScriptFlags : byte
                {
                    UseMayaValue = 1 << 0
                }
            }

            [TagStructure(Size = 0x24)]
            public class DynamicFrameDataBlock : TagStructure
            {
                public RealPoint3d CameraPosition;
                public RealVector3d CameraForward;
                public RealVector3d CameraUp;
            }

            [TagStructure(Size = 0x1C)]
            public class ConstantFrameDataBlock : TagStructure
            {
                public uint FrameIndex;
                public float FocalLength;
                public DepthOfFieldFlags Flags;
                public float NearFocalPlaneDistance;
                public float FarFocalPlaneDistance;
                public float FocalDepth;
                public float BlurAmount;
            }
        }

        [TagStructure(Size = 0x14)]
        public class ExtraCameraFrameDataBlock : TagStructure
        {
            [TagField(Flags = Label)]
            public StringId Name;
            public StringId Type;
            public List<CameraShotBlock> Shots;

            [TagStructure(Size = 0xC)]
            public class CameraShotBlock : TagStructure
            {
                public List<FrameBlock> Frames;

                [TagStructure(Size = 0x48, MaxVersion = CacheVersion.Eldorado700123)]
                [TagStructure(Size = 0x40, MinVersion = CacheVersion.HaloReach)]
                public class FrameBlock : TagStructure
                {
                    public CinematicExtraCameraFrameFlags Flags;
                    public CameraFrame CameraFrame;

                    [Flags]
                    public enum CinematicExtraCameraFrameFlags : uint
                    {
                        Enabled = 1 << 0
                    }
                }
            }
        }

        [TagStructure(Size = 0x44, MaxVersion = CacheVersion.Eldorado700123)]
        [TagStructure(Size = 0x3C, MinVersion = CacheVersion.HaloReach)]
        public class CameraFrame : TagStructure
        {
            public RealPoint3d CameraPosition;
            public RealVector3d CameraForward;
            public RealVector3d CameraUp;

            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public float HorizontalFieldOfView;
            [TagField(MaxVersion = CacheVersion.Eldorado700123)]
            public float HorizontalFilmAperture;

            public float FocalLength;
            public DepthOfFieldFlags Flags;
            public float NearFocalPlaneDistance;
            public float FarFocalPlaneDistance;
            public float FocalDepth;
            public float BlurAmount;
        }

        [Flags]
        public enum DepthOfFieldFlags : int
        {
            None,
            EnableDepthOfField = 1 << 0
        }
    }
}