using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Tags;

namespace TagTool.Commands.Tags
{
    class DiffTagCommand : Command
    {
        private GameCache Cache1 { get; }
        private GameCache Cache2 { get; }

        public DiffTagCommand(GameCache cache1, GameCache cache2)
            : base(true,
                   "DiffTag",
                   "Deep compares two tags and lists their differences.",

                   "DiffTag [simple] <tag> [other tag]",

                   "Deep compares two tags and lists their differences. Use the \"simple\" argument to list only the difference count.\n" +
                   "In a porting context, you can specify only one tag name to compare between caches.")
        {
            Cache1 = cache1;
            Cache2 = cache2;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1)
                return new TagToolError(CommandError.ArgCount);

            bool simple = false;
            bool ignoreData = false;

            if (args[0].ToLower() == "simple")
            {
                simple = true;
                args.RemoveAt(0);

                if (args.Count < 1)
                    return new TagToolError(CommandError.ArgCount);
            }

            if (ignoreData = args[0].ToLower() == "ignore_data")
                args.RemoveAt(0);

            if (!Cache1.TagCache.TryGetCachedTag(args[0], out CachedTag tag1))
                return new TagToolError(CommandError.TagInvalid, $"\"{args[0]}\"");

            string tag2name = args[0];
            if (args.Count > 1)
                tag2name = args[1];

            if (!Cache2.TagCache.TryGetCachedTag(tag2name, out CachedTag tag2))
                return new TagToolError(CommandError.TagInvalid, $"\"{tag2name}\"");

            List<TagStructureDiffer.Difference> differences;
            var differ = new TagStructureDiffer(Cache1, Cache2)
            {
                IgnoreData = ignoreData
            };

            using var stream1 = Cache1.OpenCacheRead();
            using var stream2 = Cache2.OpenCacheRead();
            {
                var definition1 = (TagStructure)Cache1.Deserialize(stream1, tag1);
                var definition2 = (TagStructure)Cache2.Deserialize(stream2, tag2);
                differences = differ.Diff(definition1, definition2);
            }

            if (!simple)
            {
                Console.WriteLine($"\n{differences.Count} differences:\n");

                foreach (var diff in differences)
                {
                    var value1 = diff.Value1 ?? "null";
                    var value2 = diff.Value2 ?? "null";

                    if (diff.Kind == TagStructureDiffer.DifferenceKind.ElementCount)
                        Console.WriteLine($"{diff.Path}.Count {Ansi.BrightBlue}{((IList)diff.Value1).Count}{Ansi.Reset} | {Ansi.BrightRed}{((IList)diff.Value2).Count}{Ansi.Reset}");
                    else
                        Console.WriteLine($"{diff.Path} {Ansi.BrightBlue}{value1}{Ansi.Reset} | {Ansi.BrightRed}{value2}{Ansi.Reset}");
                }
            }
            else
            {
                Console.WriteLine($"\n{differences.Count} differences.");
            }

            return true;
        }
    }
}
