using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
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
                    Name = CacheContext.StringTable.GetStringId($@"badge"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"standard"),
                            MeshCount = 1
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"body"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"standard"),
                            MeshIndex = 1,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"chest"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"broken"),
                            MeshIndex = 16,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"standard"),
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
                    Name = CacheContext.StringTable.GetStringId($@"emblem"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"dutch"),
                            MeshIndex = 5,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"on"),
                            MeshIndex = 25,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"off"),
                            MeshIndex = 25,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"gear"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"mickey"),
                            MeshIndex = 6,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"romeo"),
                            MeshIndex = 18,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"dutch"),
                            MeshIndex = 26,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"sergeant"),
                            MeshIndex = 29,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"standard"),
                            MeshIndex = 32,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"johnson"),
                            MeshIndex = 35,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"hands"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"standard"),
                            MeshIndex = 7,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"head"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"johnson"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"sergeant"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"romeo"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"mickey"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"dutch"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"off"),
                            MeshIndex = 36,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"headgear"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"mickey"),
                            MeshIndex = 9,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"romeo"),
                            MeshIndex = 20,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"dutch"),
                            MeshIndex = 28,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"sergeant"),
                            MeshIndex = 31,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"off"),
                            MeshIndex = 34,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"helmet"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"standard"),
                            MeshIndex = 10,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"off"),
                            MeshIndex = 10,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"knife"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"on"),
                            MeshIndex = 22,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"off"),
                            MeshIndex = 22,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"l_shoulder"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"standard"),
                            MeshIndex = 12,
                            MeshCount = 1,
                        },
                    },
                },
                new RenderModel.Region
                {
                    Name = CacheContext.StringTable.GetStringId($@"r_shoulder"),
                    Permutations = new List<RenderModel.Region.Permutation>
                    {
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"standard"),
                            MeshIndex = 13,
                            MeshCount = 1,
                        },
                        new RenderModel.Region.Permutation
                        {
                            Name = CacheContext.StringTable.GetStringId($@"off"),
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
