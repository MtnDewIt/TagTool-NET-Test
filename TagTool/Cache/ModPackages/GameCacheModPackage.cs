using LZ4;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Resources;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.ModPackages;
using System.Collections;

namespace TagTool.Cache
{
    public class GameCacheModPackage : GameCacheHaloOnlineBase
    {
        public FileInfo ModPackageFile;
        public ModPackage BaseModPackage;

        private int CurrentTagCacheIndex = 0;

        public GameCacheHaloOnlineBase BaseCacheReference;

        public GameCacheModPackage(GameCacheHaloOnlineBase baseCache, FileInfo file, bool largeResourceStream = false)
        {
            ModPackageFile = file;
            Directory = file.Directory;

            // load mod package
            var modPackage = new ModPackage(file, unmanagedResourceStream: largeResourceStream);
            Init(baseCache, modPackage, largeResourceStream);
        }

        public GameCacheModPackage(GameCacheHaloOnline baseCache, ModPackage modPackage)
        {
            Init(baseCache, modPackage);
        }

        private void Init(GameCacheHaloOnlineBase baseCache, ModPackage modPackage, bool largeResourceStream = false)
        {
            BaseCacheReference = baseCache;
            BaseModPackage = modPackage;
            Version = CacheVersion.HaloOnlineED;
            Platform = CachePlatform.Original;
            Endianness = EndianFormat.LittleEndian;
            Deserializer = new TagDeserializer(Version, Platform);
            Serializer = new TagSerializer(Version, Platform);
            ResourceCaches = new ResourceCachesModPackage(this, BaseModPackage);
            StringTableHaloOnline = BaseModPackage.StringTable;

            SetActiveTagCache(0);
        }

        public override object Deserialize(Stream stream, CachedTag instance)
        {
            var modStream = (ModPackageStream)stream;

            var definitionType = TagCache.TagDefinitions.GetTagDefinitionType(instance.Group);
            var modCachedTag = TagCache.GetTag(instance.Index) as CachedTagHaloOnline;
            // deserialization can happen in the base cache if the tag in the mod pack is only a reference
            if (modCachedTag.IsEmpty())
            {
                var baseInstance = BaseCacheReference.TagCache.GetTag(instance.Index);
                return BaseCacheReference.Deserialize(modStream.BaseStream, baseInstance);
            }
            else
            {
                var context = CreateTagSerializationContext(modStream, modCachedTag);
                return Deserializer.Deserialize(context, definitionType);
            }
        }

        public override T Deserialize<T>(Stream stream, CachedTag instance)
        {
            var modStream = (ModPackageStream)stream;

            var modCachedTag = TagCache.GetTag(instance.Index) as CachedTagHaloOnline;
            if (modCachedTag.IsEmpty())
            {
                var baseInstance = BaseCacheReference.TagCache.GetTag(instance.Index);
                return BaseCacheReference.Deserialize<T>(modStream.BaseStream, baseInstance);
            }
            else
                return Deserializer.Deserialize<T>(CreateTagSerializationContext(stream, modCachedTag));
        }

        public override void Serialize(Stream stream, CachedTag instance, object definition)
        {
            definition = ConvertResources(definition);
            Serializer.Serialize(CreateTagSerializationContext(stream, instance), definition);
        }

        private ISerializationContext CreateTagSerializationContext(Stream stream, CachedTag instance)
        {
            return new ModPackageTagSerializationContext(stream, this, (CachedTagHaloOnline)instance);
        }

        public override Stream OpenCacheRead() => new ModPackageStream(BaseModPackage.TagCachesStreams[CurrentTagCacheIndex], BaseCacheReference.OpenCacheRead());

        public Stream OpenCacheRead(Stream baseCacheStream) => new ModPackageStream(BaseModPackage.TagCachesStreams[CurrentTagCacheIndex], baseCacheStream);

        public override Stream OpenCacheReadWrite() => new ModPackageStream(BaseModPackage.TagCachesStreams[CurrentTagCacheIndex], BaseCacheReference.OpenCacheRead());

        public override Stream OpenCacheWrite() => new ModPackageStream(BaseModPackage.TagCachesStreams[CurrentTagCacheIndex], BaseCacheReference.OpenCacheRead());

