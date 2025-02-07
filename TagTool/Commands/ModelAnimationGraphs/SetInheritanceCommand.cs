using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using TagTool.Animations;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Tags.Definitions;
using static TagTool.Tags.Definitions.ModelAnimationGraph;

namespace TagTool.Commands.ModelAnimationGraphs
{
    public class SetInheritanceCommand : Command
    {
        private GameCache CacheContext { get; }
        private ModelAnimationGraph Animation { get; set; }
        private CachedTag Jmad { get; set; }

        private short Index = -1;

        public SetInheritanceCommand(GameCache cachecontext, ModelAnimationGraph animation, CachedTag jmad)
            : base(false,
                  "SetInheritance",
                  "Inherit specified animation(s) from a given ModelAnimationGraph.",
                  "SetInheritance <specifics> [index] <tag> [flags]",
                  "Set up animation inheritance from a given tag.\n"
                  + "\nSkeletal mapping is performed by name; analogous nodes without identical names require manual correction."
                  + "\nReferences to render_model markers (e.g. ModeIk) *may* require manual correction.\n"
                  + "\nSpecifics are label paths (i.e. mode:weaponclass:weapontype:action/overlay) and multiple can be given at once."
                  + "\n\t- e.g. 'combat' 'scorpion_d:enter' 'crouch:unarmed:any:throw_grenade'\n"
                  + "\nSpecifics can also be optional qualifiers to the inheritance operation."
                  + "\n\t- 'vehicles' will inherit any new vehicle-based driver, passenger, gunner, and boarding modes."
                  + "\n\t- 'fp' is required for inheritance between first person animation graphs."
                  + "\n\t- 'MCC' for EK like inheritance, sets inheritance for all animations except for animations already in graph."
                  + "\n\nAdditionally, you can specify inheritance flags at the end of the command:"
                  + "\n\t- 'TightenNodes' unforces positions in animations for the nodes during inheritance."
                  + "\n\t- 'PlayerNodes' forces proper animation behavior for irregular oriented nodes."
                  + "\n\t- 'FacialMaskRemap' allows remapping of facial animation masks."
                  + "\n\nExample usage:"
                  + "\n\tSetInheritance MCC objects\\characters\\masterchief\\masterchief.model_animation_graph TightenNodes"
                  )
        {
            CacheContext = cachecontext;
            Animation = animation;
            Jmad = jmad;
        }

