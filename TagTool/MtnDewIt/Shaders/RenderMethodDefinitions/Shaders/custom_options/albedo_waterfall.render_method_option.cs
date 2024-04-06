using System.Collections.Generic;
using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class shaders_custom_options_albedo_waterfall_render_method_option : RenderMethodData
    {
        public shaders_custom_options_albedo_waterfall_render_method_option(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\custom_options\albedo_waterfall");
            var rmop = CacheContext.Deserialize<RenderMethodOption>(Stream, tag);
            rmop.Parameters = new List<RenderMethodOption.ParameterBlock>
            {
                new RenderMethodOption.ParameterBlock
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"waterfall_base_mask"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"waterfall_layer0"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"waterfall_layer1"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"waterfall_layer2"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"transparency_frothy_weight"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"transparency_base_weight"),
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
                    Name = CacheContext.StringTable.GetOrAddString($@"transparency_bias"),
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
            };

            CacheContext.Serialize(Stream, tag, rmop);
        }
    }
}
