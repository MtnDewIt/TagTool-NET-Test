using System;
using System.Collections.Generic;
using System.Collections.Frozen;
using TagTool.Common;

namespace TagTool.Tags
{
    public abstract class TagDefinitions
    {
        protected static CachedDefinitions GetCachedDefinitions(Dictionary<TagGroup, Type> dict)
		{
			Dictionary<Tag, Type> TagToTypeLookup = [];
			Dictionary<Type, TagGroup> TypeToTagGroupLookup = [];
			Dictionary<Tag, TagGroup> TagToTagGroupLookup = [];

			foreach (var (key, value) in dict)
			{
				TagToTypeLookup.Add(key.Tag, value);
				TypeToTagGroupLookup.Add(value, key);
				TagToTagGroupLookup.Add(key.Tag, key);
			}

			CachedDefinitions definitions;
			definitions.TagGroupToTypeLookup = dict.ToFrozenDictionary();
			definitions.TagToTypeLookup = TagToTypeLookup.ToFrozenDictionary();
			definitions.TypeToTagGroupLookup = TypeToTagGroupLookup.ToFrozenDictionary();
			definitions.TagToTagGroupLookup = TagToTagGroupLookup.ToFrozenDictionary();
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
			public FrozenDictionary<TagGroup, Type> TagGroupToTypeLookup;
			public FrozenDictionary<Tag, Type> TagToTypeLookup;
			public FrozenDictionary<Type, TagGroup> TypeToTagGroupLookup;
			public FrozenDictionary<Tag, TagGroup> TagToTagGroupLookup;
		}

		public FrozenDictionary<TagGroup, Type> Types => definitions.TagGroupToTypeLookup;

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
