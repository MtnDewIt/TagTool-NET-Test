using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using TagTool.Commands;
using TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders;
using System;
using TagTool.Shaders.ShaderGenerator;
using TagTool.Commands.Shaders;

namespace TagTool.MtnDewIt.Commands.ConvertCache
{
    partial class ConvertCacheCommand : Command
    {
        public void UpdateShaderData()
        {
            // This tag isn't in the rebuilt cache by default
            GenerateTag<Bitmap>($@"shaders\default_bitmaps\bitmaps\color_green");

            new shaders_beam_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_black_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_contrail_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_cortana_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_custom_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_decal_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_foliage_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_halogram_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_light_volume_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_particle_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_screen_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_shader_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_terrain_render_method_definition(Cache, CacheContext, CacheStream);
            new shaders_water_render_method_definition(Cache, CacheContext, CacheStream);   
            new shaders_zonly_render_method_definition(Cache, CacheContext, CacheStream);

            Cache.SaveStrings();

            GenerateGlobalShaders(CacheStream, $@"beam");           // Data doesn't change between versions, Compiled vertex data is completely different from MS23 (disable for now)
            GenerateGlobalShaders(CacheStream, $@"black");
            GenerateGlobalShaders(CacheStream, $@"contrail");       // Data doesn't change between versions, Compiled vertex data is completely different from MS23 (disable for now) 
            GenerateGlobalShaders(CacheStream, $@"cortana");
            GenerateGlobalShaders(CacheStream, $@"custom");         // Vertex data is completely different from vertex data from updated source (use legacy generator for 1:1 data)
            GenerateGlobalShaders(CacheStream, $@"decal");          // Vertex data is completely different between MS23 and vertex data from updated source (use legacy generator for 1:1 data)
            GenerateGlobalShaders(CacheStream, $@"foliage");        // Having APPLY_FIXES undefined generates 1:1 vertex data. 
            GenerateGlobalShaders(CacheStream, $@"halogram");
            GenerateGlobalShaders(CacheStream, $@"lightvolume");    // Data doesn't change between versions, Compiled vertex data is completely different from MS23 (disable for now) 
            GenerateGlobalShaders(CacheStream, $@"particle");       // Data doesn't change between versions, Compiled vertex data is completely different from MS23 (disable for now) 
            GenerateGlobalShaders(CacheStream, $@"screen");
            GenerateGlobalShaders(CacheStream, $@"shader");
            GenerateGlobalShaders(CacheStream, $@"terrain");        // Vertex data is completely different between MS23 and vertex data from updated source (use legacy generator for 1:1 data)
            GenerateGlobalShaders(CacheStream, $@"water");          // Having APPLY_FIXES undefined generates 1:1 vertex data. 
            GenerateGlobalShaders(CacheStream, $@"zonly");
        }


        // TODO: Expose APPLY_FIXES
        public void GenerateGlobalShaders(Stream stream, string shaderType)
        {
            var type = (HaloShaderGenerator.Globals.ShaderType)Enum.Parse(typeof(HaloShaderGenerator.Globals.ShaderType), shaderType, true);

            CachedTag rmdfTag = Cache.TagCache.GetTag<RenderMethodDefinition>(shaderType == "lightvolume" ? "shaders\\light_volume" : $"shaders\\{shaderType}");

            RenderMethodDefinition rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);

            GlobalPixelShader glps = ShaderGeneratorNew.GenerateSharedPixelShaders(Cache, rmdf, type);
            GlobalVertexShader glvs = ShaderGeneratorNew.GenerateSharedVertexShaders(Cache, rmdf, type);

            Cache.Serialize(stream, rmdf.GlobalPixelShader, glps);
            Cache.Serialize(stream, rmdf.GlobalVertexShader, glvs);
        }

        public void GenerateRenderMethodTemplate(string shaderType, string shaderOptions)
        {
            List<byte> rawShaderOptions = new List<byte>();

            string[] optionsList = shaderOptions.Split(new char[] { ' ' });

            for (int i = 0; i < optionsList.Length; i++)
            {
                var parsedShaderOption = byte.Parse(optionsList[i]);

                rawShaderOptions.Add(parsedShaderOption);
            }

            var rmdfTag = CacheContext.TagCache.GetTag<RenderMethodDefinition>($@"shaders\{shaderType}");
            var rmdf = CacheContext.Deserialize<RenderMethodDefinition>(CacheStream, rmdfTag);

            GenerateShaderCommand.GenerateRenderMethodTemplate(Cache, CacheStream, shaderType, rawShaderOptions.ToArray(), rmdf, true);
        }
    }
}