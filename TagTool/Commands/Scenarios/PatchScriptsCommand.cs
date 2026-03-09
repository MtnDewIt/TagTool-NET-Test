using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Scenarios
{
    class PatchScriptsCommand : Command
    {
        private GameCache Cache { get; }
        private Scenario Definition { get; }

        public PatchScriptsCommand(GameCache cache, Scenario definition) :
            base(true,

                "PatchScripts",
                "Patch a script file by substituting function names for compatibility.",

                "PatchScripts <input_file> <output_file> [flags]",

                "Performs string-level substitutions on an uncompiled script file to make it\n" +
                "compatible with this version of the game. Optionally accepts an integer flags\n" +
                "value to enable or disable specific substitution groups.")
        {
            Cache = cache;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 2 || args.Count > 3)
                return new TagToolError(CommandError.ArgCount);

            string inputPath = args[0];
            string outputPath = args[1];

            int flags = ~0; // all flags set by default
            if (args.Count == 3)
            {
                if (!int.TryParse(args[2], out flags))
                    return new TagToolError(CommandError.ArgInvalid, $"Flags must be an integer, got '{args[2]}'.");
            }

            var inputFile = new FileInfo(inputPath);
            if (!inputFile.Exists)
                return new TagToolError(CommandError.FileNotFound, $"\"{inputPath}\"");

            string source = File.ReadAllText(inputPath);
            string patched = ApplyPatches(source, flags);
            File.WriteAllText(outputPath, patched, new UTF8Encoding(false));

            Console.WriteLine($"Done. Patched script written to \"{outputPath}\".");
            return true;
        }

        // Each entry: (requiredFlags, pattern, replacement)
        //   requiredFlags - bitmask checked against the flags arg; 0 means always apply
        //   pattern       - the exact function name (or multi-line block) to find
        //   replacement   - what to replace it with
        //
        // For simple one-to-one function renames, pattern and replacement are just the names.
        // For block substitutions, write them out in full including parens/whitespace.
        //
        // Simple rename example:
        //   (0, "old_function_name", "new_function_name"),
        //
        // Block substitution example:
        //   (0, "(old_function_x)", "(new_function_x)\n    (new_function_y)"),
        private static readonly (int flags, string pattern, string replacement)[] Patches =
        [
            // h3 -> ed (odst) change
            (1, "cinematic_scripting_start_animation",
                "cinematic_scripting_start_animation_legacy"),

            (1, "cinematic_scripting_create_object",
                "cinematic_scripting_create_object_legacy"),

            (1, "cinematic_scripting_create_and_animate_object",
                "cinematic_scripting_create_and_animate_object_legacy"),

            (1, "cinematic_scripting_create_and_animate_object_no_animation",
                "cinematic_scripting_create_and_animate_object_no_animation_legacy"),

            (1, "cinematic_scripting_create_and_animate_cinematic_object",
                "cinematic_scripting_create_and_animate_cinematic_object_legacy"),

            (1, "cinematic_scripting_destroy_object",
                "cinematic_scripting_destroy_object_legacy"),

            // h3 -> odst change
            (1, "cinematic_object_get_unit",
                "cinematic_object_get"),

            (1, "cinematic_object_get_scenery",
                "cinematic_object_get"),

            (1, "cinematic_object_get_effect_scenery",
                "cinematic_object_get"),

            // h3 -> odst change
            (1, "vehicle_test_seat_list",
                "vehicle_test_seat_unit_list"),

            (1, "vehicle_test_seat",
                "vehicle_test_seat_unit"),

            // h3 -> ed (odst) change
            (4, "vehicle_test_seat_list",
                "vehicle_test_seat_list_legacy"),

            (4, "vehicle_test_seat",
                "vehicle_test_seat_legacy"),

            // h3/osdt -> ms23 change (match porting code for now)
            (0, "player_action_test_cinematic_skip",
                "player_action_test_jump"),

            (0, "player_action_test_start",
                "player_action_test_jump"),

        ];

        private static string ApplyPatches(string source, int flags)
        {
            foreach (var (patchFlags, pattern, replacement) in Patches)
            {
                // skip if the required flags aren't set (0 means always apply)
                if (patchFlags != 0 && (flags & patchFlags) == 0)
                    continue;

                // For simple identifiers (no parens/newlines in the pattern), use a
                // word-boundary match so we don't clip substrings of longer names.
                // For block patterns, do a literal string replace.
                if (IsIdentifier(pattern))
                    source = ReplaceIdentifier(source, pattern, replacement);
                else
                    source = source.Replace(pattern, replacement);
            }

            return source;
        }

        // Replaces whole identifier occurrences only - won't match if the name is
        // immediately preceded or followed by another identifier character.
        private static string ReplaceIdentifier(string source, string name, string replacement)
        {
            // Identifier chars: letters, digits, underscore
            var sb = new StringBuilder(source.Length);
            int i = 0;
            while (i < source.Length)
            {
                if (source[i] == name[0] && source.Length - i >= name.Length &&
                    source.Substring(i, name.Length) == name)
                {
                    bool prevOk = i == 0 || !IsIdentifierChar(source[i - 1]);
                    bool nextOk = i + name.Length == source.Length || !IsIdentifierChar(source[i + name.Length]);

                    if (prevOk && nextOk)
                    {
                        sb.Append(replacement);
                        i += name.Length;
                        continue;
                    }
                }

                sb.Append(source[i++]);
            }

            return sb.ToString();
        }

        private static bool IsIdentifier(string s)
        {
            foreach (char c in s)
                if (!IsIdentifierChar(c)) return false;
            return s.Length > 0;
        }

        private static bool IsIdentifierChar(char c) =>
            char.IsLetterOrDigit(c) || c == '_';
    }
}
