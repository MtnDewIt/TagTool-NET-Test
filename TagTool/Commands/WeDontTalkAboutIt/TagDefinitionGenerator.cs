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

        public static void GenerateFile(string tag, string name)
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

        public static string GenerateTagDefinitionLayout(string tag, string name)
        {
            string definition = GenerateTagDefinition(tag, name);

            StringBuilder sb = new();

            sb.Append($"using TagTool.Cache;\n");
            sb.Append($"using TagTool.Common;\n");
            sb.Append($"using TagTool.Tags;\n");
            sb.Append($"using System;\n");
            sb.Append($"using System.Collections.Generic;\n");
            sb.Append($"\n");
            sb.Append($"namespace TagTool.Tags.Definitions.{Build}\n");
            sb.Append($"{{\n");
            sb.Append(definition);
            sb.Append($"}}");

            return sb.ToString();
        }

        public static string GenerateTagDefinition(string tag, string name)
        {
            string version = GetTagDefinitionAttributeVersion(Build);
            Type structureType = GroupHandler.GetType(Build, tag);

            TagStructureInfo structureInfo = structureType != null ? TagStructure.GetTagStructureInfo(structureType, Version, Platform) : null;

            uint structureSize = structureInfo != null ? structureInfo.TotalSize : 0;

            StringBuilder sb = new();

            sb.Append($"\t[TagStructure(Name = \"{name}\", Tag = \"{tag}\", Size = 0x{structureSize.ToString("X")}{version})]\n");
            sb.Append($"\tpublic class {name.ToPascalCase()} : TagStructure\n");
            sb.Append($"\t{{\n");

            string structure = structureInfo != null ? ParseTagStructure(structureInfo, $"\t\t") : null;

            if (structure != null)
            {
                sb.Append(structure);
            }

            sb.Append($"\t}}\n");

            return sb.ToString();
        }

        public static string ParseTagStructure(TagStructureInfo structureInfo, string indent)
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<Type, Type> bitFlags = new Dictionary<Type, Type>();
            Dictionary<Type, bool> structureTypes = new Dictionary<Type, bool>();

            TagFieldEnumerable fieldEnmerable = TagStructure.GetTagFieldEnumerable(structureInfo);

            int previousPaddingCount = 0;
            int previousArrayCount = 0;
            int previousPrimitiveArrayCount = 0;
            int previousStringCount = 0;

            for (int i = 0; i < fieldEnmerable.Count; i++)
            {
                TagFieldInfo fieldInfo = fieldEnmerable[i];
                string fieldName = fieldInfo.Name;
                Type fieldType = fieldInfo.FieldType;

                // Checks if the field contains the padding flag
                if (fieldInfo.Attribute.Flags.HasFlag(TagFieldFlags.Padding))
                {
                    string leading = FormatLeading(i, previousPaddingCount);

                    string length = fieldInfo.Attribute.Length != 0 ? $"Length = 0x{fieldInfo.Attribute.Length:X}, " : string.Empty;

                    sb.Append($"{leading}{indent}[TagField({length}Flags = TagFieldFlags.Padding)]\n");

                    sb.Append($"{indent}public {FormatPrimitiveType(fieldType.Name.Replace("[]", ""))}[] {fieldName};\n");

                    if (i < fieldEnmerable.Count - 1)
                    {
                        sb.Append("\n");
                    }

                    previousPaddingCount = i;
                }

                // Checks if the field is a type of array which uses a primitive type, rather than objects or generics
                else if (IsPrimitiveArray(fieldType))
                {
                    bool hasLength = fieldInfo.Attribute.Length != 0;

                    if (hasLength)
                    {
                        string leading = FormatLeading(i, previousPrimitiveArrayCount);

                        sb.Append($"{leading}{indent}[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]\n");
                    }

                    sb.Append($"{indent}public {FormatPrimitiveType(fieldType.Name.Replace("[]", ""))}[] {fieldName};\n");

                    if (i < fieldEnmerable.Count - 1 && hasLength)
                    {
                        sb.Append("\n");
                    }

                    previousPrimitiveArrayCount = i;
                }

                // Checks if the field is a type of array which uses objects or generics
                else if (fieldType.IsArray)
                {
                    bool hasLength = fieldInfo.Attribute.Length != 0;

                    if (hasLength)
                    {
                        string leading = FormatLeading(i, previousArrayCount);

                        sb.Append($"{leading}{indent}[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]\n");
                    }

                    sb.Append($"{indent}public {FormatTypeName(fieldType.Name)} {fieldName};\n");

                    if (i < fieldEnmerable.Count - 1 && hasLength)
                    {
                        sb.Append("\n");
                    }

                    previousArrayCount = i;

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
                    sb.Append($"{indent}public {FormatListName(fieldType.Name)}<{FormatTypeName($"{fieldType.GenericTypeArguments[0].Name}")}> {fieldName};\n");

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
                    sb.Append($"{indent}public {FormatPrimitiveType(fieldType.Name)} {fieldName};\n");
                }

                // Checks if the field is a type of Enumerator
                else if (fieldType.IsEnum)
                {
                    sb.Append($"{indent}public {fieldType.Name} {fieldName};\n");

                    structureTypes.TryAdd(fieldType, false);
                }

                // Checks if the field is a type of BitFlags
                else if (fieldType.GetInterface(typeof(IBitFlags).Name) != null)
                {
                    Type elementType = fieldType.GenericTypeArguments[0];

                    Type underlyingType = fieldInfo.Attribute.EnumType;

                    sb.Append($"{indent}public {elementType.Name} {fieldName};\n");

                    bitFlags.Add(elementType, underlyingType);
                    structureTypes.TryAdd(elementType, true);
                }

                // Checks if the field is a type of string
                else if (fieldType == typeof(string))
                {
                    bool hasLength = fieldInfo.Attribute.Length != 0;

                    if (hasLength)
                    {
                        string leading = FormatLeading(i, previousStringCount);

                        sb.Append($"{leading}{indent}[TagField(Length = 0x{fieldInfo.Attribute.Length.ToString("X")})]\n");
                    }

                    sb.Append($"{indent}public string {fieldName};\n");

                    if (i < fieldEnmerable.Count - 1 && hasLength)
                    {
                        sb.Append("\n");
                    }

                    previousStringCount = i;
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
                    if (fieldType.Name.StartsWith("GameObjectType"))
                    {
                        TagStructureInfo structureTypeInfo = TagStructure.GetTagStructureInfo(fieldType, Version, Platform);

                        foreach (TagFieldInfo structureFieldInfo in TagStructure.GetTagFieldEnumerable(structureTypeInfo))
                        {
                            sb.Append($"{indent}public {structureFieldInfo.FieldType.Name} {fieldName};\n");

                            structureTypes.TryAdd(structureFieldInfo.FieldType, false);
                        }
                    }
                    else
                    {
                        sb.Append($"{indent}public {fieldType.Name} {fieldName};\n");

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
                }

                // Parses the specified value if all other checks return false
                else
                {
                    if (fieldType.GetInterface(typeof(IBounds).Name) != null)
                    {
                        sb.Append($"{indent}public {FormatListName(fieldType.Name)}<{FormatTypeName($"{fieldType.GenericTypeArguments[0].Name}")}> {fieldName};\n");
                    }
                    else
                    {
                        sb.Append($"{indent}public {fieldType.Name} {fieldName};\n");
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

                        Type underlyingType = bitFlags[structureType.Key];

                        sb.Append($"\n{indent}[Flags]\n");
                        sb.Append($"{indent}public enum {structureType.Key.Name} : {FormatPrimitiveType(underlyingType.Name)}\n");
                        sb.Append($"{indent}{{\n");

                        if (enumTypeInfo.IsVersioned)
                        {
                            var enumMembers = enumTypeInfo.Members.VersionedMembers;

                            if (enumMembers.Count != 0)
                            {
                                sb.Append($"{indent}\tNone = 0,\n");

                                for (int i = 0; i < enumMembers.Count; i++)
                                {
                                    sb.Append($"{indent}\t{enumMembers[i].Name} = 1 << {i},\n");
                                }
                            }
                        }
                        else
                        {
                            var enumMembers = Enum.GetNames(structureType.Key);

                            if (enumMembers.Length != 0)
                            {
                                sb.Append($"{indent}\tNone = 0,\n");

                                for (int i = 0; i < enumMembers.Length; i++)
                                {
                                    sb.Append($"{indent}\t{enumMembers[i]} = 1 << {i},\n");
                                }
                            }
                        }

                        sb.Append($"{indent}}}\n");
                    }
                    else if (structureType.Key.IsDefined(typeof(FlagsAttribute), false))
                    {
                        Type underlyingType = Enum.GetUnderlyingType(structureType.Key);

                        sb.Append($"\n{indent}[Flags]\n");
                        sb.Append($"{indent}public enum {structureType.Key.Name} : {FormatPrimitiveType(underlyingType.Name)}\n");
                        sb.Append($"{indent}{{\n");

                        if (enumTypeInfo.IsVersioned)
                        {
                            var enumMembers = enumTypeInfo.Members.VersionedMembers;

                            if (enumMembers.Count != 0)
                            {
                                sb.Append($"{indent}\t{enumMembers[0].Name} = {Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[0].Name), underlyingType)},\n");

                                for (int i = 1; i < enumMembers.Count; i++)
                                {
                                    object memberValue = Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[i].Name), underlyingType);

                                    sb.Append($"{indent}\t{enumMembers[i].Name} = 1 << {ParseFlagsValue(memberValue)},\n");
                                }
                            }
                        }
                        else
                        {
                            var enumMembers = Enum.GetNames(structureType.Key);

                            if (enumMembers.Length != 0)
                            {
                                sb.Append($"{indent}\t{enumMembers[0]} = {Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[0]), underlyingType)},\n");

                                for (int i = 1; i < enumMembers.Length; i++)
                                {
                                    object memberValue = Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[i]), underlyingType);

                                    sb.Append($"{indent}\t{enumMembers[i]} = 1 << {ParseFlagsValue(memberValue)},\n");
                                }
                            }
                        }

                        sb.Append($"{indent}}}\n");
                    }
                    else
                    {
                        Type underlyingType = Enum.GetUnderlyingType(structureType.Key);

                        sb.Append($"\n{indent}public enum {structureType.Key.Name} : {FormatPrimitiveType(underlyingType.Name)}\n");
                        sb.Append($"{indent}{{\n");

                        if (enumTypeInfo.IsVersioned)
                        {
                            var enumMembers = enumTypeInfo.Members.VersionedMembers;

                            if (enumMembers.Count != 0)
                            {
                                sb.Append($"{indent}\t{enumMembers[0].Name} = {Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[0].Name), underlyingType)},\n");

                                for (int i = 1; i < enumMembers.Count; i++)
                                {
                                    sb.Append($"{indent}\t{enumMembers[i].Name},\n");
                                }
                            }
                        }
                        else
                        {
                            var enumMembers = Enum.GetNames(structureType.Key);

                            if (enumMembers.Length != 0)
                            {
                                sb.Append($"{indent}\t{enumMembers[0]} = {Convert.ChangeType(Enum.Parse(structureType.Key, enumMembers[0]), underlyingType)},\n");

                                for (int i = 1; i < enumMembers.Length; i++)
                                {
                                    sb.Append($"{indent}\t{enumMembers[i]},\n");
                                }
                            }
                        }

                        sb.Append($"{indent}}}\n");
                    }
                }
                else
                {
                    string version = GetTagDefinitionAttributeVersion(Build);

                    TagStructureInfo structureTypeInfo = structureType.Key != null ? TagStructure.GetTagStructureInfo(structureType.Key, Version, Platform) : null;

                    uint structureTypeSize = structureTypeInfo != null ? structureTypeInfo.TotalSize : 0;

                    sb.Append($"\n{indent}[TagStructure(Size = 0x{structureTypeSize.ToString("X")}{version})]\n");
                    sb.Append($"{indent}public class {structureType.Key.Name} : TagStructure\n");
                    sb.Append($"{indent}{{\n");

                    string structure = structureTypeInfo != null ? ParseTagStructure(structureTypeInfo, $"{indent}\t") : null;

                    if (structure != null)
                    {
                        sb.Append(structure);
                    }

                    sb.Append($"{indent}}}\n");
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

        private static bool IsPrimitiveArray(Type type)
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

        private static string FormatLeading(int currentIndex, int previousCount) 
        {
            return (currentIndex == 0) || (currentIndex == (previousCount + 1) && currentIndex != 1) ? "" : "\n";
        }

        private static string GetTagDefinitionAttributeVersion(ZeusVersion build)
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

        private static void GetTagDefinitionVersioning(ZeusVersion build, ref CacheVersion version, ref CachePlatform platform)
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
