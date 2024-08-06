using TagTool.Cache.HaloOnline;
using TagTool.Cache;

namespace TagTool.MtnDewIt.JSON.Handlers
{
    public class TagStructureHandler 
    {
        GameCache Cache;
        GameCacheHaloOnline CacheContext;

        public TagStructureHandler(GameCache cache, GameCacheHaloOnline cacheContext)
        {
            Cache = cache;
            CacheContext = cacheContext;
        }
    }
}