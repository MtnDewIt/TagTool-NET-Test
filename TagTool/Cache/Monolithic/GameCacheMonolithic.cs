using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache.Resources;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags.Definitions;

namespace TagTool.Cache.Monolithic
{
    public class GameCacheMonolithic : GameCache
    {
        public MonolithicTagFileBackend Backend;

        public TagCacheMonolithic TagCacheMono;
        public StringTableMonolithic StringTableMono;
        public ResourceCacheMonolithic ResourceCacheMono;
        public Dictionary<Tag, TagLayout> TagLayouts;

        public GameCacheMonolithic(FileInfo file, CacheVersion version = CacheVersion.Unknown, CachePlatform platform = CachePlatform.All)
        {
            if (version == CacheVersion.Unknown)
                DetectCacheVersion(file, out version, out platform);

            DisplayName = file.Name;
            Version = version;
            Platform = platform;
            Endianness = CacheVersionDetection.IsLittleEndian(version, Platform) ? EndianFormat.LittleEndian : EndianFormat.BigEndian;
            Backend = new MonolithicTagFileBackend(file, Endianness, MonolithicTagFileBackend.LoadFlags.TagIndex);
            Deserializer = new TagDeserializer(version, platform);
            TagCacheMono = new TagCacheMonolithic(Backend, version, platform);
            StringTableMono = new StringTableMonolithic();
            ResourceCacheMono = new ResourceCacheMonolithic(this);
            TagLayouts = new Dictionary<Tag, TagLayout>();
        }

        private void DetectCacheVersion(FileInfo file, out CacheVersion version, out CachePlatform platform)
        {
            // try to detect the cache version from the session id

            Guid guid;
            using (var reader = new EndianReader(file.OpenRead()))
                guid = new Guid(reader.ReadBytes(16));

            switch (guid.ToString())
            {
                // 11883.10.10.25.1227.dlc_1_ship__tag_test
                case "0237d057-1e3c-4390-9cfc-6108a911de01":
                case "f1acaa38-9d6c-40d4-ad9d-8cc985606b27":
                    version = CacheVersion.HaloReach11883;
                    platform = CachePlatform.Original;
                    break;
                case "2ccbe86e-fec7-478e-b346-a413be9f0d02":
                    version = CacheVersion.Halo4220811;
                    platform = CachePlatform.Original;
                    break;
                case "04c0ba10-efd0-4bd0-8277-aaaec892cd6d":
                    version = CacheVersion.Halo4280911;
                    platform = CachePlatform.Original;
                    break;
                case "0e1faa8c-7f66-40aa-9027-276e168754b4":
                    version = CacheVersion.Halo4140113;
                    platform = CachePlatform.Original;
                    break;
                case "a224685c-4d51-4031-9312-7857ae20244f":
                    version = CacheVersion.Halo4131113;
                    platform = CachePlatform.Original;
                    break;
                default:
                    throw new Exception("Unable to detect monolothic cache version");
            }
        }

        public override StringTable StringTable => StringTableMono;

        public override TagCache TagCache => TagCacheMono;

        public override ResourceCache ResourceCache => ResourceCacheMono;

        public override object Deserialize(Stream stream, CachedTag instance)
        {
            var definitionType = TagCache.TagDefinitions.GetTagDefinitionType(instance.Group);
            return DeserializeInternal(stream, instance, definitionType);
        }

        public override T Deserialize<T>(Stream stream, CachedTag instance)
        {
            return (T)DeserializeInternal(stream, instance, typeof(T));
        }

        private object DeserializeInternal(Stream stream, CachedTag instance, Type definitionType)
        {
            var data = Deserializer.Deserialize(new TagSerializationContextMonolithic(stream, this, (CachedTagMonolithic)instance), definitionType);

            // fixups for convenience
            switch(data)
            {
                case Bitmap bitmap when bitmap.XenonImages != null && bitmap.XenonImages.Count > 0:
                    bitmap.Images = bitmap.XenonImages;
                    break;
                case Sound sound when sound.ResourceReachTagsBuild != null:
                    sound.Resource = sound.ResourceReachTagsBuild;
                    break;
            }

            return data;
        }

        public override Stream OpenCacheRead()
        {
            return new MemoryStream();
        }

        public override Stream OpenCacheReadWrite()
            => throw new NotImplementedException();

        public override Stream OpenCacheWrite()
            => throw new NotImplementedException();

        public override void SaveStrings()
            => throw new NotImplementedException();

        public override void Serialize(Stream stream, CachedTag instance, object definition)
            => throw new NotImplementedException();

        public void LoadTagLayouts()
        {
            Backend.LoadAdditional(MonolithicTagFileBackend.LoadFlags.TagLayouts);
            TagLayouts = Backend.TagLayouts;
        }
    }
}
