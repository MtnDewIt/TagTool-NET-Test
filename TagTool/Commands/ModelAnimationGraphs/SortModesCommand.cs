using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Animations;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.ModelAnimationGraphs
{
    public class SortModesCommand : Command
    {
        private GameCache Cache { get; }
        private ModelAnimationGraph Definition { get; }

        public SortModesCommand(GameCache cache, ModelAnimationGraph definition) :
            base(false,
                
                "SortModes",
                "Sorts all \"modes\" block elements in the current model_animation_graph based on their name's string_id set and index.",
                
                "SortModes",

                "Sorts all \"modes\" block elements in the current model_animation_graph based on their name's string_id set and index.")
        {
            Cache = cache;
            Definition = definition;
        }

        public override object Execute(List<string> args)
        {
            if (args.Count != 0)
                return new TagToolError(CommandError.ArgCount);

            AnimationSorter.Sort(Definition);

            Console.WriteLine("Jmad modes sorted successfully.");

            return true;
        }
    }
}