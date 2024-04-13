using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_render_model : TagFile
    {
        public levels_ui_mainmenu_objects_odst_recon_cheap_odst_recon_cheap_render_model(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<RenderModel>($@"levels\ui\mainmenu\objects\odst_recon_cheap\odst_recon_cheap");
            var mode = CacheContext.Deserialize<RenderModel>(Stream, tag);
            mode.Regions = new List<RenderModel.Region>
            {
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"badge"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            MeshCount = 1
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"body"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            MeshIndex = 1,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"chest"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"broken"),
                            MeshIndex = 16,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            MeshIndex = 16,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    
                },
                new RenderModel.Region
                {
                    
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"emblem"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dutch"),
                            MeshIndex = 5,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            MeshIndex = 25,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            MeshIndex = 25,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"gear"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mickey"),
                            MeshIndex = 6,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"romeo"),
                            MeshIndex = 18,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dutch"),
                            MeshIndex = 26,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"sergeant"),
                            MeshIndex = 29,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            MeshIndex = 32,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"johnson"),
                            MeshIndex = 35,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"hands"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            MeshIndex = 7,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"head"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"johnson"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"sergeant"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"romeo"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mickey"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dutch"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"headgear"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"mickey"),
                            MeshIndex = 9,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"romeo"),
                            MeshIndex = 20,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"dutch"),
                            MeshIndex = 28,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"sergeant"),
                            MeshIndex = 31,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            MeshIndex = 34,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"helmet"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            MeshIndex = 10,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            MeshIndex = 10,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"knife"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"on"),
                            MeshIndex = 22,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            MeshIndex = 22,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"l_shoulder"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            MeshIndex = 12,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetOrAddString($@"r_shoulder"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"standard"),
                            MeshIndex = 13,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetOrAddString($@"off"),
                            MeshIndex = 23,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    
                },
                new RenderModel.Region
                {
                    
                },
            };
            CacheContext.Serialize(Stream, tag, mode);
        }
    }
}
