using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Gen2
{
    public class TagGroupGen2 : TagGroup
    {
        public string Name;
        public TagGroupGen2() : base() { Name = string.Empty; }
        public TagGroupGen2(Tag tag, string name) : base(tag) { Name = name; }
        public TagGroupGen2(Tag tag, Tag parentTag, string name) : base(tag, parentTag) { Name = name; }
        public TagGroupGen2(Tag tag, Tag parentTag, Tag grandparentTag, string name) : base(tag, parentTag, grandparentTag) { Name = name; }
        public override string ToString() => string.IsNullOrEmpty(Name) ? Tag.ToString() : Name;
    }
}
