using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.RenderMethods
{
    public class FixHologramCommand : Command
    {
        private GameCache Cache;
        private CachedTag Tag;
        private RenderMethod RenderMethod;

        public FixHologramCommand(GameCache cache, CachedTag tag, RenderMethod renderMethod)
            : base(true,
                  "FixHologram",
                  "Updates the shader template and options to set the 9th index to 1.",
                  "FixHologram",
                  "Synchronizes options with the RMT2 template and adjusts the 9th option.")
        {
            Cache = cache;
            Tag = tag;
            RenderMethod = renderMethod;
        }

        public override object Execute(List<string> args)
        {
            using (var stream = Cache.OpenCacheReadWrite())
            {
                // Validate shader properties and template
                if (RenderMethod.ShaderProperties.Count == 0 ||
                    RenderMethod.ShaderProperties[0].Template == null)
                    return new TagToolError(CommandError.TagInvalid, "Shader template is missing.");

                // Get current RMT2 template
                var currentRmt2Tag = RenderMethod.ShaderProperties[0].Template;
                if (currentRmt2Tag == null || currentRmt2Tag.Index == -1)
                    return new TagToolError(CommandError.TagInvalid, "Invalid RMT2 template reference.");

                // Parse options from RMT2 template name (e.g., "_0_1_0_1...")
                var rmt2Name = currentRmt2Tag.Name;
                var optionsPart = rmt2Name.Split('\\').Last().TrimStart('_');
                var optionStrings = optionsPart.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                List<byte> currentOptions = new List<byte>();
                foreach (var optStr in optionStrings)
                {
                    if (byte.TryParse(optStr, out byte opt))
                        currentOptions.Add(opt);
                    else
                        return new TagToolError(CommandError.OperationFailed, "Failed to parse RMT2 options.");
                }

                // Get RenderMethodDefinition (rmdf) to validate category count
                var rmdfTag = RenderMethod.BaseRenderMethod;
                if (rmdfTag == null || rmdfTag.Index == -1)
                    return new TagToolError(CommandError.TagInvalid, "Invalid RenderMethodDefinition reference.");

                var rmdf = Cache.Deserialize<RenderMethodDefinition>(stream, rmdfTag);
                int requiredCategories = Math.Max(rmdf.Categories.Count, 10); // Ensure at least 10 categories

                // Pad options to match required categories
                while (currentOptions.Count < requiredCategories)
                    currentOptions.Add(0);

                // Check if the 9th option (index 9) is already 1
                if (currentOptions.Count > 9 && currentOptions[9] == 1)
                {
                    Console.WriteLine("Option 9 is already set to 1. No changes needed.");
                    return true;
                }

                // Set the 9th option to 1
                if (currentOptions.Count <= 9)
                    currentOptions.Add(1); // Add if missing
                else
                    currentOptions[9] = 1;

                // Update RenderMethod.Options to match parsed options
                RenderMethod.Options.Clear();
                for (int i = 0; i < currentOptions.Count; i++)
                {
                    RenderMethod.Options.Add(new RenderMethod.RenderMethodOptionIndex
                    {
                        OptionIndex = (short)currentOptions[i]
                    });
                }

                // Generate new RMT2 template name
                string shaderType = rmdfTag.Name.Split('\\')[1].Split('.')[0];
                string newRmt2Name = $"shaders\\{shaderType}_templates\\_{string.Join("_", currentOptions)}";

                // Assign or generate the new template
                if (Cache.TagCache.TryGetTag($"{newRmt2Name}.rmt2", out CachedTag newRmt2Tag))
                {
                    RenderMethod.ShaderProperties[0].Template = newRmt2Tag;
                    Console.WriteLine($"Assigned existing template '{newRmt2Name}'.");
                }
                else
                {
                    // Generate new template with updated options
                    Shaders.GenerateShaderCommand.GenerateRenderMethodTemplate(
                        Cache, stream, shaderType, currentOptions.ToArray(), rmdf);

                    if (!Cache.TagCache.TryGetTag($"{newRmt2Name}.rmt2", out newRmt2Tag))
                        return new TagToolError(CommandError.OperationFailed, "Failed to generate new template.");

                    RenderMethod.ShaderProperties[0].Template = newRmt2Tag;
                    Console.WriteLine($"Generated and assigned new template '{newRmt2Name}'.");
                }

                // Save changes
                Cache.Serialize(stream, Tag, RenderMethod);
                Console.WriteLine("Shader options and template updated successfully.");
            }

            return true;
        }
    }
}