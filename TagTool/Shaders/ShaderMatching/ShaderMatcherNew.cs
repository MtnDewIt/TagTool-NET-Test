using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Commands.Porting;
using TagTool.Porting;
using TagTool.Porting.Gen3;
using TagTool.Common.Logging;
using TagTool.BlamFile;
using System.Threading.Tasks;
using System.Threading;

namespace TagTool.Shaders.ShaderMatching
{
    public class ShaderMatcherNew
    {
        private GameCache BaseCache;
        private GameCache PortingCache;
        private Stream BaseCacheStream;
        private PortingContextGen3 PortContext;
        // shader type, definition
        private Dictionary<string, RenderMethodDefinition> RenderMethodDefinitions;
        private Dictionary<string, RenderMethodDefinition> PortingRenderMethodDefinitions;
        // tag name, definition
        private Dictionary<string, RenderMethodOption> RenderMethodOptions;
        private Dictionary<string, RenderMethodOption> PortingRenderMethodOptions;

        public bool IsInitialized { get; private set; } = false;
        public bool UseMs30 { get; set; } = false;
        public bool PerfectMatchesOnly { get; set; } = false;

        static readonly string[] ContentBugDecals = [
            "objects\\vehicles\\scorpion\\shaders\\number_decal",
            "objects\\vehicles\\scorpion\\shaders\\scorpion_decal",
            "objects\\vehicles\\scorpion\\shaders\\icon",
            "objects\\vehicles\\shared\\pelican_110_hc\\shaders\\pelican_decals",
            "levels\\solo\\100_citadel\\decals\\gravel",
            "levels\\dlc\\bunkerworld\\decals\\decal_missile_facility",
            "levels\\shared\\decals\\multi\\riverworld\\riverworld_granite_decal",
            "objects\\levels\\multi\\shrine\\shaders\\xtra_decals"
        ];

        public class TemplateConversionResult
        {
            public RenderMethodTemplate Definition;
            public PixelShader PixelShaderDefinition;
            public VertexShader VertexShaderDefinition;
            public CachedTag Tag;
        }

        public void Init(GameCache baseCache, 
            GameCache portingCache, 
            Stream baseCacheStream, 
            Stream portingCacheStream,
            PortingContextGen3 portContext,
            bool useMS30 = false, 
            bool perfectMatchesOnly = false)
        {
            UseMs30 = useMS30;
            PerfectMatchesOnly = perfectMatchesOnly;
            BaseCache = baseCache;
            PortingCache = portingCache;
            BaseCacheStream = baseCacheStream;
            IsInitialized = true;
            PortContext = portContext;

            // we need to store all of these for async. will save cpu time for map ports since we no longer deserialize for every shader tag
            RenderMethodDefinitions = new Dictionary<string, RenderMethodDefinition>();
            PortingRenderMethodDefinitions = new Dictionary<string, RenderMethodDefinition>();
            RenderMethodOptions = new Dictionary<string, RenderMethodOption>();
            PortingRenderMethodOptions = new Dictionary<string, RenderMethodOption>();

            foreach (var rmdfTag in baseCache.TagCache.NonNull().Where(x => x.Group.Tag == "rmdf" && !x.Name.StartsWith("ms30\\")))
                RenderMethodDefinitions.Add(rmdfTag.Name.Remove(0, 8), baseCache.Deserialize<RenderMethodDefinition>(baseCacheStream, rmdfTag));
            foreach (var rmdfTag in portingCache.TagCache.NonNull().Where(x => x.Group.Tag == "rmdf"))
                PortingRenderMethodDefinitions.Add(rmdfTag.Name.Remove(0, 8), portingCache.Deserialize<RenderMethodDefinition>(portingCacheStream, rmdfTag));

            foreach (var rmopTag in baseCache.TagCache.NonNull().Where(x => x.Group.Tag == "rmop" && !x.Name.StartsWith("ms30\\")))
                RenderMethodOptions.Add(rmopTag.Name, baseCache.Deserialize<RenderMethodOption>(baseCacheStream, rmopTag));
            foreach (var rmopTag in portingCache.TagCache.NonNull().Where(x => x.Group.Tag == "rmop"))
                PortingRenderMethodOptions.Add(rmopTag.Name, portingCache.Deserialize<RenderMethodOption>(portingCacheStream, rmopTag));
        }

