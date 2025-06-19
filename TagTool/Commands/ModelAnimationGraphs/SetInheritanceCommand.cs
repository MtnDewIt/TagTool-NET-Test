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
using static TagTool.Tags.Definitions.ModelAnimationGraph.Mode;

namespace TagTool.Commands.ModelAnimationGraphs
{
    public class SetInheritanceCommand : Command
    {
        private GameCache CacheContext { get; }
        private ModelAnimationGraph Animation { get; set; }
        private CachedTag Jmad { get; set; }

        // Global base index; will be set to the new donor entry's position.
        private short Index = -1;
        // Captured donor inheritance entry index.
        private short donorInheritanceIndex = 0;
        private bool UseMccMode = false;
        // Dictionaries to record original GraphIndex values for blocks already in the target.
        private Dictionary<string, short> originalGraphIndices = new Dictionary<string, short>();
        private Dictionary<string, short> baseGraphIndices = new Dictionary<string, short>();

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
                  + "\n\t- 'Vehicles' will inherit any new vehicle-based driver, passenger, gunner, and boarding modes."
                  + "\n\t- 'FP' is required for inheritance between first person animation graphs."
                  + "\n\t- 'MCC' for EK like inheritance, sets inheritance for all animations except for animations already in graph."
                  + "\n\t- 'SyncAction' Inherits SyncActionGroups assassinations."
                  + "\n\t- 'Melee' Inherits all animations that contain the word Melee."
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
            List<string> specifics = new List<string>();
            bool firstperson = false, vehicles = false, mcc = false, fp = false, syncAction = false, melee = false;
            InheritanceListFlags inheritanceFlags = InheritanceListFlags.None;

            if (args.Count == 0)
                return new TagToolError(CommandError.ArgCount);

            // Process trailing inheritance flags.
            var possibleFlags = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "tightennodes", "playernodes", "facialmaskremap" };
            while (args.Count > 1 && possibleFlags.Contains(args.Last()))
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

            // Process qualifiers.
            var qualifiers = new List<string>(args);
            foreach (var arg in qualifiers.ToList())
            {
                string lower = arg.ToLower();
                if (lower == "mcc")
                {
                    mcc = true;
                    args.Remove(arg);
                }
                else if (lower == "fp")
                {
                    fp = true;
                    args.Remove(arg);
                }
                else if (lower == "vehicles")
                {
                    vehicles = true;
                    args.Remove(arg);
                }
                else if (lower == "syncaction" || lower == "syncactions")
                {
                    syncAction = true;
                    args.Remove(arg);
                }
                else if (lower == "melee")
                {
                    melee = true;
                    args.Remove(arg);
                }
            }
            firstperson = fp;
            UseMccMode = mcc || fp || vehicles || syncAction || melee;

            // The last argument is the donor tag.
            var tagName = args.Last();
            if (!CacheContext.TagCache.TryGetCachedTag(tagName, out CachedTag donorTag))
                return new TagToolError(CommandError.TagInvalid);
            else if (donorTag.Group != new TagTool.Tags.TagGroup("jmad"))
                return new TagToolError(CommandError.ArgInvalid, "Donor is not a model_animation_graph (jmad) tag");
            args.RemoveAt(args.Count - 1);

            // Process remaining arguments: numeric index and specifics.
            var argStack = new Stack<string>(args.AsEnumerable().Reverse());
            while (argStack.Count > 0)
            {
                var arg = argStack.Pop();
                if (short.TryParse(arg, out short givenIndex))
                    Index = givenIndex;
                else
                    specifics.Add(arg);
            }

            // Capture original graph indices.
            CaptureOriginalGraphIndices();
            baseGraphIndices = new Dictionary<string, short>(originalGraphIndices);

