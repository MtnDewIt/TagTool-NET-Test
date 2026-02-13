using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Tags
{
    public class TagStructureDiffer
    {
        private readonly GameCache _cache1;
        private readonly GameCache _cache2;

        public bool IgnoreData { get; set; }
        public bool SameCountOnly { get; set; }
        public bool ConvertFunctions { get; set; } = true;

        public TagStructureDiffer(GameCache cache1, GameCache cache2)
        {
            _cache1 = cache1;
            _cache2 = cache2;
        }

        public List<Difference> Diff(object data1, object data2)
        {
            List<Difference> differences = [];
            DiffData(data1.GetType(), data1, data2, differences);
            return differences;
        }

        private void DiffData(Type type, object data1, object data2, List<Difference> differences, string path = "")
        {
            if (data1 == data2)
                return;

            if (data1 == null && data2 != null || data2 == null && data1 != null)
            {
                differences.Add(new Difference(DifferenceKind.Value, path, data1, data2));
                return;
            }

            if (type.IsPrimitive)
            {
                if (typeof(float).IsAssignableFrom(type))
                {
                    if (Math.Abs((float)data1 - (float)data2) >= 0.00001f)
                        differences.Add(new Difference(DifferenceKind.Value, path, data1, data2));
                }
                else if (typeof(double).IsAssignableFrom(type))
                {
                    if (Math.Abs((double)data1 - (double)data2) >= 0.0000001)
                        differences.Add(new Difference(DifferenceKind.Value, path, data1, data2));
                }
                else
                {
                    if (!data1.Equals(data2))
                        differences.Add(new Difference(DifferenceKind.Value, path, data1, data2));
                }
            }
            else
            {
                if (typeof(TagStructure).IsAssignableFrom(type))
                {
                    var struct1 = (TagStructure)data1;
                    var struct2 = (TagStructure)data2;
                    var fields1 = struct1.GetTagFieldEnumerable(_cache1.Version, _cache1.Platform);
                    var fields2 = struct2.GetTagFieldEnumerable(_cache2.Version, _cache2.Platform);
                    var commonFields = fields1.Join(fields2, a => a.Name, b => b.Name, (a, b) => (a, b));

                    if (typeof(TagFunction).IsAssignableFrom(type))
                    {
                        if (_cache1.Endianness != _cache2.Endianness && ConvertFunctions)
                        {
                            TagFunction.ConvertTagFunction(_cache1.Endianness, (TagFunction)struct1);
                            TagFunction.ConvertTagFunction(_cache2.Endianness, (TagFunction)struct2);
                        }
                    }

                    foreach (var (field1, field2) in commonFields)
                    {
                        var value1 = field1.GetValue(struct1);
                        var value2 = field2.GetValue(struct2);
                        DiffData(field1.FieldType, value1, value2, differences, path.Length == 0 ? field1.Name : $"{path}.{field1.Name}");
                    }
                }
                else if (typeof(IList).IsAssignableFrom(type))
                {
                    var list1 = (IList)data1;
                    var list2 = (IList)data2;
                    int elementCount = list1.Count;
                    bool isData = type == typeof(byte[]);

                    if (list1.Count != list2.Count)
                    {
                        differences.Add(new Difference(DifferenceKind.ElementCount, path, list1, list2));
                        if (SameCountOnly || isData)
                            return;
                        else if (list2.Count < list1.Count)
                            elementCount = list2.Count;
                    }

                    if (IgnoreData && isData)
                        return;

                    Type elementType = type.IsArray ? type.GetElementType() : type.GetGenericArguments().First();
                    for (int i = 0; i < elementCount; i++)
                        DiffData(elementType, list1[i], list2[i], differences, $"{path}[{i}]");
                }
                else if (typeof(CachedTag).IsAssignableFrom(type))
                {
                    var tag1 = (CachedTag)data1;
                    var tag2 = (CachedTag)data2;
                    if (tag1.Group.Tag != tag2.Group.Tag || tag1.Name != tag2.Name)
                        differences.Add(new Difference(DifferenceKind.Value, path, data1, data2));
                }
                else if (typeof(StringId).IsAssignableFrom(type))
                {
                    var string1 = _cache1.StringTable.GetString((StringId)data1);
                    var string2 = _cache2.StringTable.GetString((StringId)data2);
                    if (string1 != string2)
                        differences.Add(new Difference(DifferenceKind.Value, path, string1, string2));
                }
                else if (typeof(IComparable).IsAssignableFrom(type))
                {
                    var comparable1 = (IComparable)data1;
                    var comparable2 = (IComparable)data2;
                    if (comparable1.CompareTo(comparable2) != 0)
                        differences.Add(new Difference(DifferenceKind.Value, path, data1, data2));
                }
                else
                {
                    var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    foreach (var field in properties.Where(x => x.CanRead && x.CanWrite))
                    {
                        var value1 = field.GetValue(data1);
                        var value2 = field.GetValue(data2);
                        DiffData(field.PropertyType, value1, value2, differences, path.Length == 0 ? field.Name : $"{path}.{field.Name}");
                    }

                    var fields = type.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    foreach (var field in fields)
                    {
                        var value1 = field.GetValue(data1);
                        var value2 = field.GetValue(data2);
                        DiffData(field.FieldType, value1, value2, differences, path.Length == 0 ? field.Name : $"{path}.{field.Name}");
                    }
                }
            }
        }

        public enum DifferenceKind
        {
            Value,
            ElementCount,
        }

        public readonly record struct Difference(DifferenceKind Kind, string Path, object Value1, object Value2)
        {
            public override string ToString()
            {
                return $"({Kind}) {Path} {Value1} <=> {Value2}";
            }
        }
    }
}