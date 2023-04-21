using System.Collections.Generic;
using TagTool.Common;
using TagTool.Tags.Definitions;
using TagTool.Tags.Definitions.Common;

namespace TagTool.Commands.Tags
{
    partial class PortingCacheCommand : Command
    {
        public void applyUIPatches() 
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                foreach (var tag in CacheContext.TagCache.NonNull()) 
                {
                    // Will update once the main menu UI is functional
                }
            }
        }
    }
}