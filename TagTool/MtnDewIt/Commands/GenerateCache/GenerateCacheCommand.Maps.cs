using TagTool.MtnDewIt.Commands.GenerateCache.Maps;
using TagTool.Commands;

namespace TagTool.MtnDewIt.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public void UpdateMapFiles()
        {
            new mainmenu(Cache, CacheContext, CacheStream);

            new campaign(Cache, CacheContext, CacheStream);
        }
    }
}