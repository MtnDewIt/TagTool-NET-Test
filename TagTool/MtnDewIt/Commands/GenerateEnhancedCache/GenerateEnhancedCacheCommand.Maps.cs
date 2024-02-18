using TagTool.Commands;
using TagTool.MtnDewIt.Commands.GenerateEnhancedCache.Maps;

namespace TagTool.MtnDewIt.Commands.GenerateEnhancedCache
{
    partial class GenerateEnhancedCacheCommand : Command
    {
        public void UpdateMapFiles()
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                new armory(Cache, CacheContext, stream);
                
                new bunkerworld(Cache, CacheContext, stream);
                
                new chill(Cache, CacheContext, stream);
                
                new chillout(Cache, CacheContext, stream);
                
                new construct(Cache, CacheContext, stream);
                
                new cyberdyne(Cache, CacheContext, stream);
                
                new deadlock(Cache, CacheContext, stream);
                
                new descent(Cache, CacheContext, stream);
                
                new docks(Cache, CacheContext, stream);
                
                new fortress(Cache, CacheContext, stream);
                
                new ghosttown(Cache, CacheContext, stream);
                
                new guardian(Cache, CacheContext, stream);
                
                new isolation(Cache, CacheContext, stream);
                
                new lockout(Cache, CacheContext, stream);
                
                new mainmenu(Cache, CacheContext, stream);
                
                new midship(Cache, CacheContext, stream);
                
                new riverworld(Cache, CacheContext, stream);
                
                new s3d_avalanche(Cache, CacheContext, stream);
                
                new s3d_edge(Cache, CacheContext, stream);
                
                new s3d_lockout(Cache, CacheContext, stream);
                
                new s3d_powerhouse(Cache, CacheContext, stream);
                
                new s3d_reactor(Cache, CacheContext, stream);
                
                new s3d_sky_bridgenew(Cache, CacheContext, stream); 
                
                new s3d_turf(Cache, CacheContext, stream);
                
                new s3d_waterfall(Cache, CacheContext, stream);

                new salvation(Cache, CacheContext, stream);
                
                new sandbox(Cache, CacheContext, stream);
                
                new shrine(Cache, CacheContext, stream);
                
                new sidewinder(Cache, CacheContext, stream);
                
                new snowbound(Cache, CacheContext, stream);
                
                new spacecamp(Cache, CacheContext, stream);
                
                new warehouse(Cache, CacheContext, stream);
                
                new zanzibar(Cache, CacheContext, stream);
            }
        }
    }
}