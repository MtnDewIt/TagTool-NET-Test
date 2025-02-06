using System.Collections.Generic;
using TagTool.Cache;

namespace TagTool.Commands.Modding
{
    class EditModMetadataCommand : Command
    {
        private CommandContextStack ContextStack;
        private GameCacheModPackage Cache;

        public EditModMetadataCommand(CommandContextStack contextStack, GameCacheModPackage cache) :
            base(true,

                "EditModMetadata",
                "Opens an editing context for modifying mod package metadata.\n",
                "EditModMetadata",
                "Opens an editing context for modifying mod package metadata.\n")
        {
            ContextStack = contextStack;
            Cache = cache;
        }

        public override object Execute(List<string> args) 
        {
            var modPackageData = new ModPackageData 
            {
                Header = Cache.BaseModPackage.Header,
                Metadata = Cache.BaseModPackage.Metadata,
            };

            ContextStack.Push(ModMetadataContextFactory.Create(ContextStack, Cache, modPackageData));

            return true;
        }
    }
}
