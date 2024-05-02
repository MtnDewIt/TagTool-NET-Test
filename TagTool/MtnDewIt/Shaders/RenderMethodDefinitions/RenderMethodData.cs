using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands;
using System.IO;
using TagTool.Tags;
using System;
using TagTool.Common;
using TagTool.Tags.Definitions;

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

        public CachedTag GenerateOptionData<T>() where T : RenderMethodData
        {
            var typeName = typeof(T).Name;
            var tagName = typeName.Replace("_render_method_option", "").Replace("shaders_", "shaders\\").Replace("_options_", "_options\\");

            if (!Cache.TagCache.TryGetTag<RenderMethodOption>(tagName, out var result))
            {
                result = Cache.TagCache.AllocateTag<RenderMethodOption>(tagName);
                var definition = Activator.CreateInstance<RenderMethodOption>();
                CacheContext.Serialize(Stream, result, definition);
                CacheContext.SaveTagNames();
            }

            object[] args = { Cache, CacheContext, Stream };

            var tagObject = Activator.CreateInstance(typeof(T), args);

            return result;
        }

        public abstract void RenderMethod();
    }
}
