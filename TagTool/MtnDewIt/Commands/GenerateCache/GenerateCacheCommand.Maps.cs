using TagTool.MtnDewIt.Commands.GenerateCache.Maps;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void UpdateMapFiles()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                new mainmenu(Cache, CacheContext, stream);

                new campaign(Cache, CacheContext, stream);
            }
        }
    }
}