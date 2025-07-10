using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Shaders.ShaderMatching;
using System;
using TagTool.Shaders.ShaderConverter;
using System.Collections.Generic;
using TagTool.Shaders;

namespace TagTool.Porting.Gen3
{
    partial class PortingContextGen3
    {
        private class DeferredRenderMethodData
        {
            public readonly CachedTag EdTag;
            public readonly CachedTag BlamTag;
            public readonly Stream CacheStream;
            public readonly Stream BlamCacheStream;
            public readonly object Definition;
            public readonly List<(RenderMethod RenderMethod, RenderMethod BlamRenderMethod)> RenderMethods = [];

            public DeferredRenderMethodData(Stream cacheStream, Stream blamCacheStream, CachedTag edTag, CachedTag blamTag, object definition, List<(RenderMethod RenderMethod, RenderMethod BlamRenderMethod)> renderMethods)
            {
                CacheStream = cacheStream;
                BlamCacheStream = blamCacheStream;
                EdTag = edTag;
                BlamTag = blamTag;
                Definition = definition;
                RenderMethods = renderMethods;
            }
        }

        public List<string> PendingTemplates = new List<string>();
        private List<DeferredRenderMethodData> DeferredRenderMethods = [];

        public class TemplateConversionResult
        {
            public RenderMethodTemplate Definition;
            public PixelShader PixelShaderDefinition;
            public VertexShader VertexShaderDefinition;
            public CachedTag Tag;
        }

        public ShaderMatcherNew Matcher = new ShaderMatcherNew();

        private RasterizerGlobals ConvertRasterizerGlobals(RasterizerGlobals rasg)
        {
            if (BlamCache.Version == CacheVersion.Halo3ODST)
            {
                rasg.MotionBlurParametersLegacy.NumberOfTaps = 6;
            }
            return rasg;
        }

        private void FinalizeRenderMethods()
        {
            foreach (var deferredRm in DeferredRenderMethods)
            {
                foreach (var rm in deferredRm.RenderMethods)
                    ConvertShaderInternal(deferredRm.CacheStream, deferredRm.BlamCacheStream, rm.RenderMethod, rm.BlamRenderMethod);

                CacheContext.Serialize(deferredRm.CacheStream, deferredRm.EdTag, deferredRm.Definition);

                if (FlagIsSet(PortingFlags.Print))
                    Console.WriteLine($"['{deferredRm.EdTag.Group.Tag}', 0x{deferredRm.EdTag.Index:X4}] {deferredRm.EdTag.Name}.{(deferredRm.EdTag.Group as Cache.Gen3.TagGroupGen3).Name}");
            }
            DeferredRenderMethods.Clear();
            PendingTemplates.Clear();
        }

        private RenderMethod ConvertShaderInternal(Stream cacheStream, Stream blamCacheStream, RenderMethod definition, RenderMethod blamDefinition)
        {
            if (!Matcher.IsInitialized)
                Matcher.Init(CacheContext, BlamCache, cacheStream, blamCacheStream, this, FlagIsSet(PortingFlags.Ms30), FlagIsSet(PortingFlags.PefectShaderMatchOnly));

            var shaderProperty = definition.ShaderProperties[0];
            var blamShaderProperty = blamDefinition.ShaderProperties[0];

            // in case of failed match
            if (shaderProperty.Template == null)
                return null;

            return ConvertRenderMethod(cacheStream, blamCacheStream, definition, blamDefinition, blamShaderProperty.Template);
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

        private CachedTag FindClosestRmt2(Stream cacheStream, Stream blamCacheStream, CachedTag blamRmt2)
        {
            // Verify that the ShaderMatcher is ready to use
            if (!Matcher.IsInitialized)
                Matcher.Init(CacheContext, BlamCache, cacheStream, blamCacheStream, this, FlagIsSet(PortingFlags.Ms30), FlagIsSet(PortingFlags.PefectShaderMatchOnly));

            return Matcher.FindClosestTemplate(blamRmt2, BlamCache.Deserialize<RenderMethodTemplate>(blamCacheStream, blamRmt2), FlagIsSet(PortingFlags.GenerateShaders));
        }

        private RenderMethod ConvertRenderMethod(Stream cacheStream, Stream blamCacheStream, RenderMethod finalRm, RenderMethod blamRm, CachedTag blamRmt2)
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