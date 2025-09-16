using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache.Gen4;
using TagTool.Cache.Resources;
using TagTool.Commands.Common;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions.Gen4;

namespace TagTool.Cache
{
    public class GameCacheGen4 : GameCache
    {
        public MapFile BaseMapFile;
        public FileInfo CacheFile;
        public string NetworkKey;
        
        public StringTableGen4 StringTableGen4;
        public TagCacheGen4 TagCacheGen4;
        public ResourceCacheGen4 ResourceCacheGen4;

        public override TagCache TagCache => TagCacheGen4;
        public override StringTable StringTable => StringTableGen4;
        public override ResourceCache ResourceCache => ResourceCacheGen4;
        public override Stream OpenCacheRead() => CacheFile.OpenRead();
        public override Stream OpenCacheReadWrite() => CacheFile.Open(FileMode.Open, FileAccess.ReadWrite);
        public override Stream OpenCacheWrite() => CacheFile.Open(FileMode.Open, FileAccess.Write);

        /// <summary>
        /// Alignment of sections in the cache
        /// </summary>
        public readonly int SectionAlign = 0x1000;

        /// <summary>
        /// Alignment of resource pages in the resource section.
        /// </summary>
        public readonly int PageAlign = 0x800;

        public ulong Expand = 0x0;

        public uint TagAddressToOffset(uint address)
        {
            var sectionTable = BaseMapFile.Header.GetSectionTable();
            var expectedBaseAddress = BaseMapFile.Header.GetExpectedBaseAddress();

            var unpackedAddress = Platform == CachePlatform.MCC ?
                (((ulong)address << 2) + Expand) :
                (ulong)address;

            return (uint)(unpackedAddress - (expectedBaseAddress - sectionTable.GetSectionOffset(CacheFileSectionType.TagSection)));
        }

        public Dictionary<string, GameCacheGen4> SharedCacheFiles { get; } = new Dictionary<string, GameCacheGen4>();

        public GameCacheGen4(MapFile mapFile, FileInfo file)
        {
            Platform = mapFile.Platform;
            BaseMapFile = mapFile;
            Version = BaseMapFile.Version;
            CacheFile = file;
            Deserializer = new TagDeserializer(Version, Platform);
            Serializer = new TagSerializer(Version, Platform);
            Endianness = BaseMapFile.EndianFormat;

            var sectionTable = BaseMapFile.Header.GetSectionTable();

            DisplayName = mapFile.Header.GetName() + ".map";

            if (Platform == CachePlatform.MCC)
                Expand = (ulong)(Version <= CacheVersion.Halo4 ? 0x4FFF0000 : 0x7AC00000);

            Directory = file.Directory;

            using (var cacheStream = OpenCacheRead())
            using (var reader = new EndianReader(cacheStream, Endianness))
            {
                StringTableGen4 = new StringTableGen4(reader, BaseMapFile);
                TagCacheGen4 = new TagCacheGen4(reader, BaseMapFile, StringTableGen4, Expand);
                ResourceCacheGen4 = new ResourceCacheGen4(this);

                if (TagCacheGen4.Instances.Count > 0)
                {

                    if (sectionTable.Sections[(int)CacheFileSectionType.LocalizationSection].Size == 0)
                        LocaleTables = new List<LocaleTable>();
                    else
                    {
                        var globals = Deserialize<Globals>(cacheStream, TagCacheGen4.GlobalInstances["matg"]);
                        LocaleTables = LocalesTableGen4.CreateLocalesTable(reader, BaseMapFile, globals);
                    }
                }
            }

            // unused but kept for future uses
            if (Platform == CachePlatform.Original) 
            {
                switch (Version)
                {
                    case CacheVersion.Halo4:
                        NetworkKey = "SneakerNetReigns";
                        break;
                }
            }
        }

        #region Serialization

        public override T Deserialize<T>(Stream stream, CachedTag instance) =>
            Deserialize<T>(new Gen4SerializationContext(stream, this, (CachedTagGen4)instance));

        public override object Deserialize(Stream stream, CachedTag instance) =>
            Deserialize(new Gen4SerializationContext(stream, this, (CachedTagGen4)instance), TagCache.TagDefinitions.GetTagDefinitionType(instance.Group));

        public override void Serialize(Stream stream, CachedTag instance, object definition)
        {
            if (typeof(CachedTagGen4) == instance.GetType())
                Serialize(stream, (CachedTagGen4)instance, definition);
            else
                throw new Exception($"Try to serialize a {instance.GetType()} into a Gen 3 Game Cache");
        }

        //TODO: Implement serialization for Gen4
        public void Serialize(Stream stream, CachedTagGen4 instance, object definition)
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
        // public methods specific to Gen4
        //

        public T Deserialize<T>(Stream stream, CachedTagGen4 instance) =>
            Deserialize<T>(new Gen4SerializationContext(stream, this, instance));

        public object Deserialize(Stream stream, CachedTagGen4 instance) =>
            Deserialize(new Gen4SerializationContext(stream, this, instance), TagCache.TagDefinitions.GetTagDefinitionType(instance.Group));

        #endregion

        public override void SaveStrings()
        {
            throw new NotImplementedException();
        }

        public void ResizeSection(CacheFileSectionType type, int requestedAdditionalSpace)
        {
            var sectionTable = BaseMapFile.Header.GetSectionTable();
            var section = sectionTable.Sections[(int)type];

            var sectionFileOffset = sectionTable.GetSectionOffset(type);
            var sectionSize = section.Size;
            var shiftAmount = (requestedAdditionalSpace + SectionAlign - 1) & ~(SectionAlign - 1);
            var sectionNewSize = sectionSize + shiftAmount;


            //
            // Need to update all references to the section in the header and the section table. If it's a tag section, need to update the partitions. 
            // if it's a locale, need to update matg, if it's a resource, need to update play, if it's a string, need to update the string offsets
            // once all the updating is done, fix sections

            section.Size = sectionNewSize;

            for(int i = (int)type + 1; i < (int)CacheFileSectionType.Count; i++)
            {
                sectionTable.SectionAddressToOffsets[i] += shiftAmount;
            }
        }
    }
}