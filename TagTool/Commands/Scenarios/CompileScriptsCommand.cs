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

                "CompileScripts <input_file> [append]",

                "Compiles HaloScript from a file and writes it to the scenario.\n" +
                "Use append to add to the existing scripts instead of replacing them.\n" +
                "When appending, the new file can freely call any script or global\n" +
                "already present in the scenario without re-declaring them.")
        {
            Cache = cache;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1 || args.Count > 2)
                return new TagToolError(CommandError.ArgCount);

            bool append = false;
            string filePath;

            filePath = args[0];

            if (args.Count == 2)
            {
                if (args[1] != "append")
                    return new TagToolError(CommandError.ArgInvalid, $"Unknown flag '{args[1]}'. Did you mean append?");

                append = true;
            }

            var srcFile = new FileInfo(filePath);

            if (!srcFile.Exists)
                return new TagToolError(CommandError.FileNotFound, $"\"{filePath}\"");

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

            Console.WriteLine(append ? "Done. Scripts appended." : "Done.");
            return true;
        }
    }
}
