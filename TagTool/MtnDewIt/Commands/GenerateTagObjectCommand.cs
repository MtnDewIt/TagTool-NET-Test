using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TagTool.Cache;
using TagTool.Commands;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.MtnDewIt.Commands 
{
    public class GenerateTagObjectCommand : Command
    {
        private GameCache Cache;
        private CachedTag Tag;
        private TagStructureInfo Structure;
        private object Value;

        private string Layout;
        private bool IgnoreDefaultValues;

        public GenerateTagObjectCommand(GameCache cache) : base
        (
            false,
            "GenerateTagObject",
            "Generates a C# object based on the current tag",

            "GenerateTagObject <output file path> <tag_name> [IgnoreDefaultValues]",
            "Generates a C# object based on the current tag. This object will be formatted based on the specified tag's definition"
        )
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            IgnoreDefaultValues = false;

            Tag = Cache.TagCache.GetTag(args[1]);
            Structure = TagStructure.GetTagStructureInfo(Cache.TagCache.TagDefinitions.GetTagDefinitionType(Tag.Group), Cache.Version, Cache.Platform);

            using (var stream = Cache.OpenCacheRead()) 
            {
                Value = Cache.Deserialize(stream, Tag);
            }

            if (args.Count > 2 && string.Equals(args[2], "IgnoreDefaultValues", StringComparison.OrdinalIgnoreCase)) 
            {
                IgnoreDefaultValues = true;
            }

            Layout = GenerateLayout(Structure);

            FileInfo fileInfo = new FileInfo(args[0] + ".cs");

            using (FileStream fileStream = fileInfo.Create())
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(Layout);
                }
            }

            return true;
        }

        public string GenerateLayout(object structure)
        {
            var tagTypeName = Structure.Types[0].Name;
            var shortFormName = "!!!!";

            var layout = "";

            if (structure is TagStructureInfo tagStructureInfo)
            {
                shortFormName = tagStructureInfo.GroupTag.ToString();
            }

            layout = $"var tag = GetCachedTag<{tagTypeName}>($\"{Tag.Name}\");";
            layout += $"\nvar {shortFormName} = CacheContext.Deserialize<{tagTypeName}>(Stream, tag);";
            layout += FormatTagStructure(Structure, Value, $"{shortFormName}.", "", ";");

            return layout;
        }

        public string FormatTagStructure(TagStructureInfo structure, object value, string objectName, string indent, string terminator) 
        {
            var output = "";

            for (int j = 0; j < TagStructure.GetTagFieldEnumerable(structure).Count; j++) 
            {
                var tagFieldInfo = TagStructure.GetTagFieldEnumerable(structure)[j];

                var nameString = tagFieldInfo.Name;
                var fieldType = tagFieldInfo.FieldType;
                var fieldValue = tagFieldInfo.GetValue(value);

                if (tagFieldInfo.Attribute != null && tagFieldInfo.Attribute.Flags.HasFlag(TagFieldFlags.Padding) || (tagFieldInfo.Name.Contains("Unused") || tagFieldInfo.Name.Contains("unused") || tagFieldInfo.Name.Contains("Padding") || tagFieldInfo.Name.Contains("padding")))
                    continue;

                if (IgnoreDefaultValues) 
                {
                    if (IsDefaultValue(fieldValue))
                        continue;
                }

                // Checks if the field is a type of TagFunction, which in this case is just an object which contains a byte array
                if (fieldType == typeof(TagFunction))
                {
                    output += FormatTagFunction((TagFunction)fieldValue, nameString, objectName, indent, terminator);
                }

                // Checks if the field is a type of array which uses a primitive type, rather than objects or generics
                else if (ParseArray(fieldType))
                {
                    output += FormatPrimitiveArray(tagFieldInfo, (Array)fieldValue, nameString, objectName, indent, terminator);
                }

                // Checks if the field is a type of array which uses objects or generics
                else if (fieldType.IsArray)
                {
                    output += FormatGenericArray(tagFieldInfo, (Array)fieldValue, fieldValue, nameString, objectName, indent, terminator);
                }

                // Checks if the field is a type of list
                else if (fieldType.GetInterface(typeof(IList).Name) != null)
                {
                    output += FormatGenericList(fieldValue, fieldType, nameString, objectName, indent, terminator);
                }

                // Checks if the field is a type of Enumerator
                else if (fieldType.IsEnum)
                {
                    output += FormatEnumerator(fieldValue, fieldType, nameString, objectName, indent, terminator);
                }

                // Checks if the field is a type of object, and is not a generic, value or array type (basically anything that can't be parsed by the serializer). Also checks if it isn't a string or some other TagTool specific types
                else if (!fieldType.IsPrimitive && !fieldType.IsGenericType && !fieldType.IsValueType && !fieldType.IsArray && !(fieldType == typeof(PlatformUnsignedValue)) && !(fieldType == typeof(CachedTag)) && !(fieldType == typeof(string)) && fieldValue != null)
                {
                    output += FormatReferenceObject(fieldValue, nameString, objectName, indent, terminator);
                }

                // Parses the specified value if all other checks return false
                else
                {
                    output += $"\n{indent}{objectName}{nameString} = {FormatValue(fieldValue)}{terminator}";
                }
            }

            return output;
        }

        private bool ParseArray(Type type)
        {
            if (type.IsArray)
            {
                Type arrayType = type.GetElementType();

                return arrayType.IsPrimitive;
            }

            return false;
        }

        // Converts the type name for each type into the language keyword
        // Pulls the type and type name from one of the bounds values
        private string FormatPrimitiveType(string typeName) 
        {
            string name;

            switch (typeName)
            {
                case "Byte":
                    name = "byte";
                    break;
                case "SByte":
                    name = "sbyte";
                    break;
                case "UInt16":
                    name = "ushort";
                    break;
                case "Int16":
                    name = "short";
                    break;
                case "UInt32":
                    name = "uint";
                    break;
                case "Int32":
                    name = "int";
                    break;
                case "UInt64":
                    name = "ulong";
                    break;
                case "Int64":
                    name = "long";
                    break;
                case "Single":
                    name = "float";
                    break;
                default:
                    name = typeName;
                    break;
            }

            return name;
        }

        private string FormatValue(object value)
        {
            switch (value)
            {
                case null:
                    return "null";
                case string str:
                    return $"\"{str}\"";
                case float f:
                    return $"{f}f";
                case Angle angle:
                    return $"Angle.FromDegrees({angle.Degrees}f)";
                case RealEulerAngles2d angles2d:
                    return $"new RealEulerAngles2d(Angle.FromDegrees({angles2d.Yaw.Degrees}f), Angle.FromDegrees({angles2d.Pitch.Degrees}f))";
                case RealEulerAngles3d angles3d:
                    return $"new RealEulerAngles3d(Angle.FromDegrees({angles3d.Yaw.Degrees}f), Angle.FromDegrees({angles3d.Pitch.Degrees}f), Angle.FromDegrees({angles3d.Roll.Degrees}f))";
                case RealVector3d vector3d:
                    return $"new RealVector3d({vector3d.I}f, {vector3d.J}f, {vector3d.K}f)";
                case RealQuaternion quaternion:
                    return $"new RealQuaternion({quaternion.I}f, {quaternion.J}f, {quaternion.K}f, {quaternion.W}f)";
                case RealPoint3d point3d:
                    return $"new RealPoint3d({point3d.X}f, {point3d.Y}f, {point3d.Z}f)";
                case RealPoint2d point2d:
                    return $"new RealPoint2d({point2d.X}f, {point2d.Y}f)";
                case RealPlane3d plane3d:
                    return $"new RealPlane3d({plane3d.I}f, {plane3d.J}f, {plane3d.K}f, {plane3d.D}f)";
                case RealPlane2d plane2d:
                    return $"new RealPlane2d({plane2d.I}f, {plane2d.J}f, {plane2d.D}f)";
                case RealArgbColor realArgb:
                    return $"new RealArgbColor({realArgb.Alpha}f, {realArgb.Red}f, {realArgb.Green}f, {realArgb.Blue}f)";
                case ArgbColor argb:
                    return $"new ArgbColor({argb.Alpha}, {argb.Red}, {argb.Green}, {argb.Blue})";
                case RealRgbColor realRgb:
                    return $"new RealRgbColor({realRgb.Red}f, {realRgb.Green}f, {realRgb.Blue}f)";
                case RealRectangle3d realRect3d:
                    return $"new RealRectangle3d({realRect3d.X0}f, {realRect3d.X1}f, {realRect3d.Y0}f, {realRect3d.Y1}f, {realRect3d.Z0}f, {realRect3d.Z1}f)";
                case Rectangle2d rect2d:
                    return $"new Rectangle2d({rect2d.Top}, {rect2d.Left}, {rect2d.Bottom}, {rect2d.Right})";
                case RealMatrix4x3 realMatrix4x3:
                    return $"new RealMatrix4x3({realMatrix4x3.m11}f, {realMatrix4x3.m12}f, {realMatrix4x3.m13}f, {realMatrix4x3.m21}f, {realMatrix4x3.m22}f, {realMatrix4x3.m23}f, {realMatrix4x3.m31}f, {realMatrix4x3.m32}f, {realMatrix4x3.m33}f, {realMatrix4x3.m41}f, {realMatrix4x3.m42}f, {realMatrix4x3.m43}f)";
                case IBounds bounds:
                    return FormatBounds(bounds);
                case DatumHandle datumHandle:
                    return $"new DatumHandle({datumHandle.Salt}, {datumHandle.Index})";
                case StringId stringId:
                    return $"CacheContext.StringTable.GetStringId($@\"{Cache.StringTable.GetString(stringId)}\")";
                case CachedTag tag:
                    return $"GetCachedTag<{Cache.TagCache.TagDefinitions.GetTagDefinitionType(tag.Group).Name}>($@\"{tag.Name}\")";
                case PlatformUnsignedValue unsignedValue:
                    return $"new PlatformUnsignedValue({unsignedValue})";
                default:
                    return $"{value}";
            }
        }

        private string FormatBounds(IBounds bounds)
        {
            var lower = bounds.GetType().GetProperty("Lower").GetValue(bounds);
            var upper = bounds.GetType().GetProperty("Upper").GetValue(bounds);

            var typeName = FormatPrimitiveType(lower.GetType().Name);

            return $"new Bounds<{typeName}>({FormatValue(lower)}, {FormatValue(upper)})";
        }

        private string FormatTypeName(string typeString) 
        {
            string output;

            output = typeString.Substring(typeString.LastIndexOf('.') + 1);

            output = output.Replace('+', '.');

            return output;
        }

        private string FormatTagFunction(TagFunction function, string nameString, string objectName, string inputIndent, string terminator) 
        {
            string output;
            string internalIndent = "    ";

            output = $"\n{inputIndent}{objectName}{nameString} = new TagFunction";
            output += $"\n{inputIndent}{{";
            output += $"\n{inputIndent}{internalIndent}Data = new byte[]";
            output += $"\n{inputIndent}{internalIndent}{{";

            for (int i = 0; i < function.Data.Length; i++)
            {
                var datum = function.Data[i];

                var offset = 0;

                if (function.Data.Length <= 100) 
                {
                    offset = 10;
                }

                if (function.Data.Length > 100)
                {
                    offset = 20;
                }

                if (function.Data.Length > 1000) 
                {
                    offset = 30;
                }

                if (i >= 0 && i % offset == 0)
                {
                    output += $"\n{inputIndent}{internalIndent}{internalIndent}";
                }

                output += "0x" + datum.ToString("X2") + ",";

                output += " ";
            }

            output += $"\n{inputIndent}{internalIndent}}}";
            output += $"\n{inputIndent}}}{terminator}";

            return output;
        }
        
        private string FormatListName(string listName) 
        {
            string output;

            output = listName.Replace("`1", "");
        
            return output;
        }

        private string FormatPrimitiveList(IList list, Type type, string valueName, string objectName, string inputIndent, string terminator) 
        {
            string output;
            string internalIndent = "    ";

            output = $"\n{inputIndent}{objectName}{valueName} = new {FormatListName(type.Name)}<{FormatTypeName(list[0].GetType().Name)}>";
            output += $"\n{inputIndent}{{";

            for (int i = 0; i < list.Count; i++) 
            {
                object datum = list[i];

                var offset = 0;

                if (list.Count <= 100)
                {
                    offset = 10;
                }

                if (list.Count > 100)
                {
                    offset = 20;
                }

                if (list.Count > 1000)
                {
                    offset = 30;
                }

                if (i >= 0 && i % offset == 0)
                {
                    output += $"\n{inputIndent}{internalIndent}";
                }

                if (datum.GetType() == typeof(Byte))
                {
                    var byteValue = (byte)datum;
                    output += "0x" + byteValue.ToString("X2") + ",";
                }
                else 
                {
                    output += datum.ToString() + ",";
                }

                output += " ";
            }

            output += $"\n{inputIndent}}}{terminator}";

            return output;
        }

        private string FormatPrimitiveArray(TagFieldInfo tagFieldInfo, Array valueArray, string valueName, string objectName, string inputIndent, string terminator) 
        {
            string output = "";
            string internalIndent = "    ";
            string arraySize = "";

            if (tagFieldInfo.Attribute.Length != 0) 
            {
                arraySize = $"{tagFieldInfo.Attribute.Length}";
            }

            if (valueArray.Length == 0)
            {
                output += $"\n{inputIndent}{objectName}{valueName} = null{terminator}";
            }
            else
            {
                var valueType = valueArray.GetValue(0).GetType();

                output = $"\n{inputIndent}{objectName}{valueName} = new {FormatPrimitiveType(valueType.Name)}[{arraySize}]";
                output += $"\n{inputIndent}{{";

                if (IgnoreDefaultValues)
                {
                    if (ParsePrimitiveArray(valueArray))
                    {
                        return $"\n{inputIndent}{objectName}{valueName} = new {FormatPrimitiveType(valueType.Name)}[{arraySize}]{terminator}";
                    }
                }

                for (int i = 0; i < valueArray.Length; i++)
                {
                    object datum = valueArray.GetValue(i);

                    var offset = 0;

                    if (valueArray.Length <= 100)
                    {
                        offset = 10;
                    }

                    if (valueArray.Length > 100)
                    {
                        offset = 20;
                    }

                    if (valueArray.Length > 1000)
                    {
                        offset = 30;
                    }

                    if (i >= 0 && i % offset == 0)
                    {
                        output += $"\n{inputIndent}{internalIndent}";
                    }

                    if (valueType == typeof(Byte))
                    {
                        var byteValue = (byte)valueArray.GetValue(i);
                        output += "0x" + byteValue.ToString("X2") + ",";
                    }
                    else
                    {
                        output += datum.ToString() + ",";
                    }

                    output += " ";
                }

                output += $"\n{inputIndent}}}{terminator}";
            }

            return output;
        }

        private string FormatGenericList(object fieldValue, Type fieldType, string nameString, string objectName, string inputIndent, string terminator) 
        {
            string output = "";
            string internalIndent = "    ";

            if (fieldValue != null)
            {
                if (((IList)fieldValue).Count != 0)
                {
                    var valueType = (IList)fieldValue;

                    if (!valueType[0].GetType().IsPrimitive)
                    {
                        output += $"\n{inputIndent}{objectName}{nameString} = new {FormatListName(fieldType.Name)}<{FormatTypeName($"{fieldType.GenericTypeArguments[0]}")}>";
                        output += $"\n{inputIndent}{{";

                        for (int i = 0; i < ((IList)fieldValue).Count; i++)
                        {
                            output += $"\n{inputIndent}{internalIndent}new {FormatTypeName($"{fieldType.GenericTypeArguments[0]}")}";
                            output += $"\n{inputIndent}{internalIndent}{{";

                            var valueStructure = TagStructure.GetTagStructureInfo(valueType[i].GetType(), Cache.Version, Cache.Platform);
                            output += FormatTagStructure(valueStructure, valueType[i], "", $"{inputIndent}{internalIndent}" + "    ", ",");

                            output += $"\n{inputIndent}{internalIndent}}},";
                        }

                        output += $"\n{inputIndent}}}{terminator}";
                    }
                    else
                    {
                        output += FormatPrimitiveList((IList)fieldValue, fieldType, nameString, objectName, inputIndent, terminator);
                    }
                }
                else
                {
                    output += $"\n{inputIndent}{objectName}{nameString} = null{terminator}";
                }
            }
            else
            {
                output += $"\n{inputIndent}{objectName}{nameString} = null{terminator}";
            }

            return output;
        }
        
        private string FormatGenericArray(TagFieldInfo tagFieldInfo, Array valueArray, object fieldValue, string nameString, string objectName, string inputIndent, string terminator) 
        {
            string output = "";
            string internalIndent = "    ";
            string arraySize = "";

            if (tagFieldInfo.Attribute.Length != 0)
            {
                arraySize = $"{tagFieldInfo.Attribute.Length}";
            }

            if (valueArray == null || valueArray.Length == 0)
            {
                output += $"\n{inputIndent}{objectName}{nameString} = null{terminator}";
            }
            else
            {
                if (valueArray.Length != 0)
                {
                    output += $"\n{inputIndent}{objectName}{nameString} = new {FormatTypeName(fieldValue.ToString().Replace("[]", ""))}[{arraySize}]";
                    output += $"\n{inputIndent}{{";

                    for (var i = 0; i < valueArray.Length; i++)
                    {
                        output += $"\n{inputIndent}{internalIndent}new {FormatTypeName(fieldValue.ToString().Replace("[]", ""))}";
                        output += $"\n{inputIndent}{internalIndent}{{";

                        var valueStructure = TagStructure.GetTagStructureInfo(valueArray.GetValue(i).GetType(), Cache.Version, Cache.Platform);
                        output += FormatTagStructure(valueStructure, valueArray.GetValue(i), "", $"{inputIndent}{internalIndent}" + "    ", ",");

                        output += $"\n{inputIndent}{internalIndent}}}{terminator}";
                    }

                    output += $"\n{inputIndent}}}{terminator}";
                }
            }

            return output;
        }
        
        private string FormatReferenceObject(object fieldValue, string nameString, string objectName, string indent, string terminator) 
        {
            var output = "";

            var valueString = "new" + " " + FormatTypeName(fieldValue.ToString());

            output += $"\n{indent}{objectName}{nameString} = {valueString}";
            output += $"\n{indent}{{";

            var valueStructure = TagStructure.GetTagStructureInfo(fieldValue.GetType(), Cache.Version, Cache.Platform);

            output += FormatTagStructure(valueStructure, fieldValue, "", indent + "    ", ",");
            output += $"\n{indent}}}{terminator}";

            if (IgnoreDefaultValues) 
            {
                return ParseReferenceObject(output, nameString, valueString, objectName, indent, terminator);
            }

            return output;
        }

        private string FormatEnumerator(object fieldValue, Type fieldType, string nameString, string objectName, string inputIndent, string terminator) 
        {
            var output = "";

            if (fieldType.IsDefined(typeof(FlagsAttribute)))
            {
                var enumValues = (Enum)fieldValue;
                var enumType = enumValues.GetType();

                if (enumValues.ToString() != "None" && enumValues.ToString() != "0")
                {
                    var enumList = "";

                    output += $"\n{inputIndent}{objectName}{nameString} = ";

                    for (int i = 0; i < Enum.GetValues(enumType).Length; i++)
                    {
                        var enumValue = (Enum)Enum.GetValues(enumType).GetValue(i);

                        if (enumValues.HasFlag(enumValue) && enumValue.ToString() != "None")
                        {
                            if (!string.IsNullOrEmpty(enumList))
                            {
                                enumList += " | ";
                            }

                            enumList += $"{FormatTypeName(fieldType.ToString()) + "." + enumValue}";
                        }
                    }

                    output += $"{enumList}{terminator}";
                }
                else if (enumValues.ToString() == "0")
                {
                    output += $"\n{inputIndent}{objectName}{nameString} = 0{terminator}";
                }
                else
                {
                    output += $"\n{inputIndent}{objectName}{nameString} = {FormatTypeName(fieldType.ToString()) + "." + enumValues.ToString()}{terminator}";
                }
            }
            else
            {
                output += $"\n{inputIndent}{objectName}{nameString} = {FormatTypeName(fieldType.ToString()) + "." + fieldValue}{terminator}";
            }

            return output;
        }

        private string ParseReferenceObject(string input, string nameString, string valueString, string objectName, string indent, string terminator)
        {
            string output;

            if (input == $"\n{indent}{objectName}{nameString} = {valueString}" + $"\n{indent}{{" + $"\n{indent}}}{terminator}")
            {
                output = null;
            }
            else 
            {
                output = input;
            }

            return output;
        }

        private bool ParsePrimitiveArray(Array valueArray) 
        {
            bool result = true;

            for (int i = 0; i < valueArray.Length; i++) 
            {
                dynamic datum = Convert.ChangeType(valueArray.GetValue(i), Convert.GetTypeCode(valueArray.GetValue(i)));

                if (datum != (dynamic)Activator.CreateInstance(valueArray.GetValue(i).GetType()))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool IsDefaultValue(object fieldValue) 
        {
            var defaultValue = GetDefaultValueFromObject(fieldValue);

            if (fieldValue == null)
                return defaultValue == null;

            if (fieldValue is string s)
                return string.IsNullOrEmpty(s);

            if (fieldValue.GetType().GetInterface(typeof(IList).Name) != null) 
            {
                if (((IList)fieldValue).Count == 0) 
                {
                    return true;
                }
            }

            return fieldValue.Equals(defaultValue);
        }

        private object GetDefaultValueFromObject(object fieldValue) 
        {
            if (fieldValue == null)
                return null;

            if (fieldValue is StringId)
                return StringId.Invalid;

            return GetDefaultValueFromType(fieldValue.GetType());
        }

        private object GetDefaultValueFromType(Type fieldType)
        {
            if (fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(Nullable<>)) 
            {
                var valueProperty = fieldType.GetProperty("Value");
                fieldType = valueProperty.PropertyType;
            }

            if (fieldType.IsValueType)
            {
                return Activator.CreateInstance(fieldType);
            }
            else 
            {
                return null;
            }
        }
    }
}