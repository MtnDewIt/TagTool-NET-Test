using System.Collections.Generic;
using System.IO;

namespace TagTool.Commands.Common
{
    class RunCommands : Command
    {
        private CommandContextStack ContextStack;

        public RunCommands(CommandContextStack contextStack)
            : base(true,

                  "RunCommands",
                  "Run commands from a file.",

                  "RunCommands <file> [print]",

                  "Run commands from a file.")
        {
            ContextStack = contextStack;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count < 1)
                return new TagToolError(CommandError.ArgCount);

            bool shouldPrint = (args.Count >= 2 && args[1].ToLower() == "print");

            string fileName = args[0];
            if (!File.Exists(fileName))
                return new TagToolError(CommandError.FileNotFound, fileName);

            var commandRunner = new CommandRunner(ContextStack);
            return commandRunner.RunCommandScript(fileName, shouldPrint);
        }
    }
}