        public void DeInit()
        {
            UseMs30 = false;
            PerfectMatchesOnly = false;
            BaseCache = null;
            PortingCache = null;
            BaseCacheStream = null;
            IsInitialized = false;
            PortContext = null;
            RenderMethodDefinitions = null;
            PortingRenderMethodDefinitions = null;
            RenderMethodOptions = null;
            PortingRenderMethodOptions = null;
        }

        public Dictionary<StringId, RenderMethodOption.ParameterBlock.OptionDataType> GetOptionParameters(List<byte> options, RenderMethodDefinition rmdf)
        {
            Dictionary<StringId, RenderMethodOption.ParameterBlock.OptionDataType> optionParameters = new Dictionary<StringId, RenderMethodOption.ParameterBlock.OptionDataType>();

            for (int i = 0; i < options.Count; i++)
            {
                if (rmdf.Categories[i].ShaderOptions[options[i]].Option != null)
                {
                    var rmop = RenderMethodOptions[rmdf.Categories[i].ShaderOptions[options[i]].Option.Name];
                    foreach (var parameter in rmop.Parameters)
                        if (!optionParameters.ContainsKey(parameter.Name))
                            optionParameters.Add(parameter.Name, parameter.Type);
                }
            }

            return optionParameters;
        }

        public Dictionary<StringId, RenderMethodOption.ParameterBlock> GetOptionBlocks(List<byte> options, RenderMethodDefinition rmdf)
        {
            Dictionary<StringId, RenderMethodOption.ParameterBlock> optionBlocks = new Dictionary<StringId, RenderMethodOption.ParameterBlock>();

            for (int i = 0; i < options.Count; i++)
            {
                if (rmdf.Categories[i].ShaderOptions[options[i]].Option != null)
                {
                    var rmop = RenderMethodOptions[rmdf.Categories[i].ShaderOptions[options[i]].Option.Name];
                    foreach (var parameter in rmop.Parameters)
                        if (!optionBlocks.ContainsKey(parameter.Name))
                            optionBlocks.Add(parameter.Name, parameter);
                }
            }

            return optionBlocks;
        }

        public Dictionary<StringId, CachedTag> GetOptionBitmaps(List<byte> options, RenderMethodDefinition rmdf)
        {
            Dictionary<StringId, CachedTag> optionBitmaps = new Dictionary<StringId, CachedTag>();

            for (int i = 0; i < options.Count; i++)
            {
                if (rmdf.Categories[i].ShaderOptions[options[i]].Option != null)
                {
                    var rmop = RenderMethodOptions[rmdf.Categories[i].ShaderOptions[options[i]].Option.Name];
                    foreach (var parameter in rmop.Parameters)
                        if (parameter.Type == RenderMethodOption.ParameterBlock.OptionDataType.Bitmap && parameter.DefaultSamplerBitmap != null && !optionBitmaps.ContainsKey(parameter.Name))
                            optionBitmaps.Add(parameter.Name, parameter.DefaultSamplerBitmap);
                }
            }

            return optionBitmaps;
        }

