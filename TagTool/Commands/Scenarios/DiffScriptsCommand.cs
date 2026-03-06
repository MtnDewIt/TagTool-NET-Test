using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using TagTool.Scripting;

namespace TagTool.Commands.Scenarios
{
    class DiffScriptsCommand : Command
    {
        private GameCache Cache { get; }
        private Scenario Definition { get; }
        private bool OmitData { get; set; }
        private bool OnlyDiffs { get; set; }

        public DiffScriptsCommand(GameCache cache, Scenario definition) :
            base(true,
                "DiffScripts",
                "Diff script expression blocks between this scenario and another.",

                "DiffScripts <other_tag> [script_name|script_index|start_index-end_index] [omit_data] [only_diffs]",

                "Compares script expression blocks between the current scenario and another.\n" +
                "Prints a decompiled representation of each script and highlights differences in:\n" +
                "  Opcode, ValueType, Flags, Data (skipped for Real due to precision).\n\n" +
                "Script selection (optional):\n" +
                "  <name>          - single script by name\n" +
                "  <index>         - single script by index\n" +
                "  <start>-<end>   - inclusive range of script indexes\n" +
                "  (omit)          - all scripts (matched by name)")
        {
            Cache = cache;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1)
                return new TagToolError(CommandError.ArgCount);

            // --- Load other scenario ---
            if (!Cache.TagCache.TryGetTag(args[0], out var otherTagInstance) || otherTagInstance == null)
                return new TagToolError(CommandError.TagInvalid, $"Could not find tag '{args[0]}'.");

            Scenario other;
            using (var stream = Cache.OpenCacheRead())
                other = Cache.Deserialize<Scenario>(stream, otherTagInstance);

            // Parse remaining args: optional flags and optional script selector
            OmitData = false;
            OnlyDiffs = false;
            string selector = null;

            for (int i = 1; i < args.Count; i++)
            {
                switch (args[i])
                {
                    case "omit_data":   OmitData = true;   break;
                    case "only_diffs":  OnlyDiffs = true;  break;
                    default:
                        if (selector != null)
                            return new TagToolError(CommandError.ArgInvalid, $"Unexpected argument '{args[i]}'.");
                        selector = args[i];
                        break;
                }
            }

            // --- Resolve which scripts to compare ---
            // Returns list of (thisIndex, otherIndex) pairs matched by name
            var pairs = ResolveScriptPairs(Definition, other, selector);
            if (pairs == null)
                return false;

            if (pairs.Count == 0)
            {
                Console.WriteLine("No matching scripts found.");
                return true;
            }

            // --- Decompile both scenarios to string maps keyed by script name ---
            var thisDecomp  = DecompileToScriptMap(Cache, Definition);
            var otherDecomp = DecompileToScriptMap(Cache, other);

            // --- Diff each pair ---
            foreach (var (thisIdx, otherIdx) in pairs)
            {
                var thisScript  = Definition.Scripts[thisIdx];
                var otherScript = other.Scripts[otherIdx];

                // Collect expression ranges and diff first
                var thisExprs  = CollectScriptExpressions(Definition, thisIdx);
                var otherExprs = CollectScriptExpressions(other, otherIdx);

                int maxCount = Math.Max(thisExprs.Count, otherExprs.Count);
                bool anyDiff = false;
                var diffLines = new List<Action>(); // deferred print

                for (int i = 0; i < maxCount; i++)
                {
                    bool hasThis  = i < thisExprs.Count;
                    bool hasOther = i < otherExprs.Count;

                    if (hasThis  && IsPaddingBlock(thisExprs[i]))  continue;
                    if (hasOther && IsPaddingBlock(otherExprs[i])) continue;

                    if (!hasThis)
                    {
                        anyDiff = true;
                        int ci = i;
                        diffLines.Add(() => { WriteColored($"  [{ci}] ONLY IN OTHER: {FormatExpr(otherExprs[ci])}", ConsoleColor.Red); Console.WriteLine(); });
                        continue;
                    }

                    if (!hasOther)
                    {
                        anyDiff = true;
                        int ci = i;
                        diffLines.Add(() => { WriteColored($"  [{ci}] ONLY IN THIS: {FormatExpr(thisExprs[ci])}", ConsoleColor.Red); Console.WriteLine(); });
                        continue;
                    }

                    var t = thisExprs[i];
                    var o = otherExprs[i];
                    var diffs = GetExprDiffs(t, o);
                    if (diffs.Count == 0)
                        continue;

                    anyDiff = true;
                    int fi = i;
                    var td = t; var od = o; var fd = diffs;
                    diffLines.Add(() =>
                    {
                        Console.Write($"  [{fi}]  THIS:  ");
                        PrintExprWithDiffs(td, fd, ConsoleColor.Green);
                        Console.WriteLine();
                        Console.Write($"  [{fi}] OTHER:  ");
                        PrintExprWithDiffs(od, fd, ConsoleColor.Red);
                        Console.WriteLine();
                    });
                }

                // Only print anything if there were differences (or OnlyDiffs not set)
                if (OnlyDiffs && !anyDiff)
                    continue;

                Console.WriteLine();
                WriteColored($"=== Script: {thisScript.ScriptName} ===", ConsoleColor.Cyan);
                Console.WriteLine();

                WriteColored("-- This --", ConsoleColor.Yellow);
                Console.WriteLine();
                if (thisDecomp.TryGetValue(thisScript.ScriptName, out var thisText))
                    Console.WriteLine(thisText);

                WriteColored("-- Other --", ConsoleColor.Yellow);
                Console.WriteLine();
                if (otherDecomp.TryGetValue(otherScript.ScriptName, out var otherText))
                    Console.WriteLine(otherText);

                WriteColored("-- Expression Diff --", ConsoleColor.Yellow);
                Console.WriteLine();

                foreach (var line in diffLines)
                    line();

                if (!anyDiff)
                {
                    WriteColored("  (no differences)", ConsoleColor.Green);
                    Console.WriteLine();
                }
            }

