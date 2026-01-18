using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TagTool.Cache;
using TagTool.Commands.WeDontTalkAboutIt.Groups;
using TagTool.Common;
using TagTool.Geometry;
using TagTool.Geometry.BspCollisionGeometry;
using TagTool.Shaders;
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

            Dictionary<Type, bool> structureTypes = new Dictionary<Type, bool>();

            // #TODO: We need to handle indenting :/

            foreach (TagFieldInfo fieldInfo in TagStructure.GetTagFieldEnumerable(structureInfo))
            {
                var fieldName = fieldInfo.Name;
                var fieldType = fieldInfo.FieldType;

                // Checks if the field contains the padding flag
                if (fieldInfo.Attribute.Flags.HasFlag(TagFieldFlags.Padding))
                {
                    string length = string.Empty;

                    if (fieldInfo.Attribute.Length != 0)
                    {
                        length = $"Length = 0x{fieldInfo.Attribute.Length.ToString("X")}, ";
                    }

                    sb.AppendLine($"\t\t[TagField({length}Flags = TagFieldFlags.Padding)]");

                    sb.AppendLine($"\t\tpublic {FormatPrimitiveType(fieldType.Name.Replace("[]", ""))}[] {fieldName};");
                }

                // Checks if the field is a type of array which uses a primitive type, rather than objects or generics
                else if (ParseArray(fieldType))
                {
                    if (fieldInfo.Attribute.Length != 0)
                    {
                        sb.AppendLine($"\t\t[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]");
                    }

                    sb.AppendLine($"\t\tpublic {FormatPrimitiveType(fieldType.Name.Replace("[]", ""))}[] {fieldName};");
                }

                // Checks if the field is a type of array which uses objects or generics
                else if (fieldType.IsArray)
                {
                    if (fieldInfo.Attribute.Length != 0)
                    {
                        sb.AppendLine($"\t\t[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]");
                    }

                    sb.AppendLine($"\t\tpublic {FormatTypeName(fieldType.Name)} {fieldName};");

                    Type elementType = fieldType.GetElementType();

                    if (elementType != typeof(StringId) &&
                        elementType != typeof(CachedTag) &&
                        elementType != typeof(StructureSurfaceToTriangleMapping) &&
                        elementType != typeof(TagResourceReference) &&
                        elementType != typeof(PixelShaderReference) &&
                        elementType != typeof(VertexShaderReference) &&
                        elementType != typeof(ComputeShaderReference) &&
                        elementType != typeof(TagData) &&
                        elementType != typeof(TinyPositionVertex) &&
                        elementType != typeof(RealVector4d) &&
                        !elementType.IsPrimitive)
                    {
                        structureTypes.TryAdd(elementType, false);
                    }
                }

                // Checks if the field is a type of list
                else if (fieldType.GetInterface(typeof(IList).Name) != null)
                {
                    sb.AppendLine($"\t\tpublic {FormatListName(fieldType.Name)}<{FormatTypeName($"{fieldType.GenericTypeArguments[0].Name}")}> {fieldName};");

                    Type elementType = fieldType.GenericTypeArguments[0];

                    if (elementType != typeof(StringId) &&
                        elementType != typeof(CachedTag) &&
                        elementType != typeof(StructureSurfaceToTriangleMapping) &&
                        elementType != typeof(TagResourceReference) &&
                        elementType != typeof(PixelShaderReference) &&
                        elementType != typeof(VertexShaderReference) &&
                        elementType != typeof(ComputeShaderReference) &&
                        elementType != typeof(TagData) &&
                        elementType != typeof(TinyPositionVertex) &&
                        elementType != typeof(RealVector4d) &&
                        !elementType.IsPrimitive)
                    {
                        structureTypes.TryAdd(elementType, false);
                    }
                }

                // Checks if the field is a primitive type
                else if (fieldType.IsPrimitive)
                {
                    sb.AppendLine($"\t\tpublic {FormatPrimitiveType(fieldType.Name)} {fieldName};");
                }

                // Checks if the field is a type of Enumerator
                else if (fieldType.IsEnum)
                {
                    sb.AppendLine($"\t\tpublic {fieldType.Name} {fieldName};");

                    structureTypes.TryAdd(fieldType, false);
                }

                // Checks if the field is a type of BitFlags
                else if (fieldType.GetInterface(typeof(IBitFlags).Name) != null) 
                {
                    Type elementType = fieldType.GenericTypeArguments[0];

                    sb.AppendLine($"\t\tpublic {elementType.Name} {fieldName};");

                    structureTypes.TryAdd(elementType, true);
                }

                // Checks if the field is a type of string
                else if (fieldType == typeof(string))
                {
                    if (fieldInfo.Attribute.Length != 0)
                    {
                        sb.AppendLine($"\t\t[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]");
                    }

                    sb.AppendLine($"\t\tpublic string {fieldName};");
                }

                // Checks if the field is a type of object, and is not a generic, value or array type (basically anything that can't be parsed by the serializer). Also checks if it isn't some other TagTool specific types
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
                    sb.AppendLine($"\t\tpublic {fieldType.Name} {fieldName};");

                    if (fieldType != typeof(TagResourceReference) &&
                        fieldType != typeof(PixelShaderReference) &&
                        fieldType != typeof(VertexShaderReference) &&
                        fieldType != typeof(ComputeShaderReference) &&
                        fieldType != typeof(TagData) &&
                        fieldType != typeof(TinyPositionVertex) &&
                        fieldType != typeof(RealVector4d))
                    {
                        structureTypes.TryAdd(fieldType, false);
                    }
                }

                // Parses the specified value if all other checks return false
                else
                {
                    if (fieldType.GetInterface(typeof(IBounds).Name) != null)
                    {
                        sb.AppendLine($"\t\tpublic {FormatListName(fieldType.Name)}<{FormatTypeName($"{fieldType.GenericTypeArguments[0].Name}")}> {fieldName};");
                    }
                    else
                    {
                        sb.AppendLine($"\t\tpublic {fieldType.Name} {fieldName};");
                    }
                }
            }

            foreach (var structureType in structureTypes) 
            {
                if (structureType.Key.IsEnum)
                {
                    TagEnumInfo enumTypeInfo = TagEnum.GetInfo(structureType.Key, Version, Platform);

                    if (structureType.Value)
                    {
                        //  Minor issue with this. It assumes the enum has no default member

                        Type underlyingType = Enum.GetUnderlyingType(structureType.Key);

                        sb.AppendLine($"\t\t[Flags]");
                        sb.AppendLine($"\t\tpublic enum {structureType.Key.Name} : {FormatPrimitiveType(underlyingType.Name)}");
                        sb.AppendLine($"\t\t{{");

                        if (enumTypeInfo.IsVersioned)
                        {
                            var enumMembers = enumTypeInfo.Members.VersionedMembers;

                            if (enumMembers.Count != 0)
                            {
                                sb.AppendLine($"\t\t\tNone = 0,");

                                for (int i = 0; i < enumMembers.Count; i++)
                                {
                                    sb.AppendLine($"\t\t\t{enumMembers[i].Name} = 1 << {i},");
                                }
                            }
                        }
                        else
                        {
                            var enumMembers = Enum.GetNames(structureType.Key);

                            if (enumMembers.Length != 0)
                            {
                                sb.AppendLine($"\t\t\tNone = 0,");

                                for (int i = 0; i < enumMembers.Length; i++)
                                {
                                    sb.AppendLine($"\t\t\t{enumMembers[i]} = 1 << {i},");
                                }
                            }
                        }

                        sb.AppendLine($"\t\t}}");
                    }
                    else if (structureType.Key.IsDefined(typeof(FlagsAttribute), false))
                    {
                        Type underlyingType = Enum.GetUnderlyingType(structureType.Key);

                        sb.AppendLine($"\t\t[Flags]");
                        sb.AppendLine($"\t\tpublic enum {structureType.Key.Name} : {FormatPrimitiveType(underlyingType.Name)}");
                        sb.AppendLine($"\t\t{{");

                        if (enumTypeInfo.IsVersioned)
                        {
                            var enumMembers = enumTypeInfo.Members.VersionedMembers;

                            if (enumMembers.Count != 0)
                            {
                                sb.AppendLine($"\t\t\t{enumMembers[0].Name} = {Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[0].Name), underlyingType)},");

                                for (int i = 1; i < enumMembers.Count; i++)
                                {
                                    object memberValue = Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[i].Name), underlyingType);

                                    sb.AppendLine($"\t\t\t{enumMembers[i].Name} = 1 << {ParseFlagsValue(memberValue)},");
                                }
                            }
                        }
                        else
                        {
                            var enumMembers = Enum.GetNames(structureType.Key);

                            if (enumMembers.Length != 0)
                            {
                                sb.AppendLine($"\t\t\t{enumMembers[0]} = {Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[0]), underlyingType)},");

                                for (int i = 1; i < enumMembers.Length; i++)
                                {
                                    object memberValue = Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[i]), underlyingType);

                                    sb.AppendLine($"\t\t\t{enumMembers[i]} = 1 << {ParseFlagsValue(memberValue)},");
                                }
                            }
                        }

                        sb.AppendLine($"\t\t}}");
                    }
                    else
                    {
                        Type underlyingType = Enum.GetUnderlyingType(structureType.Key);

                        sb.AppendLine($"\t\tpublic enum {structureType.Key.Name} : {FormatPrimitiveType(underlyingType.Name)}");
                        sb.AppendLine($"\t\t{{");

                        if (enumTypeInfo.IsVersioned)
                        {
                            var enumMembers = enumTypeInfo.Members.VersionedMembers;

                            if (enumMembers.Count != 0)
                            {
                                sb.AppendLine($"\t\t\t{enumMembers[0].Name} = {Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[0].Name), underlyingType)},");

                                for (int i = 1; i < enumMembers.Count; i++)
                                {
                                    sb.AppendLine($"\t\t\t{enumMembers[i].Name},");
                                }
                            }
                        }
                        else 
                        {
                            var enumMembers = Enum.GetNames(structureType.Key);

                            if (enumMembers.Length != 0)
                            {
                                sb.AppendLine($"\t\t\t{enumMembers[0]} = {Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[0]), underlyingType)},");

                                for (int i = 1; i < enumMembers.Length; i++)
                                {
                                    sb.AppendLine($"\t\t\t{enumMembers[i]},");
                                }
                            }
                        }

                        sb.AppendLine($"\t\t}}");
                    }
                }
                else
                {
                    string version = GetTagDefinitionAttributeVersion(Build);

                    TagStructureInfo structureTypeInfo = structureType.Key != null ? TagStructure.GetTagStructureInfo(structureType.Key, Version, Platform) : null;

                    uint structureTypeSize = structureTypeInfo != null ? structureTypeInfo.TotalSize : 0;

                    sb.AppendLine($"\t\t[TagStructure(Size = 0x{structureTypeSize.ToString("X")}{version})]");
                    sb.AppendLine($"\t\tpublic class {structureType.Key.Name} : TagStructure");
                    sb.AppendLine($"\t\t{{");

                    string structure = structureTypeInfo != null ? ParseTagStructure(structureTypeInfo) : null;
                    
                    if (structure != null)
                    {
                        sb.AppendLine(structure);
                    }

                    sb.AppendLine($"\t\t}}");
                }
            }

            return sb.ToString();
        }

        private static object ParseFlagsValue(object value) 
        {
            switch (value.GetType()) 
            {
                case Type t when t == typeof(sbyte):
                    if (((sbyte)value > 0) && (((sbyte)value & ((sbyte)value - 1)) == 0)) 
                    {
                        return Math.Log2((sbyte)value);
                    }
                    else 
                    {
                        return $"0x{((sbyte)value).ToString("X")}";
                    }
                case Type t when t == typeof(byte):
                    if (((byte)value > 0) && (((byte)value & ((byte)value - 1)) == 0))
                    {
                        return Math.Log2((byte)value);
                    }
                    else
                    {
                        return $"0x{((byte)value).ToString("X")}";
                    }
                case Type t when t == typeof(short):
                    if (((short)value > 0) && (((short)value & ((short)value - 1)) == 0))
                    {
                        return Math.Log2((short)value);
                    }
                    else
                    {
                        return $"0x{((short)value).ToString("X")}";
                    }
                case Type t when t == typeof(ushort):
                    if (((ushort)value > 0) && (((ushort)value & ((ushort)value - 1)) == 0))
                    {
                        return Math.Log2((ushort)value);
                    }
                    else
                    {
                        return $"0x{((ushort)value).ToString("X")}";
                    }
                case Type t when t == typeof(int):
                    if (((int)value > 0) && (((int)value & ((int)value - 1)) == 0))
                    {
                        return Math.Log2((int)value);
                    }
                    else
                    {
                        return $"0x{((int)value).ToString("X")}";
                    }
                case Type t when t == typeof(uint):
                    if (((uint)value > 0) && (((uint)value & ((uint)value - 1)) == 0))
                    {
                        return Math.Log2((uint)value);
                    }
                    else
                    {
                        return $"0x{((uint)value).ToString("X")}";
                    }
                case Type t when t == typeof(long):
                    if (((long)value > 0) && (((long)value & ((long)value - 1)) == 0))
                    {
                        return Math.Log2((long)value);
                    }
                    else
                    {
                        return $"0x{((long)value).ToString("X")}";
                    }
                case Type t when t == typeof(ulong):
                    if (((ulong)value > 0) && (((ulong)value & ((ulong)value - 1)) == 0))
                    {
                        return Math.Log2((ulong)value);
                    }
                    else
                    {
                        return $"0x{((ulong)value).ToString("X")}";
                    }
                default:
                    return value;
            }
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
