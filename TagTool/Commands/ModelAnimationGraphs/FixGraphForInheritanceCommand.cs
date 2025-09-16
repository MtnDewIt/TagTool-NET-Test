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
    /// Removes all ObjectSpaceParentNodes from every animation’s animation data.
    /// Doing so prevents inherited animations from twisting to odd angles if the inherited graphs don't have the exact nodes.
    /// </summary>
    public class FixGraphForInheritanceCommand : Command
    {
        private GameCache CacheContext { get; }
        private ModelAnimationGraph Animation { get; }
        private CachedTag AnimationTag { get; }

        public FixGraphForInheritanceCommand(GameCache cacheContext, ModelAnimationGraph animation, CachedTag animationTag)
            : base(false,
                   "FixGraphForInheritance",
                   "Removes all ObjectSpaceParentNodes from all animations and animation data. Doing so prevents inherited animations from twisting to odd angles if the inherited graphs don't have the exact nodes.",
                   "FixGraphForInheritance <tag>",
                   "Clears the ObjectSpaceParentNodes list from each animation’s SharedAnimationData blocks to prevent twisting issues during inheritance.")
        {
            CacheContext = cacheContext;
            Animation = animation;
            AnimationTag = animationTag;
        }

        public override object Execute(List<string> args)
        {
            // Iterate over all animations in the model animation graph.
            if (Animation.Animations != null)
            {
                foreach (var anim in Animation.Animations)
                {
                    // For inline animation data (e.g. Eldorado version)
                    if (anim.AnimationData != null && anim.AnimationData.ObjectSpaceParentNodes != null)
                    {
                        anim.AnimationData.ObjectSpaceParentNodes.Clear();
                    }

                    // For animation data blocks (e.g. Halo Reach and later)
                    if (anim.AnimationDataBlock != null)
                    {
                        foreach (var data in anim.AnimationDataBlock)
                        {
                            if (data.ObjectSpaceParentNodes != null)
                            {
                                data.ObjectSpaceParentNodes.Clear();
                            }
                        }
                    }
                }
            }

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
