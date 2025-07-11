using System;
using System.Collections;
using System.IO;
using System.Linq;
using TagTool.Cache.HaloOnline;
using TagTool.Scripting;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Cache.Utils
{
    public static class TagReplacer
    {
        /// <summary>
        /// Replaces all references to <paramref name="tag"/> with <paramref name="replacementTag"/>
        /// </summary>
        public static void ReplaceTag(GameCacheHaloOnlineBase cache, Stream cacheStream, CachedTag tag, CachedTag replacementTag)
        {
            CachedTag[] dependentTags = cache.TagCache
                .NonNull()
                .Cast<CachedTagHaloOnline>()
                .Where(x => x.Dependencies.Contains(tag.Index))
                .ToArray();

            if (dependentTags.Length == 0)
            {
                Console.WriteLine($"No references to '{tag}' were found!");
                return;
            }

            for (int i = 0; i < dependentTags.Length; i++)
            {
                CachedTag dependentTag = dependentTags[i];
                Console.WriteLine($"{dependentTag}");

                object definition = cache.Deserialize(cacheStream, dependentTag);
                definition = ReplaceTagReferences(cache, definition, tag, replacementTag);
                cache.Serialize(cacheStream, dependentTag, definition);

                if (i < dependentTags.Length - 1)
                    Console.WriteLine();
            }
        }

        private static object ReplaceTagReferences(GameCacheHaloOnlineBase cache, object data, CachedTag tag, CachedTag replacementTag, string path = "")
        {
            switch (data)
            {
                case null:
                case byte[] _:
                    break;
                case CachedTag tagRef:
                    if (tagRef == tag)
                    {
                        Console.WriteLine($"  {path} = {replacementTag?.ToString() ?? "null"}");
                        return replacementTag;
                    }
                    break;
                case IList collection:
                    for (int i = 0; i < collection.Count; i++)
                    {
                        collection[i] = ReplaceTagReferences(cache, collection[i], tag, replacementTag, $"{path}[{i}]");
                    }
                    break;
                case TagStructure tagStruct:
                    {
                        foreach (var field in tagStruct.GetTagFieldEnumerable(cache.Version, cache.Platform))
                        {
                            string fieldPath = path == "" ? field.Name : $"{path}.{field.Name}";
                            object fieldValue = field.GetValue(tagStruct);
                            fieldValue = ReplaceTagReferences(cache, fieldValue, tag, replacementTag, fieldPath);
                            field.SetValue(tagStruct, fieldValue);
                        }

                        if (tagStruct is Scenario scenario)
                            data = ReplaceScriptTagReferences(scenario, tag, replacementTag);
                    }
                    break;

            }
            return data;
        }

        private static Scenario ReplaceScriptTagReferences(Scenario scenario, CachedTag tag, CachedTag replacementTag)
        {
            foreach (HsSyntaxNode node in scenario.ScriptExpressions)
            {
                if (node.Flags.HasFlag(HsSyntaxNodeFlags.Primitive)
                    && node.ValueType.HaloOnline >= HsType.HaloOnlineValue.Sound
                    && node.ValueType.HaloOnline <= HsType.HaloOnlineValue.AnyTagNotResolving)
                {
                    int srcTagIndex = BitConverter.ToInt32(node.Data, 0);
                    if (srcTagIndex == tag.Index)
                    {
                        int exprIndex = scenario.ScriptExpressions.IndexOf(node);
                        Console.WriteLine($"  ScriptExpressions[{exprIndex}].Data = {replacementTag?.ToString() ?? "null"}");
                        node.Data = BitConverter.GetBytes(replacementTag?.Index ?? -1);
                    }
                }
            }
            return scenario;
        }
    }
}
