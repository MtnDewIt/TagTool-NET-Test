using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Audio.Bank;
using TagTool.BlamFile;
using TagTool.Cache.CacheFile;
using TagTool.Cache.Gen3;
using TagTool.Cache.Resources;
using TagTool.Common.Logging;
using TagTool.IO;
using TagTool.Serialization;
using TagTool.Tags.Definitions;
using static TagTool.Tags.Definitions.Globals;

namespace TagTool.Cache
{
    public class GameCacheGen3 : GameCache
    {
        public MapFile BaseMapFile;
        public FileInfo CacheFile;
        public string NetworkKey;
       
        public StringTableGen3 StringTableGen3;
        public TagCacheGen3 TagCacheGen3;
        public ResourceCacheGen3 ResourceCacheGen3;

        public override TagCache TagCache => TagCacheGen3;
        public override StringTable StringTable => StringTableGen3;
        public override ResourceCache ResourceCache => ResourceCacheGen3;

        /// <summary>
        /// Alignment of sections in the cache
        /// </summary>
        public readonly int SectionAlign = 0x1000;

        /// <summary>
        /// Alignment of resource pages in the resource section.
        /// </summary>
        public readonly int PageAlign = 0x800;

        public uint TagAddressToOffset(uint address)
        {
            var sectionTable = BaseMapFile.Header.GetSectionTable();
            var tagsOffset = BaseMapFile.Header.GetTagsOffset();
            var expectedBaseAddress = BaseMapFile.Header.GetExpectedBaseAddress();

            if (Version == CacheVersion.Halo3Beta)
                return (uint)(address - (expectedBaseAddress - tagsOffset));

            ulong tagDataSectionOffset = sectionTable.GetSectionOffset(CacheFileSectionType.TagSection);

            if(Platform == CachePlatform.MCC)
            {
                ulong bucketOffset = 0;
                if (Version >= CacheVersion.HaloReach)
                    bucketOffset = address >> 28 << 28;

                return (uint)((address << 2) - expectedBaseAddress + tagDataSectionOffset + bucketOffset);
            }
            else
            {
                return (uint)(address - expectedBaseAddress + tagDataSectionOffset);
            }
        }

        public Dictionary<string, GameCacheGen3> SharedCacheFiles { get; } = new Dictionary<string, GameCacheGen3>();

        public GameCacheGen3(MapFile mapFile, FileInfo file)
        {
            BaseMapFile = mapFile;
            Version = BaseMapFile.Version;
            CacheFile = file;
            Platform = BaseMapFile.Platform;

            Deserializer = new TagDeserializer(Version, Platform);
            Serializer = new TagSerializer(Version, Platform);
            Endianness = BaseMapFile.EndianFormat;

            var sectionTable = BaseMapFile.Header.GetSectionTable();

            DisplayName = mapFile.Header.GetName() + ".map";

            Directory = file.Directory;

            using(var cacheStream = OpenCacheRead())
            using(var reader = new EndianReader(cacheStream, Endianness))
            {
                StringTableGen3 = new StringTableGen3(reader, BaseMapFile);
                TagCacheGen3 = new TagCacheGen3(reader, BaseMapFile, StringTableGen3, Platform);
                ResourceCacheGen3 = new ResourceCacheGen3(this);
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
                    NetworkKey = "SneakerNetReigns";
                    break;
            }

            if (Version != CacheVersion.Halo3XboxOne && Platform == CachePlatform.MCC)
            {
                
            }
        }

        #region Serialization

        public override T Deserialize<T>(Stream stream, CachedTag instance) =>
            Deserialize<T>(new Gen3SerializationContext(stream, this, (CachedTagGen3)instance));

        public override object Deserialize(Stream stream, CachedTag instance) =>
            Deserialize(new Gen3SerializationContext(stream, this, (CachedTagGen3)instance), TagCache.TagDefinitions.GetTagDefinitionType(instance.Group));

        public override void Serialize(Stream stream, CachedTag instance, object definition)
        {
            if (typeof(CachedTagGen3) == instance.GetType())
                Serialize(stream, (CachedTagGen3)instance, definition);
            else
                throw new Exception($"Try to serialize a {instance.GetType()} into a Gen 3 Game Cache");
        }

        //TODO: Implement serialization for gen3
        public void Serialize(Stream stream, CachedTagGen3 instance, object definition)
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

        public T Deserialize<T>(Stream stream, CachedTagGen3 instance) =>
            Deserialize<T>(new Gen3SerializationContext(stream, this, instance));

        public object Deserialize(Stream stream, CachedTagGen3 instance) =>
            Deserialize(new Gen3SerializationContext(stream, this, instance), TagCache.TagDefinitions.GetTagDefinitionType(instance.Group));

        #endregion

