using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using System.Collections.Generic;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void ImportAnimations() 
        {
            CommandRunner.Current.RunCommand($@"edittag objects\characters\masterchief\masterchief.model_animation_graph");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\combat thunderclap.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any dance1test.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any dance1.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any mixamo.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any fingerlay.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any fingerstand.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any breakdance.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any twerk.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any hiphop.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Spartan\\any any ballskick.JMM\"");
            ContextStack.Pop();

            CommandRunner.Current.RunCommand($@"edittag objects\characters\elite\elite.model_animation_graph");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat thunderclap.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any dance1test.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any dance1.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any mixamo.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any fingerlay.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any fingerstand.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any breakdance.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any twerk.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any hiphop.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\any any ballskick.JMM\"");
            ContextStack.Pop();


            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("jmad") && tag.Name == $@"objects\characters\masterchief\masterchief") 
                    {
                        var jmad = CacheContext.Deserialize<ModelAnimationGraph>(stream, tag);
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
                        CacheContext.Serialize(stream, tag, jmad);
                    }

                    if (tag.IsInGroup("jmad") && tag.Name == $@"objects\characters\elite\elite")
                    {
                        var jmad = CacheContext.Deserialize<ModelAnimationGraph>(stream, tag);
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
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"armor_lock_enter"),
                            //    GraphIndex = -1,
                            //    Animation = 91,
                            //},
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"armor_lock_exit"),
                            //    GraphIndex = -1,
                            //    Animation = 92,
                            //},
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"armor_lock_idle"),
                            //    GraphIndex = -1,
                            //    Animation = 93,
                            //},
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"con_blast_enter"),
                            //    GraphIndex = -1,
                            //    Animation = 123,
                            //},
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"mag_pulse_enter"),
                            //    GraphIndex = -1,
                            //    Animation = 238,
                            //},
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
                        CacheContext.Serialize(stream, tag, jmad);
                    }

                    if (tag.IsInGroup("jmad") && tag.Name == $@"objects\characters\dervish\dervish")
                    {
                        var jmad = CacheContext.Deserialize<ModelAnimationGraph>(stream, tag);
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
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"armor_lock_enter"),
                            //    GraphIndex = 0,
                            //    Animation = 1607,
                            //},
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"armor_lock_exit"),
                            //    GraphIndex = 0,
                            //    Animation = 1608,
                            //},
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"armor_lock_idle"),
                            //    GraphIndex = 0,
                            //    Animation = 1609,
                            //},
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"con_blast_enter"),
                            //    GraphIndex = 0,
                            //    Animation = 1610,
                            //},
                            //new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            //{
                            //    Label = CacheContext.StringTable.GetStringId($@"mag_pulse_enter"),
                            //    GraphIndex = 0,
                            //    Animation = 1611,
                            //},
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
                        CacheContext.Serialize(stream, tag, jmad);
                    }
                }
            }
        }
    }
}