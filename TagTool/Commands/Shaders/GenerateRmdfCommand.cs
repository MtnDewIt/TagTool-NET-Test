using HaloShaderGenerator.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Shaders
{
    public class GenerateRmdfCommand : Command
    {
        public GameCache Cache;

        public GenerateRmdfCommand(GameCache cache) :
            base(true,

                "GenerateRmdf",
                "Generates a render method definition tag according to the specified type.",

                "GenerateRmdf <Shader Type> [noglobals] [nofixes]",
                "Generates a render method definition tag according to the specified type.\n" + 
                "Use \"noglobals\" to prevent the global pixel and global vertex shader from being recompiled\n" +
                "By default, the global pixel and global vertex shaders will be recompiled, after the rmdf definition gets generated\n" +
                "Use \"nofixes\" to toggle the APPLY_FIXES macro off.\n" +
                "The default value for the APPLY_FIXES macro for each shader type supported by the generator is always set to true.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            bool regenGlobals = true;
            bool applyFixes = true;

            Stack<string> argStack = new Stack<string>(args.AsEnumerable().Reverse());

            if (args.Count < 1 || args.Count > 3)
                return new TagToolError(CommandError.ArgCount);

            if (!Enum.TryParse(argStack.Pop(), true, out ShaderType shaderType))
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\" is not a supported or valid shader type.");

            while (argStack.Count > 0) 
            {
                string arg = argStack.Peek();
                switch (arg.ToLower()) 
                {
                    case "noglobals":
                        argStack.Pop();
                        regenGlobals = false;
                        break;
                    case "nofixes":
                        argStack.Pop();
                        applyFixes = false;
                        break;
                    default:
                        return new TagToolError(CommandError.ArgInvalid, $"\"{arg}\" is not a valid input parameter");
                }
            }

            var generator = TagTool.Shaders.ShaderGenerator.ShaderGenerator.GetGlobalShaderGenerator(shaderType);

            string rmdfName = $"shaders\\{shaderType.ToString().ToLowerInvariant()}";

            switch (shaderType)
            {
                case ShaderType.LightVolume:
                    rmdfName = "shaders\\light_volume";
                    break;
                case ShaderType.FurStencil:
                    rmdfName = "shaders\\fur_stencil";
                    break;
            }
            
            if (!Cache.TagCache.TryGetTag<RenderMethodDefinition>(rmdfName, out CachedTag rmdfTag))
            {
                rmdfTag = Cache.TagCache.AllocateTag<RenderMethodDefinition>(rmdfName);
            }

            using (var stream = Cache.OpenCacheReadWrite())
            {
                var rmdf = TagTool.Shaders.ShaderGenerator.RenderMethodDefinitionGenerator.GenerateRenderMethodDefinition(Cache, stream, generator, shaderType, regenGlobals, applyFixes);
                Cache.Serialize(stream, rmdfTag, rmdf);
            }

            (Cache as GameCacheHaloOnlineBase).SaveTagNames();

            Console.WriteLine($"\"{rmdfName}\" generated successfully.");
            return true;
        }
    }
}
