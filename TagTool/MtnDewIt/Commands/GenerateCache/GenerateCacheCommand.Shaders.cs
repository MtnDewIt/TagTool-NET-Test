using TagTool.Commands.Common;
using TagTool.Commands;
using System.IO;
using TagTool.Cache;
using TagTool.Tags.Definitions;
using System.Collections.Generic;
using System;
using TagTool.Commands.Shaders;
using TagTool.MtnDewIt.Shaders.RenderMethodDefinitions.Shaders;
using TagTool.MtnDewIt.Shaders.ShaderGenerator;
using HaloShaderGenerator.Globals;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public static HashSet<ShaderType> noFixesShaders = new HashSet<ShaderType> 
        {
            ShaderType.Water,
            ShaderType.Foliage,
        };

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
            
            foreach (ShaderType shaderType in Enum.GetValues(typeof(ShaderType))) 
            {
                if (shaderType == ShaderType.Glass)
                    continue;
                    
                bool applyFixes = !noFixesShaders.Contains(shaderType);
                GenerateGlobalShader(CacheStream, shaderType, applyFixes);
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