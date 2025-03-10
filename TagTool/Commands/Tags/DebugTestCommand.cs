using System.Collections.Generic;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.JSON.Objects;
using TagTool.JSON.Handlers;
using TagTool.Tags.Definitions;
using TagTool.Common;
using TagTool.Tags;
using TagTool.Commands.Common;
using System;
using System.IO;
using TagTool.IO;
using TagTool.BlamFile;
using Newtonsoft.Json;
using TagTool.BlamFile.MCC;
using System.Linq;
using TagTool.Shaders.ShaderGenerator;
using HaloShaderGenerator.Globals;

namespace TagTool.Commands.Tags
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnlineBase CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnlineBase cacheContext, CommandContextStack contextStack) : base
        (
            false,
            "DebugTest",
            "Self Explanatory",

            "DebugTest",
            "Self Explanatory"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                GenerateRenderMethodDefinition(stream, "beam");
                GenerateRenderMethodDefinition(stream, "black");
                GenerateRenderMethodDefinition(stream, "contrail");
                GenerateRenderMethodDefinition(stream, "cortana");
                GenerateRenderMethodDefinition(stream, "custom");
                GenerateRenderMethodDefinition(stream, "decal");
                GenerateRenderMethodDefinition(stream, "foliage");
                GenerateRenderMethodDefinition(stream, "fur");
                GenerateRenderMethodDefinition(stream, "fur_stencil");
                GenerateRenderMethodDefinition(stream, "glass");
                GenerateRenderMethodDefinition(stream, "halogram");
                GenerateRenderMethodDefinition(stream, "light_volume");
                GenerateRenderMethodDefinition(stream, "mux");
                GenerateRenderMethodDefinition(stream, "particle");
                GenerateRenderMethodDefinition(stream, "screen");
                GenerateRenderMethodDefinition(stream, "shader");
                GenerateRenderMethodDefinition(stream, "terrain");
                GenerateRenderMethodDefinition(stream, "water");
                GenerateRenderMethodDefinition(stream, "zonly");

                CacheContext.SaveStrings();
                CacheContext.SaveTagNames();

                GenerateGlobalShader(stream, ShaderType.Beam);
                GenerateGlobalShader(stream, ShaderType.Black);
                GenerateGlobalShader(stream, ShaderType.Contrail);
                GenerateGlobalShader(stream, ShaderType.Cortana);
                GenerateGlobalShader(stream, ShaderType.Custom);
                GenerateGlobalShader(stream, ShaderType.Decal);
                GenerateGlobalShader(stream, ShaderType.Foliage);
                GenerateGlobalShader(stream, ShaderType.Fur);
                GenerateGlobalShader(stream, ShaderType.FurStencil);
                GenerateGlobalShader(stream, ShaderType.Glass);
                GenerateGlobalShader(stream, ShaderType.Halogram);
                GenerateGlobalShader(stream, ShaderType.LightVolume);
                GenerateGlobalShader(stream, ShaderType.Mux);
                GenerateGlobalShader(stream, ShaderType.Particle);
                GenerateGlobalShader(stream, ShaderType.Screen);
                GenerateGlobalShader(stream, ShaderType.Shader); // issues with misc_attr_animation (We ran out of output registers :/)
                GenerateGlobalShader(stream, ShaderType.Terrain);
                GenerateGlobalShader(stream, ShaderType.Water);
                GenerateGlobalShader(stream, ShaderType.ZOnly);

                CacheContext.SaveStrings();

                foreach (var tag in Cache.TagCache.FindAllInGroup("rmdf")) 
                {
                    var rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, tag);

                    for (int i = 0; i < rmdf.Categories.Count; i++) 
                    {
                        if (rmdf.Categories[i].ShaderOptions.Count == 0) 
                        {
                            var options = new byte[rmdf.Categories.Count];

                            Console.WriteLine($"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}");

                            //var rmt2Name = $"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}";
                            //var rmt2 = ShaderGeneratorNew.GenerateTemplateSafe(Cache, stream, rmdf, rmt2Name, out _, out _);
                            //var rmt2Tag = Cache.TagCache.AllocateTag<RenderMethodTemplate>(rmt2Name);
                            //Cache.Serialize(stream, rmt2Tag, rmt2);
                        }
                        else
                        {
                            for (int j = 0; j < rmdf.Categories[i].ShaderOptions.Count; j++)
                            {
                                var options = new byte[rmdf.Categories.Count];

                                options[i] = (byte)j;

                                Console.WriteLine($"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}");

                                //var rmt2Name = $"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}";
                                //var rmt2 = ShaderGeneratorNew.GenerateTemplateSafe(Cache, stream, rmdf, rmt2Name, out _, out _);
                                //var rmt2Tag = Cache.TagCache.AllocateTag<RenderMethodTemplate>(rmt2Name);
                                //Cache.Serialize(stream, rmt2Tag, rmt2);
                            }
                        }
                    }
                }
            }

            return true;

            void GenerateRenderMethodDefinition(Stream stream, string shaderType)
            {
                string rmdfName = $"shaders\\{shaderType}";

                var generator = ShaderGenerator.GetGlobalShaderGenerator(shaderType, true);

                if (!Cache.TagCache.TryGetTag<RenderMethodDefinition>(rmdfName, out CachedTag rmdfTag))
                {
                    rmdfTag = Cache.TagCache.AllocateTag<RenderMethodDefinition>(rmdfName);
                }

                var rmdf = RenderMethodDefinitionGenerator.GenerateRenderMethodDefinition(Cache, stream, generator, shaderType, out _, out _);

                Cache.Serialize(stream, rmdfTag, rmdf);
            }

            void GenerateGlobalShader(Stream stream, ShaderType shader, bool applyFixes = true)
            {
                string shaderName = shader.ToString().ToLowerInvariant();
                string rmdfName = shaderName == "lightvolume" ? "shaders\\light_volume" : $"shaders\\{shaderName}";
                rmdfName = shaderName == "furstencil" ? "shaders\\fur_stencil" : rmdfName;

                CachedTag rmdfTag = Cache.TagCache.GetTag<RenderMethodDefinition>(rmdfName);
                RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

                GlobalPixelShader glps = ShaderGeneratorNew.GenerateSharedPixelShaders(Cache, rmdf, shader, applyFixes);
                GlobalVertexShader glvs = ShaderGeneratorNew.GenerateSharedVertexShaders(Cache, rmdf, shader, applyFixes);

                Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
                Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
            }
        }
    }
}
