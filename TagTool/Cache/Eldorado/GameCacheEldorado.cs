using System;
using System.IO;
using TagTool.Cache.Resources;
using TagTool.IO;
using TagTool.Serialization;

namespace TagTool.Cache.Eldorado
{
    public class GameCacheEldorado : GameCacheEldoradoBase
    {
        public FileInfo TagsFile { get; set; }
        public FileInfo TagNamesFile { get; set; }
        public FileInfo StringIdCacheFile { get; set; }

        public override TagCache TagCache => TagCacheEldorado;
        public override StringTable StringTable => StringTableEldorado;
        public override ResourceCache ResourceCache => ResourceCaches;

        public override Stream OpenCacheRead() => TagsFile.OpenRead();

        public override Stream OpenCacheReadWrite() => TagsFile.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

        public override Stream OpenCacheWrite() => TagsFile.OpenWrite();

        private static Stream OpenFileStream(FileInfo file)
        {
            return file.Open(
                file.Exists ? FileMode.Open : FileMode.Create,
                file.Exists ? FileAccess.Read : FileAccess.ReadWrite,
                FileShare.Read);
        }

        public GameCacheEldorado(DirectoryInfo directory)
        {
            Directory = directory;
            TagsFile = new FileInfo(Path.Combine(directory.FullName, "tags.dat"));
            TagNamesFile = new FileInfo(Path.Combine(directory.FullName, "tag_list.csv"));
            StringIdCacheFile = new FileInfo(Path.Combine(directory.FullName, "string_ids.dat"));
            Platform = CachePlatform.Original;

            Endianness = EndianFormat.LittleEndian;
            
            using (var tagsStream = OpenFileStream(TagsFile))
            {
                FindVersion(new EndianReader(tagsStream));

                using (var stream = StringIdCacheFile.Open(FileMode.OpenOrCreate))
                    StringTableEldorado = new StringTableEldorado(Version, stream);

                var names = TagCacheEldorado.LoadTagNames(TagNamesFile.FullName);
                TagCacheEldorado = new TagCacheEldorado(Version, tagsStream, StringTableEldorado, names);
            }

            DisplayName = Version.ToString();
            Deserializer = new TagDeserializer(Version, Platform);
            Serializer = new TagSerializer(Version, Platform);
          
            ResourceCaches = new ResourceCachesEldorado(this);
        }

        public override void SaveTagNames(string path = null)
        {
            TagCacheEldorado.SaveTagNames(path ?? TagNamesFile.FullName);
        }

        public override void SaveStrings()
        {
            using (var stream = StringIdCacheFile.OpenWrite())
                StringTableEldorado.Save(stream);
        }

        private void FindVersion(EndianReader reader)
        {
            reader.SeekTo(0);
            // hackfix until we fix tag cache creation
            if (reader.BaseStream.Length == 0)
            {
                Version = CacheVersion.EldoradoED;
                return;
            }

            var header = CacheFileSectionHeader.ReadHeader(reader, CacheVersion.EldoradoED, Platform);
            var timestamp = LastModificationDate.GetTimestamp(header.CreationDate);

            Version = CacheVersionDetection.DetectFromTimestamp(timestamp);

            reader.SeekTo(0);
        }

        public override void SaveFonts(Stream stream)
        {
            var fontFilePath = $"{Directory.FullName}\\fonts\\font_package.bin";
            var fontFile = new FileInfo(fontFilePath);
            if (fontFile.Exists)
                fontFile.Delete();
            
            using (var fontFileStream = fontFile.Create())
            {
                stream.Position = 0;
                stream.CopyTo(fontFileStream);
            }
        }

        public override void AddModFile(string path, Stream file)
        {
            var modFile = new FileInfo(path);
            if (modFile.Exists)
            {
                Console.WriteLine("Overwriting Existing file: " + path);
                modFile.Delete();
            }

            using (var modFileStream = modFile.Create())
            {
                file.Position = 0;
                file.CopyTo(modFileStream);
            }
        }
    }
}
