using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
{
    public class objects_characters_masterchief_masterchief_model_animation_graph : TagFile
    {
        public objects_characters_masterchief_masterchief_model_animation_graph(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream) : base
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
            var tag = GetCachedTag<ModelAnimationGraph>($@"objects\characters\masterchief\masterchief");

            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\combat thunderclap.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any dance1test.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any dance1.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any mixamo.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any fingerlay.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any fingerstand.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any breakdance.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any twerk.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any hiphop.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any ballskick.JMM");

            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(Stream, tag);
            jmad.Modes[0].WeaponClass[1].WeaponType[0].Set.Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry> 
            {
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"airborne_dead"),
                    GraphIndex = -1,
                    Animation = 88,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"landing_dead"),
                    GraphIndex = -1,
                    Animation = 89,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_enter"),
                    GraphIndex = -1,
                    Animation = 91,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_exit"),
                    GraphIndex = -1,
                    Animation = 92,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_idle"),
                    GraphIndex = -1,
                    Animation = 93,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"con_blast_enter"),
                    GraphIndex = -1,
                    Animation = 123,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"mag_pulse_enter"),
                    GraphIndex = -1,
                    Animation = 238,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"thunder_clap"),
                    GraphIndex = -1,
                    Animation = 1173,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"twerk"),
                    GraphIndex = -1,
                    Animation = 1180,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"dance1test"),
                    GraphIndex = -1,
                    Animation = 1174,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"dance1"),
                    GraphIndex = -1,
                    Animation = 1175,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"mixamo"),
                    GraphIndex = -1,
                    Animation = 1176,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"fingerlay"),
                    GraphIndex = -1,
                    Animation = 1177,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"fingerstand"),
                    GraphIndex = -1,
                    Animation = 1178,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"breakdance"),
                    GraphIndex = -1,
                    Animation = 1179,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"hiphop"),
                    GraphIndex = -1,
                    Animation = 1181,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"ballskick"),
                    GraphIndex = -1,
                    Animation = 1182,
                },
            };
            CacheContext.Serialize(Stream, tag, jmad);
        }
    }
}
