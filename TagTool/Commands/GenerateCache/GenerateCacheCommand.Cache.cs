using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Cache.Gen3;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.Resources;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Commands.Tags;
using TagTool.Serialization;
using TagTool.Tags;
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

            EmptyDirectory(destDirectory);

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

                var matgTag = cacheContext.TagCache.AllocateTag<Globals>($@"globals\globals");
                var matg = new Globals();
                cacheContext.Serialize(destStream, matgTag, matg);

                var modgTag = cacheContext.TagCache.AllocateTag<ModGlobalsDefinition>($@"multiplayer\mod_globals");
                var modg = new ModGlobalsDefinition();
                cacheContext.Serialize(destStream, modgTag, modg);

                var forgTag = cacheContext.TagCache.AllocateTag<ForgeGlobalsDefinition>($@"multiplayer\forge_globals");
                var forg = new ForgeGlobalsDefinition();
                cacheContext.Serialize(destStream, forgTag, forg);

                var mlstTag = cacheContext.TagCache.AllocateTag<MapList>($@"ui\eldewrito\maps");
                var mlst = new MapList();
                cacheContext.Serialize(destStream, mlstTag, mlst);

                cfgt = cacheContext.Deserialize<CacheFileGlobalTags>(destStream, cfgtTag);
                cfgt.GlobalTags = new List<TagReferenceBlock>()
                {
                    new TagReferenceBlock()
                    {
                        Instance = cacheContext.TagCache.GetTag<Globals>($@"globals\globals"),
                    },
                    new TagReferenceBlock()
                    {
                        Instance = cacheContext.TagCache.GetTag<ModGlobalsDefinition>($@"multiplayer\mod_globals"),
                    },
                    new TagReferenceBlock()
                    {
                        Instance = cacheContext.TagCache.GetTag<ForgeGlobalsDefinition>($@"multiplayer\forge_globals"),
                    },
                    new TagReferenceBlock()
                    {
                        Instance = cacheContext.TagCache.GetTag<MapList>($@"ui\eldewrito\maps"),
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

            if (!File.Exists($@"{path}\fonts\font_package.bin"))
            {
                File.Copy($@"{JSONFileTree.JSONGenerateCachePath}\maps\fonts\font_package_upscaled.bin", $@"{path}\fonts\font_package.bin");
            }
            else
            {
                new TagToolWarning($@"Font Package Detected in Specified Directory! Replacing Anyway.");
                File.Copy($@"{JSONFileTree.JSONGenerateCachePath}\maps\fonts\font_package_upscaled.bin", $@"{path}\fonts\font_package.bin", true);
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

        public void UpdateStringTable(StringTable stringTable) 
        {
            var jsonData = File.ReadAllText($@"{JSONFileTree.JSONStringTablePath}\ms23_strings.json");
            var ms23Strings = JsonConvert.DeserializeObject<List<string>>(jsonData);

            var startingIndex = 0x10DE;

            for (int i = stringTable.Count; i < startingIndex; i++) 
            {
                stringTable.Add(null);
            }

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