using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Shaders.ShaderMatching;
using System;
using TagTool.Shaders.ShaderConverter;
using System.Collections.Generic;
using TagTool.Shaders;
using System.Threading.Tasks;

namespace TagTool.Porting.Gen3
{
    partial class PortingContextGen3
    {
        public Dictionary<string, Task> PendingTemplates = new Dictionary<string, Task>();

        public ShaderMatcherNew Matcher = new ShaderMatcherNew();

        private RasterizerGlobals ConvertRasterizerGlobals(RasterizerGlobals rasg)
        {
            if (BlamCache.Version == CacheVersion.Halo3ODST)
            {
                rasg.MotionBlurParametersLegacy.NumberOfTaps = 6;
            }
            return rasg;
        }

        private CachedTag GetDefaultShader(Tag groupTag)
        {
            CachedTag shaderTag;

            switch (groupTag.ToString())
            {
                case "beam" when CacheContext.TagCache.TryGetTag(@"objects\weapons\support_high\spartan_laser\fx\firing_3p.beam", out shaderTag):
                    return shaderTag;

                case "cntl" when CacheContext.TagCache.TryGetTag(@"objects\weapons\pistol\needler\fx\projectile.cntl", out shaderTag):
                    return shaderTag;

                case "decs" when CacheContext.TagCache.TryGetTag(@"fx\decals\impact_plasma\impact_plasma_medium\hard.decs", out shaderTag):
                    return shaderTag;

                case "ltvl" when CacheContext.TagCache.TryGetTag(@"objects\weapons\pistol\plasma_pistol\fx\charged\projectile.ltvl", out shaderTag):
                    return shaderTag;

                case "prt3" when CacheContext.TagCache.TryGetTag(@"fx\particles\energy\sparks\impact_spark_orange.prt3", out shaderTag):
                    return shaderTag;

                case "rmd " when CacheContext.TagCache.TryGetTag(@"objects\gear\human\military\shaders\human_military_decals.rmd", out shaderTag):
                    return shaderTag;

                case "rmfl" when CacheContext.TagCache.TryGetTag(@"levels\multi\riverworld\shaders\riverworld_tree_leafa.rmfl", out shaderTag):
                    return shaderTag;

                case "rmtr" when CacheContext.TagCache.TryGetTag(@"levels\multi\riverworld\shaders\riverworld_ground.rmtr", out shaderTag):
                    return shaderTag;

                case "rmw " when CacheContext.TagCache.TryGetTag(@"levels\multi\riverworld\shaders\riverworld_water_rough.rmw", out shaderTag):
                    return shaderTag;

                case "rmhg" when CacheContext.TagCache.TryGetTag(@"objects\multi\shaders\koth_shield.rmhg", out shaderTag):
                    return shaderTag;

                case "rmbk" when CacheContext.TagCache.TryGetTag(@"levels\dlc\bunkerworld\shaders\z_black.rmsh", out shaderTag):
                    return shaderTag;
                case "rmgl" when CacheContext.TagCache.TryGetTag(@"levels\dlc\sidewinder\shaders\side_hall_glass03.rmsh", out shaderTag):
                    return shaderTag;
                case "rmrd":
                case "rmsh":
                case "rmss":
                case "rmcs":
                case "rmzo":
                case "rmct":
                    return CacheContext.TagCache.GetTag<Shader>(@"shaders\invalid");
            }

            Console.WriteLine($"No default shader found for \"{groupTag.ToString()}\", using \"shaders\\invalid.rmsh\"");
            return CacheContext.TagCache.GetTag<Shader>(@"shaders\invalid");
        }


        private RenderMethod ConvertRenderMethod(Stream cacheStream, Stream blamCacheStream, object definition, string blamTagName, RenderMethod renderMethod)
        {
            RenderMethod edRenderMethod = ConvertStructure(cacheStream, blamCacheStream, renderMethod.DeepCloneV2(), definition, blamTagName);

            if (!Matcher.IsInitialized)
                Matcher.Init(CacheContext, BlamCache, cacheStream, blamCacheStream, this, FlagIsSet(PortingFlags.Ms30), FlagIsSet(PortingFlags.PefectShaderMatchOnly));

            CachedTag rmt2Tag = Matcher.FindClosestTemplate(renderMethod.ShaderProperties[0].Template.Name, blamTagName, out string tagName, out bool isExactMatch);

            bool isTemplatePending = PendingTemplates.TryGetValue(tagName, out Task templateTask);

            if (FlagIsSet(PortingFlags.GenerateShaders) && !isTemplatePending && !isExactMatch)
            {
                templateTask = Matcher.GenerateTemplateAsync(cacheStream, tagName, out rmt2Tag);
                PendingTemplates.Add(tagName, templateTask);
            }

            edRenderMethod.ShaderProperties[0].Template = rmt2Tag;

            templateTask ??= Task.CompletedTask;
            AddTask(templateTask.ContinueWith(_ => ConvertShaderInternal(cacheStream, blamCacheStream, edRenderMethod, renderMethod), MainThreadScheduler));

            return edRenderMethod;
        }

        private RenderMethod ConvertShaderInternal(Stream cacheStream, Stream blamCacheStream, RenderMethod finalRm, RenderMethod blamRm)
        {
            ShaderConverter shaderConverter = new ShaderConverter(CacheContext, 
                BlamCache, 
                cacheStream, 
                blamCacheStream,
                finalRm, 
                blamRm, 
                Matcher);
            RenderMethod newRm = shaderConverter.ConvertRenderMethod();

            // copy each field as at this point in conversion,
            // we don't know the original tag type and what extra fields exist

            finalRm.BaseRenderMethod = newRm.BaseRenderMethod;
            finalRm.Options = newRm.Options;
            finalRm.Parameters = newRm.Parameters;
            finalRm.ShaderProperties = newRm.ShaderProperties;
            finalRm.RenderFlags = newRm.RenderFlags;
            finalRm.SortLayer = newRm.SortLayer;
            finalRm.Version = newRm.Version;
            finalRm.CustomFogSettingIndex = newRm.CustomFogSettingIndex;
            finalRm.PredictionAtomIndex = newRm.PredictionAtomIndex;

            return finalRm;
        }


        private RenderMethodOption ConvertRenderMethodOption(RenderMethodOption rmop)
        {
            if (BlamCache.Version == CacheVersion.Halo3ODST || BlamCache.Version >= CacheVersion.HaloReach)
            {
                foreach (var block in rmop.Parameters)
                {
                    if (BlamCache.Version == CacheVersion.Halo3ODST && block.RenderMethodExtern >= RenderMethodExtern.emblem_player_shoulder_texture)
                    {
                        block.RenderMethodExtern = (RenderMethodExtern)((int)block.RenderMethodExtern + 2);
                    }

                    if (BlamCache.Version >= CacheVersion.HaloReach)
                    {
                        // TODO
                    }
                }
            }

            return rmop;
        }
    }
}