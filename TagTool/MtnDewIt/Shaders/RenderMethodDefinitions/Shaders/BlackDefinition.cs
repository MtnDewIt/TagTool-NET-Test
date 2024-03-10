using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using System.Collections.Generic;
using TagTool.Common;
using TagTool.Shaders;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders
{
    public class BlackDefinition : RenderMethodData
    {
        public BlackDefinition(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = Cache.TagCache.GetTag<RenderMethodDefinition>($@"shaders\black");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(Stream, tag);
            rmdf.GlobalOptions = Cache.TagCache.GetTag<RenderMethodOption>($@"shaders\shader_options\global_shader_options");
            rmdf.Categories = new List<RenderMethodDefinition.CategoryBlock>
            {
                new RenderMethodDefinition.CategoryBlock
                {
                    Name = CacheContext.StringTable.GetStringId($@"blackness(no_options)"),
                    ShaderOptions = null,
                    VertexFunction = StringId.Invalid,
                    PixelFunction = StringId.Invalid,
                },
            };
            rmdf.EntryPoints = new List<RenderMethodDefinition.EntryPointBlock>
            {
                new RenderMethodDefinition.EntryPointBlock
                {
                    EntryPoint = EntryPoint_32.Albedo,
                    Passes = new List<RenderMethodDefinition.EntryPointBlock.PassBlock>
                    {
                        new RenderMethodDefinition.EntryPointBlock.PassBlock
                        {
                            Flags = RenderMethodDefinition.EntryPointBlock.PassBlock.PassFlags.None,
                            CategoryDependencies = null,
                        },
                    },
                },
            };
            rmdf.VertexTypes = new List<RenderMethodDefinition.VertexBlock>
            {
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.World,
                    Dependencies = null,
                },
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.Rigid,
                    Dependencies = null,
                },
                new RenderMethodDefinition.VertexBlock
                {
                    VertexType = RenderMethodDefinition.VertexBlock.VertexTypeValue.Skinned,
                    Dependencies = null,
                },
            };
            rmdf.GlobalPixelShader = Cache.TagCache.GetTag<GlobalPixelShader>($@"shaders\black_shared_pixel_shaders");
            rmdf.GlobalVertexShader = Cache.TagCache.GetTag<GlobalVertexShader>($@"shaders\black_shared_vertex_shaders");
            rmdf.Flags = RenderMethodDefinition.RenderMethodDefinitionFlags.UseAutomaticMacros;
            rmdf.Version = 0;

            CacheContext.Serialize(Stream, tag, rmdf);
        }
    }
}