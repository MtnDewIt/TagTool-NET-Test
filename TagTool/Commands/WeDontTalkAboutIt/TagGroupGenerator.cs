using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.Cache.Gen3;
using TagTool.Commands.WeDontTalkAboutIt.Groups;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Commands.WeDontTalkAboutIt
{
    public class TagGroupGenerator
    {
        private static string Layout;

        private static ZeusVersion Build;

        public TagGroupGenerator(ZeusVersion build)
        {
            Build = build;
        }

        public void GenerateTableFile() 
        {
            Layout = GenerateTagGroupsLayout();

            FileInfo fileInfo = new FileInfo(Path.Combine("", $"Cache\\Gen3\\TagDefinitions{Build}.cs"));

            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            using FileStream fileStream = fileInfo.Create();
            using StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(Layout);

            Layout = string.Empty;
        }

        public void GenerateGroupFile()
        {
            Layout = GenerateTagGroupLayout();

            FileInfo fileInfo = new FileInfo(Path.Combine("", $"Cache\\Gen3\\TagGroup{Build}.cs"));

            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            using FileStream fileStream = fileInfo.Create();
            using StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(Layout);

            Layout = string.Empty;
        }

        public static string GenerateTagGroupsLayout() 
        {
            string definitions = GenerateTagDefinitions();

            StringBuilder sb = new();

            sb.Append($"using System.Collections.Frozen;\n");
            sb.Append($"using System.Collections.Generic;\n");
            sb.Append($"using TagTool.Cache.Resources;\n");
            sb.Append($"using TagTool.Common;\n");
            sb.Append($"using TagTool.Tags;\n");
            sb.Append($"using TagTool.Tags.Definitions.{Build};\n");
            sb.Append($"\n");
            sb.Append($"namespace TagTool.Cache.Gen3\n");
            sb.Append($"{{\n");
            sb.Append($"\tpublic class TagDefinitions{Build} : TagDefinitions\n");
            sb.Append($"\t{{\n");
            sb.Append($"\t\tpublic static FrozenDictionary<TagGroup, System.Type> {Build}Types => {Build}Definitions.TagGroupToTypeLookup;\n");
            sb.Append($"\t\tprivate static readonly CachedDefinitions {Build}Definitions = GetCachedDefinitions(new Dictionary<TagGroup, System.Type>\n");
            sb.Append($"\t\t{{\n");
            sb.Append(definitions);
            sb.Append($"\t\t}});\n");
            sb.Append($"\t\tpublic TagDefinitions{Build}() : base({Build}Definitions) {{ }}\n");
            sb.Append($"\n");
            sb.Append($"\t\tprivate static readonly FrozenDictionary<string, Tag> NameToTagLookup = NameToTagLookupValue();\n");
            sb.Append($"\t\tprivate static FrozenDictionary<string, Tag> NameToTagLookupValue()\n");
            sb.Append($"\t\t{{\n");
            sb.Append($"\t\t\tvar result = new Dictionary<string, Tag>();\n");
            sb.Append($"\t\t\tforeach (var (key, _) in {Build}Definitions.TagGroupToTypeLookup)\n");
            sb.Append($"\t\t\t{{\n");
            sb.Append($"\t\t\t\tresult.Add(((TagGroup{Build})key).Name, key.Tag);\n");
            sb.Append($"\t\t\t}}\n");
            sb.Append($"\t\t\treturn result.ToFrozenDictionary();\n");
            sb.Append($"\t\t}}\n");
            sb.Append($"\n");
            sb.Append($"\t\tpublic bool TryGetTagFromName(string name, out Tag tag)\n");
            sb.Append($"\t\t{{\n");
            sb.Append($"\t\t\treturn NameToTagLookup.TryGetValue(name, out tag);\n");
            sb.Append($"\t\t}}\n");
            sb.Append($"\t}}\n");
            sb.Append($"}}\n");

            return sb.ToString();
        }

        public static string GenerateTagDefinitions() 
        {
            StringBuilder sb = new();

            List<TagGroupGen3> tagGroups = GroupHandler.GetTagGroups(Build).OrderBy(g => g.Tag.ToString()).ToList();

            foreach (var group in tagGroups) 
            {
                string groups = group.Tag != Tag.Null ? $"\"{group.Tag}\", " : "";
                groups += group.ParentTag != Tag.Null ? $"\"{group.ParentTag}\", " : "";
                groups += group.GrandParentTag != Tag.Null ? $"\"{group.GrandParentTag}\", " : "";

                string groupName = group.Name;
                string typeName = group.Name.ToPascalCase();

                sb.Append($"\t\t\t{{ new TagGroup{Build}({groups}\"{groupName}\"), typeof({typeName}) }},\n");
            }

            return sb.ToString();
        }

        public static string GenerateTagGroupLayout() 
        {
            StringBuilder sb = new();

            sb.Append($"using TagTool.Common;\n");
            sb.Append($"using TagTool.Tags;\n");
            sb.Append($"\n");
            sb.Append($"namespace TagTool.Cache.Gen3\n");
            sb.Append($"{{\n");
            sb.Append($"\tpublic class TagGroup{Build} : TagGroup\n");
            sb.Append($"\t{{\n");
            sb.Append($"\t\tpublic string Name;\n");
            sb.Append($"\t\tpublic TagGroup{Build}() : base() {{ Name = string.Empty; }}\n");
            sb.Append($"\t\tpublic TagGroup{Build}(Tag tag, string name) : base(tag) {{ Name = name; }}\n");
            sb.Append($"\t\tpublic TagGroup{Build}(Tag tag, Tag parentTag, string name) : base(tag, parentTag) {{ Name = name; }}\n");
            sb.Append($"\t\tpublic TagGroup{Build}(Tag tag, Tag parentTag, Tag grandparentTag, string name) : base(tag, parentTag, grandparentTag) {{ Name = name; }}\n");
            sb.Append($"\t\tpublic override string ToString() => string.IsNullOrEmpty(Name) ? Tag.ToString() : Name;\n");
            sb.Append($"\t}}\n");
            sb.Append($"}}\n");

            return sb.ToString();
        }
    }
}
