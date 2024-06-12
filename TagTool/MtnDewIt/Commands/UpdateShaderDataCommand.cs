using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders;
using TagTool.Shaders.ShaderGenerator;
using TagTool.Tags.Definitions;

namespace TagTool.MtnDewIt.Commands
{
    class UpdateShaderDataCommand : Command
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public CommandContextStack ContextStack { get; set; }

        public UpdateShaderDataCommand(GameCache cache, GameCacheHaloOnline cacheContext, CommandContextStack contextStack) : base
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

                // TODO: Include Chud and Explicit Shaders in Recompile
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
    }
}