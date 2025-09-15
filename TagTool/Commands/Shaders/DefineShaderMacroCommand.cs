using System;
using System.Collections.Generic;
using TagTool.Shaders.ShaderGenerator;

namespace TagTool.Commands.Shaders
{
    public class DefineShaderMacroCommand : Command
    {
        public DefineShaderMacroCommand() : base(true,
                "DefineShaderMacro",
                "Utility command to define a global macro used during shader compilation",
                "DefineShaderMacro <name> <definition>")
        {
        }

        public override object Execute(List<string> args)
        {
            if (args.Count > 0)
                GlobalMacroList.AddUserMacro(args[0], args.Count > 1 ? string.Join(' ', args[1..]) : "1");
            GlobalMacroList.GetUserMacros().ForEach(x => Console.WriteLine($"#define {x.Name} {x.Definition}"));
            return true;
        }
    }
}
