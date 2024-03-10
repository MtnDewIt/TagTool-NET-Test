using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands;
using System.IO;

namespace TagTool.MtnDewIt.Shaders.RenderMethodDefinitions
{
    public abstract class RenderMethodData
    {
        public GameCache Cache { get; set; }
        public GameCacheHaloOnline CacheContext { get; set; }
        public Stream Stream { get; set; }
        public RenderMethodData(GameCache cache, GameCacheHaloOnline cacheContext, Stream stream)
        {
            Cache = cache;
            CacheContext = cacheContext;
            Stream = stream;
        }

        public abstract void RenderMethod();
    }
}
