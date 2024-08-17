using HaloShaderGenerator.Globals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.MtnDewIt.JSON;
using TagTool.MtnDewIt.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands
{
    class UpdateShaderDataCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }

        public static List<string> TagObjectList;

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
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var tagParser = new TagObjectParser(Cache, CacheContext, stream);
                
                var jsonData = File.ReadAllText($@"{Program.TagToolDirectory}\Tools\JSON\commands\updateshaderdata\tags.json");
                TagObjectList = JsonConvert.DeserializeObject<List<string>>(jsonData);
                
                foreach (var file in TagObjectList)
                    tagParser.ParseFile($@"{Program.TagToolDirectory}\Tools\JSON\tags\{file}");

                // TODO: Create separate lists for types which don't requires the APPLY_FIXES macro
                // TODO: Create a better system for checking whether or not an enum value is actually a valid shader (Looking at you Glass and ShadowApply2)
                // TODO: Maybe modify the shader generation functions so they just take the type as an input, instead of a string :/

                // May not be all that useful, but here is the approximate time taken for this whole function to run. The time taken did go up after redoing the shader compile code for some reason :/
                // Given that the total time taken to generate a cache using the current system varies by around 4 - 15 seconds on average from run to run, these measurements are within
                // the margin of error. Once most of the issues with the JSON Deserializer have been ironed out, the speed of this function should increase slightly. So long as the total
                // elapsed time remains within the margin of error, it is acceptable :/ 

                // NEW - JUST JSON 
                // Elapsed time: 62643022800 nanoseconds

                // NEW - JSON + NEW COMPILE LOOPS
                // Elapsed time: 62733337800 nanoseconds : 90315000ns slower (0.090315 seconds)

                // OLD - C# OBJECTS
                // Elapsed time: 61286682300 nanoseconds : 1356340500ns faster (1.3563405 seconds)

                foreach (ShaderType shaderType in Enum.GetValues(typeof(ShaderType)))
                    if (shaderType != ShaderType.Glass)
                        GenerateGlobalShaders(stream, shaderType.ToString().ToLower(), 
                            shaderType == ShaderType.Foliage || 
                            shaderType == ShaderType.Water ? false : true);

                foreach (ChudShader chudShader in Enum.GetValues(typeof(ChudShader)))
                    GenerateChudShader(stream, chudShader.ToString().ToLower(), 
                        chudShader == ChudShader.chud_cortana_composite || 
                        chudShader == ChudShader.chud_meter_shield || 
                        chudShader == ChudShader.chud_simple || 
                        chudShader == ChudShader.chud_text_simple ? false : true);

                foreach (ExplicitShader explicitShader in Enum.GetValues(typeof(ExplicitShader)))
                    if (explicitShader != ExplicitShader.shadow_apply2)
                        GenerateExplicitShader(stream, explicitShader.ToString().ToLower(),
                            explicitShader == ExplicitShader.blur_11_horizontal ||
                            explicitShader == ExplicitShader.blur_11_vertical ||
                            explicitShader == ExplicitShader.double_gradient ||
                            explicitShader == ExplicitShader.gradient ||
                            explicitShader == ExplicitShader.kernel_5 ||
                            explicitShader == ExplicitShader.patchy_fog ||
                            explicitShader == ExplicitShader.screenshot_combine ||
                            explicitShader == ExplicitShader.screenshot_combine_dof ? false : true);

                stopwatch.Stop();
                long ticks = stopwatch.ElapsedTicks;
                long nanoseconds = ticks * (1000000000L / Stopwatch.Frequency);
                Console.WriteLine($"Elapsed time: {nanoseconds} nanoseconds");
            }
        }

        public void GenerateGlobalShaders(Stream stream, string shaderType, bool applyFixes = true)
        {
            var type = (HaloShaderGenerator.Globals.ShaderType)Enum.Parse(typeof(HaloShaderGenerator.Globals.ShaderType), shaderType, true);

            CachedTag rmdfTag = Cache.TagCache.GetTag<RenderMethodDefinition>(shaderType == "lightvolume" ? "shaders\\light_volume" : $"shaders\\{shaderType}");

            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            GlobalPixelShader glps = InlineShaderGenerator.GenerateSharedPixelShaders(Cache, rmdf, type, applyFixes);
            GlobalVertexShader glvs = InlineShaderGenerator.GenerateSharedVertexShaders(Cache, rmdf, type, applyFixes);

            Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
        }

        public void GenerateExplicitShader(Stream stream, string shader, bool applyFixes = true)
        {
            var type = (HaloShaderGenerator.Globals.ExplicitShader)Enum.Parse(typeof(HaloShaderGenerator.Globals.ExplicitShader), shader, true);

            CachedTag pixlTag = Cache.TagCache.GetTag<PixelShader>($"rasterizer\\shaders\\{type}") ?? Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{type}");
            CachedTag vtshTag = Cache.TagCache.GetTag<VertexShader>($"rasterizer\\shaders\\{type}") ?? Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{type}");

            InlineShaderGenerator.GenerateExplicitShader(Cache, type.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }

        public void GenerateChudShader(Stream stream, string shader, bool applyFixes = true)
        {
            var type = (HaloShaderGenerator.Globals.ChudShader)Enum.Parse(typeof(HaloShaderGenerator.Globals.ChudShader), shader, true);

            CachedTag pixlTag = Cache.TagCache.GetTag<PixelShader>($"rasterizer\\shaders\\{type}") ?? Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{type}");
            CachedTag vtshTag = Cache.TagCache.GetTag<VertexShader>($"rasterizer\\shaders\\{type}") ?? Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{type}");

            InlineShaderGenerator.GenerateChudShader(Cache, type.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);
        }
    }
}