        /// <summary>
        /// Find the closest template in the base cache to the input template.
        /// </summary>
        public CachedTag FindClosestTemplate(string sourceRmt2Name, string blamRenderMethodName, out string tagName, out bool isExactMatch)
        {
            Debug.Assert(IsInitialized);
            isExactMatch = false;
            tagName = null;

            if (!Rmt2Descriptor.TryParse(sourceRmt2Name, out Rmt2Descriptor sourceRmt2Desc))
            {
                Log.Error($"Invalid rmt2 name '{sourceRmt2Name}'");
                return null;
            }

            // rebuild options to match base cache
            sourceRmt2Desc = RebuildRmt2Options(sourceRmt2Desc, blamRenderMethodName);
            tagName = $"shaders\\{sourceRmt2Desc.Type}_templates\\_{string.Join("_", sourceRmt2Desc.Options)}";

            // if using a shader cache, try and find it there
            if (ShaderCache.ExportTemplate(BaseCacheStream, BaseCache, tagName, out CachedTag cachedRmt2Tag))
            {
                if (PortContext.FlagIsSet(PortingFlags.Print))
                    Console.WriteLine($"['{cachedRmt2Tag.Group.Tag}', 0x{cachedRmt2Tag.Index:X4}] {cachedRmt2Tag.Name}.{(cachedRmt2Tag.Group as Cache.Gen3.TagGroupGen3).Name}");
                isExactMatch = true;
                return cachedRmt2Tag;
            }

            SortingInterface sorter = GetSorter(sourceRmt2Desc.Type);
            long minDistance = long.MaxValue;
            CachedTag bestTag = null;

            // search
            foreach (CachedTag rmt2Tag in BaseCache.TagCache.TagTable)
            {
                if (rmt2Tag == null || rmt2Tag.Group.Tag != "rmt2")
                    continue;

                if (!Rmt2Descriptor.TryParse(rmt2Tag.Name, out Rmt2Descriptor destRmt2Desc))
                    continue;

                // ignore ms30 templates if desired
                if (!UseMs30 && destRmt2Desc.IsMs30)
                    continue;

                // ignore templates that are not of the same type
                if (destRmt2Desc.Type != sourceRmt2Desc.Type)
                    continue;

                // match the options from the rmt2 tag names
                if (sourceRmt2Desc.Options.AsSpan().SequenceEqual(destRmt2Desc.Options))
                {
                    isExactMatch = true;
                    return rmt2Tag;
                }

                // if not exact match determine how close it is
                if (sorter != null && !PerfectMatchesOnly)
                {
                    long targetValue = Sorter.GetValue(sorter, sourceRmt2Desc.Options);
                    long value = Sorter.GetValue(sorter, destRmt2Desc.Options);
                    long distance = Math.Abs(value - targetValue);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        bestTag = rmt2Tag;
                    }
                }
            }

            return bestTag;
        }


        public Task<TemplateConversionResult> GenerateTemplateAsync(Stream cacheStream, string tagName, out CachedTag generatedRmt2)
        {
            generatedRmt2 = null;

            if (!Rmt2Descriptor.TryParse(tagName, out Rmt2Descriptor rmt2Desc))
            {
                Log.Error($"Invalid rmt2 tag name {tagName}");
                throw new InvalidOperationException();
            }

            if (!RenderMethodDefinitions.ContainsKey(rmt2Desc.Type))
            {
                Log.Error($"No rmdf tag present for {rmt2Desc.Type}");
                throw new InvalidOperationException();
            }

            RenderMethodDefinition rmdf = RenderMethodDefinitions[rmt2Desc.Type];
      
            var glps = BaseCache.Deserialize<GlobalPixelShader>(BaseCacheStream, rmdf.GlobalPixelShader);
            var glvs = BaseCache.Deserialize<GlobalVertexShader>(BaseCacheStream, rmdf.GlobalVertexShader);

            // get options in numeric array
            List<byte> options = new List<byte>();
            foreach (var option in tagName.Split('\\')[2].Remove(0, 1).Split('_'))
                options.Add(byte.Parse(option));

            var allRmopParameters = ShaderGenerator.ShaderGeneratorNew.GatherParametersAsync(RenderMethodOptions, rmdf, options);

            CachedTag rmt2Tag = BaseCache.TagCache.AllocateTag<RenderMethodTemplate>(tagName);
            generatedRmt2 = rmt2Tag;


            return PortContext.RunOnThreadPool(() => 
                {
                    var result = new TemplateConversionResult();

                    result.Tag = rmt2Tag;
                    result.Definition = ShaderGenerator.ShaderGeneratorNew.GenerateTemplate(BaseCache,
                        rmdf, glvs, glps, allRmopParameters, tagName, out result.PixelShaderDefinition, out result.VertexShaderDefinition);

                    return result;
                })
                .ContinueWith(task =>
                    {
                        TemplateConversionResult result = task.Result;
                        var asyncRmt2 = result.Definition;
                        var asyncPixl = result.PixelShaderDefinition;
                        var asyncVtsh = result.VertexShaderDefinition;

                        if (!BaseCache.TagCache.TryGetTag(tagName + ".pixl", out asyncRmt2.PixelShader))
                            asyncRmt2.PixelShader = BaseCache.TagCache.AllocateTag<PixelShader>(tagName);
                        if (!BaseCache.TagCache.TryGetTag(tagName + ".vtsh", out asyncRmt2.VertexShader))
                            asyncRmt2.VertexShader = BaseCache.TagCache.AllocateTag<VertexShader>(tagName);

                        BaseCache.Serialize(cacheStream, asyncRmt2.PixelShader, asyncPixl);
                        BaseCache.Serialize(cacheStream, asyncRmt2.VertexShader, asyncVtsh);
                        BaseCache.Serialize(cacheStream, result.Tag, asyncRmt2);

                        if (PortContext.FlagIsSet(PortingFlags.Print))
                            Console.WriteLine($"['{result.Tag.Group.Tag}', 0x{result.Tag.Index:X4}] {result.Tag.Name}.{(result.Tag.Group as Cache.Gen3.TagGroupGen3).Name}");

                        return result;
                    },
                    PortContext.MainThreadScheduler);
        }

