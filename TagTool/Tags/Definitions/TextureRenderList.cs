using TagTool.Cache;
using TagTool.Common;
using System.Collections.Generic;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "texture_render_list", Tag = "trdf", Size = 0x48, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado235640)]
    [TagStructure(Name = "texture_render_list", Tag = "trdf", Size = 0x3C, MinVersion = CacheVersion.Eldorado301003, MaxVersion = CacheVersion.Eldorado604673)]
    [TagStructure(Name = "texture_render_list", Tag = "trdf", Size = 0x60, MinVersion = CacheVersion.Eldorado700123, MaxVersion = CacheVersion.Eldorado700123)]
    public class TextureRenderList : TagStructure
	{
        public List<TextureRenderBitmap> Bitmaps;
        public List<TextureRenderLight> Lights;
        [TagField(MinVersion = CacheVersion.Eldorado700123)]
        public List<TextureRenderUnknown1> Unknown1;
        [TagField(MinVersion = CacheVersion.Eldorado700123)]
        public List<TextureRenderUnknown2> Unknown2;
        [TagField(MinVersion = CacheVersion.Eldorado700123)]
        public List<TextureRenderUnknown3> Unknown3;
        public List<TextureRenderVideo> Videos;
        public List<TextureRenderMannequin> Mannequins;
        public List<TextureRenderWeapon> Weapons;
        [TagField(MaxVersion = CacheVersion.Eldorado235640)]
        public uint Unknown4;
        [TagField(MaxVersion = CacheVersion.Eldorado235640)]
        public uint Unknown5;
        [TagField(MaxVersion = CacheVersion.Eldorado235640)]
        public uint Unknown6;

        [TagStructure(Size = 0x110, MaxVersion = CacheVersion.Eldorado604673)]
        [TagStructure(Size = 0x108, MinVersion = CacheVersion.Eldorado700123)]
        public class TextureRenderBitmap : TagStructure
		{
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public int Index;
            [TagField(Length = 256)] 
            public string Filename;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public int Unknown;
            public int Width;
            public int Height;
        }

        [TagStructure(Size = 0x1C, MaxVersion = CacheVersion.Eldorado604673)]
        [TagStructure(Size = 0x3C, MinVersion = CacheVersion.Eldorado700123)]
        public class TextureRenderLight : TagStructure
		{
            public List<TextureRenderLightInstance> LightInstances;

            public RealRgbColor Color;
            public float Intensity;

            [TagField(Length = 32, MinVersion = CacheVersion.Eldorado700123)]
            public string Name;

            [TagStructure(Size = 0x28)]
            public class TextureRenderLightInstance : TagStructure
			{
                public RealPoint3d Position;
                public RealEulerAngles3d Orientation;
                public CachedTag Light;
            }
        }

        [TagStructure(Size = 0x34, MinVersion = CacheVersion.Eldorado700123)]
        public class TextureRenderUnknown1 : TagStructure 
        {
            public int Unknown1;
            public RealPoint3d Unknown2;
            public RealPoint3d Unknown3;
            public RealPoint3d Unknown4;
            public RealPoint3d Unknown5;
        }

        [TagStructure(Size = 0x24, MinVersion = CacheVersion.Eldorado700123)]
        public class TextureRenderUnknown2 : TagStructure
        {
            public int Unknown1;
            public float Unknown2;
            public RealEulerAngles3d Unknown3;
            public int Unknown4;
            public int Unknown5;
            public int Unknown6;
            public int Unknown7;
        }

        [TagStructure(Size = 0x30, MinVersion = CacheVersion.Eldorado700123)]
        public class TextureRenderUnknown3 : TagStructure
        {
            [TagField(Length = 32)]
            public string Name;
            public int Unknown1;
            public int Unknown2;
            public int Unknown3;
            public int Unknown4;
        }

        [TagStructure(Size = 0x30)]
        public class TextureRenderVideo : TagStructure
		{
            [TagField(Length = 32)] 
            public string Name;
            public CachedTag BinkVideo;
        }

        [TagStructure(Size = 0x4C, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado155080)]
        [TagStructure(Size = 0x5C, MinVersion = CacheVersion.Eldorado235640, MaxVersion = CacheVersion.Eldorado604673)]
        [TagStructure(Size = 0x20, MinVersion = CacheVersion.Eldorado700123)]
        public class TextureRenderMannequin : TagStructure
		{
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public int BitmapBlockIndex;
            [TagField(MinVersion = CacheVersion.Eldorado235640, MaxVersion = CacheVersion.Eldorado604673)]
            public int Unknown1;
            public CachedTag Biped;
            [TagField(MinVersion = CacheVersion.Eldorado235640, MaxVersion = CacheVersion.Eldorado604673)]
            public CachedTag Animation;

            [TagField(MinVersion = CacheVersion.Eldorado700123, MaxVersion = CacheVersion.Eldorado700123)]
            public int Unknown2;

            [TagField(MinVersion = CacheVersion.Eldorado700123, MaxVersion = CacheVersion.Eldorado700123)]
            public List<TextureRenderAnimation> Animations;

            [TagField(MaxVersion = CacheVersion.Eldorado155080)]
            public MannequinFlags Flags;

            [TagField(Length = 0x3, Flags = TagFieldFlags.Padding, MaxVersion = CacheVersion.Eldorado155080)]
            public byte[] Padding;

            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public RealVector3d Unknown3;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public RealVector3d Unknown4;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public RealVector3d Unknown5;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public RealVector3d Unknown6;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public float FieldOfView;

            public enum MannequinFlags : byte 
            {
                None = 0,
                Bit1 = 1 << 0,
            }
        }

        [TagStructure(Size = 0x64, MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado235640)]
        [TagStructure(Size = 0x84, MinVersion = CacheVersion.Eldorado301003, MaxVersion = CacheVersion.Eldorado449175)]
        [TagStructure(Size = 0x94, MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado604673)]
        [TagStructure(Size = 0x40, MinVersion = CacheVersion.Eldorado700123)]
        public class TextureRenderWeapon : TagStructure
		{
            [TagField(Length = 32)]
            public string Name;
            [TagField(Length = 32, MinVersion = CacheVersion.Eldorado498295, MaxVersion = CacheVersion.Eldorado604673)]
            public string Unknown1;

            [TagField(MinVersion = CacheVersion.EldoradoED, MaxVersion = CacheVersion.Eldorado449175)]
            [TagField(MinVersion = CacheVersion.Eldorado700123)]
            public CachedTag Weapon;

            [TagField(MinVersion = CacheVersion.Eldorado700123)]
            public int Unknown2;

            [TagField(MinVersion = CacheVersion.Eldorado700123)]
            public List<TextureRenderAnimation> Animations;

            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public RealVector3d Unknown3;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public RealVector3d Unknown4;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public RealVector3d Unknown5;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public RealVector3d Unknown6;
            [TagField(MaxVersion = CacheVersion.Eldorado604673)]
            public float FieldOfView;

            [TagField(MinVersion = CacheVersion.Eldorado301003, MaxVersion = CacheVersion.Eldorado604673)]
            public int Unknown7;
            [TagField(MinVersion = CacheVersion.Eldorado301003, MaxVersion = CacheVersion.Eldorado604673)]
            public RealEulerAngles3d Unknown8;
            [TagField(MinVersion = CacheVersion.Eldorado301003, MaxVersion = CacheVersion.Eldorado604673)]
            public RealPoint3d Unknown9;
            [TagField(MinVersion = CacheVersion.Eldorado301003, MaxVersion = CacheVersion.Eldorado604673)]
            public float Unknown10;
        }

        [TagStructure(Size = 0x34)]
        public class TextureRenderAnimation : TagStructure
        {
            [TagField(Length = 32)]
            public string Name;
            public int Unknown1;
            public CachedTag Animation;
        }
    }
}