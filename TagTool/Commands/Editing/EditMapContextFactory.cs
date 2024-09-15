using TagTool.BlamFile;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.Commands.Editing
{
    public static class EditMapContextFactory 
    {
        public static CommandContext Create(CommandContextStack contextStack, GameCache cache, MapFile mapFile) 
        {
            var commandContext = new CommandContext(contextStack.Context, $@"{mapFile.Header.GetName()}.map");

            commandContext.AddCommand(new ExecuteCSharpCommand(contextStack));

            var structure = TagStructure.GetTagStructureInfo(mapFile.Header.GetType(), cache.Version, cache.Platform);

            commandContext.AddCommand(new ListFieldsCommand(cache, structure, mapFile.Header));
            commandContext.AddCommand(new ExportCommandsCommand(cache, mapFile.Header));
            commandContext.AddCommand(new SaveMapChangesCommand(cache, mapFile));

            commandContext.AddCommand(new ExitToCommand(contextStack));

            return commandContext;
        }
    }
}
