using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Tags.Definitions;
using System.IO;
using System.Collections.Generic;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.ConvertCache.Tags 
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

            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat thunderclap.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any dance1test.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any dance1.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any mixamo.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any fingerlay.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any fingerstand.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any breakdance.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any twerk.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any hiphop.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any ballskick.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat armor_lock_enter.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat armor_lock_exit.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat armor_lock_idle.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat con_blast_enter.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat con_blast_exit.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat mag_pulse_enter.JMM");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint ball any move_front.JMA");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint hammer any move_front.JMA");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint missile any move_front.JMA");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint pistol any move_front.JMA");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint rifle any move_front.JMA");
            AddAnimation(tag, $"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint sword any move_front.JMA");

            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(Stream, tag);
            jmad.EffectReferences = new List<ModelAnimationGraph.AnimationTagReference> 
            {
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"objects\weapons\melee\gravity_hammer\fx\gravity_hammer_impact"),
                },
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"fx\scenery_fx\morph\morph_medium\morph_to_medium_elite"),
                },
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"objects\characters\masterchief\damage_effects\wraith_board_melee"),
                },
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"objects\characters\masterchief\damage_effects\scorpion_board_melee"),
                },
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"objects\characters\masterchief\damage_effects\assassination_hit_0"),
                },
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"objects\characters\masterchief\damage_effects\assassination_hit_1"),
                },
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"objects\characters\masterchief\damage_effects\assassination_hit_2"),
                },
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"objects\characters\masterchief\damage_effects\assassination_hit_3"),
                },
                new ModelAnimationGraph.AnimationTagReference
                {
                    Reference = GetCachedTag<Effect>($@"objects\characters\masterchief\damage_effects\concussive_blast"),
                },
            };
            jmad.Animations[1610].PlaybackFlags = ModelAnimationGraph.Animation.PlaybackFlagsValue.DisableWeaponIk;
            jmad.Animations[1610].AnimationData.EffectEvents = new List<ModelAnimationGraph.Animation.EffectEvent> 
            {
                new ModelAnimationGraph.Animation.EffectEvent
                {
                    Effect = 8,
                    Frame = 16,
                    MarkerName = CacheContext.StringTable.GetStringId($@"shield_recharge"),
                    DamageEffectReportingType = new Damage.DamageReportingType
                    {
                        HaloOnline = Damage.DamageReportingType.HaloOnlineValue.Guardians,
                    },
                },
            };
            jmad.Modes[3].WeaponClass[1].WeaponType[0].Set.Actions = new List<ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry>
            {
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"airborne_dead"),
                    GraphIndex = -1,
                    Animation = 109,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"landing_dead"),
                    GraphIndex = -1,
                    Animation = 252,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_enter"),
                    GraphIndex = -1,
                    Animation = 1607,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_exit"),
                    GraphIndex = -1,
                    Animation = 1608,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"armor_lock_idle"),
                    GraphIndex = -1,
                    Animation = 1609,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"con_blast_enter"),
                    GraphIndex = -1,
                    Animation = 1610,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"con_blast_exit"),
                    GraphIndex = -1,
                    Animation = 1611,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"mag_pulse_enter"),
                    GraphIndex = -1,
                    Animation = 1612,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"thunder_clap"),
                    GraphIndex = -1,
                    Animation = 1597,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"twerk"),
                    GraphIndex = -1,
                    Animation = 1604,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"dance1test"),
                    GraphIndex = -1,
                    Animation = 1598,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"dance1"),
                    GraphIndex = -1,
                    Animation = 1599,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"mixamo"),
                    GraphIndex = -1,
                    Animation = 1600,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"fingerlay"),
                    GraphIndex = -1,
                    Animation = 1601,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"fingerstand"),
                    GraphIndex = -1,
                    Animation = 1602,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"breakdance"),
                    GraphIndex = -1,
                    Animation = 1603,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"hiphop"),
                    GraphIndex = -1,
                    Animation = 1605,
                },
                new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                {
                    Label = CacheContext.StringTable.GetStringId($@"ballskick"),
                    GraphIndex = -1,
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
                                            GraphIndex = -1,
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
                                            GraphIndex = -1,
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
                                            GraphIndex = -1,
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
                                            GraphIndex = -1,
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
                                            GraphIndex = -1,
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
                                            GraphIndex = -1,
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
