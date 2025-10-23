using System;
using System.Collections.Generic;
using System.IO;
using TagTool.BlamFile;
using TagTool.Cache.CacheFile;
using TagTool.Cache.Gen4;
using TagTool.Cache.Resources;
using TagTool.Common.Logging;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags;
using TagTool.Tags.Definitions.Gen4;
using static TagTool.Tags.Definitions.Globals;

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

        public CacheFileHeaderGen4 HeaderGen4 => (CacheFileHeaderGen4)BaseMapFile.Header;
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
            var headerGen4 = (CacheFileHeaderGen4)BaseMapFile.Header;

            var baseAddress = Platform == CachePlatform.MCC ?
                headerGen4.VirtualBaseAddress64 :
                (ulong)headerGen4.VirtualBaseAddress32;

            var unpackedAddress = Platform == CachePlatform.MCC ?
                (((ulong)address << 2) + Expand) :
                (ulong)address;

            return (uint)(unpackedAddress - (baseAddress - (ulong)headerGen4.SectionTable.GetSectionOffset(CacheFileSectionType.TagSection)));
        }

        public Dictionary<string, GameCacheGen4> SharedCacheFiles { get; } = new Dictionary<string, GameCacheGen4>();

        public GameCacheGen4(MapFile mapFile, FileInfo file)
        {
            Platform = mapFile.CachePlatform;
            BaseMapFile = mapFile;
            Version = BaseMapFile.Version;
            CacheFile = file;
            Deserializer = new TagDeserializer(Version, Platform);
            Serializer = new TagSerializer(Version, Platform);
            Endianness = BaseMapFile.EndianFormat;

            var headerGen4 = (CacheFileHeaderGen4)BaseMapFile.Header;

            DisplayName = mapFile.Header.GetName() + ".map";

            if (Platform == CachePlatform.MCC)
                Expand = (ulong)(Version <= CacheVersion.Halo4 ? 0x4FFF0000 : 0x7AC00000);

            Directory = file.Directory;

            using(var cacheStream = OpenCacheRead())
            using(var reader = new EndianReader(cacheStream, Endianness))
            {
                StringTableGen4 = new StringTableGen4(reader, BaseMapFile);
                TagCacheGen4 = new TagCacheGen4(reader, BaseMapFile, StringTableGen4, Expand);
                ResourceCacheGen4 = new ResourceCacheGen4(this);
            }

            // unused but kept for future uses
            switch (Version)
            {
                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                    NetworkKey = "";
                    break;
                case CacheVersion.HaloReach:
                case CacheVersion.Halo4:
                    NetworkKey = "SneakerNetReigns";
                    break;
            }
        }

        #region Serialization

        public override object Deserialize(Stream stream, CachedTag instance, Type type) =>
            Deserialize(new Gen4SerializationContext(stream, this, (CachedTagGen4)instance), type);

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
            var sectionTable = ((CacheFileHeaderGen4)BaseMapFile.Header).SectionTable;
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

        public override void LoadLocaleTables(Stream stream)
        {
            if (LocaleTables != null)
                return;

            if (TagCacheGen4.Count == 0 || HeaderGen4.SectionTable.Sections[(int)CacheFileSectionType.LocalizationSection].Size == 0)
                return;

            try
            {
                var matg = Deserialize<Globals>(stream, TagCacheGen4.GlobalInstances["matg"]);

                LocaleTables = CacheFileLocaleTables.Load(
                    new EndianReader(stream, Endianness),
                    HeaderGen4.SectionTable,
                    localesKey: Platform == CachePlatform.MCC ? "" : "BungieHaloReach!",
                    languagePacks: Platform == CachePlatform.MCC ? matg.LanguagePacksMCC : matg.LanguagePacks);
            }
            catch
            {
                Log.Warning("Failed to build locales table (Invalid Globals definition?)");
            }
        }
    }
}