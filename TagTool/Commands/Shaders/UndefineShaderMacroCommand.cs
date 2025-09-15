using System;
using System.Collections.Generic;
using TagTool.Shaders.ShaderGenerator;

namespace TagTool.Commands.Shaders
{
    public class UndefineShaderMacroCommand : Command
    {
        public UndefineShaderMacroCommand() : base(true,
                "UndefineShaderMacro",
                "Utility command to undefine a global macro",
                "UndefineShaderMacro <name>")
        {
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 0)
                GlobalMacroList.RemoveUserMacro(args[0]);
            GlobalMacroList.GetUserMacros().ForEach(x => Console.WriteLine($"#define {x.Name} {x.Definition}"));
            return true;
        }
    }
}
