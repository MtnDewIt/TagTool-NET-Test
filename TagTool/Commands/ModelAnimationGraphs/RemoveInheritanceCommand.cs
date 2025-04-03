using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Animations;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.ModelAnimationGraphs
{
    /// <summary>
    /// Removes all blocks from modes sub blocks that have GraphIndex above -1.
    /// Additionally, if a main block (WeaponType, WeaponClass, or Mode) becomes empty,
    /// it is removed. Also clears the InheritanceList and sets ParentAnimationGraph to null.
    /// </summary>
    public class RemoveInheritanceCommand : Command
    {
        private GameCache CacheContext { get; }
        private ModelAnimationGraph Animation { get; }
        private CachedTag AnimationTag { get; }

        public RemoveInheritanceCommand(GameCache cacheContext, ModelAnimationGraph animation, CachedTag animationTag)
            : base(false,
                   "RemoveInheritance",
                   "Removes all blocks with GraphIndex above -1 from the modes sub blocks, removes main blocks that become empty, clears the inheritance list, and nullifies ParentAnimationGraph.",
                   "RemoveInheritance <tag>",
                   "Clears inherited blocks from modes, resets the inheritance list, and nullifies ParentAnimationGraph.")
        {
            CacheContext = cacheContext;
            Animation = animation;
            AnimationTag = animationTag;
        }

        public override object Execute(List<string> args)
        {
            // First pass: remove inherited sub-blocks from each mode.
            if (Animation.Modes != null)
            {
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
                                        // Remove Actions with GraphIndex > -1.
                                        if (wt.Set.Actions != null)
                                            wt.Set.Actions.RemoveAll(action => action.GraphIndex > -1);

                                        // Remove Overlays with GraphIndex > -1.
                                        if (wt.Set.Overlays != null)
                                            wt.Set.Overlays.RemoveAll(overlay => overlay.GraphIndex > -1);

                                        // Process DeathAndDamage blocks.
                                        if (wt.Set.DeathAndDamage != null)
                                        {
                                            foreach (var dad in wt.Set.DeathAndDamage)
                                            {
                                                if (dad.Directions != null)
                                                {
                                                    foreach (var dir in dad.Directions)
                                                    {
                                                        if (dir.Regions != null)
                                                            dir.Regions.RemoveAll(region => region.GraphIndex > -1);
                                                    }
                                                }
                                            }
                                        }

                                        // Process Transitions.
                                        if (wt.Set.Transitions != null)
                                        {
                                            // Iterate backwards to allow safe removal.
                                            for (int i = wt.Set.Transitions.Count - 1; i >= 0; i--)
                                            {
                                                var trans = wt.Set.Transitions[i];
                                                if (trans.Destinations != null)
                                                {
                                                    trans.Destinations.RemoveAll(dest => dest.GraphIndex > -1);
                                                }
                                                // Remove transition if no destinations remain.
                                                if (trans.Destinations == null || trans.Destinations.Count == 0)
                                                {
                                                    wt.Set.Transitions.RemoveAt(i);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            // Process SyncActionGroups.
                            if (wc.SyncActionGroups != null)
                            {
                                foreach (var sag in wc.SyncActionGroups)
                                {
                                    if (sag.SyncActions != null)
                                    {
                                        foreach (var sync in sag.SyncActions)
                                        {
                                            if (sync.SameTypeParticipants != null)
                                                sync.SameTypeParticipants.RemoveAll(participant => participant.GraphIndex > -1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Second pass: cleanup empty main blocks.
            // Local function to determine if a WeaponType block is empty.
            bool IsWeaponTypeEmpty(ModelAnimationGraph.Mode.WeaponClassBlock.WeaponTypeBlock wt)
            {
                if (wt.Set == null)
                    return true;
                bool actionsEmpty = (wt.Set.Actions == null || wt.Set.Actions.Count == 0);
                bool overlaysEmpty = (wt.Set.Overlays == null || wt.Set.Overlays.Count == 0);
                bool deathAndDamageEmpty = true;
                if (wt.Set.DeathAndDamage != null)
                {
                    foreach (var dad in wt.Set.DeathAndDamage)
                    {
                        if (dad.Directions != null)
                        {
                            foreach (var dir in dad.Directions)
                            {
                                if (dir.Regions != null && dir.Regions.Count > 0)
                                {
                                    deathAndDamageEmpty = false;
                                    break;
                                }
                            }
                            if (!deathAndDamageEmpty)
                                break;
                        }
                    }
                }
                bool transitionsEmpty = (wt.Set.Transitions == null || wt.Set.Transitions.Count == 0);
                return actionsEmpty && overlaysEmpty && deathAndDamageEmpty && transitionsEmpty;
            }

            // Iterate modes in reverse to safely remove empty ones.
            if (Animation.Modes != null)
            {
                for (int m = Animation.Modes.Count - 1; m >= 0; m--)
                {
                    var mode = Animation.Modes[m];
                    if (mode.WeaponClass != null)
                    {
                        // Process each WeaponClass block.
                        for (int wcIndex = mode.WeaponClass.Count - 1; wcIndex >= 0; wcIndex--)
                        {
                            var wc = mode.WeaponClass[wcIndex];
                            // Clean up WeaponType blocks inside this WeaponClass.
                            if (wc.WeaponType != null)
                            {
                                wc.WeaponType.RemoveAll(wt => IsWeaponTypeEmpty(wt));
                            }

                            // Determine if SyncActionGroups are empty.
                            bool syncGroupsEmpty = true;
                            if (wc.SyncActionGroups != null)
                            {
                                foreach (var sag in wc.SyncActionGroups)
                                {
                                    if (sag.SyncActions != null)
                                    {
                                        foreach (var sync in sag.SyncActions)
                                        {
                                            if (sync.SameTypeParticipants != null && sync.SameTypeParticipants.Count > 0)
                                            {
                                                syncGroupsEmpty = false;
                                                break;
                                            }
                                        }
                                        if (!syncGroupsEmpty)
                                            break;
                                    }
                                }
                            }

                            // If both the WeaponType list and SyncActionGroups are empty, remove the WeaponClass block.
                            bool weaponTypesEmpty = (wc.WeaponType == null || wc.WeaponType.Count == 0);
                            if (weaponTypesEmpty && syncGroupsEmpty)
                            {
                                mode.WeaponClass.RemoveAt(wcIndex);
                            }
                        }
                    }

                    // If the mode no longer contains any WeaponClass blocks, remove the mode.
                    if (mode.WeaponClass == null || mode.WeaponClass.Count == 0)
                    {
                        Animation.Modes.RemoveAt(m);
                    }
                }
            }

            // Clear the entire inheritance list.
            if (Animation.InheritanceList != null)
            {
                Animation.InheritanceList.Clear();
            }

            // Set ParentAnimationGraph to null.
            Animation.ParentAnimationGraph = null;

            // Write the changes back to the cache.
            using (Stream cacheStream = CacheContext.OpenCacheReadWrite())
            {
                CacheContext.Serialize(cacheStream, AnimationTag, Animation);
            }

            Console.WriteLine("Done.");
            return true;
        }
    }
}
