using System;
using System.Collections.Generic;
using TagTool.Common.Logging;

namespace TagTool.Commands.Common
{
    public class SetLogLevelCommand : Command
    {
        public SetLogLevelCommand()
            : base(true,

                  "LogLevel",
                  "Sets the current log level",

                  "LogLevel <Debug|Info|Warning|Error>",

                  "")
        {
        }

        public override object Execute(List<string> args)
        {
            if (args.Count == 0)
            {
                Console.WriteLine($"Current Log Level: {Log.Level}");
                return true;
            }

            if (!Enum.TryParse(args[0], ignoreCase: true, out LogLevel level) || !Enum.IsDefined(level))
                return new TagToolError(CommandError.ArgInvalid, args[0]);

            Log.Level = level;

            return true;
        }
    }
}
