using System.Collections.Generic;
using System.IO;
using TagTool.Cache;

namespace TagTool.Porting
{
    public class TagDefinitionCache
    {
        private Dictionary<CachedTag, object> CachedTagData = [];

        public T Deserialize<T>(GameCache cache, Stream stream, CachedTag tag)
        {
            return (T)Deserialize(cache, stream, tag);
        }

        public object Deserialize(GameCache cache, Stream stream, CachedTag tag)
        {
            if (!CachedTagData.TryGetValue(tag, out object value))
                CachedTagData.Add(tag, value = cache.Deserialize(stream, tag));
            return value;
        }

        public void Clear()
        {
            CachedTagData.Clear();
        }

        public void Evict(CachedTag tag)
        {
            CachedTagData.Remove(tag);
        }
    }
}
