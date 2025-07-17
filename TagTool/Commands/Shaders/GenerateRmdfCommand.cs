using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;
using TagTool.Shaders;

namespace TagTool.Commands.Shaders
{
    public class GenerateRmdfCommand : Command
    {
        GameCache Cache;

        public GenerateRmdfCommand(GameCache cache) :
            base(true,

                "GenerateRmdf",
                "Generates a render method definition tag according to the specified type.",

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

            if (!Enum.TryParse(typeof(HaloShaderGenerator.Globals.ShaderType), args[0], true, out var shaderTypeValue))
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[0]}\" is not a supported or valid shader type.");

            if (!bool.TryParse(args[1], out regenGlobals))
                return new TagToolError(CommandError.ArgInvalid, $"\"{args[1]}\" is not a valid boolean value.");

            if (args.Count > 2)
                if (!bool.TryParse(args[2], out applyFixes))
                    return new TagToolError(CommandError.ArgInvalid, $"\"{args[2]}\" is not a valid boolean value.");

            var shaderType = (HaloShaderGenerator.Globals.ShaderType)shaderTypeValue;

            var generator = TagTool.Shaders.ShaderGenerator.ShaderGenerator.GetGlobalShaderGenerator(shaderType);

            string rmdfName = $"shaders\\{shaderType.ToString().ToLowerInvariant()}";

            switch (shaderType)
            {
                case HaloShaderGenerator.Globals.ShaderType.LightVolume:
                    rmdfName = "shaders\\light_volume";
                    break;
                case HaloShaderGenerator.Globals.ShaderType.FurStencil:
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
