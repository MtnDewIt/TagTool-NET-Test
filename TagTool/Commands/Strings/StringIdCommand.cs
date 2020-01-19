﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TagTool.Cache;
using TagTool.Common;

namespace TagTool.Commands.Strings
{
    class StringIdCommand : Command
    {
        private GameCache Cache { get; }

        public StringIdCommand(GameCache cache) : base(
            true,

            "StringId",
            "Add, look up, or find stringID values",

            "StringId Add <string>\n" +
            "StringId Get <id>\n" +
            "StringId List [filter]",

            "\"StringId Add\" will add a new stringID.\n" +
            "\"StringId Get\" will display the string corresponding to an ID value.\n" +
            "\"StringId List\" will list stringIDs, optionally filtering them.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count == 0)
                return false;

            switch (args[0].ToLower())
            {
                case "add":
                    return ExecuteAdd(args);

                case "get":
                    return ExecuteGet(args);

                case "getset":
                    return ExecuteGetSet(args);

                case "list":
                    return ExecuteList(args);
            }

            return false;
        }

        private bool ExecuteAdd(List<string> args)
        {
            if (args.Count != 2)
                return false;

            var str = args[1];

            if (Cache.StringTable.Contains(str))
                return false;

            var id = Cache.StringTable.AddString(str);

            Cache.SaveStrings();
            
            Console.WriteLine("Added string \"{0}\" as {1}.", str, id);

            return true;
        }

        private bool ExecuteGet(List<string> args)
        {
            if (args.Count != 2)
                return false;

            if (!uint.TryParse(args[1], NumberStyles.HexNumber, null, out uint stringId))
                return false;

            var str = Cache.StringTable.GetString(new StringId(stringId));

            if (str != null)
                Console.WriteLine(str);
            else
                Console.Error.WriteLine("Unable to find a string with ID 0x{0:X}.", stringId);

            return true;
        }

        private bool ExecuteGetSet(List<string> args)
        {
            if (args.Count != 1)
                return false;
            
            var setStrings = new Dictionary<int, List<StringId>>();

            for (var i = 0; i < Cache.StringTable.Count; i++)
            {
                if (Cache.StringTable[i] == null)
                    continue;
                
                var id = Cache.StringTable.GetStringId(i);
                var set = Cache.StringTable.Resolver.GetSet(id);
                if (!setStrings.ContainsKey(set))
                    setStrings[set] = new List<StringId>();

                setStrings[set].Add(id);
            }

            foreach (var entry in setStrings)
            {
                Console.WriteLine($"Set 0x{entry.Key:X}");
                Console.WriteLine("============================");
                Console.WriteLine();

                foreach (var id in entry.Value)
                {
                    var set = Cache.StringTable.Resolver.GetSet(id);
                    var index = Cache.StringTable.Resolver.GetIndex(id);
                    Console.WriteLine($"{Cache.StringTable.GetString(id)} - 0x{id.Value:X} (set 0x{set:X}, index 0x{index:X})");
                }
                    

                Console.WriteLine();
            }

            return true;
        }

        private bool ExecuteList(List<string> args)
        {
            if (args.Count > 2)
                return false;

            var filter = (args.Count == 2) ? args[1] : null;
            var strings = new List<FoundStringID>();

            for (var i = 0; i < Cache.StringTable.Count; i++)
            {
                if (Cache.StringTable[i] == null)
                    continue;

                if (filter != null && !Cache.StringTable[i].Contains(filter))
                    continue;

                var id = Cache.StringTable.GetStringId(i);

                strings.Add(new FoundStringID
                {
                    ID = id,
                    Display = id.ToString(),
                    Value = Cache.StringTable[i]
                });
            }

            if (strings.Count == 0)
            {
                Console.Error.WriteLine("No strings found.");
                return true;
            }

            strings.Sort((a, b) => a.ID.CompareTo(b.ID));

            var idWidth = strings.Max(s => s.Display.Length);
            var formatStr = string.Format("{{0,-{0}}}  {{1}}", idWidth);

            foreach (var str in strings)
                Console.WriteLine(formatStr, str.Display, str.Value);

            return true;
        }

        private class FoundStringID
        {
            public StringId ID { get; set; }
            public string Display { get; set; }
            public string Value { get; set; }
        }
    }
}
