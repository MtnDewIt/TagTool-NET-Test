using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags
{
    public class levels_ui_mainmenu_objects_spartan_cheap_spartan_cheap_model : TagFile
    {
        public levels_ui_mainmenu_objects_spartan_cheap_spartan_cheap_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
        (
            cache,
            cacheContext,
            stream
        )
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
            TagData();
        }

        public override void TagData()
        {
            var tag = GetCachedTag<Model>($@"levels\ui\mainmenu\objects\spartan_cheap\spartan_cheap");
            var hlmt = CacheContext.Deserialize<Model>(Stream, tag);
            hlmt.Variants = new List<Model.Variant>
            {
                new Model.Variant
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"menu_spartan1"),
                    ModelRegionIndices = new sbyte[16]
                    {
                        2, 1, 6, 7, 0, 4, 3, 5, -1, -1,
                        -1, -1, -1, -1, -1, -1,
                    },
                    Regions = new List<Model.Variant.Region>
                    {
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"helmet"),
                            RenderModelRegionIndex = 4,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"mp_markv"),
                                    RenderModelPermutationIndex = 9,
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"body"),
                            RenderModelRegionIndex = 1,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"base"),
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"arms"),
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"base"),
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"legs"),
                            RenderModelRegionIndex = 6,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"base"),
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                            RenderModelRegionIndex = 5,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                                    RenderModelPermutationIndex = 7,
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                            RenderModelRegionIndex = 7,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"mp_scout"),
                                    RenderModelPermutationIndex = 7,
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"chest"),
                            RenderModelRegionIndex = 2,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                                    RenderModelPermutationIndex = 0,
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"decals"),
                            RenderModelRegionIndex = 3,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"base"),
                                    Probability = 1f,
                                },
                            },
                        },
                    },
                },
                new Model.Variant
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"menu_spartan2"),
                    ModelRegionIndices = new sbyte[16]
                    {
                        2, 1, 6, 7, 0, 4, 3, 5, -1, -1,
                        -1, -1, -1, -1, -1, -1,
                    },
                    Regions = new List<Model.Variant.Region>
                    {
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"helmet"),
                            RenderModelRegionIndex = 4,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"mp_intruder"),
                                    RenderModelPermutationIndex = 3,
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"body"),
                            RenderModelRegionIndex = 1,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"base"),
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"arms"),
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"base"),
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"legs"),
                            RenderModelRegionIndex = 6,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"base"),
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"leftshoulder"),
                            RenderModelRegionIndex = 5,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                                    RenderModelPermutationIndex = 1,
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"rightshoulder"),
                            RenderModelRegionIndex = 7,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"mp_cobra"),
                                    RenderModelPermutationIndex = 1,
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"chest"),
                            RenderModelRegionIndex = 2,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"mp_ninja"),
                                    RenderModelPermutationIndex = 2,
                                    Probability = 1f,
                                },
                            },
                        },
                        new Model.Variant.Region
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"decals"),
                            RenderModelRegionIndex = 3,
                            Permutations = new List<Model.Variant.Region.Permutation>
                            {
                                new Model.Variant.Region.Permutation
                                {
                                    Name = CacheContext.StringTable.GetOrAddString($@"base"),
                                    Probability = 1f,
                                },
                            },
                        },
                    },
                },
            };
            CacheContext.Serialize(Stream, tag, hlmt);
        }
    }
}
