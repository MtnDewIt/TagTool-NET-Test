﻿using System;
using System.IO;
using System.IO.Compression;
using TagTool.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Resources;
using TagTool.BlamFile;
using TagTool.Cache.Resources;
using System.Collections.Generic;
using TagTool.Extensions;

namespace TagTool.Cache.Gen1
{
    public class ResourceCacheGen1
    {
        public Gen1ResourceCacheHeader Header;
        public List<Gen1ResourceTableEntry> ResourceTable;
        public GameCacheGen1 Cache;
        private Stream CacheStream = null;
        private string CachePath;

        public enum Gen1ResourceCacheType : uint
        {
            Bitmaps = 1,
            Sounds = 2,
            Localization = 3
        }


        [TagStructure(MaxVersion = CacheVersion.HaloCustomEdition, Size = 0x10)]
        public class Gen1ResourceCacheHeader : TagStructure
        {
            public Gen1ResourceCacheType ResourceType;
            public uint ResourceNamesOffset;
            public uint ResourceTableOffset;
            public uint ResourceCount;
        }

        [TagStructure(MaxVersion = CacheVersion.HaloCustomEdition, Size = 0xC)]
        public class Gen1ResourceTableEntry : TagStructure
        {
            public uint NameOffset;
            public uint Size;
            public uint DataOffset;

            [TagField(Flags = TagFieldFlags.Runtime)]
            public string ResourceName = "";
        }


        public ResourceCacheGen1(GameCacheGen1 cache, string path)
        {
            Cache = cache;
            CachePath = path;

            using (var stream = File.OpenRead(path))
            using(var reader = new EndianReader(stream, cache.Endianness))
            {
                var dataContext = new DataSerializationContext(reader);
                var deserializer = new TagDeserializer(cache.Version, cache.Platform);
                stream.Position = 0;

                Header = deserializer.Deserialize<Gen1ResourceCacheHeader>(dataContext);

                stream.Position = Header.ResourceTableOffset;

                ResourceTable = new List<Gen1ResourceTableEntry>();

                for (int i = 0; i < Header.ResourceCount; i++)
                {
                    var entry = deserializer.Deserialize<Gen1ResourceTableEntry>(dataContext);

                    var currentStreamPosition = stream.Position;

                    stream.Position = Header.ResourceNamesOffset + entry.NameOffset;
                    entry.ResourceName = reader.ReadNullTerminatedString();

                    stream.Position = currentStreamPosition;

                    ResourceTable.Add(entry);
                }
            }
        }

        public byte[] GetResourceData(int size, int offset)
        {
            if (size < 0 || offset < 0)
                return null;

            if(CacheStream == null)
                CacheStream = File.OpenRead(CachePath);

            if (offset + size > CacheStream.Length)
                return null;

            byte[] result = new byte[size];

            CacheStream.Position = offset;

            var readSize = CacheStream.ReadAll(result, 0, size);

            if (readSize != size)
                return null;

            return result;
        }
        ~ResourceCacheGen1()
        {
            if(CacheStream != null)
                CacheStream.Dispose();
        }


    }
}