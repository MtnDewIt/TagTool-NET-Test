using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.Utils;
using TagTool.Commands.Common;

namespace TagTool.Commands.Tags
{
    public class ReplaceTagCommand : Command
    {
        private readonly GameCacheHaloOnlineBase Cache;

        public ReplaceTagCommand(GameCacheHaloOnlineBase cache)
            : base(true,

                "ReplaceTag",
                "Replaces a tag with another tag from the cache",

                "ReplaceTag <tag> <replacement tag>",

                "")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 2)
                return new TagToolError(CommandError.ArgCount);

            if (!Cache.TagCache.TryGetTag(args[0], out CachedTag tag))
                return new TagToolError(CommandError.TagInvalid, args[0]);

            if (!Cache.TagCache.TryGetTag(args[1], out CachedTag replacementTag))
                return new TagToolError(CommandError.TagInvalid, args[1]);

            using Stream cacheStream = Cache.OpenCacheReadWrite();

            TagReplacer.ReplaceTag(Cache, cacheStream, tag, replacementTag);

            return true;
        }
    }
}
