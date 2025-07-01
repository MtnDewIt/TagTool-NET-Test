using System;
using System.Collections.Generic;
using TagTool.Cache;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.HUD
{
    public class SortRuntimeWidgetIndexCommand : Command
    {
        private GameCache Cache { get; }
        private ChudDefinition Chud { get; }

        public SortRuntimeWidgetIndexCommand(GameCache cache, ChudDefinition chud) : base
        (
            false,
            "SortRuntimeWidgetIndex",
            "Sorts all runtime widget index values in the current chud_definition instance",

            "SortRuntimeWidgetIndex",
            "Sorts all runtime widget index values in the current chud_definition instance"
        )
        {
            Cache = cache;
            Chud = chud;
        }

        public override object Execute(List<string> args) 
        {
            var startingIndex = 0;

            foreach (var hudWidget in Chud.HudWidgets) 
            {
                foreach (var bitmapWidget in hudWidget.BitmapWidgets) 
                {
                    bitmapWidget.RuntimeWidgetIndex = startingIndex;
                    startingIndex++;
                }

                foreach (var textWidget in hudWidget.TextWidgets) 
                {
                    textWidget.RuntimeWidgetIndex = startingIndex;
                    startingIndex++;
                }
            }

            Console.WriteLine("Runtime Widget Indices Sorted Successfully.");

            return true;
        }
    }
}
