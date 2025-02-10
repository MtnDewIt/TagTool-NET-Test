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

        private short Index = -1;
        private bool UseMccMode = false;
        // Dictionary to record original GraphIndex values for blocks already in the target.
        private Dictionary<string, short> originalGraphIndices = new Dictionary<string, short>();

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
            bool firstperson = false;
            bool vehicles = false;
            bool mcc = false;
            bool fp = false;
            bool syncAction = false;
            bool melee = false;
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

            // Process qualifiers (the first arguments).
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
            if (fp)
                firstperson = true;
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

            // Capture original GraphIndex values.
            CaptureOriginalGraphIndices();

            using (Stream cacheStream = CacheContext.OpenCacheReadWrite())
            {
                ModelAnimationGraph donorGraph = CacheContext.Deserialize<ModelAnimationGraph>(cacheStream, donorTag);

                // Rebuild InheritanceList if a flag is specified (MCC-like behavior).
                if (UseMccMode)
                {
                    Animation.InheritanceList.Clear();
                    Inheritance donorInh = new Inheritance { InheritedGraph = donorTag, Flags = inheritanceFlags };
                    RecalcInheritanceEntry(donorInh, donorGraph, firstperson);
                    Animation.InheritanceList.Add(donorInh);
                    Index = 0;
                    if (donorGraph.InheritanceList != null)
                    {
                        foreach (var inh in donorGraph.InheritanceList)
                        {
                            if (!Animation.InheritanceList.Any(x => x.InheritedGraph == inh.InheritedGraph))
                            {
                                ModelAnimationGraph subDonor = CacheContext.Deserialize<ModelAnimationGraph>(cacheStream, inh.InheritedGraph);
                                Inheritance cloned = CloneInheritance(inh);
                                cloned.Flags = inheritanceFlags;
                                RecalcInheritanceEntry(cloned, subDonor, firstperson);
                                Animation.InheritanceList.Add(cloned);
                            }
                        }
                    }
                }
                else
                {
                    var foundIndex = Animation.InheritanceList.FindIndex(x => x.InheritedGraph == donorTag);
                    if (foundIndex == -1)
                    {
                        Index = (short)Animation.InheritanceList.Count;
                        Inheritance newInh = new Inheritance { InheritedGraph = donorTag, Flags = inheritanceFlags };
                        Animation.InheritanceList.Add(newInh);
                    }
                    else
                        Index = (short)foundIndex;
                    Inheritance inhEntry = Animation.InheritanceList[Index];
                    if (inhEntry.InheritedGraph == null)
                        return new TagToolError(CommandError.TagInvalid);
                    RecalcInheritanceEntry(inhEntry, donorGraph, firstperson);
                    inhEntry.Flags = inheritanceFlags;
                }

                // --- Merging strategy:
                // If any specifics are provided, only process the specifics.
                if (specifics.Any())
                {
                    foreach (var specific in specifics)
                    {
                        if (specific.Contains(":"))
                        {
                            // Colon-separated specifics: split into parts.
                            string[] parts = specific.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length == 0)
                                continue;
                            // Locate a donor mode whose name matches or contains parts[0].
                            var donorMode = donorGraph.Modes.FirstOrDefault(m =>
                                CacheContext.StringTable.GetString(m.Name)
                                    .Equals(parts[0], StringComparison.OrdinalIgnoreCase) ||
                                CacheContext.StringTable.GetString(m.Name).Contains(parts[0], StringComparison.OrdinalIgnoreCase));
                            if (donorMode != null)
                            {
                                MergePartialFromDonorIntoTarget(donorMode, parts);
                            }
                            else
                            {
                                // Fallback: treat as a full label path.
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
                            // No colon: treat the specific as a full mode name.
                            string modeName = specific;
                            var donorMode = donorGraph.Modes.FirstOrDefault(m =>
                                CacheContext.StringTable.GetString(m.Name)
                                    .Equals(modeName, StringComparison.OrdinalIgnoreCase) ||
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
                                // Fallback: treat as a full label path.
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
                    // No specifics provided: merge based on flag qualifiers.
                    if (syncAction)
                    {
                        InheritSyncActionBlocks(Animation, donorGraph);
                    }
                    if (melee)
                    {
                        InheritMeleeBlocks(Animation, donorGraph);
                    }
                    if (vehicles)
                    {
                        InheritVehicleModes(Animation, donorGraph);
                    }
                    if (mcc)
                    {
                        InheritAllModes(Animation, donorGraph);
                    }
                    if (!syncAction && !melee && !vehicles && !mcc)
                    {
                        // Fallback if no flags are provided.
                        OverwriteInheritance(Animation, donorGraph);
                    }
                }

                // Update graph indices for all modes.
                foreach (var mode in Animation.Modes)
                {
                    UpdateGraphIndicesForMode(mode);
                }

                // Recalculate NodeMap, RootZOffset, and NodeMapFlags for each Inheritance entry.
                foreach (var inh in Animation.InheritanceList)
                {
                    ModelAnimationGraph inhGraph = CacheContext.Deserialize<ModelAnimationGraph>(cacheStream, inh.InheritedGraph);
                    RecalcInheritanceEntry(inh, inhGraph, firstperson);
                    inh.Flags = inheritanceFlags;
                }

                new SortModesCommand(CacheContext, Animation).Execute(new List<string>());
            }

            Console.WriteLine("Done.");
            return true;
        }

        // -----------------------------------------------------------------
        // Helper: Merge a partial branch from donorMode into the target.
        // -----------------------------------------------------------------
        private void MergePartialFromDonorIntoTarget(Mode donorMode, string[] parts)
        {
            Mode partialClone = CreatePartialClone(donorMode, parts);
            var targetMode = Animation.Modes.FirstOrDefault(m =>
                CacheContext.StringTable.GetString(m.Name)
                    .Equals(CacheContext.StringTable.GetString(donorMode.Name), StringComparison.OrdinalIgnoreCase));
            if (targetMode == null)
            {
                Animation.Modes.Add(partialClone);
            }
            else
            {
                MergePartialWeaponClasses(targetMode, partialClone);
            }
        }

        // -----------------------------------------------------------------
        // Helper: Create a partial clone of donorMode containing only the branch defined by parts.
        // For parts[1] (weapon class), parts[2] (weapon type) and parts[3] (action/overlay)
        // exact (case‑insensitive) matching is used.
        // -----------------------------------------------------------------
        private Mode CreatePartialClone(Mode donorMode, string[] parts)
        {
            Mode clone = new Mode
            {
                Name = donorMode.Name,
                OverlayGroup = donorMode.OverlayGroup,
                ikGroup = donorMode.ikGroup,
                StanceFlags = donorMode.StanceFlags,
                ModeIk = donorMode.ModeIk != null ? new List<ModeIkBlock>(donorMode.ModeIk) : new List<ModeIkBlock>(),
                FootDefaults = donorMode.FootDefaults != null ? new List<FootTrackingDefaultsBlock>(donorMode.FootDefaults) : new List<FootTrackingDefaultsBlock>()
            };

            // For a WeaponClass qualifier (parts[1]).
            if (parts.Length >= 2)
            {
                clone.WeaponClass = donorMode.WeaponClass
                    .Where(wc => CacheContext.StringTable.GetString(wc.Label)
                           .Equals(parts[1], StringComparison.OrdinalIgnoreCase))
                    .Select(CloneWeaponClass)
                    .ToList();
            }
            else
            {
                clone.WeaponClass = donorMode.WeaponClass?.Select(CloneWeaponClass).ToList();
            }

            // For a WeaponType qualifier (parts[2]).
            if (parts.Length >= 3)
            {
                foreach (var wc in clone.WeaponClass)
                {
                    if (wc.WeaponType != null)
                    {
                        wc.WeaponType = wc.WeaponType
                            .Where(wt => CacheContext.StringTable.GetString(wt.Label)
                                   .Equals(parts[2], StringComparison.OrdinalIgnoreCase))
                            .Select(CloneWeaponType)
                            .ToList();
                    }
                }
            }

            // For an Action/Overlay qualifier (parts[3]).
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
                                {
                                    wt.Set.Actions = wt.Set.Actions
                                        .Where(a => CacheContext.StringTable.GetString(a.Label)
                                               .Equals(parts[3], StringComparison.OrdinalIgnoreCase))
                                        .Select(CloneEntry)
                                        .ToList();
                                }
                                if (wt.Set.Overlays != null)
                                {
                                    wt.Set.Overlays = wt.Set.Overlays
                                        .Where(o => CacheContext.StringTable.GetString(o.Label)
                                               .Equals(parts[3], StringComparison.OrdinalIgnoreCase))
                                        .Select(CloneEntry)
                                        .ToList();
                                }
                            }
                        }
                    }
                }
            }

            return clone;
        }

        // -----------------------------------------------------------------
        // Helper: Merge the partial clone's WeaponClass blocks into the target mode.
        // -----------------------------------------------------------------
        private void MergePartialWeaponClasses(Mode targetMode, Mode partial)
        {
            foreach (var partialWC in partial.WeaponClass)
            {
                var targetWC = targetMode.WeaponClass.FirstOrDefault(wc => wc.Label == partialWC.Label);
                if (targetWC == null)
                {
                    targetMode.WeaponClass.Add(partialWC);
                }
                else
                {
                    foreach (var partialWT in partialWC.WeaponType)
                    {
                        var targetWT = targetWC.WeaponType.FirstOrDefault(wt => wt.Label == partialWT.Label);
                        if (targetWT == null)
                        {
                            targetWC.WeaponType.Add(partialWT);
                        }
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

        // -----------------------------------------------------------------
        // Inherit only vehicle-specific modes from donor.
        // -----------------------------------------------------------------
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
                        var targetMode = target.Modes.FirstOrDefault(m => CacheContext.StringTable.GetString(m.Name)
                            .Equals(modeName, StringComparison.OrdinalIgnoreCase));
                        if (targetMode != null)
                            InheritModeSubBlocks(targetMode, donorMode);
                    }
                }
            }
        }

        // -----------------------------------------------------------------
        // Inherit SyncActionGroups from donor into target (merge only into existing modes).
        // -----------------------------------------------------------------
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

        // -----------------------------------------------------------------
        // Inherit only "melee" blocks from donor into target.
        // This method now checks all modes and merges any action or overlay whose label contains "melee" (case-insensitive).
        // -----------------------------------------------------------------
        private void InheritMeleeBlocks(ModelAnimationGraph target, ModelAnimationGraph donor)
        {
            foreach (var donorMode in donor.Modes)
            {
                // Try to find a matching target mode.
                var donorModeStr = CacheContext.StringTable.GetString(donorMode.Name);
                var targetMode = target.Modes.FirstOrDefault(m =>
                    CacheContext.StringTable.GetString(m.Name).Equals(donorModeStr, StringComparison.OrdinalIgnoreCase));
                // If not present, create a partial clone that only retains "melee" actions/overlays.
                if (targetMode == null)
                {
                    Mode partialClone = CreatePartialClone(donorMode, new string[] { donorModeStr, "", "", "melee" });
                    if (partialClone.WeaponClass != null && partialClone.WeaponClass.Any())
                    {
                        target.Modes.Add(partialClone);
                    }
                }
                else
                {
                    if (donorMode.WeaponClass != null)
                    {
                        foreach (var donorWc in donorMode.WeaponClass)
                        {
                            var targetWc = targetMode.WeaponClass.FirstOrDefault(wc => CacheContext.StringTable.GetString(wc.Label)
                                .Equals(CacheContext.StringTable.GetString(donorWc.Label), StringComparison.OrdinalIgnoreCase));
                            if (targetWc != null && donorWc.WeaponType != null)
                            {
                                foreach (var donorWt in donorWc.WeaponType)
                                {
                                    var targetWt = targetWc.WeaponType.FirstOrDefault(wt => CacheContext.StringTable.GetString(wt.Label)
                                        .Equals(CacheContext.StringTable.GetString(donorWt.Label), StringComparison.OrdinalIgnoreCase));
                                    if (targetWt != null && donorWt.Set != null)
                                    {
                                        // Merge any actions whose label contains "melee"
                                        foreach (var donorAction in donorWt.Set.Actions.Where(a =>
                                            CacheContext.StringTable.GetString(a.Label).IndexOf("melee", StringComparison.OrdinalIgnoreCase) >= 0))
                                        {
                                            if (!targetWt.Set.Actions.Any(a =>
                                                CacheContext.StringTable.GetString(a.Label).IndexOf("melee", StringComparison.OrdinalIgnoreCase) >= 0))
                                            {
                                                targetWt.Set.Actions.Add(CloneEntry(donorAction));
                                            }
                                        }
                                        // Merge any overlays whose label contains "melee"
                                        foreach (var donorOverlay in donorWt.Set.Overlays.Where(o =>
                                            CacheContext.StringTable.GetString(o.Label).IndexOf("melee", StringComparison.OrdinalIgnoreCase) >= 0))
                                        {
                                            if (!targetWt.Set.Overlays.Any(o =>
                                                CacheContext.StringTable.GetString(o.Label).IndexOf("melee", StringComparison.OrdinalIgnoreCase) >= 0))
                                            {
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
        }

        // -----------------------------------------------------------------
        // Capture original GraphIndex values from the target.
        // -----------------------------------------------------------------
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

        // --- Helper key generators ---
        private string GetActionKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.WeaponTypeBlock wt, Mode.WeaponClassBlock.WeaponTypeBlock.Entry action)
        {
            return "A|" + mode.Name + "|" + wc.Label + "|" + wt.Label + "|" + action.Label;
        }

        private string GetOverlayKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.WeaponTypeBlock wt, Mode.WeaponClassBlock.WeaponTypeBlock.Entry overlay)
        {
            return "O|" + mode.Name + "|" + wc.Label + "|" + wt.Label + "|" + overlay.Label;
        }

        private string GetRegionKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.WeaponTypeBlock wt, int ddIndex, int dirIndex, int regIndex)
        {
            return "R|" + mode.Name + "|" + wc.Label + "|" + wt.Label + "|DD:" + ddIndex + ":" + dirIndex + ":" + regIndex;
        }

        private string GetTransitionKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.WeaponTypeBlock wt, Mode.WeaponClassBlock.WeaponTypeBlock.Transition trans, int destIndex)
        {
            return "T|" + mode.Name + "|" + wc.Label + "|" + wt.Label + "|TR:" + trans.FullName + ":" + destIndex;
        }

        // Modified to safely handle nulls.
        private string GetSameTypeParticipantKey(Mode mode, Mode.WeaponClassBlock wc, Mode.WeaponClassBlock.SyncActionGroup sag, int participantIndex)
        {
            string modeStr = mode != null ? mode.Name.ToString() : "NoMode";
            string wcStr = wc != null ? wc.Label.ToString() : "NoWeaponClass";
            string sagStr = sag != null ? sag.Name.ToString() : "NoSyncActionGroup";
            return $"S|{modeStr}|{wcStr}|{sagStr}|ST:{participantIndex}";
        }

        // -----------------------------------------------------------------
        // Recalculate NodeMap, RootZOffset, and NodeMapFlags for an Inheritance entry.
        // -----------------------------------------------------------------
        private void RecalcInheritanceEntry(Inheritance inh, ModelAnimationGraph donorGraph, bool firstperson)
        {
            float targetRoot = JmadHelper.GetRootNode(Animation).ZPosition;
            float donorRoot = JmadHelper.GetRootNode(donorGraph).ZPosition;
            inh.RootZOffset = (targetRoot == 0.0f || donorRoot == 0.0f) ? 1.0f : targetRoot / donorRoot;

            int skeletonCount = (donorGraph.SkeletonNodes != null && donorGraph.SkeletonNodes.Count > 0)
                                ? donorGraph.SkeletonNodes.Count
                                : Animation.SkeletonNodes.Count;
            if (inh.NodeMap == null || inh.NodeMap.Count != skeletonCount)
            {
                inh.NodeMap = new List<Inheritance.NodeMapBlock>();
                for (int i = 0; i < skeletonCount; i++)
                    inh.NodeMap.Add(new Inheritance.NodeMapBlock());
            }
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

        // -----------------------------------------------------------------
        // MCC Mode: Inherit every missing Mode and sub–block from donor's Modes.
        // -----------------------------------------------------------------
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

        // Deep clone a Mode.
        private Mode CloneMode(Mode donorMode)
        {
            Mode clone = new Mode
            {
                Name = donorMode.Name,
                OverlayGroup = donorMode.OverlayGroup,
                ikGroup = donorMode.ikGroup,
                StanceFlags = donorMode.StanceFlags,
                WeaponClass = donorMode.WeaponClass?.Select(wc => CloneWeaponClass(wc)).ToList() ?? new List<Mode.WeaponClassBlock>(),
                ModeIk = donorMode.ModeIk != null ? new List<ModeIkBlock>(donorMode.ModeIk) : new List<ModeIkBlock>(),
                FootDefaults = donorMode.FootDefaults != null ? new List<FootTrackingDefaultsBlock>(donorMode.FootDefaults) : new List<FootTrackingDefaultsBlock>()
            };
            return clone;
        }

        private Mode.WeaponClassBlock CloneWeaponClass(Mode.WeaponClassBlock donorClass)
        {
            Mode.WeaponClassBlock clone = new Mode.WeaponClassBlock
            {
                Label = donorClass.Label,
                OverlayGroup = donorClass.OverlayGroup,
                ikGroup = donorClass.ikGroup,
                WeaponType = donorClass.WeaponType?.Select(wt => CloneWeaponType(wt)).ToList() ?? new List<Mode.WeaponClassBlock.WeaponTypeBlock>(),
                WeaponIk = donorClass.WeaponIk != null ? new List<ModeIkBlock>(donorClass.WeaponIk) : new List<ModeIkBlock>(),
                SyncActionGroups = donorClass.SyncActionGroups != null ? new List<Mode.WeaponClassBlock.SyncActionGroup>(donorClass.SyncActionGroups) : new List<Mode.WeaponClassBlock.SyncActionGroup>(),
                RangedActions = (byte[])donorClass.RangedActions.Clone()
            };
            return clone;
        }

        private Mode.WeaponClassBlock.WeaponTypeBlock CloneWeaponType(Mode.WeaponClassBlock.WeaponTypeBlock donorType)
        {
            Mode.WeaponClassBlock.WeaponTypeBlock clone = new Mode.WeaponClassBlock.WeaponTypeBlock
            {
                Label = donorType.Label,
                OverlayGroup = donorType.OverlayGroup,
                ikGroup = donorType.ikGroup,
                AnimationSetsReach = donorType.AnimationSetsReach != null ? new List<Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet>(donorType.AnimationSetsReach) : new List<Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet>(),
                Set = donorType.Set
            };
            return clone;
        }

        // Merge missing sub–blocks from donor Mode into target Mode.
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
                                if (!targetClass.WeaponIk.Any(tik => tik.Marker == donorIk.Marker && tik.AttachToMarker == donorIk.AttachToMarker))
                                    targetClass.WeaponIk.Add(donorIk);
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
                    targetMode.ModeIk = new List<ModeIkBlock>();
                foreach (var donorIk in donorMode.ModeIk)
                {
                    if (!targetMode.ModeIk.Any(tik => tik.Marker == donorIk.Marker && tik.AttachToMarker == donorIk.AttachToMarker))
                        targetMode.ModeIk.Add(donorIk);
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

        // Inherit AnimationSet entries (Actions, Overlays, DeathAndDamage, Transitions) from donor into target.
        private void InheritAnimationSet(Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet targetSet,
                                         Mode.WeaponClassBlock.WeaponTypeBlock.AnimationSet donorSet)
        {
            if (donorSet.Actions != null)
            {
                foreach (var donorEntry in donorSet.Actions)
                {
                    if (!targetSet.Actions.Any(te => te.Label == donorEntry.Label))
                    {
                        var entryClone = CloneEntry(donorEntry);
                        entryClone.GraphIndex = ComputeNewGraphIndexForMapping(donorEntry.GraphIndex);
                        targetSet.Actions.Add(entryClone);
                    }
                }
            }
            if (donorSet.Overlays != null)
            {
                foreach (var donorEntry in donorSet.Overlays)
                {
                    if (!targetSet.Overlays.Any(te => te.Label == donorEntry.Label))
                    {
                        var entryClone = CloneEntry(donorEntry);
                        entryClone.GraphIndex = ComputeNewGraphIndexForMapping(donorEntry.GraphIndex);
                        targetSet.Overlays.Add(entryClone);
                    }
                }
            }
            if (donorSet.DeathAndDamage != null)
            {
                foreach (var donorDAD in donorSet.DeathAndDamage)
                {
                    if (!targetSet.DeathAndDamage.Any(tdad => tdad.Label == donorDAD.Label))
                    {
                        targetSet.DeathAndDamage.Add(CloneDeathAndDamageBlock(donorDAD));
                    }
                }
            }
            if (donorSet.Transitions != null)
            {
                foreach (var donorTrans in donorSet.Transitions)
                {
                    if (!targetSet.Transitions.Any(tt => tt.FullName == donorTrans.FullName))
                    {
                        targetSet.Transitions.Add(CloneTransition(donorTrans));
                    }
                }
            }
        }

        // Clone an AnimationSet entry.
        private Mode.WeaponClassBlock.WeaponTypeBlock.Entry CloneEntry(Mode.WeaponClassBlock.WeaponTypeBlock.Entry donorEntry)
        {
            return new Mode.WeaponClassBlock.WeaponTypeBlock.Entry
            {
                Label = donorEntry.Label,
                OverlayGroup = donorEntry.OverlayGroup,
                ikGroup = donorEntry.ikGroup,
                Animation = donorEntry.Animation,
                GraphIndex = donorEntry.GraphIndex
            };
        }

        // Inherit SyncActionGroup data.
        private void InheritSyncActions(Mode.WeaponClassBlock.SyncActionGroup targetSAG, Mode.WeaponClassBlock.SyncActionGroup donorSAG)
        {
            if (donorSAG.SyncActions != null)
            {
                foreach (var donorSync in donorSAG.SyncActions)
                {
                    var targetSync = targetSAG.SyncActions.FirstOrDefault(sa => sa.Name == donorSync.Name);
                    if (targetSync == null)
                    {
                        targetSAG.SyncActions.Add(donorSync);
                    }
                    else
                    {
                        if (donorSync.SameTypeParticipants != null)
                        {
                            int participantIndex = 0;
                            foreach (var donorPart in donorSync.SameTypeParticipants)
                            {
                                var newParticipant = CloneSameTypeParticipant(donorPart);
                                newParticipant.GraphIndex = ComputeNewGraphIndexForMapping(donorPart.GraphIndex);
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

        // Clone a SameTypeParticipant.
        private Mode.WeaponClassBlock.SyncActionGroup.SyncAction.SameTypeParticipant CloneSameTypeParticipant(Mode.WeaponClassBlock.SyncActionGroup.SyncAction.SameTypeParticipant donorParticipant)
        {
            return new Mode.WeaponClassBlock.SyncActionGroup.SyncAction.SameTypeParticipant
            {
                Flags = donorParticipant.Flags,
                GraphIndex = donorParticipant.GraphIndex,
                Animation = donorParticipant.Animation,
                StartOffset = donorParticipant.StartOffset,
                StartFacing = donorParticipant.StartFacing,
                EndOffset = donorParticipant.EndOffset,
                TimeUntilHurt = donorParticipant.TimeUntilHurt
            };
        }

        // Update GraphIndex values in all inherited entries within a Mode.
        private void UpdateGraphIndicesForMode(Mode mode)
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
                                        if (originalGraphIndices.ContainsKey(key))
                                            action.GraphIndex = originalGraphIndices[key];
                                        else
                                            action.GraphIndex = ComputeNewGraphIndexForMapping(action.GraphIndex);
                                    }
                                }
                                if (wt.Set.Overlays != null)
                                {
                                    foreach (var overlay in wt.Set.Overlays)
                                    {
                                        string key = GetOverlayKey(mode, wc, wt, overlay);
                                        if (originalGraphIndices.ContainsKey(key))
                                            overlay.GraphIndex = originalGraphIndices[key];
                                        else
                                            overlay.GraphIndex = ComputeNewGraphIndexForMapping(overlay.GraphIndex);
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
                                                if (originalGraphIndices.ContainsKey(key))
                                                    reg.GraphIndex = originalGraphIndices[key];
                                                else
                                                    reg.GraphIndex = ComputeNewGraphIndexForMapping(reg.GraphIndex);
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
                                            if (originalGraphIndices.ContainsKey(key))
                                                dest.GraphIndex = originalGraphIndices[key];
                                            else
                                                dest.GraphIndex = ComputeNewGraphIndexForMapping(dest.GraphIndex);
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
                                    if (originalGraphIndices.ContainsKey(key))
                                        participant.GraphIndex = originalGraphIndices[key];
                                    else
                                        participant.GraphIndex = ComputeNewGraphIndexForMapping(participant.GraphIndex);
                                    partIndex++;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Compute the new GraphIndex for mapping: donorGraphIndex + 1.
        /// </summary>
        private short ComputeNewGraphIndexForMapping(short donorGraphIndex)
        {
            return (short)(donorGraphIndex + 1);
        }

        // -----------------------------------------------------------------
        // Cloning helpers for Inheritance entries, DeathAndDamage blocks, and Transitions.
        // -----------------------------------------------------------------
        private Inheritance CloneInheritance(Inheritance donorInh)
        {
            Inheritance clone = new Inheritance
            {
                InheritedGraph = donorInh.InheritedGraph,
                RootZOffset = donorInh.RootZOffset,
                Flags = donorInh.Flags,
                NodeMap = donorInh.NodeMap != null ? donorInh.NodeMap.Select(n => new Inheritance.NodeMapBlock { LocalNode = n.LocalNode }).ToList() : new List<Inheritance.NodeMapBlock>(),
                NodeMapFlags = donorInh.NodeMapFlags != null ? donorInh.NodeMapFlags.Select(f => new Inheritance.NodeMapFlag { LocalNodeFlags = f.LocalNodeFlags }).ToList() : new List<Inheritance.NodeMapFlag>()
            };
            return clone;
        }

        private Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock CloneDeathAndDamageBlock(Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock donorDAD)
        {
            var clone = new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock
            {
                Label = donorDAD.Label,
                Directions = donorDAD.Directions?.Select(dir => CloneDirection(dir)).ToList()
            };
            return clone;
        }

        private Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction CloneDirection(Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction donorDir)
        {
            var clone = new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction
            {
                Regions = donorDir.Regions?.Select(reg => new Mode.WeaponClassBlock.WeaponTypeBlock.DeathAndDamageBlock.Direction.Region
                {
                    GraphIndex = reg.GraphIndex,
                    Animation = reg.Animation
                }).ToList()
            };
            return clone;
        }

        private Mode.WeaponClassBlock.WeaponTypeBlock.Transition CloneTransition(Mode.WeaponClassBlock.WeaponTypeBlock.Transition donorTrans)
        {
            var clone = new Mode.WeaponClassBlock.WeaponTypeBlock.Transition
            {
                FullName = donorTrans.FullName,
                StateName = donorTrans.StateName,
                Padding0 = (donorTrans.Padding0 != null) ? (byte[])donorTrans.Padding0.Clone() : null,
                IndexA = donorTrans.IndexA,
                IndexB = donorTrans.IndexB,
                Destinations = donorTrans.Destinations?.Select(dest => CloneDestination(dest)).ToList()
            };
            return clone;
        }

        private Mode.WeaponClassBlock.WeaponTypeBlock.Transition.Destination CloneDestination(Mode.WeaponClassBlock.WeaponTypeBlock.Transition.Destination donorDest)
        {
            var clone = new Mode.WeaponClassBlock.WeaponTypeBlock.Transition.Destination
            {
                FullName = donorDest.FullName,
                ModeName = donorDest.ModeName,
                StateName = donorDest.StateName,
                FrameEventLink = donorDest.FrameEventLink,
                Padding1 = (donorDest.Padding1 != null) ? (byte[])donorDest.Padding1.Clone() : null,
                IndexA = donorDest.IndexA,
                IndexB = donorDest.IndexB,
                GraphIndex = donorDest.GraphIndex,
                Animation = donorDest.Animation
            };
            return clone;
        }

        // -----------------------------------------------------------------
        // Fallback: Overwrite inheritance (non-MCC mode).
        // -----------------------------------------------------------------
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
                            foreach (var dir in dd.Directions)
                                foreach (var region in dir.Regions)
                                {
                                    if (region.GraphIndex == Index)
                                    {
                                        StringId animName = donor.Animations[region.Animation].Name;
                                        region.Animation = (short)donor.Animations.FindIndex(x => x.Name == animName);
                                    }
                                }
                        foreach (var trs in wType.Set.Transitions)
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
    }
}
