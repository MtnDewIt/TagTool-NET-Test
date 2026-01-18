using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.Cache.Gen3;
using TagTool.Commands.WeDontTalkAboutIt.Groups;
using TagTool.Common;

namespace TagTool.Commands.WeDontTalkAboutIt
{
    public class TagGroupGenerator
    {
        private string Layout;

        private ZeusVersion Build;

        public TagGroupGenerator(ZeusVersion build)
        {
            Build = build;
        }

        public void GenerateFile() 
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
        }

        public string GenerateTagGroupsLayout() 
        {
            string definitions = GenerateTagDefinitions();

            StringBuilder sb = new();

            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Frozen;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine($"using TagTool.Cache.Resources;");
            sb.AppendLine($"using TagTool.Common;");
            sb.AppendLine($"using TagTool.Tags;");
            sb.AppendLine($"using TagTool.Tags.Definitions.{Build};");
            sb.AppendLine();
            sb.AppendLine($"namespace TagTool.Cache.Gen3");
            sb.AppendLine($"{{");
            sb.AppendLine($"\tpublic class TagDefinitions{Build} : TagDefinitions");
            sb.AppendLine($"\t{{");
            sb.AppendLine($"\t\tpublic static FrozenDictionary<TagGroup, Type> {Build}Types => {Build}Definitions.TagGroupToTypeLookup;");
            sb.AppendLine($"\t\tprivate static readonly CachedDefinitions {Build}Definitions = GetCachedDefinitions(new Dictionary<TagGroup, Type>");
            sb.AppendLine($"\t\t{{");
            sb.AppendLine(definitions);
            sb.AppendLine($"\t\t}});");
            sb.AppendLine($"\t\tpublic TagDefinitions{Build}() : base({Build}Definitions) {{ }}");
            sb.AppendLine();
            sb.AppendLine($"\t\tprivate static readonly FrozenDictionary<string, Tag> NameToTagLookup = NameToTagLookupValue();");
            sb.AppendLine($"\t\tprivate static FrozenDictionary<string, Tag> NameToTagLookupValue()");
            sb.AppendLine($"\t\t{{");
            sb.AppendLine($"\t\t\tvar result = new Dictionary<string, Tag>();");
            sb.AppendLine($"\t\t\tforeach (var (key, _) in {Build}Definitions.TagGroupToTypeLookup)");
            sb.AppendLine($"\t\t\t{{");
            sb.AppendLine($"\t\t\t\tresult.Add(((TagGroup{Build})key).Name, key.Tag);");
            sb.AppendLine($"\t\t\t}}");
            sb.AppendLine($"\t\t\treturn result.ToFrozenDictionary();");
            sb.AppendLine($"\t\t}}");
            sb.AppendLine();
            sb.AppendLine($"\t\tpublic bool TryGetTagFromName(string name, out Tag tag)");
            sb.AppendLine($"\t\t{{");
            sb.AppendLine($"\t\t\treturn NameToTagLookup.TryGetValue(name, out tag);");
            sb.AppendLine($"\t\t}}");
            sb.AppendLine($"\t}}");
            sb.AppendLine($"}}");

            return sb.ToString();
        }

        public string GenerateTagDefinitions() 
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

                sb.AppendLine($"\t\t\t{{ new TagGroupGen3({groups}\"{groupName}\"), typeof({typeName}) }},");
            }

            return sb.ToString();
        }
    }
}
