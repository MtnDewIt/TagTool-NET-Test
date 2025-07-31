using HaloShaderGenerator.Globals;
using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.Shaders
{
    public class GenerateRmdfCommand : Command
    {
        GameCache Cache;

        public GenerateRmdfCommand(GameCache cache) :
            base(true,

                "GenerateRmdf",
                "Generates a render method definition tag according to the specified type.",

                // TODO: Update this to use actual variable names instead of boolean inputs
                // TODO: Maybe also use an input stack, and just track which inputs are included,
                // rather than forcing the user to provide inputs for each parameter.
                "GenerateRmdf <Shader Type> <Regenerate Global Shaders> [Apply Fixes]",
                "Generates a render method definition tag according to the specified type.")
        {
            Cache = cache;
        }

        public override object Execute(List<string> args)
        {
            bool regenGlobals = false;
            bool applyFixes = true;

            if (args.Count > 3)
                return new TagToolError(CommandError.ArgCount);

            if (!Enum.TryParse(args[0], true, out ShaderType shaderType))
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\" is not a supported or valid shader type.");

            if (!bool.TryParse(args[1], out regenGlobals))
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[1]}\" is not a valid boolean value.");

            if (args.Count > 2)
                if (!bool.TryParse(args[2], out applyFixes))
                    return new TagToolError(CommandError.ArgInvalid, $"\"{args[2]}\" is not a valid boolean value.");

            // TODO: Update global shader generator table
            var generator = TagTool.Shaders.ShaderGenerator.ShaderGenerator.GetGlobalShaderGenerator(shaderType);

            string rmdfName = $"shaders\\{shaderType.ToString().ToLowerInvariant()}";

            // TODO: Update shader generator
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
                // TODO: Update render method definition generator
                var rmdf = TagTool.Shaders.ShaderGenerator.RenderMethodDefinitionGenerator.GenerateRenderMethodDefinition(Cache, stream, generator, shaderType, regenGlobals, applyFixes);
                Cache.Serialize(stream, rmdfTag, rmdf);
            }

            (Cache as GameCacheHaloOnlineBase).SaveTagNames();

            Console.WriteLine($"\"{rmdfName}\" generated successfully.");
            return true;
        }
    }
}
