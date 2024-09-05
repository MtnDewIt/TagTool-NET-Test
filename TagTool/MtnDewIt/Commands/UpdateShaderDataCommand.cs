using HaloShaderGenerator.Globals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.MtnDewIt.JSON.Parsers;
using TagTool.MtnDewIt.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands
{
    class UpdateShaderDataCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }

        public static List<string> TagObjectList;

        public static HashSet<ShaderType> noFixesShaders = new HashSet<ShaderType> 
        {
            ShaderType.Water,
            ShaderType.Foliage,
        };

        public static HashSet<ChudShader> noFixesChudShaders = new HashSet<ChudShader>
        {
            ChudShader.chud_simple,
            ChudShader.chud_text_simple,
            ChudShader.chud_meter_shield,
            ChudShader.chud_cortana_composite,
        };

        public static HashSet<ExplicitShader> noFixesExplicitShaders = new HashSet<ExplicitShader>
        {
            ExplicitShader.blur_11_horizontal,
            ExplicitShader.blur_11_vertical,
            ExplicitShader.screenshot_combine,
            ExplicitShader.kernel_5,
            ExplicitShader.screenshot_combine_dof,
            ExplicitShader.gradient,
            ExplicitShader.patchy_fog,
            ExplicitShader.double_gradient,
        };

        public UpdateShaderDataCommand(GameCache cache, GameCacheHaloOnline cacheContext) : base
        (
            true,
            "UpdateShaderData",
            "Updates Render Method Definitions To Include ElDewrito, and MCC Options",
            "UpdateShaderData",
            "Updates Render Method Definitions To Include ElDewrito, and MCC Options. Recompiles Global Pixel and Vertex Shaders"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
        }

        public override object Execute(List<string> args)
        {
            UpdateShaderData();

            return true;
        }

        public void UpdateShaderData()
        {            
            using (var stream = Cache.OpenCacheReadWrite())
            {
                var tagParser = new TagObjectParser(Cache, CacheContext, stream);
                
                var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\updateshaderdata\tags.json");
                TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);
                
                foreach (var file in TagObjectList)
                    tagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

                // Don't really know if I should use a cast when retrieving values, as while it does
                // improve type safety, I have no clue what impact it may have on performance

                foreach (ShaderType shaderType in Enum.GetValues(typeof(ShaderType))) 
                {
                    if (shaderType == ShaderType.Glass)
                        continue;

                    bool applyFixes = !noFixesShaders.Contains(shaderType);
                    GenerateGlobalShader(stream, shaderType, applyFixes);
                }

                foreach (ChudShader chudShader in Enum.GetValues(typeof(ChudShader))) 
                {
                    bool applyFixes = !noFixesChudShaders.Contains(chudShader);
                    GenerateChudShader(stream, chudShader, applyFixes); 
                }

                foreach (ExplicitShader explicitShader in Enum.GetValues(typeof(ExplicitShader))) 
                {
                    if (explicitShader == ExplicitShader.shadow_apply2)
                        continue;

                    bool applyFixes = !noFixesExplicitShaders.Contains(explicitShader);
                    GenerateExplicitShader(stream, explicitShader, applyFixes);
                }
            }
        }

        public void GenerateGlobalShader(Stream stream, ShaderType shader, bool applyFixes = true)
        {
            string shaderName = shader.ToString().ToLowerInvariant();
            string rmdfName = shaderName == "lightvolume" ? "shaders\\light_volume" : $"shaders\\{shaderName}";

            CachedTag rmdfTag = Cache.TagCache.GetTag<RenderMethodDefinition>(rmdfName);
            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            GlobalPixelShader glps = InlineShaderGenerator.GenerateSharedPixelShaders(Cache, rmdf, shader, applyFixes);
            GlobalVertexShader glvs = InlineShaderGenerator.GenerateSharedVertexShaders(Cache, rmdf, shader, applyFixes);

            Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
        }

        public void GenerateExplicitShader(Stream stream, ExplicitShader shader, bool applyFixes = true)
        {
            CachedTag pixlTag = Cache.TagCache.GetTag<PixelShader>($"rasterizer\\shaders\\{shader}") ?? Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");
            CachedTag vtshTag = Cache.TagCache.GetTag<VertexShader>($"rasterizer\\shaders\\{shader}") ?? Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            InlineShaderGenerator.GenerateExplicitShader(Cache, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }

        public void GenerateChudShader(Stream stream, ChudShader shader, bool applyFixes = true)
        {
            CachedTag pixlTag = Cache.TagCache.GetTag<PixelShader>($"rasterizer\\shaders\\{shader}") ?? Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");
            CachedTag vtshTag = Cache.TagCache.GetTag<VertexShader>($"rasterizer\\shaders\\{shader}") ?? Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            InlineShaderGenerator.GenerateChudShader(Cache, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }
    }
}