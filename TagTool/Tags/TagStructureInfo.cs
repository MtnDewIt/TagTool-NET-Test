using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags
{
    /// <summary>
    /// Utility class for analyzing a tag structure type's inheritance hierarchy.
    /// </summary>
    public class TagStructureInfo
    {
        private TagFieldEnumerable _fields;
        private Func<object> _activator;

        /// <summary>
        /// Constructs a <see cref="TagStructureInfo"/> object which contains info about a tag structure type.
        /// </summary>
        /// <param name="structureType">The tag structure type to analyze.</param>
        /// <param name="version">The engine version to compare attributes against.</param>
        /// <param name="cachePlatform"></param>
        public TagStructureInfo(Type structureType, CacheVersion version, CachePlatform cachePlatform)
        {
            Version = version;
            CachePlatform = cachePlatform;
            GroupTag = new Tag(-1);
            ParentGroupTag = new Tag(-1);
            GrandparentGroupTag = new Tag(-1);
            Analyze(structureType, version, cachePlatform);    
        }

        /// <summary>
        /// Gets the engine version that was used to construct the info object.
        /// </summary>
        public CacheVersion Version { get; private set; }


        public CachePlatform CachePlatform { get; private set; }

        /// <summary>
        /// Gets the structure types in the structure's inheritance hierarchy in order from child to base.
        /// Types which do not have a matching TagStructure attribute will not be included in this list.
        /// </summary>
        public List<Type> Types { get; private set; }

        /// <summary>
        /// Gets the total size of the structure, including parent structures.
        /// </summary>
        public uint TotalSize { get; private set; }

        /// <summary>
        /// Gets the current <see cref="TagStructureAttribute"/>.
        /// </summary>
        public TagStructureAttribute Structure { get; private set; }

        /// <summary>
        /// Gets the group tag for the structure, or -1 if none.
        /// </summary>
        public Tag GroupTag { get; private set; }

        /// <summary>
        /// Gets the parent group tag for the structure, or -1 if none.
        /// </summary>
        public Tag ParentGroupTag { get; private set; }

        /// <summary>
        /// Gets the grandparent group tag for the structure, or -1 if none.
        /// </summary>
        public Tag GrandparentGroupTag { get; private set; }

        public TagFieldEnumerable TagFields
        {
            get
            {
                if (_fields == null)
                {
                    lock (this)
                    {
                        _fields ??= new TagFieldEnumerable(this);
                    }
                }

                return _fields;
            }
        }

        public object CreateInstance()
        {
            if (_activator == null)
            {
                lock (this)
                {
                    _activator ??= Expression.Lambda<Func<object>>(Expression.New(Types[0])).Compile();
                }
            }
            return _activator();
        }

        private void Analyze(Type mainType, CacheVersion version, CachePlatform cachePlatform)
        {
            // Get the attribute for the main structure type
            Structure = GetStructureAttribute(mainType, version, cachePlatform);
            if (Structure == null)
                throw new InvalidOperationException($"No `{nameof(TagStructureAttribute)}` for `{version}` platform `{cachePlatform}` found on `{mainType.Name}`.");

			// Scan through the type's inheritance hierarchy and analyze each TagStructure attribute
			var currentType = mainType;
            Types = [];
            while (currentType != null)
            {
                var attrib = (currentType != mainType) ? GetStructureAttribute(currentType, version, cachePlatform) : Structure;
                if (attrib != null)
                {
                    Types.Add(currentType);
                    TotalSize += attrib.Size;
                    if (attrib.Tag != null)
                    {
                        if (GroupTag.IsNull())
                            GroupTag = new Tag(attrib.Tag);
                        else if (ParentGroupTag.IsNull())
                            ParentGroupTag = new Tag(attrib.Tag);
                        else if (GrandparentGroupTag.IsNull())
                            GrandparentGroupTag = new Tag(attrib.Tag);
                    }
                }
                currentType = currentType.BaseType;
            }
        }

        private static TagStructureAttribute GetStructureAttribute(Type type, CacheVersion version, CachePlatform platform)
        {
            foreach (var attr in type.GetCustomAttributes<TagStructureAttribute>(false))
            {
                if (CacheVersionDetection.TestAttribute(attr, version, platform))
                    return attr;
            }

            return null;
        }
    }
}