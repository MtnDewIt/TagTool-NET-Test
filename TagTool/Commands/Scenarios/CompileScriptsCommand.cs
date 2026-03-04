using System;
using System.Collections.Generic;
using System.IO;
using TagTool.Cache;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using TagTool.Scripting;
using TagTool.Scripting.Compiler;

namespace TagTool.Commands.Scenarios
{
    class CompileScriptsCommand : Command
    {
        private GameCache Cache { get; }
        private Scenario Definition { get; }

        public CompileScriptsCommand(GameCache cache, Scenario definition) :
            base(true,

                "CompileScripts",
                "Compile scripts from a file. (still may have a few issues)",

                "CompileScripts <input_file> [append] [adjust_indexes]",

                "Compiles HaloScript from a file and writes it to the scenario.\n" +
                "Use append to add to the existing scripts instead of replacing them.\n" +
                "When appending, the new file can freely call any script or global\n" +
                "already present in the scenario without re-declaring them.\n" +
                "Use adjust_indexes to fix up script indexes in squad and objective\n" +
                "blocks after compilation (use when scripts are added or removed).")
        {
            Cache = cache;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1 || args.Count > 3)
                return new TagToolError(CommandError.ArgCount);

            bool append = false;
            bool adjustIndexes = false;

            string filePath = args[0];

            for (int i = 1; i < args.Count; i++)
            {
                switch (args[i])
                {
                    case "append":         append = true;        break;
                    case "adjust_indexes": adjustIndexes = true; break;
                    default:
                        return new TagToolError(CommandError.ArgInvalid, $"Unknown flag '{args[i]}'.");
                }
            }

            var srcFile = new FileInfo(filePath);
            if (!srcFile.Exists)
                return new TagToolError(CommandError.FileNotFound, $"\"{filePath}\"");

            // Before compiling, snapshot script name -> old index so we can remap later.
            Dictionary<string, int> oldIndexByName = null;
            if (adjustIndexes)
                oldIndexByName = BuildScriptNameMap(Definition);

            var scriptCompiler = new ScriptCompiler(Cache, Definition);

            try
            {
                if (append)
                    scriptCompiler.AppendCompileFile(srcFile);
                else
                    scriptCompiler.CompileFile(srcFile);
            }
            catch (ScriptCompilerException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Script compile error: {e.Message}");
                Console.ResetColor();
                return false;
            }
            catch (Exception e)
            {
                return new TagToolError(CommandError.OperationFailed, $"Unexpected compiler error: {e.Message}");
            }

            if (adjustIndexes)
            {
                var newIndexByName = BuildScriptNameMap(Definition);
                AdjustScriptIndexes(Definition, oldIndexByName, newIndexByName);
                Console.WriteLine("Script indexes adjusted.");
            }

            Console.WriteLine(append ? "Done. Scripts appended." : "Done.");
            return true;
        }

        // Builds a name -> index map from the scenario's current Scripts list.
        private static Dictionary<string, int> BuildScriptNameMap(Scenario definition)
        {
            var map = new Dictionary<string, int>(StringComparer.Ordinal);
            for (int i = 0; i < definition.Scripts.Count; i++)
                map[definition.Scripts[i].ScriptName] = i;
            return map;
        }

        // Remaps a single script index field using the old and new name->index maps.
        // If the index was -1 (none) or out of range, it is left unchanged.
        private static short Remap(short oldIndex, IReadOnlyList<HsScript> oldScripts,
            Dictionary<string, int> newIndexByName)
        {
            if (oldIndex < 0 || oldIndex >= oldScripts.Count)
                return oldIndex;

            string name = oldScripts[oldIndex].ScriptName;
            return newIndexByName.TryGetValue(name, out int newIdx) ? (short)newIdx : oldIndex;
        }

        private static void AdjustScriptIndexes(Scenario definition,
            Dictionary<string, int> oldIndexByName,
            Dictionary<string, int> newIndexByName)
        {
            // Reconstruct the old scripts list by index so we can look up names.
            // We use the name map we captured before compilation; build a lookup list
            // from it for O(1) index -> name -> new index.
            var oldScripts = definition.Scripts; // post-compile list (same names, new indexes)

            // Build old index -> name from the pre-compile snapshot.
            // Since we only stored name->index we invert it here.
            var oldNameByIndex = new Dictionary<int, string>();
            foreach (var kv in oldIndexByName)
                oldNameByIndex[kv.Value] = kv.Key;

            // Helper that remaps using the pre/post name snapshots.
            short RemapIndex(short oldIndex)
            {
                if (oldIndex < 0 || !oldNameByIndex.TryGetValue(oldIndex, out string name))
                    return oldIndex;
                return newIndexByName.TryGetValue(name, out int newIdx) ? (short)newIdx : oldIndex;
            }

            // --- Squads ---
            if (definition.Squads != null)
            {
                foreach (var squad in definition.Squads)
                {
                    // Fireteams (H3 style, MaxVersion Halo3Retail)
                    if (squad.Fireteams != null)
                        foreach (var ft in squad.Fireteams)
                            ft.CommandScriptIndex = RemapIndex(ft.CommandScriptIndex);

                    // Designer fireteams (ODST+)
                    if (squad.DesignerFireteams != null)
                        foreach (var ft in squad.DesignerFireteams)
                            ft.CommandScriptIndex = RemapIndex(ft.CommandScriptIndex);

                    // Templated fireteams (ODST+)
                    if (squad.TemplatedFireteams != null)
                        foreach (var ft in squad.TemplatedFireteams)
                            ft.CommandScriptIndex = RemapIndex(ft.CommandScriptIndex);

                    // Spawn formations (ODST+)
                    if (squad.SpawnFormations != null)
                        foreach (var sf in squad.SpawnFormations)
                            sf.PlacementScriptIndex = RemapIndex(sf.PlacementScriptIndex);

                    // Spawn points (ODST+)
                    if (squad.SpawnPoints != null)
                        foreach (var sp in squad.SpawnPoints)
                            sp.PlacementScriptIndex = RemapIndex(sp.PlacementScriptIndex);
                }
            }

            // --- AI Objectives -> Tasks ---
            if (definition.AiObjectives != null)
            {
                foreach (var objective in definition.AiObjectives)
                {
                    if (objective.Tasks == null)
                        continue;

                    foreach (var task in objective.Tasks)
                    {
                        task.EntryScriptIndex      = RemapIndex(task.EntryScriptIndex);
                        task.CommandScriptIndex    = RemapIndex(task.CommandScriptIndex);
                        task.ExhaustionScriptIndex = RemapIndex(task.ExhaustionScriptIndex);
                        task.ScriptIndex           = RemapIndex(task.ScriptIndex);
                    }
                }
            }
        }
    }
}