        public override object Execute(List<string> args)
        {
            List<string> specifics = new List<string> { };
            bool firstperson = false;
            bool vehicles = false;
            bool mcc = false;
            InheritanceListFlags inheritanceFlags = InheritanceListFlags.None;

            if(args.Count == 0)
                return new TagToolError(CommandError.ArgCount);

            // Process possible flags at the end of the command.
            var possibleFlags = new HashSet<string> { "tightennodes", "playernodes", "facialmaskremap" };
            while (args.Count > 1 && possibleFlags.Contains(args.Last().ToLower()))
            {
                string flagArg = args.Last().ToLower();
                args.RemoveAt(args.Count - 1);
                switch (flagArg)
                {
                    case "tightennodes":
                        inheritanceFlags |= InheritanceListFlags.TightenNodes;
                        break;
                    case "playernodes":
                        inheritanceFlags |= InheritanceListFlags.Bit1;
                        break;
                    case "facialmaskremap":
                        inheritanceFlags |= InheritanceListFlags.Bit2;
                        break;
                }
            }

            var tagName = args.LastOrDefault();
            if (!CacheContext.TagCache.TryGetCachedTag(tagName, out CachedTag newTag))
                return new TagToolError(CommandError.TagInvalid);
            else if (newTag.Group != new TagTool.Tags.TagGroup("jmad"))
                return new TagToolError(CommandError.ArgInvalid, "Donor is not a model_animation_graph (jmad) tag");
            else
                args.RemoveAt(args.Count - 1);

            var argStack = new Stack<string>(args.AsEnumerable().Reverse());
            while(argStack.Count > 0)
            {
                var arg = argStack.Pop();

                if (short.TryParse(arg, out short givenIndex))
                    Index = givenIndex;
                else
                {
                    switch(arg.ToLower())
                    {
                        case "fp":
                            firstperson = true;
                            break;
                        case "vehicles":
                            vehicles = true;
                            break;
                        case "mcc":
                            mcc = true;
                            break;
                        default:
                            specifics.Add(arg);
                            break;
                    }
                }
            }

            var foundIndex = Animation.InheritanceList.FindIndex(x => x.InheritedGraph == newTag);
            if (foundIndex == -1)
            {
                Index = (short)Animation.InheritanceList.Count;
                Animation.InheritanceList.Add(new Inheritance { InheritedGraph = newTag, Flags = inheritanceFlags });
            }
            else
                Index = (short)foundIndex;

            var block = Animation.InheritanceList[Index];
            if (block.InheritedGraph == null)
                return new TagToolError(CommandError.TagInvalid);

            // Apply inheritance flags.
            block.Flags = inheritanceFlags;

            using (Stream cacheStream = CacheContext.OpenCacheReadWrite())
            {
                ModelAnimationGraph oldJmad = CacheContext.Deserialize<ModelAnimationGraph>(cacheStream, block.InheritedGraph);
                ModelAnimationGraph newJmad = CacheContext.Deserialize<ModelAnimationGraph>(cacheStream, newTag);

                // Adjust root offsets.
                var thisRoot = JmadHelper.GetRootNode(Animation).ZPosition;
                var newRoot = JmadHelper.GetRootNode(newJmad).ZPosition;
                block.RootZOffset = (thisRoot == 0.0f || newRoot == 0.0f) ? 1.0f : thisRoot / newRoot;

                if (!firstperson)
                {
                    block.NodeMapFlags = new List<Inheritance.NodeMapFlag>
                    {
                        new Inheritance.NodeMapFlag { LocalNodeFlags = -1 },
                        new Inheritance.NodeMapFlag { LocalNodeFlags = -1 }
                    };
                }

                // create approximate node map from shared names
                if (block.NodeMap?.Count != newJmad.SkeletonNodes.Count)
                {
                    block.NodeMap = new List<Inheritance.NodeMapBlock>();
                    foreach (var node in newJmad.SkeletonNodes)
                    {
                        block.NodeMap.Add(new Inheritance.NodeMapBlock());
                    }
                }

                for (int i = 0; i < newJmad.SkeletonNodes.Count; i++)
                {
                    StringId nodeName = newJmad.SkeletonNodes[i].Name;
                    short localNodeIndex = (short)Animation.SkeletonNodes.FindIndex(x => x.Name == nodeName); // -1 if not found
                    block.NodeMap[i].LocalNode = localNodeIndex;
                }

                // add all vehicle modes if requested
                if(vehicles)
                {
                    List<string> currentModeNames = Animation.Modes.Select(m => CacheContext.StringTable.GetString(m.Name)).ToList();
                    foreach (var m in newJmad.Modes)
                    {
                        var modeString = CacheContext.StringTable.GetString(m.Name);
                        var vehicleChars = new string[] { "d", "g", "p", "b", "l", "f", "r" };
                        var split = modeString.Split('_');
                        
                        foreach (var c in vehicleChars)
                        {
                            if (split.Contains(c) && !currentModeNames.Contains(modeString))
                            {
                                specifics.Add(modeString);
                                break;
                            }
                        }
                    }
                }

                // transfer graph data additively
                if (specifics.Any())
                {
                    foreach (var fullLabel in specifics)
                    {
                        // check if the requested path through donor graph is valid
                        var labels = JmadHelper.GetLabelStringIDs(fullLabel, CacheContext);
                        if(labels.Count == 0 || labels.Contains(StringId.Invalid))
                            return new TagToolError(CommandError.CustomError, $"Part of the graph path {fullLabel} is invalid.");

                        var toInherit = JmadHelper.TraverseGraph(newJmad, labels);
                        if (toInherit == null)
                            return new TagToolError(CommandError.CustomError, $"\"{fullLabel}\" not defined in {tagName}");

                        // modify, replace, or create entries in recipient graph where needed
                        if (toInherit is Mode donorMode)
                        {
                            var mode = (Mode)JmadHelper.TraverseGraph(Animation, labels, true);
                            mode.WeaponClass = donorMode.WeaponClass;
                            mode.ModeIk = donorMode.ModeIk;
                            mode.FootDefaults = donorMode.FootDefaults;
                        }
                        else if (toInherit is Mode.WeaponClassBlock donorClass)
                        {
                            var wclass = (Mode.WeaponClassBlock)JmadHelper.TraverseGraph(Animation, labels, true);
                            wclass.WeaponIk = donorClass.WeaponIk;
                            // Do not copy SyncActionGroups
                            wclass.WeaponType = donorClass.WeaponType;
                        }
                        else if (toInherit is Mode.WeaponClassBlock.WeaponTypeBlock donorType)
                        {
                            var wtype = (Mode.WeaponClassBlock.WeaponTypeBlock)JmadHelper.TraverseGraph(Animation, labels, true);
                            wtype.Set = donorType.Set;
                        }
                        else if (toInherit is Mode.WeaponClassBlock.WeaponTypeBlock.Entry donorEntry)
                        {
                            // Only process if the donor entry is unassigned (GraphIndex == -1).
                            if (donorEntry.GraphIndex != -1)
                                continue;

                            var entry = (Mode.WeaponClassBlock.WeaponTypeBlock.Entry)JmadHelper.TraverseGraph(Animation, labels, true);
                            if (entry == null)
                            {
                                var parent = (Mode.WeaponClassBlock.WeaponTypeBlock)JmadHelper.TraverseGraph(Animation, labels.GetRange(0, 3));
                                switch(JmadHelper.GetEntryType(newJmad, labels))
                                {
                                    case JmadHelper.AnimationSetEntryType.Action:
                                        parent.Set.Actions.Add(new Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = donorEntry.Label,
                                            GraphIndex = Index,
                                            Animation = donorEntry.Animation
                                        });
                                        break;
                                    case JmadHelper.AnimationSetEntryType.Overlay:
                                        parent.Set.Overlays.Add(new Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                        {
                                            Label = donorEntry.Label,
                                            GraphIndex = Index,
                                            Animation = donorEntry.Animation
                                        });
                                        break;
                                    default:
                                        return new TagToolError(CommandError.CustomError, "Could not inherit this entry.");
                                }
                            }
                        }

                        // assign graph index
                        JmadHelper.SetGraphIndex(Animation, Index, labels);
                    }
                }

                // MCC FLAG – ADD ANY MISSING DONOR BLOCKS (ONLY FOR ENTRIES STILL at GraphIndex == -1)
                if (mcc)
                {
                    CopyMissingInheritance(Animation, newJmad, CacheContext, Index);
                }

                // UPDATE ANIMATION REFERENCES:
                // For each inherited entry that is still unassigned (GraphIndex == -1), remap its animation and then mark it.
                OverwriteInheritance(oldJmad, newJmad);

                // Finally, sort the modes.
                new SortModesCommand(CacheContext, Animation).Execute(new List<string>());
                Console.WriteLine("Done.");
                return true;
            }
        }

