using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands;
using System.IO;
using TagTool.Tags;
using System;
using TagTool.Common;

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

        public CachedTag GenerateTag<T>(string tagName) where T : TagStructure
        {
            if (!Cache.TagCache.TryGetTag<T>(tagName, out var result)) 
            {
                result = Cache.TagCache.AllocateTag<T>(tagName);
                var definition = Activator.CreateInstance<T>();
                CacheContext.Serialize(Stream, result, definition);
                CacheContext.SaveTagNames();
            }

            return result;
        }

        public abstract void RenderMethod();
    }
}
