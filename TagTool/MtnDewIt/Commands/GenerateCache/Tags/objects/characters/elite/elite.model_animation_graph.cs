using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache.Tags 
{
    public class objects_characters_elite_elite_model_animation_graph : TagFile
    {
        public objects_characters_elite_elite_model_animation_graph(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ModelAnimationGraph>($@"objects\characters\elite\elite");

            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\sprint ball any move_front.JMA");
            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\sprint hammer any move_front.JMA");
            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\sprint missile any move_front.JMA");
            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\sprint pistol any move_front.JMA");
            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\sprint rifle any move_front.JMA");
            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\sprint sword any move_front.JMA");

            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(Stream, tag);
            jmad.Modes.Add(new ModelAnimationGraph.Mode
            {
                Name = CacheContext.StringTable.GetOrAddString("sprint"),
                WeaponClass = new List<ModelAnimationGraph.Mode.WeaponClassBlock>
                {
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetOrAddString("missile"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetOrAddString("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetOrAddString("move_front"),
                                            GraphIndex = -1,
                                            Animation = 1605,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetOrAddString("rifle"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetOrAddString("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetOrAddString("move_front"),
                                            GraphIndex = -1,
                                            Animation = 1607,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetOrAddString("pistol"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetOrAddString("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetOrAddString("move_front"),
                                            GraphIndex = -1,
                                            Animation = 1606,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetOrAddString("sword"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetOrAddString("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetOrAddString("move_front"),
                                            GraphIndex = -1,
                                            Animation = 1608,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetOrAddString("ball"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetOrAddString("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetOrAddString("move_front"),
                                            GraphIndex = -1,
                                            Animation = 1603,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetOrAddString("hammer"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetOrAddString("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetOrAddString("move_front"),
                                            GraphIndex = -1,
                                            Animation = 1604,
                                        },
                                    },
                                },
                            },
                        },
                    },
                },
            });
            CacheContext.Serialize(Stream, tag, jmad);

            SortModes(tag);
        }
    }
}
