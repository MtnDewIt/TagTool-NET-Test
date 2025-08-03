using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using TagTool.Cache;
using TagTool.Scripting;

namespace TagTool.Tags
{
    // TODO: merge into TagStructure, just keeping it separate for now while we trial this

    public class TagEnum
    {
        private static Dictionary<(CacheVersion, CachePlatform), VersionedCache> VersionedCaches
            = new Dictionary<(CacheVersion, CachePlatform), VersionedCache>();

        static TagEnum()
        {
            foreach (var platform in Enum.GetValues(typeof(CachePlatform)) as CachePlatform[])
                foreach (var version in Enum.GetValues(typeof(CacheVersion)) as CacheVersion[])
                    VersionedCaches[(version, platform)] = new VersionedCache(version, platform);
        }

        public static TagEnumInfo GetInfo(Type enumType, CacheVersion version, CachePlatform platform)
        {
            return VersionedCaches[(version, platform)].GetInfo(enumType);
        }

        public static TagEnumMemberEnumerable GetMemberEnumerable(TagEnumInfo info)
        {
            return VersionedCaches[(info.CacheVersion, info.CachePlatform)].GetMemberEnumerable(info);
        }

        public static TagEnumMemberEnumerable GetMemberEnumerable(Type enumType, CacheVersion version, CachePlatform platform)
        {
            var info = GetInfo(enumType, version, platform);
            return VersionedCaches[(version, platform)].GetMemberEnumerable(info);
        }

        public static bool AttributeInCacheVersion(TagEnumMemberAttribute attr, CacheVersion compare)
        {
            if (attr.Version != CacheVersion.Unknown)
                if (attr.Version != compare)
                    return false;

            if (attr.Gen != CacheGeneration.Unknown)
                if (!CacheVersionDetection.IsInGen(attr.Gen, compare))
                    return false;

            if (attr.MinVersion != CacheVersion.Unknown || attr.MaxVersion != CacheVersion.Unknown)
                if (!CacheVersionDetection.IsBetween(compare, attr.MinVersion, attr.MaxVersion))
                    return false;

            return true;
        }

        public static bool AttributeInPlatform(TagEnumMemberAttribute attr, CachePlatform compare)
        {
            return CacheVersionDetection.ComparePlatform(attr.Platform, compare);
        }

        class VersionedCache
        {
            public CacheVersion CacheVersion;
            public CachePlatform CachePlatform;

            public Dictionary<Type, TagEnumInfo> Infos = new Dictionary<Type, TagEnumInfo>();
            public Dictionary<FieldInfo, TagEnumMemberInfo> MemberInfos = new Dictionary<FieldInfo, TagEnumMemberInfo>();
            public Dictionary<TagEnumInfo, TagEnumMemberEnumerable> MemberEnumerables = new Dictionary<TagEnumInfo, TagEnumMemberEnumerable>();

            public VersionedCache(CacheVersion cacheVersion, CachePlatform cachePlatform)
            {
                CacheVersion = cacheVersion;
                CachePlatform = cachePlatform;
            }

            public TagEnumInfo GetInfo(Type enumType)
            {
                lock (Infos)
                {
                    if (!Infos.TryGetValue(enumType, out TagEnumInfo info))
                        Infos.Add(enumType, info = new TagEnumInfo(enumType, CacheVersion, CachePlatform));
                    return info;
                }
            }

            public TagEnumMemberEnumerable GetMemberEnumerable(TagEnumInfo info)
            {
                lock (MemberEnumerables)
                {
                    if (!MemberEnumerables.TryGetValue(info, out TagEnumMemberEnumerable enumerable))
                        MemberEnumerables.Add(info, enumerable = new TagEnumMemberEnumerable(info));
                    return enumerable;
                }
            }
        }
    }

    public class TagEnumInfo
    {
        public Type Type;
        public Type UnderlyingType;
        public CacheVersion CacheVersion;
        public CachePlatform CachePlatform;
        public TagEnumAttribute Attribute;
        public bool IsFlags;

