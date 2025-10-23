using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.Resources;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Serialization
{
    class ModPackageTagSerializationContext : HaloOnlineSerializationContext
    {
        private TagCacheHaloOnline ModPackageTagCache;

        public ModPackageTagSerializationContext(Stream stream, GameCacheHaloOnlineBase context, CachedTagHaloOnline tag) : base(stream, context, tag)
        {
            ModPackageTagCache = context.TagCacheGenHO;
        }

        public override CachedTag GetTagByIndex(int index)
        {
            if (index < 0 || index >= ModPackageTagCache.Tags.Count)
                return null;

            return ModPackageTagCache.Tags[index];
        }

        public override CachedTag GetTagByName(TagGroup group, string name)
        {
            foreach(var tag in Context.TagCacheGenHO.Tags)
            {
                if (tag.Name == name && group == tag.Group)
                    return tag;
            }
            return null;
        }

        protected override PageableResource PreSerializeTagResource(PageableResource resource)
        {
            var modCache = (GameCacheModPackage)Context;

            resource.GetLocation(out ResourceLocation location);

            if (location == ResourceLocation.None || location == ResourceLocation.Mods)
                return resource;

            // Copy the base cache resource to the mod package
            var rawResource = modCache.BaseCacheReference.ResourceCaches.ExtractRawResource(resource);
            resource.ChangeLocation(ResourceLocation.Mods);
            modCache.ResourceCaches.AddRawResource(resource, rawResource);

            return resource;
        }
    }
}
