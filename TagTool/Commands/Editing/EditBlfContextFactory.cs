using System.IO;
using TagTool.BlamFile;
using TagTool.BlamFile.HaloOnline;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Tags;

namespace TagTool.Commands.Editing
{
    public static class EditBlfContextFactory
    {
        public static CommandContext Create(CommandContextStack contextStack, GameCache cache, Blf blf, string filePath) 
        {
            var commandContext = new CommandContext(contextStack.Context, $@"{Path.GetFileName(filePath)}");

            commandContext.AddCommand(new ExecuteCSharpCommand(contextStack));

            var blfDefinition = new HaloOnlineBlf(blf);

            var structure = TagStructure.GetTagStructureInfo(blfDefinition.GetType(), cache.Version, cache.Platform);

            commandContext.AddCommand(new ListFieldsCommand(cache, structure, blfDefinition));
            commandContext.AddCommand(new SetFieldCommand(contextStack, cache, blfDefinition, structure, blfDefinition));
            commandContext.AddCommand(new EditBlockCommand(contextStack, cache, blfDefinition, blfDefinition));
            //commandContext.AddCommand(new AddBlockElementsCommand(contextStack, cache, blfDefinition, structure, blfDefinition));
            //commandContext.AddCommand(new RemoveBlockElementsCommand(contextStack, cache, blfDefinition, structure, blfDefinition));
            commandContext.AddCommand(new CopyBlockElementsCommand(contextStack, cache, blfDefinition, structure, blfDefinition));
            commandContext.AddCommand(new PasteBlockElementsCommand(contextStack, cache, blfDefinition, structure, blfDefinition));
            commandContext.AddCommand(new MoveBlockElementCommand(contextStack, cache, blfDefinition, structure, blfDefinition));
            commandContext.AddCommand(new SwapBlockElementsCommand(contextStack, cache, blfDefinition, structure, blfDefinition));
            commandContext.AddCommand(new ForEachCommand(contextStack, cache, blfDefinition, structure, blfDefinition));
            commandContext.AddCommand(new ExportCommandsCommand(cache, blfDefinition));
            commandContext.AddCommand(new SaveBlfChangesCommand(cache, blfDefinition, filePath));
            //commandContext.AddCommand(new FindValueCommand(cache, tag));

            commandContext.AddCommand(new ExitToCommand(contextStack));

            return commandContext;
        }
    }
}
