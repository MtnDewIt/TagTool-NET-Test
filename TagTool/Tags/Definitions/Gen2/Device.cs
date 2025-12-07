using System;
using System.Collections.Generic;
using System.Text;
using TagTool.Cache;

namespace TagTool.Tags.Definitions.Gen2
{
    [TagStructure(Name = "device", Tag = "devi", Size = 0x11C)]
    public class Device : GameObject
    {
        public FlagsValue1 Flags1;
        public float PowerTransitionTime; // seconds
        public float PowerAccelerationTime; // seconds
        public float PositionTransitionTime; // seconds
        public float PositionAccelerationTime; // seconds
        public float DepoweredPositionTransitionTime; // seconds
        public float DepoweredPositionAccelerationTime; // seconds
        public LightmapFlagsValue LightmapFlags;
        [TagField(Length = 0x2, Flags = TagFieldFlags.Padding)]
        public byte[] Padding4;
        [TagField(ValidTags = new[] { "snd!", "effe" })]
        public CachedTag OpenUp;
        [TagField(ValidTags = new[] { "snd!", "effe" })]
        public CachedTag CloseDown;
        [TagField(ValidTags = new[] { "snd!", "effe" })]
        public CachedTag Opened;
        [TagField(ValidTags = new[] { "snd!", "effe" })]
        public CachedTag Closed;
        [TagField(ValidTags = new[] { "snd!", "effe" })]
        public CachedTag Depowered;
        [TagField(ValidTags = new[] { "snd!", "effe" })]
        public CachedTag Repowered;
        public float DelayTime; // seconds
        [TagField(ValidTags = new[] { "snd!", "effe" })]
        public CachedTag DelayEffect;
        public float AutomaticActivationRadius; // world units

        [Flags]
        public enum FlagsValue1 : uint
        {
            PositionLoops = 1 << 0,
            Unused = 1 << 1,
            AllowInterpolation = 1 << 2
        }

        [Flags]
        public enum LightmapFlagsValue : ushort
        {
            DonTUseInLightmap = 1 << 0,
            DonTUseInLightprobe = 1 << 1
        }
    }
}
