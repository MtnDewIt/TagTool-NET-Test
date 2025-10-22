using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using TagTool.Shaders.ShaderMatching;
using System;
using TagTool.Shaders.ShaderConverter;
using System.Collections.Generic;
using TagTool.Shaders;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagTool.Bitmaps.Utils;
using TagTool.Bitmaps;
using TagTool.Common.Logging;

namespace TagTool.Porting.Gen3
{
    partial class PortingContextGen3
    {
        protected Dictionary<string, Task> PendingTemplates = new Dictionary<string, Task>();

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
                case "rmgl" when CacheContext.TagCache.TryGetTag(@"levels\dlc\bunkerworld\shaders\bunker_glass_techwindow.rmsh", out shaderTag):
                    return shaderTag;
                case "rmrd":
                case "rmsh":
                case "rmss":
                case "rmcs":
                case "rmzo":
                case "rmct":
                case "rmfu":
                case "rmfs":
                case "rmmx":
                    return CacheContext.TagCache.GetTag<Shader>(@"shaders\invalid");
            }

            Console.WriteLine($"No default shader found for \"{groupTag.ToString()}\", using \"shaders\\invalid.rmsh\"");
            return CacheContext.TagCache.GetTag<Shader>(@"shaders\invalid");
        }

        private RenderMethod ConvertRenderMethod(Stream cacheStream, Stream blamCacheStream, object definition, string blamTagName, RenderMethod renderMethod)
        {
            var rmt2 = BlamCache.Deserialize<RenderMethodTemplate>(blamCacheStream, renderMethod.ShaderProperties[0].Template);

            if (FlagIsSet(PortingFlags.Recursive))
                ConvertRenderMethodBitmaps(cacheStream, blamCacheStream, renderMethod, blamTagName, rmt2);

            RenderMethod edRenderMethod = ConvertStructure(cacheStream, blamCacheStream, renderMethod.DeepCloneV2(), definition, blamTagName);

            if (!Matcher.IsInitialized)
                Matcher.Init(CacheContext, BlamCache, cacheStream, blamCacheStream, this, FlagIsSet(PortingFlags.Ms30), FlagIsSet(PortingFlags.PefectShaderMatchOnly));

            CachedTag rmt2Tag = Matcher.FindClosestTemplate(renderMethod.ShaderProperties[0].Template.Name, blamTagName, out string tagName, out bool isExactMatch);

            bool isTemplatePending = PendingTemplates.TryGetValue(tagName, out Task templateTask);

            if (!isTemplatePending && FlagIsSet(PortingFlags.GenerateShaders) && (!isExactMatch || FlagsAllSet(PortingFlags.Replace | PortingFlags.Recursive)))
            {
                templateTask = Matcher.GenerateTemplateAsync(cacheStream, tagName, out rmt2Tag);
                PendingTemplates.Add(tagName, templateTask);
            }

            edRenderMethod.ShaderProperties[0].Template = rmt2Tag;

            templateTask ??= Task.CompletedTask;
            AddTask(templateTask.ContinueWith(_ => ConvertShaderInternal(cacheStream, blamCacheStream, edRenderMethod, renderMethod), MainThreadScheduler));

            return edRenderMethod;
        }

        private void ConvertRenderMethodBitmaps(Stream cacheStream, Stream blamCacheStream, RenderMethod renderMethod, string blamTagName, RenderMethodTemplate rmt2)
        {
            var postprocessDef = renderMethod.ShaderProperties[0];

            for (int i = 0; i < postprocessDef.TextureConstants.Count; i++)
            {
                string paramName = BlamCache.StringTable.GetString(rmt2.TextureParameterNames[i].Name);
                var constant = postprocessDef.TextureConstants[i];
                if (constant.Bitmap == null)
                {
                    Log.Warning($"Render method in '{blamTagName}' has a null bitmap for parameter '{paramName}'");
                    continue;
                }

                Bitmap bitmap = BlamCache.Deserialize<Bitmap>(blamCacheStream, constant.Bitmap);

                if (Options.UseExperimentalDxt5nm && BumpMapParameterRegex().IsMatch(paramName) && !BitmapUtils.IsNormalMap(bitmap, 0))
                {
                    Log.Warning($"Render method in '{blamTagName}' has an invalid bump map for parameter '{paramName}'");

                    if (BumpFileNameSuffixRegex().IsMatch(constant.Bitmap.Name))
                    {
                        Log.Warning($"Possibly incorrect bitmap usage detected '{constant.Bitmap}'");
                    }

                    // Fix diffuse bitmaps that are incorrectly used as bump maps. This needs to be done for dxt5nm

                    BitmapConverterMode oldBitmapMode = BitmapMode;
                    try
                    {
                        BitmapMode = BitmapConverterMode.DiffuseToNormal;

                        var options = new ConvertTagOptions()
                        {
                            AllowReentrancy = true,
                            TargetTagName = $"{constant.Bitmap.Name}_dxt5nm"
                        };
                        constant.Bitmap = ConvertTag(cacheStream, blamCacheStream, constant.Bitmap, blamTagName, bitmap, options);    
                    }
                    finally
                    {
                        BitmapMode = oldBitmapMode;
                    }
                }
                else
                {
                    constant.Bitmap = ConvertTag(cacheStream, blamCacheStream, constant.Bitmap, blamTagName, bitmap);
                }

                // Fixup the parameters block
                foreach (var parameter in renderMethod.Parameters)
                {
                    if (parameter.ParameterType == RenderMethodOption.ParameterBlock.OptionDataType.Bitmap && parameter.Name == rmt2.TextureParameterNames[i].Name)
                    {
                        parameter.Bitmap = constant.Bitmap;
                        break;
                    }
                }
            }
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

        [GeneratedRegex("^(bump_map|bump_detail_map|bump_detail_masked_map|distort_map|wrinkle_normal|detail_bump)")]
        private static partial Regex BumpMapParameterRegex();

        [GeneratedRegex("(_bump|_zbump|_detailbump|_normal)$")]
        private static partial Regex BumpFileNameSuffixRegex();
    }
}