        private static SortingInterface GetSorter(string type) => type switch
        {
            "beam" => new BeamSorter(),
            "contrail" => new ContrailSorter(),
            "shader" => new ShaderSorter(),
            "halogram" => new HalogramSorter(),
            "terrain" => new TerrainSorter(),
            "particle" => new ParticleSorter(),
            "light_volume" => new LightVolumeSorter(),
            "foliage" => new FoliageSorter(),
            "decal" => new DecalSorter(),
            "screen" => new ScreenSorter(),
            "water" => new WaterSorter(),
            _ => null,
        };

        /// <summary>
        /// Rebuilds an rmt2's options in memory so indices match up with the base cache
        /// </summary>
        private Rmt2Descriptor RebuildRmt2Options(Rmt2Descriptor srcRmt2Descriptor, string renderMethodName)
        {
            if (srcRmt2Descriptor.Type != "black" && PortingCache.Version >= CacheVersion.Halo3Beta)
            {
                string rmdfName = $"shaders\\{srcRmt2Descriptor.Type}.rmdf";
                if (!RenderMethodDefinitions.ContainsKey(srcRmt2Descriptor.Type) || !PortingRenderMethodDefinitions.ContainsKey(srcRmt2Descriptor.Type))
                    return srcRmt2Descriptor;

                var baseRmdfDefinition = RenderMethodDefinitions[srcRmt2Descriptor.Type];
                var portingRmdfDefinition = PortingRenderMethodDefinitions[srcRmt2Descriptor.Type];

                List<byte> newOptions = new List<byte>();

                // get option indices (if we loop by basecache rmdf, the options will always be correct length and index)
                for (int i = 0; i < baseRmdfDefinition.Categories.Count; i++)
                {
                    byte option = 0;

                    string methodName = BaseCache.StringTable.GetString(baseRmdfDefinition.Categories[i].Name);

                    if (PortingCache.Version >= CacheVersion.HaloReach && methodName == "reach_compatibility")
                    {
                        if (portingRmdfDefinition.GetCategoryOption(PortingCache, "detail", srcRmt2Descriptor.Options) == "repeat")
                        {
                            int potentialIndex = baseRmdfDefinition.GetCategoryOptionIndex(BaseCache, "reach_compatibility", "enabled_detail_repeat");
                            newOptions.Add(potentialIndex != -1 ? (byte)potentialIndex : (byte)1);
                        }
                        else
                        {
                            newOptions.Add(1);
                        }
                        continue;
                    }

                    for (int j = 0; j < portingRmdfDefinition.Categories.Count; j++)
                    {
                        if (methodName != PortingCache.StringTable.GetString(portingRmdfDefinition.Categories[j].Name))
                            continue;

                        int portingOptionIndex = srcRmt2Descriptor.Options[j];
                        string optionName = PortingCache.StringTable.GetString(portingRmdfDefinition.Categories[j].ShaderOptions[portingOptionIndex].Name);

                        // these are perfect option matches
                        // do not touch unless verified
                        if (srcRmt2Descriptor.Type == "shader")
                        {
                            if (methodName == "self_illumination" && optionName == "change_color")
                                optionName = "illum_change_color";
                        }
                        if (methodName == "misc" && optionName == "default")
                            optionName = "always_calc_albedo";
                        if (methodName == "alpha_test" && optionName == "from_texture")
                            optionName = "simple";
                        //if (PortingCache.Version == CacheVersion.Halo3ODST && methodName == "material_model" && optionName == "cook_torrance")
                        //    optionName = "cook_torrance_odst";
                        //if (methodName == "material_model" && optionName == "cook_torrance_rim_fresnel")
                        //    optionName = "cook_torrance";

                        // Workaround for H3/ODST content bug
                        if (srcRmt2Descriptor.Type == "decal" && methodName == "bump_mapping" && (PortingCache.Version == CacheVersion.Halo3Retail || PortingCache.Version == CacheVersion.Halo3ODST))
                        {
                            if (ContentBugDecals.Contains(renderMethodName) && (optionName == "standard" || optionName == "standard_mask"))
                            {
                                optionName += "_diffuse";
                            }
                        }

                        if (PortingCache.Version == CacheVersion.HaloReach)
                        {
                            // keep in sync with cubemap conversion - not needed anymore?
                            //if (methodName == "environment_mapping" && optionName == "dynamic")
                            //{
                            //    optionName = "dynamic_reach";
                            //}
                            if (methodName == "material_model")
                            {
                                if (optionName == "cook_torrance")
                                    optionName = "cook_torrance_reach";
                                else if (optionName == "two_lobe_phong")
                                    optionName = "two_lobe_phong_reach";
                                //else if (optionName == "organism")
                                //    optionName = "organism_reach";
                            }
                        }

                        // TODO: fill this switch, Reach shadergen might take some time...
                        // fixup names (remove when full rmdf + shader generation for each gen3 game)
                        switch ($"{methodName}\\{optionName}")
                        {
                            // Reach rmsh //
                            case @"albedo\patchy_emblem":
                                optionName = "emblem_change_color";
                                break;
                            case @"bump_mapping\detail_blend":
                            case @"bump_mapping\three_detail_blend":
                                optionName = "detail";
                                break;
                            case @"specular_mask\specular_mask_mult_diffuse":
                                optionName = "specular_mask_from_texture";
                                break;
                            // Reach rmtr  //
                            case @"blending\distance_blend_base":
                                optionName = "morph";
                                break;
                            // Reach rmfl //
                            case @"material_model\flat":
                            case @"material_model\specular":
                            case @"material_model\translucent":
                                optionName = "default";
                                break;
                            // Reach prt3 //
                            case @"lighting\per_pixel_smooth":
                            case @"lighting\smoke_lighting":
                                optionName = "per_pixel_ravi_order_3";
                                break;
                            case @"lighting\per_vertex_ambient":
                                optionName = "per_vertex_ravi_order_0";
                                break;
                            case @"depth_fade\low_res":
                                optionName = "on";
                                break;
                        }

                        bool matchFound = false;
                        // get basecache option index
                        for (int k = 0; k < baseRmdfDefinition.Categories[i].ShaderOptions.Count; k++)
                        {
                            if (optionName == BaseCache.StringTable.GetString(baseRmdfDefinition.Categories[i].ShaderOptions[k].Name))
                            {
                                option = (byte)k;
                                matchFound = true;
                                break;
                            }
                        }

                        if (!matchFound)
                        {
                            Log.Warning($"Unrecognized {srcRmt2Descriptor.Type} method option \"{methodName}\\{optionName}\"");
                        }
                        break;
                    }
                    newOptions.Add(option);
                }

                srcRmt2Descriptor.Options = newOptions.ToArray();
            }

            return srcRmt2Descriptor;
        }

