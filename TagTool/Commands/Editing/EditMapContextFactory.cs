using TagTool.BlamFile;
using TagTool.BlamFile.HaloOnline;
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

            var mapDefinition = new HaloOnlineMapFile(mapFile);

            var structure = TagStructure.GetTagStructureInfo(mapDefinition.GetType(), cache.Version, cache.Platform);

            commandContext.AddCommand(new ListFieldsCommand(cache, structure, mapDefinition));
            commandContext.AddCommand(new SetFieldCommand(contextStack, cache, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new EditBlockCommand(contextStack, cache, mapDefinition, mapDefinition));
            //commandContext.AddCommand(new AddBlockElementsCommand(contextStack, cache, mapDefinition, structure, mapDefinition));
            //commandContext.AddCommand(new RemoveBlockElementsCommand(contextStack, cache, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new CopyBlockElementsCommand(contextStack, cache, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new PasteBlockElementsCommand(contextStack, cache, mapDefinition, structure, mapDefinition));
            //commandContext.AddCommand(new MoveBlockElementCommand(contextStack, cache, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new SwapBlockElementsCommand(contextStack, cache, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new ForEachCommand(contextStack, cache, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new ExportCommandsCommand(cache, mapDefinition));
            commandContext.AddCommand(new SaveMapChangesCommand(cache, mapDefinition));
            //commandContext.AddCommand(new FindValueCommand(cache, tag));

            commandContext.AddCommand(new ExitToCommand(contextStack));

            return commandContext;
        }
    }
}
