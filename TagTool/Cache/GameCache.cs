﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TagTool.BlamFile;
using TagTool.Cache.Eldorado;
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

        // TODO: cleanup. the reason I'm doing this is because GameCache doesn't have a constructor
        // where the version and platform is available, and I don't want to have to call 
        // ScriptDefinitionsFactory.Create in every GameCache implementation
        private IScriptDefinitions _scriptDefinitions;
        public IScriptDefinitions ScriptDefinitions => _scriptDefinitions ?? (_scriptDefinitions = ScriptDefinitionsFactory.Create(Version, Platform));

        public List<LocaleTable> LocaleTables;
        public abstract StringTable StringTable { get; }
        public abstract TagCache TagCache { get; }
        public abstract ResourceCache ResourceCache { get; }

        public abstract Stream OpenCacheRead();
        public abstract Stream OpenCacheReadWrite();
        public abstract Stream OpenCacheWrite();

        public abstract void Serialize(Stream stream, CachedTag instance, object definition);
        public abstract object Deserialize(Stream stream, CachedTag instance);
        public abstract T Deserialize<T>(Stream stream, CachedTag instance);

        public static GameCache Open(string filePath) => Open(new FileInfo(filePath));

        public static GameCache Open(FileInfo file)
        {
            if(file.Name.Equals("blob_index.dat"))
                return new GameCacheMonolithic(file);

            MapFile map = new MapFile();
            var estimatedVersion = CacheVersion.EldoradoED;

            using (var stream = file.OpenRead())
            using (var reader = new EndianReader(stream))
            {
                if (file.Name.Contains(".map"))
                {
                    map.Read(reader);
                    estimatedVersion = map.Version;
                }
                else if (file.Name.Equals("tags.dat"))
                    estimatedVersion = CacheVersion.EldoradoED;
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
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3XboxOne:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReachAlpha:
                case CacheVersion.HaloReachPreBeta:
                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReach:
                    return new GameCacheGen3(map, file);

                case CacheVersion.EldoradoED:
                case CacheVersion.Eldorado106708:
                case CacheVersion.Eldorado155080:
                case CacheVersion.Eldorado235640:
                case CacheVersion.Eldorado301003:
                case CacheVersion.Eldorado327043:
                case CacheVersion.Eldorado372731:
                case CacheVersion.Eldorado416097:
                case CacheVersion.Eldorado430475:
                case CacheVersion.Eldorado454665:
                case CacheVersion.Eldorado449175:
                case CacheVersion.Eldorado498295:
                case CacheVersion.Eldorado530605:
                case CacheVersion.Eldorado532911:
                case CacheVersion.Eldorado554482:
                case CacheVersion.Eldorado571627:
                case CacheVersion.Eldorado604673:
                case CacheVersion.Eldorado700123:
                    {
                        var directory = file.Directory.FullName;
                        var tagsPath = Path.Combine(directory, "tags.dat");
                        var tagsFile = new FileInfo(tagsPath);

                        if (!tagsFile.Exists)
                            throw new Exception("Failed to find tags.dat");

                        return new GameCacheEldorado(tagsFile.Directory);
                    }

                case CacheVersion.Halo4E3:
                case CacheVersion.Halo4:
                case CacheVersion.Halo2AMP:
                    return new GameCacheGen4(map, file);
            }

            return null;
        }

        public abstract void SaveStrings();
    }
}
