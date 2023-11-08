using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_dervish_dervish_model_animation_graph : TagFile
    {
        public objects_characters_dervish_dervish_model_animation_graph(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ModelAnimationGraph>($@"objects\characters\dervish\dervish");
            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(Stream, tag);
            jmad.Modes[3].WeaponClass[1].WeaponType[0].Set.Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
            {
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"airborne_dead"),
                    GraphIndex = 0,
                    Animation = 109,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"landing_dead"),
                    GraphIndex = 0,
                    Animation = 252,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_enter"),
                    GraphIndex = 0,
                    Animation = 1607,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_exit"),
                    GraphIndex = 0,
                    Animation = 1608,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_idle"),
                    GraphIndex = 0,
                    Animation = 1609,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"con_blast_enter"),
                    GraphIndex = 0,
                    Animation = 1610,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"con_blast_exit"),
                    GraphIndex = 0,
                    Animation = 1611,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"mag_pulse_enter"),
                    GraphIndex = 0,
                    Animation = 1612,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"thunder_clap"),
                    GraphIndex = 0,
                    Animation = 1597,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"twerk"),
                    GraphIndex = 0,
                    Animation = 1604,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"dance1test"),
                    GraphIndex = 0,
                    Animation = 1598,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"dance1"),
                    GraphIndex = 0,
                    Animation = 1599,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"mixamo"),
                    GraphIndex = 0,
                    Animation = 1600,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"fingerlay"),
                    GraphIndex = 0,
                    Animation = 1601,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"fingerstand"),
                    GraphIndex = 0,
                    Animation = 1602,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"breakdance"),
                    GraphIndex = 0,
                    Animation = 1603,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"hiphop"),
                    GraphIndex = 0,
                    Animation = 1605,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"ballskick"),
                    GraphIndex = 0,
                    Animation = 1606,
                },
            };
            jmad.Modes.Add(new ModelAnimationGraph.Mode
            {
                Name = CacheContext.StringTable.GetStringId("sprint"),
                WeaponClass = new List<ModelAnimationGraph.Mode.WeaponClassBlock>
                {
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetStringId("missile"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetStringId("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetStringId("move_front"),
                                            GraphIndex = 0,
                                            Animation = 1615,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetStringId("rifle"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetStringId("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetStringId("move_front"),
                                            GraphIndex = 0,
                                            Animation = 1617,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetStringId("pistol"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetStringId("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetStringId("move_front"),
                                            GraphIndex = 0,
                                            Animation = 1616,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetStringId("sword"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetStringId("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetStringId("move_front"),
                                            GraphIndex = 0,
                                            Animation = 1618,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetStringId("ball"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetStringId("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetStringId("move_front"),
                                            GraphIndex = 0,
                                            Animation = 1613,
                                        },
                                    },
                                },
                            },
                        },
                    },
                    new ModelAnimationGraph.Mode.WeaponClassBlock
                    {
                        Label = CacheContext.StringTable.GetStringId("hammer"),
                        WeaponType = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock>
                        {
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock
                            {
                                Label = CacheContext.StringTable.GetStringId("any"),
                                Set = new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
                                {
                                    Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
                                    {
                                        new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = CacheContext.StringTable.GetStringId("move_front"),
                                            GraphIndex = 0,
                                            Animation = 1614,
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
