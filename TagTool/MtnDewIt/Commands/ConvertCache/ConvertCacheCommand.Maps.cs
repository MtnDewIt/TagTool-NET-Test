using System;
using System.IO;
using System.Linq;
using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Commands;
using TagTool.Common;
using TagTool.IO;
using TagTool.MtnDewIt.Commands.ConvertCache.Maps;

namespace TagTool.MtnDewIt.Commands.ConvertCache 
{
    partial class ConvertCacheCommand : Command
    {
        public void UpdateMapFiles()
        {
            using (var stream = Cache.OpenCacheReadWrite()) 
            {
                new bunkerworld(Cache, CacheContext, stream);

                new chill(Cache, CacheContext, stream);

                new cyberdyne(Cache, CacheContext, stream);

                new deadlock(Cache, CacheContext, stream);

                new guardian(Cache, CacheContext, stream);

                new mainmenu(Cache, CacheContext, stream);

                new riverworld(Cache, CacheContext, stream);

                new s3d_avalanche(Cache, CacheContext, stream);

                new s3d_edge(Cache, CacheContext, stream);

                new s3d_reactor(Cache, CacheContext, stream);

                new s3d_turf(Cache, CacheContext, stream);

                new shrine(Cache, CacheContext, stream);

                new zanzibar(Cache, CacheContext, stream);
            }
        }
    }
}