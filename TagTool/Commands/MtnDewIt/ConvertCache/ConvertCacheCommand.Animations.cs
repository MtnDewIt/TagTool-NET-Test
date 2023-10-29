using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using System.IO;
using TagTool.Commands.MtnDewIt.ConvertCache;

namespace TagTool.Commands.MtnDewIt
{
    partial class ConvertCacheCommand : Command
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
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat armor_lock_enter.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat armor_lock_exit.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat armor_lock_idle.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat con_blast_enter.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat con_blast_exit.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\combat mag_pulse_enter.JMM\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint ball any move_front.JMA\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint hammer any move_front.JMA\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint missile any move_front.JMA\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint pistol any move_front.JMA\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint rifle any move_front.JMA\"");
            CommandRunner.Current.RunCommand($"addanimation \"{Program.TagToolDirectory}\\Tools\\BaseCache\\Animations\\Elite\\sprint sword any move_front.JMA\"");
            ContextStack.Pop();


            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                new objects_characters_masterchief_masterchief_model_animation_graph(Cache, CacheContext, stream);

                new objects_characters_elite_elite_model_animation_graph(Cache, CacheContext, stream);

                new objects_characters_dervish_dervish_model_animation_graph(Cache, CacheContext, stream);

                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    if (tag.IsInGroup("jmad") && tag.Name == $@"objects\characters\elite\elite")
                    {
                        var jmad = CacheContext.Deserialize<ModelAnimationGraph>(stream, tag);

                        SortAnimationModes(stream, tag);
                    }

                    if (tag.IsInGroup("jmad") && tag.Name == $@"objects\characters\dervish\dervish") 
                    {
                        var jmad = CacheContext.Deserialize<ModelAnimationGraph>(stream, tag);

                        SortAnimationModes(stream, tag);
                    }
                }
            }
        }

        public void SortAnimationModes(Stream stream, CachedTag tag)
        {
            var jmad = CacheContext.Deserialize<ModelAnimationGraph>(stream, tag);

            var resolver = CacheContext.StringTable.Resolver;

            jmad.Modes = jmad.Modes.OrderBy(a => resolver.GetSet(a.Name)).ThenBy(a => resolver.GetIndex(a.Name)).ToList();

            foreach (var mode in jmad.Modes)
            {
                mode.WeaponClass = mode.WeaponClass.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();

                foreach (var weaponClass in mode.WeaponClass)
                {
                    weaponClass.WeaponType = weaponClass.WeaponType.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();

                    foreach (var weaponType in weaponClass.WeaponType)
                    {
                        weaponType.Set.Actions = weaponType.Set.Actions.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.Overlays = weaponType.Set.Overlays.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.DeathAndDamage = weaponType.Set.DeathAndDamage.OrderBy(a => resolver.GetSet(a.Label)).ThenBy(a => resolver.GetIndex(a.Label)).ToList();
                        weaponType.Set.Transitions = weaponType.Set.Transitions.OrderBy(a => resolver.GetSet(a.FullName)).ThenBy(a => resolver.GetIndex(a.FullName)).ToList();

                        foreach (var transition in weaponType.Set.Transitions) 
                        {
                            transition.Destinations = transition.Destinations.OrderBy(a => resolver.GetSet(a.FullName)).ThenBy(a => resolver.GetIndex(a.FullName)).ToList();
                        }
                    }
                }
            }

            CacheContext.Serialize(stream, tag, jmad);
        }
    }
}