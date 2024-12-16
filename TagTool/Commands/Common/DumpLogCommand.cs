﻿using System;
using System.Collections.Generic;
using TagTool.IO;

namespace TagTool.Commands.Common
{
    class DumpLogCommand : Command
    {
        public DumpLogCommand()
            : base(true,

                  "DumpLog",
                  "Dumps the current log into the logs directory.",

                  "DumpLog [name = hott_*_crash.log]",

                  "Dumps the current log into the logs directory.\n" +
                  "If a path is specified, the current log will be dumped into the file hott_*_crash.log\n" +
                  "If a path is specified with a file, the current log will be dumped into the file specified")
        {
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 1)
                return new TagToolError(CommandError.ArgCount);

            string path = args.Count == 0 ? null : args[0];
            var result = ConsoleHistory.Dump(path);

            Console.WriteLine("Successfully dumped log to '{0}'.", result);

            return true;
        }
    }
}
