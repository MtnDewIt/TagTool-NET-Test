using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Cache.Gen1
{
    public class TagGroupGen1 : TagGroup
    {
        public string Name;
        public TagGroupGen1() : base() { Name = string.Empty; }
        public TagGroupGen1(Tag tag, string name) : base(tag) { Name = name; }
        public TagGroupGen1(Tag tag, Tag parentTag, string name) : base(tag, parentTag) { Name = name; }
        public TagGroupGen1(Tag tag, Tag parentTag, Tag grandparentTag, string name) : base(tag, parentTag, grandparentTag) { Name = name; }
        public override string ToString() => string.IsNullOrEmpty(Name) ? Tag.ToString() : Name;
    }
}
