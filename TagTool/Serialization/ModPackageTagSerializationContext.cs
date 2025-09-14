using System.IO;
using TagTool.Cache;
using TagTool.Tags;
using TagTool.Cache.Eldorado;

namespace TagTool.Serialization
{
    class ModPackageTagSerializationContext : EldoradoSerializationContext
    {
        private TagCacheEldorado ModPackageTagCache;

        public ModPackageTagSerializationContext(Stream stream, GameCacheEldoradoBase context, CachedTagEldorado tag) : base(stream, context, tag)
        {
            ModPackageTagCache = context.TagCacheEldorado;
        }

        public override CachedTag GetTagByIndex(int index)
        {
            if (index < 0 || index >= ModPackageTagCache.Tags.Count)
                return null;

            return ModPackageTagCache.Tags[index];
        }

        public override CachedTag GetTagByName(TagGroup group, string name)
        {
            foreach(var tag in Context.TagCacheEldorado.Tags)
            {
                if (tag.Name == name && group == tag.Group)
                    return tag;
            }
            return null;
        }
    }
}
