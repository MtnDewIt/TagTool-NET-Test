using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Cache.HaloOnline;
using TagTool.Common;
using TagTool.Serialization;
using TagTool.Tags.Definitions;
using Newtonsoft.Json;
using TagTool.JSON;

namespace TagTool.Commands.GenerateCache
{
    partial class GenerateCacheCommand : Command
    {
        public object RebuildCache(string destCacheDirectory)
        {
            var destDirectory = new DirectoryInfo(destCacheDirectory);

            MoveFontPackage(destDirectory.FullName);

            var cacheContext = new GameCacheHaloOnline(destDirectory);

            UpdateStringTable(cacheContext.StringTable);

            SetCacheVersion(cacheContext, CacheVersion.HaloOnlineED);

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
        }

        public void MoveFontPackage(string path)
        {
            Directory.CreateDirectory($@"{path}\fonts");

            File.Copy($@"{SourceDirectoryInfo.FullName}\maps\fonts\font_package_upscaled.bin", $@"{path}\fonts\font_package.bin", true);
        }

        public void UpdateStringTable(StringTable stringTable) 
        {
            var jsonData = File.ReadAllText($@"{SourceDirectoryInfo.FullName}\data\cache_strings.json");
            var ms23Strings = JsonConvert.DeserializeObject<List<string>>(jsonData);

            var startingIndex = 0x10DE;

            for (int i = stringTable.Count; i < startingIndex; i++)
                stringTable.Add(null);

            foreach (var str in ms23Strings)
                stringTable.Add(str);
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
    }
}