        public override Stream OpenCacheRead() 
        {
            Stream resultStream = null;

            if (Version == CacheVersion.Halo3XboxOne && IsCompressed(BaseMapFile.Header))
            {
                var sectionTable = BaseMapFile.Header.GetSectionTable();
                var offsets = BaseMapFile.Header.GetCompressedSectionOffset();
                var sizes = BaseMapFile.Header.GetCompressedSectionSize();
                var codecs = BaseMapFile.Header.GetCompressedSectionCodec();

                using (MemoryStream memoryStream = new MemoryStream()) 
                {
                    using (Stream stream = CacheFile.OpenRead()) 
                    {
                        using (EndianReader reader = new EndianReader(stream, Endianness)) 
                        {
                            byte[] header = reader.ReadBytes(0x4000);

                            memoryStream.Write(header, 0, 0x4000);

                            int[] order = new int[4] { 0, 1, 3, 2 };

                            for (int i = 0; i < 4; i++) 
                            {
                                int index = order[i];

                                var offset = offsets[index].Value;
                                var compressedSize = sizes[index].Value;
                                var codec = codecs[index].Codec;
                                var decompressedSize = sectionTable.OriginalSectionBounds[index].Size;
                                var address = sectionTable.OriginalSectionBounds[index].Offset;
                                var mask = sectionTable.SectionOffsets[index];

                                if (codec == CompressedSectionCodec.None)
                                {
                                    reader.SeekTo(offset);

                                    byte[] buffer = new byte[decompressedSize];

                                    int bufferSize = reader.Read(buffer, 0, decompressedSize);

                                    memoryStream.Write(buffer, 0, bufferSize);
                                }
                                else if (codec == CompressedSectionCodec.LZMALib)
                                {
                                    // TODO: Implement LZMA decompression
                                }
                                else 
                                {
                                    throw new ArgumentException($"Unsupported Compressed Secion Codec {codec}");
                                }
                            }
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
            return CacheFile.Open(FileMode.Open, FileAccess.ReadWrite);
        }

        public override Stream OpenCacheWrite() 
        {
            return CacheFile.Open(FileMode.Open, FileAccess.Write);
        }

        public override void SaveStrings()
        {
            throw new NotImplementedException();
        }

        public static bool IsCompressed(CacheFileHeader header) 
        {
            var compressedSizes = header.GetCompressedSectionSize();

            foreach (var size in compressedSizes) 
            {
                if (size.Value > 0)
                    return true;
            }

            return false;
        }

        public void ResizeSection(CacheFileSectionType type, int requestedAdditionalSpace)
        {
            var sectionTable = BaseMapFile.Header.GetSectionTable();
            var section = sectionTable.OriginalSectionBounds[(int)type];

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
                sectionTable.SectionOffsets[i] += shiftAmount;
            }
        }

        public override void LoadLocaleTables(Stream stream)
        {
            var sectionTable = BaseMapFile.Header.GetSectionTable();

            if (LocaleTables != null)
                return;

            if (TagCacheGen3.Instances.Count == 0 || sectionTable.OriginalSectionBounds[(int)CacheFileSectionType.LocalizationSection].Size == 0)
                return;

            //Allow caches to open even if Globals cannot deserialize
            try
            {
                var matg = Deserialize<Globals>(stream, TagCacheGen3.GlobalInstances["matg"]);

                string localesKey = "";
                switch (Version)
                {
                    case CacheVersion.HaloReach when Platform == CachePlatform.Original:
                        localesKey = "BungieHaloReach!";
                        break;
                }

                LanguagePack[] languagePacks = Platform == CachePlatform.MCC ? matg.LanguagePacksMCC : matg.LanguagePacks;

                LocaleTables = CacheFileLocaleTables.Load(new EndianReader(stream, Endianness), sectionTable, localesKey, languagePacks);
            }
            catch
            {
                Log.Warning("Failed to build locales table (Invalid Globals definition?)");
            }
        }

        public override void LoadSoundBanks()
        {
            if (SoundBanks != null || Platform != CachePlatform.MCC)
                return;

            var game = Version.ToString().ToLower().Replace("retail", "");

            var directories =  new List<DirectoryInfo>();
            //check if this is a mod
            if (CacheFile.Directory.FullName.Contains("steamapps\\workshop\\content"))
            {
                string root = CacheFile.Directory.FullName.Split(new string[] { "workshop" }, StringSplitOptions.None)[0];

                DirectoryInfo mainDirectory = new DirectoryInfo(Path.Combine(root, "common\\Halo The Master Chief Collection", game, "fmod\\pc"));
                if (mainDirectory.Exists)
                    directories.Add(mainDirectory);
                else
                    Log.Warning("Failed to find main mcc sound banks!");
            }

            DirectoryInfo localDirectory = new DirectoryInfo(Path.Combine(CacheFile.Directory.FullName, "..", "fmod\\pc"));
            if (localDirectory.Exists)
                directories.Add(localDirectory);
            else
            {
                localDirectory = new DirectoryInfo(Path.Combine(CacheFile.Directory.FullName, "..", game, "fmod\\pc"));
                if (localDirectory.Exists)
                    directories.Add(localDirectory);
            }

            if (directories.Count == 0)
                Log.Warning("Failed to load any FMOD sound banks!");

            SoundBanks = new SoundBankCache(directories);
        }
    }
}