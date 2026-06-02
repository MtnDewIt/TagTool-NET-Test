using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Unicode
{
    class RemoveStringCommand : Command
    {
        private enum RemovalFlags
        {
            None,
            UseAsSubstring,
        }

        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private MultilingualUnicodeStringList Definition { get; set; }
        private RemovalFlags Flags { get; set; }

        public RemoveStringCommand(GameCache cache, CachedTag tag, MultilingualUnicodeStringList definition) :
            base(false,
                
                "RemoveString",
                "Removes a string entry from the multilingual_unicode_string_list definition.",
                
                "RemoveString <StringID> [Flags]",

                "Removes a string entry from the multilingual_unicode_string_list definition.\n" +
                "\nAvailable Flags:\n" +
                "\n - UseAsSubstring: Instead of a string id string, you can specify a substring to compare against.")
        {
            Cache = cache;
            Tag = tag;
            Definition = definition;
            Flags = RemovalFlags.None;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            if (args.Count > 1) 
            {
                if (Enum.TryParse(args[1], out RemovalFlags flags))
                {
                    Flags = flags;
                }
                else 
                {
                    return new TagToolError(CommandError.ArgInvalid, "Invalid Removal Flags");
                }
            }

            StringId value = StringId.Empty;

            if (Flags != RemovalFlags.UseAsSubstring)
            {
                value = Cache.StringTable.GetStringId(args[0]);
            }

            var newDefinition = new MultilingualUnicodeStringList
            {
                Data = [],
                Strings = []
            };

            foreach (var oldString in Definition.Strings)
            {
                if (Flags == RemovalFlags.UseAsSubstring)
                {
                    if (oldString.StringIDStr.Contains(args[0], StringComparison.OrdinalIgnoreCase))
                        continue;
                }
                else 
                {
                    if (oldString.StringID == value)
                        continue;
                }

                var newString = new LocalizedString
                {
                    Offsets = [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1],
                    StringID = oldString.StringID,
                    StringIDStr = oldString.StringIDStr
                };

                for (var i = 0; i < 12; i++)
                {
                    if (oldString.Offsets[i] == -1)
                        continue;

                    newDefinition.SetString(newString, (GameLanguage)i, Definition.GetString(oldString, (GameLanguage)i));
                }

                newDefinition.Strings.Add(newString);
            }

            Definition.Data = newDefinition.Data;
            Definition.Strings = newDefinition.Strings;

            return true;
        }
    }
}