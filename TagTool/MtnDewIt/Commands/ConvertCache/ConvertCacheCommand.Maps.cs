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
            new bunkerworld(Cache, CacheContext, CacheStream);

            new chill(Cache, CacheContext, CacheStream);

            new cyberdyne(Cache, CacheContext, CacheStream);

            new deadlock(Cache, CacheContext, CacheStream);

            new guardian(Cache, CacheContext, CacheStream);

            new mainmenu(Cache, CacheContext, CacheStream);

            new riverworld(Cache, CacheContext, CacheStream);

            new s3d_avalanche(Cache, CacheContext, CacheStream);

            new s3d_edge(Cache, CacheContext, CacheStream);

            new s3d_reactor(Cache, CacheContext, CacheStream);

            new s3d_turf(Cache, CacheContext, CacheStream);

            new shrine(Cache, CacheContext, CacheStream);

            new zanzibar(Cache, CacheContext, CacheStream);
        }
    }
}