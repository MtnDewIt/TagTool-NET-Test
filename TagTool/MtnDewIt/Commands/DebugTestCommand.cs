using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.MtnDewIt.Shaders.LegacyShaderGenerator;
using TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders;
using TagTool.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;
using static TagTool.Commands.Shaders.GenerateShaderCommand;

namespace TagTool.MtnDewIt.Commands
{
    class DebugTestCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public DebugTestCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
        (
            true,
            "DebugTest",
            "Calls on specific functions from within the specified class",
            "DebugTest",
            "Calls on specific functions from within the specified class. Assumes that the specified functions are public"
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            ContextStack = contextStack;
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
                new BeamDefinition(Cache, CacheContext, stream);
                new BlackDefinition(Cache, CacheContext, stream);
                new ContrailDefinition(Cache, CacheContext, stream);
                new CortanaDefinition(Cache, CacheContext, stream);
                new CustomDefinition(Cache, CacheContext, stream);
                new DecalDefinition(Cache, CacheContext, stream);
                new FoliageDefinition(Cache, CacheContext, stream);
                new HalogramDefinition(Cache, CacheContext, stream);
                new LightVolumeDefinition(Cache, CacheContext, stream);
                new ParticleDefinition(Cache, CacheContext, stream);
                new ScreenDefinition(Cache, CacheContext, stream);
                new ShaderDefinition(Cache, CacheContext, stream);
                new TerrainDefinition(Cache, CacheContext, stream);
                new WaterDefinition(Cache, CacheContext, stream);
                new ZOnlyDefinition(Cache, CacheContext, stream);

                Cache.SaveStrings();

                // Some shaders appear to be using MS30 entry point enum for entry point count.
                // This may be why there are issues with generating / recompiling halo online templates?

                GenerateGlobalShader(stream, $@"beam", false);           // Data doesn't change between versions, Compiled bytecode is completely different from MS23 (disable for now)
                GenerateGlobalShader(stream, $@"black", false);
                GenerateGlobalShader(stream, $@"contrail", false);       // Data doesn't change between versions, Compiled bytecode is completely different from MS23 (disable for now) 
                GenerateGlobalShader(stream, $@"cortana", false);
                GenerateGlobalShader(stream, $@"custom", false);         // Compiled bytecode is completely different from bytecode compiled from updated source (use legacy generator for now)
                GenerateGlobalShader(stream, $@"decal", false);          // Compiled bytecode is completely different between MS23 and bytecode compiled from updated source (use legacy generator for now)
                GenerateGlobalShader(stream, $@"foliage", false);        // Having APPLY_FIXES undefined generates 1:1 data. 
                GenerateGlobalShader(stream, $@"halogram", false);
                GenerateGlobalShader(stream, $@"lightvolume", false);    // Data doesn't change between versions, Compiled bytecode is completely different from MS23 (disable for now) 
                GenerateGlobalShader(stream, $@"particle", false);       // Data doesn't change between versions, Compiled bytecode is completely different from MS23 (disable for now) 
                GenerateGlobalShader(stream, $@"screen", false);
                GenerateGlobalShader(stream, $@"shader", false);
                GenerateGlobalShader(stream, $@"terrain", false);        // Compiled bytecode is completely different between MS23 and bytecode compiled from updated source (use legacy generator for now)
                GenerateGlobalShader(stream, $@"water", false);          // Having APPLY_FIXES undefined generates 1:1 data. 
                GenerateGlobalShader(stream, $@"zonly", false);

                GenerateGlobalShader(stream, $@"beam", true);
                GenerateGlobalShader(stream, $@"black", true);
                GenerateGlobalShader(stream, $@"contrail", true);
                GenerateGlobalShader(stream, $@"cortana", true);
                GenerateGlobalShader(stream, $@"custom", true);
                GenerateGlobalShader(stream, $@"decal", true);
                GenerateGlobalShader(stream, $@"foliage", true);
                GenerateGlobalShader(stream, $@"halogram", true);
                GenerateGlobalShader(stream, $@"lightvolume", true);
                GenerateGlobalShader(stream, $@"particle", true);
                GenerateGlobalShader(stream, $@"screen", true);
                GenerateGlobalShader(stream, $@"shader", true);
                GenerateGlobalShader(stream, $@"terrain", true);
                GenerateGlobalShader(stream, $@"water", true);
                GenerateGlobalShader(stream, $@"zonly", true);
            }
        }

        public void GenerateGlobalShader(Stream stream, string shaderType, bool pixel)
        {
            var type = (HaloShaderGenerator.Globals.ShaderType)Enum.Parse(typeof(HaloShaderGenerator.Globals.ShaderType), shaderType, true);

            CachedTag rmdfTag = null;

            if (shaderType == "lightvolume")
            {
                rmdfTag = Cache.TagCache.GetTag($"shaders\\light_volume.rmdf");
            }
            else
            {
                rmdfTag = Cache.TagCache.GetTag($"shaders\\{shaderType}.rmdf");
            }

            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            if (pixel)
            {
                GlobalPixelShader glps = ShaderGeneratorNew.GenerateSharedPixelShaders(Cache, rmdf, type);
                Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            }
            else
            {
                GlobalVertexShader glvs = ShaderGeneratorNew.GenerateSharedVertexShaders(Cache, rmdf, type);
                Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
            }
        }

        public void GenerateLegacyGlobalShader(Stream stream, string shaderType, bool pixel)
        {
            var generator = LegacyShaderGenerator.GetLegacyGlobalShaderGenerator(shaderType, true);

            CachedTag rmdfTag = null;

            if (shaderType == "lightvolume")
            {
                rmdfTag = Cache.TagCache.GetTag($"shaders\\light_volume.rmdf");
            }
            else
            {
                rmdfTag = Cache.TagCache.GetTag($"shaders\\{shaderType}.rmdf");
            }

            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            if (pixel)
            {
                GlobalPixelShader glps = LegacyShaderGenerator.GenerateSharedPixelShader(Cache, generator);
                Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            }
            else
            {
                GlobalVertexShader glvs = LegacyShaderGenerator.GenerateSharedVertexShader(Cache, generator);
                Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
            }
        }

        public void RecompileShaders(Stream stream, string shaderType)
        {
            if (!Cache.TagCache.TryGetTag($"shaders\\{shaderType}.rmdf", out CachedTag rmdfTag))
                new TagToolError(CommandError.TagInvalid, $"Missing \"{shaderType}\" rmdf");

            var rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            if (rmdf.GlobalVertexShader == null || rmdf.GlobalPixelShader == null)
                new TagToolError(CommandError.TagInvalid, "A global shader was missing from rmdf");

            var glvs = Cache.Deserialize<GlobalVertexShader>(stream, rmdf.GlobalVertexShader);
            var glps = Cache.Deserialize<GlobalPixelShader>(stream, rmdf.GlobalPixelShader);

            List<CachedTag> regenTags = new List<CachedTag>();
            foreach (var tag in Cache.TagCache.NonNull())
            {
                if (tag.Group.Tag != "rmt2" ||
                    tag.Name.StartsWith("ms30") ||
                    !tag.Name.Split('\\')[1].StartsWith(shaderType + "_templates"))
                    continue;
                regenTags.Add(tag);
            }

            List<STemplateRecompileInfo> recompileInfo = new List<STemplateRecompileInfo>();

            foreach (var tag in regenTags)
            {
                List<byte> options = new List<byte>();
                foreach (var option in tag.Name.Split('\\')[2].Remove(0, 1).Split('_'))
                    options.Add(byte.Parse(option));
                while (options.Count < rmdf.Categories.Count)
                    options.Add(0);
                var aOptions = options.ToArray();

                STemplateRecompileInfo info = new STemplateRecompileInfo
                {
                    Name = $"shaders\\{shaderType}_templates\\_{string.Join("_", aOptions)}",
                    ShaderType = shaderType,
                    Options = aOptions,
                    Tag = tag,
                    Dependants = GetDependantsAsync(Cache, stream, shaderType, aOptions),
                    AllRmopParameters = ShaderGeneratorNew.GatherParameters(Cache, stream, rmdf, options)
                };

                recompileInfo.Add(info);
            }

            List<Task<STemplateRecompileInfo>> tasks = new List<Task<STemplateRecompileInfo>>();

            foreach (var info in recompileInfo)
            {
                Task<STemplateRecompileInfo> generatorTask = Task.Run(() =>
                {
                    return GenerateRenderMethodTemplateAsync(Cache, info, rmdf, glvs, glps);
                });
                tasks.Add(generatorTask);
            }

            // serialize
            foreach (var task in tasks)
            {
                if (!Cache.TagCache.TryGetTag(task.Result.Name + ".pixl", out task.Result.Template.PixelShader))
                    task.Result.Template.PixelShader = Cache.TagCache.AllocateTag<PixelShader>(task.Result.Name);
                if (!Cache.TagCache.TryGetTag(task.Result.Name + ".vtsh", out task.Result.Template.VertexShader))
                    task.Result.Template.VertexShader = Cache.TagCache.AllocateTag<VertexShader>(task.Result.Name);

                Cache.Serialize(stream, task.Result.Template.PixelShader, task.Result.PixelShader);
                Cache.Serialize(stream, task.Result.Template.VertexShader, task.Result.VertexShader);
                Cache.Serialize(stream, task.Result.Tag, task.Result.Template);

                (Cache as GameCacheHaloOnlineBase).SaveTagNames();

                ReserializeDependantsAsync(Cache, stream, task.Result.Template, task.Result.Dependants);
            }

            // validation
            foreach (var task in tasks)
            {
                var rmt2 = Cache.Deserialize<RenderMethodTemplate>(stream, task.Result.Tag);
                var pixl = Cache.Deserialize<PixelShader>(stream, rmt2.PixelShader);

                if (rmt2.PixelShader.Name == null || rmt2.PixelShader.Name == "")
                    new TagToolWarning($"pixel_shader {rmt2.PixelShader.Index:X16} has no name");

                for (int i = 0; i < pixl.EntryPointShaders.Count; i++)
                {
                    bool entryNeeded = rmdf.EntryPoints.Any(x => (int)x.EntryPoint == i) &&
                        (glps.EntryPoints[i].DefaultCompiledShaderIndex == -1 && glps.EntryPoints[i].CategoryDependency.Count == 0);

                    if (pixl.EntryPointShaders[i].Count > 0 && !entryNeeded)
                        new TagToolWarning($"{rmt2.PixelShader.Name} has unneeded entry point shader {(TagTool.Shaders.EntryPoint)i}");

                    if (pixl.EntryPointShaders[i].Count == 0 && entryNeeded)
                        new TagToolWarning($"{rmt2.PixelShader.Name} missing entry point shader {(TagTool.Shaders.EntryPoint)i}");

                    if (pixl.EntryPointShaders[i].Count > 0 && pixl.EntryPointShaders[i].Offset >= pixl.Shaders.Count)
                        new TagToolWarning($"{rmt2.PixelShader.Name} has invalid compiled shader indices {i}");
                }
            }
        }
    }
}