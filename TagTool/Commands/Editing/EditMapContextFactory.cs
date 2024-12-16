using TagTool.BlamFile;
using TagTool.BlamFile.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Commands.Files;
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

            var structure = TagStructure.GetTagStructureInfo(mapDefinition.GetType(), mapFile.Version, mapFile.CachePlatform);

            commandContext.AddCommand(new ListFieldsCommand(cache, structure, mapDefinition));
            commandContext.AddCommand(new SetFieldCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new EditBlockCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, mapDefinition));
            //commandContext.AddCommand(new AddBlockElementsCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, structure, mapDefinition));
            //commandContext.AddCommand(new RemoveBlockElementsCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new CopyBlockElementsCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new PasteBlockElementsCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new MoveBlockElementCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new SwapBlockElementsCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new ForEachCommand(contextStack, cache, mapFile.Version, mapFile.CachePlatform, mapDefinition, structure, mapDefinition));
            commandContext.AddCommand(new ExportCommandsCommand(cache, mapFile.Version, mapFile.CachePlatform, mapDefinition));
            commandContext.AddCommand(new SaveMapChangesCommand(cache, mapDefinition));
            //commandContext.AddCommand(new FindValueCommand(cache, tag));

            commandContext.AddCommand(new ImportMapInfoCommand(cache, mapDefinition));

            commandContext.AddCommand(new ExitToCommand(contextStack));

            return commandContext;
        }
    }
}
