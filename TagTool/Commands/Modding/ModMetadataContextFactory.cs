using TagTool.Cache;
using TagTool.Commands.Editing;
using TagTool.Tags;

namespace TagTool.Commands.Modding
{
    public static class ModMetadataContextFactory
    {
        public static CommandContext Create(CommandContextStack contextStack, GameCacheModPackage cache, object metadata)
        {
            var commandContext = new CommandContext(contextStack.Context, "metadata");

            var structure = TagStructure.GetTagStructureInfo(metadata.GetType(), cache.Version, cache.Platform);

            commandContext.AddCommand(new ListFieldsCommand(cache, structure, metadata));
            commandContext.AddCommand(new SetFieldCommand(contextStack, cache, cache.Version, cache.Platform, metadata, structure, metadata));
            commandContext.AddCommand(new EditBlockCommand(contextStack, cache, cache.Version, cache.Platform, metadata, metadata));
            //commandContext.AddCommand(new AddBlockElementsCommand(contextStack, cache, cache.Version, cache.Platform, metadata, structure, metadata));
            //commandContext.AddCommand(new RemoveBlockElementsCommand(contextStack, cache, cache.Version, cache.Platform, metadata, structure, metadata));
            commandContext.AddCommand(new CopyBlockElementsCommand(contextStack, cache, cache.Version, cache.Platform, metadata, structure, metadata));
            commandContext.AddCommand(new PasteBlockElementsCommand(contextStack, cache, cache.Version, cache.Platform, metadata, structure, metadata));
            commandContext.AddCommand(new MoveBlockElementCommand(contextStack, cache, cache.Version, cache.Platform, metadata, structure, metadata));
            commandContext.AddCommand(new SwapBlockElementsCommand(contextStack, cache, cache.Version, cache.Platform, metadata, structure, metadata));
            commandContext.AddCommand(new ForEachCommand(contextStack, cache, cache.Version, cache.Platform, metadata, structure, metadata));
            commandContext.AddCommand(new ExportCommandsCommand(cache, cache.Version, cache.Platform, metadata as TagStructure));
            //commandContext.AddCommand(new FindValueCommand(cache, tag));
            commandContext.AddCommand(new SaveModMetadataCommand(cache, metadata as ModPackageData));

            return commandContext;
        }
    }
}
