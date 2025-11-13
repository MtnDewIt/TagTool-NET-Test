using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TagTool.Audio.Bank;
using TagTool.BlamFile;
using TagTool.Cache.HaloOnline;
using TagTool.Cache.Monolithic;
using TagTool.Cache.Resources;
using TagTool.Common;
using TagTool.IO;
using TagTool.Scripting;
using TagTool.Serialization;
using TagTool.Tags;

namespace TagTool.Cache
{
    public abstract class GameCache
    {
        public string DisplayName = "default";
        public CacheVersion Version;
        public CachePlatform Platform;
        public EndianFormat Endianness;
        public TagSerializer Serializer;
        public TagDeserializer Deserializer;
        public DirectoryInfo Directory;

        private IScriptDefinitions _scriptDefinitions;
        public IScriptDefinitions ScriptDefinitions => _scriptDefinitions ??= ScriptDefinitionsFactory.Create(Version, Platform);

        public List<LocaleTable> LocaleTables;
        public SoundBankCache SoundBanks;

        public abstract StringTable StringTable { get; }
        public abstract TagCache TagCache { get; }
        public abstract ResourceCache ResourceCache { get; }

        public abstract Stream OpenCacheRead();
        public abstract Stream OpenCacheReadWrite();
        public abstract Stream OpenCacheWrite();

        public abstract void Serialize(Stream stream, CachedTag instance, object definition);
        public abstract object Deserialize(Stream stream, CachedTag instance, Type type);

        public object Deserialize(Stream stream, CachedTag instance)
        {
            return Deserialize(stream, instance, TagCache.TagDefinitions.GetTagDefinitionType(instance.Group));
        }

        public T Deserialize<T>(Stream stream, CachedTag instance)
        {
            return (T)Deserialize(stream, instance, typeof(T));
        }

        public static GameCache Open(string filePath) => Open(new FileInfo(filePath));

        public static GameCache Open(FileInfo file)
        {
            if(file.Name.Equals("blob_index.dat"))
                return new GameCacheMonolithic(file);

            MapFile map = new MapFile();
            var estimatedVersion = CacheVersion.HaloOnlineED;

            using (var stream = file.OpenRead())
            using (var reader = new EndianReader(stream))
            {
                if (file.Name.Contains(".map"))
                {
                    map.Read(reader);
                    estimatedVersion = map.Version;
                }
                else if (file.Name.Equals("tags.dat"))
                    estimatedVersion = CacheVersion.HaloOnlineED;
                else
                    throw new Exception("Invalid file passed to GameCache constructor");
            }

            switch (estimatedVersion)
            {
                case CacheVersion.HaloXbox:
                case CacheVersion.HaloPC:
                case CacheVersion.HaloCustomEdition:
                    return new GameCacheGen1(map, file);

                case CacheVersion.Halo2Alpha:
                case CacheVersion.Halo2Beta:
                case CacheVersion.Halo2Xbox:
                case CacheVersion.Halo2PC:
                    return new GameCacheGen2(map, file);

                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Epsilon:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReachAlpha:
                case CacheVersion.HaloReachPreBeta:
                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReach:
                    return new GameCacheGen3(map, file);

                case CacheVersion.HaloOnlineED:
                case CacheVersion.HaloOnline106708:
                case CacheVersion.HaloOnline155080:
                case CacheVersion.HaloOnline235640:
                case CacheVersion.HaloOnline301003:
                case CacheVersion.HaloOnline327043:
                case CacheVersion.HaloOnline372731:
                case CacheVersion.HaloOnline416097:
                case CacheVersion.HaloOnline430475:
                case CacheVersion.HaloOnline454665:
                case CacheVersion.HaloOnline449175:
                case CacheVersion.HaloOnline498295:
                case CacheVersion.HaloOnline530605:
                case CacheVersion.HaloOnline532911:
                case CacheVersion.HaloOnline554482:
                case CacheVersion.HaloOnline571627:
                case CacheVersion.HaloOnline604673:
                case CacheVersion.HaloOnline700123:
                    {
                        var directory = file.Directory.FullName;
                        var tagsPath = Path.Combine(directory, "tags.dat");
                        var tagsFile = new FileInfo(tagsPath);

                        if (!tagsFile.Exists)
                            throw new Exception("Failed to find tags.dat");

                        return new GameCacheHaloOnline(tagsFile.Directory);
                    }

                case CacheVersion.Halo4E3:
                case CacheVersion.Halo4:
                case CacheVersion.H2AMP:
                    return new GameCacheGen4(map, file);
            }

            return null;
        }

        public abstract void SaveStrings();

        public virtual void LoadLocaleTables(Stream stream) { }
        public virtual void LoadSoundBanks() { }
    }
}
