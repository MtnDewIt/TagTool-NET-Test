using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;
using TagTool.Cache;
using TagTool.Commands.WeDontTalkAboutIt.Groups;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Commands.WeDontTalkAboutIt
{
    public class TagDefinitionGenerator
    {
        private static ZeusVersion Build;
        private static CacheVersion Version;
        private static CachePlatform Platform;

        public TagDefinitionGenerator(ZeusVersion build)
        {
            Build = build;
            Version = CacheVersion.Unknown;
            Platform = CachePlatform.All;

            GetTagDefinitionVersioning(Build, ref Version, ref Platform);
        }

        public void GenerateFiles()
        {
            var groups = GroupHandler.GetGroups(Build);

            foreach (var group in groups)
            {
                GenerateFile(group.Key.ToString(), group.Value);
            }
        }

        public void GenerateFile(string tag, string name)
        {
            string layout = GenerateTagDefinitionLayout(tag, name);

            FileInfo fileInfo = new FileInfo(Path.Combine("", $"Tags\\Definitions\\{Build}\\{name.ToPascalCase()}.cs"));

            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            using FileStream fileStream = fileInfo.Create();
            using StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(layout);
        }

        public string GenerateTagDefinitionLayout(string tag, string name)
        {
            string definition = GenerateTagDefinition(tag, name);

            StringBuilder sb = new();

            sb.AppendLine($"using TagTool.Cache;");
            sb.AppendLine($"using TagTool.Common;");
            sb.AppendLine($"using TagTool.Tags;");
            sb.AppendLine($"using System;");
            sb.AppendLine($"using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine($"namespace TagTool.Tags.Definitions.{Build}");
            sb.AppendLine($"{{");
            sb.AppendLine(definition);
            sb.AppendLine($"}}");

            return sb.ToString();
        }

        public string GenerateTagDefinition(string tag, string name)
        {
            string version = GetTagDefinitionAttributeVersion(Build);
            Type structureType = GroupHandler.GetType(Build, tag);

            TagStructureInfo structureInfo = structureType != null ? TagStructure.GetTagStructureInfo(structureType, Version, Platform) : null;

            uint structureSize = structureInfo != null ? structureInfo.TotalSize : 0;

            StringBuilder sb = new();

            sb.AppendLine($"\t[TagStructure(Name = \"{name}\", Tag = \"{tag}\", Size = 0x{structureSize.ToString("X")}{version})]");
            sb.AppendLine($"\tpublic class {name.ToPascalCase()} : TagStructure");
            sb.AppendLine($"\t{{");

            string structure = structureInfo != null ? ParseTagStructure(structureInfo) : null;

            if (structure != null)
            {
                sb.AppendLine(structure);
            }

            sb.AppendLine($"\t}}");

            return sb.ToString();
        }

        public static string ParseTagStructure(TagStructureInfo structureInfo) 
        {
            StringBuilder sb = new StringBuilder();

            for (int j = 0; j < TagStructure.GetTagFieldEnumerable(structureInfo).Count; j++)
            {
                var fieldInfo = TagStructure.GetTagFieldEnumerable(structureInfo)[j];
                var fieldName = fieldInfo.Name;
                var fieldType = fieldInfo.FieldType;

                // #TODO: Checks we need to add:
                // Check if any fields have a default value assigned to them (This is often the case with tag functions, might end up ignoring this)
                // Check if a field is a static array ([] arrays that have a static length)
                // Check if a field is a list (non static collection of tag structures (They might not be tag structures in some cases :/))
                // Check if a field is a reference object (Is a type of object, and is not a generic, value or array type (basically anything that can't be parsed by the serializer). Also checks if it isn't a string or some other TagTool specific types)
                // Check if the type in an array or collection is a TagStructure (We'll need to iterate through the structure to pull thier fields as well)
                // Check if the field is a generic type (They'll need to be formatted separately)

                if (fieldInfo.Attribute.Flags.HasFlag(TagFieldFlags.Padding))
                {
                    string data = FormatPadding(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
                else if (ParseArray(fieldType))
                {
                    string data = FormatPrimitiveArray(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
                else if (fieldType.IsArray)
                {
                    string data = FormatGenericArray(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
                else if (fieldType.GetInterface(typeof(IList).Name) != null)
                {
                    string data = FormatGenericList(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
                else if (fieldType.IsPrimitive)
                {
                    string data = FormatPrimitive(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
                else if (fieldType.IsEnum)
                {
                    string data = FormatEnumerator(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
                else if (fieldType == typeof(string))
                {
                    string data = FormatString(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
                else if (
                    !fieldType.IsPrimitive &&
                    !fieldType.IsGenericType &&
                    !fieldType.IsValueType &&
                    !fieldType.IsArray &&
                    !(fieldType == typeof(PlatformUnsignedValue)) &&
                    !(fieldType == typeof(PlatformSignedValue)) &&
                    !(fieldType == typeof(CachedTag)) &&
                    !(fieldType == typeof(string)))
                {
                    string data = FormatReferenceObject(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
                else
                {
                    string data = FormatType(fieldInfo, fieldType, fieldName);
                    sb.AppendLine(data);
                }
            }

            return sb.ToString();
        }

        private static string FormatPadding(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            string length = string.Empty;

            if (fieldInfo.Attribute.Length != 0) 
            {
                length = $"Length = 0x{fieldInfo.Attribute.Length.ToString("X")}, ";
            }

            sb.AppendLine($"\t\t[TagField({length}Flags = TagFieldFlags.Padding)]");

            sb.AppendLine($"\t\tpublic {FormatPrimitiveType(fieldType.Name.Replace("[]", ""))}[] {fieldName};");

            return sb.ToString();
        }

        private static string FormatPrimitiveArray(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            if (fieldInfo.Attribute.Length != 0) 
            {
                sb.AppendLine($"\t\t[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]");
            }

            sb.AppendLine($"\t\tpublic {FormatPrimitiveType(fieldType.Name.Replace("[]", ""))}[] {fieldName};");

            return sb.ToString();
        }

        private static string FormatGenericArray(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            if (fieldInfo.Attribute.Length != 0) 
            {
                sb.AppendLine($"\t\t[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]");
            }

            sb.AppendLine($"\t\tpublic {FormatTypeName(fieldType.Name)} {fieldName};");

            return sb.ToString();
        }

        private static string FormatGenericList(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\t\tpublic {FormatListName(fieldType.Name)}<{FormatTypeName($"{fieldType.GenericTypeArguments[0].Name}")}> {fieldName};");

            return sb.ToString();
        }

        private static string FormatPrimitive(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\t\tpublic {FormatPrimitiveType(fieldType.Name)} {fieldName};");

            return sb.ToString();
        }

        private static string FormatString(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            if (fieldInfo.Attribute.Length != 0)
            {
                sb.AppendLine($"\t\t[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]");
            }

            sb.AppendLine($"\t\tpublic string {fieldName};");

            return sb.ToString();
        }

        private static string FormatEnumerator(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\t\tpublic {fieldType.Name} {fieldName};");

            return sb.ToString();
        }

        private static string FormatReferenceObject(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"\t\tpublic {fieldType.Name} {fieldName};");

            return sb.ToString();
        }

        private static string FormatType(TagFieldInfo fieldInfo, Type fieldType, string fieldName) 
        {
            StringBuilder sb = new StringBuilder();

            if (fieldType.GetInterface(typeof(IBounds).Name) != null || fieldType.GetInterface(typeof(IBitFlags).Name) != null)
            {
                sb.AppendLine($"\t\tpublic {FormatListName(fieldType.Name)}<{FormatTypeName($"{fieldType.GenericTypeArguments[0].Name}")}> {fieldName};");
            }
            else
            {
                sb.AppendLine($"\t\tpublic {fieldType.Name} {fieldName};");
            }

            return sb.ToString();
        }

        private static bool ParseArray(Type type)
        {
            if (type.IsArray)
            {
                Type arrayType = type.GetElementType();

                return arrayType.IsPrimitive;
            }

            return false;
        }

        private static string FormatPrimitiveType(string typeName)
        {
            string name = typeName switch
            {
                "Byte" => "byte",
                "SByte" => "sbyte",
                "UInt16" => "ushort",
                "Int16" => "short",
                "UInt32" => "uint",
                "Int32" => "int",
                "UInt64" => "ulong",
                "Int64" => "long",
                "Single" => "float",
                _ => typeName,
            };
            return name;
        }

        private static string FormatTypeName(string typeString)
        {
            string output;

            output = typeString.Substring(typeString.LastIndexOf('.') + 1);

            output = output.Replace('+', '.');

            return output;
        }

        private static string FormatListName(string listName)
        {
            string output;

            output = listName.Replace("`1", "");

            return output;
        }

        public static string GetTagDefinitionAttributeVersion(ZeusVersion build) 
        {
            return build switch
            {
                // We should only need this in the event the base structure requires versioning info

                //ZeusVersion.Halo3Xenon => ", MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = Platform = CachePlatform.Original",
                //ZeusVersion.Halo3ODSTXenon => ", MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = Platform = CachePlatform.Original",
                //ZeusVersion.Halo3Ares => ", MinVersion = CacheVersion.Halo3XboxOne, MaxVersion = CacheVersion.Halo3XboxOne, Platform = Platform = CachePlatform.MCC",
                //ZeusVersion.Halo3Latest => ", MinVersion = CacheVersion.Halo3Retail, MaxVersion = CacheVersion.Halo3Retail, Platform = Platform = CachePlatform.MCC",
                //ZeusVersion.Halo3ODSTLatest => ", MinVersion = CacheVersion.Halo3ODST, MaxVersion = CacheVersion.Halo3ODST, Platform = Platform = CachePlatform.MCC",
                //ZeusVersion.HaloOnlineMS23 => ", MinVersion = CacheVersion.HaloOnline106708, MaxVersion = CacheVersion.HaloOnline106708, Platform = Platform = CachePlatform.Original",
                _ => "",
            };
        }

        public static void GetTagDefinitionVersioning(ZeusVersion build, ref CacheVersion version, ref CachePlatform platform) 
        {
            switch (build) 
            {
                case ZeusVersion.Halo3Xenon:
                    version = CacheVersion.Halo3Retail;
                    platform = CachePlatform.Original;
                    break;
                case ZeusVersion.Halo3ODSTXenon:
                    version = CacheVersion.Halo3ODST;
                    platform = CachePlatform.Original;
                    break;
                case ZeusVersion.Halo3Ares:
                    version = CacheVersion.Halo3XboxOne;
                    platform = CachePlatform.MCC;
                    break;
                case ZeusVersion.Halo3Latest:
                    version = CacheVersion.Halo3Retail;
                    platform = CachePlatform.MCC;
                    break;
                case ZeusVersion.Halo3ODSTLatest:
                    version = CacheVersion.Halo3ODST;
                    platform = CachePlatform.MCC;
                    break;
                case ZeusVersion.HaloOnlineMS23:
                    version = CacheVersion.HaloOnline106708;
                    platform = CachePlatform.Original;
                    break;
                default:
                    break;
            }
        }
    }
}