            using (Stream cacheStream = CacheContext.OpenCacheReadWrite())
            {
                ModelAnimationGraph donorGraph = CacheContext.Deserialize<ModelAnimationGraph>(cacheStream, donorTag);

                // --- Inheritance Handling ---
                if (UseMccMode)
                {
                    int foundIndex = Animation.InheritanceList.FindIndex(x => x.InheritedGraph == donorTag);
                    if (foundIndex == -1)
                    {
                        donorInheritanceIndex = (short)Animation.InheritanceList.Count;
                        Inheritance donorInh = new Inheritance { InheritedGraph = donorTag, Flags = inheritanceFlags };
                        RecalcInheritanceEntry(donorInh, donorGraph, firstperson);
                        Animation.InheritanceList.Add(donorInh);
                    }
                    else
                    {
                        donorInheritanceIndex = (short)foundIndex;
                        Inheritance donorInh = Animation.InheritanceList[donorInheritanceIndex];
                        donorInh.Flags = inheritanceFlags;
                    }
                    if (donorGraph.InheritanceList != null)
                    {
                        foreach (var inh in donorGraph.InheritanceList)
                        {
                            if (!Animation.InheritanceList.Any(x => x.InheritedGraph != null && string.Equals(x.InheritedGraph.Name, inh.InheritedGraph.Name, StringComparison.OrdinalIgnoreCase)))
                            {
                                ModelAnimationGraph subDonor = CacheContext.Deserialize<ModelAnimationGraph>(cacheStream, inh.InheritedGraph);
                                Inheritance cloned = CloneInheritance(inh);
                                cloned.Flags = inheritanceFlags;
                                RecalcInheritanceEntry(cloned, subDonor, firstperson);
                                Animation.InheritanceList.Add(cloned);
                            }
                        }
                    }
                    Index = donorInheritanceIndex;
                }
                else
                {
                    int foundIndex = Animation.InheritanceList.FindIndex(x => x.InheritedGraph == donorTag);
                    if (foundIndex == -1)
                    {
                        donorInheritanceIndex = (short)Animation.InheritanceList.Count;
                        Inheritance newInh = new Inheritance { InheritedGraph = donorTag, Flags = inheritanceFlags };
                        RecalcInheritanceEntry(newInh, donorGraph, firstperson);
                        Animation.InheritanceList.Add(newInh);
                    }
                    else
                    {
                        donorInheritanceIndex = (short)foundIndex;
                    }
                    Index = donorInheritanceIndex;
                    Inheritance inhEntry = Animation.InheritanceList[Index];
                    if (inhEntry.InheritedGraph == null)
                        return new TagToolError(CommandError.TagInvalid);
                    inhEntry.Flags = inheritanceFlags;
                }

                // --- Merging Strategy ---
                if (specifics.Any())
                {
                    foreach (var specific in specifics)
                    {
                        if (specific.Contains(":"))
                        {
                            string[] parts = specific.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length == 0)
                                continue;
                            var donorMode = donorGraph.Modes.FirstOrDefault(m =>
                                CacheContext.StringTable.GetString(m.Name).Equals(parts[0], StringComparison.OrdinalIgnoreCase) ||
                                CacheContext.StringTable.GetString(m.Name).Contains(parts[0], StringComparison.OrdinalIgnoreCase));
                            if (donorMode != null)
                                MergePartialFromDonorIntoTarget(donorMode, parts);
                            else
                            {
                                var labels = JmadHelper.GetLabelStringIDs(specific, CacheContext);
                                if (labels.Count == 0 || labels.Contains(StringId.Invalid))
                                    return new TagToolError(CommandError.CustomError, $"Part of the graph path {specific} is invalid.");
                                var toInherit = JmadHelper.TraverseGraph(donorGraph, labels);
                                if (toInherit == null)
                                    return new TagToolError(CommandError.CustomError, $"\"{specific}\" not defined in donor graph.");
                                JmadHelper.SetGraphIndex(Animation, Index, labels);
                            }
                        }
                        else
                        {
                            string modeName = specific;
                            var donorMode = donorGraph.Modes.FirstOrDefault(m =>
                                CacheContext.StringTable.GetString(m.Name).Equals(modeName, StringComparison.OrdinalIgnoreCase) ||
                                CacheContext.StringTable.GetString(m.Name).Contains(modeName, StringComparison.OrdinalIgnoreCase));
                            if (donorMode != null)
                            {
                                var targetMode = Animation.Modes.FirstOrDefault(m =>
                                    CacheContext.StringTable.GetString(m.Name)
                                        .Equals(CacheContext.StringTable.GetString(donorMode.Name), StringComparison.OrdinalIgnoreCase));
                                if (targetMode == null)
                                    Animation.Modes.Add(CloneMode(donorMode));
                                else
                                    InheritModeSubBlocks(targetMode, donorMode);
                            }
                            else
                            {
                                var labels = JmadHelper.GetLabelStringIDs(specific, CacheContext);
                                if (labels.Count == 0 || labels.Contains(StringId.Invalid))
                                    return new TagToolError(CommandError.CustomError, $"Part of the graph path {specific} is invalid.");
                                var toInherit = JmadHelper.TraverseGraph(donorGraph, labels);
                                if (toInherit == null)
                                    return new TagToolError(CommandError.CustomError, $"\"{specific}\" not defined in donor graph.");
                                JmadHelper.SetGraphIndex(Animation, Index, labels);
                            }
                        }
                    }
                }
                else
                {
                    if (syncAction)
                        InheritSyncActionBlocks(Animation, donorGraph);
                    if (melee)
                        InheritMeleeBlocks(Animation, donorGraph);
                    if (vehicles)
                        InheritVehicleModes(Animation, donorGraph);
                    if (mcc)
                        InheritAllModes(Animation, donorGraph);
                    if (!syncAction && !melee && !vehicles && !mcc)
                        OverwriteInheritance(Animation, donorGraph);
                }

                // Build mapping: donor GraphIndex -1 maps to donorInheritanceIndex; for donor sub-inheritance, map each index.
                Dictionary<short, short> donorMapping = new Dictionary<short, short> { { -1, donorInheritanceIndex } };
                if (donorGraph.InheritanceList != null)
                {
                    for (short i = 0; i < donorGraph.InheritanceList.Count; i++)
                    {
                        int targetIndex = Animation.InheritanceList.FindIndex(x => x.InheritedGraph != null && string.Equals(x.InheritedGraph.Name, donorGraph.InheritanceList[i].InheritedGraph.Name, StringComparison.OrdinalIgnoreCase));
                        donorMapping[i] = (short)targetIndex;
                    }
                }

                // Remap GraphIndices for all modes using the donorMapping.
                foreach (var mode in Animation.Modes)
                    UpdateGraphIndicesForMode(mode, donorMapping);

                // Recalculate NodeMap, RootZOffset, and NodeMapFlags for each Inheritance entry.
                foreach (var inh in Animation.InheritanceList)
                {
                    ModelAnimationGraph inhGraph = CacheContext.Deserialize<ModelAnimationGraph>(cacheStream, inh.InheritedGraph);
                    if (inh.NodeMap == null || inh.NodeMap.Count == 0)
                    {
                        RecalcInheritanceEntry(inh, inhGraph, firstperson);
                    }
                    inh.Flags = inheritanceFlags;
                }

