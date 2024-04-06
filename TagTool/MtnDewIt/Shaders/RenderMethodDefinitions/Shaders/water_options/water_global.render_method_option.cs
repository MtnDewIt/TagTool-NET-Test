using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class shaders_water_options_water_global_render_method_option : RenderMethodData
    {
        public shaders_water_options_water_global_render_method_option(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\water_options\water_global");
            var rmop = CacheContext.Deserialize<RenderMethodOption>(Stream, tag);
            rmop.Parameters = new List<RenderMethodOption.ParameterBlock>
            {
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"water_memory_export_addr"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Color,
                    RenderMethodExtern = RenderMethodExtern.water_memory_export_address,
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
                    Name = CacheContext.StringTable.GetOrAddString($@"scene_ldr_texture"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Bitmap,
                    RenderMethodExtern = RenderMethodExtern.scene_ldr_texture,
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
                    Name = CacheContext.StringTable.GetOrAddString($@"scene_hdr_texture"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Bitmap,
                    RenderMethodExtern = RenderMethodExtern.scene_hdr_texture,
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
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Bilinear,
                    DefaultAddressMode = RenderMethodOption.ParameterBlock.DefaultAddressModeValue.Wrap,
                    AnisotropyAmount = 0,
                    DefaultColor = new ArgbColor(0, 0, 0, 0),
                    DefaultBitmapScale = 0f,
                    HelpText = null,
                },
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"lightprobe_texture_array"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Bitmap,
                    RenderMethodExtern = RenderMethodExtern.texture_lightprobe_texture,
                    DefaultSamplerBitmap = null,
                    DefaultFloatArgument = 0f,
                    DefaultIntBoolArgument = 0,
                    Flags = 0,
                    DefaultFilterMode = RenderMethodOption.ParameterBlock.DefaultFilterModeValue.Bilinear,
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
