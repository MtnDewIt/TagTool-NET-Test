using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Ai;
using TagTool.BlamFile;
using TagTool.Cache.Gen1;
using TagTool.Cache.Resources;
using TagTool.Common;
using TagTool.Extensions;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache
{
    public class GameCacheGen1 : GameCache
    {
        public MapFile BaseMapFile;
        public FileInfo CacheFile;

        public TagCacheGen1 TagCacheGen1;

        public override TagCache TagCache => TagCacheGen1;
        // Gen1 caches don't have stringids
        public override StringTable StringTable => null;
        public override ResourceCache ResourceCache => throw new NotImplementedException();

        public ResourceCacheGen1 BitmapResources = null;
        public ResourceCacheGen1 SoundResources = null;
        public ResourceCacheGen1 LocalizationResources = null;

        public GameCacheGen1(MapFile mapFile, FileInfo file)
        {
            BaseMapFile = mapFile;
            CacheFile = file;
            Version = BaseMapFile.Version;
            Platform = BaseMapFile.Platform;
            CacheFile = file;
            Deserializer = new TagDeserializer(Version, Platform);
            Serializer = new TagSerializer(Version, Platform);
            Endianness = BaseMapFile.EndianFormat;
            DisplayName = mapFile.Header.GetName() + ".map";
            Directory = file.Directory;

            using (var cacheStream = OpenCacheRead())
            using (var reader = new EndianReader(cacheStream, Endianness))
            {
                TagCacheGen1 = new TagCacheGen1(reader, mapFile);
            }

            var bitmapResourceCachePath = Path.Combine(Directory.FullName, "bitmaps.map");
            if (File.Exists(bitmapResourceCachePath))
                BitmapResources = new ResourceCacheGen1(this, bitmapResourceCachePath);

            var soundResourceCachePath = Path.Combine(Directory.FullName, "sounds.map");
            if (File.Exists(soundResourceCachePath))
                SoundResources = new ResourceCacheGen1(this, soundResourceCachePath);

        }

        #region Serialization

        public override object Deserialize(Stream stream, CachedTag instance, Type type) =>
            Deserialize(new Gen1SerializationContext(stream, this, (CachedTagGen1)instance), type);

        public override void Serialize(Stream stream, CachedTag instance, object definition)
        {
            if (typeof(CachedTagGen1) == instance.GetType())
                Serialize(stream, (CachedTagGen1)instance, definition);
            else
                throw new Exception($"Try to serialize a {instance.GetType()} into a Gen 3 Game Cache");
        }

        //TODO: Implement serialization for gen1
        public void Serialize(Stream stream, CachedTagGen1 instance, object definition)
        {
            throw new NotImplementedException();
        }

        //
        // private methods for internal use
        //

        private T Deserialize<T>(ISerializationContext context) =>
            Deserializer.Deserialize<T>(context);

        private object Deserialize(ISerializationContext context, Type type) =>
            Deserializer.Deserialize(context, type);

        //
        // public methods specific to gen3
        //

        public T Deserialize<T>(Stream stream, CachedTagGen1 instance) =>
            Deserialize<T>(new Gen1SerializationContext(stream, this, instance));

        public object Deserialize(Stream stream, CachedTagGen1 instance) =>
            Deserialize(new Gen1SerializationContext(stream, this, instance), TagCache.TagDefinitions.GetTagDefinitionType(instance.Group));

        #endregion


        public override Stream OpenCacheRead()
        {
            Stream resultStream = null;

            if (Version == CacheVersion.HaloXbox)
            {
                using (MemoryStream memoryStream = new MemoryStream()) 
                {
                    using (Stream stream = CacheFile.OpenRead()) 
                    {
                        using (EndianReader reader = new EndianReader(stream, Endianness)) 
                        {
                            int fileSize = (int)(BaseMapFile.Header.GetSize() - 0x800);

                            byte[] header = reader.ReadBytes(0x800);

                            memoryStream.Write(header, 0, 0x800);

                            reader.SeekTo(0x800 + 0x2);

                            int decompressedSize = fileSize;
                            byte[] decompressedBuffer = new byte[decompressedSize];

                            using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress, true))
                                decompressedSize = deflateStream.ReadAll(decompressedBuffer, 0, decompressedBuffer.Length);

                            memoryStream.Write(decompressedBuffer, 0, decompressedBuffer.Length);
                        }
                    }

                    resultStream = new MemoryStream(memoryStream.ToArray());
                }
            }
            else 
            {
                resultStream = CacheFile.OpenRead();
            }

            return resultStream;
        }

        public override Stream OpenCacheReadWrite()
        {
            throw new NotImplementedException();
        }

        public override Stream OpenCacheWrite()
        {
            throw new NotImplementedException();
        }

        public override void SaveStrings()
        {
            throw new NotImplementedException();
        }

    }

}
