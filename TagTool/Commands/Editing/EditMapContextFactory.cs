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
            commandContext.AddCommand(new ExportCommandsCommand(cache, mapDefinition));
            commandContext.AddCommand(new SaveMapChangesCommand(cache, mapFile));

            commandContext.AddCommand(new ExitToCommand(contextStack));

            return commandContext;
        }
    }
}
