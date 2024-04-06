using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class shaders_shader_options_cortana_screenspace_render_method_option : RenderMethodData
    {
        public shaders_shader_options_cortana_screenspace_render_method_option(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\cortana_screenspace");
            var rmop = CacheContext.Deserialize<RenderMethodOption>(Stream, tag);
            rmop.Parameters = new List<RenderMethodOption.ParameterBlock>
            {
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"scanline_map"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"scanline_amount_opaque"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"scanline_amount_transparent"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"ss_constants"),
                    Type = RenderMethodOption.ParameterBlock.OptionDataType.Color,
                    RenderMethodExtern = RenderMethodExtern.screen_constants,
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
