using System.IO;
using TagTool.Cache.HaloOnline;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.Commands.Common;
using TagTool.Commands.Tags;
using TagTool.Serialization;
using TagTool.Tags;
using System.Linq;

namespace TagTool.MtnDewIt.Commands.GenerateDonkeyCache
{
    partial class GenerateDonkeyCacheCommand : Command
    {


        // Retargets the cache (Its bascially the equivalent of the restart command)
        public void RetargetCache(string cache)
        {
            var newFileInfo = new FileInfo(cache + "\\tags.dat");
            Cache = GameCache.Open(newFileInfo);
            CacheContext = Cache as GameCacheHaloOnline;
            ContextStack.Push(TagCacheContextFactory.Create(ContextStack, Cache));
        }

        // Copies over required files (map files required for updating map files)
        public void MoveFontPackage(string path)
        {
            Directory.CreateDirectory($@"{path}\fonts");

            if (!File.Exists($@"{path}\fonts\font_package.bin"))
            {
                File.Copy($@"{Program.TagToolDirectory}\Tools\BaseCache\Fonts\Upscaled\font_package.bin", $@"{path}\fonts\font_package.bin");
            }
            else
            {
                new TagToolWarning($@"Font Package Detected in Specified Directory! Replacing Anyway.");
                File.Copy($@"{Program.TagToolDirectory}\Tools\BaseCache\Fonts\Upscaled\font_package.bin", $@"{path}\fonts\font_package.bin", true);
            }
        }

        public void EmptyDirectory(DirectoryInfo directoryInfo)
        {
            string[] remove = { "map", "dat", "csv" };

            if (directoryInfo.GetFiles().Any(x => x.FullName.EndsWith(".map") || x.FullName.EndsWith(".dat") || x.FullName.EndsWith(".csv")))
            {
                new TagToolWarning($@"Cache Detected in Specified Directory! Replacing Anyway.");

                foreach (string fileType in remove)
                {
                    FileInfo[] files = directoryInfo.GetFiles("*." + fileType);

                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                }
            }
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