        public TagEnumInfo(Type type, CacheVersion cacheVersion, CachePlatform cachePlatform)
        {
            Type = type;
            CacheVersion = cacheVersion;
            CachePlatform = cachePlatform;
            UnderlyingType = type.GetEnumUnderlyingType();
            Attribute = type.GetCustomAttribute<TagEnumAttribute>() ?? TagEnumAttribute.Default;
            IsFlags = type.GetCustomAttribute<FlagsAttribute>() != null;

            if (Attribute.IsVersioned)
            {
                if (UnderlyingType != typeof(int))
                    throw new NotSupportedException("Versioned enums must have an underlying type of int.");

                if (IsFlags)
                    throw new NotSupportedException("C# [Flags] Enum cannot be versioned, use FlagBits<Enum> instead.");
            }
        }

        public bool IsVersioned => Attribute.IsVersioned;

    }

    public class TagEnumMemberEnumerable : IEnumerable<TagEnumMemberInfo>
    {
        public readonly TagEnumInfo Info;
        public readonly List<TagEnumMemberInfo> Members = [];
        public readonly List<TagEnumMemberInfo> VersionedMembers = [];
        public readonly List<int> Constants = [];

        public TagEnumMemberEnumerable(TagEnumInfo info)
        {
            Info = info;
            Build();
        }

        public IEnumerator<TagEnumMemberInfo> GetEnumerator() => Members.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Members.GetEnumerator();

        private void Build()
        {
            int memberIndex = 0;
            foreach (var fieldInfo in Info.Type.GetFields(BindingFlags.Static | BindingFlags.Public).OrderBy(x => x.MetadataToken))
            {
                var attributes = fieldInfo.GetCustomAttributes<TagEnumMemberAttribute>(false);
                var matchingAttributes = attributes.Where(a => CacheVersionDetection.TestAttribute(a, Info.CacheVersion, Info.CachePlatform));
                var attr = matchingAttributes.FirstOrDefault() ?? attributes.DefaultIfEmpty(TagEnumMemberAttribute.Default).First();

                if (CacheVersionDetection.TestAttribute(attr, Info.CacheVersion, Info.CachePlatform))
                {
                    var value = fieldInfo.GetValue(null);
                    if (Info.Attribute.IsVersioned)
                    {
                        if (memberIndex.Equals(value))
                            throw new NotSupportedException("Versioned enums must be sequential.");
                    }

                    var info = new TagEnumMemberInfo(fieldInfo, attr, value);

                    if ((attr.Flags & TagEnumMemberFlags.Constant) != 0)
                        Constants.Add(Convert.ToInt32(value));
                    else
                        VersionedMembers.Add(info);

                    Members.Add(info);
                }

                memberIndex++;
            }
        }
    }

    public record TagEnumMemberInfo
    {
        public readonly FieldInfo FieldInfo;
        public readonly TagEnumMemberAttribute Attribute;
        public readonly object Value;

        public TagEnumMemberInfo(FieldInfo fieldInfo, TagEnumMemberAttribute attr, object value)
        {
            FieldInfo = fieldInfo;
            Attribute = attr;
            Value = value;
        }

        public string Name => FieldInfo.Name;
    }

    public class TagEnumAttribute : Attribute
    {
        public static readonly TagEnumAttribute Default = new TagEnumAttribute();
        public bool IsVersioned { get; set; } = false;
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class TagEnumMemberAttribute : Attribute
    {
        public static readonly TagEnumMemberAttribute Default = new TagEnumMemberAttribute();

        /// <summary>
        /// The flags of the field.
        /// </summary>
        public TagEnumMemberFlags Flags { get; set; } = TagEnumMemberFlags.None;

        /// <summary>
        /// The minimum cache version the tag field is present in.
        /// </summary>
        public CacheVersion MinVersion { get; set; } = CacheVersion.Unknown;

        /// <summary>
        /// The maximum cache version the tag field is present in.
        /// </summary>
        public CacheVersion MaxVersion { get; set; } = CacheVersion.Unknown;

        /// <summary>
        /// The set of versions the tag field is present in. (Can be combined with MinVersion/MaxVersion)
        /// </summary>
        public CacheVersion Version { get; set; } = CacheVersion.Unknown;

        /// <summary>
        /// The game generation of the tag field.
        /// </summary>
        public CacheGeneration Gen { get; set; } = CacheGeneration.Unknown;

        /// <summary>
        /// The platforms that the tag field are available on.
        /// </summary>
        public CachePlatform Platform { get; set; } = CachePlatform.All;
    }

    [Flags]
    public enum TagEnumMemberFlags
    {
        None = 0,

        /// <summary>
        /// Used for values that are contrary to the natural order. e.g -1, 0xBABA
        /// </summary>
        Constant = 1 << 0
    }
}
