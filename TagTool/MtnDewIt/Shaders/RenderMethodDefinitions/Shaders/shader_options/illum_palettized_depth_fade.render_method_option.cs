using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class shaders_shader_options_illum_palettized_depth_fade_render_method_option : RenderMethodData
    {
        public shaders_shader_options_illum_palettized_depth_fade_render_method_option(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            RenderMethod();
        }

        public override void RenderMethod()
        {
            var tag = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\illum_palettized_depth_fade");
            var rmop = CacheContext.Deserialize<RenderMethodOption>(Stream, tag);
            rmop.Parameters = new List<RenderMethodOption.ParameterBlock>
            {
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"noise_map_a"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Bitmap,
                    RenderMethodExtern = RenderMethodExtern.none,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"palette"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Bitmap,
                    RenderMethodExtern = RenderMethodExtern.none,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"alpha_mask_map"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Bitmap,
                    RenderMethodExtern = RenderMethodExtern.none,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"alpha_modulation_factor"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Real,
                    RenderMethodExtern = RenderMethodExtern.none,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"depth_buffer"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Bitmap,
                    RenderMethodExtern = RenderMethodExtern.texture_global_target_z,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"depth_fade_range"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Real,
                    RenderMethodExtern = RenderMethodExtern.none,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"self_illum_color"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Color,
                    RenderMethodExtern = RenderMethodExtern.none,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"self_illum_intensity"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Real,
                    RenderMethodExtern = RenderMethodExtern.none,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"v_coordinate"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Real,
                    RenderMethodExtern = RenderMethodExtern.none,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"global_depth_constants"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Real,
                    RenderMethodExtern = RenderMethodExtern.global_depth_constants,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"global_camera_forward"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Real,
                    RenderMethodExtern = RenderMethodExtern.global_camera_forward,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Trilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
            };

            CacheContext.Serialize(Stream, tag, rmop);
        }
    }
}
