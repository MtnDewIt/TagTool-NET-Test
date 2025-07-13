using System.Collections.Generic;
using System.IO;
using TagTool.Cache.Gen3;
using TagTool.Cache.HaloOnline;
using TagTool.IO;

namespace TagTool.Cache.ModPackages
{
    public class ModPackageCacheUtils
    {
        public static void BuildInitialTagCache(GameCacheHaloOnlineBase baseCache, out Dictionary<int, string> tagNames, out Stream stream)
        {
            tagNames = new Dictionary<int, string>();
            stream = new MemoryStream();

            var writer = new EndianWriter(stream, false);

            var stringTable = new StringTableHaloOnline(baseCache.Version);
            stringTable.AddRange(baseCache.StringTable);

            var modTagCache = new TagCacheHaloOnline(baseCache.Version, stream, stringTable);

            stream.Seek(0, SeekOrigin.End);
            for (var tagIndex = 0; tagIndex < baseCache.TagCache.Count; tagIndex++)
            {
                var srcTag = baseCache.TagCache.GetTag(tagIndex);

                if (srcTag == null)
                {
                    modTagCache.AllocateTag(new TagGroupGen3());
                    continue;
                }

                var emptyTag = (CachedTagHaloOnline)modTagCache.AllocateTag(srcTag.Group, srcTag.Name);
                var cachedTagData = new CachedTagData
                {
                    Data = [],
                    Group = (TagGroupGen3)emptyTag.Group,
                };

                var headerSize = CachedTagHaloOnline.CalculateHeaderSize(cachedTagData);
                var alignedHeaderSize = (uint)(headerSize + 0xF & ~0xF);
                emptyTag.HeaderOffset = stream.Position;
                emptyTag.Offset = alignedHeaderSize;
                emptyTag.TotalSize = alignedHeaderSize;
                emptyTag.WriteHeader(writer, modTagCache.StringTableReference);
                StreamUtil.Fill(stream, 0, (int)(alignedHeaderSize - headerSize));

                tagNames[srcTag.Index] = srcTag.Name;
            }

            modTagCache.UpdateTagOffsets(writer);
        }
    }
}
