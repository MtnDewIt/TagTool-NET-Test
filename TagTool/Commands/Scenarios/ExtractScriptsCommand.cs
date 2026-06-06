using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.IO;
using TagTool.Scripting;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Scenarios
{
    class ExtractScriptsCommand : Command
    {
        private GameCache Cache { get; }
        private CachedTag Tag { get; }
        private Scenario Definition { get; }

        public ExtractScriptsCommand(GameCache cache, CachedTag tag, Scenario definition)
            : base(true,

                  "ExtractScripts",
                  "Extracts scripts from the current scenario tag to a file.",

                  "ExtractScripts [Output Filename] [-script <name>]",

                  "Extracts scripts from the current scenario tag to a file.\n" +
                  "Use -script <name> to extract only a specific script and all scripts/globals it calls recursively.")
        {
            Cache = cache;
            Tag = tag;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            string scriptName = null;
            string outputPath = null;

            for (int i = 0; i < args.Count; i++)
            {
                if (args[i] == "-script")
                {
                    if (i + 1 >= args.Count)
                        return new TagToolError(CommandError.ArgInvalid, "Expected a script name after -script.");
                    scriptName = args[++i];
                }
                else
                {
                    outputPath = args[i];
                }
            }

            FileInfo scriptFile;
            string mapName = Tag.Name.Split('\\').Last();
            string fileName = $"_{Definition.MapId}_{mapName}.hsc";

            if (outputPath != null)
            {
                scriptFile = new FileInfo(outputPath);
            }
            else
            {
                if (Cache.Version == CacheVersion.HaloOnlineED)
                    scriptFile = new FileInfo($"haloscript\\ED" + fileName);
                else
                    scriptFile = new FileInfo($"haloscript\\{Cache.Version}" + fileName);
            }

            System.IO.Directory.CreateDirectory("haloscript");
            using (var scriptFileStream = scriptFile.Create())
            using (var scriptWriter = new StreamWriter(scriptFileStream))
            {
                var decompiler = new ScriptDecompiler(Cache, Definition);
                decompiler.DecompileScripts(scriptWriter, scriptName);
            }

            Console.WriteLine($"\nDecompiled script extracted to \"{scriptFile.FullName}\"");

            return true;
        }
    }
}