        public class Rmt2Pairing
        {
            public Rmt2ParameterMatch RealParams;
            public Rmt2ParameterMatch IntParams;
            public Rmt2ParameterMatch BoolParams;
            public Rmt2ParameterMatch TextureParams;
            public int CommonOptions;
            public int Score;
            public CachedTag DestTag;
            public CachedTag SourceTag;

            public int CommonParameters =>
                  RealParams.Common
                + TextureParams.Common
                + IntParams.Common
                + BoolParams.Common;

            public int MissingFromSource =>
                  RealParams.MissingFromSource
                + TextureParams.MissingFromSource
                + IntParams.MissingFromSource
                + BoolParams.MissingFromSource;

            public int MissingFromDest =>
                  RealParams.MissingFromDest
                + TextureParams.MissingFromDest
                + IntParams.MissingFromDest
                + BoolParams.MissingFromDest;
        }

        public struct Rmt2ParameterMatch
        {
            public int MissingFromSource;
            public int MissingFromDest;
            public int Common;
            public int SourceCount;
            public int DestCount;
        }

        public struct Rmt2Descriptor
        {
            public DescriptorFlags Flags;
            public string Type;
            public byte[] Options;
            private bool HasParsed;

            [Flags]
            public enum DescriptorFlags
            {
                None = 0,
                Ms30 = (1 << 0)
            }

