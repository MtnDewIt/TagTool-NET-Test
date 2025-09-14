using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache.Eldorado;

namespace TagTool.Cache.ModPackages
{
    public class ModPackageBuilder
    {
        private readonly GameCacheEldoradoBase BaseCache;
        private List<string> TagCacheNames = [];
        private ModPackageMetadata Metadata;
        private ModifierFlags ModifierFlags;

        public ModPackageBuilder(GameCacheEldoradoBase baseCache)
        {
            BaseCache = baseCache;
        }

        public ModPackageBuilder SetMetadata(ModPackageMetadata metadata)
        {
            Metadata = metadata;
            return this;
        }

        public ModPackageBuilder SetModifierFlags(ModifierFlags flags)
        {
            ModifierFlags = flags;
            return this;
        }

        public ModPackageBuilder AddTagCache(string name)
        {
            TagCacheNames.Add(name);
            return this;
        }

        public ModPackageBuilder CreateTest(string modName)
        {
            return SetMetadata(new ModPackageMetadata()
            {
                Name = modName,
                Description = "test",
                Author = "test",
                VersionMajor = 0,
                VersionMinor = 1
            })
            .SetModifierFlags(ModifierFlags.mainmenu | ModifierFlags.campaign | ModifierFlags.multiplayer | ModifierFlags.firefight)
            .AddTagCache("default");
        }

        public ModPackage Build()
        {
            ModPackageCacheUtils.BuildInitialTagCache(
                BaseCache,
                out Dictionary<int, string> referenceTagNames,
                out Stream referenceStream);

            var modPackage = new ModPackage();
            modPackage.Header.ModifierFlags = ModifierFlags;
            modPackage.Metadata = Metadata ?? new ModPackageMetadata();
            modPackage.StringTable = new StringTableEldorado(BaseCache.Version);
            modPackage.StringTable.AddRange(BaseCache.StringTableEldorado);
            modPackage.TagCacheNames.Clear();
            modPackage.TagCachesStreams.Clear();
            modPackage.CacheNames.Clear();

            modPackage.Metadata.SetBuildDate(DateTime.UtcNow);

            //
            // Add the tag caches
            //

            for (int i = 0; i < TagCacheNames.Count; i++)
            {
                referenceStream.Position = 0;

                var newTagCacheStream = referenceStream;
                if (i > 0)
                {
                    newTagCacheStream = new MemoryStream();
                    referenceStream.CopyTo(newTagCacheStream);
                    newTagCacheStream.Position = 0;
                }

                modPackage.AddTagCache(TagCacheNames[i], referenceTagNames.ToDictionary(), newTagCacheStream);
            }

            return modPackage;
        }
    }
}