            return true;
        }

        // -------------------------------------------------------------------
        // Script pair resolution
        // -------------------------------------------------------------------

        private List<(int thisIdx, int otherIdx)> ResolveScriptPairs(Scenario a, Scenario b, string selector)
        {
            var result = new List<(int, int)>();

            IEnumerable<int> thisIndexes;

            if (selector == null)
            {
                // All scripts matched by name
                thisIndexes = Enumerable.Range(0, a.Scripts.Count);
            }
            else if (selector.Contains('-') && !selector.StartsWith("-"))
            {
                // Range: start-end
                var parts = selector.Split('-');
                if (!int.TryParse(parts[0], out int start) || !int.TryParse(parts[1], out int end))
                {
                    Console.WriteLine($"Invalid range '{selector}'.");
                    return null;
                }
                thisIndexes = Enumerable.Range(start, end - start + 1);
            }
            else if (int.TryParse(selector, out int singleIdx))
            {
                thisIndexes = new[] { singleIdx };
            }
            else
            {
                // Name
                int idx = a.Scripts.FindIndex(s => s.ScriptName == selector);
                if (idx == -1)
                {
                    Console.WriteLine($"Script '{selector}' not found in this scenario.");
                    return null;
                }
                thisIndexes = new[] { idx };
            }

            foreach (int ti in thisIndexes)
            {
                if (ti < 0 || ti >= a.Scripts.Count)
                {
                    Console.WriteLine($"Script index {ti} out of range.");
                    continue;
                }

                var name = a.Scripts[ti].ScriptName;
                int oi = b.Scripts.FindIndex(s => s.ScriptName == name);

                if (oi == -1)
                {
                    WriteColored($"Script '{name}' not found in other scenario — skipping.", ConsoleColor.DarkYellow);
                    Console.WriteLine();
                    continue;
                }

                result.Add((ti, oi));
            }

            return result;
        }

        // -------------------------------------------------------------------
        // Expression collection — walks from script root
        // -------------------------------------------------------------------

        private List<HsSyntaxNode> CollectScriptExpressions(Scenario scnr, int scriptIndex)
        {
            var result = new List<HsSyntaxNode>();
            var script = scnr.Scripts[scriptIndex];
            int root = script.RootExpressionHandle.Index;

            // Find the lower bound: the highest root index that is still below our root,
            // i.e. the previous script/global's root. Used as a fallback when no padding exists.
            int lowerBound = 0;
            foreach (var s in scnr.Scripts)
            {
                int ri = s.RootExpressionHandle.Index;
                if (ri < root && ri > lowerBound)
                    lowerBound = ri;
            }
            foreach (var g in scnr.Globals)
            {
                int gi = g.InitializationExpressionHandle.Index;
                if (gi < root && gi > lowerBound)
                    lowerBound = gi;
            }

            // Expressions are compiled in reverse — body first at lower indexes,
            // root wrapper last at the highest index. Walk backwards from root,
            // stopping at padding (Bungie emits 5 padding blocks before each script)
            // or at the lower bound if no padding is present.
            for (int i = root; i > lowerBound; i--)
            {
                var expr = scnr.ScriptExpressions[i];
                if (IsPaddingBlock(expr))
                    break;
                result.Add(expr);
            }

            // Reverse so index 0 = first body expression, last = root wrapper
            result.Reverse();
            return result;
        }