        public override void SaveStrings() { }

        public override void SaveTagNames(string path = null)
        {
            Dictionary<int, string> tagNames = new Dictionary<int, string>();
            foreach(var tag in TagCache.NonNull())
            {
                tagNames[tag.Index] = tag.Name;
            }
            BaseModPackage.TagCacheNames[CurrentTagCacheIndex] = tagNames;
        }

        private int GetTagCacheCount() => BaseModPackage.GetTagCacheCount();

        public int GetCurrentTagCacheIndex() => CurrentTagCacheIndex;

        public void SetActiveTagCache(int index)
        {
            if (!BaseModPackage.IsValidTagCacheIndex(index))
                throw new ArgumentOutOfRangeException(nameof(index), index, "Invalid tag cache index");

            CurrentTagCacheIndex = index;
            TagCacheGenHO = new TagCacheHaloOnline(Version, BaseModPackage.TagCachesStreams[CurrentTagCacheIndex], StringTableHaloOnline, BaseModPackage.TagCacheNames[CurrentTagCacheIndex]);
            if (GetTagCacheCount() > 1)
                DisplayName = BaseModPackage.Metadata.Name + $" {BaseModPackage.CacheNames[CurrentTagCacheIndex]}" + ".pak";
            else
                DisplayName = BaseModPackage.Metadata.Name + ".pak";
        }

        public bool SaveModPackage(string filePath)
        {
            return SaveModPackage(new FileInfo(filePath));
        }

        public bool SaveModPackage(FileInfo file)
        {
            SaveStrings();
            SaveTagNames();
            BaseModPackage.DetermineMapFlags();

            // check for null tags
            foreach (var tag in TagCache.TagTable)
            {
                if(tag == null || tag.Name == null)
                {
                    if (tag != null)
                        new TagToolWarning($"Tag: 0x{tag.Index:X4} has no name, will crash ingame!");
                    else
                        new TagToolWarning($"null tag detected.");

                    return false;
                }
            }

            BaseModPackage.Save(file);
            return true;
        }

        public void SetCampaignFile(Stream stream)
        {
            BaseModPackage.CampaignFileStream = stream;
        }

        public void AddMapFile(Stream mapStream, int mapId)
        {
            BaseModPackage.AddMap(mapStream, mapId, CurrentTagCacheIndex);
        }

        public override void SaveFonts(Stream fontStream)
        {
            BaseModPackage.FontPackage = new MemoryStream();
            fontStream.Position = 0;
            fontStream.CopyTo(BaseModPackage.FontPackage);
        }

        public override void AddModFile(string path, Stream file)
        {
            if (!BaseModPackage.Files.ContainsKey(path))
            {
                file.Position = 0;
                BaseModPackage.Files.Add(path, file);
            }
            else
            {
                file.Position = 0;
                BaseModPackage.Files.Remove(path);
                BaseModPackage.Files.Add(path, file);
                Console.WriteLine("Overwriting Existing file: " + path);
            }
        }

        private object ConvertResources(object data)
        {
            switch (data)
            {
                case PageableResource resource:
                    return ConvertResource(resource);
                case TagStructure tagStruct:
                    foreach (var field in tagStruct.GetTagFieldEnumerable(Version, Platform))
                        field.SetValue(data, ConvertResources(field.GetValue(tagStruct)));
                    break;
                case IList collection:
                    for (var i = 0; i < collection.Count; i++)
                        collection[i] = ConvertResources(collection[i]);
                    break;
            }
            return data;
        }
           
        private PageableResource ConvertResource(PageableResource resource)
        {
            resource.GetLocation(out ResourceLocation location);
            if (location == ResourceLocation.None)
                return resource;
            if (location == ResourceLocation.Mods)
                return resource;

            // Console.WriteLine($"Converting resource {resource.Page.Index}");
            var rawResource = BaseCacheReference.ResourceCaches.ExtractRawResource(resource);
            resource.ChangeLocation(ResourceLocation.Mods);
            ResourceCaches.AddRawResource(resource, rawResource);
            return resource;
        }
    }
}

