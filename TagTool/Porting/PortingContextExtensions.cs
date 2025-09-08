using System.IO;
using TagTool.Cache;

namespace TagTool.Porting
{
    public static class PortingContextExtensions
    {
        /// <summary>
        /// Ports a tag from source cache to the destination cache
        /// </summary>
        /// <remarks>
        /// NOTE: For bulk conversion consider using <see cref="PortingContext.ConvertTag"/>
        /// </remarks>
        public static CachedTag PortTag(this PortingContext context, string tagPath, PortingFlags flags = PortingFlags.Default)
        {
            return PortTag(context, context.BlamCache.TagCache.GetTag(tagPath), flags);
        }

        /// <summary>
        /// Ports a tag from source cache to the destination cache
        /// </summary>
        /// <remarks>
        /// NOTE: For bulk conversion consider using <see cref="PortingContext.ConvertTag"/>
        /// </remarks>
        public static CachedTag PortTag(this PortingContext context, CachedTag tag, PortingFlags flags = PortingFlags.Default)
        {
            using Stream cacheStream = context.CacheContext.OpenCacheReadWrite();
            using Stream blamCacheStream = context.BlamCache is GameCacheModPackage package ? package.OpenCacheRead(cacheStream) : context.BlamCache.OpenCacheRead();

            using var portingScope = context.CreateScope(flags);
            return context.ConvertTag(cacheStream, blamCacheStream, tag);
        }
    }
}
