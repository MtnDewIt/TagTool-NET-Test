using System;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Tags.Definitions
{
    [TagStructure(Name = "gui_bitmap_widget_definition", Tag = "bmp3", Size = 0x5C)]
    public class GuiBitmapWidgetDefinition : TagStructure
	{
        [TagField(MinVersion = CacheVersion.Halo3ODST)]
        public BitmapWidgetDefinitionFlags Flags;
        [TagField(MaxVersion = CacheVersion.Halo3Retail)]
        public BitmapWidgetDefinitionFlagsH3 FlagsH3;
        public GuiDefinition GuiRenderBlock;
        public CachedTag Bitmap;
        public CachedTag CustomPixelShader;
        public BlendMethodValue BlendMethod;
        public short InitialSpriteSequence;
        public short InitialSpriteFrame;
        [TagField(Length = 2, Flags = TagFieldFlags.Padding)]
        public byte[] BitmapWidgetDefinitionAlignmentPad;
        public StringId ValueOverrideList;
        public StringId ValueIdentifier;

        [Flags]
        public enum BitmapWidgetDefinitionFlags : uint
        {
            None = 0,
            DoNotApplyOldContentUpscaling = 1 << 0,
            OverrideTemplateFlags = 1 << 1,
            EnableAnimationDebugging = 1 << 2,
            ScaleToFitBounds = 1 << 3,
            RenderAsScreenBlur = 1 << 4,
            RenderAsPlayerEmblem = 1 << 5,
            SpriteFromExportedInteger = 1 << 6,
            SequenceFromExportedInteger = 1 << 7,
            AttachShaderToExportedInteger = 1 << 8,
            AllowListItemToOverrideAnimationSkin = 1 << 9,
            CanRecieveFocus = 1 << 10,
            ScaleHalf = 1 << 11,
            Stretch = 1 << 12,
        }

        [Flags]
        public enum BitmapWidgetDefinitionFlagsH3 : uint
        {
            None = 0,
            DoNotApplyOldContentUpscaling = 1 << 0,
            OverrideTemplateFlags = 1 << 1,
            EnableAnimationDebugging = 1 << 2,
            ScaleToFitBounds = 1 << 3,
            RenderAsScreenBlur = 1 << 4,
            RenderAsPlayerEmblem = 1 << 5,
            SpriteFromExportedInteger = 1 << 6,
            SequenceFromExportedInteger = 1 << 7,
            AttachShaderToExportedInteger = 1 << 8,
            AllowListItemToOverrideAnimationSkin = 1 << 9,
            Clickable = 1 << 10,
        }

        public enum BlendMethodValue : short
        {
            Opaque,
            Additive,
            Multiply,
            AlphaBlend,
            DoubleMultiply,
            PreMultipliedAlpha,
            Maximum,
            MultiplyAdd,
            AddSrcTimesDstalpha,
            AddSrcTimesSrcalpha,
            InverseAlphaBlend,
            MotionBlurStatic,
            MotionBlurInhibit,
            AddSrcTimesSrcalphaAlphaAccum
        }
    }
}