            public Rmt2Descriptor(string type, byte[] options)
            {
                Type = type;
                Options = options;
                HasParsed = true;
                Flags = DescriptorFlags.None;
            }

            public bool IsMs30 => Flags.HasFlag(DescriptorFlags.Ms30);

            public string GetRmdfName()
            {
                if (!HasParsed)
                    return null;
                return $"{(IsMs30 ? "ms30\\" : "")}shaders\\{Type}";
            }

            public static bool TryParse(string name, out Rmt2Descriptor descriptor)
            {
                descriptor = new Rmt2Descriptor();

                descriptor.HasParsed = false;

                var parts = name.Split(new string[] { "shaders\\" }, StringSplitOptions.None);

                var prefixParts = parts[0].Split('\\');
                if (prefixParts.Length > 0 && prefixParts[0] == "ms30")
                    descriptor.Flags |= DescriptorFlags.Ms30;

                if (parts.Length < 2)
                    return false;
                var nameParts = parts[1].Split('\\');
                if (nameParts.Length < 2)
                    return false;

                descriptor.Type = nameParts[0].Substring(0, nameParts[0].Length-10);
                descriptor.Options = nameParts[1].Split('_').Skip(1).Select(x => byte.Parse(x)).ToArray();
                descriptor.HasParsed = true;

                return true;
            }

            public HaloShaderGenerator.Generator.IShaderGenerator GetGenerator(bool applyFixes = false)
            {
                if (HasParsed && !IsMs30)
                {
                    switch (Type)
                    {
                        case "beam":            return new HaloShaderGenerator.Beam.BeamGenerator(Options, applyFixes);
                        case "black":           return new HaloShaderGenerator.Black.ShaderBlackGenerator();
                        case "contrail":        return new HaloShaderGenerator.Contrail.ContrailGenerator(Options, applyFixes);
                        case "cortana":         return new HaloShaderGenerator.Cortana.CortanaGenerator(Options, applyFixes);
                        case "custom":          return new HaloShaderGenerator.Custom.CustomGenerator(Options, applyFixes);
                        case "decal":           return new HaloShaderGenerator.Decal.DecalGenerator(Options, applyFixes);
                        case "foliage":         return new HaloShaderGenerator.Foliage.FoliageGenerator(Options, applyFixes);
                        //case "glass":           return new HaloShaderGenerator.Glass.GlassGenerator(Options, applyFixes);
                        case "halogram":        return new HaloShaderGenerator.Halogram.HalogramGenerator(Options, applyFixes);
                        case "light_volume":    return new HaloShaderGenerator.LightVolume.LightVolumeGenerator(Options, applyFixes);
                        case "particle":        return new HaloShaderGenerator.Particle.ParticleGenerator(Options, applyFixes);
                        case "screen":          return new HaloShaderGenerator.Screen.ScreenGenerator(Options, applyFixes);
                        case "shader":          return new HaloShaderGenerator.Shader.ShaderGenerator(Options, applyFixes);
                        case "terrain":         return new HaloShaderGenerator.Terrain.TerrainGenerator(Options, applyFixes);
                        case "water":           return new HaloShaderGenerator.Water.WaterGenerator(Options, applyFixes);
                        case "zonly":           return new HaloShaderGenerator.ZOnly.ZOnlyGenerator(Options, applyFixes);
                    }

                    Console.WriteLine($"\"{Type}\" shader generation is currently unsupported.");
                    return null;
                }

                Console.WriteLine("Invalid descriptor.");
                return null;
            }
        }

        public CachedTag FindRmdf(CachedTag matchedRmt2Tag)
        {
            Rmt2Descriptor rmt2Description;
            if (!Rmt2Descriptor.TryParse(matchedRmt2Tag.Name, out rmt2Description))
                throw new ArgumentException($"Invalid rmt2 name '{matchedRmt2Tag.Name}'", nameof(matchedRmt2Tag));

            string prefix = matchedRmt2Tag.Name.StartsWith("ms30") ? "ms30\\" : "";
            string type = rmt2Description.Type; // remove _templates
            string rmdfName = $"{prefix}shaders\\{type}";

            return BaseCache.TagCache.GetTag(rmdfName, "rmdf");
        }
    }
}
