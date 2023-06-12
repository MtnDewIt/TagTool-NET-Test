using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using System.Collections.Generic;

namespace TagTool.Commands.Tags
{
    partial class BaseCacheCommand : Command
    {
        public void ImportAnimations() 
        {
            CommandRunner.Current.RunCommand($@"edittag objects\characters\masterchief\masterchief.model_animation_graph");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\combat thunderclap.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any dance1test.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any dance1.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any mixamo.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any fingerlay.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any fingerstand.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any breakdance.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any twerk.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any hiphop.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\any any ballskick.JMM\"");
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
                                Animation = 24,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"landing_dead"),
                                GraphIndex = -1,
                                Animation = 25,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"thunder_clap"),
                                GraphIndex = -1,
                                Animation = 1058,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"twerk"),
                                GraphIndex = -1,
                                Animation = 1059,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"dance1test"),
                                GraphIndex = -1,
                                Animation = 1060,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"dance1"),
                                GraphIndex = -1,
                                Animation = 1061,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"mixamo"),
                                GraphIndex = -1,
                                Animation = 1062,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"fingerlay"),
                                GraphIndex = -1,
                                Animation = 1063,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"fingerstand"),
                                GraphIndex = -1,
                                Animation = 1064,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"breakdance"),
                                GraphIndex = -1,
                                Animation = 1065,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"hiphop"),
                                GraphIndex = -1,
                                Animation = 1066,
                            },
                            new ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                            {
                                Label = CacheContext.StringTable.GetStringId($@"ballskick"),
                                GraphIndex = -1,
                                Animation = 1067,
                            },
                        };
                        CacheContext.Serialize(stream, tag, jmad);
                    }
                }
            }
        }
    }
}