        // -------------------------------------------------------------------
        // Diff logic
        // -------------------------------------------------------------------

        private static readonly string[] DiffFields = { "Opcode", "ValueType", "Flags", "Data" };

        private List<string> GetExprDiffs(HsSyntaxNode a, HsSyntaxNode b)
        {
            var diffs = new List<string>();

            if (a.Opcode    != b.Opcode)    diffs.Add("Opcode");
            if (a.ValueType != b.ValueType) diffs.Add("ValueType");
            if (a.Flags     != b.Flags)     diffs.Add("Flags");

            // Skip data diff when omit_data is set, or for Real to avoid float precision noise
            if (!OmitData && a.ValueType != HsType.Real && b.ValueType != HsType.Real)
                if (!a.Data.SequenceEqual(b.Data))
                    diffs.Add("Data");

            return diffs;
        }

        private void PrintExprWithDiffs(HsSyntaxNode expr, List<string> diffFields, ConsoleColor highlightColor)
        {
            PrintField("Opcode",    $"0x{expr.Opcode:X3}",           diffFields, highlightColor);
            Console.Write("  ");
            PrintField("ValueType", expr.ValueType.ToString(),        diffFields, highlightColor);
            Console.Write("  ");
            PrintField("Flags",     expr.Flags.ToString(),            diffFields, highlightColor);
            if (!OmitData)
            {
                Console.Write("  ");
                PrintField("Data",  BitConverter.ToString(expr.Data), diffFields, highlightColor);
            }
        }

        private void PrintField(string fieldName, string value, List<string> diffFields, ConsoleColor highlightColor)
        {
            bool isDiff = diffFields.Contains(fieldName);
            if (isDiff) Console.ForegroundColor = highlightColor;
            Console.Write($"{fieldName}={value}");
            if (isDiff) Console.ResetColor();
        }

        private static bool IsPaddingBlock(HsSyntaxNode expr) =>
            expr.Opcode == 0xBABA &&
            expr.ValueType == HsType.Invalid &&
            expr.Data.All(b => b == 0xBA);

        private string FormatExpr(HsSyntaxNode expr) =>
            $"Opcode=0x{expr.Opcode:X3}  ValueType={expr.ValueType}  Flags={expr.Flags}  Data={BitConverter.ToString(expr.Data)}";

        // -------------------------------------------------------------------
        // Decompile to per-script text map
        // -------------------------------------------------------------------

        private static Dictionary<string, string> DecompileToScriptMap(GameCache cache, Scenario scnr)
        {
            var result = new Dictionary<string, string>(StringComparer.Ordinal);

            // Decompile the whole scenario to a string then split by script header
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                var decompiler = new ScriptDecompiler(cache, scnr);
                decompiler.DecompileScripts(sw);
            }

            // Split into per-script blocks by scanning for "(script " lines
            var lines = sb.ToString().Split('\n');
            string currentName = null;
            var currentLines = new List<string>();

            foreach (var rawLine in lines)
            {
                var line = rawLine.TrimEnd('\r');

                if (line.TrimStart().StartsWith("(script "))
                {
                    // Flush previous
                    if (currentName != null)
                        result[currentName] = string.Join("\n", currentLines);

                    currentName = null;
                    currentLines = new List<string> { line };

                    // Extract script name from the declaration
                    // format: (script <type> <rettype> <name> ...
                    var tokens = line.TrimStart('(', ' ').Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    // tokens[0]=script tokens[1]=type tokens[2]=rettype tokens[3]=name or (name
                    if (tokens.Length >= 4)
                    {
                        var namePart = tokens[3].TrimStart('(');
                        currentName = namePart;
                    }
                }
                else if (currentName != null)
                {
                    currentLines.Add(line);

                    // A lone ')' at indent 0 closes the script block
                    if (line == ")")
                    {
                        result[currentName] = string.Join("\n", currentLines);
                        currentName = null;
                        currentLines = new List<string>();
                    }
                }
            }

            if (currentName != null && currentLines.Count > 0)
                result[currentName] = string.Join("\n", currentLines);

            return result;
        }

        // -------------------------------------------------------------------
        // Helpers
        // -------------------------------------------------------------------

        private static void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
