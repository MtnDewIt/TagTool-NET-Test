using System;
using System.Collections.Generic;
using TagTool.Common;

namespace TagTool.Tags
{
    public abstract class TagDefinitions
    {
        protected static CachedDefinitions GetCachedDefinitions(Dictionary<TagGroup, Type> dict)
		{
			Dictionary<TagGroup, Type> TagGroupToTypeLookup = dict;
			Dictionary<Tag, Type> TagToTypeLookup = new();
			Dictionary<Type, TagGroup> TypeToTagGroupLookup = new();
			Dictionary<Tag, TagGroup> TagToTagGroupLookup = new();

			foreach (var (key, value) in dict)
			{
				TagToTypeLookup.Add(key.Tag, value);
				TypeToTagGroupLookup.Add(value, key);
				TagToTagGroupLookup.Add(key.Tag, key);
			}

			CachedDefinitions definitions;
			definitions.TagGroupToTypeLookup = TagGroupToTypeLookup;
			definitions.TagToTypeLookup = TagToTypeLookup;
			definitions.TypeToTagGroupLookup = TypeToTagGroupLookup;
			definitions.TagToTagGroupLookup = TagToTagGroupLookup;
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
			public Dictionary<TagGroup, Type> TagGroupToTypeLookup;
			public Dictionary<Tag, Type> TagToTypeLookup;
			public Dictionary<Type, TagGroup> TypeToTagGroupLookup;
			public Dictionary<Tag, TagGroup> TagToTagGroupLookup;
		}

		public Dictionary<TagGroup, Type> Types => definitions.TagGroupToTypeLookup;

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
