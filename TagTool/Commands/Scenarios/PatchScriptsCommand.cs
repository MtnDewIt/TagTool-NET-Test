using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Scripting;
using TagTool.Tags.Definitions;
using static TagTool.Scripting.ScriptPatcher;

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

                "Performs string-level and S-expression substitutions on an uncompiled script\n" +
                "file to make it compatible with this version of the game. Optionally accepts an\n" +
                "integer flags value to enable or disable specific substitution groups.\n\n" +
                "S-expression rules support:\n" +
                "  - Total replacement:  (oldFunc $1 $2) -> (print \"removed\")\n" +
                "  - Prepending/wrapping: (oldFunc $1 $2) -> (newFunc (oldFunc $1 $2))\n" +
                "  - Parameter manipulation: (oldFunc $1 $2) -> (newFunc $1)  (drop $2)\n" +
                "  - Swapping: (oldFunc $1 $2) -> (newFunc $2 $1)\n" +
                "  - Variadic: (oldFunc $1 $*) -> (newFunc $1 $*)")
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

            int flags = 0;
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

        // --- Simple string-level patches (backward compatible) ---
        // Each entry: (requiredFlags, pattern, replacement)
        // For simple identifiers, uses word-boundary matching.
        // For block patterns, does literal string replace.

        private static readonly (int flags, string pattern, string replacement)[] StringPatches =
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

        // --- S-expression patches ---
        // Each entry: (requiredFlags, pattern, replacement)
        // Pattern uses $1, $2, ... to capture arguments, $* for remaining args.
        // Replacement uses captured values with the same $N syntax.

        private static readonly (int flags, string pattern, string replacement)[] SExprPatches =
        [
            // Example: total replacement
            // (1, "(old_function $1 $2)", "(print \"removed\")"),

            // Example: wrap/prepend
            // (1, "(cinematic_object_get_unit $1)", "(unit (cinematic_object_get $1))"),

            // Example: keep first arg, drop second
            // (1, "(old_function $1 $2)", "(new_function $1)"),

            // Example: swap args
            // (1, "(old_function $1 $2)", "(new_function $2 $1)"),

            // Example: add arg
            // (1, "(old_function $1 $2)", "(new_function $1 $2 0)"),

            // h3 -> odst change
            (1, "(unit_limit_lipsync_to_mouth_only (cinematic_object_get $1) $*)",
                "(unit_limit_lipsync_to_mouth_only (unit (cinematic_object_get $1)) $*)"),
            
            (1, "(unit_set_emotion_by_name (cinematic_object_get $1) $*)",
                "(unit_set_emotion_by_name (unit (cinematic_object_get $1)) $*)"),

            // odst -> ms23 change
            (0, "(pda_is_active_deterministic $*)",
                "false"),

            (0, "(chud_display_pda_objectives_message $1 $*)",
                "(print $1)"),

            (0, "(chud_display_pda_minimap_message $1 $*)",
                "(print $1)"),

            (0, "(player_close_pda $*)",
                "(print \"player close pda\")"),

            (0, "(pda_stop_arg_sound $*)",
                "(print \"pda stop arg sound\")"),

            (0, "(pda_set_footprint_dead_zone $*)",
                "(print \"pda set footprint dead zone\")"),

            (0, "(player_add_footprint $*)",
                "(print \"player add footprint\")"),

            (0, "(pda_input_enable $*)",
                "(print \"pda input enable\")"),

            (0, "(pda_input_enable_a $*)",
                "(print \"pda input enable a\")"),

            (0, "(pda_input_enable_x $*)",
                "(print \"pda input enable x\")"),

            (0, "(pda_input_enable_y $*)",
                "(print \"pda input enable y\")"),

            (0, "(pda_input_enable_dpad $*)",
                "(print \"pda input enable dpad\")"),

            (0, "(pda_set_active_pda_definition $1)",
                "(print $1)"),

            (0, "(player_set_fourth_wall_enabled $*)",
                "(print \"player set fourth wall enabled\")"),

            (0, "(chud_show_ai_navpoint $*)",
                "(print \"chud show ai navpoint\")"),
        ];          

        private static string ApplyPatches(string source, int flags)
        {
            // Phase 1: Simple string-level patches
            foreach (var (patchFlags, pattern, replacement) in StringPatches)
            {
                if (patchFlags != 0 && (flags & patchFlags) == 0)
                    continue;

                if (IsIdentifier(pattern))
                    source = ReplaceIdentifier(source, pattern, replacement);
                else
                    source = source.Replace(pattern, replacement);
            }

            // Phase 2: S-expression patches
            var patcher = new ScriptPatcher();
            foreach (var (patchFlags, pattern, replacement) in SExprPatches)
            {
                if (patchFlags != 0 && (flags & patchFlags) == 0)
                    continue;
                patcher.AddRule(patchFlags, pattern, replacement);
            }
            source = patcher.Apply(source, flags);

            return source;
        }

        private static string ReplaceIdentifier(string source, string name, string replacement)
        {
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
