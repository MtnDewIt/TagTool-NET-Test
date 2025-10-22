using System;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Threading;
using TagTool.Cache;
using TagTool.Commands.Common;

namespace TagTool.Tags
{
    public class TagStructure
    {
        private static readonly FrozenDictionary<(CacheVersion version, CachePlatform platform), VersionedCache> VersionedCaches = CreateVersionedCache();

        public static TagStructureAttribute GetTagStructureAttribute(Type type, CacheVersion version, CachePlatform cachePlatform) =>
            VersionedCaches[(version, cachePlatform)].GetTagStructureAttribute(type);

        public static TagStructureInfo GetTagStructureInfo(Type type, CacheVersion version, CachePlatform cachePlatform) =>
             VersionedCaches[(version, cachePlatform)].GetTagStructureInfo(type);

        public static TagFieldEnumerable GetTagFieldEnumerable(Type type, CacheVersion version, CachePlatform cachePlatform) =>
            GetTagFieldEnumerable(GetTagStructureInfo(type, version, cachePlatform));

        public static TagFieldEnumerable GetTagFieldEnumerable(TagStructureInfo info) => info.TagFields;

        public static VersionedCache GetVersonedCache(CacheVersion version, CachePlatform platform)
        {
            return VersionedCaches[(version, platform)];
        }

        private static FrozenDictionary<(CacheVersion version, CachePlatform platform), VersionedCache> CreateVersionedCache()
        {
            var builder = ImmutableDictionary.CreateBuilder<(CacheVersion, CachePlatform), VersionedCache>();

            foreach (var platform in Enum.GetValues(typeof(CachePlatform)) as CachePlatform[])
                foreach (var version in Enum.GetValues(typeof(CacheVersion)) as CacheVersion[])
                    builder.Add((version, platform), new VersionedCache(version, platform));

            return builder.ToFrozenDictionary();
        }

        public TagStructureAttribute GetTagStructureAttribute(CacheVersion version, CachePlatform cachePlatform) =>
            GetTagStructureAttribute(GetType(), version, cachePlatform);

        public TagStructureInfo GetTagStructureInfo(CacheVersion version, CachePlatform cachePlatform) =>
            GetTagStructureInfo(GetType(), version, cachePlatform);

        public TagFieldEnumerable GetTagFieldEnumerable(CacheVersion version, CachePlatform cachePlatform) =>
            GetTagFieldEnumerable(GetType(), version, cachePlatform);


        public virtual void PreConvert(CacheVersion from, CacheVersion to)
        {
        }

        public virtual void PostConvert(CacheVersion from, CacheVersion to)
        {
        }

        public class VersionedCache(CacheVersion version, CachePlatform cachePlatform)
        {
            private readonly CacheVersion Version = version;
            private readonly CachePlatform Platform = cachePlatform;

            private readonly Dictionary<nint, TagStructureInfo> TagStructureInfos = [];
                
            public TagStructureInfo GetTagStructureInfo(Type type)
            {
                nint typeHandle = type.TypeHandle.Value;

                lock (TagStructureInfos)
                {
                    if (!TagStructureInfos.TryGetValue(typeHandle, out var info))
                        TagStructureInfos.Add(typeHandle, info = new TagStructureInfo(type, Version, Platform));

                    return info;
                }
            }

            public TagStructureAttribute GetTagStructureAttribute(Type type)
            {
                return GetTagStructureInfo(type)?.Structure;
            }  
        }

        public static uint GetStructureSize(Type type, CacheVersion version, CachePlatform cachePlatform)
        {
            return GetTagStructureInfo(type, version, cachePlatform).TotalSize;
        }
    }
}