        /// <summary>
        /// MCC flag processing: loop through donor modes and their sub-blocks.
        /// For each donor block, if the corresponding block is missing in the current graph,
        /// clone and add it. For existing blocks, add missing entries only if the donor’s entry has GraphIndex == -1.
        /// </summary>
        private void CopyMissingInheritance(ModelAnimationGraph currentGraph, ModelAnimationGraph donorGraph, GameCache cache, short inheritanceIndex)
        {
            foreach (var donorMode in donorGraph.Modes)
            {
                var mode = currentGraph.Modes.FirstOrDefault(m => m.Name == donorMode.Name);
                if (mode == null)
                {
                    var clonedMode = CloneMode(donorMode, inheritanceIndex);
                    currentGraph.Modes.Add(clonedMode);
                    mode = clonedMode;
                }
                else
                {
                    foreach (var donorWClass in donorMode.WeaponClass)
                    {
                        var wclass = mode.WeaponClass.FirstOrDefault(wc => wc.Label == donorWClass.Label);
                        if (wclass == null)
                        {
                            var clonedWClass = CloneWeaponClass(donorWClass, inheritanceIndex);
                            mode.WeaponClass.Add(clonedWClass);
                            wclass = clonedWClass;
                        }
                        else
                        {
                            foreach (var donorWType in donorWClass.WeaponType)
                            {
                                var wtype = wclass.WeaponType.FirstOrDefault(wt => wt.Label == donorWType.Label);
                                if (wtype == null)
                                {
                                    var clonedWType = CloneWeaponType(donorWType, inheritanceIndex);
                                    wclass.WeaponType.Add(clonedWType);
                                    wtype = clonedWType;
                                }
                                else
                                {
                                    // For an existing weapon type, add any missing actions/overlays.
                                    foreach (var donorAction in donorWType.Set.Actions)
                                    {
                                        if (donorAction.GraphIndex != -1)
                                            continue;
                                        if (!wtype.Set.Actions.Any(a => a.Label == donorAction.Label))
                                        {
                                            var newAction = new Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                            {
                                                Label = donorAction.Label,
                                                GraphIndex = inheritanceIndex,
                                                Animation = donorAction.Animation
                                            };
                                            wtype.Set.Actions.Add(newAction);
                                        }
                                    }
                                    foreach (var donorOverlay in donorWType.Set.Overlays)
                                    {
                                        if (donorOverlay.GraphIndex != -1)
                                            continue;
                                        if (!wtype.Set.Overlays.Any(o => o.Label == donorOverlay.Label))
                                        {
                                            var newOverlay = new Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                                            {
                                                Label = donorOverlay.Label,
                                                GraphIndex = inheritanceIndex,
                                                Animation = donorOverlay.Animation
                                            };
                                            wtype.Set.Overlays.Add(newOverlay);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Deep clones a donor Mode.
        /// </summary>
        private Mode CloneMode(Mode donorMode, short inheritanceIndex)
        {
            Mode newMode = new Mode();
            newMode.Name = donorMode.Name;
            newMode.ModeIk = donorMode.ModeIk;
            newMode.FootDefaults = donorMode.FootDefaults;
            newMode.WeaponClass = new List<Mode.WeaponClassBlock>();
            foreach (var donorWClass in donorMode.WeaponClass)
            {
                newMode.WeaponClass.Add(CloneWeaponClass(donorWClass, inheritanceIndex));
            }
            return newMode;
        }

        /// <summary>
        /// Deep clones a donor WeaponClassBlock.
        /// Note: The donor’s SyncActionGroups are deliberately not copied.
        /// </summary>
        private Mode.WeaponClassBlock CloneWeaponClass(Mode.WeaponClassBlock donorWClass, short inheritanceIndex)
        {
            Mode.WeaponClassBlock newWClass = new Mode.WeaponClassBlock();
            newWClass.Label = donorWClass.Label;
            newWClass.WeaponIk = donorWClass.WeaponIk;
            newWClass.WeaponType = new List<Mode.WeaponClassBlock.WeaponTypeBlock>();
            foreach (var donorWType in donorWClass.WeaponType)
            {
                newWClass.WeaponType.Add(CloneWeaponType(donorWType, inheritanceIndex));
            }
            return newWClass;
        }

        /// <summary>
        /// Deep clones a donor WeaponTypeBlock.
        /// Only actions/overlays with GraphIndex == -1 are copied.
        /// DeathAndDamage and Transitions are cloned using the correct nested types.
        /// </summary>
        private Mode.WeaponClassBlock.WeaponTypeBlock CloneWeaponType(Mode.WeaponClassBlock.WeaponTypeBlock donorWType, short inheritanceIndex)
        {
            Mode.WeaponClassBlock.WeaponTypeBlock newWType = new Mode.WeaponClassBlock.WeaponTypeBlock();
            newWType.Label = donorWType.Label;
            newWType.Set = new Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet
            {
                Actions = donorWType.Set.Actions
                    .Where(a => a.GraphIndex == -1)
                    .Select(a => new Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                    {
                        Label = a.Label,
                        GraphIndex = inheritanceIndex,
                        Animation = a.Animation
                    }).ToList(),
                Overlays = donorWType.Set.Overlays
                    .Where(o => o.GraphIndex == -1)
                    .Select(o => new Mode.WeaponClassBlock.WeaponTypeBlock.Entry
                    {
                        Label = o.Label,
                        GraphIndex = inheritanceIndex,
                        Animation = o.Animation
                    }).ToList(),
                DeathAndDamage = donorWType.Set.DeathAndDamage
                    .Select(dd => new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock
                    {
                        Directions = dd.Directions
                            .Select(dir => new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction
                            {
                                Regions = dir.Regions
                                    .Select(region => new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction.Region
                                    {
                                        GraphIndex = region.GraphIndex,
                                        Animation = region.Animation
                                    }).ToList()
                            }).ToList()
                    }).ToList(),
                Transitions = donorWType.Set.Transitions
                    .Select(trs => new Mode.WeaponClassBlock.WeaponTypeBlock.Transition
                    {
                        Destinations = trs.Destinations
                            .Select(dest => new Mode.WeaponClassBlock.WeaponTypeBlock.Transition.Destination
                            {
                                GraphIndex = dest.GraphIndex,
                                Animation = dest.Animation
                            }).ToList()
                    }).ToList()
            };
            return newWType;
        }

        /// <summary>
        /// Remaps animation indices for inherited entries.
        /// Only entries whose GraphIndex is still –1 are updated, then marked with the inheritance index.
        /// </summary>
        private void OverwriteInheritance(ModelAnimationGraph oldJmad, ModelAnimationGraph newJmad)
        {
            foreach (var mode in Animation.Modes)
            {
                foreach (var wClass in mode.WeaponClass)
                {
                    foreach (var wType in wClass.WeaponType)
                    {
                        foreach (var action in wType.Set.Actions)
                        {
                            if (action.GraphIndex == -1)
                            {
                                if (action.Animation >= 0 && action.Animation < oldJmad.Animations.Count)
                                {
                                    StringId animName = oldJmad.Animations[action.Animation].Name;
                                    int newIndex = newJmad.Animations.FindIndex(x => x.Name == animName);
                                    action.Animation = newIndex == -1 ? (short)0 : (short)newIndex;
                                }
                                else
                                {
                                    action.Animation = 0;
                                }
                                action.GraphIndex = Index;
                            }
                        }
                        foreach (var overlay in wType.Set.Overlays)
                        {
                            if (overlay.GraphIndex == -1)
                            {
                                if (overlay.Animation >= 0 && overlay.Animation < oldJmad.Animations.Count)
                                {
                                    StringId animName = oldJmad.Animations[overlay.Animation].Name;
                                    int newIndex = newJmad.Animations.FindIndex(x => x.Name == animName);
                                    overlay.Animation = newIndex == -1 ? (short)0 : (short)newIndex;
                                }
                                else
                                {
                                    overlay.Animation = 0;
                                }
                                overlay.GraphIndex = Index;
                            }
                        }
                        foreach (var dd in wType.Set.DeathAndDamage)
                        {
                            foreach (var dir in dd.Directions)
                            {
                                foreach (var region in dir.Regions)
                                {
                                    if (region.GraphIndex == -1)
                                    {
                                        if (region.Animation >= 0 && region.Animation < oldJmad.Animations.Count)
                                        {
                                            StringId animName = oldJmad.Animations[region.Animation].Name;
                                            int newIndex = newJmad.Animations.FindIndex(x => x.Name == animName);
                                            region.Animation = newIndex == -1 ? (short)0 : (short)newIndex;
                                        }
                                        else
                                        {
                                            region.Animation = 0;
                                        }
                                        region.GraphIndex = Index;
                                    }
                                }
                            }
                        }
                        foreach (var trs in wType.Set.Transitions)
                        {
                            foreach (var dest in trs.Destinations)
                            {
                                if (dest.GraphIndex == -1)
                                {
                                    if (dest.Animation >= 0 && dest.Animation < oldJmad.Animations.Count)
                                    {
                                        StringId animName = oldJmad.Animations[dest.Animation].Name;
                                        int newIndex = newJmad.Animations.FindIndex(x => x.Name == animName);
                                        dest.Animation = newIndex == -1 ? (short)0 : (short)newIndex;
                                    }
                                    else
                                    {
                                        dest.Animation = 0;
                                    }
                                    dest.GraphIndex = Index;
                                }
                            }
                        }
                    }
                }
            }
        }

        private short GetEquivalentAnimation(ModelAnimationGraph newJmad, StringId mode, StringId weapC, StringId weapT, StringId other)
        {
            short index = -1;

            var foundType = newJmad.Modes.FirstOrDefault(x => x.Name == mode)
                ?.WeaponClass?.FirstOrDefault(x => x.Label == weapC)
                ?.WeaponType?.FirstOrDefault(x => x.Label == weapT);

            if (foundType != null)
            {
                var foundAction = foundType.Set.Actions?.FirstOrDefault(x => x.Label == other);
                if (foundAction != null)
                    index = foundAction.Animation;
                else
                {
                    var foundOverlay = foundType.Set.Overlays?.FirstOrDefault(x => x.Label == other);
                    if (foundOverlay != null)
                        index = foundOverlay.Animation;
                }
            }
            return index;
        }
    }
}
