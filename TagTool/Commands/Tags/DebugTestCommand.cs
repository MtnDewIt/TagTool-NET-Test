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
using TagTool.Commands.Shaders;
using TagTool.Shaders.ShaderMatching;
using TagTool.Commands.JSON;

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
            HashSet<ShaderType> noFixesGlobalShaders = new HashSet<ShaderType>
            {
                ShaderType.Water,
                ShaderType.Foliage,
            };

            HashSet<ChudShader> noFixesChudShaders = new HashSet<ChudShader>
            {
                ChudShader.chud_simple,
                ChudShader.chud_text_simple,
                ChudShader.chud_meter_shield,
                ChudShader.chud_cortana_composite,
            };

            HashSet<ExplicitShader> noFixesExplicitShaders = new HashSet<ExplicitShader>
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

            using (var stream = Cache.OpenCacheReadWrite())
            {
                //SHADER UNIT TEST
                //1.Generate Render Method Definitions
                //2.Generate Global Shaders For Each Render Method Type

                foreach (ShaderType shaderType in Enum.GetValues(typeof(ShaderType)))
                {
                    bool applyFixes = !noFixesGlobalShaders.Contains(shaderType);

                    GenerateRenderMethodDefinition(stream, shaderType, applyFixes);
                }

                //3.Generate All Explicit Shaders and Chud Shaders

                var chgdTag = Cache.TagCache.AllocateTag<ChudGlobalsDefinition>($"ui\\chud\\globals");
                var chgd = new ChudGlobalsDefinition { HudShaders = new List<ChudGlobalsDefinition.HudShader>() };

                foreach (ChudShader chudShader in Enum.GetValues(typeof(ChudShader)))
                {
                    bool applyFixes = !noFixesChudShaders.Contains(chudShader);
                    GenerateChudShader(stream, chgd, chudShader, applyFixes);
                }

                Cache.Serialize(stream, chgdTag, chgd);

                var rasgTag = Cache.TagCache.AllocateTag<ChudGlobalsDefinition>($"globals\\rasterizer_globals");
                var rasg = new RasterizerGlobals { DefaultShaders = new List<RasterizerGlobals.ExplicitShader>() };

                foreach (ExplicitShader explicitShader in Enum.GetValues(typeof(ExplicitShader)))
                {
                    if (explicitShader == ExplicitShader.shadow_apply2)
                        continue;

                    bool applyFixes = !noFixesExplicitShaders.Contains(explicitShader);
                    GenerateExplicitShader(stream, rasg, explicitShader, applyFixes);
                }

                Cache.Serialize(stream, rasgTag, rasg);

                //4.Generate All Possible Templates For Each Category And Option
                //5.Maybe attempt to generate a shader for each render method type to ensure that all parameters are being referenced correctly

                foreach (ShaderType shaderType in Enum.GetValues(typeof(ShaderType)))
                {
                    TemplateUnitTest(stream, shaderType);
                }
            }

            //6.Disassemble Data For Each Explicit Shader, Chud Shader and Render Method Type

            new DumpDisassembledShadersCommand(Cache).Execute(new List<string> { "Current" });

            foreach (var tag in Cache.TagCache.NonNull())
            {
                if (tag.IsInGroup("rmdf"))
                {
                    new GenerateTagObjectCommand(Cache, Cache as GameCacheHaloOnline).Execute(new List<string> { $@"{tag.Name}.{tag.Group}", $@"Single", $@"MS23" });
                }
            }

            //7.Dump Diassembled Data from ED and MS23 (use as a comparision point to check if APPLY_FIXES functions correctly)

            var ms23Cache = GameCache.Open(new FileInfo(args[0]));

            new DumpDisassembledShadersCommand(ms23Cache).Execute(new List<string> { "MS23" });

            foreach (var tag in ms23Cache.TagCache.NonNull())
            {
                if (tag.IsInGroup("rmdf"))
                {
                    new GenerateTagObjectCommand(ms23Cache, ms23Cache as GameCacheHaloOnline).Execute(new List<string> { $@"{tag.Name}.{tag.Group}", $@"Single", $@"MS23" });
                }
            }

            var edCache = GameCache.Open(new FileInfo(args[1]));

            new DumpDisassembledShadersCommand(edCache).Execute(new List<string> { "ElDewrito" });

            foreach (var tag in edCache.TagCache.NonNull())
            {
                if (tag.IsInGroup("rmdf"))
                {
                    new GenerateTagObjectCommand(edCache, edCache as GameCacheHaloOnline).Execute(new List<string> { $@"{tag.Name}.{tag.Group}", $@"Single", $@"ElDewrito" });
                }
            }

            //We're gonna need to revert our changes :/
            //RESET ENTRY POINTS
            //REMOVE UNUSED FUNCTIONS
            //FOR ADDED REACH RENDER METHOD TYPES, REFERENCE GLASS IMPLEMENTATION TO FIX

            return true;
        }

        void GenerateRenderMethodDefinition(Stream stream, ShaderType shaderType, bool applyFixes = true)
        {
            string rmdfName = $"shaders\\{shaderType.ToString().ToLowerInvariant()}";

            switch (shaderType)
            {
                case ShaderType.LightVolume:
                    rmdfName = "shaders\\light_volume";
                    break;
                case ShaderType.FurStencil:
                    rmdfName = "shaders\\fur_stencil";
                    break;
            }

            var generator = ShaderGenerator.GetGlobalShaderGenerator(shaderType);

            if (!Cache.TagCache.TryGetTag<RenderMethodDefinition>(rmdfName, out CachedTag rmdfTag))
            {
                rmdfTag = Cache.TagCache.AllocateTag<RenderMethodDefinition>(rmdfName);
            }

            var rmdf = RenderMethodDefinitionGenerator.GenerateRenderMethodDefinition(Cache, stream, generator, shaderType, true, applyFixes);

            Cache.Serialize(stream, rmdfTag, rmdf);
        }

        public void GenerateExplicitShader(Stream stream, RasterizerGlobals rasg, ExplicitShader shader, bool applyFixes = true)
        {
            if (!Cache.TagCache.TryGetTag<PixelShader>($"rasterizer\\shaders\\{shader}", out CachedTag pixlTag))
                pixlTag = Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");

            if (!Cache.TagCache.TryGetTag<VertexShader>($"rasterizer\\shaders\\{shader}", out CachedTag vtshTag))
                vtshTag = Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            ShaderGeneratorNew.GenerateExplicitShader(Cache, stream, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);

            rasg.DefaultShaders.Add(new RasterizerGlobals.ExplicitShader { VertexShader = vtshTag, PixelShader = pixlTag });
        }

        public void GenerateChudShader(Stream stream, ChudGlobalsDefinition chgd, ChudShader shader, bool applyFixes = true)
        {
            if (!Cache.TagCache.TryGetTag<PixelShader>($"rasterizer\\shaders\\{shader}", out CachedTag pixlTag))
                pixlTag = Cache.TagCache.AllocateTag<PixelShader>($"rasterizer\\shaders\\{shader}");

            if (!Cache.TagCache.TryGetTag<VertexShader>($"rasterizer\\shaders\\{shader}", out CachedTag vtshTag))
                vtshTag = Cache.TagCache.AllocateTag<VertexShader>($"rasterizer\\shaders\\{shader}");

            ShaderGeneratorNew.GenerateChudShader(Cache, stream, shader.ToString(), applyFixes, out PixelShader pixl, out VertexShader vtsh);

            Cache.Serialize(stream, vtshTag, vtsh);
            Cache.Serialize(stream, pixlTag, pixl);

            chgd.HudShaders.Add(new ChudGlobalsDefinition.HudShader { VertexShader = vtshTag, PixelShader = pixlTag });
        }

        public void TemplateUnitTest(Stream stream, ShaderType shaderType)
        {
            string rmdfName = $"shaders\\{shaderType.ToString().ToLowerInvariant()}";

            switch (shaderType)
            {
                case ShaderType.LightVolume:
                    rmdfName = "shaders\\light_volume";
                    break;
                case ShaderType.FurStencil:
                    rmdfName = "shaders\\fur_stencil";
                    break;
            }

            var tag = Cache.TagCache.GetTag<RenderMethodDefinition>(rmdfName);
            var rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, tag);

            for (int i = 0; i < rmdf.Categories.Count; i++)
            {
                if (rmdf.Categories[i].ShaderOptions.Count == 0)
                {
                    var options = new byte[rmdf.Categories.Count];

                    Console.WriteLine($"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}");

                    var rmt2Name = $"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}";

                    try
                    {
                        var rmt2 = ShaderGeneratorNew.GenerateTemplateSafe(Cache, stream, rmdf, rmt2Name, out _, out _);
                        var rmt2Tag = Cache.TagCache.AllocateTag<RenderMethodTemplate>(rmt2Name);
                        Cache.Serialize(stream, rmt2Tag, rmt2);

                        RenderMethodUnitTest(stream, Cache as GameCacheHaloOnlineBase, rmt2Name, rmt2Name);
                    }
                    catch (Exception e)
                    {
                        new TagToolWarning($"Failed to generate template \"{rmt2Name}\":\n {e}\n");
                    }
                }
                else
                {
                    for (int j = 0; j < rmdf.Categories[i].ShaderOptions.Count; j++)
                    {
                        var options = new byte[rmdf.Categories.Count];

                        options[i] = (byte)j;

                        Console.WriteLine($"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}");

                        var rmt2Name = $"shaders\\{tag.Name.Replace("shaders\\", "")}_templates\\_{string.Join("_", options)}";

                        try
                        {
                            var rmt2 = ShaderGeneratorNew.GenerateTemplateSafe(Cache, stream, rmdf, rmt2Name, out _, out _);
                            var rmt2Tag = Cache.TagCache.AllocateTag<RenderMethodTemplate>(rmt2Name);
                            Cache.Serialize(stream, rmt2Tag, rmt2);

                            RenderMethodUnitTest(stream, Cache as GameCacheHaloOnlineBase, rmt2Name, rmt2Name);
                        }
                        catch (Exception e)
                        {
                            new TagToolWarning($"Failed to generate template \"{rmt2Name}\":\n {e}\n");
                        }
                    }
                }
            }
        }

        public void RenderMethodUnitTest(Stream stream, GameCacheHaloOnlineBase cache, string renderMethodName, string rmt2Name)
        {
            Dictionary<string, string> ShaderTypeGroups = new Dictionary<string, string>
            {
                ["shader"] = "rmsh",
                ["decal"] = "rmd ",
                ["halogram"] = "rmhg",
                ["water"] = "rmw ",
                ["black"] = "rmbk",
                ["terrain"] = "rmtr",
                ["custom"] = "rmcs",
                ["foliage"] = "rmfl",
                ["screen"] = "rmss",
                ["cortana"] = "rmct",
                ["zonly"] = "rmzo",
                ["glass"] = "rmgl",
                ["fur_stencil"] = "rmfs",
                ["fur"] = "rmfu",
                ["mux"] = "rmmx",
            };

            if (!cache.TagCache.TryGetTag($"{rmt2Name.Split('.')[0]}.rmt2", out var rmt2Tag))
                new TagToolError(CommandError.TagInvalid, $"Could not find \"{rmt2Name}.rmt2\"");

            // easier to get the type, and cleaner to check if ms30
            ShaderMatcherNew.Rmt2Descriptor.TryParse(rmt2Tag.Name, out var rmt2Descriptor);

            // check if tag already exists, or allocate new one
            string rmGroup = ShaderTypeGroups[rmt2Descriptor.Type];
            if (!cache.TagCache.TryGetTag($"{renderMethodName}.{rmGroup}", out var rmTag))
                rmTag = cache.TagCache.AllocateTag(cache.TagCache.TagDefinitions.GetTagGroupFromTag(rmGroup), renderMethodName);

            string prefix = rmt2Descriptor.IsMs30 ? "ms30\\" : "";
            string rmdfName = prefix + "shaders\\" + rmt2Descriptor.Type;
            if (!cache.TagCache.TryGetTag($"{rmdfName}.rmdf", out var rmdfTag))
                new TagToolError(CommandError.TagInvalid, $"Could not find \"{rmdfName}.rmdf\"");

            var rmt2 = cache.Deserialize<RenderMethodTemplate>(stream, rmt2Tag);
            var rmdf = cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            // store rmop definitions for quick lookup
            List<RenderMethodOption> renderMethodOptions = new List<RenderMethodOption>();
            for (int i = 0; i < rmt2Descriptor.Options.Length; i++)
            {
                if (rmdf.GlobalOptions != null)
                    renderMethodOptions.Add(cache.Deserialize<RenderMethodOption>(stream, rmdf.GlobalOptions));


                if (rmdf.Categories[i].ShaderOptions.Count == 0)
                    continue;

                var rmopTag = rmdf.Categories[i].ShaderOptions[rmt2Descriptor.Options[i]].Option;
                if (rmopTag != null)
                    renderMethodOptions.Add(cache.Deserialize<RenderMethodOption>(stream, rmopTag));
            }

            // create definition
            object definition = Activator.CreateInstance(cache.TagCache.TagDefinitions.GetTagDefinitionType(rmGroup));
            // make changes as RenderMethod so the code can be reused for each rm type
            var rmDefinition = definition as RenderMethod;

            rmDefinition.BaseRenderMethod = rmdfTag;

            // initialize lists
            rmDefinition.Options = new List<RenderMethod.RenderMethodOptionIndex>();
            rmDefinition.ShaderProperties = new List<RenderMethod.RenderMethodPostprocessBlock>();

            foreach (var option in rmt2Descriptor.Options)
                rmDefinition.Options.Add(new RenderMethod.RenderMethodOptionIndex { OptionIndex = option });
            rmDefinition.SortLayer = TagTool.Shaders.SortingLayerValue.Normal;
            rmDefinition.PredictionAtomIndex = -1;

            PopulateRenderMethodConstants populateConstants = new PopulateRenderMethodConstants();

            // setup shader property
            RenderMethod.RenderMethodPostprocessBlock shaderProperty = new RenderMethod.RenderMethodPostprocessBlock
            {
                Template = rmt2Tag,
                // setup constants
                TextureConstants = populateConstants.SetupTextureConstants(rmt2, renderMethodOptions, cache),
                RealConstants = populateConstants.SetupRealConstants(rmt2, renderMethodOptions, cache),
                IntegerConstants = populateConstants.SetupIntegerConstants(rmt2, renderMethodOptions, cache),
                BooleanConstants = populateConstants.SetupBooleanConstants(rmt2, renderMethodOptions, cache),
                // get alpha blend mode
                BlendMode = populateConstants.GetAlphaBlendMode(rmt2Descriptor, rmdf, cache),
                // TODO
                QueryableProperties = new short[] { -1, -1, -1, -1, -1, -1, -1, -1 }
            };

            rmDefinition.ShaderProperties.Add(shaderProperty);

            cache.Serialize(stream, rmTag, definition);
            cache.SaveTagNames();

            Console.WriteLine($"Generated {rmGroup} tag: {rmTag.Name}.{rmTag.Group}");
        }
    }
}
