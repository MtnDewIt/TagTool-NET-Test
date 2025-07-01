using TagTool.Cache;
using TagTool.Tags.Definitions;

namespace TagTool.Commands.HUD
{
    public class HudContextFactory
    {
        public static CommandContext Create(CommandContext parent, GameCache cache, CachedTag tag, ChudDefinition chud)
        {
            var groupName = tag.Group.ToString();
            var commandContext = new CommandContext(parent, string.Format("{0:X8}.{1}", tag.Index, groupName));

            Populate(commandContext, cache, tag, chud);

            return commandContext;
        }

        public static void Populate(CommandContext commandContext, GameCache cache, CachedTag tag, ChudDefinition chud)
        {
            commandContext.AddCommand(new SortRuntimeWidgetIndexCommand(cache, chud));
        }
    }
}
