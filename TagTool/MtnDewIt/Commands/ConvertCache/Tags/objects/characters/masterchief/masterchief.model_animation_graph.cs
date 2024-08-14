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

            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\thunderclap.JMM");
            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\fresh.JMM");
            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\orangejustice.JMM");
            AddAnimation(tag, $@"{Program.TagToolDirectory}\Tools\JSON\data\{tag.Name}\electroswing.JMM");

            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(Stream, tag);
            jmad.Modes[0].WeaponClass[1].WeaponType[0].Set.Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry> 
            {
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"airborne_dead"),
                    GraphIndex = -1,
                    Animation = 88,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"landing_dead"),
                    GraphIndex = -1,
                    Animation = 89,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"armor_lock_enter"),
                    GraphIndex = -1,
                    Animation = 91,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"armor_lock_exit"),
                    GraphIndex = -1,
                    Animation = 92,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"armor_lock_idle"),
                    GraphIndex = -1,
                    Animation = 93,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"con_blast_enter"),
                    GraphIndex = -1,
                    Animation = 123,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"mag_pulse_enter"),
                    GraphIndex = -1,
                    Animation = 238,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"thunder_clap"),
                    GraphIndex = -1,
                    Animation = 1173,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"fresh"),
                    GraphIndex = -1,
                    Animation = 1174,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"orange_justice"),
                    GraphIndex = -1,
                    Animation = 1175,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetOrAddString($@"electro_swing"),
                    GraphIndex = -1,
                    Animation = 1176,
                },
            };
            CacheContext.Serialize(Stream, tag, jmad);
        }
    }
}
