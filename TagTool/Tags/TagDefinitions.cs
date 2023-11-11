using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using TagTool.Common;

namespace TagTool.Tags
{
    public abstract class TagDefinitions
    {
        protected static CachedDefinitions GetCachedDefinitions(Dictionary<TagGroup, Type> dict)
		{
			ImmutableDictionary<Tag, Type>.Builder TagToTypeLookup = ImmutableDictionary.CreateBuilder<Tag, Type>();
			ImmutableDictionary<Type, TagGroup>.Builder TypeToTagGroupLookup = ImmutableDictionary.CreateBuilder<Type, TagGroup>();
			ImmutableDictionary<Tag, TagGroup>.Builder TagToTagGroupLookup = ImmutableDictionary.CreateBuilder<Tag, TagGroup>();

			foreach (var (key, value) in dict)
			{
				TagToTypeLookup.Add(key.Tag, value);
				TypeToTagGroupLookup.Add(value, key);
				TagToTagGroupLookup.Add(key.Tag, key);
			}

			CachedDefinitions definitions;
			definitions.TagGroupToTypeLookup = dict.ToImmutableDictionary();
			definitions.TagToTypeLookup = TagToTypeLookup.ToImmutable();
			definitions.TypeToTagGroupLookup = TypeToTagGroupLookup.ToImmutable();
			definitions.TagToTagGroupLookup = TagToTagGroupLookup.ToImmutable();
			return definitions;
		}

		protected TagDefinitions(CachedDefinitions definitions)
		{
			this.definitions = definitions;
		}

		CachedDefinitions definitions;

		protected struct CachedDefinitions
		{
			public bool IsNull => TagGroupToTypeLookup == null;
			public ImmutableDictionary<TagGroup, Type> TagGroupToTypeLookup;
			public ImmutableDictionary<Tag, Type> TagToTypeLookup;
			public ImmutableDictionary<Type, TagGroup> TypeToTagGroupLookup;
			public ImmutableDictionary<Tag, TagGroup> TagToTagGroupLookup;
		}

		public ImmutableDictionary<TagGroup, Type> Types => definitions.TagGroupToTypeLookup;

		public bool TagDefinitionExists(TagGroup group)
        {
            return definitions.TagGroupToTypeLookup.ContainsKey(group);
        }

        public bool TagDefinitionExists(Tag tag)
        {
			return definitions.TagToTypeLookup.ContainsKey(tag);
        }

        public Type GetTagDefinitionType(TagGroup group)
        {
			return definitions.TagGroupToTypeLookup.TryGetValue(group, out var val) ? val : null;
        }

        public Type GetTagDefinitionType(Tag tag)
        {
			return definitions.TagToTypeLookup.TryGetValue(tag, out var val) ? val : null;
        }

        public TagGroup GetTagDefinitionGroupTag(Type type)
        {
			return definitions.TypeToTagGroupLookup.TryGetValue(type, out var val) ? val : null;
        }

        public TagGroup GetTagGroupFromTag(Tag tag)
		{
			return definitions.TagToTagGroupLookup.TryGetValue(tag, out var val) ? val : null;
		}
    }
}
