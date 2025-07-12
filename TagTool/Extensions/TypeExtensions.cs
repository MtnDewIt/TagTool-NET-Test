using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Tags;

namespace System
{
    public static class TypeExtensions
    {
        private static Dictionary<string, Tag> TypeGroupTags { get; } = new Dictionary<string, Tag>();

        public static Tag GetGroupTag(this Type type, CacheVersion version = CacheVersion.Unknown)
        {
            if (TypeGroupTags.ContainsKey(type.FullName))
                return TypeGroupTags[type.FullName];

            var attr = type.GetCustomAttributes(typeof(TagStructureAttribute), false)
                .Cast<TagStructureAttribute>()
                .FirstOrDefault(a => version == CacheVersion.Unknown || CacheVersionDetection.IsBetween(version, a.MinVersion, a.MaxVersion));

            if (attr == null)
                throw new NotSupportedException(type.FullName);

            return TypeGroupTags[type.FullName] = new Tag(attr.Tag);
        }

        private static Dictionary<string, uint> TypeSizes { get; } = new Dictionary<string, uint>();

        public static uint GetSize(this Type type, CacheVersion version = CacheVersion.Unknown)
        {
            if (TypeSizes.ContainsKey(type.FullName))
                return TypeSizes[type.FullName];

            var attr = type.GetCustomAttributes(typeof(TagStructureAttribute), false)
                .Cast<TagStructureAttribute>()
                .FirstOrDefault(a => version == CacheVersion.Unknown || CacheVersionDetection.IsBetween(version, a.MinVersion, a.MaxVersion));

            if (attr == null)
                throw new NotSupportedException(type.FullName);

            return TypeSizes[type.FullName] = attr.Size;
        }

        public static string GetFriendlyTypeName(this Type type)
        {
            if (type == null) return "null";

            // Handle common types directly
            if (type == typeof(int)) return "int";
            if (type == typeof(string)) return "string";
            if (type == typeof(bool)) return "bool";
            if (type == typeof(double)) return "double";
            if (type == typeof(decimal)) return "decimal";
            if (type == typeof(float)) return "float";
            if (type == typeof(long)) return "long";
            if (type == typeof(short)) return "short";
            if (type == typeof(byte)) return "byte";
            if (type == typeof(char)) return "char";
            if (type == typeof(object)) return "object";

            // Handle generic types
            if (type.IsGenericType)
            {
                // Get the generic type name without the `n suffix
                string name = type.Name.Substring(0, type.Name.IndexOf('`'));
                // Get the generic type arguments and recursively get their friendly names
                var genericArgs = type.GetGenericArguments()
                    .Select(t => t.GetFriendlyTypeName())
                    .Aggregate((a, b) => $"{a}, {b}");
                return $"{name}<{genericArgs}>";
            }

            // Handle array types
            if (type.IsArray)
            {
                return $"{type.GetElementType().GetFriendlyTypeName()}[]";
            }

            // Handle nested types
            if (type.IsNested)
            {
                return $"{type.DeclaringType.GetFriendlyTypeName()}.{type.Name}";
            }

            // Default case: return the type name
            return type.Name;
        }
    }
}