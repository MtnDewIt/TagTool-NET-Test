using System;
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
                return false;

            bool shouldPrint = (args.Count >= 2 && args[1].ToLower() == "print");

            using (TextReader reader = File.OpenText(args[0]))
            {
                TextReader oldStdIn = Console.In;
                Console.SetIn(reader);

                var commandRunner = new CommandRunner(ContextStack);
                try
                {
                    for (string line; (line = reader.ReadLine()) != null && !commandRunner.EOF;)
                        commandRunner.RunCommand(line, shouldPrint);
                }
                finally
                {
                    Console.SetIn(oldStdIn);
                }
            }

            return true;
        }
    }
}
