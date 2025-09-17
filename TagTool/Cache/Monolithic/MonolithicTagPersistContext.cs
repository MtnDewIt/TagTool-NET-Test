using System.Collections.Generic;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Common.Logging;

namespace TagTool.Cache.Monolithic
{
    public class MonolithicTagPersistContext : ISingleTagFilePersistContext
    {
        public GameCacheMonolithic Cache;
        public Dictionary<DatumHandle, TagResourceXSyncState> TagResources;

        public MonolithicTagPersistContext(GameCacheMonolithic cache)
        {
            Cache = cache;
            TagResources = new Dictionary<DatumHandle, TagResourceXSyncState>();
        }

        public void AddTagResource(DatumHandle resourceHandle, TagResourceXSyncState state)
        {
            TagResources.Add(resourceHandle, state);
        }
        public void AddTagResourceData(byte[] data)
        {

        }

        public StringId AddStringId(string stringvalue)
        {
            return Cache.StringTableMono.GetOrAddString(stringvalue);
        }

        public CachedTag GetTag(Tag groupTag, string name)
        {
            if (Cache.TagCache.TryGetCachedTag($"{name}.{groupTag}", out CachedTag tag))
                return tag;
            Log.Warning($"Could not resolve referenced tag {name}.{groupTag}");
            return null;
        }
    }
}
