using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Commands.Tags;
using TagTool.JSON;
using System.Linq;
using TagTool.Serialization;
using TagTool.Tags;
using System.Collections.Generic;
using System;
using TagTool.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.GenerateDonkeyCache
{
    partial class GenerateDonkeyCacheCommand : Command
    {
        public object RebuildCache(string destCacheDirectory)
        {
            var destDirectory = new DirectoryInfo(destCacheDirectory);

            MoveFontPackage(destDirectory.FullName);

            var cacheContext = new GameCacheHaloOnline(destDirectory);

            SetCacheVersion(cacheContext, CacheVersion.HaloOnline106708);

            var resourceStreams = new Dictionary<ResourceLocation, Stream>();

            foreach (var value in Enum.GetValues(typeof(ResourceLocation)))
            {
                var location = (ResourceLocation)value;

                if (location == ResourceLocation.None || location == ResourceLocation.RenderModels || location == ResourceLocation.Lightmaps || location == ResourceLocation.Mods)
                    continue;

                resourceStreams[location] = cacheContext.ResourceCaches.OpenCacheReadWrite(location);
            }

            using (var destStream = cacheContext.OpenCacheReadWrite())
            {
                var cfgtTag = cacheContext.TagCache.AllocateTag<CacheFileGlobalTags>($@"global_tags");
                var cfgt = new CacheFileGlobalTags();
                cacheContext.Serialize(destStream, cfgtTag, cfgt);

                var matgTag = cacheContext.TagCache.AllocateTag<Globals>($@"globals\globals");
                var matg = new Globals();
                cacheContext.Serialize(destStream, matgTag, matg);

                cfgt = cacheContext.Deserialize<CacheFileGlobalTags>(destStream, cfgtTag);
                cfgt.GlobalTags = new List<TagReferenceBlock>()
                {
                    new TagReferenceBlock()
                    {
                        Instance = cacheContext.TagCache.GetTag<Globals>($@"globals\globals"),
                    },
                };
                cacheContext.Serialize(destStream, cfgtTag, cfgt);
            }

            cacheContext.SaveTagNames();
            cacheContext.SaveStrings();

            foreach (var entry in resourceStreams)
                entry.Value.Close();

            return true;
        }

        public void RetargetCache(string cache)
        {
            var newFileInfo = new FileInfo(cache + "\\tags.dat");
            Cache = GameCache.Open(newFileInfo);
            CacheContext = Cache as GameCacheHaloOnline;
            ContextStack.Push(TagCacheContextFactory.Create(ContextStack, Cache));
        }

        public void MoveFontPackage(string path)
        {
            Directory.CreateDirectory($@"{path}\fonts");

            File.Copy($@"{SourceDirectoryInfo.FullName}\maps\fonts\font_package.bin", $@"{path}\fonts\font_package.bin", true);
        }

        public void SetCacheVersion(GameCacheHaloOnline cache, CacheVersion version)
        {
            cache.Version = version;
            cache.TagCacheGenHO.Version = version;
            cache.TagCacheGenHO.Header.CreationTime = CacheVersionDetection.GetTimestamp(version);
            cache.StringTableHaloOnline.Version = version;
            cache.Serializer = new TagSerializer(version, CachePlatform.Original);
            cache.Deserializer = new TagDeserializer(version, CachePlatform.Original);
            cache.ResourceCaches = new ResourceCachesHaloOnline(cache);
        }

        public CachedTag GetCachedTag<T>(string tagName) where T : TagStructure
        {
            var tagAttribute = TagStructure.GetTagStructureAttribute(typeof(T), CacheContext.Version, CacheContext.Platform);
            var typeName = tagAttribute.Tag;

            if (CacheContext.TagCache.TryGetTag<T>(tagName, out var result))
            {
                return result;
            }
            else
            {
                new TagToolWarning($@"Could not find tag: '{tagName}.{typeName}'. Assinging null tag instead");
                return null;
            }
        }
    }
}