                new SortModesCommand(CacheContext, Animation).Execute(new List<string>());
            }

            Console.WriteLine("Done.");
            return true;
        }

        // --- Cloning Helpers ---
        private Mode.ModeIkBlock CloneModeIkBlock(Mode.ModeIkBlock donorIk) =>
            new Mode.ModeIkBlock { Marker = donorIk.Marker, AttachToMarker = donorIk.AttachToMarker };

        private Mode CloneMode(Mode donorMode) =>
            new Mode
            {
                Name = donorMode.Name,
                OverlayGroup = donorMode.OverlayGroup,
                ikGroup = donorMode.ikGroup,
                StanceFlags = donorMode.StanceFlags,
                WeaponClass = donorMode.WeaponClass?.Select(CloneWeaponClass).ToList() ?? new List<Mode.WeaponClassBlock>(),
                ModeIk = donorMode.ModeIk?.Select(CloneModeIkBlock).ToList() ?? new List<Mode.ModeIkBlock>(),
                FootDefaults = donorMode.FootDefaults != null ? new List<FootTrackingDefaultsBlock>(donorMode.FootDefaults) : new List<FootTrackingDefaultsBlock>()
            };

        private Mode.WeaponClassBlock CloneWeaponClass(Mode.WeaponClassBlock donorClass) =>
            new Mode.WeaponClassBlock
            {
                Label = donorClass.Label,
                OverlayGroup = donorClass.OverlayGroup,
                ikGroup = donorClass.ikGroup,
                WeaponType = donorClass.WeaponType?.Select(CloneWeaponType).ToList() ?? new List<Mode.WeaponClassBlock.WeaponTypeBlock>(),
                WeaponIk = donorClass.WeaponIk?.Select(CloneModeIkBlock).ToList() ?? new List<Mode.ModeIkBlock>(),
                SyncActionGroups = donorClass.SyncActionGroups != null ? new List<Mode.WeaponClassBlock.SyncActionGroup>(donorClass.SyncActionGroups) : new List<Mode.WeaponClassBlock.SyncActionGroup>(),
                RangedActions = (byte[])donorClass.RangedActions.Clone()
            };

        private Mode.WeaponClassBlock.WeaponTypeBlock CloneWeaponType(Mode.WeaponClassBlock.WeaponTypeBlock donorType) =>
            new Mode.WeaponClassBlock.WeaponTypeBlock
            {
                Label = donorType.Label,
                OverlayGroup = donorType.OverlayGroup,
                ikGroup = donorType.ikGroup,
                AnimationSetsReach = donorType.AnimationSetsReach != null ? new List<Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet>(donorType.AnimationSetsReach) : new List<Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet>(),
                Set = donorType.Set
            };

        // --- Partial Merge Helpers ---
        private void MergePartialFromDonorIntoTarget(Mode donorMode, string[] parts)
        {
            Mode partialClone = CreatePartialClone(donorMode, parts);
            var targetMode = Animation.Modes.FirstOrDefault(m =>
                CacheContext.StringTable.GetString(m.Name)
                    .Equals(CacheContext.StringTable.GetString(donorMode.Name), StringComparison.OrdinalIgnoreCase));
            if (targetMode == null)
                Animation.Modes.Add(partialClone);
            else
                MergePartialWeaponClasses(targetMode, partialClone);
        }

        private Mode CreatePartialClone(Mode donorMode, string[] parts)
        {
            Mode clone = new Mode
            {
                Name = donorMode.Name,
                OverlayGroup = donorMode.OverlayGroup,
                ikGroup = donorMode.ikGroup,
                StanceFlags = donorMode.StanceFlags,
                ModeIk = donorMode.ModeIk?.Select(CloneModeIkBlock).ToList() ?? new List<Mode.ModeIkBlock>(),
                FootDefaults = donorMode.FootDefaults != null ? new List<FootTrackingDefaultsBlock>(donorMode.FootDefaults) : new List<FootTrackingDefaultsBlock>()
            };

            if (parts.Length >= 2)
                clone.WeaponClass = donorMode.WeaponClass
                    .Where(wc => CacheContext.StringTable.GetString(wc.Label).Equals(parts[1], StringComparison.OrdinalIgnoreCase))
                    .Select(CloneWeaponClass).ToList();
            else
                clone.WeaponClass = donorMode.WeaponClass?.Select(CloneWeaponClass).ToList();

            if (parts.Length >= 3)
            {
                foreach (var wc in clone.WeaponClass)
                {
                    if (wc.WeaponType != null)
                        wc.WeaponType = wc.WeaponType
                            .Where(wt => CacheContext.StringTable.GetString(wt.Label).Equals(parts[2], StringComparison.OrdinalIgnoreCase))
                            .Select(CloneWeaponType).ToList();
                }
            }

            if (parts.Length >= 4)
            {
                foreach (var wc in clone.WeaponClass)
                {
                    if (wc.WeaponType != null)
                    {
                        foreach (var wt in wc.WeaponType)
                        {
                            if (wt.Set != null)
                            {
                                if (wt.Set.Actions != null)
                                    wt.Set.Actions = wt.Set.Actions
                                        .Where(a => CacheContext.StringTable.GetString(a.Label).Equals(parts[3], StringComparison.OrdinalIgnoreCase))
                                        .Select(CloneEntry).ToList();
                                if (wt.Set.Overlays != null)
                                    wt.Set.Overlays = wt.Set.Overlays
                                        .Where(o => CacheContext.StringTable.GetString(o.Label).Equals(parts[3], StringComparison.OrdinalIgnoreCase))
                                        .Select(CloneEntry).ToList();
                            }
                        }
                    }
                }
            }
            return clone;
        }

        private void MergePartialWeaponClasses(Mode targetMode, Mode partial)
        {
            foreach (var partialWC in partial.WeaponClass)
            {
                var targetWC = targetMode.WeaponClass.FirstOrDefault(wc => wc.Label == partialWC.Label);
                if (targetWC == null)
                    targetMode.WeaponClass.Add(partialWC);
                else
                {
                    foreach (var partialWT in partialWC.WeaponType)
                    {
                        var targetWT = targetWC.WeaponType.FirstOrDefault(wt => wt.Label == partialWT.Label);
                        if (targetWT == null)
                            targetWC.WeaponType.Add(partialWT);
                        else
                        {
                            if (partialWT.Set != null)
                            {
                                if (partialWT.Set.Actions != null)
                                {
                                    foreach (var partialAction in partialWT.Set.Actions)
                                    {
                                        if (!targetWT.Set.Actions.Any(a => a.Label == partialAction.Label))
                                            targetWT.Set.Actions.Add(partialAction);
                                    }
                                }
                                if (partialWT.Set.Overlays != null)
                                {
                                    foreach (var partialOverlay in partialWT.Set.Overlays)
                                    {
                                        if (!targetWT.Set.Overlays.Any(o => o.Label == partialOverlay.Label))
                                            targetWT.Set.Overlays.Add(partialOverlay);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // --- Inheritance by Flag Helpers ---
        private void InheritVehicleModes(ModelAnimationGraph target, ModelAnimationGraph donor)
        {
            var vehicleChars = new string[] { "d", "g", "p", "b", "l", "f", "r" };
            var targetModeNames = target.Modes.Select(m => CacheContext.StringTable.GetString(m.Name)).ToList();
            foreach (var donorMode in donor.Modes)
            {
                var modeName = CacheContext.StringTable.GetString(donorMode.Name);
                var parts = modeName.Split('_');
                if (parts.Any(p => vehicleChars.Contains(p, StringComparer.OrdinalIgnoreCase)))
                {
                    if (!targetModeNames.Contains(modeName))
                        target.Modes.Add(CloneMode(donorMode));
                    else
                    {
                        var targetMode = target.Modes.FirstOrDefault(m =>
                            CacheContext.StringTable.GetString(m.Name).Equals(modeName, StringComparison.OrdinalIgnoreCase));
                        if (targetMode != null)
                            InheritModeSubBlocks(targetMode, donorMode);
                    }
                }
            }
        }

        private void InheritSyncActionBlocks(ModelAnimationGraph target, ModelAnimationGraph donor)
        {
            foreach (var donorMode in donor.Modes)
            {
                string modeName = CacheContext.StringTable.GetString(donorMode.Name);
                var targetMode = target.Modes.FirstOrDefault(m =>
                    CacheContext.StringTable.GetString(m.Name).Equals(modeName, StringComparison.OrdinalIgnoreCase));
                if (targetMode != null && donorMode.WeaponClass != null)
                {
                    foreach (var donorWc in donorMode.WeaponClass)
                    {
                        var targetWc = targetMode.WeaponClass.FirstOrDefault(wc => wc.Label == donorWc.Label);
                        if (targetWc != null && donorWc.SyncActionGroups != null)
                        {
                            foreach (var donorSAG in donorWc.SyncActionGroups)
                            {
                                if (!targetWc.SyncActionGroups.Any(sag => sag.Name == donorSAG.Name))
                                    targetWc.SyncActionGroups.Add(donorSAG);
                                else
                                    InheritSyncActions(targetWc.SyncActionGroups.First(sag => sag.Name == donorSAG.Name), donorSAG);
                            }
                        }
                    }
                }
            }
        }

        private void InheritSyncActions(Mode.WeaponClassBlock.SyncActionGroup targetSAG, Mode.WeaponClassBlock.SyncActionGroup donorSAG)
        {
            if (donorSAG.SyncActions != null)
            {
                foreach (var donorSync in donorSAG.SyncActions)
                {
                    var targetSync = targetSAG.SyncActions.FirstOrDefault(sa => sa.Name == donorSync.Name);
                    if (targetSync == null)
                        targetSAG.SyncActions.Add(donorSync);
                    else
                    {
                        if (donorSync.SameTypeParticipants != null)
                        {
                            int participantIndex = 0;
                            foreach (var donorPart in donorSync.SameTypeParticipants)
                            {
                                var newParticipant = CloneSameTypeParticipant(donorPart);
                                newParticipant.GraphIndex = donorPart.GraphIndex;
                                string key = GetSameTypeParticipantKey(null, null, targetSAG, participantIndex);
                                if (!targetSync.SameTypeParticipants.Any(tp => tp.Animation == newParticipant.Animation && tp.Flags == newParticipant.Flags))
                                    targetSync.SameTypeParticipants.Add(newParticipant);
                                participantIndex++;
                            }
                        }
                        if (donorSync.OtherParticipants != null)
                        {
                            foreach (var donorOther in donorSync.OtherParticipants)
                            {
                                if (!targetSync.OtherParticipants.Any(to => to.ObjectType == donorOther.ObjectType))
                                    targetSync.OtherParticipants.Add(donorOther);
                            }
                        }
                    }
                }
            }
        }

        private void InheritMeleeBlocks(ModelAnimationGraph target, ModelAnimationGraph donor)
        {
            foreach (var donorMode in donor.Modes)
            {
                var donorModeStr = CacheContext.StringTable.GetString(donorMode.Name);
                var targetMode = target.Modes.FirstOrDefault(m =>
                    CacheContext.StringTable.GetString(m.Name).Equals(donorModeStr, StringComparison.OrdinalIgnoreCase));
                if (targetMode == null)
                {
                    Mode partialClone = CreatePartialClone(donorMode, new string[] { donorModeStr, "", "", "melee" });
                    if (partialClone.WeaponClass != null && partialClone.WeaponClass.Any())
                        target.Modes.Add(partialClone);
                }
                else
                {
                    if (donorMode.WeaponClass != null)
                    {
                        foreach (var donorWc in donorMode.WeaponClass)
                        {
                            var targetWc = targetMode.WeaponClass.FirstOrDefault(wc =>
                                CacheContext.StringTable.GetString(wc.Label)
                                .Equals(CacheContext.StringTable.GetString(donorWc.Label), StringComparison.OrdinalIgnoreCase));
                            if (targetWc != null && donorWc.WeaponType != null)
                            {
                                foreach (var donorWt in donorWc.WeaponType)
                                {
                                    var targetWt = targetWc.WeaponType.FirstOrDefault(wt =>
                                        CacheContext.StringTable.GetString(wt.Label)
                                        .Equals(CacheContext.StringTable.GetString(donorWt.Label), StringComparison.OrdinalIgnoreCase));
                                    if (targetWt != null && donorWt.Set != null)
                                    {
                                        foreach (var donorAction in donorWt.Set.Actions.Where(a =>
                                            CacheContext.StringTable.GetString(a.Label).IndexOf("melee", StringComparison.OrdinalIgnoreCase) >= 0))
                                        {
                                            if (!targetWt.Set.Actions.Any(a =>
                                                CacheContext.StringTable.GetString(a.Label).IndexOf("melee", StringComparison.OrdinalIgnoreCase) >= 0))
                                                targetWt.Set.Actions.Add(CloneEntry(donorAction));
                                        }
                                        foreach (var donorOverlay in donorWt.Set.Overlays.Where(o =>
                                            CacheContext.StringTable.GetString(o.Label).IndexOf("melee", StringComparison.OrdinalIgnoreCase) >= 0))
                                        {
                                            if (!targetWt.Set.Overlays.Any(o =>
                                                CacheContext.StringTable.GetString(o.Label).IndexOf("melee", StringComparison.OrdinalIgnoreCase) >= 0))
                                                targetWt.Set.Overlays.Add(CloneEntry(donorOverlay));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CaptureOriginalGraphIndices()
        {
            originalGraphIndices.Clear();
            foreach (var mode in Animation.Modes)
            {
                if (mode.WeaponClass != null)
                {
                    foreach (var wc in mode.WeaponClass)
                    {
                        if (wc.WeaponType != null)
                        {
                            foreach (var wt in wc.WeaponType)
                            {
                                if (wt.Set != null)
                                {
                                    if (wt.Set.Actions != null)
                                    {
                                        foreach (var action in wt.Set.Actions)
                                        {
                                            string key = GetActionKey(mode, wc, wt, action);
                                            originalGraphIndices[key] = action.GraphIndex;
                                        }
                                    }
                                    if (wt.Set.Overlays != null)
                                    {
                                        foreach (var overlay in wt.Set.Overlays)
                                        {
                                            string key = GetOverlayKey(mode, wc, wt, overlay);
                                            originalGraphIndices[key] = overlay.GraphIndex;
                                        }
                                    }
                                    if (wt.Set.DeathAndDamage != null)
                                    {
                                        int ddIndex = 0;
                                        foreach (var dad in wt.Set.DeathAndDamage)
                                        {
                                            int dirIndex = 0;
                                            foreach (var dir in dad.Directions)
                                            {
                                                int regIndex = 0;
                                                foreach (var reg in dir.Regions)
                                                {
                                                    string key = GetRegionKey(mode, wc, wt, ddIndex, dirIndex, regIndex);
                                                    originalGraphIndices[key] = reg.GraphIndex;
                                                    regIndex++;
                                                }
                                                dirIndex++;
                                            }
                                            ddIndex++;
                                        }
                                    }
                                    if (wt.Set.Transitions != null)
                                    {
                                        foreach (var trans in wt.Set.Transitions)
                                        {
                                            int destIndex = 0;
                                            foreach (var dest in trans.Destinations)
                                            {
                                                string key = GetTransitionKey(mode, wc, wt, trans, destIndex);
                                                originalGraphIndices[key] = dest.GraphIndex;
                                                destIndex++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (wc.SyncActionGroups != null)
                        {
                            foreach (var sag in wc.SyncActionGroups)
                            {
                                int stIndex = 0;
                                foreach (var participant in sag.SyncActions.SelectMany(a => a.SameTypeParticipants))
                                {
                                    string key = GetSameTypeParticipantKey(mode, wc, sag, stIndex);
                                    originalGraphIndices[key] = participant.GraphIndex;
                                    stIndex++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void InheritAnimationSet(Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet targetSet,
                                         Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet donorSet)
        {
            if (donorSet.Actions != null)
            {
                foreach (var donorEntry in donorSet.Actions)
                {
                    if (!targetSet.Actions.Any(te => te.Label == donorEntry.Label))
                        targetSet.Actions.Add(CloneEntry(donorEntry));
                }
            }
            if (donorSet.Overlays != null)
            {
                foreach (var donorEntry in donorSet.Overlays)
                {
                    if (!targetSet.Overlays.Any(te => te.Label == donorEntry.Label))
                        targetSet.Overlays.Add(CloneEntry(donorEntry));
                }
            }
            if (donorSet.DeathAndDamage != null)
            {
                foreach (var donorDAD in donorSet.DeathAndDamage)
                {
                    if (!targetSet.DeathAndDamage.Any(tdad => tdad.Label == donorDAD.Label))
                        targetSet.DeathAndDamage.Add(CloneDeathAndDamageBlock(donorDAD));
                }
            }
            if (donorSet.Transitions != null)
            {
                foreach (var donorTrans in donorSet.Transitions)
                {
                    if (!targetSet.Transitions.Any(tt => tt.FullName == donorTrans.FullName))
                        targetSet.Transitions.Add(CloneTransition(donorTrans));
                }
            }
        }

        private Mode.WeaponClassBlock.WeaponTypeBlock.Entry CloneEntry(Mode.WeaponClassBlock.WeaponTypeBlock.Entry donorEntry) =>
            new Mode.WeaponClassBlock.WeaponTypeBlock.Entry
            {
                Label = donorEntry.Label,
                OverlayGroup = donorEntry.OverlayGroup,
                ikGroup = donorEntry.ikGroup,
                Animation = donorEntry.Animation,
                GraphIndex = donorEntry.GraphIndex
            };

        private Mode.WeaponClassBlock.WeaponTypeBlock.Transition CloneTransition(Mode.WeaponClassBlock.WeaponTypeBlock.Transition donorTrans) =>
            new Mode.WeaponClassBlock.WeaponTypeBlock.Transition
            {
                FullName = donorTrans.FullName,
                StateName = donorTrans.StateName,
                Padding0 = donorTrans.Padding0 != null ? (byte[])donorTrans.Padding0.Clone() : null,
                IndexA = donorTrans.IndexA,
                IndexB = donorTrans.IndexB,
                Destinations = donorTrans.Destinations?.Select(CloneDestination).ToList()
            };

        private Mode.WeaponClassBlock.WeaponTypeBlock.Transition.Destination CloneDestination(Mode.WeaponClassBlock.WeaponTypeBlock.Transition.Destination donorDest) =>
            new Mode.WeaponClassBlock.WeaponTypeBlock.Transition.Destination
            {
                FullName = donorDest.FullName,
                ModeName = donorDest.ModeName,
                StateName = donorDest.StateName,
                FrameEventLink = donorDest.FrameEventLink,
                Padding1 = donorDest.Padding1 != null ? (byte[])donorDest.Padding1.Clone() : null,
                IndexA = donorDest.IndexA,
                IndexB = donorDest.IndexB,
                GraphIndex = donorDest.GraphIndex,
                Animation = donorDest.Animation
            };

        private Mode.WeaponClassBlock.SyncActionGroup.SyncAction.SameTypeParticipant CloneSameTypeParticipant(Mode.WeaponClassBlock.SyncActionGroup.SyncAction.SameTypeParticipant donorParticipant) =>
            new Mode.WeaponClassBlock.SyncActionGroup.SyncAction.SameTypeParticipant
            {
                Flags = donorParticipant.Flags,
                GraphIndex = donorParticipant.GraphIndex,
                Animation = donorParticipant.Animation,
                StartOffset = donorParticipant.StartOffset,
                StartFacing = donorParticipant.StartFacing,
                EndOffset = donorParticipant.EndOffset,
                TimeUntilHurt = donorParticipant.TimeUntilHurt
            };

        private Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock CloneDeathAndDamageBlock(Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock donorDAD) =>
            new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock
            {
                Label = donorDAD.Label,
                Directions = donorDAD.Directions?.Select(CloneDirection).ToList()
            };

        private Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction CloneDirection(Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction donorDir) =>
            new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction
            {
                Regions = donorDir.Regions?.Select(reg => new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction.Region
                {
                    GraphIndex = reg.GraphIndex,
                    Animation = reg.Animation
                }).ToList()
            };

        private void RecalcInheritanceEntry(Inheritance inh, ModelAnimationGraph donorGraph, bool firstperson)
        {
            if (inh.NodeMap != null && inh.NodeMap.Count > 0)
                return;

            float targetRoot = JmadHelper.GetRootNode(Animation).ZPosition;
            float donorRoot = JmadHelper.GetRootNode(donorGraph).ZPosition;
            inh.RootZOffset = (targetRoot == 0.0f || donorRoot == 0.0f) ? 1.0f : targetRoot / donorRoot;

            bool sameMapping = false;
            if (donorGraph.SkeletonNodes != null && donorGraph.SkeletonNodes.Count > 0 &&
                Animation.SkeletonNodes != null &&
                Animation.SkeletonNodes.Count == donorGraph.SkeletonNodes.Count)
            {
                sameMapping = true;
                for (int i = 0; i < donorGraph.SkeletonNodes.Count; i++)
                {
                    if (donorGraph.SkeletonNodes[i].Name != Animation.SkeletonNodes[i].Name)
                    {
                        sameMapping = false;
                        break;
                    }
                }
            }

            if (sameMapping)
            {
                inh.NodeMap = null;
                inh.NodeMapFlags = null;
            }
            else
            {
                int skeletonCount = (donorGraph.SkeletonNodes != null && donorGraph.SkeletonNodes.Count > 0)
                                    ? donorGraph.SkeletonNodes.Count
                                    : Animation.SkeletonNodes.Count;
                inh.NodeMap = new List<Inheritance.NodeMapBlock>();
                for (int i = 0; i < skeletonCount; i++)
                    inh.NodeMap.Add(new Inheritance.NodeMapBlock());
                for (int i = 0; i < skeletonCount; i++)
                {
                    StringId donorNodeName = (donorGraph.SkeletonNodes != null && donorGraph.SkeletonNodes.Count > i)
                                               ? donorGraph.SkeletonNodes[i].Name
                                               : Animation.SkeletonNodes[i].Name;
                    short localIndex = (short)Animation.SkeletonNodes.FindIndex(x => x.Name == donorNodeName);
                    inh.NodeMap[i].LocalNode = localIndex;
                }
                if (!firstperson)
                {
                    inh.NodeMapFlags = new List<Inheritance.NodeMapFlag>
                    {
                        new Inheritance.NodeMapFlag { LocalNodeFlags = -1 },
                        new Inheritance.NodeMapFlag { LocalNodeFlags = -1 }
                    };
                }
            }
        }

        private void InheritAllModes(ModelAnimationGraph target, ModelAnimationGraph donor)
        {
            foreach (var donorMode in donor.Modes)
            {
                var targetMode = target.Modes.FirstOrDefault(m => m.Name == donorMode.Name);
                if (targetMode == null)
                    target.Modes.Add(CloneMode(donorMode));
                else
                    InheritModeSubBlocks(targetMode, donorMode);
            }
        }

        private void InheritModeSubBlocks(Mode targetMode, Mode donorMode)
        {
            if (donorMode.WeaponClass != null)
            {
                foreach (var donorClass in donorMode.WeaponClass)
                {
                    var targetClass = targetMode.WeaponClass.FirstOrDefault(wc => wc.Label == donorClass.Label);
                    if (targetClass == null)
                        targetMode.WeaponClass.Add(CloneWeaponClass(donorClass));
                    else
                    {
                        if (donorClass.WeaponType != null)
                        {
                            foreach (var donorType in donorClass.WeaponType)
                            {
                                var targetType = targetClass.WeaponType.FirstOrDefault(wt => wt.Label == donorType.Label);
                                if (targetType == null)
                                    targetClass.WeaponType.Add(CloneWeaponType(donorType));
                                else
                                    InheritAnimationSet(targetType.Set, donorType.Set);
                            }
                        }
                        if (donorClass.WeaponIk != null)
                        {
                            foreach (var donorIk in donorClass.WeaponIk)
                            {
                                if (donorIk.Marker == StringId.Invalid || donorIk.AttachToMarker == StringId.Invalid)
                                    continue;
                                var cloneIk = CloneModeIkBlock(donorIk);
                                if (!targetClass.WeaponIk.Any(tik => tik.Marker == cloneIk.Marker && tik.AttachToMarker == cloneIk.AttachToMarker))
                                    targetClass.WeaponIk.Add(cloneIk);
                            }
                        }
                        if (donorClass.SyncActionGroups != null)
                        {
                            foreach (var donorSAG in donorClass.SyncActionGroups)
                            {
                                var targetSAG = targetClass.SyncActionGroups.FirstOrDefault(sag => sag.Name == donorSAG.Name);
                                if (targetSAG == null)
                                    targetClass.SyncActionGroups.Add(donorSAG);
                                else
                                    InheritSyncActions(targetSAG, donorSAG);
                            }
                        }
                    }
                }
            }
            if (donorMode.ModeIk != null)
            {
                if (targetMode.ModeIk == null)
                    targetMode.ModeIk = new List<Mode.ModeIkBlock>();
                foreach (var donorIk in donorMode.ModeIk)
                {
                    if (donorIk.Marker == StringId.Invalid || donorIk.AttachToMarker == StringId.Invalid)
                        continue;
                    var cloneIk = CloneModeIkBlock(donorIk);
                    if (!targetMode.ModeIk.Any(tik => tik.Marker == cloneIk.Marker && tik.AttachToMarker == cloneIk.AttachToMarker))
                        targetMode.ModeIk.Add(cloneIk);
                }
            }
            if (donorMode.FootDefaults != null)
            {
                if (targetMode.FootDefaults == null)
                    targetMode.FootDefaults = new List<FootTrackingDefaultsBlock>();
                foreach (var donorFoot in donorMode.FootDefaults)
                {
                    if (!targetMode.FootDefaults.Any(tfd => tfd.Foot == donorFoot.Foot))
                        targetMode.FootDefaults.Add(donorFoot);
                }
            }
        }

        private void OverwriteInheritance(ModelAnimationGraph target, ModelAnimationGraph donor)
        {
            foreach (var mode in target.Modes)
            {
                foreach (var wClass in mode.WeaponClass)
                {
                    foreach (var wType in wClass.WeaponType)
                    {
                        foreach (var action in wType.Set.Actions)
                        {
                            if (action.GraphIndex == Index)
                            {
                                StringId animName = donor.Animations[action.Animation].Name;
                                action.Animation = (short)donor.Animations.FindIndex(x => x.Name == animName);
                                if (action.Animation == -1)
                                    action.Animation = GetEquivalentAnimation(donor, mode.Name, wClass.Label, wType.Label, action.Label);
                            }
                        }
                        foreach (var overlay in wType.Set.Overlays)
                        {
                            if (overlay.GraphIndex == Index)
                            {
                                StringId animName = donor.Animations[overlay.Animation].Name;
                                overlay.Animation = (short)donor.Animations.FindIndex(x => x.Name == animName);
                                if (overlay.Animation == -1)
                                    overlay.Animation = GetEquivalentAnimation(donor, mode.Name, wClass.Label, wType.Label, overlay.Label);
                            }
                        }
                        foreach (var dd in wType.Set.DeathAndDamage)
                        {
                            foreach (var dir in dd.Directions)
                            {
                                foreach (var region in dir.Regions)
                                {
                                    if (region.GraphIndex == Index)
                                    {
                                        StringId animName = donor.Animations[region.Animation].Name;
                                        region.Animation = (short)donor.Animations.FindIndex(x => x.Name == animName);
                                    }
                                }
                            }
                        }
                        foreach (var trs in wType.Set.Transitions)
                        {
                            foreach (var dest in trs.Destinations)
                            {
                                if (dest.GraphIndex == Index)
                                {
                                    StringId animName = donor.Animations[dest.Animation].Name;
                                    dest.Animation = (short)donor.Animations.FindIndex(x => x.Name == animName);
                                }
                            }
                        }
                    }
                }
            }
        }

        private short GetEquivalentAnimation(ModelAnimationGraph donor, StringId mode, StringId weapC, StringId weapT, StringId other)
        {
            short index = -1;
            var foundType = donor.Modes.FirstOrDefault(x => x.Name == mode)
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

        private Inheritance CloneInheritance(Inheritance donorInh) =>
            new Inheritance
            {
                InheritedGraph = donorInh.InheritedGraph,
                RootZOffset = donorInh.RootZOffset,
                Flags = donorInh.Flags,
                NodeMap = donorInh.NodeMap != null ? donorInh.NodeMap.Select(n => new Inheritance.NodeMapBlock { LocalNode = n.LocalNode }).ToList() : new List<Inheritance.NodeMapBlock>(),
                NodeMapFlags = donorInh.NodeMapFlags != null ? donorInh.NodeMapFlags.Select(f => new Inheritance.NodeMapFlag { LocalNodeFlags = f.LocalNodeFlags }).ToList() : new List<Inheritance.NodeMapFlag>()
            };

        private void UpdateGraphIndicesForMode(Mode mode, Dictionary<short, short> donorMapping)
        {
            if (mode.WeaponClass != null)
            {
                foreach (var wc in mode.WeaponClass)
                {
                    if (wc.WeaponType != null)
                    {
                        foreach (var wt in wc.WeaponType)
                        {
                            if (wt.Set != null)
                            {
                                if (wt.Set.Actions != null)
                                {
                                    foreach (var action in wt.Set.Actions)
                                    {
                                        string key = GetActionKey(mode, wc, wt, action);
                                        if (baseGraphIndices.ContainsKey(key))
                                            action.GraphIndex = baseGraphIndices[key];
                                        else
                                        {
                                            short orig = action.GraphIndex;
                                            action.GraphIndex = donorMapping.ContainsKey(orig) ? donorMapping[orig] : donorInheritanceIndex;
                                        }
                                    }
                                }
                                if (wt.Set.Overlays != null)
                                {
                                    foreach (var overlay in wt.Set.Overlays)
                                    {
                                        string key = GetOverlayKey(mode, wc, wt, overlay);
                                        if (baseGraphIndices.ContainsKey(key))
                                            overlay.GraphIndex = baseGraphIndices[key];
                                        else
                                        {
                                            short orig = overlay.GraphIndex;
                                            overlay.GraphIndex = donorMapping.ContainsKey(orig) ? donorMapping[orig] : donorInheritanceIndex;
                                        }
                                    }
                                }
                                if (wt.Set.DeathAndDamage != null)
                                {
                                    int ddIndex = 0;
                                    foreach (var dad in wt.Set.DeathAndDamage)
                                    {
                                        int dirIndex = 0;
                                        foreach (var dir in dad.Directions)
                                        {
                                            int regIndex = 0;
                                            foreach (var reg in dir.Regions)
                                            {
                                                string key = GetRegionKey(mode, wc, wt, ddIndex, dirIndex, regIndex);
                                                if (baseGraphIndices.ContainsKey(key))
                                                    reg.GraphIndex = baseGraphIndices[key];
                                                else
                                                {
                                                    short orig = reg.GraphIndex;
                                                    reg.GraphIndex = donorMapping.ContainsKey(orig) ? donorMapping[orig] : donorInheritanceIndex;
                                                }
                                                regIndex++;
                                            }
                                            dirIndex++;
                                        }
                                        ddIndex++;
                                    }
                                }
                                if (wt.Set.Transitions != null)
                                {
                                    foreach (var trans in wt.Set.Transitions)
                                    {
                                        int destIndex = 0;
                                        foreach (var dest in trans.Destinations)
                                        {
                                            string key = GetTransitionKey(mode, wc, wt, trans, destIndex);
                                            if (baseGraphIndices.ContainsKey(key))
                                                dest.GraphIndex = baseGraphIndices[key];
                                            else
                                            {
                                                short orig = dest.GraphIndex;
                                                dest.GraphIndex = donorMapping.ContainsKey(orig) ? donorMapping[orig] : donorInheritanceIndex;
                                            }
                                            destIndex++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (wc.SyncActionGroups != null)
                    {
                        foreach (var sag in wc.SyncActionGroups)
                        {
                            int partIndex = 0;
                            foreach (var sync in sag.SyncActions)
                            {
                                foreach (var participant in sync.SameTypeParticipants)
                                {
                                    string key = GetSameTypeParticipantKey(mode, wc, sag, partIndex);
                                    if (baseGraphIndices.ContainsKey(key))
                                        participant.GraphIndex = baseGraphIndices[key];
                                    else
                                    {
                                        short orig = participant.GraphIndex;
                                        participant.GraphIndex = donorMapping.ContainsKey(orig) ? donorMapping[orig] : donorInheritanceIndex;
                                    }
                                    partIndex++;
                                }
                            }
                        }
                    }
                }
            }
        }

        // --- Key Generators ---
        private string GetActionKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.WeaponTypeBlock wt, Mode.WeaponClassBlock.WeaponTypeBlock.Entry action) =>
            "A|" + mode.Name + "|" + wc.Label + "|" + wt.Label + "|" + action.Label;

        private string GetOverlayKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.WeaponTypeBlock wt, Mode.WeaponClassBlock.WeaponTypeBlock.Entry overlay) =>
            "O|" + mode.Name + "|" + wc.Label + "|" + wt.Label + "|" + overlay.Label;

        private string GetRegionKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.WeaponTypeBlock wt, int ddIndex, int dirIndex, int regIndex) =>
            "R|" + mode.Name + "|" + wc.Label + "|" + wt.Label + "|DD:" + ddIndex + ":" + dirIndex + ":" + regIndex;

        private string GetTransitionKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.WeaponTypeBlock wt, Mode.WeaponClassBlock.WeaponTypeBlock.Transition trans, int destIndex) =>
            "T|" + mode.Name + "|" + wc.Label + "|" + wt.Label + "|TR:" + trans.FullName + ":" + destIndex;

        private string GetSameTypeParticipantKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.SyncActionGroup sag, int participantIndex)
        {
            string modeStr = mode != null ? mode.Name.ToString() : "NoMode";
            string wcStr = wc != null ? wc.Label.ToString() : "NoWeaponClass";
            string sagStr = sag != null ? sag.Name.ToString() : "NoSyncActionGroup";
            return $"S|{modeStr}|{wcStr}|{sagStr}|ST:{participantIndex}";
        }
    }
}
